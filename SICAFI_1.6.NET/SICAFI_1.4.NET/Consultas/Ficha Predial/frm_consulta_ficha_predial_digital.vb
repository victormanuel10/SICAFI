Imports REGLAS_DEL_NEGOCIO
Imports JEJ.ImprimirFicha
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
'Imports System.Linq
Imports System.Windows.Forms


Public Class frm_consulta_ficha_predial_digital

    '=======================================
    ' *** CONSULTA FICHA PREDIAL DIGITAL ***
    '=======================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_ficha_predial_digital
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_ficha_predial_digital
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

    ' variables de conexión
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

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
    Dim stFPPRNUDO As String
    Dim stFPPRMAIN As String
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
    Dim Guardar_stFPPRNUDO As String
    Dim Guardar_stFPPRMAIN As String

    Dim tblCONSULTA As New DataTable
    Dim vl_inFIPRNUFI As Integer = 0
    Dim vl_boControlComandos As Boolean = False

    ' declara las variables
    Dim st01_Python As String = ""
    Dim st02_CarpetaArchivosTemporales As String = ""
    Dim st03_InstanciaBaseDeDatos As String = ""
    Dim st04_UsuarioBaseDeDatos As String = ""
    Dim st05_ClaveBaseDeDatos As String = ""
    Dim st06_NumeroFichaPredial As String = ""
    Dim st07_ArchivosShpPrediosUrbanos As String = ""
    Dim st08_ArchivosShpConstruccionesUrbanos As String = ""
    Dim st09_ArchivosArchivosPythonServidor As String = ""
    Dim st10_CarpetaOrtofoto As String = ""
    Dim st11_ClaseSector As String = ""
    Dim st12_ArchivosShpPrediosRurales As String = ""
    Dim st13_ArchivosShpConstruccionesRurales As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_PermisoControlDeComandos()

        Try
            ' declaro la variable
            Dim boPermisoControl As Boolean = fun_PermisoControlDeComandos(vp_usuario, Me.Name, "axaVisorDocumentoPDF")

            Me.axaPlanoPredio.setShowToolbar(boPermisoControl)

            vl_boControlComandos = boPermisoControl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ConsultarPrediosCedulaCatastral()

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi as NroFicha, "
            ParametrosConsulta += "FiprDire as Direccion, "
            ParametrosConsulta += "FiprDepa as Departamento, "
            ParametrosConsulta += "FiprCapr as Caracteristica, "
            ParametrosConsulta += "FiprMuni as Municipio, "
            ParametrosConsulta += "FiprCorr as Corregi, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as UnidPred, "
            ParametrosConsulta += "FiprClse as Sector "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprNufi like '" & CStr(Trim(stFIPRNUFI)) & "' and "
            ParametrosConsulta += "FiprDire like '" & CStr(Trim(stFIPRDIRE)) & "' and "
            ParametrosConsulta += "FiprMuni like '" & CStr(Trim(stFIPRMUNI)) & "' and "
            ParametrosConsulta += "FiprCorr like '" & CStr(Trim(stFIPRCORR)) & "' and "
            ParametrosConsulta += "FiprBarr like '" & CStr(Trim(stFIPRBARR)) & "' and "
            ParametrosConsulta += "FiprManz like '" & CStr(Trim(stFIPRMANZ)) & "' and "
            ParametrosConsulta += "FiprPred like '" & CStr(Trim(stFIPRPRED)) & "' and "
            ParametrosConsulta += "FiprEdif like '" & CStr(Trim(stFIPREDIF)) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & CStr(Trim(stFIPRUNPR)) & "' and "
            ParametrosConsulta += "FiprClse like '" & CStr(Trim(stFIPRCLSE)) & "' and "
            ParametrosConsulta += "FiprTifi = 0 "
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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then
                ' llena el datagridview
                If dt.Rows.Count > 500 Then
                    ' controla la sobregarga del datagridview
                    If MessageBox.Show("La consulta sobrecargara el sistema" & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "Nro. de registros para cargar :  " & dt.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' llena el datagridview
                        Me.dgvCONSULTA.DataSource = dt
                    Else
                        ' sale del proceso de consulta
                        Exit Sub
                    End If
                End If

                ' llena el datagridview
                Me.dgvCONSULTA.DataSource = dt

                Me.dgvCONSULTA.Columns(1).Visible = False
                Me.dgvCONSULTA.Columns(2).Visible = False
                Me.dgvCONSULTA.Columns(3).Visible = False

                ' llena la lista de valores
                pro_ListaDeValores()
                'pro_VisualizarFichaPredialDigital()
            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount.ToString

            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConsultarPrediosCedulaDeCiudadania()

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi as NroFicha, "
            ParametrosConsulta += "FiprDire as Direccion, "
            ParametrosConsulta += "FiprDepa as Departamento, "
            ParametrosConsulta += "FiprCapr as Caracteristica, "
            ParametrosConsulta += "FiprMuni as Municipio, "
            ParametrosConsulta += "FiprCorr as Corregi, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as UnidPred, "
            ParametrosConsulta += "FiprClse as Sector "
            ParametrosConsulta += "From FichPred where "

            ParametrosConsulta += "Exists(select 1 from fiprprop where fiprnufi = fpprnufi and fppresta = 'ac' and fpprnudo like '" & stFPPRNUDO & "') and "

            ParametrosConsulta += "FiprTifi = 0 "
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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then
                ' llena el datagridview
                If dt.Rows.Count > 500 Then
                    ' controla la sobregarga del datagridview
                    If MessageBox.Show("La consulta sobrecargara el sistema" & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "Nro. de registros para cargar :  " & dt.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' llena el datagridview
                        Me.dgvCONSULTA.DataSource = dt
                    Else
                        ' sale del proceso de consulta
                        Exit Sub
                    End If
                End If

                ' llena el datagridview
                Me.dgvCONSULTA.DataSource = dt

                Me.dgvCONSULTA.Columns(1).Visible = False
                Me.dgvCONSULTA.Columns(2).Visible = False
                Me.dgvCONSULTA.Columns(3).Visible = False

                ' llena la lista de valores
                pro_ListaDeValores()
                pro_VisualizarFichaPredialDigital()
            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount.ToString

            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConsultarPrediosMatriculaInmobiliario()

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi as NroFicha, "
            ParametrosConsulta += "FiprDire as Direccion, "
            ParametrosConsulta += "FiprDepa as Departamento, "
            ParametrosConsulta += "FiprCapr as Caracteristica, "
            ParametrosConsulta += "FiprMuni as Municipio, "
            ParametrosConsulta += "FiprCorr as Corregi, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as UnidPred, "
            ParametrosConsulta += "FiprClse as Sector "
            ParametrosConsulta += "From FichPred where "

            ParametrosConsulta += "Exists(select 1 from fiprprop where fiprnufi = fpprnufi and fppresta = 'ac' and fpprmain like '" & stFPPRMAIN & "') and "

            ParametrosConsulta += "FiprTifi = 0 "
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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then
                ' llena el datagridview
                If dt.Rows.Count > 500 Then
                    ' controla la sobregarga del datagridview
                    If MessageBox.Show("La consulta sobrecargara el sistema" & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "Nro. de registros para cargar :  " & dt.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' llena el datagridview
                        Me.dgvCONSULTA.DataSource = dt
                    Else
                        ' sale del proceso de consulta
                        Exit Sub
                    End If
                End If

                ' llena el datagridview
                Me.dgvCONSULTA.DataSource = dt

                Me.dgvCONSULTA.Columns(1).Visible = False
                Me.dgvCONSULTA.Columns(2).Visible = False
                Me.dgvCONSULTA.Columns(3).Visible = False

                ' llena la lista de valores
                pro_ListaDeValores()
                pro_VisualizarFichaPredialDigital()
            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount.ToString

            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

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

        Me.axaPlanoPredio.EndInit()

        Me.dgvCONSULTA.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.txtFIPRNUFI.Focus()

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(Me.txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
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

        If Trim(Me.txtFPPRNUDO.Text) = "" Then
            stFPPRNUDO = "%"
        Else
            stFPPRNUDO = Trim(Me.txtFPPRNUDO.Text)
        End If

        If Trim(Me.txtFPPRMAIN.Text) = "" Then
            stFPPRMAIN = "%"
        Else
            stFPPRMAIN = Trim(Me.txtFPPRMAIN.Text)
        End If

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            Dim I, SW As Byte

            While I < Me.dgvCONSULTA.RowCount And SW = 0
                If Me.dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos de ficha predial
                    Me.txtFIPRNUFI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())
                    Me.txtFIPRDIRE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    Me.txtFIPRMUNI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    Me.txtFIPRCORR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    Me.txtFIPRBARR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    Me.txtFIPRMANZ.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    Me.txtFIPRPRED.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    Me.txtFIPREDIF.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())
                    Me.txtFIPRUNPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(10).Value.ToString())
                    Me.txtFIPRCLSE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())

                    vl_inFIPRNUFI = CInt(Me.txtFIPRNUFI.Text)

                    SW = 1
                Else
                    I = I + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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
        Guardar_stFPPRNUDO = Trim(Me.txtFPPRNUDO.Text)
        Guardar_stFPPRMAIN = Trim(Me.txtFPPRMAIN.Text)

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
        Me.txtFPPRNUDO.Text = Guardar_stFPPRNUDO
        Me.txtFPPRMAIN.Text = Guardar_stFPPRMAIN

    End Sub

    Private Sub pro_VisualizarFichaPredialDigital()

        Try
            ' Consulta imagenes de ficha predial
            If Me.dgvCONSULTA.RowCount > 0 Then

                ' instancia la clase
                Dim obRutaFichaPredialDigital As New cla_RUTAFPDI

                ' declaro las tablas
                Dim tbRuta01Python As New DataTable
                Dim tbRuta02CarpetaArchivosTemporales As New DataTable
                Dim tbRuta07ArchivosShpPrediosUrbanos As New DataTable
                Dim tbRuta08RutaArchivosShpConstruccionesUrbanos As New DataTable
                Dim tbRuta09ArchivosArchivosPythonServidor As New DataTable
                Dim tbRuta10CarpetaOrtofoto As New DataTable
                Dim tbRuta12ArchivosShpPrediosRurales As New DataTable
                Dim tbRuta13RutaArchivosShpConstruccionesRurales As New DataTable

                ' almacena la Ruta01Python                                                                                     
                tbRuta01Python = obRutaFichaPredialDigital.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 1)

                ' almacena la ruta Ruta02CarpetaArchivosTemporales                                                                                   
                tbRuta02CarpetaArchivosTemporales = obRutaFichaPredialDigital.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 2)

                ' almacena la Ruta07ArchivosShpPrediosUrbanos                                                                                   
                tbRuta07ArchivosShpPrediosUrbanos = obRutaFichaPredialDigital.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 7)

                ' almacena la ruta Ruta08RutaArchivosShpConstruccionesUrbanos                                                                                   
                tbRuta08RutaArchivosShpConstruccionesUrbanos = obRutaFichaPredialDigital.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 8)

                ' almacena la ruta Ruta09ArchivosArchivosPythonServidor                                                                                   
                tbRuta09ArchivosArchivosPythonServidor = obRutaFichaPredialDigital.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 9)

                ' almacena la ruta Ruta10CarpetaOrtofoto                                                                                   
                tbRuta10CarpetaOrtofoto = obRutaFichaPredialDigital.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 10)

                ' almacena la ruta Ruta12ArchivosShpPrediosRurales                                                                                   
                tbRuta12ArchivosShpPrediosRurales = obRutaFichaPredialDigital.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 11)

                ' almacena la ruta Ruta13RutaArchivosShpConstruccionesRurales                                                                                   
                tbRuta13RutaArchivosShpConstruccionesRurales = obRutaFichaPredialDigital.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUFD_X_MANT_RUTAFPDI(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                 Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 12)

                ' declara la instancia
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString

                ' limpia las variables
                st01_Python = ""
                st02_CarpetaArchivosTemporales = ""
                st03_InstanciaBaseDeDatos = oCadenaConexion.fun_DataSource
                st04_UsuarioBaseDeDatos = oCadenaConexion.fun_UserID
                st05_ClaveBaseDeDatos = oCadenaConexion.fun_Password
                st06_NumeroFichaPredial = Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()
                st07_ArchivosShpPrediosUrbanos = ""
                st08_ArchivosShpConstruccionesUrbanos = ""
                st09_ArchivosArchivosPythonServidor = ""
                st10_CarpetaOrtofoto = ""
                st11_ClaseSector = Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString()
                st12_ArchivosShpPrediosRurales = ""
                st13_ArchivosShpConstruccionesRurales = ""

                ' almacena la Ruta01Python           
                If tbRuta01Python.Rows.Count > 0 Then
                    st01_Python = CStr(Trim(tbRuta01Python.Rows(0).Item("RUFDRUTA")))
                End If

                ' almacena la Ruta02CarpetaArchivosTemporales       
                If tbRuta02CarpetaArchivosTemporales.Rows.Count > 0 Then
                    st02_CarpetaArchivosTemporales = CStr(Trim(tbRuta02CarpetaArchivosTemporales.Rows(0).Item("RUFDRUTA")))
                End If

                ' almacena la Ruta07ArchivosShpPrediosUrbanos           
                If tbRuta07ArchivosShpPrediosUrbanos.Rows.Count > 0 Then
                    st07_ArchivosShpPrediosUrbanos = CStr(Trim(tbRuta07ArchivosShpPrediosUrbanos.Rows(0).Item("RUFDRUTA")))
                End If

                ' almacena la Ruta08RutaArchivosShpConstruccionesUrbanos           
                If tbRuta08RutaArchivosShpConstruccionesUrbanos.Rows.Count > 0 Then
                    st08_ArchivosShpConstruccionesUrbanos = CStr(Trim(tbRuta08RutaArchivosShpConstruccionesUrbanos.Rows(0).Item("RUFDRUTA")))
                End If

                ' almacena la Ruta09ArchivosArchivosPythonServidor           
                If tbRuta09ArchivosArchivosPythonServidor.Rows.Count > 0 Then
                    st09_ArchivosArchivosPythonServidor = CStr(Trim(tbRuta09ArchivosArchivosPythonServidor.Rows(0).Item("RUFDRUTA")))
                End If

                ' almacena la Ruta10CarpetaOrtofoto           
                If tbRuta10CarpetaOrtofoto.Rows.Count > 0 Then
                    st10_CarpetaOrtofoto = CStr(Trim(tbRuta10CarpetaOrtofoto.Rows(0).Item("RUFDRUTA")))
                End If

                ' almacena la Ruta12ArchivosShpPrediosRurales           
                If tbRuta12ArchivosShpPrediosRurales.Rows.Count > 0 Then
                    st12_ArchivosShpPrediosRurales = CStr(Trim(tbRuta12ArchivosShpPrediosRurales.Rows(0).Item("RUFDRUTA")))
                End If

                ' almacena la Ruta13RutaArchivosShpConstruccionesRurales           
                If tbRuta13RutaArchivosShpConstruccionesRurales.Rows.Count > 0 Then
                    st13_ArchivosShpConstruccionesRurales = CStr(Trim(tbRuta13RutaArchivosShpConstruccionesRurales.Rows(0).Item("RUFDRUTA")))
                End If

                Dim stConsola As String = ""

                ' reprote para predios urbano
                If CInt(Trim(st11_ClaseSector)) = 1 Then

                    Dim objImprimirFicha As New ImprimirFicha(st01_Python, _
                                                              st02_CarpetaArchivosTemporales, _
                                                              st03_InstanciaBaseDeDatos, _
                                                              st04_UsuarioBaseDeDatos, _
                                                              st05_ClaveBaseDeDatos, _
                                                              st06_NumeroFichaPredial, _
                                                              st07_ArchivosShpPrediosUrbanos, _
                                                              st08_ArchivosShpConstruccionesUrbanos, _
                                                              st09_ArchivosArchivosPythonServidor, _
                                                              st10_CarpetaOrtofoto, _
                                                              Me.chkGenerarCroquis.Checked)

                    objImprimirFicha.Imprimir(st02_CarpetaArchivosTemporales, stConsola)

                    ' reporte para predio rural
                ElseIf CInt(Trim(st11_ClaseSector)) = 2 Then

                    Dim objImprimirFicha As New ImprimirFicha(st01_Python, _
                                                              st02_CarpetaArchivosTemporales, _
                                                              st03_InstanciaBaseDeDatos, _
                                                              st04_UsuarioBaseDeDatos, _
                                                              st05_ClaveBaseDeDatos, _
                                                              st06_NumeroFichaPredial, _
                                                              st12_ArchivosShpPrediosRurales, _
                                                              st13_ArchivosShpConstruccionesRurales, _
                                                              st09_ArchivosArchivosPythonServidor, _
                                                              st10_CarpetaOrtofoto, _
                                                              Me.chkGenerarCroquis.Checked)

                    objImprimirFicha.Imprimir(st02_CarpetaArchivosTemporales, stConsola)

                End If

                ' Visualiza el archivo PDF
                If Me.axaPlanoPredio.LoadFile(Trim(st02_CarpetaArchivosTemporales) & "\" & Trim(st06_NumeroFichaPredial) & ".pdf") = True Then

                    ' visualiza el archivo
                    Me.axaPlanoPredio.LoadFile(Trim(st02_CarpetaArchivosTemporales) & "\" & Trim(st06_NumeroFichaPredial) & ".pdf")
                    Me.axaPlanoPredio.gotoFirstPage()

                End If

                ' refreca el control
                Me.axaPlanoPredio.Refresh()

                ' control de comandos
                pro_PermisoControlDeComandos()

                mod_MENSAJE.Proceso_Termino_Correctamente()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
  
#End Region

#Region "MENU"

    Private Sub cmdConsultaCedulaCatastral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultaCedulaCatastral.Click
        pro_ConsultarPrediosCedulaCatastral()
    End Sub
    Private Sub cmdConsultarCedulaDeCiudadania_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarCedulaDeCiudadania.Click
        pro_ConsultarPrediosCedulaDeCiudadania()
    End Sub
    Private Sub cmdConsultarMatriculaInmobiliaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarMatriculaInmobiliaria.Click
        pro_ConsultarPrediosMatriculaInmobiliario()
    End Sub
    Private Sub cmdVisualizarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVisualizarFicha.Click
        pro_VisualizarFichaPredialDigital()
    End Sub

    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdULTIMACONSULTA.Click
        pro_LimpiarCampos()
        pro_ObtenerConsulta()
        Me.cmdConsultaCedulaCatastral.Focus()
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
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

    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        Me.txtFIPRNUFI.SelectionStart = 0
        Me.txtFIPRNUFI.SelectionLength = Len(Me.txtFIPRNUFI.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        Me.txtFIPRDIRE.SelectionStart = 0
        Me.txtFIPRDIRE.SelectionLength = Len(Me.txtFIPRDIRE.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRDIRE.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        Me.txtFIPRMUNI.SelectionStart = 0
        Me.txtFIPRMUNI.SelectionLength = Len(Me.txtFIPRMUNI.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRMUNI.AccessibleDescription
    End Sub
    Private Sub txtFIPRCORR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.GotFocus
        Me.txtFIPRCORR.SelectionStart = 0
        Me.txtFIPRCORR.SelectionLength = Len(Me.txtFIPRCORR.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRCORR.AccessibleDescription
    End Sub
    Private Sub txtFIPRBARR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.GotFocus
        Me.txtFIPRBARR.SelectionStart = 0
        Me.txtFIPRBARR.SelectionLength = Len(Me.txtFIPRBARR.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRBARR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMANZ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.GotFocus
        Me.txtFIPRMANZ.SelectionStart = 0
        Me.txtFIPRMANZ.SelectionLength = Len(Me.txtFIPRMANZ.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRMANZ.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.GotFocus
        Me.txtFIPRPRED.SelectionStart = 0
        Me.txtFIPRPRED.SelectionLength = Len(Me.txtFIPRPRED.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRPRED.AccessibleDescription
    End Sub
    Private Sub txtFIPREDIF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.GotFocus
        Me.txtFIPREDIF.SelectionStart = 0
        Me.txtFIPREDIF.SelectionLength = Len(Me.txtFIPREDIF.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPREDIF.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.GotFocus
        Me.txtFIPRUNPR.SelectionStart = 0
        Me.txtFIPRUNPR.SelectionLength = Len(Me.txtFIPRUNPR.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRUNPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus
        Me.txtFIPRCLSE.SelectionStart = 0
        Me.txtFIPRCLSE.SelectionLength = Len(Me.txtFIPRCLSE.Text)
        Me.strBARRESTA.Items(0).Text = Me.txtFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdConsultaCedulaCatastral.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.cmdConsultaCedulaCatastral.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub dgvCONSULTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvCONSULTA.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
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
            Me.cmdConsultaCedulaCatastral.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdConsultaCedulaCatastral.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, dgvCONSULTA.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdConsultaCedulaCatastral.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            cmdULTIMACONSULTA.PerformClick()
        End If

    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONSULTA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA.CellClick
        pro_VisualizarFichaPredialDigital()
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_VisualizarFichaPredialDigital()
            pro_ListaDeValores()
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

#End Region

#Region "Click"

    Private Sub cmdVistaPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVistaPredio.Click

        Try
            If Trim(st02_CarpetaArchivosTemporales) <> "" Then
                Dim o_frm_Visor As New frm_visor_PDF(Trim(st02_CarpetaArchivosTemporales) & "\" & Trim(st06_NumeroFichaPredial) & ".pdf", vl_boControlComandos)
                o_frm_Visor.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#End Region

    
End Class