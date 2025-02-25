Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_excel_LINDEROS

    '=======================================================================
    '*** FORMULARIO IMPORTAR EXCEL INFORMACIÓN DE LINDEROS FICHA PREDIAL ***
    '=======================================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_excel_LINDEROS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_excel_LINDEROS
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
    Dim dt_CONSULTA As New DataTable
    Dim dt_FPCELIST As New DataTable

    ' otros procesos
    Dim stRutaArchivo As String
    Dim stSeparador As String
    Dim inTotalRegistros As Integer
    Dim stRESOLUCION As String
    Dim inProceso As Integer

    ' variable contador de registros totales
    Dim a As Integer

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro(ByVal inFIPRNUFI As Integer) As Integer

        Try
            Dim inFPLISECU As Integer = 0

            Dim objdatos5 As New cla_FIPRLIND
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL(CInt(inFIPRNUFI))

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

                inFPLISECU += 1
            End If

            Return inFPLISECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.dgvFIPRLIST.DataSource = New DataTable

        Me.lblRUTA.Text = ""
        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        Me.cmdValidaDatos.Enabled = False
        Me.cmdGrabarDatos.Enabled = False
        Me.lblFecha2.Visible = False

        Me.strBARRESTA.Items(2).Text = "Registro : 0"


    End Sub
    Private Sub pro_ValidarInformacion()

        ' limpia los datagrigview
        Me.dgvFIPRINCO.DataSource = New DataTable

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbPROCESO.Value = 0
        pbPROCESO.Maximum = inTotalRegistros + 1
        Timer1.Enabled = True

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Norte_1", GetType(String)))
        dt1.Columns.Add(New DataColumn("Norte_2", GetType(String)))
        dt1.Columns.Add(New DataColumn("Norte_3", GetType(String)))
        dt1.Columns.Add(New DataColumn("Norte_4", GetType(String)))
        dt1.Columns.Add(New DataColumn("Oriente_1", GetType(String)))
        dt1.Columns.Add(New DataColumn("Oriente_2", GetType(String)))
        dt1.Columns.Add(New DataColumn("Oriente_3", GetType(String)))
        dt1.Columns.Add(New DataColumn("Oriente_4", GetType(String)))
        dt1.Columns.Add(New DataColumn("Sur_1", GetType(String)))
        dt1.Columns.Add(New DataColumn("Sur_2", GetType(String)))
        dt1.Columns.Add(New DataColumn("Sur_3", GetType(String)))
        dt1.Columns.Add(New DataColumn("Sur_4", GetType(String)))
        dt1.Columns.Add(New DataColumn("Occidente_1", GetType(String)))
        dt1.Columns.Add(New DataColumn("Occidente_2", GetType(String)))
        dt1.Columns.Add(New DataColumn("Occidente_3", GetType(String)))
        dt1.Columns.Add(New DataColumn("Occidente_4", GetType(String)))
        dt1.Columns.Add(New DataColumn("Zenit_1", GetType(String)))
        dt1.Columns.Add(New DataColumn("Zenit_2", GetType(String)))
        dt1.Columns.Add(New DataColumn("Zenit_3", GetType(String)))
        dt1.Columns.Add(New DataColumn("Zenit_4", GetType(String)))
        dt1.Columns.Add(New DataColumn("Nadir_1", GetType(String)))
        dt1.Columns.Add(New DataColumn("Nadir_2", GetType(String)))
        dt1.Columns.Add(New DataColumn("Nadir_3", GetType(String)))
        dt1.Columns.Add(New DataColumn("Nadir_4", GetType(String)))
        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_FPCELIST = New DataTable

        ' carga la tabla
        dt_FPCELIST = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_FPCELIST.Rows.Count - 1

            ' verifica que el campo numero de ficha este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(0).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Norte_1") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Norte_2") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Norte_3") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Norte_4") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Oriente_1") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Oriente_2") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Oriente_3") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Oriente_4") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Sur_1") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Sur_2") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Sur_3") = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                dr1("Sur_4") = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                dr1("Occidente_1") = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                dr1("Occidente_2") = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                dr1("Occidente_3") = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                dr1("Occidente_4") = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                dr1("Zenit_1") = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                dr1("Zenit_2") = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                dr1("Zenit_3") = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                dr1("Zenit_4") = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                dr1("Nadir_1") = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                dr1("Nadir_2") = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                dr1("Nadir_3") = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                dr1("Nadir_4") = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)
                dr1("Descripcion") = "El campo nro de ficha esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FPCELIST.Rows(i).Item(0).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                    dr1("Norte_1") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                    dr1("Norte_2") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                    dr1("Norte_3") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                    dr1("Norte_4") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                    dr1("Oriente_1") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                    dr1("Oriente_2") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                    dr1("Oriente_3") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                    dr1("Oriente_4") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                    dr1("Sur_1") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                    dr1("Sur_2") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                    dr1("Sur_3") = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                    dr1("Sur_4") = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                    dr1("Occidente_1") = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                    dr1("Occidente_2") = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                    dr1("Occidente_3") = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                    dr1("Occidente_4") = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                    dr1("Zenit_1") = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                    dr1("Zenit_2") = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                    dr1("Zenit_3") = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                    dr1("Zenit_4") = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                    dr1("Nadir_1") = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                    dr1("Nadir_2") = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                    dr1("Nadir_3") = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                    dr1("Nadir_4") = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)
                    dr1("Descripcion") = "El campo nro de ficha no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo norte_1 este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(1).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Norte_1") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Norte_2") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Norte_3") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Norte_4") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Oriente_1") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Oriente_2") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Oriente_3") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Oriente_4") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Sur_1") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Sur_2") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Sur_3") = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                dr1("Sur_4") = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                dr1("Occidente_1") = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                dr1("Occidente_2") = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                dr1("Occidente_3") = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                dr1("Occidente_4") = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                dr1("Zenit_1") = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                dr1("Zenit_2") = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                dr1("Zenit_3") = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                dr1("Zenit_4") = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                dr1("Nadir_1") = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                dr1("Nadir_2") = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                dr1("Nadir_3") = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                dr1("Nadir_4") = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)
                dr1("Descripcion") = "El campo Norte_1 esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo oriente_1 este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(5).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Norte_1") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Norte_2") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Norte_3") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Norte_4") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Oriente_1") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Oriente_2") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Oriente_3") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Oriente_4") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Sur_1") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Sur_2") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Sur_3") = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                dr1("Sur_4") = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                dr1("Occidente_1") = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                dr1("Occidente_2") = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                dr1("Occidente_3") = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                dr1("Occidente_4") = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                dr1("Zenit_1") = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                dr1("Zenit_2") = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                dr1("Zenit_3") = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                dr1("Zenit_4") = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                dr1("Nadir_1") = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                dr1("Nadir_2") = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                dr1("Nadir_3") = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                dr1("Nadir_4") = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)
                dr1("Descripcion") = "El campo Oriente_1 esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Sur_1 este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(9).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Norte_1") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Norte_2") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Norte_3") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Norte_4") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Oriente_1") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Oriente_2") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Oriente_3") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Oriente_4") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Sur_1") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Sur_2") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Sur_3") = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                dr1("Sur_4") = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                dr1("Occidente_1") = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                dr1("Occidente_2") = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                dr1("Occidente_3") = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                dr1("Occidente_4") = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                dr1("Zenit_1") = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                dr1("Zenit_2") = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                dr1("Zenit_3") = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                dr1("Zenit_4") = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                dr1("Nadir_1") = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                dr1("Nadir_2") = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                dr1("Nadir_3") = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                dr1("Nadir_4") = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)
                dr1("Descripcion") = "El campo Sur_1 esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Occidente_1 este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(13).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Norte_1") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Norte_2") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Norte_3") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Norte_4") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Oriente_1") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Oriente_2") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Oriente_3") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Oriente_4") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Sur_1") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Sur_2") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Sur_3") = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                dr1("Sur_4") = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                dr1("Occidente_1") = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                dr1("Occidente_2") = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                dr1("Occidente_3") = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                dr1("Occidente_4") = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                dr1("Zenit_1") = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                dr1("Zenit_2") = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                dr1("Zenit_3") = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                dr1("Zenit_4") = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                dr1("Nadir_1") = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                dr1("Nadir_2") = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                dr1("Nadir_3") = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                dr1("Nadir_4") = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)
                dr1("Descripcion") = "El campo Occidente_1 esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Zenit_1 este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(17).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Norte_1") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Norte_2") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Norte_3") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Norte_4") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Oriente_1") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Oriente_2") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Oriente_3") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Oriente_4") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Sur_1") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Sur_2") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Sur_3") = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                dr1("Sur_4") = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                dr1("Occidente_1") = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                dr1("Occidente_2") = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                dr1("Occidente_3") = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                dr1("Occidente_4") = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                dr1("Zenit_1") = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                dr1("Zenit_2") = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                dr1("Zenit_3") = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                dr1("Zenit_4") = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                dr1("Nadir_1") = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                dr1("Nadir_2") = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                dr1("Nadir_3") = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                dr1("Nadir_4") = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)
                dr1("Descripcion") = "El campo Zenit_1 esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Nadir_1 este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(21).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Norte_1") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Norte_2") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Norte_3") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Norte_4") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Oriente_1") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Oriente_2") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Oriente_3") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Oriente_4") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Sur_1") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Sur_2") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Sur_3") = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                dr1("Sur_4") = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                dr1("Occidente_1") = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                dr1("Occidente_2") = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                dr1("Occidente_3") = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                dr1("Occidente_4") = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                dr1("Zenit_1") = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                dr1("Zenit_2") = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                dr1("Zenit_3") = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                dr1("Zenit_4") = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                dr1("Nadir_1") = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                dr1("Nadir_2") = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                dr1("Nadir_3") = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                dr1("Nadir_4") = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)
                dr1("Descripcion") = "El campo Nadir_1 esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' Incrementa la barra
            inProceso = inProceso + 1
            pbPROCESO.Value = inProceso

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage2)
        Me.dgvFIPRINCO.DataSource = dt1
        pbPROCESO.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cmdGrabarDatos.Enabled = True
            Me.lblFecha2.Visible = True
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Focus()
            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Me.cmdValidaDatos.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

    End Sub
    Private Sub pro_GuardarInformacion()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' Valores predeterminados ProgressBar
            inProceso = 0
            Me.pbPROCESO.Value = 0
            Me.pbPROCESO.Maximum = inTotalRegistros + 1
            Me.Timer1.Enabled = True

            ' crea la tabla
            dt_FPCELIST = New DataTable

            ' declara las variables
            Dim stFPLINUFI As String = ""
            Dim stNORTE_1 As String = ""
            Dim stNORTE_2 As String = ""
            Dim stNORTE_3 As String = ""
            Dim stNORTE_4 As String = ""
            Dim stORIENTE_1 As String = ""
            Dim stORIENTE_2 As String = ""
            Dim stORIENTE_3 As String = ""
            Dim stORIENTE_4 As String = ""
            Dim stSUR_1 As String = ""
            Dim stSUR_2 As String = ""
            Dim stSUR_3 As String = ""
            Dim stSUR_4 As String = ""
            Dim stOCCIDENTE_1 As String = ""
            Dim stOCCIDENTE_2 As String = ""
            Dim stOCCIDENTE_3 As String = ""
            Dim stOCCIDENTE_4 As String = ""
            Dim stZENIT_1 As String = ""
            Dim stZENIT_2 As String = ""
            Dim stZENIT_3 As String = ""
            Dim stZENIT_4 As String = ""
            Dim stNARIR_1 As String = ""
            Dim stNARIR_2 As String = ""
            Dim stNARIR_3 As String = ""
            Dim stNARIR_4 As String = ""

            ' carga la tabla
            dt_FPCELIST = Me.dgvFIPRLIST.DataSource

            ' declaro la variable
            Dim inContadorNorte_1 As Integer = 0
            Dim inContadorNorte_2 As Integer = 0
            Dim inContadorNorte_3 As Integer = 0
            Dim inContadorNorte_4 As Integer = 0
            Dim inContadorOriente_1 As Integer = 0
            Dim inContadorOriente_2 As Integer = 0
            Dim inContadorOriente_3 As Integer = 0
            Dim inContadorOriente_4 As Integer = 0
            Dim inContadorSur_1 As Integer = 0
            Dim inContadorSur_2 As Integer = 0
            Dim inContadorSur_3 As Integer = 0
            Dim inContadorSur_4 As Integer = 0
            Dim inContadorOccidente_1 As Integer = 0
            Dim inContadorOccidente_2 As Integer = 0
            Dim inContadorOccidente_3 As Integer = 0
            Dim inContadorOccidente_4 As Integer = 0
            Dim inContadorZenit_1 As Integer = 0
            Dim inContadorZenit_2 As Integer = 0
            Dim inContadorZenit_3 As Integer = 0
            Dim inContadorZenit_4 As Integer = 0
            Dim inContadorNadir_1 As Integer = 0
            Dim inContadorNadir_2 As Integer = 0
            Dim inContadorNadir_3 As Integer = 0
            Dim inContadorNadir_4 As Integer = 0

            ' declara la variable
            Dim j As Integer = 0

            ' elimina registros de linderos
            If Me.chkEliminarRegistros.Checked = True Then

                For j = 0 To dt_FPCELIST.Rows.Count - 1

                    stFPLINUFI = Trim(dt_FPCELIST.Rows(j).Item(0).ToString)

                    ' instancia la clase
                    Dim obFIPRLIND_1 As New cla_FIPRLIND

                    If obFIPRLIND_1.fun_Eliminar_NUFI_FIPRLIND(stFPLINUFI) = True Then

                    End If

                Next

            End If

            ' declara la variable
            Dim i As Integer = 0

            ' recorre la table
            For i = 0 To dt_FPCELIST.Rows.Count - 1

                ' llena las variables
                stFPLINUFI = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                stNORTE_1 = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                stNORTE_2 = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                stNORTE_3 = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                stNORTE_4 = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                stORIENTE_1 = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                stORIENTE_2 = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                stORIENTE_3 = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                stORIENTE_4 = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                stSUR_1 = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                stSUR_2 = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                stSUR_3 = Trim(dt_FPCELIST.Rows(i).Item(11).ToString)
                stSUR_4 = Trim(dt_FPCELIST.Rows(i).Item(12).ToString)
                stOCCIDENTE_1 = Trim(dt_FPCELIST.Rows(i).Item(13).ToString)
                stOCCIDENTE_2 = Trim(dt_FPCELIST.Rows(i).Item(14).ToString)
                stOCCIDENTE_3 = Trim(dt_FPCELIST.Rows(i).Item(15).ToString)
                stOCCIDENTE_4 = Trim(dt_FPCELIST.Rows(i).Item(16).ToString)
                stZENIT_1 = Trim(dt_FPCELIST.Rows(i).Item(17).ToString)
                stZENIT_2 = Trim(dt_FPCELIST.Rows(i).Item(18).ToString)
                stZENIT_3 = Trim(dt_FPCELIST.Rows(i).Item(19).ToString)
                stZENIT_4 = Trim(dt_FPCELIST.Rows(i).Item(20).ToString)
                stNARIR_1 = Trim(dt_FPCELIST.Rows(i).Item(21).ToString)
                stNARIR_2 = Trim(dt_FPCELIST.Rows(i).Item(22).ToString)
                stNARIR_3 = Trim(dt_FPCELIST.Rows(i).Item(23).ToString)
                stNARIR_4 = Trim(dt_FPCELIST.Rows(i).Item(24).ToString)

                ' verifica el dato
                Dim boFIPRNUFI As Boolean = fun_Verificar_Dato_Numerico_Evento_Validated(stFPLINUFI)

                ' valida el dato
                If boFIPRNUFI = True Then

                    ' Instancia la clase
                    Dim objdatos As New cla_FICHPRED
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(stFPLINUFI)

                    If tbl.Rows.Count > 0 Then

                        ' declaro la variable
                        Dim stFIPRDEPA As String = fun_Formato_Mascara_2_String(CStr(Trim(tbl.Rows(0).Item("FIPRDEPA").ToString)))
                        Dim stFIPRMUNI As String = fun_Formato_Mascara_3_String(CStr(Trim(tbl.Rows(0).Item("FIPRMUNI").ToString)))
                        Dim stFIPRCORR As String = fun_Formato_Mascara_3_String(CStr(Trim(tbl.Rows(0).Item("FIPRCORR").ToString)))
                        Dim stFIPRBARR As String = fun_Formato_Mascara_3_String(CStr(Trim(tbl.Rows(0).Item("FIPRBARR").ToString)))
                        Dim stFIPRMANZ As String = fun_Formato_Mascara_4_String(CStr(Trim(tbl.Rows(0).Item("FIPRMANZ").ToString)))
                        Dim stFIPRPRED As String = fun_Formato_Mascara_5_String(CStr(Trim(tbl.Rows(0).Item("FIPRPRED").ToString)))
                        Dim stFIPRTIRE As String = CStr(Trim(tbl.Rows(0).Item("FIPRTIRE").ToString))
                        Dim stFIPRCLSE As String = CStr(Trim(tbl.Rows(0).Item("FIPRCLSE").ToString))
                        Dim stFIPRVIGE As String = CStr(Trim(tbl.Rows(0).Item("FIPRVIGE").ToString))
                        Dim stFIPRRESO As String = CStr(Trim(tbl.Rows(0).Item("FIPRRESO").ToString))
                        Dim stFIPRNURE As String = CStr(Trim(tbl.Rows(0).Item("FIPRVIGE").ToString))
                        Dim stFIPRESTA As String = CStr(Trim(tbl.Rows(0).Item("FIPRESTA").ToString))

                        Dim stCEDUCAST As String = stFIPRMUNI & stFIPRCLSE & stFIPRCORR & stFIPRBARR & stFIPRMANZ & stFIPRPRED
                        Dim stPUNTCARD As String = ""
                        Dim stCOLIDANTE As String = ""

                        Dim stPUNTCARD_NORTE As String = "N"
                        Dim stPUNTCARD_ESTE As String = "E"
                        Dim stPUNTCARD_SUR As String = "S"
                        Dim stPUNTCARD_OESTE As String = "O"
                        Dim stPUNTCARD_NADIR As String = "NA"
                        Dim stPUNTCARD_ZENIT As String = "ZE"

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stNORTE_1) <> "" Then
                            stPUNTCARD = stPUNTCARD_NORTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNORTE_1)) = True Then

                                Dim inLONGITUD As Integer = Trim(stNORTE_1).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stNORTE_1)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stNORTE_1)

                                Else
                                    stCOLIDANTE = Trim(stNORTE_1)

                                End If

                            Else
                                stCOLIDANTE = Trim(stNORTE_1).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorNorte_1 += 1
                            End If

                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stNORTE_2) <> "" Then
                            stPUNTCARD = stPUNTCARD_NORTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNORTE_2)) = True Then

                                Dim inLONGITUD As Integer = Trim(stNORTE_2).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stNORTE_2)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stNORTE_2)

                                Else
                                    stCOLIDANTE = Trim(stNORTE_2)

                                End If

                            Else
                                stCOLIDANTE = Trim(stNORTE_2).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorNorte_2 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stNORTE_3) <> "" Then
                            stPUNTCARD = stPUNTCARD_NORTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNORTE_3)) = True Then

                                Dim inLONGITUD As Integer = Trim(stNORTE_3).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stNORTE_3)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stNORTE_3)

                                Else
                                    stCOLIDANTE = Trim(stNORTE_3)

                                End If

                            Else
                                stCOLIDANTE = Trim(stNORTE_3).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorNorte_3 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stNORTE_4) <> "" Then
                            stPUNTCARD = stPUNTCARD_NORTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNORTE_4)) = True Then

                                Dim inLONGITUD As Integer = Trim(stNORTE_4).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stNORTE_4)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stNORTE_4)

                                Else
                                    stCOLIDANTE = Trim(stNORTE_4)

                                End If

                            Else
                                stCOLIDANTE = Trim(stNORTE_4).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorNorte_4 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stORIENTE_1) <> "" Then
                            stPUNTCARD = stPUNTCARD_ESTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stORIENTE_1)) = True Then

                                Dim inLONGITUD As Integer = Trim(stORIENTE_1).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stORIENTE_1)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stORIENTE_1)

                                Else
                                    stCOLIDANTE = Trim(stORIENTE_1)

                                End If

                            Else
                                stCOLIDANTE = Trim(stORIENTE_1).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorOriente_1 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stORIENTE_2) <> "" Then
                            stPUNTCARD = stPUNTCARD_ESTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stORIENTE_2)) = True Then

                                Dim inLONGITUD As Integer = Trim(stORIENTE_2).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stORIENTE_2)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stORIENTE_2)

                                Else
                                    stCOLIDANTE = Trim(stORIENTE_2)

                                End If

                            Else
                                stCOLIDANTE = Trim(stORIENTE_2).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorOriente_2 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stORIENTE_3) <> "" Then
                            stPUNTCARD = stPUNTCARD_ESTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stORIENTE_3)) = True Then

                                Dim inLONGITUD As Integer = Trim(stORIENTE_3).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stORIENTE_3)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stORIENTE_3)

                                Else
                                    stCOLIDANTE = Trim(stORIENTE_3)

                                End If

                            Else
                                stCOLIDANTE = Trim(stORIENTE_3).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorOriente_3 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stORIENTE_4) <> "" Then
                            stPUNTCARD = stPUNTCARD_ESTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stORIENTE_4)) = True Then

                                Dim inLONGITUD As Integer = Trim(stORIENTE_4).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stORIENTE_4)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stORIENTE_4)

                                Else
                                    stCOLIDANTE = Trim(stORIENTE_4)

                                End If

                            Else
                                stCOLIDANTE = Trim(stORIENTE_4).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorOriente_4 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stSUR_1) <> "" Then
                            stPUNTCARD = stPUNTCARD_SUR

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stSUR_1)) = True Then

                                Dim inLONGITUD As Integer = Trim(stSUR_1).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stSUR_1)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stSUR_1)

                                Else
                                    stCOLIDANTE = Trim(stSUR_1)

                                End If

                            Else
                                stCOLIDANTE = Trim(stSUR_1).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorSur_1 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stSUR_2) <> "" Then
                            stPUNTCARD = stPUNTCARD_SUR

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stSUR_2)) = True Then

                                Dim inLONGITUD As Integer = Trim(stSUR_2).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stSUR_2)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stSUR_2)

                                Else
                                    stCOLIDANTE = Trim(stSUR_2)

                                End If

                            Else
                                stCOLIDANTE = Trim(stSUR_2).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorSur_2 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stSUR_3) <> "" Then
                            stPUNTCARD = stPUNTCARD_SUR

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stSUR_3)) = True Then

                                Dim inLONGITUD As Integer = Trim(stSUR_3).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stSUR_3)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stSUR_3)

                                Else
                                    stCOLIDANTE = Trim(stSUR_3)

                                End If

                            Else
                                stCOLIDANTE = Trim(stSUR_3).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorSur_3 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stSUR_4) <> "" Then
                            stPUNTCARD = stPUNTCARD_SUR

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stSUR_4)) = True Then

                                Dim inLONGITUD As Integer = Trim(stSUR_4).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stSUR_4)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stSUR_4)

                                Else
                                    stCOLIDANTE = Trim(stSUR_4)

                                End If

                            Else
                                stCOLIDANTE = Trim(stSUR_4).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorSur_4 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stOCCIDENTE_1) <> "" Then
                            stPUNTCARD = stPUNTCARD_OESTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stOCCIDENTE_1)) = True Then

                                Dim inLONGITUD As Integer = Trim(stOCCIDENTE_1).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stOCCIDENTE_1)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stOCCIDENTE_1)

                                Else
                                    stCOLIDANTE = Trim(stOCCIDENTE_1)

                                End If

                            Else
                                stCOLIDANTE = Trim(stOCCIDENTE_1).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorOccidente_1 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stOCCIDENTE_2) <> "" Then
                            stPUNTCARD = stPUNTCARD_OESTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stOCCIDENTE_2)) = True Then

                                Dim inLONGITUD As Integer = Trim(stOCCIDENTE_2).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stOCCIDENTE_2)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stOCCIDENTE_2)

                                Else
                                    stCOLIDANTE = Trim(stOCCIDENTE_2)

                                End If

                            Else
                                stCOLIDANTE = Trim(stOCCIDENTE_2).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorOccidente_2 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stOCCIDENTE_3) <> "" Then
                            stPUNTCARD = stPUNTCARD_OESTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stOCCIDENTE_3)) = True Then

                                Dim inLONGITUD As Integer = Trim(stOCCIDENTE_3).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stOCCIDENTE_3)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stOCCIDENTE_3)

                                Else
                                    stCOLIDANTE = Trim(stOCCIDENTE_3)

                                End If

                            Else
                                stCOLIDANTE = Trim(stOCCIDENTE_3).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorOccidente_3 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stOCCIDENTE_4) <> "" Then
                            stPUNTCARD = stPUNTCARD_OESTE

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stOCCIDENTE_4)) = True Then

                                Dim inLONGITUD As Integer = Trim(stOCCIDENTE_4).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stOCCIDENTE_4)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stOCCIDENTE_4)

                                Else
                                    stCOLIDANTE = Trim(stOCCIDENTE_4)

                                End If

                            Else
                                stCOLIDANTE = Trim(stOCCIDENTE_4).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorOccidente_4 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stZENIT_1) <> "" Then
                            stPUNTCARD = stPUNTCARD_ZENIT

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stZENIT_1)) = True Then

                                Dim inLONGITUD As Integer = Trim(stZENIT_1).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stZENIT_1)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stZENIT_1)

                                Else
                                    stCOLIDANTE = Trim(stZENIT_1)

                                End If

                            Else
                                stCOLIDANTE = Trim(stZENIT_1).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorZenit_1 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stZENIT_2) <> "" Then
                            stPUNTCARD = stPUNTCARD_ZENIT

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stZENIT_2)) = True Then

                                Dim inLONGITUD As Integer = Trim(stZENIT_2).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stZENIT_2)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stZENIT_2)

                                Else
                                    stCOLIDANTE = Trim(stZENIT_2)

                                End If

                            Else
                                stCOLIDANTE = Trim(stZENIT_2).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorZenit_2 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stZENIT_3) <> "" Then
                            stPUNTCARD = stPUNTCARD_ZENIT

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stZENIT_3)) = True Then

                                Dim inLONGITUD As Integer = Trim(stZENIT_3).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stZENIT_3)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stZENIT_3)

                                Else
                                    stCOLIDANTE = Trim(stZENIT_3)

                                End If

                            Else
                                stCOLIDANTE = Trim(stZENIT_3).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorZenit_3 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stZENIT_4) <> "" Then
                            stPUNTCARD = stPUNTCARD_ZENIT

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stZENIT_4)) = True Then

                                Dim inLONGITUD As Integer = Trim(stZENIT_4).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stZENIT_4)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stZENIT_4)

                                Else
                                    stCOLIDANTE = Trim(stZENIT_4)

                                End If

                            Else
                                stCOLIDANTE = Trim(stZENIT_4).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorZenit_4 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stNARIR_1) <> "" Then
                            stPUNTCARD = stPUNTCARD_NADIR

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNARIR_1)) = True Then

                                Dim inLONGITUD As Integer = Trim(stNARIR_1).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stNARIR_1)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stNARIR_1)

                                Else
                                    stCOLIDANTE = Trim(stNARIR_1)

                                End If

                            Else
                                stCOLIDANTE = Trim(stNARIR_1).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorNadir_1 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stNARIR_2) <> "" Then
                            stPUNTCARD = stPUNTCARD_NADIR

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNARIR_2)) = True Then

                                Dim inLONGITUD As Integer = Trim(stNARIR_2).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stNARIR_2)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stNARIR_2)

                                Else
                                    stCOLIDANTE = Trim(stNARIR_2)

                                End If

                            Else
                                stCOLIDANTE = Trim(stNARIR_2).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorNadir_2 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stNARIR_3) <> "" Then
                            stPUNTCARD = stPUNTCARD_NADIR

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNARIR_3)) = True Then

                                Dim inLONGITUD As Integer = Trim(stNARIR_3).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stNARIR_3)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stNARIR_3)

                                Else
                                    stCOLIDANTE = Trim(stNARIR_3)

                                End If

                            Else
                                stCOLIDANTE = Trim(stNARIR_3).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorNadir_3 += 1
                            End If
                        End If

                        ' limpia las variables
                        stPUNTCARD = ""
                        stCOLIDANTE = ""

                        If Trim(stNARIR_4) <> "" Then
                            stPUNTCARD = stPUNTCARD_NADIR

                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNARIR_4)) = True Then

                                Dim inLONGITUD As Integer = Trim(stNARIR_4).ToString.Length

                                If inLONGITUD = 9 Then
                                    stCOLIDANTE = Trim(stCEDUCAST) & Trim(stNARIR_4)

                                ElseIf inLONGITUD = 28 Then
                                    stCOLIDANTE = Trim(stNARIR_4)

                                Else
                                    stCOLIDANTE = Trim(stNARIR_4)

                                End If

                            Else
                                stCOLIDANTE = Trim(stNARIR_4).ToString.ToUpper

                            End If

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPLINUFI))

                            ' instancia la clase
                            Dim obFIPRLIND As New cla_FIPRLIND

                            ' inserta el registro
                            If obFIPRLIND.fun_Insertar_FIPRLIND(CInt(stFPLINUFI), _
                                                                CStr(stPUNTCARD), _
                                                                CStr(stCOLIDANTE), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CInt(stFIPRTIRE), _
                                                                CInt(stFIPRCLSE), _
                                                                CInt(stFIPRVIGE), _
                                                                CInt(stFIPRRESO), _
                                                                CInt(inSECUENCIA), _
                                                                CInt(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then
                                inContadorNadir_4 += 1
                            End If
                        End If

                    End If

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                Me.pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            pbPROCESO.Value = 0

            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

            MessageBox.Show("Se actualizaron: " & inContadorNorte_1 & " Norte_1 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorNorte_2 & " Norte_2 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorNorte_3 & " Norte_3 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorNorte_4 & " Norte_4 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorOriente_1 & " Oriente_1 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorOriente_2 & " Oriente_2 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorOriente_3 & " Oriente_3 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorOriente_4 & " Oriente_4 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorSur_1 & " Sur_1 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorSur_2 & " Sur_2 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorSur_3 & " Sur_3 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorSur_4 & " Sur_4 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorOccidente_1 & " Occidente_1 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorOccidente_2 & " Occidente_2 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorOccidente_3 & " Occidente_3 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorOccidente_4 & " Occidente_4 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorZenit_1 & " Zenit_1 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorZenit_2 & " Zenit_2 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorZenit_3 & " Zenit_3 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorZenit_4 & " Zenit_4 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorNadir_1 & " Nadir_1 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorNadir_2 & " Nadir_2 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorNadir_3 & " Nadir_3 " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorNadir_4 & " Nadir_4 " & Chr(Keys.Enter), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Me.cmdGrabarDatos.Enabled = False
            Me.lblFecha2.Visible = False
            Me.cmdValidaDatos.Enabled = False

            Me.cmdAbrirArchivo.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ExportarPlano(ByVal dtl As DataTable)
        Try
            Me.dgvFIPRLIST.DataSource = dtl

            If dgvFIPRLIST.RowCount > 0 Then

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

                        With dgvFIPRLIST
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

#End Region

#Region "MENU"

    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            ' declara variable
            inTotalRegistros = 0

            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False

            pro_LimpiarCampos()

            Me.lblFecha2.Visible = False

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
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

                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                MyCommand.TableMappings.Add("Table", "TestTable")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                Me.dgvFIPRLIST.DataSource = DtSet.Tables(0)

                MyConnection.Close()

            Else
                stNombreLibro = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")
            End If

            ' verifica que exista registros
            If Me.dgvFIPRLIST.RowCount > 0 Then
                Me.cmdValidaDatos.Enabled = True
                inTotalRegistros = Me.dgvFIPRLIST.RowCount
            Else
                Me.cmdValidaDatos.Enabled = False
            End If

            TabControl1.SelectTab(TabPage1)

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click
        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False

            Me.lblFecha2.Visible = False

            If Trim(stRutaArchivo) <> "" And Me.dgvFIPRLIST.RowCount > 0 Then

                pro_ValidarInformacion()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click

        Try
            If Me.dgvFIPRINCO.RowCount = 0 Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_GuardarInformacion()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            ' exporta ficha predial
            If Me.dgvFIPRLIST.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvFIPRLIST.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click

        Try
            If Me.dgvFIPRLIST.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                pro_ExportarPlano(Me.dgvFIPRLIST.DataSource)
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
    Private Sub dgvFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRLIST.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvFIPRLIST.AccessibleDescription
    End Sub

#End Region

#End Region

End Class