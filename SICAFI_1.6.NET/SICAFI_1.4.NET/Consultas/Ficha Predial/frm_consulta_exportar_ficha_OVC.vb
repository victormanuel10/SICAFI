Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_exportar_ficha_OVC

    '===================================
    '*** CONSULTA EXPORTAR FICHA OVC ***
    '===================================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet

    Private dtFicha As New DataTable
    Private dtZonasHomogeneas As New DataTable
    Private dtZonasHomogeneasFisica As New DataTable
    Private dtZonasHomogeneasGeoeconomicas As New DataTable
    Private dtCartografiaInformacionGrafica As New DataTable
    Private dtConstrucciones As New DataTable
    Private dtCalificacionConstrucciones As New DataTable
    Private dtConstruccionesGenerales As New DataTable
    Private dtColindantes As New DataTable
    Private dtEdificio As New DataTable
    Private dtFichasPrediales As New DataTable
    Private dtConstruccionesFicha As New DataTable
    Private dtCalificacionesConsFicha As New DataTable
    Private dtConstruccionGeneralFicha As New DataTable
    Private dtColindantesFicha As New DataTable
    Private dtPropietarios As New DataTable

    Private dt_Ficha As New DataTable
    Private dt_ZonasHomogeneas As New DataTable
    Private dt_ZonasHomogeneasFisicas As New DataTable
    Private dt_ZonasHomogeneasGeoeconomica As New DataTable
    Private dt_CartografiaInformacionGrafica As New DataTable
    Private dt_Construcciones As New DataTable
    Private dt_CalificacionConstrucciones As New DataTable
    Private dt_ConstruccionesGenerales As New DataTable
    Private dt_Colindantes As New DataTable
    Private dt_Edificio As New DataTable
    Private dt_FichasPrediales As New DataTable
    Private dt_ConstruccionesFicha As New DataTable
    Private dt_CalificacionesConsFicha As New DataTable
    Private dt_ConstruccionGeneralFicha As New DataTable
    Private dt_ColindantesFicha As New DataTable
    Private dt_Propietarios As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_exportar_ficha_OVC
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_exportar_ficha_OVC
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

    ' variables verificar datos
    Dim stFIPRFIIN As String = ""
    Dim stFIPRFIFI As String = ""
    Dim stFIPRDIRE As String = ""
    Dim stFIPRMUNI As String = ""
    Dim stFIPRCORR As String = ""
    Dim stFIPRBARR As String = ""
    Dim stFIPRMANZ As String = ""
    Dim stFIPRPRED As String = ""
    Dim stFIPREDIF As String = ""
    Dim stFIPRUNPR As String = ""
    Dim stFIPRCLSE As String = ""
    Dim stFIPRCASU As String = ""
    Dim stFIPRCAPR As String = ""
    Dim stFIPRMOAD As String = ""
    Dim stFIPRESTA As String = ""

    Dim stDireccionReferencia As String = ""
    Dim stDireccionNombre As String = ""
    Dim stCodigoFideicomiso As String = ""
    Dim stValorCompra As String = ""
    Dim stAreaTotalLote As String = "1"

    ' variables guardar consulta
    Dim Guardar_stFIPRFIIN As String = ""
    Dim Guardar_stFIPRFIFI As String = ""
    Dim Guardar_stFIPRDIRE As String = ""
    Dim Guardar_stFIPRMUNI As String = ""
    Dim Guardar_stFIPRCORR As String = ""
    Dim Guardar_stFIPRBARR As String = ""
    Dim Guardar_stFIPRMANZ As String = ""
    Dim Guardar_stFIPRPRED As String = ""
    Dim Guardar_stFIPREDIF As String = ""
    Dim Guardar_stFIPRUNPR As String = ""
    Dim Guardar_stFIPRCLSE As String = ""
    Dim Guardar_stFIPRCASU As String = ""
    Dim Guardar_stFIPRCAPR As String = ""
    Dim Guardar_stFIPRMOAD As String = ""
    Dim Guardar_stFIPRESTA As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRFIIN.Text = "0"
        Me.txtFIPRFIFI.Text = "999999999"
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
        Me.txtFIPRESTA.Text = ""
        Me.lblFIPRCLSE.Text = ""
        Me.lblFIPRCASU.Text = ""
        Me.lblFIPRCAPR.Text = ""
        Me.lblFIPRMOAD.Text = ""
     
        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvFicha.DataSource = New DataTable
        Me.dgvZonasHomogeneas.DataSource = New DataTable
        Me.dgvCartografiaInformacionGrafica.DataSource = New DataTable
        Me.dgvConstrucciones.DataSource = New DataTable
        Me.dgvCalificacionConstrucciones.DataSource = New DataTable
        Me.dgvConstruccionesGenerales.DataSource = New DataTable
        Me.dgvColindantes.DataSource = New DataTable
        Me.dgvEdificio.DataSource = New DataTable
        Me.dgvFichasPrediales.DataSource = New DataTable
        Me.dgvConstruccionesFicha.DataSource = New DataTable
        Me.dgvCalificacionesConsFicha.DataSource = New DataTable
        Me.dgvConstruccionGeneralFicha.DataSource = New DataTable
        Me.dgvColindantesFicha.DataSource = New DataTable
        Me.dgvPropietarios.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(Me.txtFIPRFIIN.Text) = "" Then
            stFIPRFIIN = "%"
        Else
            stFIPRFIIN = Trim(Me.txtFIPRFIIN.Text)
        End If

        If Trim(Me.txtFIPRFIFI.Text) = "" Then
            stFIPRFIFI = "%"
        Else
            stFIPRFIFI = Trim(Me.txtFIPRFIFI.Text)
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

        If Trim(Me.txtFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
        End If

    End Sub
    Private Sub pro_GuardarConsulta()

        Guardar_stFIPRFIIN = Trim(Me.txtFIPRFIIN.Text)
        Guardar_stFIPRFIFI = Trim(Me.txtFIPRFIFI.Text)
        Guardar_stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        Guardar_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        Guardar_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        Guardar_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        Guardar_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        Guardar_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        Guardar_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        Guardar_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        Guardar_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        Guardar_stFIPRCASU = Trim(Me.txtFIPRCASU.Text)
        Guardar_stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)
        Guardar_stFIPRMOAD = Trim(Me.txtFIPRMOAD.Text)
        Guardar_stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
       
    End Sub
    Private Sub pro_ObtenerConsulta()

        Me.txtFIPRFIIN.Text = Guardar_stFIPRFIIN
        Me.txtFIPRFIFI.Text = Guardar_stFIPRFIFI
        Me.txtFIPRDIRE.Text = Guardar_stFIPRDIRE
        Me.txtFIPRMUNI.Text = Guardar_stFIPRMUNI
        Me.txtFIPRCORR.Text = Guardar_stFIPRCORR
        Me.txtFIPRBARR.Text = Guardar_stFIPRBARR
        Me.txtFIPRMANZ.Text = Guardar_stFIPRMANZ
        Me.txtFIPRPRED.Text = Guardar_stFIPRPRED
        Me.txtFIPREDIF.Text = Guardar_stFIPREDIF
        Me.txtFIPRUNPR.Text = Guardar_stFIPRUNPR
        Me.txtFIPRCLSE.Text = Guardar_stFIPRCLSE
        Me.txtFIPRCASU.Text = Guardar_stFIPRCASU
        Me.txtFIPRCAPR.Text = Guardar_stFIPRCAPR
        Me.txtFIPRMOAD.Text = Guardar_stFIPRMOAD
        Me.txtFIPRESTA.Text = Guardar_stFIPRESTA

    End Sub
    Private Sub pro_PermisoExportar()

        Dim objdatos1 As New cla_CONTRASENA
        Dim tbl1 As New DataTable

        tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

        Dim boCONTCOFP As Boolean = Trim(tbl1.Rows(0).Item(8))

        If boCONTCOFP = True Then

            Me.cmdExportarExcelFicha.Enabled = True
            Me.cmdExportarExcelZonasHomogeneas.Enabled = True
            Me.cmdExportarExcelCartografiaInformacionGrafica.Enabled = True
            Me.cmdExportarExcelConstrucciones.Enabled = True
            Me.cmdExportarExcelCalificacionConstrucciones.Enabled = True
            Me.cmdExportarExcelConstruccionesGenerales.Enabled = True
            Me.cmdExportarExcelColindantes.Enabled = True
            Me.cmdExportarExcelEdificio.Enabled = True
            Me.cmdExportarExcelFichasPrediales.Enabled = True
            Me.cmdExportarExcelConstruccionesFicha.Enabled = True
            Me.cmdExportarExcelCalificacionConsFicha.Enabled = True
            Me.cmdExportarExcelConstruccionGeneralFicha.Enabled = True
            Me.cmdExportarExcelColindantesFicha.Enabled = True
            Me.cmdExportarExcelPropietarios.Enabled = True
        Else
            Me.cmdExportarExcelFicha.Enabled = False
            Me.cmdExportarExcelZonasHomogeneas.Enabled = False
            Me.cmdExportarExcelCartografiaInformacionGrafica.Enabled = False
            Me.cmdExportarExcelConstrucciones.Enabled = False
            Me.cmdExportarExcelCalificacionConstrucciones.Enabled = False
            Me.cmdExportarExcelConstruccionesGenerales.Enabled = False
            Me.cmdExportarExcelColindantes.Enabled = False
            Me.cmdExportarExcelEdificio.Enabled = False
            Me.cmdExportarExcelFichasPrediales.Enabled = False
            Me.cmdExportarExcelConstruccionesFicha.Enabled = False
            Me.cmdExportarExcelCalificacionConsFicha.Enabled = False
            Me.cmdExportarExcelConstruccionGeneralFicha.Enabled = False
            Me.cmdExportarExcelColindantesFicha.Enabled = False
            Me.cmdExportarExcelPropietarios.Enabled = False

        End If

    End Sub

#End Region

