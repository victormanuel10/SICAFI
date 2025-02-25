Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Migrar_Datos_Dinamicamente

    '==================================
    '*** MIGRAR DATOS DINAMICAMENTE ***
    '==================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Migrar_Datos_Dinamicamente
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Migrar_Datos_Dinamicamente
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
    Dim dt_DATOS As New DataTable
    Dim dt_CAMPOS As New DataTable
    Dim dt_TABLA As New DataTable
    Dim dt_INCONSISTENCIA As New DataTable

    Dim dt_TABLA_MANTENIMIENTO As New DataTable
    Dim dt_TABLA_SISTEMA As New DataTable

    ' otros procesos
    Dim stRutaArchivo As String
    Dim stSeparador As String
    Dim inTotalRegistros As Integer
    Dim inProceso As Integer

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Private dt1 As New DataTable
    Private dt2 As New DataTable

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultarTablaMantenimiento(ByVal stCAMPTABL As String, ByVal stCAMPCODI As String, ByVal stCAMPO As String) As Boolean

        Try
            ' instancia un dt
            dt_TABLA_MANTENIMIENTO = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' concatena la consulta
            stConsulta += "Select "
            stConsulta += "* "
            stConsulta += "From " & Trim(stCAMPTABL) & " "
            stConsulta += "Where "
            stConsulta += Trim(stCAMPCODI) & " = '" & Trim(stCAMPO) & "' "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            ' almacena la consulta
            dt_TABLA_MANTENIMIENTO = oConsulta.fun_Consultar_ConexionString(stConsulta)

            ' verifica si existen datos consultados
            If dt_TABLA_MANTENIMIENTO.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return False
        End Try

    End Function
    Private Function fun_ConsultarTablaSistemas(ByVal stCAMPTABL As String, ByVal stCAMPCODI As String, ByVal stCAMPO As String) As Boolean

        Try
            ' instancia un dt
            dt_TABLA_SISTEMA = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' concatena la consulta
            stConsulta += "Select "
            stConsulta += "* "
            stConsulta += "From " & Trim(stCAMPTABL) & " "
            stConsulta += "Where "
            stConsulta += Trim(stCAMPCODI) & " = '" & Trim(stCAMPO) & "' "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            ' almacena la consulta
            dt_TABLA_SISTEMA = oConsulta.fun_Consultar_ConexionString(stConsulta)

            ' verifica si existen datos consultados
            If dt_TABLA_SISTEMA.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return False
        End Try

    End Function
    Private Function fun_Eliminar(ByVal stTabla As String, ByVal stInstruccion As String) As Boolean

        Try
            ' declara la variable
            Dim boResultado As Boolean = False

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' concatena la consulta
            stConsulta += "Delete " & Trim(stTabla) & " "
            stConsulta += "Where " & Trim(stInstruccion)

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Migrar_Datos_Dinamicamente

            ' almacena la consulta
            boResultado = oConsulta.fun_Eliminar(stConsulta)

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return False
        End Try

    End Function
    Private Function fun_Insertar(ByVal stTabla As String, ByVal stInstruccionCampos As String, ByVal stInstruccionValor As String) As Boolean

        Try
            ' declara la variable
            Dim boResultado As Boolean = False

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' concatena la consulta
            stConsulta += "INSERT INTO " & Trim(stTabla) & " "
            stConsulta += "( "
            stConsulta += Trim(stInstruccionCampos)
            stConsulta += ") "
            stConsulta += "VALUES "
            stConsulta += "( "
            stConsulta += Trim(stInstruccionValor)
            stConsulta += ") "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Migrar_Datos_Dinamicamente

            ' almacena la consulta
            boResultado = oConsulta.fun_Insertar(stConsulta)

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return False
        End Try

    End Function
    Private Function fun_Consultar(ByVal stTabla As String, ByVal stInstruccion As String) As Boolean

        Try
            ' declara la variable
            Dim boResultado As Boolean = False

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' concatena la consulta
            stConsulta += "Select * from " & Trim(stTabla) & " "
            stConsulta += "Where " & Trim(stInstruccion)

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Migrar_Datos_Dinamicamente

            ' almacena la consulta
            boResultado = oConsulta.fun_Consultar(stConsulta)

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return False
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.dgvDATOS.DataSource = New DataTable
        Me.dgvINCONSISTENCIAS.DataSource = New DataTable
        Me.dgvTABLAS.DataSource = New DataTable
        Me.dgvCAMPOS.DataSource = New DataTable

        Me.cboCAMPPROC1.DataSource = New DataTable
        Me.cboCAMPPROC2.DataSource = New DataTable
        Me.cboCAMPPROC3.DataSource = New DataTable

        Me.lblRUTA.Text = ""

        Me.cmdValidaDatos.Enabled = False
        Me.cmdGrabarDatos.Enabled = False
        Me.cboCAMPPROC2.Enabled = False
        Me.chkRemplazarRegistros.Enabled = False
        Me.cmdAbrirArchivo.Enabled = False

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

    End Sub
    Private Sub pro_Validar()

        If Me.dgvTABLAS.RowCount > 1 Then
            MessageBox.Show("Existe mas de una tabla", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Me.cmdValidaDatos.Enabled = True
            Exit Sub
        End If

        If Me.dgvTABLAS.RowCount = 0 Then
            MessageBox.Show("No existe tabla", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Me.cmdValidaDatos.Enabled = True
            Exit Sub
        End If

        If Me.dgvCAMPOS.RowCount = 0 Then
            MessageBox.Show("No existe campo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Me.cmdValidaDatos.Enabled = True
            Exit Sub
        End If

        If Me.dgvCAMPOS.RowCount <> Me.dgvDATOS.ColumnCount Then
            MessageBox.Show("La cantidad de columnas cargadas es diferente a la cantidad de campos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Me.cmdValidaDatos.Enabled = True
            Exit Sub
        End If

        ' limpia los datagrigview
        Me.dgvINCONSISTENCIAS.DataSource = New DataTable

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbPROCESO.Value = 0
        pbPROCESO.Maximum = Me.dgvCAMPOS.RowCount * Me.dgvDATOS.RowCount
        Timer1.Enabled = True

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("Campo", GetType(String)))
        dt1.Columns.Add(New DataColumn("Inconsistencia", GetType(String)))

        ' crea la tabla
        dt_INCONSISTENCIA = New DataTable
        dt_DATOS = New DataTable
        dt_TABLA = New DataTable
        dt_CAMPOS = New DataTable

        dt_DATOS = Me.dgvDATOS.DataSource
        dt_TABLA = Me.dgvTABLAS.DataSource
        dt_CAMPOS = Me.dgvCAMPOS.DataSource

        ' declara la variable
        Dim k As Integer = 0

        For k = 0 To dt_CAMPOS.Rows.Count - 1

            ' instancia la clase
            Dim objdatos11 As New cla_CAMPOS
            Dim tblcampos11 As New DataTable

            tblcampos11 = objdatos11.fun_Buscar_CAMPOS_Y_TABLAS_Y_PROCEDIMIENTO_MANT_CAMPOS(Me.cboCAMPPROC1.SelectedValue, dt_TABLA.Rows(0).Item("CAMPTABL"), dt_CAMPOS.Rows(k).Item("CAMPCODI"))

            ' verifica los registros
            If tblcampos11.Rows.Count > 0 Then

                ' declara las variables
                Dim stCAMPPROC As String = Trim(tblcampos11.Rows(0).Item("CAMPPROC"))
                Dim stCAMPTABL As String = Trim(tblcampos11.Rows(0).Item("CAMPTABL"))
                Dim stCAMPCODI As String = Trim(tblcampos11.Rows(0).Item("CAMPCODI"))
                Dim boCAMPLLPR As Boolean = tblcampos11.Rows(0).Item("CAMPLLPR")
                Dim boCAMPREQU As Boolean = tblcampos11.Rows(0).Item("CAMPREQU")
                Dim stCAMPTIDA As String = Trim(tblcampos11.Rows(0).Item("CAMPTIDA"))
                Dim inCAMPLONG As Integer = tblcampos11.Rows(0).Item("CAMPLONG")
                Dim boCAMPCOND As Boolean = tblcampos11.Rows(0).Item("CAMPCOND")
                Dim boCAMPMANT As Boolean = tblcampos11.Rows(0).Item("CAMPMANT")
                Dim stCAMPTAMA As String = Trim(tblcampos11.Rows(0).Item("CAMPTAMA"))
                Dim boCAMPSIST As Boolean = tblcampos11.Rows(0).Item("CAMPSIST")
                Dim stCAMPTASI As String = Trim(tblcampos11.Rows(0).Item("CAMPTASI"))
                Dim stCAMPLLMA As String = Trim(tblcampos11.Rows(0).Item("CAMPLLMA"))
                Dim stCAMPLLSI As String = Trim(tblcampos11.Rows(0).Item("CAMPLLSI"))

                ' declaro la variable
                Dim j As Integer = 0

                For j = 0 To dt_DATOS.Rows.Count - 1

                    ' validaciones
                    If boCAMPREQU = True Then
                        If Trim(dt_DATOS.Rows(j).Item(k).ToString) = "" Or Trim(dt_DATOS.Rows(j).Item(k).ToString) Is Nothing Then

                            dr1 = dt1.NewRow()

                            dr1("Campo") = Me.dgvDATOS.Columns(k).HeaderText
                            dr1("Inconsistencia") = "Campo en blanco " & "Nro. registro: " & j + 1

                            dt1.Rows.Add(dr1)

                        Else
                            Dim inTamano As Integer = CInt(dt_DATOS.Rows(j).Item(k).ToString.Length)
                            Dim stDato As String = CStr(Trim(dt_DATOS.Rows(j).Item(k).ToString))

                            If inTamano > inCAMPLONG Then

                                dr1 = dt1.NewRow()

                                dr1("Campo") = Me.dgvDATOS.Columns(k).HeaderText
                                dr1("Inconsistencia") = "Campo supera la longitud " & "Nro. registro: " & j + 1 & " campo: " & dt_DATOS.Rows(j).Item(k)

                                dt1.Rows.Add(dr1)

                            End If

                        End If
                    End If

                    ' validaciones
                    If stCAMPTIDA = "N" Then
                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_DATOS.Rows(j).Item(k).ToString)) = False Then

                            dr1 = dt1.NewRow()

                            dr1("Campo") = Me.dgvDATOS.Columns(k).HeaderText
                            dr1("Inconsistencia") = "Campo no es numérico " & "Nro. registro: " & j + 1 & " campo: " & dt_DATOS.Rows(j).Item(k)

                            dt1.Rows.Add(dr1)

                        Else
                            If CInt(dt_DATOS.Rows(j).Item(k).ToString.Length) > inCAMPLONG Then

                                dr1 = dt1.NewRow()

                                dr1("Campo") = Me.dgvDATOS.Columns(k).HeaderText
                                dr1("Inconsistencia") = "Campo supera la longitud " & "Nro. registro: " & j + 1 & " campo: " & dt_DATOS.Rows(j).Item(k)

                                dt1.Rows.Add(dr1)

                            End If

                        End If

                    ElseIf stCAMPTIDA = "D" Then
                        If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_DATOS.Rows(j).Item(k).ToString)) = False Then

                            dr1 = dt1.NewRow()

                            dr1("Campo") = Me.dgvDATOS.Columns(k).HeaderText
                            dr1("Inconsistencia") = "Campo no es decimal " & "Nro. registro: " & j + 1 & " campo: " & dt_DATOS.Rows(j).Item(k)

                            dt1.Rows.Add(dr1)

                        Else
                            If CInt(dt_DATOS.Rows(j).Item(k).ToString.Length) > inCAMPLONG Then

                                dr1 = dt1.NewRow()

                                dr1("Campo") = Me.dgvDATOS.Columns(k).HeaderText
                                dr1("Inconsistencia") = "Campo supera la longitud " & "Nro. registro: " & j + 1 & " campo: " & dt_DATOS.Rows(j).Item(k)

                                dt1.Rows.Add(dr1)

                            End If

                        End If
                    End If

                    ' validaciones
                    If boCAMPMANT = True Then
                        Dim boInconsistencia As Boolean = fun_ConsultarTablaMantenimiento(stCAMPTAMA, stCAMPLLMA, dt_DATOS.Rows(j).Item(k))

                        If boInconsistencia = False Then

                            dr1 = dt1.NewRow()

                            dr1("Campo") = Me.dgvDATOS.Columns(k).HeaderText
                            dr1("Inconsistencia") = "Registro " & dt_DATOS.Rows(j).Item(k) & " no existe en la tabla " & stCAMPTAMA & " de mantenimiento. " & "Nro. registro: " & j + 1

                            dt1.Rows.Add(dr1)

                        End If
                    End If

                    ' validaciones
                    If boCAMPSIST = True Then
                        Dim boInconsistencia As Boolean = fun_ConsultarTablaSistemas(stCAMPTASI, stCAMPLLSI, dt_DATOS.Rows(j).Item(k))

                        If boInconsistencia = False Then

                            dr1 = dt1.NewRow()

                            dr1("Campo") = Me.dgvDATOS.Columns(k).HeaderText
                            dr1("Inconsistencia") = "Registro " & dt_DATOS.Rows(j).Item(k) & " no existe en la tabla " & stCAMPTAMA & " de sistema. " & "Nro. registro: " & j + 1

                            dt1.Rows.Add(dr1)

                        End If
                    End If

                Next

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            End If

        Next

        ' inicia la barra de progreso
        pbPROCESO.Value = 0

        ' Llena el datagrigview
        If dt1.Rows.Count > 0 Then
            TabControl1.SelectTab(TabPage2)
        End If

        Me.dgvINCONSISTENCIAS.DataSource = dt1
        pbPROCESO.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cboCAMPPROC2.Enabled = True
            Me.cboCAMPPROC3.Enabled = True

            Me.cmdGrabarDatos.Enabled = True
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Focus()
            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Me.cmdValidaDatos.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvDATOS.RowCount

    End Sub
    Private Sub pro_Guardar()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' Valores predeterminados ProgressBar
            inProceso = 0
            Me.pbPROCESO.Value = 0
            Me.pbPROCESO.Maximum = Me.dgvDATOS.RowCount
            Me.Timer1.Enabled = True

            ' Crea objeto de columnas y registros
            Dim dt2 As New DataTable
            Dim dr2 As DataRow

            ' Crea las columnas
            dt2.Columns.Add(New DataColumn("Campo", GetType(String)))
            dt2.Columns.Add(New DataColumn("Inconsistencia", GetType(String)))

            ' verifica las condicones
            If Me.chkRemplazarRegistros.Checked = True Or Me.chkRemplazarRegistros.Checked = False Then

                If Me.cboCAMPPROC2.Text = "" Then
                    MessageBox.Show("Se requiere seleccionar un procedimiento de eliminación", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.cmdGrabarDatos.Enabled = True
                    Exit Sub
                End If

                If Me.cboCAMPPROC3.Text = "" Then
                    MessageBox.Show("Se requiere seleccionar un procedimiento de consulta", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.cmdGrabarDatos.Enabled = True
                    Exit Sub
                End If

                ' declara las tablas
                dt_DATOS = New DataTable
                dt_CAMPOS = New DataTable
                dt_TABLA = New DataTable

                ' llena las tablas
                dt_DATOS = Me.dgvDATOS.DataSource
                dt_CAMPOS = Me.dgvCAMPOS.DataSource
                dt_TABLA = Me.dgvTABLAS.DataSource

                ' declara la variable 
                Dim i As Integer = 0

                ' recorre las filas de los registros importados
                For i = 0 To dt_DATOS.Rows.Count - 1

                    ' instancia la clase
                    Dim objdatos11 As New cla_CAMPOS
                    Dim tbldatos11 As New DataTable

                    tbldatos11 = objdatos11.fun_Consultar_CAMPOS_Y_TABLAS_X_PROCEDIMIENTO_MANT_CAMPOS(Me.cboCAMPPROC2.SelectedValue, Me.dt_TABLA.Rows(0).Item("CAMPTABL"))

                    ' instancia la clase
                    Dim objdatos13 As New cla_CAMPOS
                    Dim tbldatos13 As New DataTable

                    tbldatos13 = objdatos13.fun_Consultar_CAMPOS_Y_TABLAS_X_PROCEDIMIENTO_MANT_CAMPOS(Me.cboCAMPPROC3.SelectedValue, Me.dt_TABLA.Rows(0).Item("CAMPTABL"))

                    ' instancia la clase
                    Dim objdatos12 As New cla_CAMPOS
                    Dim tbldatos12 As New DataTable

                    tbldatos12 = objdatos12.fun_Consultar_CAMPOS_Y_TABLAS_X_PROCEDIMIENTO_MANT_CAMPOS(Me.cboCAMPPROC1.SelectedValue, Me.dt_TABLA.Rows(0).Item("CAMPTABL"))

                    ' *** PROCEDIMIENTO ELIMINAR ***

                    ' verifica los registros
                    If tbldatos11.Rows.Count > 0 And tbldatos12.Rows.Count > 0 And tbldatos13.Rows.Count > 0 Then

                        ' declaro la variable
                        Dim stInstruccionEliminar As String = ""

                        ' declara la verible
                        Dim k As Integer = 0

                        ' recorre los campos con propiedades
                        For k = 0 To tbldatos11.Rows.Count - 1

                            If tbldatos11.Rows(k).Item("CAMPCOND") = True Then

                                Dim stNombreCampo As String = Trim(tbldatos11.Rows(k).Item("CAMPCODI").ToString)

                                ' declaro la variable
                                Dim j As Integer = 0

                                ' recorre las columnas de la registros importados
                                For j = 0 To Me.dgvDATOS.Columns.Count - 1

                                    If Trim(stNombreCampo) = Me.dgvDATOS.Columns(j).HeaderText Then

                                        ' concatena la instrucción eliminar o consultar
                                        stInstruccionEliminar += stNombreCampo & " = " & " '" & Trim(dt_DATOS.Rows(i).Item(j)) & "' "

                                        ' declara la variable
                                        Dim inCantidad As Integer = tbldatos11.Rows.Count

                                        If inCantidad > (k + 1) Then
                                            stInstruccionEliminar += " and "
                                        End If

                                    End If

                                Next

                            End If

                        Next

                        ' *** PROCEDIMIENTO CONSULTAR ***

                        ' declaro la variable
                        Dim stInstruccionConsultar As String = ""

                        ' declara la verible
                        Dim kkk As Integer = 0

                        ' recorre los campos con propiedades
                        For kkk = 0 To tbldatos13.Rows.Count - 1

                            If tbldatos13.Rows(kkk).Item("CAMPCOND") = True Then

                                Dim stNombreCampo As String = Trim(tbldatos13.Rows(kkk).Item("CAMPCODI").ToString)

                                ' declaro la variable
                                Dim jjj As Integer = 0

                                ' recorre las columnas de la registros importados
                                For jjj = 0 To Me.dgvDATOS.Columns.Count - 1

                                    If Trim(stNombreCampo) = Me.dgvDATOS.Columns(jjj).HeaderText Then

                                        ' concatena la instrucción eliminar o consultar
                                        stInstruccionConsultar += stNombreCampo & " = " & " '" & Trim(dt_DATOS.Rows(i).Item(jjj)) & "' "

                                        ' declara la variable
                                        Dim inCantidad As Integer = tbldatos13.Rows.Count

                                        If inCantidad > (kkk + 1) Then
                                            stInstruccionConsultar += " and "
                                        End If

                                    End If

                                Next

                            End If

                        Next

                        ' *** PROCEDIMIENTO INSERTAR ***

                        ' declaro la variable
                        Dim stInstruccionNombreCampoInsertar As String = ""
                        Dim stInstruccionValorCampoInsertar As String = ""

                        ' declara la verible
                        Dim kk As Integer = 0

                        ' recorre los campos con propiedades
                        For kk = 0 To tbldatos12.Rows.Count - 1

                            Dim stNombreCampo As String = Trim(tbldatos12.Rows(kk).Item("CAMPCODI").ToString)

                            ' declaro la variable
                            Dim jj As Integer = 0

                            ' recorre las columnas de la registros importados
                            For jj = 0 To Me.dgvDATOS.Columns.Count - 1

                                If Trim(stNombreCampo) = Me.dgvDATOS.Columns(jj).HeaderText Then

                                    ' concatena la instrucción insertar
                                    stInstruccionNombreCampoInsertar += Trim(stNombreCampo)

                                    ' concatena la instrucción insertar
                                    stInstruccionValorCampoInsertar += "'" & Trim(dt_DATOS.Rows(i).Item(jj)) & "'"

                                    ' declara la variable
                                    Dim inCantidad As Integer = tbldatos12.Rows.Count

                                    If inCantidad > (kk + 1) Then
                                        stInstruccionNombreCampoInsertar += " , "
                                        stInstruccionValorCampoInsertar += " , "
                                    End If

                                End If

                            Next

                        Next

                        ' procesa el registro
                        If fun_Consultar(Me.dt_TABLA.Rows(0).Item("CAMPTABL"), stInstruccionConsultar) = True Then
                            If fun_Eliminar(Me.dt_TABLA.Rows(0).Item("CAMPTABL"), stInstruccionEliminar) = True Then
                                If fun_Insertar(Me.dt_TABLA.Rows(0).Item("CAMPTABL"), stInstruccionNombreCampoInsertar, stInstruccionValorCampoInsertar) = True Then
                                    'dr2 = dt2.NewRow()

                                    'dr2("Campo") = stInstruccionNombreCampoInsertar & " , " & stInstruccionValorCampoInsertar
                                    'dr2("Inconsistencia") = "Se inserto correctamente el registro " & "Nro. registro: " & i + 1

                                    'dt2.Rows.Add(dr2)
                                Else
                                    dr2 = dt2.NewRow()

                                    dr2("Campo") = stInstruccionNombreCampoInsertar & " , " & stInstruccionValorCampoInsertar
                                    dr2("Inconsistencia") = "NO se inserto el registro " & "Nro. registro: " & i + 1

                                    dt2.Rows.Add(dr2)
                                End If
                            Else
                                dr2 = dt2.NewRow()

                                dr2("Campo") = stInstruccionNombreCampoInsertar & " , " & stInstruccionValorCampoInsertar
                                dr2("Inconsistencia") = "NO se elimino el registro ya que esta relacionado con otra tabla " & "Nro. registro: " & i + 1

                                dt2.Rows.Add(dr2)
                            End If
                        Else
                            If fun_Insertar(Me.dt_TABLA.Rows(0).Item("CAMPTABL"), stInstruccionNombreCampoInsertar, stInstruccionValorCampoInsertar) = True Then
                                'dr2 = dt2.NewRow()

                                'dr2("Campo") = stInstruccionNombreCampoInsertar & " , " & stInstruccionValorCampoInsertar
                                'dr2("Inconsistencia") = "Se inserto correctamente el registro " & "Nro. registro: " & i + 1

                                'dt2.Rows.Add(dr2)
                            Else
                                dr2 = dt2.NewRow()

                                dr2("Campo") = stInstruccionNombreCampoInsertar & " , " & stInstruccionValorCampoInsertar
                                dr2("Inconsistencia") = "NO se elimino el registro ya que esta relacionado con otra tabla " & "Nro. registro: " & i + 1

                                dt2.Rows.Add(dr2)
                            End If

                        End If

                    Else
                        MessageBox.Show("Se requiere la creación de campos de un procedimiento", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    Me.pbPROCESO.Value = inProceso

                Next

            End If

            ' Llena el datagrigview
            Me.pbPROCESO.Value = 0

            Me.dgvINCONSISTENCIAS.DataSource = dt2

            If Me.dgvINCONSISTENCIAS.RowCount > 0 Then
                MessageBox.Show("Proceso de guardado terminado con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                TabControl1.SelectTab(TabPage2)
            Else
                MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabControl1.SelectTab(TabPage1)
            End If

            Me.cmdGrabarDatos.Enabled = False
            Me.chkRemplazarRegistros.Enabled = False
            Me.cmdValidaDatos.Enabled = False

            Me.cboCAMPPROC2.DataSource = New DataTable
            Me.cboCAMPPROC3.DataSource = New DataTable

            Me.cboCAMPPROC2.Enabled = False
            Me.cboCAMPPROC3.Enabled = False

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvDATOS.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConsultarTablaCampos()

        Try
            If Not Me.cboCAMPPROC1.SelectedValue Is Nothing Then

                ' instancia la clase
                Dim obCAMPOS1 As New cla_CAMPOS
                Dim dtTABLAS1 As New DataTable

                dtTABLAS1 = obCAMPOS1.fun_Buscar_TABLAS_X_PROCEDIMIENTO_MANT_CAMPOS(Me.cboCAMPPROC1.SelectedValue)

                ' verifica la cantidad de registros
                If dtTABLAS1.Rows.Count > 0 Then

                    ' llena la tabla
                    Me.dgvTABLAS.DataSource = dtTABLAS1

                    Me.dgvTABLAS.Columns("CAMPTABL").HeaderText = "Tablas"
                    Me.dgvTABLAS.Columns("TABLDESC").HeaderText = "Descripción"

                    ' instancia la clase
                    Dim obCAMPOS2 As New cla_CAMPOS
                    Dim dtCAMPOS2 As New DataTable

                    dtCAMPOS2 = obCAMPOS2.fun_Buscar_CAMPOS_Y_TABLAS_X_PROCEDIMIENTO_MANT_CAMPOS(Me.cboCAMPPROC1.SelectedValue, Me.dgvTABLAS.CurrentRow.Cells("CAMPTABL").Value.ToString())

                    If dtCAMPOS2.Rows.Count > 0 Then

                        Me.dgvCAMPOS.DataSource = dtCAMPOS2

                        Me.dgvCAMPOS.Columns("CAMPCODI").HeaderText = "Campos"
                        Me.dgvCAMPOS.Columns("CAMPDESC").HeaderText = "Descripción"

                    End If
                Else
                    Me.dgvTABLAS.DataSource = New DataTable
                    Me.dgvCAMPOS.DataSource = New DataTable

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            ' declara variable
            inTotalRegistros = 0

            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False
            Me.chkRemplazarRegistros.Enabled = False

            Me.dgvDATOS.DataSource = New DataTable
            Me.dgvINCONSISTENCIAS.DataSource = New DataTable

            Me.cboCAMPPROC2.Enabled = False
            Me.cboCAMPPROC3.Enabled = False

            Me.cboCAMPPROC2.DataSource = New DataTable
            Me.cboCAMPPROC3.DataSource = New DataTable

            If Me.rbdExcel.Checked = True Then

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de excel 97 2003 (*.xls)|*.xls" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivo = Trim(oLeer.FileName)
                Me.lblRUTA.Text = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection _
                ("provider=Microsoft.Jet.OLEDB.4.0;" & _
                " Data Source='" & stRutaArchivo & "'; " & _
                 "Extended Properties=Excel 8.0;")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    'MyConnection.Open()

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)
                    Me.dgvDATOS.DataSource = DtSet.Tables(0)

                    MyConnection.Close()

                Else
                    stNombreLibro = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")
                End If

            ElseIf Me.rbdAccess.Checked = True Then

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.mdb)|*.mdb" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivo = Trim(oLeer.FileName)
                Me.lblRUTA.Text = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivo & "'")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la tabla de access", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvDATOS.DataSource = DtSet.Tables(0)

                    MyConnection.Close()

                Else
                    stNombreLibro = InputBox("Ingrese el nombre de la tabla de access", "Mensaje")
                End If

            End If


            ' verifica que exista registros
            If Me.dgvDATOS.RowCount > 0 Then
                Me.cmdValidaDatos.Enabled = True
                inTotalRegistros = Me.dgvDATOS.RowCount
            Else
                Me.cmdValidaDatos.Enabled = False
            End If

            TabControl1.SelectTab(TabPage1)

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvDATOS.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click
        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False
            Me.chkRemplazarRegistros.Enabled = False

            If Trim(stRutaArchivo) <> "" And Me.dgvDATOS.RowCount > 0 Then

                pro_Validar()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click

        Try
            If Me.dgvINCONSISTENCIAS.RowCount = 0 Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_Guardar()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            ' exporta ficha predial
            If Me.dgvDATOS.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel

                If Me.rbdDatosImportados.Checked = True Then
                    oExp.DataTableToExcel(CType(Me.dgvDATOS.DataSource, DataTable))
                ElseIf Me.rbdInconsistencias.Checked = True Then
                    oExp.DataTableToExcel(CType(Me.dgvINCONSISTENCIAS.DataSource, DataTable))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click

        Try
            If Me.dgvDATOS.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else

                If dgvDATOS.RowCount > 0 Then

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

                            With dgvDATOS
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
        Me.strBARRESTA.Items(0).Text = "Importar datos"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmdAbrirArchivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdAbrirArchivo.AccessibleDescription
    End Sub
    Private Sub cmdValidaDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdValidaDatos.AccessibleDescription
    End Sub
    Private Sub cmdGrabarDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdGrabarDatos.AccessibleDescription
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
    Private Sub dgvFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDATOS.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvDATOS.AccessibleDescription
    End Sub
    Private Sub dgvFIREINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.strBARRESTA.Items(0).Text = dgvINCONSISTENCIAS.AccessibleDescription
    End Sub

#End Region

#Region "Click"

    Private Sub cboCAMPPROC1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPPROC1.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_INSERTAR_Descripcion(Me.cboCAMPPROC1, Me.cboCAMPPROC1.SelectedIndex)
    End Sub
    Private Sub cboCAMPPROC2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPPROC2.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_ELIMINAR_Descripcion(Me.cboCAMPPROC2, Me.cboCAMPPROC2.SelectedIndex)
    End Sub
    Private Sub cboCAMPPROC3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCAMPPROC3.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_CONSULTAR_Descripcion(Me.cboCAMPPROC3, Me.cboCAMPPROC3.SelectedIndex)
    End Sub
    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        If Me.cboCAMPPROC1.Text = "" Then
            mod_MENSAJE.Se_Requiere_Realizar_Una_Seleccion()
        Else
            pro_ConsultarTablaCampos()
        End If
    End Sub

#End Region

#Region "CellValueChanged"

    Private Sub dgvTABLAS_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTABLAS.CellValueChanged, dgvCAMPOS.CellValueChanged

        If Me.dgvTABLAS.RowCount > 0 And Me.dgvCAMPOS.RowCount > 0 Then
            Me.cmdAbrirArchivo.Enabled = True
        Else
            Me.cmdAbrirArchivo.Enabled = False
        End If
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkRemplazarRegistros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRemplazarRegistros.CheckedChanged
        If Me.chkRemplazarRegistros.Checked = True Then
            Me.cboCAMPPROC2.Enabled = True
            Me.cboCAMPPROC3.Enabled = True
        Else
            Me.cboCAMPPROC2.DataSource = New DataTable
            Me.cboCAMPPROC3.DataSource = New DataTable
            Me.cboCAMPPROC2.Enabled = False
            Me.cboCAMPPROC3.Enabled = False
        End If
    End Sub

#End Region

#End Region

End Class