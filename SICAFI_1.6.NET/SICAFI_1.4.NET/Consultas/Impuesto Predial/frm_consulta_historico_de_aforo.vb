Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_historico_de_aforo

    '==================================
    '*** CONSULTA AFORO DE IMPUESTO ***
    '==================================

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

    Public Shared Function instance() As frm_consulta_historico_de_aforo
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_historico_de_aforo
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

#Region "VARIABLES LOCALES"

    Dim stFIPRNUFI As String = ""
    Dim stFIPRDIRE As String = ""
    Dim stFIPRMUNI As String = ""
    Dim stFIPRCORR As String = ""
    Dim stFIPRBARR As String = ""
    Dim stFIPRMANZ As String = ""
    Dim stFIPRPRED As String = ""
    Dim stFIPREDIF As String = ""
    Dim stFIPRUNPR As String = ""
    Dim stFIPRCLSE As String = ""
    Dim stFIPRCASU As String = ""
    Dim stFIPRCAPR As String = ""
    Dim stFIPRMOAD As String = ""
    Dim stFIPRESTA As String = ""

    Dim stAFSIVIGE As String = ""
    Dim stAFSIVABA As String = ""
    Dim stAFSIVALI As String = ""
    Dim stAFSIVAIM As String = ""
    Dim stAFSITIIM As String = ""
    Dim stAFSICONC As String = ""
    Dim stAFSIEXEC As String = ""
    Dim stAFSIESTA As String = ""
  
    Dim Separador As String = ""

    ' variables guardar consulta
    Dim Guardar_stFIPRNUFI As String = ""
    Dim Guardar_stFIPRDIRE As String = ""
    Dim Guardar_stFIPRMUNI As String = ""
    Dim Guardar_stFIPRCORR As String = ""
    Dim Guardar_stFIPRBARR As String = ""
    Dim Guardar_stFIPRMANZ As String = ""
    Dim Guardar_stFIPRPRED As String = ""
    Dim Guardar_stFIPREDIF As String = ""
    Dim Guardar_stFIPRUNPR As String = ""
    Dim Guardar_stFIPRCLSE As String = ""
    Dim Guardar_stFIPRCASU As String = ""
    Dim Guardar_stFIPRCAPR As String = ""
    Dim Guardar_stFIPRMOAD As String = ""
    Dim Guardar_stFIPRESTA As String = ""
    Dim Guardar_stAFSIVIGE As String = ""
    Dim Guardar_stAFSIVABA As String = ""
    Dim Guardar_stAFSIVALI As String = ""
    Dim Guardar_stAFSIVAIM As String = ""
    Dim Guardar_stAFSITIIM As String = ""
    Dim Guardar_stAFSICONC As String = ""
    Dim Guardar_boAFSIEXEC As Boolean
    Dim Guardar_stAFSIESTA As String = ""

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
        Me.txtAFSIVABA.Text = ""
        Me.txtAFSIVALI.Text = ""
        Me.txtAFSIVAIM.Text = ""
        Me.txtAFSITOVB.Text = ""
        Me.txtAFSITOVL.Text = ""
        Me.txtAFSITOVI.Text = ""

        Me.cboFIPRCLSE.DataSource = New DataTable
        Me.cboFIPRCASU.DataSource = New DataTable
        Me.cboFIPRCAPR.DataSource = New DataTable
        Me.cboFIPRMOAD.DataSource = New DataTable
        Me.cboFIPRESTA.DataSource = New DataTable
        Me.cboAFSIVIGE.DataSource = New DataTable
        Me.cboAFSIESTA.DataSource = New DataTable
        Me.cboAFSITIIM.DataSource = New DataTable
        Me.cboAFSICONC.DataSource = New DataTable

        Me.chkAFSIEXEN.CheckState = CheckState.Indeterminate

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

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

        If Trim(Me.cboFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(Me.cboFIPRCLSE.SelectedValue)
        End If

        If Trim(Me.cboFIPRCASU.Text) = "" Then
            stFIPRCASU = "%"
        Else
            stFIPRCASU = Trim(Me.cboFIPRCASU.SelectedValue)
        End If

        If Trim(Me.cboFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(Me.cboFIPRCAPR.SelectedValue)
        End If

        If Trim(Me.cboFIPRMOAD.Text) = "" Then
            stFIPRMOAD = "%"
        Else
            stFIPRMOAD = Trim(Me.cboFIPRMOAD.SelectedValue)
        End If

        If Trim(Me.cboFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(Me.cboFIPRESTA.SelectedValue)
        End If

        '*** VERIFICA DATOS DE HISTORICOS DE LIQUIDACIÓN ***

        If Trim(Me.cboAFSIVIGE.Text) = "" Then
            stAFSIVIGE = "%"
        Else
            stAFSIVIGE = Trim(Me.cboAFSIVIGE.SelectedValue)
        End If

        If Trim(Me.txtAFSIVABA.Text) = "" Then
            stAFSIVABA = "%"
        Else
            stAFSIVABA = Trim(Me.txtAFSIVABA.Text)
        End If

        If Trim(Me.txtAFSIVALI.Text) = "" Then
            stAFSIVALI = "%"
        Else
            stAFSIVALI = Trim(Me.txtAFSIVALI.Text)
        End If

        If Trim(Me.txtAFSIVAIM.Text) = "" Then
            stAFSIVAIM = "%"
        Else
            stAFSIVAIM = Trim(Me.txtAFSIVAIM.Text)
        End If

        If Trim(Me.cboAFSITIIM.Text) = "" Then
            stAFSITIIM = "%"
        Else
            stAFSITIIM = Trim(Me.cboAFSITIIM.SelectedValue)
        End If

        If Trim(Me.cboAFSICONC.Text) = "" Then
            stAFSICONC = "%"
        Else
            stAFSICONC = Trim(Me.cboAFSICONC.SelectedValue)
        End If

        If Me.chkAFSIEXEN.CheckState = CheckState.Indeterminate Then
            stAFSIEXEC = "%"
        ElseIf Me.chkAFSIEXEN.Checked = False Then
            stAFSIEXEC = "0"
        ElseIf Me.chkAFSIEXEN.Checked = True Then
            stAFSIEXEC = "1"
        End If

        If Trim(Me.cboAFSIESTA.Text) = "" Then
            stAFSIESTA = "%"
        Else
            stAFSIESTA = Trim(Me.cboAFSIESTA.SelectedValue)
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
                    Me.cboFIPRCLSE.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(9).Value.ToString()
                    Me.cboFIPRCASU.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(10).Value.ToString()
                    Me.cboFIPRCAPR.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString()
                    Me.cboFIPRMOAD.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(12).Value.ToString()
                    Me.cboFIPRESTA.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(13).Value.ToString()

                    ' llena los campos de avaluos
                    Me.cboAFSIVIGE.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(14).Value.ToString()
                    Me.cboAFSITIIM.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(15).Value.ToString()
                    Me.cboAFSICONC.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(16).Value.ToString()
                    Me.txtAFSIVABA.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(17).Value.ToString())
                    Me.txtAFSIVALI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(18).Value.ToString())
                    Me.txtAFSIVAIM.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(19).Value.ToString())
                    Me.chkAFSIEXEN.Checked = Me.dgvCONSULTA.CurrentRow.Cells(20).Value
                    Me.cboAFSIESTA.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(21).Value.ToString()

                    Me.txtAFSIVABA.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(Me.txtAFSIVABA.Text))
                    Me.txtAFSIVALI.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(Me.txtAFSIVALI.Text))
                    Me.txtAFSIVAIM.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(Me.txtAFSIVAIM.Text))

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
        Guardar_stFIPRCLSE = Trim(Me.cboFIPRCLSE.SelectedValue)
        Guardar_stFIPRCASU = Trim(Me.cboFIPRCASU.SelectedValue)
        Guardar_stFIPRCAPR = Trim(Me.cboFIPRCAPR.SelectedValue)
        Guardar_stFIPRMOAD = Trim(Me.cboFIPRMOAD.SelectedValue)
        Guardar_stFIPRESTA = Trim(Me.cboFIPRESTA.SelectedValue)
        Guardar_stAFSIVIGE = Trim(Me.cboAFSIVIGE.SelectedValue)
        Guardar_stAFSIVALI = Trim(Me.txtAFSIVALI.Text)
        Guardar_stAFSIVABA = Trim(Me.txtAFSIVABA.Text)
        Guardar_stAFSIVAIM = Trim(Me.txtAFSIVAIM.Text)
        Guardar_stAFSITIIM = Trim(Me.cboAFSITIIM.SelectedValue)
        Guardar_stAFSICONC = Trim(Me.cboAFSICONC.SelectedValue)
        Guardar_boAFSIEXEC = Trim(Me.chkAFSIEXEN.Checked)
        Guardar_stAFSIESTA = Trim(Me.cboAFSIESTA.SelectedValue)

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

        If Guardar_stFIPRCLSE <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFIPRCLSE, Me.cboFIPRCLSE.SelectedIndex)
        End If
        If Guardar_stFIPRCASU <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL_Descripcion(Me.cboFIPRCASU, Me.cboFIPRCASU.SelectedIndex)
        End If
        If Guardar_stFIPRCAPR <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboFIPRCAPR, Me.cboFIPRCAPR.SelectedIndex)
        End If
        If Guardar_stFIPRMOAD <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU_Descripcion(Me.cboFIPRMOAD, Me.cboFIPRMOAD.SelectedIndex)
        End If
        If Guardar_stFIPRESTA <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboFIPRESTA, Me.cboFIPRESTA.SelectedIndex)
        End If
        If Guardar_stAFSIVIGE <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboAFSIVIGE, Me.cboAFSIVIGE.SelectedIndex)
        End If
        If Guardar_stAFSITIIM <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboAFSITIIM, Me.cboAFSITIIM.SelectedIndex)
        End If
        If Guardar_stAFSICONC <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboAFSICONC, Me.cboAFSICONC.SelectedIndex)
        End If
        If Guardar_stAFSIESTA <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboAFSIESTA, Me.cboAFSIESTA.SelectedIndex)
        End If

        Me.cboFIPRCLSE.SelectedValue = Guardar_stFIPRCLSE
        Me.cboFIPRCASU.SelectedValue = Guardar_stFIPRCASU
        Me.cboFIPRCAPR.SelectedValue = Guardar_stFIPRCAPR
        Me.cboFIPRMOAD.SelectedValue = Guardar_stFIPRMOAD
        Me.cboFIPRESTA.SelectedValue = Guardar_stFIPRESTA
        Me.cboAFSIVIGE.SelectedValue = Guardar_stAFSIVIGE
        Me.cboAFSITIIM.SelectedValue = Guardar_stAFSITIIM
        Me.cboAFSICONC.SelectedValue = Guardar_stAFSICONC
        Me.cboAFSIESTA.SelectedValue = Guardar_stAFSIESTA

        Me.txtAFSIVABA.Text = Guardar_stAFSIVABA
        Me.txtAFSIVALI.Text = Guardar_stAFSIVALI
        Me.txtAFSIVAIM.Text = Guardar_stAFSIVAIM

    End Sub
    Private Sub pro_FormatoDeCampos()

        Me.dgvCONSULTA.Columns("Valor_Base").DefaultCellStyle.Format = "c"
        Me.dgvCONSULTA.Columns("Valor_Liquidado").DefaultCellStyle.Format = "c"
        Me.dgvCONSULTA.Columns("Valor_Impuesto").DefaultCellStyle.Format = "c"

    End Sub
    Private Sub pro_CargaListaDesplegable()

        ' carga los combobox
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboFIPRESTA, Me.cboFIPRESTA.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFIPRCLSE, Me.cboFIPRCLSE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL_Descripcion(Me.cboFIPRCASU, Me.cboFIPRCASU.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboFIPRCAPR, Me.cboFIPRCAPR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU_Descripcion(Me.cboFIPRMOAD, Me.cboFIPRMOAD.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboAFSIVIGE, Me.cboAFSIVIGE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboAFSITIIM, Me.cboAFSITIIM.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboAFSICONC, Me.cboAFSICONC.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboAFSIESTA, Me.cboAFSIESTA.SelectedIndex)

    End Sub
    Private Sub pro_SumaTotales()

        Try
            If Me.dgvCONSULTA.RowCount > 0 Then

                Dim loAFSIVABA As Long = 0
                Dim loAFSIVALI As Long = 0
                Dim loAFSIVAIM As Long = 0

                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    loAFSIVABA += Double.Parse(dt.Rows(i).Item("Valor_Base"))
                    loAFSIVALI += Double.Parse(dt.Rows(i).Item("Valor_Liquidado"))
                    loAFSIVAIM += Double.Parse(dt.Rows(i).Item("Valor_Impuesto"))

                Next

                Me.txtAFSITOVB.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(loAFSIVABA))
                Me.txtAFSITOVL.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(loAFSIVALI))
                Me.txtAFSITOVI.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(loAFSIVAIM))

            Else
                Me.txtAFSITOVB.Text = ""
                Me.txtAFSITOVL.Text = ""
                Me.txtAFSITOVI.Text = ""
           
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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
            ParametrosConsulta += "FiprDire as Dirección, "
            ParametrosConsulta += "FiprMuni as Municipio, "
            ParametrosConsulta += "FiprCorr as Corregimiento, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as Unidad, "
            ParametrosConsulta += "FiprClse as Sector, "
            ParametrosConsulta += "FiprCasu as Cat_de_suelo, "
            ParametrosConsulta += "FiprCapr as Caracteristica, "
            ParametrosConsulta += "FiprMoad as Modo_de_adqui, "
            ParametrosConsulta += "FiprEsta as Estado_ficha, "
            ParametrosConsulta += "AfsiVige as Vigencia, "
            ParametrosConsulta += "AfsiTiim as Tipo_Impuesto, "
            ParametrosConsulta += "AfsiConc as Concepto, "
            ParametrosConsulta += "AfsiVaba as Valor_Base, "
            ParametrosConsulta += "AfsiVali as Valor_Liquidado, "
            ParametrosConsulta += "AfsiVaim as Valor_Impuesto, "
            ParametrosConsulta += "AfsiExen as Exento, "
            ParametrosConsulta += "AfsiEsta as Estado "
            ParametrosConsulta += "From FichPred, AforSuim where "
            ParametrosConsulta += "FiprNufi = AfsiNufi and "
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
            ParametrosConsulta += "FiprCasu like '" & stFIPRCASU & "' and "
            ParametrosConsulta += "FiprCapr like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "FiprMoad like '" & stFIPRMOAD & "' and "
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "AfsiVige like '" & stAFSIVIGE & "' and "
            ParametrosConsulta += "AfsiVaba like '" & stAFSIVABA & "' and "
            ParametrosConsulta += "AfsiVali like '" & stAFSIVALI & "' and "
            ParametrosConsulta += "AfsiVaim like '" & stAFSIVAIM & "' and "
            ParametrosConsulta += "AfsiTiim like '" & stAFSITIIM & "' and "
            ParametrosConsulta += "AfsiConc like '" & stAFSICONC & "' and "
            ParametrosConsulta += "AfsiExen like '" & stAFSIEXEC & "' and "
            ParametrosConsulta += "AfsiESTA like '" & stAFSIESTA & "' "
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
                Else
                    Me.dgvCONSULTA.DataSource = dt
                End If

                pro_FormatoDeCampos()
                pro_CargaListaDesplegable()
                pro_ListaDeValores()
                pro_SumaTotales()

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
        Me.txtFIPRNUFI.Focus()
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
        Me.txtFIPRNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()

        pro_PermisoControlDeComandos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consulta_historico_de_avaluos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtFIPRNUFI.Focus()
    End Sub

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus, _
                                                                                                  txtFIPRDIRE.GotFocus, _
                                                                                                  txtFIPRMUNI.GotFocus, _
                                                                                                  txtFIPRCORR.GotFocus, _
                                                                                                  txtFIPRBARR.GotFocus, _
                                                                                                  txtFIPRMANZ.GotFocus, _
                                                                                                  txtFIPRPRED.GotFocus, _
                                                                                                  txtFIPREDIF.GotFocus, _
                                                                                                  txtFIPRUNPR.GotFocus, _
                                                                                                  txtAFSIVABA.GotFocus, _
                                                                                                  txtAFSIVALI.GotFocus, _
 _
                                                                                                  txtAFSIVAIM.GotFocus

        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus, _
                                                                                          cmdExportarPlano.GotFocus, _
                                                                                          cmdSALIR.GotFocus, _
                                                                                          cmdLIMPIAR.GotFocus, _
                                                                                          cmdExportarExcel.GotFocus, _
                                                                                          cmdULTIMACONSULTA.GotFocus




        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress, _
                                                                                                  txtFIPRDIRE.KeyPress, _
                                                                                                  txtFIPRMUNI.KeyPress, _
                                                                                                  txtFIPRCORR.KeyPress, _
                                                                                                  txtFIPRBARR.KeyPress, _
                                                                                                  txtFIPRMANZ.KeyPress, _
                                                                                                  txtFIPRPRED.KeyPress, _
                                                                                                  txtFIPREDIF.KeyPress, _
                                                                                                  txtFIPRUNPR.KeyPress, _
                                                                                                  txtAFSIVABA.KeyPress, _
                                                                                                  txtAFSIVALI.KeyPress, _
                                                                                                  txtAFSIVAIM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, dgvCONSULTA.KeyDown, txtAFSIVABA.KeyDown, txtAFSIVALI.KeyDown
        If e.KeyCode = Keys.F8 Then
            Me.cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            Me.cmdULTIMACONSULTA.PerformClick()
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