#Region "FUNCION"

    Function fun_ConsultarMatricula(ByVal inNroFicha As Integer) As String

        Try
            ' declaro la variable
            Dim stMatricula As String = ""
            Dim inTamano As Integer = 0
            Dim stLetra As String = ""

            ' instancia la clase
            Dim obFIPRPROP As New cla_FIPRPROP
            Dim tdFIPRPROP As New DataTable

            tdFIPRPROP = obFIPRPROP.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(inNroFicha)

            If tdFIPRPROP.Rows.Count > 0 Then

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To tdFIPRPROP.Rows.Count - 1

                    stMatricula = Trim(tdFIPRPROP.Rows(i).Item("FPPRMAIN"))

                Next

                ' almaceno la longitud
                inTamano = stMatricula.ToString.Length

                ' declaro la variable 
                Dim inSeparador As Integer = 0
                Dim stSeparador As String = ""
                Dim ii As Integer = 0

                For ii = 0 To inTamano - 1

                    stSeparador = stMatricula.ToString.Substring(ii, 1)

                    If inSeparador = 1 Then
                        stLetra += stMatricula.ToString.Substring(ii, 1)
                    End If

                    If stSeparador = "-" Then
                        inSeparador = 1
                    End If

                Next

                ' llena la matricula 
                stMatricula = stLetra

            End If

            Return stMatricula

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_ConsultarDestino(ByVal inNroFicha As Integer) As String

        Try
            ' declaro la variable
            Dim stDestino As String = ""

            ' instancia la clase
            Dim obFIPRDEEC As New cla_FIPRDEEC
            Dim tdFIPRDEEC As New DataTable

            tdFIPRDEEC = obFIPRDEEC.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(inNroFicha)

            If tdFIPRDEEC.Rows.Count > 0 Then

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To tdFIPRDEEC.Rows.Count - 1

                    stDestino = Trim(tdFIPRDEEC.Rows(i).Item("FPDEDEEC"))

                Next

            End If

            Return stDestino

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_ConsultarPiso(ByVal stDireccion As String) As Integer

        Try
            Dim inPiso As Integer = 1
            Dim stApto As String = ""
            Dim inLongitud As Integer = Trim(stDireccion).ToString.Length
            Dim inPosiocionApto As Integer = 0

            If inLongitud >= 3 Then

                Dim i As Integer = 0

                For i = 0 To (inLongitud - 4) - 1

                    If Trim(stDireccion).ToString.Substring(i, 4) = " AP " Or _
                       Trim(stDireccion).ToString.Substring(i, 4) = " AP-" Then

                        inPosiocionApto = i

                        If (inLongitud - inPosiocionApto) >= 7 Then

                            Dim stNivelPisos As String = 0

                            stNivelPisos = fun_ConsultarNivelPiso(Trim(stDireccion).ToString.Substring(i, (inLongitud - inPosiocionApto)))

                            If stNivelPisos <> 0 Then
                                inPiso = stNivelPisos
                            End If

                            Exit For

                        End If

                    End If

                Next

            End If

            Return inPiso

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_ConsultarNivelPiso(ByVal stDireccion As String) As String

        Try
            Dim inLongitud As Integer = stDireccion.ToString.Length
            Dim stApto As String = ""
            Dim stPiso As String = "1"
            Dim bySW As Byte = 0

            Dim i As Integer = 0

            For i = 0 To inLongitud - 1

                If fun_Verificar_Dato_Numerico_Evento_Validated(stDireccion.ToString.Substring(i, 1)) = True And bySW = 0 Then

                    stApto += stDireccion.ToString.Substring(i, 1)

                Else
                    If stApto.ToString.Length >= 3 And stDireccion.ToString.Substring(i, 1) = " " Then

                        bySW = 1

                    End If
                End If

            Next

            If stApto.ToString.Length = 3 Then
                stPiso = stApto.ToString.Substring(0, 1)
            ElseIf stApto.ToString.Length = 4 Then
                stPiso = stApto.ToString.Substring(0, 1)
            ElseIf stApto.ToString.Length = 5 Then
                stPiso = stApto.ToString.Substring(0, 2)
            End If

            Return stPiso

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Function fun_Ficha() As DataTable

        Try
            ' informacion 
            stDireccionReferencia = InputBox("Ingrese la Direccion Referencia (El Barrio)", "Información")
            stDireccionNombre = InputBox("Ingrese la Direccion Nombre (Nombre de la Urbanización ó Conjunto)", "Información")
            stCodigoFideicomiso = InputBox("Ingrese el Fideicomiso", "Información")
            stValorCompra = InputBox("Ingrese el Valor de la compra (avalúo de la escritura)", "Información")

            stDireccionReferencia = stDireccionReferencia.ToString.ToUpper
            stDireccionNombre = stDireccionNombre.ToString.ToUpper

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtFicha = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi, "
            ParametrosConsulta += "FiprDepa, "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprDire, "
            ParametrosConsulta += "FiprCapr, "
            ParametrosConsulta += "FiprAtlo, "
            ParametrosConsulta += "FiprAclo, "
            ParametrosConsulta += "FiprToed, "
            ParametrosConsulta += "FiprUrph, "
            ParametrosConsulta += "FiprApca, "
            ParametrosConsulta += "FiprLoca, "
            ParametrosConsulta += "FiprGacu, "
            ParametrosConsulta += "FiprGade, "
            ParametrosConsulta += "FiprCuut  "

            ParametrosConsulta += "From FichPred where "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') "

            ParametrosConsulta += "order by FiprNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtFicha)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_Ficha As DataRow

            ' limpia la tabla
            dt_Ficha = New DataTable

            ' crea campos dinamicamente
            dt_Ficha.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("Objectld", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("NumCedCatastral", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("Municipio", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("Sector", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("Corregimiento", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("Barrio", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("ManzanVereda", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("Predio", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("DireccionReferencia", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("DireccionNombre", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("DireccionReal", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("CaracteristicaPredio", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("AreaTotalLote", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("AreaLoteComun", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("TotalEdificio", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("UnidadesEnRPH", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("ApartamentosOCasas", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("Locales", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("GarajesCubiertos", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("GarajesDescubiertos", GetType(String)))
            dt_Ficha.Columns.Add(New DataColumn("CuartosUtiles", GetType(String)))

            ' verifica que existan registros
            If dtFicha.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtFicha.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_Ficha = dt_Ficha.NewRow()

                    dr_Ficha("NroFicha") = Trim(dtFicha.Rows(i).Item("FiprNufi"))
                    dr_Ficha("Objectld") = "0"
                    dr_Ficha("NumCedCatastral") = "0"
                    dr_Ficha("Municipio") = Trim(dtFicha.Rows(i).Item("FiprMuni")) & "|" & fun_Buscar_Lista_Valores_MUNICIPIO(Trim(dtFicha.Rows(i).Item("FiprDepa")), Trim(dtFicha.Rows(i).Item("FiprMuni")))
                    dr_Ficha("Sector") = Trim(dtFicha.Rows(i).Item("FiprClse")) & "|" & fun_Buscar_Lista_Valores_CLASSECT(Trim(dtFicha.Rows(i).Item("FiprClse")))
                    dr_Ficha("Corregimiento") = Trim(dtFicha.Rows(i).Item("FiprCorr"))
                    dr_Ficha("Barrio") = Trim(dtFicha.Rows(i).Item("FiprBarr"))
                    dr_Ficha("ManzanVereda") = Trim(dtFicha.Rows(i).Item("FiprManz"))
                    dr_Ficha("Predio") = Trim(dtFicha.Rows(i).Item("FiprPred"))
                    dr_Ficha("DireccionReferencia") = stDireccionReferencia
                    dr_Ficha("DireccionNombre") = stDireccionNombre
                    dr_Ficha("DireccionReal") = Trim(dtFicha.Rows(i).Item("FiprDire"))
                    dr_Ficha("CaracteristicaPredio") = Trim(dtFicha.Rows(i).Item("FiprCapr")) & "|" & fun_Buscar_Lista_Valores_CARAPRED(Trim(dtFicha.Rows(i).Item("FiprCapr")))
                    dr_Ficha("AreaTotalLote") = Trim(dtFicha.Rows(i).Item("FiprAtlo"))
                    dr_Ficha("AreaLoteComun") = Trim(dtFicha.Rows(i).Item("FiprAclo"))
                    dr_Ficha("TotalEdificio") = Trim(dtFicha.Rows(i).Item("FiprToed"))
                    dr_Ficha("UnidadesEnRPH") = Trim(dtFicha.Rows(i).Item("FiprUrph"))
                    dr_Ficha("ApartamentosOCasas") = Trim(dtFicha.Rows(i).Item("FiprApca"))
                    dr_Ficha("Locales") = Trim(dtFicha.Rows(i).Item("FiprLoca"))
                    dr_Ficha("GarajesCubiertos") = Trim(dtFicha.Rows(i).Item("FiprGacu"))
                    dr_Ficha("GarajesDescubiertos") = Trim(dtFicha.Rows(i).Item("FiprGade"))
                    dr_Ficha("CuartosUtiles") = Trim(dtFicha.Rows(i).Item("FiprCuut"))

                    dt_Ficha.Rows.Add(dr_Ficha)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Ficha)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_Ficha

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_ZonasHomogeneas() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtZonasHomogeneasFisica = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpzfNufi, "
            ParametrosConsulta += "FpzfDepa, "
            ParametrosConsulta += "FpzfClse, "
            ParametrosConsulta += "FpzfZofi, "
            ParametrosConsulta += "FpzfPorc  "

            ParametrosConsulta += "From FichPred, FiprZofi where "
            ParametrosConsulta += "FiprNufi = FpzfNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') "

            ParametrosConsulta += "order by FpzfNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtZonasHomogeneasFisica)

            ' cierra la conexion
            oConexion.Close()

            ' buscar cadena de conexion
            Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion1 As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtZonasHomogeneasGeoeconomicas = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta1 As String = ""

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta1 += "Select "
            ParametrosConsulta1 += "FpzeNufi, "
            ParametrosConsulta1 += "FpzeDepa, "
            ParametrosConsulta1 += "FpzeClse, "
            ParametrosConsulta1 += "FpzeZoec, "
            ParametrosConsulta1 += "FpzePorc  "

            ParametrosConsulta1 += "From FichPred, FiprZoec where "
            ParametrosConsulta1 += "FiprNufi = FpzeNufi and "

            ParametrosConsulta1 += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
            ParametrosConsulta1 += "FiprDire like '" & stFIPRDIRE & "' and "
            ParametrosConsulta1 += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta1 += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta1 += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta1 += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta1 += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta1 += "FiprEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta1 += "FiprUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta1 += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta1 += "FiprCasu like '" & stFIPRCASU & "' and "
            ParametrosConsulta1 += "FiprCapr like '" & stFIPRCAPR & "' and "
            ParametrosConsulta1 += "FiprMoad like '" & stFIPRMOAD & "' and "
            ParametrosConsulta1 += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta1 += "FiprTifi in ('1','2') "

            ParametrosConsulta1 += "order by FpzeNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtZonasHomogeneasGeoeconomicas)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_ZonasHomogeneas As DataRow

            ' limpia la tabla
            dt_ZonasHomogeneas = New DataTable

            ' crea campos dinamicamente
            dt_ZonasHomogeneas.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_ZonasHomogeneas.Columns.Add(New DataColumn("Tipo", GetType(String)))
            dt_ZonasHomogeneas.Columns.Add(New DataColumn("Sector", GetType(String)))
            dt_ZonasHomogeneas.Columns.Add(New DataColumn("IdentificadorZona", GetType(String)))
            dt_ZonasHomogeneas.Columns.Add(New DataColumn("Área", GetType(String)))
            dt_ZonasHomogeneas.Columns.Add(New DataColumn("TipoZona", GetType(String)))

            ' verifica que existan registros
            If dtZonasHomogeneasFisica.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtZonasHomogeneasFisica.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_ZonasHomogeneas = dt_ZonasHomogeneas.NewRow()

                    dr_ZonasHomogeneas("NroFicha") = Trim(dtZonasHomogeneasFisica.Rows(i).Item("FpzfNufi"))
                    dr_ZonasHomogeneas("Tipo") = "Fisica"
                    dr_ZonasHomogeneas("Sector") = Trim(dtZonasHomogeneasFisica.Rows(i).Item("FpzfClse")) & "|" & fun_Buscar_Lista_Valores_CLASSECT(Trim(dtZonasHomogeneasFisica.Rows(i).Item("FpzfClse")))
                    dr_ZonasHomogeneas("IdentificadorZona") = Trim(dtZonasHomogeneasFisica.Rows(i).Item("FpzfZofi"))
                    dr_ZonasHomogeneas("Área") = Trim("0")
                    dr_ZonasHomogeneas("TipoZona") = Trim("1|Ocupada")

                    dt_ZonasHomogeneas.Rows.Add(dr_ZonasHomogeneas)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Zonas Homogeneas)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            ' verifica que existan registros
            If dtZonasHomogeneasGeoeconomicas.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtZonasHomogeneasGeoeconomicas.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_ZonasHomogeneas = dt_ZonasHomogeneas.NewRow()

                    dr_ZonasHomogeneas("NroFicha") = Trim(dtZonasHomogeneasGeoeconomicas.Rows(i).Item("FpzeNufi"))
                    dr_ZonasHomogeneas("Tipo") = "Geoeconomica"
                    dr_ZonasHomogeneas("Sector") = Trim(dtZonasHomogeneasGeoeconomicas.Rows(i).Item("FpzeClse")) & "|" & fun_Buscar_Lista_Valores_CLASSECT(Trim(dtZonasHomogeneasGeoeconomicas.Rows(i).Item("FpzeClse")))
                    dr_ZonasHomogeneas("IdentificadorZona") = Trim(dtZonasHomogeneasGeoeconomicas.Rows(i).Item("FpzeZoec"))
                    dr_ZonasHomogeneas("Área") = Trim("0")
                    dr_ZonasHomogeneas("TipoZona") = Trim("1|Ocupada")

                    dt_ZonasHomogeneas.Rows.Add(dr_ZonasHomogeneas)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Zonas Homogeneas)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_ZonasHomogeneas

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_CartografiaInformacionGrafica() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtCartografiaInformacionGrafica = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcaNufi, "
            ParametrosConsulta += "FpcaPlan, "
            ParametrosConsulta += "FpcaVent, "
            ParametrosConsulta += "FpcaEsgr, "
            ParametrosConsulta += "FpcaVigr, "
            ParametrosConsulta += "FpcaVuel, "
            ParametrosConsulta += "FpcaFaja, "
            ParametrosConsulta += "FpcaFoto, "
            ParametrosConsulta += "FpcaViae, "
            ParametrosConsulta += "FpcaAmpl, "
            ParametrosConsulta += "FpcaEsae  "

            ParametrosConsulta += "From FichPred, FiprCart where "
            ParametrosConsulta += "FiprNufi = FpcaNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') "

            ParametrosConsulta += "order by FpcaNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtCartografiaInformacionGrafica)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_CartografiaInformacionGrafica As DataRow

            ' limpia la tabla
            dt_CartografiaInformacionGrafica = New DataTable

            ' crea campos dinamicamente
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("IndicePlancha", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("Ventana", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("Escala", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("Vigencia", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("IndiceVuelo", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("Faja", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("Foto", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("VigenciaAero", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("ampliacion", GetType(String)))
            dt_CartografiaInformacionGrafica.Columns.Add(New DataColumn("EscalaAero", GetType(String)))

            ' verifica que existan registros
            If dtCartografiaInformacionGrafica.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtCartografiaInformacionGrafica.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_CartografiaInformacionGrafica = dt_CartografiaInformacionGrafica.NewRow()

                    dr_CartografiaInformacionGrafica("NroFicha") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaNufi"))
                    dr_CartografiaInformacionGrafica("IndicePlancha") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaPlan"))
                    dr_CartografiaInformacionGrafica("Ventana") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaVent"))
                    dr_CartografiaInformacionGrafica("Escala") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaEsgr")) & " _"
                    dr_CartografiaInformacionGrafica("Vigencia") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaVigr"))
                    dr_CartografiaInformacionGrafica("IndiceVuelo") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaVuel"))
                    dr_CartografiaInformacionGrafica("Faja") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaFaja"))
                    dr_CartografiaInformacionGrafica("Foto") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaFoto"))
                    dr_CartografiaInformacionGrafica("VigenciaAero") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("Fpcaviae"))
                    dr_CartografiaInformacionGrafica("ampliacion") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaAmpl"))
                    dr_CartografiaInformacionGrafica("EscalaAero") = Trim(dtCartografiaInformacionGrafica.Rows(i).Item("FpcaEsae")) & " _"

                    dt_CartografiaInformacionGrafica.Rows.Add(dr_CartografiaInformacionGrafica)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Cartografia)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_CartografiaInformacionGrafica

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_Construcciones() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtConstrucciones = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoIdre, "
            ParametrosConsulta += "FpcoDepa, "
            ParametrosConsulta += "FpcoMuni, "
            ParametrosConsulta += "FpcoClse, "
            ParametrosConsulta += "FpcoNufi, "
            ParametrosConsulta += "FpcoSecu, "
            ParametrosConsulta += "FpcoUnid, "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "FpcoClco, "
            ParametrosConsulta += "FpcoPunt, "
            ParametrosConsulta += "FpcoArco, "
            ParametrosConsulta += "FpcoEdco, "
            ParametrosConsulta += "FpcoPiso, "
            ParametrosConsulta += "FpcoPoco  "

            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') "

            ParametrosConsulta += "order by FpcoNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConstrucciones)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_Construcciones As DataRow

            ' limpia la tabla
            dt_Construcciones = New DataTable

            ' crea campos dinamicamente
            dt_Construcciones.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("Secuencia", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("NumeroConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("ObjectIdConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("ObjectIdModelo", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TipoConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("IdentificadoUso", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("ConvencionalNoConvencional", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("CalificacionNoConvencional", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("Puntos", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("AreaConstruida", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("NumeroPisos", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("EdadConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("PorcentajeConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("Tipificacion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TotalCocinas", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TotalHabitaciones", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TotalLocales", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TotalBaños", GetType(String)))

            ' verifica que existan registros
            If dtConstrucciones.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtConstrucciones.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_Construcciones = dt_Construcciones.NewRow()

                    dr_Construcciones("NroFicha") = Trim(dtConstrucciones.Rows(i).Item("FpcoNufi"))
                    dr_Construcciones("Secuencia") = Trim(dtConstrucciones.Rows(i).Item("FpcoIdre"))
                    dr_Construcciones("NumeroConstruccion") = Trim(dtConstrucciones.Rows(i).Item("FpcoUnid"))
                    dr_Construcciones("ObjectIdConstruccion") = ""
                    dr_Construcciones("ObjectIdModelo") = ""

                    Dim objdatos15 As New cla_TIPOCONS
                    Dim tbl15 As New DataTable

                    tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(dtConstrucciones.Rows(i).Item("FpcoDepa")), Trim(dtConstrucciones.Rows(i).Item("FpcoMuni")), Trim(dtConstrucciones.Rows(i).Item("FpcoClco")), Trim(dtConstrucciones.Rows(i).Item("FpcoClse")), Trim(dtConstrucciones.Rows(i).Item("FpcoTico")))

                    Dim stFPCOTIPO As String = ""

                    If tbl15.Rows.Count > 0 Then
                        stFPCOTIPO = Trim(tbl15.Rows(0).Item(4))
                    End If

                    If Trim(stFPCOTIPO) = "O" Then
                        stFPCOTIPO = ""
                    End If

                    dr_Construcciones("TipoConstruccion") = stFPCOTIPO
                    dr_Construcciones("IdentificadoUso") = Trim(dtConstrucciones.Rows(i).Item("FpcoTico")) & "|" & fun_Buscar_Lista_Valores_TIPOCONS(Trim(dtConstrucciones.Rows(i).Item("FpcoDepa")), Trim(dtConstrucciones.Rows(i).Item("FpcoMuni")), Trim(dtConstrucciones.Rows(i).Item("FpcoClco")), Trim(dtConstrucciones.Rows(i).Item("FpcoClse")), Trim(dtConstrucciones.Rows(i).Item("FpcoTico")))

                    If Trim(dtConstrucciones.Rows(i).Item("FpcoClco")) = 1 Then
                        dr_Construcciones("ConvencionalNoConvencional") = "Convencional"
                    ElseIf Trim(dtConstrucciones.Rows(i).Item("FpcoClco")) = 2 Then
                        dr_Construcciones("ConvencionalNoConvencional") = "No Convencional"
                    End If

                    If Trim(dtConstrucciones.Rows(i).Item("FpcoClco")) = 1 Then
                        dr_Construcciones("CalificacionNoConvencional") = ""
                        dr_Construcciones("Puntos") = Trim(dtConstrucciones.Rows(i).Item("FpcoPunt"))
                    ElseIf Trim(dtConstrucciones.Rows(i).Item("FpcoClco")) = 2 Then
                        dr_Construcciones("CalificacionNoConvencional") = Trim(dtConstrucciones.Rows(i).Item("FpcoPunt"))
                        dr_Construcciones("Puntos") = ""
                    End If

                    dr_Construcciones("AreaConstruida") = Trim(dtConstrucciones.Rows(i).Item("FpcoArco"))
                    dr_Construcciones("NumeroPisos") = Trim(dtConstrucciones.Rows(i).Item("FpcoPiso"))
                    dr_Construcciones("EdadConstruccion") = Trim(dtConstrucciones.Rows(i).Item("FpcoEdco"))
                    dr_Construcciones("PorcentajeConstruccion") = Trim(dtConstrucciones.Rows(i).Item("FpcoPoco"))

                    dr_Construcciones("Tipificacion") = ""

                    If Trim(stFPCOTIPO) = "R" Then
                        dr_Construcciones("TotalCocinas") = "1"
                        dr_Construcciones("TotalHabitaciones") = "1"
                        dr_Construcciones("TotalLocales") = "0"
                        dr_Construcciones("TotalBaños") = "1"

                    ElseIf Trim(stFPCOTIPO) = "C" Then
                        dr_Construcciones("TotalCocinas") = "0"
                        dr_Construcciones("TotalHabitaciones") = "0"
                        dr_Construcciones("TotalLocales") = "1"
                        dr_Construcciones("TotalBaños") = "0"

                    ElseIf Trim(stFPCOTIPO) = "I" Or Trim(stFPCOTIPO) = "O" Then
                        dr_Construcciones("TotalCocinas") = "0"
                        dr_Construcciones("TotalHabitaciones") = "0"
                        dr_Construcciones("TotalLocales") = "0"
                        dr_Construcciones("TotalBaños") = "0"

                    End If

                    dt_Construcciones.Rows.Add(dr_Construcciones)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Construcciones)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_Construcciones

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_CalificacionesConstrucciones() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtCalificacionConstrucciones = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoIdre, "
            ParametrosConsulta += "FpcoDepa, "
            ParametrosConsulta += "FpcoMuni, "
            ParametrosConsulta += "FpcoClse, "
            ParametrosConsulta += "FpcoNufi, "
            ParametrosConsulta += "FpcoSecu, "
            ParametrosConsulta += "FpcoUnid, "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "FpcoClco, "
            ParametrosConsulta += "FpcoPunt, "
            ParametrosConsulta += "FpcoArco, "
            ParametrosConsulta += "FpcoEdco, "
            ParametrosConsulta += "FpcoPiso, "
            ParametrosConsulta += "FpcoPoco  "

            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') "

            ParametrosConsulta += "order by FpcoNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtCalificacionConstrucciones)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_CalificacionConstrucciones As DataRow

            ' limpia la tabla
            dt_CalificacionConstrucciones = New DataTable

            ' crea campos dinamicamente
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Secuencia", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Armazon", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Muro", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Cubierta", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Conservacion", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Fachada", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("CubrimientoMuro", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Piso", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("ConservacionPrincipales", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("TamanioBanio", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("EnchapesBanio", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("MobiliarioBanio", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("ConservacionBanio", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("TamanioCocina", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Enchape", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("MobiliarioCocina", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("ConservacionCocina", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("ComplementoIndustrial", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Altura", GetType(String)))

            ' verifica que existan registros
            If dtCalificacionConstrucciones.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtCalificacionConstrucciones.Rows.Count - 1

                    Dim inIdreCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoIdre")
                    Dim inNufiCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoNufi")
                    Dim inSecuCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoSecu")
                    Dim inUnidCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoUnid")
                    Dim inClcoCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoClco")

                    ' declaro la instancia
                    Dim obCalificacion As New cla_FIPRCACO
                    Dim dtCalificacion As New DataTable

                    dtCalificacion = obCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL(inNufiCons, inUnidCons)

                    If dtCalificacion.Rows.Count > 0 Then

                        ' inserta un nuevo registro
                        dr_CalificacionConstrucciones = dt_CalificacionConstrucciones.NewRow()

                        dr_CalificacionConstrucciones("Secuencia") = Trim(inIdreCons)

                        ' declara la variable
                        Dim ii As Integer = 0

                        For ii = 0 To dtCalificacion.Rows.Count - 1

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "111" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "112" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "113" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "114" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "115" Then

                                dr_CalificacionConstrucciones("Armazon") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "121" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "122" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "123" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "124" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "125" Then

                                dr_CalificacionConstrucciones("Muro") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "131" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "132" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "133" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "134" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "135" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "136" Then

                                dr_CalificacionConstrucciones("Cubierta") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "141" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "142" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "143" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "144" Then

                                dr_CalificacionConstrucciones("Conservacion") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "211" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "212" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "213" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "214" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "215" Then

                                dr_CalificacionConstrucciones("Fachada") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "221" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "222" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "223" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "224" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "225" Then

                                dr_CalificacionConstrucciones("CubrimientoMuro") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "231" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "232" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "233" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "234" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "235" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "236" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "237" Then

                                dr_CalificacionConstrucciones("Piso") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "241" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "242" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "243" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "244" Then

                                dr_CalificacionConstrucciones("ConservacionPrincipales") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "311" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "312" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "313" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "314" Then

                                dr_CalificacionConstrucciones("TamanioBanio") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "321" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "322" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "323" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "324" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "325" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "326" Then

                                dr_CalificacionConstrucciones("EnchapesBanio") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "331" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "332" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "333" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "334" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "335" Then

                                dr_CalificacionConstrucciones("MobiliarioBanio") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "341" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "342" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "343" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "344" Then

                                dr_CalificacionConstrucciones("ConservacionBanio") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "411" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "412" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "413" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "414" Then

                                dr_CalificacionConstrucciones("TamanioCocina") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "421" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "422" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "423" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "424" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "425" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "426" Then

                                dr_CalificacionConstrucciones("Enchape") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "431" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "432" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "433" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "434" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "435" Then

                                dr_CalificacionConstrucciones("MobiliarioCocina") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "441" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "442" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "443" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "444" Then

                                dr_CalificacionConstrucciones("ConservacionCocina") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "511" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "512" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "513" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "514" Then

                                dr_CalificacionConstrucciones("ComplementoIndustrial") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "515" Then
                                dr_CalificacionConstrucciones("Altura") = "Si"
                            Else
                                dr_CalificacionConstrucciones("Altura") = "No"
                            End If

                        Next

                        dt_CalificacionConstrucciones.Rows.Add(dr_CalificacionConstrucciones)

                    End If

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Calificaciones Construcciones)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_CalificacionConstrucciones

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_ConstruccionesGenerales() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtConstruccionesGenerales = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoIdre, "
            ParametrosConsulta += "FpcoDepa, "
            ParametrosConsulta += "FpcoMuni, "
            ParametrosConsulta += "FpcoClse, "
            ParametrosConsulta += "FpcoNufi, "
            ParametrosConsulta += "FpcoSecu, "
            ParametrosConsulta += "FpcoUnid, "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "FpcoClco, "
            ParametrosConsulta += "FpcoPunt, "
            ParametrosConsulta += "FpcoArco, "
            ParametrosConsulta += "FpcoEdco, "
            ParametrosConsulta += "FpcoPiso, "
            ParametrosConsulta += "FpcoPoco, "
            ParametrosConsulta += "FpcoAcue, "
            ParametrosConsulta += "FpcoAlca, "
            ParametrosConsulta += "FpcoEner, "
            ParametrosConsulta += "FpcoTele, "
            ParametrosConsulta += "FpcoGas,  "
            ParametrosConsulta += "FpcoLey   "

            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') "

            ParametrosConsulta += "order by FpcoNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConstruccionesGenerales)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_ConstruccionesGenerales As DataRow

            ' limpia la tabla
            dt_ConstruccionesGenerales = New DataTable

            ' crea campos dinamicamente
            dt_ConstruccionesGenerales.Columns.Add(New DataColumn("Secuencia", GetType(String)))
            dt_ConstruccionesGenerales.Columns.Add(New DataColumn("Descripcion", GetType(String)))

            ' verifica que existan registros
            If dtConstruccionesGenerales.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtConstruccionesGenerales.Rows.Count - 1

                    ' declara las variables
                    Dim stAcueducto As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoAcue"))
                    Dim stAlcantarillado As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoAlca"))
                    Dim stEnergia As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoEner"))
                    Dim stTelefono As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoTele"))
                    Dim stGas As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoGas"))
                    Dim boLey56 As Boolean = dtConstruccionesGenerales.Rows(i).Item("FpcoLey")

                    ' inserta el registro
                    If stAcueducto = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "001|Acueducto"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If stAlcantarillado = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "002|Alcantarillado"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If stEnergia = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "003|Energia"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If stTelefono = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "004|Telefono"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If stGas = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "005|Gas"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If boLey56 = True Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "007|Ley 56"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Construcciones Generales)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_ConstruccionesGenerales

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_Colindantes() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtColindantes = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpliIdre, "
            ParametrosConsulta += "FpliDepa, "
            ParametrosConsulta += "FpliMuni, "
            ParametrosConsulta += "FpliClse, "
            ParametrosConsulta += "FpliNufi, "
            ParametrosConsulta += "FpliPuca, "
            ParametrosConsulta += "FpliColi  "

            ParametrosConsulta += "From FichPred, FiprLind where "
            ParametrosConsulta += "FiprNufi = FpliNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') "

            ParametrosConsulta += "order by FpliNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtColindantes)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_Colindantes As DataRow

            ' limpia la tabla
            dt_Colindantes = New DataTable

            ' crea campos dinamicamente
            dt_Colindantes.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_Colindantes.Columns.Add(New DataColumn("Orientacion", GetType(String)))
            dt_Colindantes.Columns.Add(New DataColumn("Colindante", GetType(String)))

            ' verifica que existan registros
            If dtColindantes.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtColindantes.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_Colindantes = dt_Colindantes.NewRow()

                    dr_Colindantes("NroFicha") = Trim(dtColindantes.Rows(i).Item("FpliNufi"))

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "N" Then
                        dr_Colindantes("Orientacion") = "NORTE"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "E" Then
                        dr_Colindantes("Orientacion") = "ESTE"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "S" Then
                        dr_Colindantes("Orientacion") = "SUR"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "O" Then
                        dr_Colindantes("Orientacion") = "OESTE"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "ZE" Then
                        dr_Colindantes("Orientacion") = "ZENIT"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "NA" Then
                        dr_Colindantes("Orientacion") = "NADIR"
                    End If

                    dr_Colindantes("Colindante") = Trim(dtColindantes.Rows(i).Item("FpliColi")) & " _"

                    dt_Colindantes.Rows.Add(dr_Colindantes)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Colindantes)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_Colindantes

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_Edificios() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtEdificio = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi, "
            ParametrosConsulta += "FiprDepa, "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprDire, "
            ParametrosConsulta += "FiprCapr, "
            ParametrosConsulta += "FiprAtlo, "
            ParametrosConsulta += "FiprAclo, "
            ParametrosConsulta += "FiprToed, "
            ParametrosConsulta += "FiprUrph, "
            ParametrosConsulta += "FiprApca, "
            ParametrosConsulta += "FiprLoca, "
            ParametrosConsulta += "FiprGacu, "
            ParametrosConsulta += "FiprGade, "
            ParametrosConsulta += "FiprPiso, "
            ParametrosConsulta += "FiprCuut  "

            ParametrosConsulta += "From FichPred where "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') "

            ParametrosConsulta += "order by FiprNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtEdificio)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_Edificio As DataRow

            ' limpia la tabla
            dt_Edificio = New DataTable

            ' crea campos dinamicamente
            dt_Edificio.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("NumeroEdificio", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("PkEdificio", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("Objectld", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("NumeroPisos", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("NumeroUnidadesPrediales", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("AreaOcupadaEdificio", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("AreaConstruidaComun", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("Locales", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("CuartosUtiles", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("GarajesCubiertos", GetType(String)))
            dt_Edificio.Columns.Add(New DataColumn("GarajesDescubiertos", GetType(String)))

            ' verifica que existan registros
            If dtEdificio.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtEdificio.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_Edificio = dt_Edificio.NewRow()

                    dr_Edificio("NroFicha") = Trim(dtEdificio.Rows(i).Item("FiprNufi"))
                    dr_Edificio("NumeroEdificio") = Trim(dtEdificio.Rows(i).Item("FiprToed"))
                    dr_Edificio("PkEdificio") = "0"
                    dr_Edificio("Objectld") = "0"
                    dr_Edificio("NumeroPisos") = Trim(dtEdificio.Rows(i).Item("FiprPiso"))
                    dr_Edificio("NumeroUnidadesPrediales") = Trim(dtEdificio.Rows(i).Item("FiprUrph"))
                    dr_Edificio("AreaOcupadaEdificio") = Trim(dtEdificio.Rows(i).Item("FiprAtlo"))
                    dr_Edificio("AreaConstruidaComun") = "0.0000"
                    dr_Edificio("Locales") = Trim(dtEdificio.Rows(i).Item("FiprLoca"))
                    dr_Edificio("CuartosUtiles") = Trim(dtEdificio.Rows(i).Item("FiprCuut"))
                    dr_Edificio("GarajesCubiertos") = Trim(dtEdificio.Rows(i).Item("FiprGacu"))
                    dr_Edificio("GarajesDescubiertos") = Trim(dtEdificio.Rows(i).Item("FiprGade"))

                    dt_Edificio.Rows.Add(dr_Edificio)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Edificios)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_Edificio

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_FichasPrediales() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtFichasPrediales = New DataTable

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
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprEdif, "
            ParametrosConsulta += "FiprUnpr, "
            ParametrosConsulta += "FiprDire, "
            ParametrosConsulta += "FiprCapr, "
            ParametrosConsulta += "FiprMoad, "
            ParametrosConsulta += "FiprAtlo, "
            ParametrosConsulta += "FiprAclo, "
            ParametrosConsulta += "FiprToed, "
            ParametrosConsulta += "FiprUrph, "
            ParametrosConsulta += "FiprApca, "
            ParametrosConsulta += "FiprLoca, "
            ParametrosConsulta += "FiprGacu, "
            ParametrosConsulta += "FiprGade, "
            ParametrosConsulta += "FiprCoed, "
            ParametrosConsulta += "FiprArte, "
            ParametrosConsulta += "FiprCuut  "

            ParametrosConsulta += "From FichPred where "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('0') "

            ParametrosConsulta += "order by FiprNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtFichasPrediales)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_FichasPrediales As DataRow

            ' limpia la tabla
            dt_FichasPrediales = New DataTable

            ' crea campos dinamicamente
            dt_FichasPrediales.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("ObjectldPredio", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("ObjectIdEdificio", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("NumCedCatastral", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("edificio", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("UnidadPredial", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("ModeloRegistral", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("Libro", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("Tomo", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("Pagina", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("MatriculaInmobiliaria", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("circulo", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("NumeroRadicado", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("Resolucion", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("FechaResolucion", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("TipoMutacion", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("CaracteristicaPredio", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("Servidumbre", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("DireccionReferencia", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("DireccionReal", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("DireccionNombre", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("DestinoEconomico", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("CoeficienteCopropiedad", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("AreaLotePrivada", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("ModoAdquisicion", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("Litigio", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("PorcentajeLitigio", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("NumeroEdificio", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("Piso", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("Lado", GetType(String)))
            dt_FichasPrediales.Columns.Add(New DataColumn("IdModeloPiso", GetType(String)))

            ' verifica que existan registros
            If dtFichasPrediales.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtFichasPrediales.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_FichasPrediales = dt_FichasPrediales.NewRow()

                    dr_FichasPrediales("NroFicha") = Trim(dtFichasPrediales.Rows(i).Item("FiprNufi"))
                    dr_FichasPrediales("ObjectldPredio") = "0"
                    dr_FichasPrediales("ObjectIdEdificio") = "0"
                    dr_FichasPrediales("NumCedCatastral") = "0"
                    dr_FichasPrediales("Edificio") = Trim(dtFichasPrediales.Rows(i).Item("FiprEdif"))
                    dr_FichasPrediales("UnidadPredial") = Trim(dtFichasPrediales.Rows(i).Item("FiprUnpr"))
                    dr_FichasPrediales("ModeloRegistral") = "NUE|Nuevo"
                    dr_FichasPrediales("Libro") = ""
                    dr_FichasPrediales("Tomo") = ""
                    dr_FichasPrediales("Pagina") = ""
                    dr_FichasPrediales("MatriculaInmobiliaria") = fun_ConsultarMatricula(dtFichasPrediales.Rows(i).Item("FiprNufi"))
                    dr_FichasPrediales("circulo") = "001"
                    dr_FichasPrediales("NumeroRadicado") = "0"
                    dr_FichasPrediales("Resolucion") = ""
                    dr_FichasPrediales("FechaResolucion") = ""
                    dr_FichasPrediales("TipoMutacion") = ""
                    dr_FichasPrediales("CaracteristicaPredio") = Trim(dtFichasPrediales.Rows(i).Item("FiprCapr")) & "|" & fun_Buscar_Lista_Valores_CARAPRED(Trim(dtFichasPrediales.Rows(i).Item("FiprCapr")))
                    dr_FichasPrediales("Servidumbre") = "No"
                    dr_FichasPrediales("DireccionReferencia") = stDireccionReferencia
                    dr_FichasPrediales("DireccionReal") = Trim(dtFichasPrediales.Rows(i).Item("FiprDire"))
                    dr_FichasPrediales("DireccionNombre") = stDireccionNombre
                    dr_FichasPrediales("DestinoEconomico") = fun_ConsultarDestino(dtFichasPrediales.Rows(i).Item("FiprNufi")) & "|" & fun_Buscar_Lista_Valores_DESTECON(fun_ConsultarDestino(dtFichasPrediales.Rows(i).Item("FiprNufi")))
                    dr_FichasPrediales("CoeficienteCopropiedad") = Trim(dtFichasPrediales.Rows(i).Item("FiprCoed"))
                    dr_FichasPrediales("AreaLotePrivada") = Trim(dtFichasPrediales.Rows(i).Item("FiprArte"))
                    dr_FichasPrediales("ModoAdquisicion") = Trim(dtFichasPrediales.Rows(i).Item("FiprMoad")) & "|" & fun_Buscar_Lista_Valores_MODOADQU(Trim(dtFichasPrediales.Rows(i).Item("FiprMoad")))
                    dr_FichasPrediales("Litigio") = "No"
                    dr_FichasPrediales("PorcentajeLitigio") = "0"
                    dr_FichasPrediales("NumeroEdificio") = "0"
                    dr_FichasPrediales("Piso") = fun_ConsultarPiso(Trim(dtFichasPrediales.Rows(i).Item("FiprDire")))
                    dr_FichasPrediales("Lado") = "ND"
                    dr_FichasPrediales("IdModeloPiso") = ""

                    dt_FichasPrediales.Rows.Add(dr_FichasPrediales)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Fichas Prediales)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_FichasPrediales

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_ConstruccionesFicha() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtConstrucciones = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoIdre, "
            ParametrosConsulta += "FpcoDepa, "
            ParametrosConsulta += "FpcoMuni, "
            ParametrosConsulta += "FpcoClse, "
            ParametrosConsulta += "FpcoNufi, "
            ParametrosConsulta += "FpcoSecu, "
            ParametrosConsulta += "FpcoUnid, "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "FpcoClco, "
            ParametrosConsulta += "FpcoPunt, "
            ParametrosConsulta += "FpcoArco, "
            ParametrosConsulta += "FpcoEdco, "
            ParametrosConsulta += "FpcoPiso, "
            ParametrosConsulta += "FpcoPoco  "

            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('0') "

            ParametrosConsulta += "order by FpcoNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConstrucciones)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_Construcciones As DataRow

            ' limpia la tabla
            dt_Construcciones = New DataTable

            ' crea campos dinamicamente
            dt_Construcciones.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("Secuencia", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("NumeroConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("ObjectIdConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("ObjectIdModelo", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TipoConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("IdentificadoUso", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("ConvencionalNoConvencional", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("CalificacionNoConvencional", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("Puntos", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("AreaConstruida", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("NumeroPisos", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("EdadConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("PorcentajeConstruccion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("Tipificacion", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TotalCocinas", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TotalHabitaciones", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TotalLocales", GetType(String)))
            dt_Construcciones.Columns.Add(New DataColumn("TotalBaños", GetType(String)))

            ' verifica que existan registros
            If dtConstrucciones.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtConstrucciones.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_Construcciones = dt_Construcciones.NewRow()

                    dr_Construcciones("NroFicha") = Trim(dtConstrucciones.Rows(i).Item("FpcoNufi"))
                    dr_Construcciones("Secuencia") = Trim(dtConstrucciones.Rows(i).Item("FpcoIdre"))
                    dr_Construcciones("NumeroConstruccion") = Trim(dtConstrucciones.Rows(i).Item("FpcoUnid"))
                    dr_Construcciones("ObjectIdConstruccion") = ""
                    dr_Construcciones("ObjectIdModelo") = ""

                    Dim objdatos15 As New cla_TIPOCONS
                    Dim tbl15 As New DataTable

                    tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(dtConstrucciones.Rows(i).Item("FpcoDepa")), Trim(dtConstrucciones.Rows(i).Item("FpcoMuni")), Trim(dtConstrucciones.Rows(i).Item("FpcoClco")), Trim(dtConstrucciones.Rows(i).Item("FpcoClse")), Trim(dtConstrucciones.Rows(i).Item("FpcoTico")))

                    Dim stFPCOTIPO As String = ""

                    If tbl15.Rows.Count > 0 Then
                        stFPCOTIPO = Trim(tbl15.Rows(0).Item(4))
                    End If

                    If Trim(stFPCOTIPO) = "O" Then
                        stFPCOTIPO = ""
                    End If

                    dr_Construcciones("TipoConstruccion") = stFPCOTIPO
                    dr_Construcciones("IdentificadoUso") = Trim(dtConstrucciones.Rows(i).Item("FpcoTico")) & "|" & fun_Buscar_Lista_Valores_TIPOCONS(Trim(dtConstrucciones.Rows(i).Item("FpcoDepa")), Trim(dtConstrucciones.Rows(i).Item("FpcoMuni")), Trim(dtConstrucciones.Rows(i).Item("FpcoClco")), Trim(dtConstrucciones.Rows(i).Item("FpcoClse")), Trim(dtConstrucciones.Rows(i).Item("FpcoTico")))

                    If Trim(dtConstrucciones.Rows(i).Item("FpcoClco")) = 1 Then
                        dr_Construcciones("ConvencionalNoConvencional") = "Convencional"
                    ElseIf Trim(dtConstrucciones.Rows(i).Item("FpcoClco")) = 2 Then
                        dr_Construcciones("ConvencionalNoConvencional") = "No Convencional"
                    End If

                    If Trim(dtConstrucciones.Rows(i).Item("FpcoClco")) = 1 Then
                        dr_Construcciones("CalificacionNoConvencional") = ""
                        dr_Construcciones("Puntos") = Trim(dtConstrucciones.Rows(i).Item("FpcoPunt"))
                    ElseIf Trim(dtConstrucciones.Rows(i).Item("FpcoClco")) = 2 Then
                        dr_Construcciones("CalificacionNoConvencional") = Trim(dtConstrucciones.Rows(i).Item("FpcoPunt"))
                        dr_Construcciones("Puntos") = ""
                    End If

                    dr_Construcciones("AreaConstruida") = Trim(dtConstrucciones.Rows(i).Item("FpcoArco"))
                    dr_Construcciones("NumeroPisos") = Trim(dtConstrucciones.Rows(i).Item("FpcoPiso"))
                    dr_Construcciones("EdadConstruccion") = Trim(dtConstrucciones.Rows(i).Item("FpcoEdco"))
                    dr_Construcciones("PorcentajeConstruccion") = Trim(dtConstrucciones.Rows(i).Item("FpcoPoco"))

                    dr_Construcciones("Tipificacion") = ""

                    If Trim(stFPCOTIPO) = "R" Then
                        dr_Construcciones("TotalCocinas") = "1"
                        dr_Construcciones("TotalHabitaciones") = "1"
                        dr_Construcciones("TotalLocales") = "0"
                        dr_Construcciones("TotalBaños") = "1"

                    ElseIf Trim(stFPCOTIPO) = "C" Then
                        dr_Construcciones("TotalCocinas") = "0"
                        dr_Construcciones("TotalHabitaciones") = "0"
                        dr_Construcciones("TotalLocales") = "1"
                        dr_Construcciones("TotalBaños") = "0"

                    ElseIf Trim(stFPCOTIPO) = "I" Or Trim(stFPCOTIPO) = "O" Then
                        dr_Construcciones("TotalCocinas") = "0"
                        dr_Construcciones("TotalHabitaciones") = "0"
                        dr_Construcciones("TotalLocales") = "0"
                        dr_Construcciones("TotalBaños") = "0"

                    End If

                    dt_Construcciones.Rows.Add(dr_Construcciones)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Construcciones Ficha)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_Construcciones

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_CalificacionesConsFicha() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtCalificacionConstrucciones = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoIdre, "
            ParametrosConsulta += "FpcoDepa, "
            ParametrosConsulta += "FpcoMuni, "
            ParametrosConsulta += "FpcoClse, "
            ParametrosConsulta += "FpcoNufi, "
            ParametrosConsulta += "FpcoSecu, "
            ParametrosConsulta += "FpcoUnid, "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "FpcoClco, "
            ParametrosConsulta += "FpcoPunt, "
            ParametrosConsulta += "FpcoArco, "
            ParametrosConsulta += "FpcoEdco, "
            ParametrosConsulta += "FpcoPiso, "
            ParametrosConsulta += "FpcoPoco  "

            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('0') "

            ParametrosConsulta += "order by FpcoNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtCalificacionConstrucciones)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_CalificacionConstrucciones As DataRow

            ' limpia la tabla
            dt_CalificacionConstrucciones = New DataTable

            ' crea campos dinamicamente
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Secuencia", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Armazon", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Muro", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Cubierta", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Conservacion", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Fachada", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("CubrimientoMuro", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Piso", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("ConservacionPrincipales", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("TamanioBanio", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("EnchapesBanio", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("MobiliarioBanio", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("ConservacionBanio", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("TamanioCocina", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Enchape", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("MobiliarioCocina", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("ConservacionCocina", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("ComplementoIndustrial", GetType(String)))
            dt_CalificacionConstrucciones.Columns.Add(New DataColumn("Altura", GetType(String)))

            ' verifica que existan registros
            If dtCalificacionConstrucciones.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtCalificacionConstrucciones.Rows.Count - 1

                    Dim inIdreCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoIdre")
                    Dim inNufiCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoNufi")
                    Dim inSecuCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoSecu")
                    Dim inUnidCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoUnid")
                    Dim inClcoCons As Integer = dtCalificacionConstrucciones.Rows(i).Item("FpcoClco")

                    ' declaro la instancia
                    Dim obCalificacion As New cla_FIPRCACO
                    Dim dtCalificacion As New DataTable

                    dtCalificacion = obCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL(inNufiCons, inUnidCons)

                    If dtCalificacion.Rows.Count > 0 Then

                        ' inserta un nuevo registro
                        dr_CalificacionConstrucciones = dt_CalificacionConstrucciones.NewRow()

                        dr_CalificacionConstrucciones("Secuencia") = Trim(inIdreCons)

                        ' declara la variable
                        Dim ii As Integer = 0

                        For ii = 0 To dtCalificacion.Rows.Count - 1

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "111" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "112" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "113" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "114" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "115" Then

                                dr_CalificacionConstrucciones("Armazon") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "121" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "122" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "123" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "124" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "125" Then

                                dr_CalificacionConstrucciones("Muro") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "131" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "132" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "133" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "134" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "135" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "136" Then

                                dr_CalificacionConstrucciones("Cubierta") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "141" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "142" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "143" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "144" Then

                                dr_CalificacionConstrucciones("Conservacion") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "211" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "212" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "213" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "214" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "215" Then

                                dr_CalificacionConstrucciones("Fachada") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "221" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "222" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "223" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "224" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "225" Then

                                dr_CalificacionConstrucciones("CubrimientoMuro") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "231" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "232" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "233" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "234" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "235" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "236" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "237" Then

                                dr_CalificacionConstrucciones("Piso") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "241" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "242" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "243" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "244" Then

                                dr_CalificacionConstrucciones("ConservacionPrincipales") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "311" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "312" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "313" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "314" Then

                                dr_CalificacionConstrucciones("TamanioBanio") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "321" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "322" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "323" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "324" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "325" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "326" Then

                                dr_CalificacionConstrucciones("EnchapesBanio") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "331" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "332" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "333" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "334" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "335" Then

                                dr_CalificacionConstrucciones("MobiliarioBanio") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "341" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "342" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "343" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "344" Then

                                dr_CalificacionConstrucciones("ConservacionBanio") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "411" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "412" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "413" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "414" Then

                                dr_CalificacionConstrucciones("TamanioCocina") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "421" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "422" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "423" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "424" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "425" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "426" Then

                                dr_CalificacionConstrucciones("Enchape") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "431" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "432" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "433" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "434" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "435" Then

                                dr_CalificacionConstrucciones("MobiliarioCocina") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "441" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "442" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "443" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "444" Then

                                dr_CalificacionConstrucciones("ConservacionCocina") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "511" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "512" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "513" Or _
                               Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "514" Then

                                dr_CalificacionConstrucciones("ComplementoIndustrial") = Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) & "|" & fun_Buscar_Lista_Valores_CODICALI(Trim(dtCalificacion.Rows(ii).Item("FpccCodi")))
                            End If

                            If Trim(dtCalificacion.Rows(ii).Item("FpccCodi")) = "515" Then
                                dr_CalificacionConstrucciones("Altura") = "Si"
                            Else
                                dr_CalificacionConstrucciones("Altura") = "No"
                            End If

                        Next

                        dt_CalificacionConstrucciones.Rows.Add(dr_CalificacionConstrucciones)

                    End If

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Calificaciones Cons Ficha)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_CalificacionConstrucciones

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_ConstruccionesGeneralFicha() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtConstruccionesGenerales = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoIdre, "
            ParametrosConsulta += "FpcoDepa, "
            ParametrosConsulta += "FpcoMuni, "
            ParametrosConsulta += "FpcoClse, "
            ParametrosConsulta += "FpcoNufi, "
            ParametrosConsulta += "FpcoSecu, "
            ParametrosConsulta += "FpcoUnid, "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "FpcoClco, "
            ParametrosConsulta += "FpcoPunt, "
            ParametrosConsulta += "FpcoArco, "
            ParametrosConsulta += "FpcoEdco, "
            ParametrosConsulta += "FpcoPiso, "
            ParametrosConsulta += "FpcoPoco, "
            ParametrosConsulta += "FpcoAcue, "
            ParametrosConsulta += "FpcoAlca, "
            ParametrosConsulta += "FpcoEner, "
            ParametrosConsulta += "FpcoTele, "
            ParametrosConsulta += "FpcoGas,  "
            ParametrosConsulta += "FpcoLey   "

            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('0') "

            ParametrosConsulta += "order by FpcoNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtConstruccionesGenerales)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_ConstruccionesGenerales As DataRow

            ' limpia la tabla
            dt_ConstruccionesGenerales = New DataTable

            ' crea campos dinamicamente
            dt_ConstruccionesGenerales.Columns.Add(New DataColumn("Secuencia", GetType(String)))
            dt_ConstruccionesGenerales.Columns.Add(New DataColumn("Descripcion", GetType(String)))

            ' verifica que existan registros
            If dtConstruccionesGenerales.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtConstruccionesGenerales.Rows.Count - 1

                    ' declara las variables
                    Dim stAcueducto As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoAcue"))
                    Dim stAlcantarillado As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoAlca"))
                    Dim stEnergia As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoEner"))
                    Dim stTelefono As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoTele"))
                    Dim stGas As String = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoGas"))
                    Dim boLey56 As Boolean = dtConstruccionesGenerales.Rows(i).Item("FpcoLey")

                    ' inserta el registro
                    If stAcueducto = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "001|Acueducto"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If stAlcantarillado = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "002|Alcantarillado"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If stEnergia = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "003|Energia"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If stTelefono = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "004|Telefono"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If stGas = "1" Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "005|Gas"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                    If boLey56 = True Then

                        dr_ConstruccionesGenerales = dt_ConstruccionesGenerales.NewRow()

                        dr_ConstruccionesGenerales("Secuencia") = Trim(dtConstruccionesGenerales.Rows(i).Item("FpcoIdre"))
                        dr_ConstruccionesGenerales("Descripcion") = "007|Ley 56"

                        dt_ConstruccionesGenerales.Rows.Add(dr_ConstruccionesGenerales)

                    End If

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Construccion General Ficha)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_ConstruccionesGenerales

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_ColindantesFicha() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtColindantes = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpliIdre, "
            ParametrosConsulta += "FpliDepa, "
            ParametrosConsulta += "FpliMuni, "
            ParametrosConsulta += "FpliClse, "
            ParametrosConsulta += "FpliNufi, "
            ParametrosConsulta += "FpliPuca, "
            ParametrosConsulta += "FpliColi  "

            ParametrosConsulta += "From FichPred, FiprLind where "
            ParametrosConsulta += "FiprNufi = FpliNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('0') "

            ParametrosConsulta += "order by FpliNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtColindantes)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_Colindantes As DataRow

            ' limpia la tabla
            dt_Colindantes = New DataTable

            ' crea campos dinamicamente
            dt_Colindantes.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_Colindantes.Columns.Add(New DataColumn("Orientacion", GetType(String)))
            dt_Colindantes.Columns.Add(New DataColumn("Colindante", GetType(String)))

            ' verifica que existan registros
            If dtColindantes.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtColindantes.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_Colindantes = dt_Colindantes.NewRow()

                    dr_Colindantes("NroFicha") = Trim(dtColindantes.Rows(i).Item("FpliNufi"))

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "N" Then
                        dr_Colindantes("Orientacion") = "NORTE"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "E" Then
                        dr_Colindantes("Orientacion") = "ESTE"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "S" Then
                        dr_Colindantes("Orientacion") = "SUR"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "O" Then
                        dr_Colindantes("Orientacion") = "OESTE"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "ZE" Then
                        dr_Colindantes("Orientacion") = "ZENIT"
                    End If

                    If Trim(dtColindantes.Rows(i).Item("FpliPuca")) = "NA" Then
                        dr_Colindantes("Orientacion") = "NADIR"
                    End If

                    dr_Colindantes("Colindante") = Trim(dtColindantes.Rows(i).Item("FpliColi")) & " _"

                    dt_Colindantes.Rows.Add(dr_Colindantes)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Colindantes Ficha)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_Colindantes

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Function fun_Propietarios() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtPropietarios = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpprIdre, "
            ParametrosConsulta += "FpprDepa, "
            ParametrosConsulta += "FpprMuni, "
            ParametrosConsulta += "FpprDeno, "
            ParametrosConsulta += "FpprMuno, "
            ParametrosConsulta += "FpprClse, "
            ParametrosConsulta += "FpprNufi, "
            ParametrosConsulta += "FpprTido, "
            ParametrosConsulta += "FpprNudo, "
            ParametrosConsulta += "FpprCapr, "
            ParametrosConsulta += "FpprDere, "
            ParametrosConsulta += "FpprGrav, "
            ParametrosConsulta += "FpprCapr, "
            ParametrosConsulta += "FpprFere, "
            ParametrosConsulta += "FpprEscr, "
            ParametrosConsulta += "FpprFees, "
            ParametrosConsulta += "FpprNota, "
            ParametrosConsulta += "FpprSico, "
            ParametrosConsulta += "FpprNomb, "
            ParametrosConsulta += "FpprPrap, "
            ParametrosConsulta += "FpprSeap  "

            ParametrosConsulta += "From FichPred, FiprProp where "
            ParametrosConsulta += "FiprNufi = FpprNufi and "

            ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi in ('0') "

            ParametrosConsulta += "order by FpprNufi "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtPropietarios)

            ' cierra la conexion
            oConexion.Close()

            ' crea registro dinamicamente
            Dim dr_Propietarios As DataRow

            ' limpia la tabla
            dt_Propietarios = New DataTable

            ' crea campos dinamicamente
            dt_Propietarios.Columns.Add(New DataColumn("NroFicha", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("TipoDocumento", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("Documento", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("CalidadPropietario", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("Derecho", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("Gravable", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("CalidadPropietarioOficial", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("Fecha", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("CodigoFideicomiso", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("Escritura", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("FechaEscritura", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("ValorCompra", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("Entidad", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("EntidadDepartamento", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("EntidadMunicipio", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("NumeroFallo", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("SiglaComercial", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("RazonSocial", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("PrimerNombre", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("SegundoNombre", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("PrimerApellido", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("SegundoApellido", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("DepartamentoPersona", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("MunicipioPersona", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("Telefono", GetType(String)))
            dt_Propietarios.Columns.Add(New DataColumn("Direccion", GetType(String)))

            ' verifica que existan registros
            If dtPropietarios.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dtPropietarios.Rows.Count - 1

                    ' inserta un nuevo registro
                    dr_Propietarios = dt_Propietarios.NewRow()

                    dr_Propietarios("NroFicha") = Trim(dtPropietarios.Rows(i).Item("FpprNufi"))
                    dr_Propietarios("TipoDocumento") = Trim(dtPropietarios.Rows(i).Item("FpprTido")) & "|" & fun_Buscar_Lista_Valores_TIPODOCU(Trim(dtPropietarios.Rows(i).Item("FpprTido")))
                    dr_Propietarios("Documento") = Trim(dtPropietarios.Rows(i).Item("FpprNudo")) & " _"
                    dr_Propietarios("CalidadPropietario") = Trim(dtPropietarios.Rows(i).Item("FpprCapr")) & "|" & fun_Buscar_Lista_Valores_CALIPROP(Trim(dtPropietarios.Rows(i).Item("FpprCapr")))
                    dr_Propietarios("Derecho") = Trim(dtPropietarios.Rows(i).Item("FpprDere"))

                    If CBool(dtPropietarios.Rows(i).Item("FpprGrav")) = True Then
                        dr_Propietarios("Gravable") = "Si"
                    Else
                        dr_Propietarios("Gravable") = "No"
                    End If

                    dr_Propietarios("CalidadPropietarioOficial") = Trim(dtPropietarios.Rows(i).Item("FpprCapr")) & "|" & fun_Buscar_Lista_Valores_CALIPROP(Trim(dtPropietarios.Rows(i).Item("FpprCapr")))

                    If chkConcatenarGuionPropietarios.Checked = True Then
                        dr_Propietarios("Fecha") = Trim(dtPropietarios.Rows(i).Item("FpprFere").ToString.Replace("-", "/")) & " _"
                    Else
                        dr_Propietarios("Fecha") = Trim(dtPropietarios.Rows(i).Item("FpprFere").ToString.Replace("-", "/"))
                    End If

                    dr_Propietarios("CodigoFideicomiso") = Trim(stCodigoFideicomiso)
                    dr_Propietarios("Escritura") = Trim(dtPropietarios.Rows(i).Item("FpprEscr"))

                    If Me.chkConcatenarGuionPropietarios.Checked = True Then
                        dr_Propietarios("FechaEscritura") = Trim(dtPropietarios.Rows(i).Item("FpprFees").ToString.Replace("-", "/")) & " _"
                    Else
                        dr_Propietarios("FechaEscritura") = Trim(dtPropietarios.Rows(i).Item("FpprFees").ToString.Replace("-", "/"))
                    End If

                    dr_Propietarios("ValorCompra") = Trim(stValorCompra)
                    dr_Propietarios("Entidad") = "1|Notaria"

                    If Trim(dtPropietarios.Rows(i).Item("FpprDeno")) <> "" Then
                        dr_Propietarios("EntidadDepartamento") = CInt(dtPropietarios.Rows(i).Item("FpprDeno")) & "|" & fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(dtPropietarios.Rows(i).Item("FpprDeno")))
                    Else
                        dr_Propietarios("EntidadDepartamento") = ""
                    End If

                    If Trim(dtPropietarios.Rows(i).Item("FpprMuno")) <> "" Then
                        dr_Propietarios("EntidadMunicipio") = CInt(dtPropietarios.Rows(i).Item("FpprMuno"))
                    Else
                        dr_Propietarios("EntidadMunicipio") = ""
                    End If

                    dr_Propietarios("NumeroFallo") = Trim(dtPropietarios.Rows(i).Item("FpprNota"))
                    dr_Propietarios("SiglaComercial") = Trim(dtPropietarios.Rows(i).Item("FpprSico"))
                    dr_Propietarios("RazonSocial") = ""
                    dr_Propietarios("PrimerNombre") = Trim(dtPropietarios.Rows(i).Item("FpprNomb"))
                    dr_Propietarios("SegundoNombre") = ""
                    dr_Propietarios("PrimerApellido") = Trim(dtPropietarios.Rows(i).Item("FpprPrap"))
                    dr_Propietarios("SegundoApellido") = Trim(dtPropietarios.Rows(i).Item("FpprSeap"))
                    dr_Propietarios("DepartamentoPersona") = ""
                    dr_Propietarios("MunicipioPersona") = ""
                    dr_Propietarios("Telefono") = ""
                    dr_Propietarios("Direccion") = ""

                    dt_Propietarios.Rows.Add(dr_Propietarios)

                Next

            Else
                MessageBox.Show("Consulta no encontro registros pestaña (Propietarios)", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Return dt_Propietarios

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            Me.cmdCONSULTAR.Enabled = False

            Me.dgvFicha.DataSource = fun_Ficha()
            Me.dgvZonasHomogeneas.DataSource = fun_ZonasHomogeneas()
            Me.dgvCartografiaInformacionGrafica.DataSource = fun_CartografiaInformacionGrafica()
            Me.dgvConstrucciones.DataSource = fun_Construcciones()
            Me.dgvCalificacionConstrucciones.DataSource = fun_CalificacionesConstrucciones()
            Me.dgvConstruccionesGenerales.DataSource = fun_ConstruccionesGenerales()
            Me.dgvColindantes.DataSource = fun_Colindantes()
            Me.dgvEdificio.DataSource = fun_Edificios()
            Me.dgvFichasPrediales.DataSource = fun_FichasPrediales()
            Me.dgvConstruccionesFicha.DataSource = fun_ConstruccionesFicha()
            Me.dgvCalificacionesConsFicha.DataSource = fun_CalificacionesConsFicha()
            Me.dgvConstruccionGeneralFicha.DataSource = fun_ConstruccionesGeneralFicha()
            Me.dgvColindantesFicha.DataSource = fun_ColindantesFicha()
            Me.dgvPropietarios.DataSource = fun_Propietarios()

            Me.cmdCONSULTAR.Enabled = True

            MessageBox.Show("Proceso terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdULTIMACONSULTA.Click
        pro_LimpiarCampos()
        pro_ObtenerConsulta()
        cmdCONSULTAR.Focus()
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub

    Private Sub cmdfichaExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelFicha.Click
        Try
            If Me.dgvFicha.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvFicha.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelZonasHomogeneas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelZonasHomogeneas.Click
        Try
            If Me.dgvZonasHomogeneas.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvZonasHomogeneas.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelCartografiaInformacionGrafica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelCartografiaInformacionGrafica.Click
        Try
            If Me.dgvCartografiaInformacionGrafica.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCartografiaInformacionGrafica.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelConstrucciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelConstrucciones.Click
        Try
            If Me.dgvConstrucciones.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvConstrucciones.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelCalificacionConstrucciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelCalificacionConstrucciones.Click
        Try
            If Me.dgvCalificacionConstrucciones.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCalificacionConstrucciones.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelConstruccionesGenerales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelConstruccionesGenerales.Click
        Try
            If Me.dgvConstruccionesGenerales.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvConstruccionesGenerales.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelColindantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelColindantes.Click
        Try
            If Me.dgvColindantes.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvColindantes.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelEdificio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelEdificio.Click
        Try
            If Me.dgvEdificio.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvEdificio.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelFichasPrediales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelFichasPrediales.Click
        Try
            If Me.dgvFichasPrediales.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvFichasPrediales.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelConstruccionesFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelConstruccionesFicha.Click
        Try
            If Me.dgvConstruccionesFicha.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvConstruccionesFicha.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelCalificacionConsFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelCalificacionConsFicha.Click
        Try
            If Me.dgvCalificacionesConsFicha.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCalificacionesConsFicha.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelConstruccionGeneralFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelConstruccionGeneralFicha.Click
        Try
            If Me.dgvConstruccionGeneralFicha.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvConstruccionGeneralFicha.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelColindantesFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelColindantesFicha.Click
        Try
            If Me.dgvColindantesFicha.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvColindantesFicha.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelPropietarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelPropietarios.Click
        Try
            If Me.dgvPropietarios.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvPropietarios.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFIPRFIIN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_LimpiarCampos()
        Me.txtFIPRFIIN.Focus()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRFIIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.GotFocus
        txtFIPRFIIN.SelectionStart = 0
        txtFIPRFIIN.SelectionLength = Len(txtFIPRFIIN.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIIN.AccessibleDescription
    End Sub
    Private Sub txtFIPRfifi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.GotFocus
        txtFIPRfifi.SelectionStart = 0
        txtFIPRFIFI.SelectionLength = Len(txtFIPRFIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIFI.AccessibleDescription
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
    Private Sub txtFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRESTA.GotFocus
        txtFIPRESTA.SelectionStart = 0
        txtFIPRESTA.SelectionLength = Len(txtFIPRESTA.Text)
        strBARRESTA.Items(0).Text = txtFIPRESTA.AccessibleDescription
    End Sub
    Private Sub cboFPPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCASU.GotFocus
        txtFIPRCASU.SelectionStart = 0
        txtFIPRCASU.SelectionLength = Len(txtFIPRCASU.Text)
        strBARRESTA.Items(0).Text = txtFIPRCASU.AccessibleDescription
    End Sub
    Private Sub cboFPPRSEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.GotFocus
        txtFIPRCAPR.SelectionStart = 0
        txtFIPRCAPR.SelectionLength = Len(txtFIPRCAPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub cboFPPRTIDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.GotFocus
        txtFIPRMOAD.SelectionStart = 0
        txtFIPRMOAD.SelectionLength = Len(txtFIPRMOAD.Text)
        strBARRESTA.Items(0).Text = txtFIPRMOAD.AccessibleDescription
    End Sub

    Private Sub txtGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus, txtFIPRCASU.GotFocus, txtFIPRCAPR.GotFocus, txtFIPRMOAD.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRFIFI.Focus()
        End If

    End Sub
    Private Sub txtFIPRfifi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDIRE.Focus()
        End If

    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
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
            txtFIPRUNPR.Focus()
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRESTA.Focus()
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCASU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMOAD.Focus()
        End If
    End Sub
    Private Sub txtFIPRMOAD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMOAD.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress, txtFIPRCASU.KeyPress, txtFIPRCAPR.KeyPress, txtFIPRMOAD.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If

    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRFIIN.KeyDown, txtFIPRFIFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRESTA.KeyDown, txtFIPRCASU.KeyDown, txtFIPRCAPR.KeyDown, txtFIPRMOAD.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            cmdULTIMACONSULTA.PerformClick()
        End If

    End Sub

#End Region

#Region "Validated"

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
            lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Trim(txtFIPRCAPR.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRMOAD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.Validated
        If Trim(txtFIPRMOAD.Text) = "" Then
            lblFIPRMOAD.Text = ""
        Else
            lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(txtFIPRMOAD.Text)), String)
        End If
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkConcatenarGuion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConcatenarGuion.CheckedChanged

        If Me.chkConcatenarGuion.Checked = True Then
            Me.chkConcatenarGuionPropietarios.Checked = True
        Else
            Me.chkConcatenarGuionPropietarios.Checked = False
        End If

    End Sub

#End Region

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        If tstBAESDESC.Text <> "" Then
            MessageBox.Show(Trim(tstBAESDESC.Text), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#End Region

End Class