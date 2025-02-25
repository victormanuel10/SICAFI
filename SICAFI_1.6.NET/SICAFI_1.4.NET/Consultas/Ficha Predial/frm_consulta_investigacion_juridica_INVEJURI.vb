Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_investigacion_juridica_INVEJURI

    '=======================================
    '*** CONSULTA INVESTIGACIÓN JURIDICA ***
    '=======================================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    Dim tblCONSULTA As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_investigacion_juridica_INVEJURI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_investigacion_juridica_INVEJURI
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

    ' variables verificar datos
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
    Dim stFIPRESTA As String
    Dim stFIPRCASU As String
    Dim stFIPRCAPR As String
    Dim stFIPRMOAD As String
    Dim Separador As String

    ' variables guardar consulta
    Dim Guardar_stFIPRNUFI As String
    Dim Guardar_stFIPRDIRE As String
    Dim Guardar_stFIPRMUNI As String
    Dim Guardar_stFIPRCORR As String
    Dim Guardar_stFIPRBARR As String
    Dim Guardar_stFIPRMANZ As String
    Dim Guardar_stFIPRPRED As String
    Dim Guardar_stFIPREDIF As String
    Dim Guardar_stFIPRUNPR As String
    Dim Guardar_stFIPRCLSE As String
    Dim Guardar_stFIPRESTA As String
    Dim Guardar_stFIPRCASU As String
    Dim Guardar_stFIPRCAPR As String
    Dim Guardar_stFIPRMOAD As String

    Dim dt_CONSULTA As New DataTable

    Dim inProceso As Integer = 0

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRCLSE.Text = ""
        Me.txtFIPRESTA.Text = ""
        Me.txtFIPRCASU.Text = ""
        Me.txtFIPRCAPR.Text = ""
        Me.txtFIPRMOAD.Text = ""

        Me.cmdCONSULTAR.Enabled = True

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(txtFIPRNUFI.Text)
        End If

        If Trim(txtFIPRDIRE.Text) = "" Then
            stFIPRDIRE = "%"
        Else
            stFIPRDIRE = Trim(txtFIPRDIRE.Text)
        End If

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

        If Trim(txtFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(txtFIPRESTA.Text)
        End If

        If Trim(txtFIPRCASU.Text) = "" Then
            stFIPRCASU = "%"
        Else
            stFIPRCASU = Trim(txtFIPRCASU.Text)
        End If

        If Trim(txtFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(txtFIPRCAPR.Text)
        End If

        If Trim(txtFIPRMOAD.Text) = "" Then
            stFIPRMOAD = "%"
        Else
            stFIPRMOAD = Trim(txtFIPRMOAD.Text)
        End If


    End Sub
    Private Sub pro_GuardarConsulta()

        Guardar_stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        Guardar_stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        Guardar_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        Guardar_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        Guardar_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        Guardar_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        Guardar_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        Guardar_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        Guardar_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        Guardar_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        Guardar_stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
        Guardar_stFIPRCASU = Trim(Me.txtFIPRCASU.Text)
        Guardar_stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)
        Guardar_stFIPRMOAD = Trim(Me.txtFIPRMOAD.Text)

    End Sub
    Private Sub pro_ObtenerConsulta()

        Me.txtFIPRNUFI.Text = Guardar_stFIPRNUFI
        Me.txtFIPRDIRE.Text = Guardar_stFIPRDIRE
        Me.txtFIPRMUNI.Text = Guardar_stFIPRMUNI
        Me.txtFIPRCORR.Text = Guardar_stFIPRCORR
        Me.txtFIPRBARR.Text = Guardar_stFIPRBARR
        Me.txtFIPRMANZ.Text = Guardar_stFIPRMANZ
        Me.txtFIPRPRED.Text = Guardar_stFIPRPRED
        Me.txtFIPREDIF.Text = Guardar_stFIPREDIF
        Me.txtFIPRUNPR.Text = Guardar_stFIPRUNPR
        Me.txtFIPRCLSE.Text = Guardar_stFIPRCLSE
        Me.txtFIPRESTA.Text = Guardar_stFIPRESTA
        Me.txtFIPRCASU.Text = Guardar_stFIPRCASU
        Me.txtFIPRCAPR.Text = Guardar_stFIPRCAPR
        Me.txtFIPRMOAD.Text = Guardar_stFIPRMOAD

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.cmdExportarExcel.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarExcel.Name)
            Me.cmdExportarPlano.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarPlano.Name)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Function fun_PredioMejora(ByVal stNroFicha) As Boolean

        Try
            Dim oMejora As New cla_FIPRCONS
            Dim dtMejora As New DataTable

            dtMejora = oMejora.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(stNroFicha)

            Dim boMejora As Boolean = False

            If dtMejora.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtMejora.Rows.Count - 1

                    If CBool(dtMejora.Rows(i).Item("FPCOMEJO")) = True And Trim(dtMejora.Rows(i).Item("FPCOESTA").ToString) = "ac" Then
                        boMejora = True
                    End If

                Next

            End If

            Return boMejora

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_PredioBienDeDominio(ByVal stNroFicha) As Boolean

        Try

            Dim oDestino As New cla_FIPRDEEC
            Dim dtDestino As New DataTable

            dtDestino = oDestino.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(stNroFicha)

            Dim boDominio As Boolean = False

            If dtDestino.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtDestino.Rows.Count - 1

                    If CInt(dtDestino.Rows(i).Item("FPDEDEEC")) = 19 And Trim(dtDestino.Rows(i).Item("FPDEESTA").ToString) = "ac" Then
                        boDominio = True
                    End If

                Next

            End If

            Return boDominio

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Function fun_PredioDestinoEconomico(ByVal stNroFicha) As String

        Try
            Dim oDestino As New cla_FIPRDEEC
            Dim dtDestino As New DataTable

            dtDestino = oDestino.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(stNroFicha)

            Dim stDestino As String = ""

            If dtDestino.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtDestino.Rows.Count - 1

                    stDestino = dtDestino.Rows(i).Item("FPDEDEEC").ToString

                Next

            End If

            Return stDestino

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            Me.cmdCONSULTAR.Enabled = False

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi as Nro_Ficha, "
            ParametrosConsulta += "FiprDire as Direccion, "
            ParametrosConsulta += "FiprMuni as Municipio, "
            ParametrosConsulta += "FiprCorr as Corregi, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as Unidad, "
            ParametrosConsulta += "FiprClse as Sector, "
            ParametrosConsulta += "FiprCasu as Categoria, "
            ParametrosConsulta += "FiprCapr as Caracteris_Predio, "
            ParametrosConsulta += "FiprMoad as Adquisicion, "
            ParametrosConsulta += "FiprCopr as Coeficiente_Predio, "
            ParametrosConsulta += "FiprCoed as Coeficiente_Edificio, "
            ParametrosConsulta += "FiprArte as Area_Terreno, "
            ParametrosConsulta += "FiprObse as Observacion_Ficha, "
            ParametrosConsulta += "FiprEsta as Estado, "
            ParametrosConsulta += "FpprCapr as Cali_Prop, "
            ParametrosConsulta += "FpprSexo as Sexo, "
            ParametrosConsulta += "FpprTido as Tipo_Docu, "
            ParametrosConsulta += "FpprNudo as Nro_Documento, "
            ParametrosConsulta += "FpprPrap as Pri_Apellido_Actual, "
            ParametrosConsulta += "FpprSeap as Seg_Apellido_Actual, "
            ParametrosConsulta += "FpprNomb as Nombre_Actual, "
            ParametrosConsulta += "FpprDere as Derecho, "
            ParametrosConsulta += "FpprSico as Sigla_Comercial, "
            ParametrosConsulta += "FpprEscr as Nro_Escritura, "
            ParametrosConsulta += "fpprDeno +'-'+ fpprmuno +'-'+ fpprnota as Notaria, "
            ParametrosConsulta += "FpprFees +'.' as Fecha_Escritura , "
            ParametrosConsulta += "FpprFere +'.' as Fecha_Registro , "
            ParametrosConsulta += "FpprTomo as Tomo, "
            ParametrosConsulta += "FpprMain as Matricula "
            ParametrosConsulta += "From FichPred, FiprProp  where "
            ParametrosConsulta += "FiprNufi = FpprNufi and "
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
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' "
            ParametrosConsulta += "order by FiprNufi,FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

                If MessageBox.Show("¿ Desea continuar ? " & "Nro de registros: " & dt.Rows.Count, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim dr_CONSULTA As DataRow

                    dt_CONSULTA = New DataTable

                    ' crea las columnas
                    dt_CONSULTA.Columns.Add(New DataColumn("Circulo_Registral", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Matricula", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Tomo", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Folio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Estado", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Fecha_Registro", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Matricula_Segregada", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Matricula_Abierta_Basada_En", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Tomo_Abierto", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Folio_Abierto", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Area_Escritura", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Falsa_Tradicion", GetType(Boolean)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Cali_Prop", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Bien_De_Dominio_Publico", GetType(Boolean)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Coeficiente_Edificio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Coeficiente_Predio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Adju_Entidad_Oficial", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Area_Terreno", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Corregi", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Manzana", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Unidad", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Direccion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Destino_Economico", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Caracteris_Predio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Adquisicion", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Pri_Apellido_Actual", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Seg_Apellido_Actual", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nombre_Actual", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Sigla_Comercial", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Tipo_Docu", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Derecho", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Pri_Apellido_Anterior", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Seg_Apellido_Anterior", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nombre_Anterior", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Causa_Del_Acto", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Observacion_Propietario_Anterior", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Escritura", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Notaria", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Fecha_Escritura", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Plano_Protocolizado", GetType(Boolean)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Observacion_Ficha", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Mejora", GetType(Boolean)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Observacion_Juridica", GetType(String)))

                    ' declara la variable
                    Dim stCirculo_Registral As String = ""
                    Dim stMatricula As String = ""
                    Dim stTomo As String = ""
                    Dim stFolio As String = ""
                    Dim stEstado As String = ""
                    Dim stFecha_Registro As String = ""
                    Dim stMatricula_Segregada As String = ""
                    Dim stMatricula_Abierta_Basada_En As String = ""
                    Dim stFolio_Abierto As String = ""
                    Dim stTomo_Abierto As String = ""
                    Dim stArea_Escritura As String = ""
                    Dim boFalsa_Tradicion As Boolean = False
                    Dim stCali_Prop As String = ""
                    Dim boBien_De_Dominio_Publico As Boolean = False
                    Dim stCoeficiente_Edificio As String = ""
                    Dim stCoeficiente_Predio As String = ""
                    Dim stAdju_Entidad_Oficial As String = ""
                    Dim stArea_Terreno As String = ""
                    Dim stMunicipio As String = ""
                    Dim stCorregi As String = ""
                    Dim stBarrio As String = ""
                    Dim stManzana As String = ""
                    Dim stPredio As String = ""
                    Dim stEdificio As String = ""
                    Dim stUnidad As String = ""
                    Dim stSector As String = ""
                    Dim stDireccion As String = ""
                    Dim stDestino_Economico As String = ""
                    Dim stCaracteris_Predio As String = ""
                    Dim stAdquisicion As String = ""
                    Dim stPri_Apellido_Actual As String = ""
                    Dim stSeg_Apellido_Actual As String = ""
                    Dim stNombre_Actual As String = ""
                    Dim stSigla_Comercial As String = ""
                    Dim stTipo_Docu As String = ""
                    Dim stNro_Documento As String = ""
                    Dim stDerecho As String = ""
                    Dim stPri_Apellido_Anterior As String = ""
                    Dim stSeg_Apellido_Anterior As String = ""
                    Dim stNombre_Anterior As String = ""
                    Dim stCausa_Del_Acto As String = ""
                    Dim stObservacion_Propietario_Anterior As String = ""
                    Dim stNro_Escritura As String = ""
                    Dim stNotaria As String = ""
                    Dim stFecha_Escritura As String = ""
                    Dim boPlano_Protocolizado As Boolean = False
                    Dim stObservacion_Ficha As String = ""
                    Dim stNro_Ficha As String = ""
                    Dim boMejora As Boolean = False
                    Dim stObservacion_Juridica As String = ""

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        ' llena las variables de la ficha predial
                        stEstado = Trim(dt.Rows(i).Item("Estado"))
                        stCoeficiente_Edificio = Trim(dt.Rows(i).Item("Coeficiente_Edificio"))
                        stCoeficiente_Predio = Trim(dt.Rows(i).Item("Coeficiente_Predio"))
                        stArea_Terreno = Trim(dt.Rows(i).Item("Area_Terreno"))
                        stMunicipio = Trim(dt.Rows(i).Item("Municipio"))
                        stCorregi = Trim(dt.Rows(i).Item("Corregi"))
                        stBarrio = Trim(dt.Rows(i).Item("Barrio"))
                        stManzana = Trim(dt.Rows(i).Item("Manzana"))
                        stPredio = Trim(dt.Rows(i).Item("Predio"))
                        stEdificio = Trim(dt.Rows(i).Item("Edificio"))
                        stUnidad = Trim(dt.Rows(i).Item("Unidad"))
                        stDireccion = Trim(dt.Rows(i).Item("Direccion"))
                        stCaracteris_Predio = Trim(dt.Rows(i).Item("Caracteris_Predio"))
                        stAdquisicion = Trim(dt.Rows(i).Item("Adquisicion"))
                        stObservacion_Ficha = Trim(dt.Rows(i).Item("Observacion_Ficha"))
                        stNro_Ficha = Trim(dt.Rows(i).Item("Nro_Ficha"))
                        stSector = Trim(dt.Rows(i).Item("Sector"))

                        ' llena las variable boleanas
                        boBien_De_Dominio_Publico = fun_PredioBienDeDominio(stNro_Ficha)
                        boMejora = fun_PredioMejora(stNro_Ficha)
                        stDestino_Economico = fun_PredioDestinoEconomico(stNro_Ficha)

                        ' llena las variables del propietario actual
                        'stCirculo_Registral = Trim(dt.Rows(i).Item("Circulo_Registral"))
                        stMatricula = Trim(dt.Rows(i).Item("Matricula"))
                        stTomo = Trim(dt.Rows(i).Item("Tomo"))
                        stFecha_Registro = Trim(dt.Rows(i).Item("Fecha_Registro"))
                        stPri_Apellido_Actual = Trim(dt.Rows(i).Item("Pri_Apellido_Actual"))
                        stSeg_Apellido_Actual = Trim(dt.Rows(i).Item("Seg_Apellido_Actual"))
                        stNombre_Actual = Trim(dt.Rows(i).Item("Nombre_Actual"))
                        stSigla_Comercial = Trim(dt.Rows(i).Item("Sigla_Comercial"))
                        stTipo_Docu = Trim(dt.Rows(i).Item("Tipo_Docu"))
                        stNro_Documento = Trim(dt.Rows(i).Item("Nro_Documento"))
                        stDerecho = Trim(dt.Rows(i).Item("Derecho"))
                        stNro_Escritura = Trim(dt.Rows(i).Item("Nro_Escritura"))
                        stNotaria = Trim(dt.Rows(i).Item("Notaria"))
                        stFecha_Escritura = Trim(dt.Rows(i).Item("Fecha_Escritura"))
                        stCali_Prop = Trim(dt.Rows(i).Item("Cali_Prop"))

                        Dim oJurica As New cla_juridica_PREDIO
                        Dim dtJuridica As New DataTable

                        dtJuridica = oJurica.fun_Buscar_NRO_FICHA_JURIDICA(Trim(dt.Rows(i).Item("Nro_Ficha")))

                        If dtJuridica.Rows.Count > 0 Then

                            ' llena las variables de la investigacion juridica
                            stFolio = Trim(dtJuridica.Rows(0).Item("JURIFOLI"))
                            stMatricula_Segregada = Trim(dtJuridica.Rows(0).Item("JURIMASE"))
                            stMatricula_Abierta_Basada_En = Trim(dtJuridica.Rows(0).Item("JURIMAAB"))
                            stFolio_Abierto = Trim(dtJuridica.Rows(0).Item("JURIFOAB"))
                            stTomo_Abierto = Trim(dtJuridica.Rows(0).Item("JURITOAB"))
                            stArea_Escritura = Trim(dtJuridica.Rows(0).Item("JURIARTE"))
                            boFalsa_Tradicion = dtJuridica.Rows(0).Item("JURIFATR")
                            stAdju_Entidad_Oficial = Trim(dtJuridica.Rows(0).Item("JURIADEO"))
                            boPlano_Protocolizado = dtJuridica.Rows(0).Item("JURIPLPR")
                            stObservacion_Juridica = Trim(dtJuridica.Rows(0).Item("JURIOBSE"))
                        Else
                            ' llena las variables de la investigacion juridica
                            stFolio = ""
                            stMatricula_Segregada = ""
                            stMatricula_Abierta_Basada_En = ""
                            stFolio_Abierto = ""
                            stTomo_Abierto = ""
                            stArea_Escritura = ""
                            boFalsa_Tradicion = False
                            stAdju_Entidad_Oficial = ""
                            boPlano_Protocolizado = False
                            stObservacion_Juridica = ""
                        End If




                        ' llena las variables del propietario anterior
                        stNro_Documento = ""
                        stPri_Apellido_Anterior = ""
                        stSeg_Apellido_Anterior = ""
                        stNombre_Anterior = ""
                        stCausa_Del_Acto = ""
                        stObservacion_Propietario_Anterior = ""

                        stNro_Ficha = Trim(dt.Rows(i).Item("Nro_Ficha"))
                        stNro_Documento = Trim(dt.Rows(i).Item("Nro_Documento"))

                        ' instancia la clase
                        Dim objdatos As New cla_PROPANTE
                        Dim tbl As New DataTable

                        tbl = objdatos.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(stNro_Ficha, stNro_Documento)

                        If tbl.Rows.Count > 0 Then

                            stNro_Ficha = Trim(tbl.Rows(0).Item("PRANNUFI"))
                            stNro_Documento = Trim(tbl.Rows(0).Item("PRANNUDO"))
                            stPri_Apellido_Anterior = Trim(tbl.Rows(0).Item("PRANPRAP"))
                            stSeg_Apellido_Anterior = Trim(tbl.Rows(0).Item("PRANSEAP"))
                            stNombre_Anterior = Trim(tbl.Rows(0).Item("PRANNOMB"))
                            stCausa_Del_Acto = Trim(tbl.Rows(0).Item("PRANCAAC"))
                            stObservacion_Propietario_Anterior = Trim(tbl.Rows(0).Item("PRANOBSE"))

                        End If

                        ' inserta un nuevo registro
                        dr_CONSULTA = dt_CONSULTA.NewRow()

                        dr_CONSULTA("Matricula") = Trim(stMatricula)

                        If Trim(stMatricula).ToString.Length >= 3 Then
                            dr_CONSULTA("Circulo_Registral") = Trim(stMatricula).ToString.Substring(0, 3)
                        Else
                            dr_CONSULTA("Circulo_Registral") = "0"
                        End If

                        dr_CONSULTA("Tomo") = Trim(stTomo)
                        dr_CONSULTA("Folio") = Trim(stFolio)
                        dr_CONSULTA("Estado") = Trim(stEstado)
                        dr_CONSULTA("Fecha_Registro") = Trim(stFecha_Registro)
                        dr_CONSULTA("Matricula_Segregada") = Trim(stMatricula_Segregada)
                        dr_CONSULTA("Matricula_Abierta_Basada_En") = Trim(stMatricula_Abierta_Basada_En)
                        dr_CONSULTA("Folio_Abierto") = Trim(stFolio_Abierto)
                        dr_CONSULTA("Tomo_Abierto") = Trim(stTomo_Abierto)
                        dr_CONSULTA("Area_Escritura") = Trim(stArea_Escritura)
                        dr_CONSULTA("Falsa_Tradicion") = boFalsa_Tradicion
                        dr_CONSULTA("Cali_Prop") = Trim(stCali_Prop)
                        dr_CONSULTA("Bien_De_Dominio_Publico") = Trim(boBien_De_Dominio_Publico)
                        dr_CONSULTA("Coeficiente_Predio") = Trim(stCoeficiente_Predio)
                        dr_CONSULTA("Coeficiente_Edificio") = Trim(stCoeficiente_Edificio)
                        dr_CONSULTA("Adju_Entidad_Oficial") = Trim(stAdju_Entidad_Oficial)
                        dr_CONSULTA("Area_Terreno") = Trim(stArea_Terreno)
                        dr_CONSULTA("Municipio") = Trim(stMunicipio)
                        dr_CONSULTA("Corregi") = Trim(stCorregi)
                        dr_CONSULTA("Barrio") = Trim(stBarrio)
                        dr_CONSULTA("Manzana") = Trim(stManzana)
                        dr_CONSULTA("Predio") = Trim(stPredio)
                        dr_CONSULTA("Edificio") = Trim(stEdificio)
                        dr_CONSULTA("Unidad") = Trim(stUnidad)
                        dr_CONSULTA("Direccion") = Trim(stDireccion)
                        dr_CONSULTA("Destino_Economico") = Trim(stDestino_Economico)
                        dr_CONSULTA("Caracteris_Predio") = Trim(stCaracteris_Predio)
                        dr_CONSULTA("Adquisicion") = Trim(stAdquisicion)
                        dr_CONSULTA("Pri_Apellido_Actual") = Trim(stPri_Apellido_Actual)
                        dr_CONSULTA("Seg_Apellido_Actual") = Trim(stSeg_Apellido_Actual)
                        dr_CONSULTA("Nombre_Actual") = Trim(stNombre_Actual)
                        dr_CONSULTA("Sigla_Comercial") = Trim(stSigla_Comercial)
                        dr_CONSULTA("Tipo_Docu") = Trim(stTipo_Docu)
                        dr_CONSULTA("Nro_Documento") = Trim(stNro_Documento)
                        dr_CONSULTA("Derecho") = Trim(stDerecho)
                        dr_CONSULTA("Pri_Apellido_Anterior") = Trim(stPri_Apellido_Anterior)
                        dr_CONSULTA("Seg_Apellido_Anterior") = Trim(stSeg_Apellido_Anterior)
                        dr_CONSULTA("Nombre_Anterior") = Trim(stNombre_Anterior)
                        dr_CONSULTA("Causa_Del_Acto") = Trim(stCausa_Del_Acto)
                        dr_CONSULTA("Nro_Escritura") = Trim(stNro_Escritura)
                        dr_CONSULTA("Notaria") = Trim(stNotaria)
                        dr_CONSULTA("Fecha_Escritura") = Trim(stFecha_Escritura)
                        dr_CONSULTA("Plano_Protocolizado") = boPlano_Protocolizado
                        dr_CONSULTA("Observacion_Juridica") = Trim(stObservacion_Juridica)
                        dr_CONSULTA("Observacion_Ficha") = Trim(stObservacion_Ficha)
                        dr_CONSULTA("Observacion_Propietario_Anterior") = Trim(stObservacion_Propietario_Anterior)
                        dr_CONSULTA("Nro_Ficha") = Trim(stNro_Ficha)
                        dr_CONSULTA("Mejora") = boMejora
                        dr_CONSULTA("Sector") = Trim(stSector)

                        dt_CONSULTA.Rows.Add(dr_CONSULTA)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' llena el datagridview
                    Me.dgvCONSULTA.DataSource = dt_CONSULTA

                End If

            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString

            Me.pbPROCESO.Value = 0

            Me.cmdCONSULTAR.Enabled = True
            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdULTIMACONSULTA.Click
        pro_LimpiarCampos()
        pro_ObtenerConsulta()
        cmdCONSULTAR.Focus()
    End Sub
    Private Sub cmdPLANO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            If dgvCONSULTA.RowCount > 0 Then

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

                    ' se carga el separador
                    Separador = Trim(txtSEPARADOR.Text)

                    'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
                    Using archivo As StreamWriter = New StreamWriter(oCrear.FileName)

                        ' variable para almacenar la línea actual del dataview
                        Dim linea As String = String.Empty

                        With dgvCONSULTA
                            ' Recorrer las filas del dataGridView
                            For fila As Integer = 0 To .RowCount - 1
                                ' vaciar la línea
                                linea = String.Empty

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For col As Integer = 0 To .Columns.Count - 1
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    linea = linea & Trim(.Item(col, fila).Value.ToString) & Separador
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
                    'txtRUTA.Text = ""
                    txtFIPRNUFI.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()
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
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFIPRNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()

        pro_PermisoControlDeComandos()
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
    Private Sub cmdPLANO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub dgvCONSULTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        strBARRESTA.Items(0).Text = dgvCONSULTA.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
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

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRESTA.KeyDown, dgvCONSULTA.KeyDown, txtFIPRCASU.KeyDown, txtFIPRCAPR.KeyDown, txtFIPRMOAD.KeyDown
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

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        If tstBAESDESC.Text <> "" Then
            MessageBox.Show(Trim(tstBAESDESC.Text), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#End Region

End Class