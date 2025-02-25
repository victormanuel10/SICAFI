Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_excel_HISTAVAL

    '======================================================
    '*** FORMULARIO IMPORTAR EXCEL HISTORICO DE AVALUOS ***
    '======================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_excel_HISTAVAL
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_excel_HISTAVAL
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
    Dim dt_HISTAVAL As New DataTable

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
    Private Sub pro_ValidarHistoricoAvaluos()

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
        dt1.Columns.Add(New DataColumn("Vigencia", GetType(String)))
        dt1.Columns.Add(New DataColumn("Ficha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Area_Terreno_Privado", GetType(String)))
        dt1.Columns.Add(New DataColumn("Area_Terreno_Comun", GetType(String)))
        dt1.Columns.Add(New DataColumn("Area_Construccion_Privado", GetType(String)))
        dt1.Columns.Add(New DataColumn("Area_Construccion_Comun", GetType(String)))
        dt1.Columns.Add(New DataColumn("Valor_Terreno_Privado", GetType(String)))
        dt1.Columns.Add(New DataColumn("Valor_Terreno_Comun", GetType(String)))
        dt1.Columns.Add(New DataColumn("Valor_Construccion_Privado", GetType(String)))
        dt1.Columns.Add(New DataColumn("Valor_Construccion_Comun", GetType(String)))
        dt1.Columns.Add(New DataColumn("Avaluo_Catastral", GetType(String)))
        dt1.Columns.Add(New DataColumn("Inconsistencia", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_HISTAVAL = New DataTable

        ' carga la tabla
        dt_HISTAVAL = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_HISTAVAL.Rows.Count - 1

            ' verifica vigencia
            If Trim(dt_HISTAVAL.Rows(i).Item(0).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Vigencia esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Vigencia no es numerico"

                    dt1.Rows.Add(dr1)

                Else

                    Dim objdatos2 As New cla_VIGENCIA
                    Dim tbl As New DataTable

                    tbl = objdatos2.fun_Buscar_CODIGO_VIGENCIA(Trim(dt_HISTAVAL.Rows(i).Item(0).ToString))

                    If tbl.Rows.Count = 0 Then

                        dr1 = dt1.NewRow()

                        dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                        dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                        dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                        dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                        dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                        dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                        dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                        dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                        dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                        dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                        dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                        dr1("Inconsistencia") = "Vigencia no existe en el maestro"

                        dt1.Rows.Add(dr1)

                    End If

                End If

            End If

            ' verifica nro de ficha
            If Trim(dt_HISTAVAL.Rows(i).Item(1).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Ficha esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Ficha no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Area_Terreno_Privado
            If Trim(dt_HISTAVAL.Rows(i).Item(2).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Area_Terreno_Privado es vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Area_Terreno_Privado no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Area_Terreno_Comun
            If Trim(dt_HISTAVAL.Rows(i).Item(3).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Area_Terreno_Comun esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Area_Terreno_Comun no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Area_Construccion_Privado
            If Trim(dt_HISTAVAL.Rows(i).Item(4).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Area_Construccion_Privado esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Area_Construccion_Privado no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Area_Construccion_Comun
            If Trim(dt_HISTAVAL.Rows(i).Item(5).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Area_Construccion_Comun esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Area_Construccion_Comun no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Valor_Terreno_Privado
            If Trim(dt_HISTAVAL.Rows(i).Item(6).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Valor_Terreno_Privado esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Valor_Terreno_Privado no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Valor_Terreno_Comun
            If Trim(dt_HISTAVAL.Rows(i).Item(7).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Valor_Terreno_Comun esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Valor_Terreno_Comun no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Valor_Construccion_Privado
            If Trim(dt_HISTAVAL.Rows(i).Item(8).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Valor_Construccion_Privado esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Valor_Construccion_Privado no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Valor_Construccion_Comun
            If Trim(dt_HISTAVAL.Rows(i).Item(9).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Valor_Construccion_Comun esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Valor_Construccion_Comun no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica Avaluo_Catastral
            If Trim(dt_HISTAVAL.Rows(i).Item(10).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                dr1("Inconsistencia") = "Avaluo_Catastral esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Vigencia") = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                    dr1("Ficha") = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                    dr1("Area_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(2).ToString)
                    dr1("Area_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(3).ToString)
                    dr1("Area_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(4).ToString)
                    dr1("Area_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(5).ToString)
                    dr1("Valor_Terreno_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(6).ToString)
                    dr1("Valor_Terreno_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(7).ToString)
                    dr1("Valor_Construccion_Privado") = Trim(dt_HISTAVAL.Rows(i).Item(8).ToString)
                    dr1("Valor_Construccion_Comun") = Trim(dt_HISTAVAL.Rows(i).Item(9).ToString)
                    dr1("Avaluo_Catastral") = Trim(dt_HISTAVAL.Rows(i).Item(10).ToString)
                    dr1("Inconsistencia") = "Avaluo_Catastral no es numerico"

                    dt1.Rows.Add(dr1)

                End If

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
    Private Sub pro_GuardarHistoricoDeAvaluos()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbPROCESO.Value = 0
            pbPROCESO.Maximum = inTotalRegistros + 1
            Timer1.Enabled = True

            ' declara la variable
            Dim i As Integer = 0

            ' crea la tabla
            dt_HISTAVAL = New DataTable

            ' declara las variables
            Dim stRESOTIRE As String = ""
            Dim stRESONURE As String = ""
            Dim stRESOVIRE As String = ""

            Dim stHIAVVIGE As String = ""
            Dim stHIAVNUFI As String = ""
            Dim stHIAVATPR As String = ""
            Dim stHIAVATCO As String = ""
            Dim stHIAVACPR As String = ""
            Dim stHIAVACCO As String = ""
            Dim stHIAVVTPR As String = ""
            Dim stHIAVVTCO As String = ""
            Dim stHIAVVCPR As String = ""
            Dim stHIAVVCCO As String = ""
            Dim stHIAVAVCA As String = ""
            Dim stHIAVOBSE As String = "Avalúo importado."
            Dim stHIAVESTA As String = "ac"
            Dim inCantidad As Integer = 0

            ' carga la tabla
            dt_HISTAVAL = Me.dgvFIPRLIST.DataSource

            For i = 0 To dt_HISTAVAL.Rows.Count - 1

                stHIAVNUFI = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                stHIAVESTA = "ac"

                Dim boHIAVNUFI As Boolean = fun_Verificar_Dato_Numerico_Evento_Validated(stHIAVNUFI)

                If boHIAVNUFI = True Then

                    ' Instancia la clase
                    Dim objdatos As New cla_FICHPRED
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(stHIAVNUFI)

                    If tbl.Rows.Count > 0 Then

                        stRESOTIRE = Trim(tbl.Rows(0).Item("FIPRTIRE"))
                        stRESONURE = Trim(tbl.Rows(0).Item("FIPRRESO"))
                        stRESOVIRE = Trim(tbl.Rows(0).Item("FIPRVIGE"))

                        stHIAVVIGE = Trim(dt_HISTAVAL.Rows(i).Item(0).ToString)
                        stHIAVNUFI = Trim(dt_HISTAVAL.Rows(i).Item(1).ToString)
                        stHIAVATPR = CLng(Trim(dt_HISTAVAL.Rows(i).Item(2).ToString))
                        stHIAVATCO = CLng(Trim(dt_HISTAVAL.Rows(i).Item(3).ToString))
                        stHIAVACPR = CLng(Trim(dt_HISTAVAL.Rows(i).Item(4).ToString))
                        stHIAVACCO = CLng(Trim(dt_HISTAVAL.Rows(i).Item(5).ToString))
                        stHIAVVTPR = CLng(Trim(dt_HISTAVAL.Rows(i).Item(6).ToString))
                        stHIAVVTCO = CLng(Trim(dt_HISTAVAL.Rows(i).Item(7).ToString))
                        stHIAVVCPR = CLng(Trim(dt_HISTAVAL.Rows(i).Item(8).ToString))
                        stHIAVVCCO = CLng(Trim(dt_HISTAVAL.Rows(i).Item(9).ToString))
                        stHIAVAVCA = CLng(Trim(dt_HISTAVAL.Rows(i).Item(10).ToString))

                        Dim obHISTAVAL As New cla_HISTAVAL

                        obHISTAVAL.fun_Eliminar_NUFI_Y_VIGE_X_HISTAVAL(stHIAVNUFI, stHIAVVIGE)

                        If obHISTAVAL.fun_Insertar_HISTAVAL(stHIAVNUFI, stHIAVVIGE, stHIAVATPR, stHIAVATCO, stHIAVACPR, stHIAVACCO, stHIAVVTPR, stHIAVVTCO, stHIAVVCPR, stHIAVVCCO, stHIAVAVCA, stHIAVOBSE, stRESOTIRE, stRESONURE, stRESOVIRE, stHIAVESTA) = True Then
                            inCantidad += 1
                        End If

                    End If

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            pbPROCESO.Value = 0

            ' comando grabar datos
            MessageBox.Show("Proceso de guardado terminado correctamente. Registros: " & inCantidad, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

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

                pro_ValidarHistoricoAvaluos()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click

        Try
            If Me.dgvFIPRINCO.RowCount = 0 Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_GuardarHistoricoDeAvaluos()

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
    Private Sub dgvFIREINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.strBARRESTA.Items(0).Text = dgvFIPRINCO.AccessibleDescription
    End Sub

#End Region

#End Region

End Class