#Region "Click"

    Private Sub cboFIPRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboFIPRESTA, Me.cboFIPRESTA.SelectedIndex)
    End Sub
    Private Sub cboFIPRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFIPRCLSE, Me.cboFIPRCLSE.SelectedIndex)
    End Sub
    Private Sub cboFIPRCASU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL_Descripcion(Me.cboFIPRCASU, Me.cboFIPRCASU.SelectedIndex)
    End Sub
    Private Sub cboFIPRCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboFIPRCAPR, Me.cboFIPRCAPR.SelectedIndex)
    End Sub
    Private Sub cboFIPRMOAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRMOAD.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU_Descripcion(Me.cboFIPRMOAD, Me.cboFIPRMOAD.SelectedIndex)
    End Sub
    Private Sub cboAFSIVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSIVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboAFSIVIGE, Me.cboAFSIVIGE.SelectedIndex)
    End Sub
    Private Sub cboAFSITIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSITIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboAFSITIIM, Me.cboAFSITIIM.SelectedIndex)
    End Sub
    Private Sub cboAFSIESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSICONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboAFSICONC, Me.cboAFSICONC.SelectedIndex)
    End Sub
    Private Sub cboAFSIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboAFSIESTA, Me.cboAFSIESTA.SelectedIndex)
    End Sub

#End Region

#End Region

End Class