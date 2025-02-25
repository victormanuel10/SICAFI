Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_excel_CEDUCATA

    '============================================
    '*** FORMULARIO IMPORTAR CEDULA CATASTRAL ***
    '============================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_excel_CEDUCATA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_excel_CEDUCATA
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
    Dim dt_PRANLIST As New DataTable

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

    Dim stNUMEFICH As String = ""
    Dim stMUNIACTU As String = ""
    Dim stCORRACTU As String = ""
    Dim stBARRACTU As String = ""
    Dim stMANZACTU As String = ""
    Dim stPREDACTU As String = ""
    Dim stEDIFACTU As String = ""
    Dim stUNPRACTU As String = ""
    Dim stCLSEACTU As String = ""
    Dim stMUNINUEV As String = ""
    Dim stCORRNUEV As String = ""
    Dim stBARRNUEV As String = ""
    Dim stMANZNUEV As String = ""
    Dim stPREDNUEV As String = ""
    Dim stEDIFNUEV As String = ""
    Dim stUNPRNUEV As String = ""
    Dim stCLSENUEV As String = ""
    Dim stCASUNUEV As String = ""

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
    Private Sub pro_ValidarCedulaCatastralEstructura1()

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
        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Corr_Actual", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Barr_Actual", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Manz_Accual", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Pred_Accual", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Edif_Actual", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Unid_Actual", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Sect_Actual", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Muni_Nuevo", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Corr_Nuevo", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Barr_Nuevo", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Manz_Nuevo", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Pred_Nuevo", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Edif_Nuevo", GetType(String)))
        'dt1.Columns.Add(New DataColumn("Unid_Nuevo", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_PRANLIST = New DataTable

        ' carga la tabla
        dt_PRANLIST = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_PRANLIST.Rows.Count - 1

            ' verifica que el campo numero de ficha este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(0).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(0).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(0).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo nro de ficha esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo municipio actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(1).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(1).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(1).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo municipio actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo corregimiento actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(2).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(2).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(2).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo corregimiento actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo barrio actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(3).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(3).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(3).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo barrio actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo manzana actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(4).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(4).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(4).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo manzana actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo predio actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(5).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(5).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(5).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo predio actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo edificio actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(6).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(6).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(6).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo edificio actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo unidad actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(7).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(7).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(7).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo unidad actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo sector actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(8).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(8).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(8).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo sector actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo municipio nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(9).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(9).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(9).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo municipio nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo corregimiento nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(10).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(10).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(10).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo corregimiento nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo barrio nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(11).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(11).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(11).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo barrio nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo manzana nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(12).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(12).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(12).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo manzana nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo predio nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(13).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(13).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(13).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo predio nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo edificio nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(14).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(14).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(14).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo edificio nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo unidad nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(15).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(15).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(15).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo unidad nuevo esta vacio o no es numerico"

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
    Private Sub pro_ValidarCedulaCatastralEstructura2()

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
        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_PRANLIST = New DataTable

        ' carga la tabla
        dt_PRANLIST = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_PRANLIST.Rows.Count - 1

            ' verifica que el campo municipio actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(0).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(0).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(0).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo municipio actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo corregimiento actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(1).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(1).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(1).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo corregimiento actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo barrio actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(2).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(2).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(2).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo barrio actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo manzana actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(3).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(3).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(3).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo manzana actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo predio actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(4).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(4).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(4).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo predio actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo edificio actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(5).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(5).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(5).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo edificio actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo unidad actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(6).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(6).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(6).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo unidad actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo sector actual este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(7).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(7).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(7).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo sector actual esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo municipio nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(8).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(8).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(8).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo municipio nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo corregimiento nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(9).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(9).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(9).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo corregimiento nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo barrio nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(10).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(10).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(10).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo barrio nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo manzana nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(11).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(11).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(11).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo manzana nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo predio nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(12).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(12).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(12).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo predio nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo edificio nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(13).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(13).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(13).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo edificio nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo unidad nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(14).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(14).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(14).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo unidad nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo sector nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(15).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(15).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(15).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo sector nuevo esta vacio o no es numerico"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo categoria de suelo nuevo este lleno
            If Trim(dt_PRANLIST.Rows(i).Item(16).ToString) = "" Or _
               Trim(dt_PRANLIST.Rows(i).Item(16).ToString) Is Nothing Or _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_PRANLIST.Rows(i).Item(16).ToString)) = False Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                dr1("Descripcion") = "El campo sector categoria esta vacio o no es numerico"

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
    Private Sub pro_GuardarDatosCedulaCatastralEstructura1()

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
            dt_PRANLIST = New DataTable

            ' limpia las variables
            stNUMEFICH = ""
            stMUNIACTU = ""
            stCORRACTU = ""
            stBARRACTU = ""
            stMANZACTU = ""
            stPREDACTU = ""
            stEDIFACTU = ""
            stUNPRACTU = ""
            stCLSEACTU = ""
            stMUNINUEV = ""
            stCORRNUEV = ""
            stBARRNUEV = ""
            stMANZNUEV = ""
            stPREDNUEV = ""
            stEDIFNUEV = ""
            stUNPRNUEV = ""

            ' carga la tabla
            dt_PRANLIST = Me.dgvFIPRLIST.DataSource

            For i = 0 To dt_PRANLIST.Rows.Count - 1

                ' almacena los datos en las variables 
                stNUMEFICH = Trim(dt_PRANLIST.Rows(i).Item(0).ToString)
                stMUNIACTU = Trim(dt_PRANLIST.Rows(i).Item(1).ToString)
                stCORRACTU = Trim(dt_PRANLIST.Rows(i).Item(2).ToString)
                stBARRACTU = Trim(dt_PRANLIST.Rows(i).Item(3).ToString)
                stMANZACTU = Trim(dt_PRANLIST.Rows(i).Item(4).ToString)
                stPREDACTU = Trim(dt_PRANLIST.Rows(i).Item(5).ToString)
                stEDIFACTU = Trim(dt_PRANLIST.Rows(i).Item(6).ToString)
                stUNPRACTU = Trim(dt_PRANLIST.Rows(i).Item(7).ToString)
                stCLSEACTU = Trim(dt_PRANLIST.Rows(i).Item(8).ToString)
                stMUNINUEV = Trim(dt_PRANLIST.Rows(i).Item(9).ToString)
                stCORRNUEV = Trim(dt_PRANLIST.Rows(i).Item(10).ToString)
                stBARRNUEV = Trim(dt_PRANLIST.Rows(i).Item(11).ToString)
                stMANZNUEV = Trim(dt_PRANLIST.Rows(i).Item(12).ToString)
                stPREDNUEV = Trim(dt_PRANLIST.Rows(i).Item(13).ToString)
                stEDIFNUEV = Trim(dt_PRANLIST.Rows(i).Item(14).ToString)
                stUNPRNUEV = Trim(dt_PRANLIST.Rows(i).Item(15).ToString)

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
                ParametrosConsulta += "FiprNufi "
                ParametrosConsulta += "From FichPred where "
                ParametrosConsulta += "FiprNufi = '" & stNUMEFICH & "' "

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

                    Dim objdatos22 As New cla_FICHPRED
                    Dim tbl22 As New DataTable

                    tbl22 = objdatos22.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(CInt(dt.Rows(0).Item("FiprNufi")))

                    If tbl22.Rows.Count > 0 Then

                        '======================================
                        ' actualiza la cedula catastral actual
                        '======================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion11 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion11 As String = oCadenaConexion11.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion11)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta11 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta11 += "update FICHPRED "
                        ParametrosConsulta11 += "set "
                        ParametrosConsulta11 += "FIPRCOAN = '" & CStr(fun_Formato_Mascara_2_Reales(stCORRACTU)) & "', "
                        ParametrosConsulta11 += "FIPRBAAN = '" & CStr(fun_Formato_Mascara_3_Reales(stBARRACTU)) & "', "
                        ParametrosConsulta11 += "FIPRMAAN = '" & CStr(fun_Formato_Mascara_3_Reales(stMANZACTU)) & "', "
                        ParametrosConsulta11 += "FIPRPRAN = '" & CStr(fun_Formato_Mascara_5_Reales(stPREDACTU)) & "', "
                        ParametrosConsulta11 += "FIPREDAN = '" & CStr(fun_Formato_Mascara_3_Reales(stEDIFACTU)) & "', "
                        ParametrosConsulta11 += "FIPRUPAN = '" & CStr(fun_Formato_Mascara_5_Reales(stUNPRACTU)) & "'  "
                        ParametrosConsulta11 += "where FIPRNUFI = '" & CInt(dt.Rows(0).Item("FiprNufi")) & "'"

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta11, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        '========================================
                        ' actualiza la cedula catastral anterior
                        '========================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion12 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion12 As String = oCadenaConexion12.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion12)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta12 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta12 += "update FICHPRED "
                        ParametrosConsulta12 += "set "
                        ParametrosConsulta12 += "FIPRCORR = '" & CStr(fun_Formato_Mascara_2_Reales(stCORRNUEV)) & "', "
                        ParametrosConsulta12 += "FIPRBARR = '" & CStr(fun_Formato_Mascara_3_Reales(stBARRNUEV)) & "', "
                        ParametrosConsulta12 += "FIPRMANZ = '" & CStr(fun_Formato_Mascara_3_Reales(stMANZNUEV)) & "', "
                        ParametrosConsulta12 += "FIPRPRED = '" & CStr(fun_Formato_Mascara_5_Reales(stPREDNUEV)) & "', "
                        ParametrosConsulta12 += "FIPREDIF = '" & CStr(fun_Formato_Mascara_3_Reales(stEDIFNUEV)) & "', "
                        ParametrosConsulta12 += "FIPRUNPR = '" & CStr(fun_Formato_Mascara_5_Reales(stUNPRNUEV)) & "'  "
                        ParametrosConsulta12 += "where FIPRNUFI = '" & CInt(dt.Rows(0).Item("FiprNufi")) & "'"

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta12, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing


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
            MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Me.cmdGrabarDatos.Enabled = False
            Me.lblFecha2.Visible = False
            Me.cmdValidaDatos.Enabled = False

            Me.cmdAbrirArchivo.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarDatosCedulaCatastralEstructura2()

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
            dt_PRANLIST = New DataTable

            ' limpia las variables
            stMUNIACTU = ""
            stCORRACTU = ""
            stBARRACTU = ""
            stMANZACTU = ""
            stPREDACTU = ""
            stEDIFACTU = ""
            stUNPRACTU = ""
            stCLSEACTU = ""
            stMUNINUEV = ""
            stCORRNUEV = ""
            stBARRNUEV = ""
            stMANZNUEV = ""
            stPREDNUEV = ""
            stEDIFNUEV = ""
            stUNPRNUEV = ""
            stCLSENUEV = ""
            stCASUNUEV = ""

            ' carga la tabla
            dt_PRANLIST = Me.dgvFIPRLIST.DataSource

            For i = 0 To dt_PRANLIST.Rows.Count - 1

                ' almacena los datos en las variables 
                stMUNIACTU = Trim(fun_Formato_Mascara_3_String(dt_PRANLIST.Rows(i).Item(0).ToString))
                stCORRACTU = Trim(fun_Formato_Mascara_2_String(dt_PRANLIST.Rows(i).Item(1).ToString))
                stBARRACTU = Trim(fun_Formato_Mascara_3_String(dt_PRANLIST.Rows(i).Item(2).ToString))
                stMANZACTU = Trim(fun_Formato_Mascara_3_String(dt_PRANLIST.Rows(i).Item(3).ToString))
                stPREDACTU = Trim(fun_Formato_Mascara_5_String(dt_PRANLIST.Rows(i).Item(4).ToString))
                stEDIFACTU = Trim(fun_Formato_Mascara_3_String(dt_PRANLIST.Rows(i).Item(5).ToString))
                stUNPRACTU = Trim(fun_Formato_Mascara_5_String(dt_PRANLIST.Rows(i).Item(6).ToString))
                stCLSEACTU = Trim(dt_PRANLIST.Rows(i).Item(7).ToString)
                stMUNINUEV = Trim(fun_Formato_Mascara_3_String(dt_PRANLIST.Rows(i).Item(8).ToString))
                stCORRNUEV = Trim(fun_Formato_Mascara_2_String(dt_PRANLIST.Rows(i).Item(9).ToString))
                stBARRNUEV = Trim(fun_Formato_Mascara_3_String(dt_PRANLIST.Rows(i).Item(10).ToString))
                stMANZNUEV = Trim(fun_Formato_Mascara_3_String(dt_PRANLIST.Rows(i).Item(11).ToString))
                stPREDNUEV = Trim(fun_Formato_Mascara_5_String(dt_PRANLIST.Rows(i).Item(12).ToString))
                stEDIFNUEV = Trim(fun_Formato_Mascara_3_String(dt_PRANLIST.Rows(i).Item(13).ToString))
                stUNPRNUEV = Trim(fun_Formato_Mascara_5_String(dt_PRANLIST.Rows(i).Item(14).ToString))
                stCLSENUEV = Trim(dt_PRANLIST.Rows(i).Item(15).ToString)
                stCASUNUEV = Trim(dt_PRANLIST.Rows(i).Item(16).ToString)

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
                ParametrosConsulta += "FiprNufi "
                ParametrosConsulta += "From FichPred where "
                ParametrosConsulta += "FiprMuni = '" & stMUNIACTU & "' and "
                ParametrosConsulta += "FiprCorr = '" & stCORRACTU & "' and "
                ParametrosConsulta += "FiprBarr = '" & stBARRACTU & "' and "
                ParametrosConsulta += "FiprManz = '" & stMANZACTU & "' and "
                ParametrosConsulta += "FiprPred = '" & stPREDACTU & "' and "
                ParametrosConsulta += "FiprEdif = '" & stEDIFACTU & "' and "
                ParametrosConsulta += "FiprUnpr = '" & stUNPRACTU & "' and "
                ParametrosConsulta += "FiprClse = '" & stCLSEACTU & "' "

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

                    Dim ii As Integer = 0

                    For ii = 0 To dt.Rows.Count - 1

                        Dim objdatos22 As New cla_FICHPRED
                        Dim tbl22 As New DataTable

                        tbl22 = objdatos22.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(CInt(dt.Rows(ii).Item("FiprNufi")))

                        If tbl22.Rows.Count > 0 Then

                            '======================================
                            ' actualiza la cedula catastral actual
                            '======================================

                            ' buscar cadena de conexion
                            Dim oCadenaConexion11 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion11 As String = oCadenaConexion11.fun_ConnectionString

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion11)

                            ' abre la conexion
                            oConexion.Open()

                            ' parametros de la consulta
                            Dim ParametrosConsulta11 As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta11 += "Update FICHPRED "
                            ParametrosConsulta11 += "Set "
                            ParametrosConsulta11 += "FIPRCOAN = '" & CStr(fun_Formato_Mascara_2_Reales(stCORRACTU)) & "', "
                            ParametrosConsulta11 += "FIPRBAAN = '" & CStr(fun_Formato_Mascara_3_Reales(stBARRACTU)) & "', "
                            ParametrosConsulta11 += "FIPRMAAN = '" & CStr(fun_Formato_Mascara_3_Reales(stMANZACTU)) & "', "
                            ParametrosConsulta11 += "FIPRPRAN = '" & CStr(fun_Formato_Mascara_5_Reales(stPREDACTU)) & "', "
                            ParametrosConsulta11 += "FIPREDAN = '" & CStr(fun_Formato_Mascara_3_Reales(stEDIFACTU)) & "', "
                            ParametrosConsulta11 += "FIPRUPAN = '" & CStr(fun_Formato_Mascara_5_Reales(stUNPRACTU)) & "', "
                            ParametrosConsulta11 += "FIPRCSAN = '" & CInt(stCLSEACTU) & "' "
                            ParametrosConsulta11 += "Where FIPRNUFI = '" & CInt(tbl22.Rows(0).Item("FiprNufi")) & "'"

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta11, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 0
                            oEjecutar.CommandType = CommandType.Text

                            oReader = oEjecutar.ExecuteReader

                            ' cierra la conexion
                            oConexion.Close()
                            oReader = Nothing

                            '========================================
                            ' actualiza la cedula catastral anterior
                            '========================================

                            ' buscar cadena de conexion
                            Dim oCadenaConexion12 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion12 As String = oCadenaConexion12.fun_ConnectionString

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion12)

                            ' abre la conexion
                            oConexion.Open()

                            ' parametros de la consulta
                            Dim ParametrosConsulta12 As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta12 += "update FICHPRED "
                            ParametrosConsulta12 += "set "
                            ParametrosConsulta12 += "FIPRCORR = '" & CStr(fun_Formato_Mascara_2_Reales(stCORRNUEV)) & "', "
                            ParametrosConsulta12 += "FIPRBARR = '" & CStr(fun_Formato_Mascara_3_Reales(stBARRNUEV)) & "', "
                            ParametrosConsulta12 += "FIPRMANZ = '" & CStr(fun_Formato_Mascara_3_Reales(stMANZNUEV)) & "', "
                            ParametrosConsulta12 += "FIPRPRED = '" & CStr(fun_Formato_Mascara_5_Reales(stPREDNUEV)) & "', "
                            ParametrosConsulta12 += "FIPREDIF = '" & CStr(fun_Formato_Mascara_3_Reales(stEDIFNUEV)) & "', "
                            ParametrosConsulta12 += "FIPRUNPR = '" & CStr(fun_Formato_Mascara_5_Reales(stUNPRNUEV)) & "', "
                            ParametrosConsulta12 += "FIPRCLSE = '" & CInt(stCLSENUEV) & "', "
                            ParametrosConsulta12 += "FIPRCASU = '" & CInt(stCASUNUEV) & "'  "
                            ParametrosConsulta12 += "where FIPRNUFI = '" & CInt(tbl22.Rows(0).Item("FiprNufi")) & "'"

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta12, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 0
                            oEjecutar.CommandType = CommandType.Text

                            oReader = oEjecutar.ExecuteReader

                            ' cierra la conexion
                            oConexion.Close()
                            oReader = Nothing

                        End If

                    Next

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            pbPROCESO.Value = 0

            ' comando grabar datos
            MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

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

                If Me.rbdEstructura1.Checked = True Then
                    pro_ValidarCedulaCatastralEstructura1()

                ElseIf Me.rbdEstructura2.Checked = True Then
                    pro_ValidarCedulaCatastralEstructura2()

                End If


            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click

        Try
            If Me.dgvFIPRINCO.RowCount = 0 Then
                If Trim(stRutaArchivo) <> "" Then

                    If Me.rbdEstructura1.Checked = True Then
                        pro_GuardarDatosCedulaCatastralEstructura1()

                    ElseIf Me.rbdEstructura2.Checked = True Then
                        pro_GuardarDatosCedulaCatastralEstructura2()

                    End If

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