Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Math

Public Class frm_AVALCOME

    '========================
    '*** AVALÚO COMERCIAL ***
    '========================

#Region "VARIABLES"

    Private vl_dtCONSULTA As New DataTable
    Private dt_Carga As New DataTable

    Private loSuma As Long = 0
    Private loMedia As Long = 0
    Private loDesviacionEstandar As Long = 0
    Private loSumaDesviacionEstandar As Long = 0
    Private loCoeficienteVariacion As Long = 0
    Private loValorComercial As Long = 0

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal dtTabla As DataTable)

        vl_dtCONSULTA = dtTabla

        InitializeComponent()
        pro_Limpiar()
        pro_CargarDatos()
        pro_AsignarAviso()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_CargarDatos()

        Try
            dt_Carga = New DataTable

            dt_Carga.Columns.Add(New DataColumn("Cedula Catastral", GetType(String)))
            dt_Carga.Columns.Add(New DataColumn("Direccion", GetType(String)))
            dt_Carga.Columns.Add(New DataColumn("Descripcion", GetType(String)))
            dt_Carga.Columns.Add(New DataColumn("Area mts2", GetType(String)))
            dt_Carga.Columns.Add(New DataColumn("Avaluo Comercial", GetType(Long)))
            dt_Carga.Columns.Add(New DataColumn("Valor mts2 Comercial", GetType(Long)))
            dt_Carga.Columns.Add(New DataColumn("Valor mts2 Catastral " & Me.nudAVCOVM2CA.Value & "%", GetType(Long)))

            ' Crea objeto registros
            Dim dr1 As DataRow

            Dim j As Integer = 0

            For j = 0 To vl_dtCONSULTA.Rows.Count - 1

                dr1 = dt_Carga.NewRow()

                dr1("Cedula Catastral") = CStr(Trim(vl_dtCONSULTA.Rows(j).Item(1).ToString)) & "-"
                dr1("Direccion") = CStr(Trim(vl_dtCONSULTA.Rows(j).Item(13).ToString))
                dr1("Descripcion") = CStr(Trim(vl_dtCONSULTA.Rows(j).Item(12).ToString))
                dr1("Area mts2") = CStr(Trim(vl_dtCONSULTA.Rows(j).Item(28).ToString))
                dr1("Avaluo Comercial") = CLng(Trim(vl_dtCONSULTA.Rows(j).Item(27).ToString))
                dr1("Valor mts2 Comercial") = CLng(Trim(vl_dtCONSULTA.Rows(j).Item(30).ToString))
                dr1("Valor mts2 Catastral " & Me.nudAVCOVM2CA.Value & "%") = CLng(Trim(vl_dtCONSULTA.Rows(j).Item(30).ToString)) * Me.nudAVCOVM2CA.Value / 100

                dt_Carga.Rows.Add(dr1)

            Next

            If dt_Carga.Rows.Count > 0 Then

                Me.dgvCONSULTA.DataSource = dt_Carga

                pro_GenerarIndices()

                Me.dgvCONSULTA.Columns("Avaluo Comercial").DefaultCellStyle.Format = "c"
                Me.dgvCONSULTA.Columns("Valor mts2 Comercial").DefaultCellStyle.Format = "c"
                Me.dgvCONSULTA.Columns("Valor mts2 Catastral " & Me.nudAVCOVM2CA.Value & "%").DefaultCellStyle.Format = "c"
                Me.dgvCONSULTA.Columns("Cedula Catastral").Width = 170
                Me.dgvCONSULTA.Columns("Descripcion").Width = 320

            Else
                pro_Limpiar()
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt_Carga.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub pro_GenerarIndices()

        Try
            If Me.dgvCONSULTA.RowCount > 1 Then

                Dim dtCargaData As New DataTable

                dtCargaData = Me.dgvCONSULTA.DataSource

                Dim inCantidadRegistros As Integer = Me.dgvCONSULTA.RowCount

                ' genera la media
                Dim i As Integer = 0

                loSuma = 0

                For i = 0 To dtCargaData.Rows.Count - 1

                    loSuma += dtCargaData.Rows(i).Item(5)

                Next

                Me.txtAVCOMEDI.Text = fun_Formato_Mascara_Pesos_Enteros(loSuma / inCantidadRegistros)
                Me.txtAVCOVM2CO.Text = fun_Formato_Mascara_Pesos_Enteros(loSuma / inCantidadRegistros)
                Me.txtAVCOVM2CA.Text = fun_Formato_Mascara_Pesos_Enteros(((loSuma / inCantidadRegistros) * Me.nudAVCOVM2CA.Value) / 100)

                Me.txtAVCOVTCO.Text = fun_Formato_Mascara_Pesos_Enteros(CInt(Me.txtAVCOVM2CO.Text) * Me.nudAVCOVTCO.Value / 100)
                Me.txtAVCOVCCO.Text = fun_Formato_Mascara_Pesos_Enteros(CInt(Me.txtAVCOVM2CO.Text) * Me.nudAVCOVCCO.Value / 100)

                Me.txtAVCOVTCA.Text = fun_Formato_Mascara_Pesos_Enteros(CInt(((Me.txtAVCOVM2CO.Text) * Me.nudAVCOVM2CA.Value) / 100) * Me.nudAVCOVTCA.Value / 100)
                Me.txtAVCOVCCA.Text = fun_Formato_Mascara_Pesos_Enteros(CInt(((Me.txtAVCOVM2CO.Text) * Me.nudAVCOVM2CA.Value) / 100) * Me.nudAVCOVCCA.Value / 100)


                loMedia = CLng(Me.txtAVCOMEDI.Text)

                ' genera la desviación
                Dim ii As Integer = 0

                loSuma = 0
                loSumaDesviacionEstandar = 0
                loDesviacionEstandar = 0

                For ii = 0 To dtCargaData.Rows.Count - 1

                    loSumaDesviacionEstandar = loSumaDesviacionEstandar + (CLng(dtCargaData.Rows(ii).Item(5)) - loMedia) ^ 2

                Next

                loDesviacionEstandar = loSumaDesviacionEstandar / inCantidadRegistros
                loDesviacionEstandar = Sqrt(loDesviacionEstandar)
                loCoeficienteVariacion = loMedia / loDesviacionEstandar

                Me.txtAVCODEES.Text = fun_Formato_Mascara_Pesos_Enteros(loDesviacionEstandar)
                Me.txtAVCOCOVA.Text = fun_Formato_Decimal_2_Decimales(loCoeficienteVariacion)

            Else
                MessageBox.Show("La cantidad de registros debe ser superior a uno", "Mensaje ...")
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Limpiar()

        Me.txtAVCOCOVA.Text = ""
        Me.txtAVCODEES.Text = ""
        Me.txtAVCOMEDI.Text = ""
        Me.txtAVCOVM2CO.Text = ""
        Me.txtAVCOVM2CA.Text = ""
        Me.txtAVCOVTCO.Text = ""
        Me.txtAVCOVCCO.Text = ""
        Me.txtAVCOVTCA.Text = ""
        Me.txtAVCOVCCA.Text = ""
        Me.lblAviso.Text = ""

        Me.dgvCONSULTA.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_AsignarAviso()

        Try
            If Trim(Me.txtAVCOCOVA.Text) <> "" And Trim(Me.txtAVCOCOVA.Text) <> "" Then

                If CDbl(Me.txtAVCOCOVA.Text) <= 10 Then
                    Me.lblAviso.Text = "CORRECTO"
                Else
                    Me.lblAviso.Text = "INCORRECTO"
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerar.Click
        pro_GenerarIndices()
        pro_AsignarAviso()
    End Sub
    Private Sub cmdReconsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReconsultar.Click
        pro_CargarDatos()
        pro_GenerarIndices()
        pro_AsignarAviso()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
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

#End Region

#Region "FORMULARIO"

    Private Sub frm_AVALCOME_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Avalúo comercial"
    End Sub

#End Region


End Class