Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_excel_CARTOGRAFIA

    '====================================================================
    '*** FORMULARIO IMPORTAR INFORMACIÓN DE CARTOGRAFIA FICHA PREDIAL ***
    '====================================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_excel_CARTOGRAFIA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_excel_CARTOGRAFIA
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
            Dim inFPCASECU As Integer = 0

            Dim objdatos5 As New cla_FIPRCART
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCART_X_FICHA_PREDIAL(CInt(inFIPRNUFI))

            If tbl10.Rows.Count = 0 Then
                inFPCASECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("FPCASECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("FPCASECU"))

                    If NroMayor > Posicion Then
                        inFPCASECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inFPCASECU = Posicion
                    End If
                Next

                inFPCASECU += 1
            End If

            Return inFPCASECU

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
        dt1.Columns.Add(New DataColumn("Pk_Predio", GetType(String)))
        dt1.Columns.Add(New DataColumn("Plancha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Ventana", GetType(String)))
        dt1.Columns.Add(New DataColumn("Escala_Grafica", GetType(String)))
        dt1.Columns.Add(New DataColumn("Vigencia_Grafica", GetType(String)))
        dt1.Columns.Add(New DataColumn("Vuelo", GetType(String)))
        dt1.Columns.Add(New DataColumn("Faja", GetType(String)))
        dt1.Columns.Add(New DataColumn("Foto", GetType(String)))
        dt1.Columns.Add(New DataColumn("Vigencia_Aerofotografica", GetType(String)))
        dt1.Columns.Add(New DataColumn("Ampliacion", GetType(String)))
        dt1.Columns.Add(New DataColumn("Escala_Aerofotografica", GetType(String)))
        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_FPCELIST = New DataTable

        ' carga la tabla
        dt_FPCELIST = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_FPCELIST.Rows.Count - 1

            ' verifica que el campo numero de pk_predio
            If Trim(dt_FPCELIST.Rows(i).Item(0).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Descripcion") = "El campo pk_predio esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FPCELIST.Rows(i).Item(0).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                    dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                    dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                    dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                    dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                    dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                    dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                    dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                    dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                    dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                    dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                    dr1("Descripcion") = "El campo pk_predio no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo plancha
            If Trim(dt_FPCELIST.Rows(i).Item(1).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Descripcion") = "El campo Plancha esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Escala_Grafica
            If Trim(dt_FPCELIST.Rows(i).Item(3).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Descripcion") = "El campo Escala_Grafica esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Vigencia_Grafica
            If Trim(dt_FPCELIST.Rows(i).Item(4).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Descripcion") = "El campo Vigencia_Grafica esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Vuelo
            'If Trim(dt_FPCELIST.Rows(i).Item(5).ToString) = "" Then

            '    dr1 = dt1.NewRow()

            '    dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
            '    dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
            '    dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
            '    dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
            '    dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
            '    dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
            '    dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
            '    dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
            '    dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
            '    dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
            '    dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
            '    dr1("Descripcion") = "El campo Vuelo esta vacio"

            '    dt1.Rows.Add(dr1)

            'End If

            ' verifica que el campo Faja
            'If Trim(dt_FPCELIST.Rows(i).Item(6).ToString) = "" Then

            '    dr1 = dt1.NewRow()

            '    dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
            '    dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
            '    dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
            '    dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
            '    dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
            '    dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
            '    dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
            '    dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
            '    dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
            '    dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
            '    dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
            '    dr1("Descripcion") = "El campo Faja esta vacio"

            '    dt1.Rows.Add(dr1)

            'End If

            ' verifica que el campo Foto
            If Trim(dt_FPCELIST.Rows(i).Item(7).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Descripcion") = "El campo Foto esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Vigencia_Aerofotografica
            If Trim(dt_FPCELIST.Rows(i).Item(8).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Descripcion") = "El campo Vigencia_Aerofotografica esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Ampliacion
            'If Trim(dt_FPCELIST.Rows(i).Item(9).ToString) = "" Then

            '    dr1 = dt1.NewRow()

            '    dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
            '    dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
            '    dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
            '    dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
            '    dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
            '    dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
            '    dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
            '    dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
            '    dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
            '    dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
            '    dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
            '    dr1("Descripcion") = "El campo Ampliacion esta vacio"

            '    dt1.Rows.Add(dr1)

            'End If

            ' verifica que el campo Escala_Aerofotografica
            If Trim(dt_FPCELIST.Rows(i).Item(10).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Pk_Predio") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Plancha") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Ventana") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Escala_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Vigencia_Grafica") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Vuelo") = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                dr1("Faja") = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                dr1("Foto") = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                dr1("Vigencia_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                dr1("Ampliacion") = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                dr1("Escala_Aerofotografica") = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)
                dr1("Descripcion") = "El campo Escala_Aerofotografica esta vacio"

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

            ' declaro las variables
            Dim stPK_PREDIO As String = ""
            Dim stPLANCHA As String = ""
            Dim stVENTANA As String = ""
            Dim stESCALA_GRAFICA As String = ""
            Dim stVIGENCIA_GRAFICA As String = ""
            Dim stVUELO As String = ""
            Dim stFAJA As String = ""
            Dim stFOTO As String = ""
            Dim stVIGENCIA_AEROFOTOGRAFICA As String = ""
            Dim stAMPLIACION As String = ""
            Dim stESCALA_AEROFOTOGRAFICA As String = ""

            ' declaro las variables
            Dim stMUNICIPIO As String = ""
            Dim stSECTOR As String = ""
            Dim stCORREGIMIENTO As String = ""
            Dim stBARRIO As String = ""
            Dim stMANZANA As String = ""
            Dim stPREDIO As String = ""
            Dim stTIPO_FICHA As String = ""

            ' carga la tabla
            dt_FPCELIST = Me.dgvFIPRLIST.DataSource

            ' declara la variable
            Dim j As Integer = 0

            ' elimina registros de linderos
            If Me.chkEliminarRegistros.Checked = True Then

                For j = 0 To dt_FPCELIST.Rows.Count - 1

                    stPK_PREDIO = Trim(dt_FPCELIST.Rows(j).Item(0).ToString)

                    If Trim(stPK_PREDIO.ToString.Length) = 19 Then

                        ' declaro las variables
                        stMUNICIPIO = fun_Formato_Mascara_3_String(Trim(stPK_PREDIO.ToString.Substring(0, 3)))
                        stSECTOR = Trim(stPK_PREDIO.ToString.Substring(3, 1))
                        stCORREGIMIENTO = fun_Formato_Mascara_2_String(Trim(stPK_PREDIO.ToString.Substring(4, 3)))
                        stBARRIO = fun_Formato_Mascara_3_String(Trim(stPK_PREDIO.ToString.Substring(7, 3)))
                        stMANZANA = fun_Formato_Mascara_3_String(Trim(stPK_PREDIO.ToString.Substring(10, 4)))
                        stPREDIO = fun_Formato_Mascara_5_String(Trim(stPK_PREDIO.ToString.Substring(14, 5)))

                        ' instancia la clase
                        Dim obFICHPRED As New cla_FICHPRED
                        Dim dtFICHPRED As New DataTable

                        dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stMUNICIPIO, stSECTOR, stCORREGIMIENTO, stBARRIO, stMANZANA, stPREDIO)

                        If dtFICHPRED.Rows.Count > 0 Then

                            ' declara la variable
                            Dim i1 As Integer = 0

                            For i1 = 0 To dtFICHPRED.Rows.Count - 1

                                ' declara la variable
                                Dim stFPCANUFI As String = CStr(dtFICHPRED.Rows(i1).Item("FIPRNUFI").ToString)

                                ' instancia la clase
                                Dim obFIPRCART_1 As New cla_FIPRCART

                                obFIPRCART_1.fun_Eliminar_NUFI_FIPRCART(stFPCANUFI)

                            Next

                        End If

                    End If

                Next

            End If

            ' declara la variable
            Dim i As Integer = 0

            ' recorre la table
            For i = 0 To dt_FPCELIST.Rows.Count - 1

                ' llena las variables
                stPK_PREDIO = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)

                stMUNICIPIO = fun_Formato_Mascara_3_String(Trim(stPK_PREDIO.ToString.Substring(0, 3)))
                stSECTOR = Trim(stPK_PREDIO.ToString.Substring(3, 1))
                stCORREGIMIENTO = fun_Formato_Mascara_2_String(Trim(stPK_PREDIO.ToString.Substring(4, 3)))
                stBARRIO = fun_Formato_Mascara_3_String(Trim(stPK_PREDIO.ToString.Substring(7, 3)))
                stMANZANA = fun_Formato_Mascara_3_String(Trim(stPK_PREDIO.ToString.Substring(10, 4)))
                stPREDIO = fun_Formato_Mascara_5_String(Trim(stPK_PREDIO.ToString.Substring(14, 5)))

                stPLANCHA = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                stVENTANA = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                stESCALA_GRAFICA = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                stVIGENCIA_GRAFICA = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                stVUELO = Trim(dt_FPCELIST.Rows(i).Item(5).ToString)
                stFAJA = Trim(dt_FPCELIST.Rows(i).Item(6).ToString)
                stFOTO = Trim(dt_FPCELIST.Rows(i).Item(7).ToString)
                stVIGENCIA_AEROFOTOGRAFICA = Trim(dt_FPCELIST.Rows(i).Item(8).ToString)
                stAMPLIACION = Trim(dt_FPCELIST.Rows(i).Item(9).ToString)
                stESCALA_AEROFOTOGRAFICA = Trim(dt_FPCELIST.Rows(i).Item(10).ToString)

                ' instancia la clase
                Dim obFICHPRED_1 As New cla_FICHPRED
                Dim dtFICHPRED_1 As New DataTable

                dtFICHPRED_1 = obFICHPRED_1.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stMUNICIPIO, stSECTOR, stCORREGIMIENTO, stBARRIO, stMANZANA, stPREDIO)

                If dtFICHPRED_1.Rows.Count > 0 Then

                    ' declara la variabla
                    Dim ii As Integer = 0

                    For ii = 0 To dtFICHPRED_1.Rows.Count - 1

                        ' declara la variable
                        Dim stFPCANUFI As String = CStr(dtFICHPRED_1.Rows(ii).Item("FIPRNUFI").ToString)

                        ' Instancia la clase
                        Dim objdatos As New cla_FICHPRED
                        Dim tbl As New DataTable

                        tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(stFPCANUFI)

                        If tbl.Rows.Count > 0 Then

                            ' declaro la variable
                            Dim stFIPRDEPA As String = fun_Formato_Mascara_2_String(CStr(Trim(tbl.Rows(0).Item("FIPRDEPA").ToString)))
                            Dim stFIPRMUNI As String = fun_Formato_Mascara_3_String(CStr(Trim(tbl.Rows(0).Item("FIPRMUNI").ToString)))
                            Dim stFIPRTIRE As String = CStr(Trim(tbl.Rows(0).Item("FIPRTIRE").ToString))
                            Dim stFIPRCLSE As String = CStr(Trim(tbl.Rows(0).Item("FIPRCLSE").ToString))
                            Dim stFIPRVIGE As String = CStr(Trim(tbl.Rows(0).Item("FIPRVIGE").ToString))
                            Dim stFIPRRESO As String = CStr(Trim(tbl.Rows(0).Item("FIPRRESO").ToString))
                            Dim stFIPRNURE As String = CStr(Trim(tbl.Rows(0).Item("FIPRVIGE").ToString))
                            Dim stFIPRESTA As String = CStr(Trim(tbl.Rows(0).Item("FIPRESTA").ToString))

                            Dim inSECUENCIA As Integer = fun_NumeroDeSecuenciaDeRegistro(CInt(stFPCANUFI))

                            ' instancia la clase
                            Dim obFIPRCART As New cla_FIPRCART

                            ' inserta el registro
                            If obFIPRCART.fun_Insertar_FIPRCART(CInt(stFPCANUFI), _
                                                                CStr(stPLANCHA), _
                                                                CStr(stVENTANA), _
                                                                CStr(stESCALA_GRAFICA), _
                                                                CStr(stVIGENCIA_GRAFICA), _
                                                                CStr(stVUELO), _
                                                                CStr(stFAJA), _
                                                                CStr(stFOTO), _
                                                                CStr(stVIGENCIA_AEROFOTOGRAFICA), _
                                                                CStr(stAMPLIACION), _
                                                                CStr(stESCALA_AEROFOTOGRAFICA), _
                                                                CStr(stFIPRDEPA), _
                                                                CStr(stFIPRMUNI), _
                                                                CStr(stFIPRTIRE), _
                                                                CStr(stFIPRCLSE), _
                                                                CStr(stFIPRVIGE), _
                                                                CStr(stFIPRRESO), _
                                                                CStr(inSECUENCIA), _
                                                                CStr(stFIPRNURE), _
                                                                CStr(stFIPRESTA)) = True Then

                            End If

                        End If

                    Next

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                Me.pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            pbPROCESO.Value = 0

            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

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