Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_CONSULTA_SQL

    '============================
    ' *** CONSULTA SQL SERVER ***
    '============================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

#End Region

#Region "VARIABLES"

    Dim Separador As String

    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_CONSULTA_SQL
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_CONSULTA_SQL
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

    Private Sub pro_EjecuarConsulta()

        Try
            ' apaga el boton
            Me.cmdEjecutar.Enabled = False

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
            ParametrosConsulta += Trim(Me.txtCODIGO.Text.ToString)

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

            ' llena el datagridview
            If dt.Rows.Count > 0 Then
                Me.dgvCONSULTA.DataSource = dt
                mod_MENSAJE.Proceso_Termino_Correctamente()
            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount.ToString

            ' ejecuta las propiedades
            Me.cmdEjecutar.Enabled = True
            Me.txtCODIGO.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecuarInsertar()

        ' apaga el boton
        Me.cmdEjecutar.Enabled = False

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
        ParametrosConsulta += Trim(Me.txtCODIGO.Text.ToString)

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

        mod_MENSAJE.Proceso_Termino_Correctamente()

        ' Numero de registros recuperados
        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount.ToString

        ' ejecuta las propiedades
        Me.cmdEjecutar.Enabled = True
        Me.txtCODIGO.Focus()

    End Sub
    Private Sub pro_EjecuarActualizar()

        Try
            ' apaga el boton
            Me.cmdEjecutar.Enabled = False

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
            ParametrosConsulta += Trim(Me.txtCODIGO.Text.ToString)

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oReader = oEjecutar.ExecuteReader

            Dim inCantidadRegistros As Integer = oReader.RecordsAffected

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

            mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & inCantidadRegistros

            ' ejecuta las propiedades
            Me.cmdEjecutar.Enabled = True
            Me.txtCODIGO.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecuarEliminar()

        Try
            ' apaga el boton
            Me.cmdEjecutar.Enabled = False

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
            ParametrosConsulta += Trim(Me.txtCODIGO.Text.ToString)

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oReader = oEjecutar.ExecuteReader

            Dim inCantidadRegistros As Integer = oReader.RecordsAffected

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

            mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & inCantidadRegistros

            ' ejecuta las propiedades
            Me.cmdEjecutar.Enabled = True
            Me.txtCODIGO.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCODIGO.Text = ""

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.cmdExportarExcel.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarExcel.Name)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEjecutar.Click

        Try
            ' selecciona el procedimiento
            If Me.rbdConsultar.Checked = True Then
                pro_EjecuarConsulta()

            ElseIf Me.rbdInsertar.Checked = True Then
                pro_EjecuarInsertar()

            ElseIf Me.rbdActualizar.Checked = True Then
                pro_EjecuarActualizar()

            ElseIf Me.rbdEliminar.Checked = True Then
                pro_EjecuarEliminar()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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
        txtCODIGO.Focus()
        Me.Close()
    End Sub
    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try

            Dim oLeer As New OpenFileDialog

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            Dim stRutaArchivo As String = Trim(oLeer.FileName)

            ' selecciona ficha predial
            If Trim(stRutaArchivo) <> "" Then

                ' almacena la linea
                Dim stContenidoLinea As String = ""

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                Do Until EOF(1)
                    stContenidoLinea += LineInput(1) & " " & Chr(13)
                Loop

                Me.txtCODIGO.Text = stContenidoLinea

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRestablecer.Click
        Me.cmdEjecutar.Enabled = True
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click

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

                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_CONSULTA_SQL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If vp_usuario <> "ADMINISTRADOR" Then

            Me.rbdActualizar.Visible = False
            Me.rbdInsertar.Visible = False
            Me.rbdEliminar.Visible = False

        End If

        pro_PermisoControlDeComandos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtCONDICION_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCODIGO.GotFocus
        strBARRESTA.Items(0).Text = txtCODIGO.AccessibleDescription
    End Sub
    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEjecutar.GotFocus
        strBARRESTA.Items(0).Text = cmdEjecutar.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub dgvCONSULTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        strBARRESTA.Items(0).Text = dgvCONSULTA.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub txtCONDICION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCODIGO.KeyDown

        If e.KeyCode = Keys.F8 Then
            cmdEjecutar.PerformClick()
        End If

    End Sub

#End Region

#Region "Click"

    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
    End Sub

#End Region

#End Region

  
End Class