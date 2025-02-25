Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_Plano_Cartografico

    '====================================
    ' *** CONSULTA PLANO CARTOGRAFICO ***
    '====================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_Plano_Cartografico
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_Plano_Cartografico
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
    Dim stRutaPredio As String = ""
    Dim stRutaConstruccion As String = ""
    Dim stRutaLinderos As String = ""
    Dim stRutaZonas As String = ""
    Dim stRutaManzanero As String = ""

    ' declara la variable
    Dim stArchivoPredio As String = ""
    Dim stArchivoConstruccion As String = ""
    Dim stArchivoLinderos As String = ""
    Dim stArchivoZonas As String = ""
    Dim stArchivoManzanero As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_PermisoControlDeComandos()

        Try
            ' declaro la variable
            Dim boPermisoControl As Boolean = fun_PermisoControlDeComandos(vp_usuario, Me.Name, "axaVisorDocumentoPDF")

            Me.axaPlanoPredio.setShowToolbar(boPermisoControl)
            Me.axaPlanoConstruccion.setShowToolbar(boPermisoControl)
            Me.axaPlanoLinderos.setShowToolbar(boPermisoControl)
            Me.axaPlanoZonas.setShowToolbar(boPermisoControl)

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
                pro_VisualizarPredioCartografico()
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
                pro_VisualizarPredioCartografico()
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
                pro_VisualizarPredioCartografico()
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

    Private Sub pro_CargaConstruccion()

        Try
            If Me.dgvCONSULTA.RowCount > 0 Then

                Dim objdatos22 As New cla_FIPRCONS
                Dim tbl22 As New DataTable

                tbl22 = objdatos22.fun_Buscar_NRO_SECUENCIA_FIPRCONS_X_FICHA_PREDIAL(vl_inFIPRNUFI)

                If tbl22.Rows.Count > 0 Then

                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow

                    dt1.Columns.Add(New DataColumn("Nro. Construcción", GetType(String)))

                    Dim k As Integer = 0

                    For k = 0 To tbl22.Rows.Count - 1

                        dr1 = dt1.NewRow()

                        dr1("Nro. Construcción") = CType(Trim(tbl22.Rows(k).Item("FPCOUNID")), String)

                        dt1.Rows.Add(dr1)

                    Next

                    Me.dgvCONSTRUCCION.DataSource = dt1

                End If
            End If


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
        Me.dgvCONSTRUCCION.DataSource = New DataTable

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

    Private Sub pro_VisualizarPredioCartografico()

        Try
            ' Consulta imagenes de ficha predial
            If Me.dgvCONSULTA.RowCount > 0 Then

                ' instancia la clase
                Dim obRutaPlanoCartografico As New cla_RUTAPLCA

                ' declaro las tablas
                Dim tbRutaPredio As New DataTable
                Dim tbRutaConstruccion As New DataTable
                Dim tbRutaLinderos As New DataTable
                Dim tbRutaZonas As New DataTable
                Dim tbRutaManzanero As New DataTable

                ' almacena la ruta de los planos
                tbRutaPredio = obRutaPlanoCartografico.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUPC_X_MANT_RUTAPLCA(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                             Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                             Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 1)

                ' almacena la ruta de los planos
                tbRutaConstruccion = obRutaPlanoCartografico.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUPC_X_MANT_RUTAPLCA(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                   Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                   Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 2)

                ' almacena la ruta de los planos
                tbRutaLinderos = obRutaPlanoCartografico.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUPC_X_MANT_RUTAPLCA(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                               Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                               Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 3)

                ' almacena la ruta de los planos
                tbRutaZonas = obRutaPlanoCartografico.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUPC_X_MANT_RUTAPLCA(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                            Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                            Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 4)

                ' almacena la ruta de los planos
                tbRutaManzanero = obRutaPlanoCartografico.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUPC_X_MANT_RUTAPLCA(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 5)

                ' ejecuta la consulta del predio
                If tbRutaPredio.Rows.Count > 0 Then

                    ' carga construccion
                    pro_CargaConstruccion()

                    ' Limpia la variable
                    stArchivoPredio = ""

                    ' almacena la ruta
                    stRutaPredio = CStr(Trim(tbRutaPredio.Rows(0).Item("RUPCRUTA")))

                    ' aplica ficha predial
                    If Me.rbdReporteFichaPredial.Checked = True Then

                        stArchivoPredio = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString()) & ".pdf"

                    End If

                    ' aplica ficha resumen
                    If Me.rbdReporteFichaResumen.Checked = True Then

                        stArchivoPredio = fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())) & _
                                                                       Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString()) & _
                                          fun_Formato_Mascara_2_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())) & _
                                          fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())) & _
                                          fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())) & _
                                          fun_Formato_Mascara_5_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())) & ".pdf"
                    End If

                    ' verifica el archivo
                    If Me.axaPlanoPredio.LoadFile(Trim(stRutaPredio) & "\" & Trim(stArchivoPredio)) = True Then

                        ' visualiza el archivo
                        Me.axaPlanoPredio.LoadFile(Trim(stRutaPredio) & "\" & Trim(stArchivoPredio))
                        Me.axaPlanoPredio.gotoFirstPage()

                    End If

                    ' refreca el control
                    Me.axaPlanoPredio.Refresh()

                End If

                ' ejecuta la consulta de la construccion
                If tbRutaConstruccion.Rows.Count > 0 Then
                    If Me.dgvCONSTRUCCION.RowCount > 0 Then

                        ' limpia la variable
                        stArchivoConstruccion = ""

                        ' almacena la ruta
                        stRutaConstruccion = CStr(Trim(tbRutaConstruccion.Rows(0).Item("RUPCRUTA")))

                        ' aplica ficha predial
                        If Me.rbdReporteFichaPredial.Checked = True Then

                            stArchivoConstruccion = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString()) & "-" & _
                                                    Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString()) & ".pdf"

                        End If

                        ' aplica ficha resumen
                        If Me.rbdReporteFichaResumen.Checked = True Then

                            stArchivoConstruccion = fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())) & _
                                                                                 Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString()) & _
                                                    fun_Formato_Mascara_2_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())) & _
                                                    fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())) & _
                                                    fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())) & _
                                                    fun_Formato_Mascara_5_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())) & "-" & _
                                                                                 Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString()) & ".pdf"
                        End If

                        ' verifica el archivo
                        If Me.axaPlanoConstruccion.LoadFile(Trim(stRutaConstruccion) & "\" & Trim(stArchivoConstruccion)) = True Then

                            ' visualiza el archivo
                            Me.axaPlanoConstruccion.LoadFile(Trim(stRutaConstruccion) & "\" & Trim(stArchivoConstruccion))
                            Me.axaPlanoConstruccion.gotoFirstPage()

                        End If

                        ' refresca el control
                        Me.axaPlanoConstruccion.Refresh()

                    End If
                End If

                ' ejecuta la consulta de los linderos
                If tbRutaLinderos.Rows.Count > 0 Then

                    ' limpia la variable
                    stArchivoLinderos = ""

                    ' almacena la ruta
                    stRutaLinderos = CStr(Trim(tbRutaLinderos.Rows(0).Item("RUPCRUTA")))

                    ' aplica ficha predial
                    If Me.rbdReporteFichaPredial.Checked = True Then

                        stArchivoLinderos = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString()) & ".pdf"

                    End If

                    ' aplica ficha resumen
                    If Me.rbdReporteFichaResumen.Checked = True Then

                        stArchivoLinderos = fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())) & _
                                                                         Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString()) & _
                                            fun_Formato_Mascara_2_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())) & _
                                            fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())) & _
                                            fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())) & _
                                            fun_Formato_Mascara_5_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())) & ".pdf"
                    End If

                    ' verifica el archivo
                    If Me.axaPlanoLinderos.LoadFile(Trim(stRutaLinderos) & "\" & Trim(stArchivoLinderos)) = True Then

                        ' visualiza el archivo
                        Me.axaPlanoLinderos.LoadFile(Trim(stRutaLinderos) & "\" & Trim(stArchivoLinderos))
                        Me.axaPlanoLinderos.gotoFirstPage()

                    End If

                    ' refreca el control
                    Me.axaPlanoLinderos.Refresh()

                End If

                ' ejecuta la consulta de las zonas
                If tbRutaZonas.Rows.Count > 0 Then

                    ' limpia la variable
                    stArchivoZonas = ""

                    ' almacena la ruta
                    stRutaZonas = CStr(Trim(tbRutaZonas.Rows(0).Item("RUPCRUTA")))

                    ' aplica ficha predial
                    If Me.rbdReporteFichaPredial.Checked = True Then

                        stArchivoZonas = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString()) & ".pdf"

                    End If

                    ' aplica ficha resumen
                    If Me.rbdReporteFichaResumen.Checked = True Then

                        stArchivoZonas = fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())) & _
                                                                      Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString()) & _
                                         fun_Formato_Mascara_2_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())) & _
                                         fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())) & _
                                         fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())) & _
                                         fun_Formato_Mascara_5_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())) & ".pdf"
                    End If

                    ' verifica el archivo
                    If Me.axaPlanoZonas.LoadFile(Trim(stRutaZonas) & "\" & Trim(stArchivoZonas)) = True Then

                        ' visualiza el archivo
                        Me.axaPlanoZonas.LoadFile(Trim(stRutaZonas) & "\" & Trim(stArchivoZonas))
                        Me.axaPlanoZonas.gotoFirstPage()

                    End If

                    ' refreca el control
                    Me.axaPlanoZonas.Refresh()

                End If

                ' ejecuta la consulta del plano manzanero
                If tbRutaManzanero.Rows.Count > 0 Then

                    ' limpia la variable
                    stArchivoManzanero = ""

                    ' almacena la ruta
                    stRutaManzanero = CStr(Trim(tbRutaManzanero.Rows(0).Item("RUPCRUTA")))

                    ' sector urbano
                    If CInt(Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())) = 1 Then

                        stArchivoManzanero = fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())) & _
                                                                          Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString()) & _
                                             fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())) & _
                                             fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())) & _
                                             fun_Formato_Mascara_4_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())) & ".pdf"
                    End If

                    ' sector rural
                    If CInt(Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())) = 2 Then

                        stArchivoManzanero = fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())) & _
                                                                          Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString()) & _
                                             fun_Formato_Mascara_3_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())) & _
                                             "000" & _
                                             fun_Formato_Mascara_4_String(Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())) & ".pdf"
                    End If

                    ' visualiza el archivo
                    Me.axaPlanoManzanero.LoadFile(Trim(stRutaManzanero) & "\" & Trim(stArchivoManzanero))
                    Me.axaPlanoManzanero.gotoFirstPage()

                    ' refreca el control
                    Me.axaPlanoManzanero.Refresh()

                End If

                ' control de comandos
                pro_PermisoControlDeComandos()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_VisualizarConstruccionCartografico()

        Try
            ' Consulta imagenes de ficha predial
            If Me.dgvCONSULTA.RowCount > 0 Then

                ' declara las variables
                Dim stRutaConstruccion As String = ""

                ' instancia la clase
                Dim obRutaPlanoCartografico As New cla_RUTAPLCA

                ' declaro las tablas
                Dim tbRutaConstruccion As New DataTable

                ' almacena la ruta de los planos
                tbRutaConstruccion = obRutaPlanoCartografico.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUPC_X_MANT_RUTAPLCA(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(2).Value.ToString(), _
                                                                                                                   Me.dgvCONSULTA.SelectedRows.Item(0).Cells(4).Value.ToString(), _
                                                                                                                   Me.dgvCONSULTA.SelectedRows.Item(0).Cells(11).Value.ToString(), 2)


                ' ejecuta la consulta de la construccion
                If tbRutaConstruccion.Rows.Count > 0 Then
                    If Me.dgvCONSTRUCCION.RowCount > 0 Then

                        ' declara la variable
                        stArchivoConstruccion = ""

                        ' almacena la ruta
                        stRutaConstruccion = CStr(Trim(tbRutaConstruccion.Rows(0).Item("RUPCRUTA")))

                        stArchivoConstruccion = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString()) & "-" & _
                                                Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString()) & ".pdf"

                        ' visualiza el archivo
                        Me.axaPlanoConstruccion.LoadFile(Trim(stRutaConstruccion) & "\" & Trim(stArchivoConstruccion))
                        Me.axaPlanoConstruccion.gotoFirstPage()

                    End If
                End If

                pro_PermisoControlDeComandos()

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
    Private Sub cmdCALIFICACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCALIFICACION.Click

        If Me.dgvCONSTRUCCION.RowCount > 0 Then
            Dim frm_consulta_calificacion_FIPRCACO As New frm_consulta_calificacion_FIPRCACO(Me.txtFIPRNUFI.Text, Me.dgvCONSTRUCCION.SelectedRows(0).Cells(0).Value.ToString)
            frm_consulta_calificacion_FIPRCACO.ShowDialog()
        Else
            MessageBox.Show("Seleccione una construcción", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

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
        pro_VisualizarPredioCartografico()
        pro_ListaDeValores()
    End Sub
    Private Sub dgvCONSTRUCCION_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSTRUCCION.CellClick
        pro_VisualizarConstruccionCartografico()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_VisualizarPredioCartografico()
            pro_ListaDeValores()
        End If
    End Sub
    Private Sub dgvCONSTRUCCION_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSTRUCCION.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_VisualizarConstruccionCartografico()
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
            If Trim(stRutaPredio) <> "" Then
                Dim o_frm_Visor As New frm_visor_PDF(Trim(stRutaPredio) & "\" & Trim(stArchivoPredio), vl_boControlComandos)
                o_frm_Visor.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdVistaConstruccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVistaConstruccion.Click

        Try
            If Trim(stRutaConstruccion) <> "" Then
                Dim o_frm_Visor As New frm_visor_PDF(Trim(stRutaConstruccion) & "\" & Trim(stArchivoConstruccion), vl_boControlComandos)
                o_frm_Visor.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdVistaLinderos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVistaLinderos.Click

        Try
            If Trim(stRutaLinderos) <> "" Then
                Dim o_frm_Visor As New frm_visor_PDF(Trim(stRutaLinderos) & "\" & Trim(stArchivoLinderos), vl_boControlComandos)
                o_frm_Visor.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdVistaZonas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVistaZonas.Click

        Try
            If Trim(stRutaZonas) <> "" Then
                Dim o_frm_Visor As New frm_visor_PDF(Trim(stRutaZonas) & "\" & Trim(stArchivoZonas), vl_boControlComandos)
                o_frm_Visor.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdVistaManzana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVistaManzana.Click

        Try
            If Trim(stRutaManzanero) <> "" Then
                Dim o_frm_Visor As New frm_visor_PDF(Trim(stRutaManzanero) & "\" & Trim(stArchivoManzanero), vl_boControlComandos)
                o_frm_Visor.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#End Region

End Class