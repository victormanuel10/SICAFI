Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_propietario_anterior_PROPANTE

    '=====================================
    '*** CONSULTA PROPIETARIO ANTERIOR ***
    '=====================================

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

    Public Shared Function instance() As frm_consulta_propietario_anterior_PROPANTE
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_propietario_anterior_PROPANTE
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
    Dim stFPPRCAPR As String
    Dim stFPPRSEXO As String
    Dim stFPPRTIDO As String
    Dim stFPPRNUDO As String
    Dim stFPPRPRAP As String
    Dim stFPPRSEAP As String
    Dim stFPPRNOMB As String
    Dim stFPPRDERE As String
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
    Dim Guardar_stFIPRESTA As String
    Dim Guardar_stFPPRCAPR As String
    Dim Guardar_stFPPRSEXO As String
    Dim Guardar_stFPPRTIDO As String
    Dim Guardar_stFPPRNUDO As String
    Dim Guardar_stFPPRPRAP As String
    Dim Guardar_stFPPRSEAP As String
    Dim Guardar_stFPPRNOMB As String
    Dim Guardar_stFPPRDERE As String
    Dim Guardar_stFPPRMAIN As String
   
    Dim Guardar_boFPPRGRAV As Boolean

    Dim dt_CONSULTA As New DataTable

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
        Me.txtFPPRCAPR.Text = ""
        Me.txtFPPRSEXO.Text = ""
        Me.txtFPPRTIDO.Text = ""
        Me.txtFPPRNUDO.Text = ""
        Me.txtFPPRPRAP.Text = ""
        Me.txtFPPRSEAP.Text = ""
        Me.txtFPPRNOMB.Text = ""
        Me.txtFPPRDERE.Text = ""
        Me.txtFPPRMAIN.Text = ""

        Me.txtPRANPRAP.Text = ""
        Me.txtPRANSEAP.Text = ""
        Me.txtPRANNOMB.Text = ""
        Me.txtPRANCAAC.Text = ""
     
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

        '*** VERIFICA DATOS DE PROPIETARIOS ***

        If Trim(txtFPPRCAPR.Text) = "" Then
            stFPPRCAPR = "%"
        Else
            stFPPRCAPR = Trim(txtFPPRCAPR.Text)
        End If

        If Trim(txtFPPRSEXO.Text) = "" Then
            stFPPRSEXO = "%"
        Else
            stFPPRSEXO = Trim(txtFPPRSEXO.Text)
        End If

        If Trim(txtFPPRTIDO.Text) = "" Then
            stFPPRTIDO = "%"
        Else
            stFPPRTIDO = Trim(txtFPPRTIDO.Text)
        End If

        If Trim(txtFPPRNUDO.Text) = "" Then
            stFPPRNUDO = "%"
        Else
            stFPPRNUDO = Trim(txtFPPRNUDO.Text)
        End If

        If Trim(txtFPPRPRAP.Text) = "" Then
            stFPPRPRAP = "%"
        Else
            stFPPRPRAP = Trim(txtFPPRPRAP.Text)
        End If

        If Trim(txtFPPRSEAP.Text) = "" Then
            stFPPRSEAP = "%"
        Else
            stFPPRSEAP = Trim(txtFPPRSEAP.Text)
        End If

        If Trim(txtFPPRNOMB.Text) = "" Then
            stFPPRNOMB = "%"
        Else
            stFPPRNOMB = Trim(txtFPPRNOMB.Text)
        End If

        If Trim(txtFPPRDERE.Text) = "" Then
            stFPPRDERE = "%"
        Else
            stFPPRDERE = Trim(txtFPPRDERE.Text)
        End If

        If Trim(txtFPPRMAIN.Text) = "" Then
            stFPPRMAIN = "%"
        Else
            stFPPRMAIN = Trim(txtFPPRMAIN.Text)
        End If


    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < dgvCONSULTA.RowCount And SW = 0
                If dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos de ficha predial
                    Me.txtFIPRNUFI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())
                    Me.txtFIPRDIRE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    Me.txtFIPRMUNI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    Me.txtFIPRCORR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(3).Value.ToString())
                    Me.txtFIPRBARR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    Me.txtFIPRMANZ.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    Me.txtFIPRPRED.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    Me.txtFIPREDIF.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    Me.txtFIPRUNPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    Me.txtFIPRCLSE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())
                    Me.txtFIPRESTA.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(10).Value.ToString())

                    ' llena los campos de propietarios actual
                    Me.txtFPPRCAPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())
                    Me.txtFPPRSEXO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(12).Value.ToString())
                    Me.txtFPPRTIDO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(13).Value.ToString())
                    Me.txtFPPRNUDO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(14).Value.ToString())
                    Me.txtFPPRPRAP.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(15).Value.ToString())
                    Me.txtFPPRSEAP.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(16).Value.ToString())
                    Me.txtFPPRNOMB.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(17).Value.ToString())
                    Me.txtFPPRDERE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(18).Value.ToString())
                    Me.txtFPPRMAIN.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(19).Value.ToString())

                    ' llena los campos de propietarios anterior
                    Me.txtPRANPRAP.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(20).Value.ToString())
                    Me.txtPRANSEAP.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(21).Value.ToString())
                    Me.txtPRANNOMB.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(22).Value.ToString())
                    Me.txtPRANCAAC.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(23).Value.ToString())
                 
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
        Guardar_stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
        Guardar_stFPPRCAPR = Trim(Me.txtFPPRCAPR.Text)
        Guardar_stFPPRSEXO = Trim(Me.txtFPPRSEXO.Text)
        Guardar_stFPPRTIDO = Trim(Me.txtFPPRTIDO.Text)
        Guardar_stFPPRNUDO = Trim(Me.txtFPPRNUDO.Text)
        Guardar_stFPPRPRAP = Trim(Me.txtFPPRPRAP.Text)
        Guardar_stFPPRSEAP = Trim(Me.txtFPPRSEAP.Text)
        Guardar_stFPPRNOMB = Trim(Me.txtFPPRNOMB.Text)
        Guardar_stFPPRDERE = Trim(Me.txtFPPRDERE.Text)
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
        Me.txtFIPRESTA.Text = Guardar_stFIPRESTA
        Me.txtFPPRCAPR.Text = Guardar_stFPPRCAPR
        Me.txtFPPRSEXO.Text = Guardar_stFPPRSEXO
        Me.txtFPPRTIDO.Text = Guardar_stFPPRTIDO
        Me.txtFPPRNUDO.Text = Guardar_stFPPRNUDO
        Me.txtFPPRPRAP.Text = Guardar_stFPPRPRAP
        Me.txtFPPRSEAP.Text = Guardar_stFPPRSEAP
        Me.txtFPPRNOMB.Text = Guardar_stFPPRNOMB
        Me.txtFPPRDERE.Text = Guardar_stFPPRDERE
        Me.txtFPPRMAIN.Text = Guardar_stFPPRMAIN

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

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

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
            ParametrosConsulta += "FiprEsta as Estado, "
            ParametrosConsulta += "FpprCapr as Cali_Prop, "
            ParametrosConsulta += "FpprSexo as Sexo, "
            ParametrosConsulta += "FpprTido as Tipo_Docu, "
            ParametrosConsulta += "FpprNudo as Nro_Documento, "
            ParametrosConsulta += "FpprPrap as Pri_Apellido_Actual, "
            ParametrosConsulta += "FpprSeap as Seg_Apellido_Actual, "
            ParametrosConsulta += "FpprNomb as Nombre_Actual, "
            ParametrosConsulta += "FpprDere as Derecho, "
            ParametrosConsulta += "FpprMain as Matricula "
            ParametrosConsulta += "From FichPred, FiprProp where "
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
            ParametrosConsulta += "FpprCapr like '" & stFPPRCAPR & "' and "
            ParametrosConsulta += "FpprSexo like '" & stFPPRSEXO & "' and "
            ParametrosConsulta += "FpprTido like '" & stFPPRTIDO & "' and "
            ParametrosConsulta += "FpprNudo like '" & stFPPRNUDO & "' and "
            ParametrosConsulta += "FpprPrap like '" & stFPPRPRAP & "' and "
            ParametrosConsulta += "FpprSeap like '" & stFPPRSEAP & "' and "
            ParametrosConsulta += "FpprNomb like '" & stFPPRNOMB & "' and "
            ParametrosConsulta += "FpprDere like '" & stFPPRDERE & "' and "
            ParametrosConsulta += "FpprMain like '" & stFPPRMAIN & "' and "
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

                Dim dr_CONSULTA As DataRow

                dt_CONSULTA = New DataTable

                ' crea las columnas
                dt_CONSULTA.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Direccion", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Corregi", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Edificio", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Unidad", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Estado", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Cali_Prop", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Sexo", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Tipo_Docu", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Pri_Apellido_Actual", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Seg_Apellido_Actual", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Nombre_Actual", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Derecho", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Matricula", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Pri_Apellido_Anterior", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Seg_Apellido_Anterior", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Nombre_Anterior", GetType(String)))
                dt_CONSULTA.Columns.Add(New DataColumn("Causa_Del_Acto", GetType(String)))

                ' declara la variable
                Dim stPRANNUFI As String = ""
                Dim stPRANNUDO As String = ""
                Dim stPRANPRAP As String = ""
                Dim stPRANSEAP As String = ""
                Dim stPRANNOMB As String = ""
                Dim stPRANCAAC As String = ""

                Dim stFIPRNUFI As String = ""
                Dim stFPPRNUDO As String = ""

                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    ' llena las variables
                    stFIPRNUFI = Trim(dt.Rows(i).Item("Nro_Ficha"))
                    stFPPRNUDO = Trim(dt.Rows(i).Item("Nro_Documento"))

                    stPRANNUFI = ""
                    stPRANNUDO = ""
                    stPRANPRAP = ""
                    stPRANSEAP = ""
                    stPRANNOMB = ""
                    stPRANCAAC = ""

                    ' instancia la clase
                    Dim objdatos As New cla_PROPANTE
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(stFIPRNUFI, stFPPRNUDO)

                    If tbl.Rows.Count > 0 Then

                        stPRANNUFI = Trim(tbl.Rows(0).Item("PRANNUFI"))
                        stPRANNUDO = Trim(tbl.Rows(0).Item("PRANNUDO"))
                        stPRANPRAP = Trim(tbl.Rows(0).Item("PRANPRAP"))
                        stPRANSEAP = Trim(tbl.Rows(0).Item("PRANSEAP"))
                        stPRANNOMB = Trim(tbl.Rows(0).Item("PRANNOMB"))
                        stPRANCAAC = Trim(tbl.Rows(0).Item("PRANCAAC"))

                    End If

                    dr_CONSULTA = dt_CONSULTA.NewRow()

                    dr_CONSULTA("Nro_Ficha") = Trim(dt.Rows(i).Item("Nro_Ficha"))
                    dr_CONSULTA("Direccion") = Trim(dt.Rows(i).Item("Direccion"))
                    dr_CONSULTA("Municipio") = Trim(dt.Rows(i).Item("Municipio"))
                    dr_CONSULTA("Corregi") = Trim(dt.Rows(i).Item("Corregi"))
                    dr_CONSULTA("Barrio") = Trim(dt.Rows(i).Item("Barrio"))
                    dr_CONSULTA("Manzana") = Trim(dt.Rows(i).Item("Manzana"))
                    dr_CONSULTA("Predio") = Trim(dt.Rows(i).Item("Predio"))
                    dr_CONSULTA("Edificio") = Trim(dt.Rows(i).Item("Edificio"))
                    dr_CONSULTA("Unidad") = Trim(dt.Rows(i).Item("Unidad"))
                    dr_CONSULTA("Sector") = Trim(dt.Rows(i).Item("Sector"))
                    dr_CONSULTA("Estado") = Trim(dt.Rows(i).Item("Estado"))
                    dr_CONSULTA("Cali_Prop") = Trim(dt.Rows(i).Item("Cali_Prop"))
                    dr_CONSULTA("Sexo") = Trim(dt.Rows(i).Item("Sexo"))
                    dr_CONSULTA("Tipo_Docu") = Trim(dt.Rows(i).Item("Tipo_Docu"))
                    dr_CONSULTA("Nro_Documento") = Trim(dt.Rows(i).Item("Nro_Documento"))
                    dr_CONSULTA("Pri_Apellido_Actual") = Trim(dt.Rows(i).Item("Pri_Apellido_Actual"))
                    dr_CONSULTA("Seg_Apellido_Actual") = Trim(dt.Rows(i).Item("Seg_Apellido_Actual"))
                    dr_CONSULTA("Nombre_Actual") = Trim(dt.Rows(i).Item("Nombre_Actual"))
                    dr_CONSULTA("Derecho") = Trim(dt.Rows(i).Item("Derecho"))
                    dr_CONSULTA("Matricula") = Trim(dt.Rows(i).Item("Matricula"))
                    dr_CONSULTA("Pri_Apellido_Anterior") = Trim(stPRANPRAP)
                    dr_CONSULTA("Seg_Apellido_Anterior") = Trim(stPRANSEAP)
                    dr_CONSULTA("Nombre_Anterior") = Trim(stPRANNOMB)
                    dr_CONSULTA("Causa_Del_Acto") = Trim(stPRANCAAC)

                    dt_CONSULTA.Rows.Add(dr_CONSULTA)

                Next

                ' llena el datagridview
                Me.dgvCONSULTA.DataSource = dt_CONSULTA

                ' Coloca la mascara del campo
                Me.txtFPPRDERE.Text = CType(fun_Formato_Decimal_6_Decimales(Trim(txtFPPRDERE.Text)), String)

                ' llena la lista de valores
                pro_ListaDeValores()
            Else
                Dim tbl_Limpiar As New DataTable
                dgvCONSULTA.DataSource = tbl_Limpiar
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString

            dgvCONSULTA.Focus()

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
        txtFPPRCAPR.Focus()
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
        txtFPPRCAPR.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        txtFPPRCAPR.Focus()

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
    Private Sub cboFPPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRCAPR.GotFocus
        txtFPPRCAPR.SelectionStart = 0
        txtFPPRCAPR.SelectionLength = Len(txtFPPRCAPR.Text)
        strBARRESTA.Items(0).Text = txtFPPRCAPR.AccessibleDescription
    End Sub
    Private Sub cboFPPRSEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRSEXO.GotFocus
        txtFPPRSEXO.SelectionStart = 0
        txtFPPRSEXO.SelectionLength = Len(txtFPPRSEXO.Text)
        strBARRESTA.Items(0).Text = txtFPPRSEXO.AccessibleDescription
    End Sub
    Private Sub cboFPPRTIDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRTIDO.GotFocus
        txtFPPRTIDO.SelectionStart = 0
        txtFPPRTIDO.SelectionLength = Len(txtFPPRTIDO.Text)
        strBARRESTA.Items(0).Text = txtFPPRTIDO.AccessibleDescription
    End Sub
    Private Sub txtFPPRNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRNUDO.GotFocus
        txtFPPRNUDO.SelectionStart = 0
        txtFPPRNUDO.SelectionLength = Len(txtFPPRNUDO.Text)
        strBARRESTA.Items(0).Text = txtFPPRNUDO.AccessibleDescription
    End Sub
    Private Sub txtFPPRPRAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRPRAP.GotFocus
        txtFPPRPRAP.SelectionStart = 0
        txtFPPRPRAP.SelectionLength = Len(txtFPPRPRAP.Text)
        strBARRESTA.Items(0).Text = txtFPPRPRAP.AccessibleDescription
    End Sub
    Private Sub txtFPPRSEAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRSEAP.GotFocus
        txtFPPRSEAP.SelectionStart = 0
        txtFPPRSEAP.SelectionLength = Len(txtFPPRSEAP.Text)
        strBARRESTA.Items(0).Text = txtFPPRSEAP.AccessibleDescription
    End Sub
    Private Sub txtFPPRNOMB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRNOMB.GotFocus
        txtFPPRNOMB.SelectionStart = 0
        txtFPPRNOMB.SelectionLength = Len(txtFPPRNOMB.Text)
        strBARRESTA.Items(0).Text = txtFPPRNOMB.AccessibleDescription
    End Sub
    Private Sub txtFPPRDERE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRDERE.GotFocus
        txtFPPRDERE.SelectionStart = 0
        txtFPPRDERE.SelectionLength = Len(txtFPPRDERE.Text)
        strBARRESTA.Items(0).Text = txtFPPRDERE.AccessibleDescription
    End Sub

    Private Sub txtGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRANPRAP.GotFocus, txtPRANSEAP.GotFocus, txtPRANNOMB.GotFocus, txtPRANCAAC.GotFocus
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
    Private Sub txtFPPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRSEXO.Focus()
        End If
    End Sub
    Private Sub txtFPPRSEXO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRSEXO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRTIDO.Focus()
        End If
    End Sub
    Private Sub txtFPPRTIDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRTIDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRNUDO.Focus()
        End If
    End Sub
    Private Sub txtFPPRNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRNUDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRPRAP.Focus()
        End If
    End Sub
    Private Sub txtFPPRPRAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRPRAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRSEAP.Focus()
        End If
    End Sub
    Private Sub txtFPPRSEAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRSEAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRNOMB.Focus()
        End If
    End Sub
    Private Sub txtFPPRNOMB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRNOMB.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRDERE.Focus()
        End If
    End Sub
    Private Sub txtFPPRDERE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRDERE.KeyPress
        If fun_Verificar_Dato_Decimal_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRNUFI.Focus()
        End If
    End Sub

    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRANPRAP.KeyPress, txtPRANSEAP.KeyPress, txtPRANNOMB.KeyPress, txtPRANCAAC.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If

    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRESTA.KeyDown, dgvCONSULTA.KeyDown, txtFPPRCAPR.KeyDown, txtFPPRSEXO.KeyDown, txtFPPRTIDO.KeyDown, txtFPPRNUDO.KeyDown, txtFPPRPRAP.KeyDown, txtFPPRSEAP.KeyDown, txtFPPRNOMB.KeyDown, txtFPPRDERE.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            cmdULTIMACONSULTA.PerformClick()
        End If

    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONSULTA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFPPRDERE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRDERE.Validated
        If Trim(txtFPPRDERE.Text) <> "" Then
            If Val(txtFPPRDERE.Text) >= 0 Then
                txtFPPRDERE.Text = CType(fun_Formato_Decimal_6_Decimales(txtFPPRDERE.Text.ToString), String)
            End If
        End If
    End Sub
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

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        If tstBAESDESC.Text <> "" Then
            MessageBox.Show(Trim(tstBAESDESC.Text), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#End Region

End Class