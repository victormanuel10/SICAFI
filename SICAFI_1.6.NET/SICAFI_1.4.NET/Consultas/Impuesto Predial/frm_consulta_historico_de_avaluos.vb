Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_historico_de_avaluos

    '======================================================
    '*** CONSULTA HISTORICO DE AVALUOS IMPUESTO PREDIAL ***
    '======================================================

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

    Public Shared Function instance() As frm_consulta_historico_de_avaluos
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_historico_de_avaluos
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

    Dim stSUIMNUFI As String = ""
    Dim stSUIMDIRE As String = ""
    Dim stSUIMMUNI As String = ""
    Dim stSUIMCORR As String = ""
    Dim stSUIMBARR As String = ""
    Dim stSUIMMANZ As String = ""
    Dim stSUIMPRED As String = ""
    Dim stSUIMEDIF As String = ""
    Dim stSUIMUNPR As String = ""
    Dim stSUIMCLSE As String = ""
    Dim stSUIMCASU As String = ""
    Dim stSUIMCAPR As String = ""
    Dim stSUIMMOAD As String = ""
    Dim stSUIMESTA As String = ""

    Dim stHIAVVIGE As String = ""
    Dim stHIAVATPR As String = ""
    Dim stHIAVATCO As String = ""
    Dim stHIAVACPR As String = ""
    Dim stHIAVACCO As String = ""
    Dim stHIAVVATP As String = ""
    Dim stHIAVVATC As String = ""
    Dim stHIAVVACP As String = ""
    Dim stHIAVVACC As String = ""
    Dim stHIAVAVAL As String = ""
    Dim stHIAVESTA As String = ""
    Dim Separador As String = ""

    ' variables guardar consulta
    Dim Guardar_stSUIMNUFI As String = ""
    Dim Guardar_stSUIMDIRE As String = ""
    Dim Guardar_stSUIMMUNI As String = ""
    Dim Guardar_stSUIMCORR As String = ""
    Dim Guardar_stSUIMBARR As String = ""
    Dim Guardar_stSUIMMANZ As String = ""
    Dim Guardar_stSUIMPRED As String = ""
    Dim Guardar_stSUIMEDIF As String = ""
    Dim Guardar_stSUIMUNPR As String = ""
    Dim Guardar_stSUIMCLSE As String = ""
    Dim Guardar_stSUIMCASU As String = ""
    Dim Guardar_stSUIMCAPR As String = ""
    Dim Guardar_stSUIMMOAD As String = ""
    Dim Guardar_stSUIMESTA As String = ""
    Dim Guardar_stHIAVVIGE As String = ""
    Dim Guardar_stHIAVATPR As String = ""
    Dim Guardar_stHIAVATCO As String = ""
    Dim Guardar_stHIAVACPR As String = ""
    Dim Guardar_stHIAVACCO As String = ""
    Dim Guardar_stHIAVVATP As String = ""
    Dim Guardar_stHIAVVATC As String = ""
    Dim Guardar_stHIAVVACP As String = ""
    Dim Guardar_stHIAVVACC As String = ""
    Dim Guardar_stHIAVAVAL As String = ""
    Dim Guardar_stHIAVESTA As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtSUIMNUFI.Text = ""
        Me.txtSUIMDIRE.Text = ""
        Me.txtSUIMMUNI.Text = ""
        Me.txtSUIMCORR.Text = ""
        Me.txtSUIMBARR.Text = ""
        Me.txtSUIMMANZ.Text = ""
        Me.txtSUIMPRED.Text = ""
        Me.txtSUIMEDIF.Text = ""
        Me.txtSUIMUNPR.Text = ""
        Me.txtHIAVATPR.Text = ""
        Me.txtHIAVATCO.Text = ""
        Me.txtHIAVACPR.Text = ""
        Me.txtHIAVACCO.Text = ""
        Me.txtHIAVVATP.Text = ""
        Me.txtHIAVVATC.Text = ""
        Me.txtHIAVVACP.Text = ""
        Me.txtHIAVVACC.Text = ""
        Me.txtHIAVAVAL.Text = ""
        Me.txtHIAVTVTP.Text = ""
        Me.txtHIAVTVTC.Text = ""
        Me.txtHIAVTVCP.Text = ""
        Me.txtHIAVTVCC.Text = ""
        Me.txtHIAVTOAV.Text = ""

        Me.cboSUIMCLSE.DataSource = New DataTable
        Me.cboSUIMCAPR.DataSource = New DataTable
        Me.cboSUIMMOAD.DataSource = New DataTable
        Me.cboSUIMESTA.DataSource = New DataTable
        Me.cboHIAVVIGE.DataSource = New DataTable
        Me.cboHIAVESTA.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(txtSUIMNUFI.Text) = "" Then
            stSUIMNUFI = "%"
        Else
            stSUIMNUFI = Trim(txtSUIMNUFI.Text)
        End If

        If Trim(txtSUIMDIRE.Text) = "" Then
            stSUIMDIRE = "%"
        Else
            stSUIMDIRE = Trim(txtSUIMDIRE.Text)
        End If

        If Trim(txtSUIMMUNI.Text) = "" Then
            stSUIMMUNI = "%"
        Else
            stSUIMMUNI = Trim(txtSUIMMUNI.Text)
        End If

        If Trim(txtSUIMCORR.Text) = "" Then
            stSUIMCORR = "%"
        Else
            stSUIMCORR = Trim(txtSUIMCORR.Text)
        End If

        If Trim(txtSUIMBARR.Text) = "" Then
            stSUIMBARR = "%"
        Else
            stSUIMBARR = Trim(txtSUIMBARR.Text)
        End If

        If Trim(txtSUIMMANZ.Text) = "" Then
            stSUIMMANZ = "%"
        Else
            stSUIMMANZ = Trim(txtSUIMMANZ.Text)
        End If

        If Trim(txtSUIMPRED.Text) = "" Then
            stSUIMPRED = "%"
        Else
            stSUIMPRED = Trim(txtSUIMPRED.Text)
        End If

        If Trim(txtSUIMEDIF.Text) = "" Then
            stSUIMEDIF = "%"
        Else
            stSUIMEDIF = Trim(txtSUIMEDIF.Text)
        End If

        If Trim(txtSUIMUNPR.Text) = "" Then
            stSUIMUNPR = "%"
        Else
            stSUIMUNPR = Trim(txtSUIMUNPR.Text)
        End If

        If Trim(cboSUIMCLSE.Text) = "" Then
            stSUIMCLSE = "%"
        Else
            stSUIMCLSE = Trim(cboSUIMCLSE.SelectedValue)
        End If

        If Trim(cboSUIMCAPR.Text) = "" Then
            stSUIMCAPR = "%"
        Else
            stSUIMCAPR = Trim(cboSUIMCAPR.SelectedValue)
        End If

        If Trim(cboSUIMMOAD.Text) = "" Then
            stSUIMMOAD = "%"
        Else
            stSUIMMOAD = Trim(cboSUIMMOAD.SelectedValue)
        End If

        If Trim(cboSUIMESTA.Text) = "" Then
            stSUIMESTA = "%"
        Else
            stSUIMESTA = Trim(cboSUIMESTA.SelectedValue)
        End If

        '*** VERIFICA DATOS DE AVALUOS ***

        If Trim(Me.cboHIAVVIGE.Text) = "" Then
            stHIAVVIGE = "%"
        Else
            stHIAVVIGE = Trim(Me.cboHIAVVIGE.SelectedValue)
        End If

        If Trim(Me.txtHIAVATPR.Text) = "" Then
            stHIAVATPR = "%"
        Else
            stHIAVATPR = Trim(Me.txtHIAVATPR.Text)
        End If

        If Trim(Me.txtHIAVATCO.Text) = "" Then
            stHIAVATCO = "%"
        Else
            stHIAVATCO = Trim(Me.txtHIAVATCO.Text)
        End If

        If Trim(Me.txtHIAVACPR.Text) = "" Then
            stHIAVACPR = "%"
        Else
            stHIAVACPR = Trim(Me.txtHIAVACPR.Text)
        End If

        If Trim(Me.txtHIAVACCO.Text) = "" Then
            stHIAVACCO = "%"
        Else
            stHIAVACCO = Trim(Me.txtHIAVACCO.Text)
        End If

        If Trim(Me.txtHIAVVATP.Text) = "" Then
            stHIAVVATP = "%"
        Else
            stHIAVVATP = Trim(Me.txtHIAVVATP.Text)
        End If

        If Trim(Me.txtHIAVVATC.Text) = "" Then
            stHIAVVATC = "%"
        Else
            stHIAVVATC = Trim(Me.txtHIAVVATC.Text)
        End If

        If Trim(Me.txtHIAVVACP.Text) = "" Then
            stHIAVVACP = "%"
        Else
            stHIAVVACP = Trim(Me.txtHIAVVACP.Text)
        End If

        If Trim(Me.txtHIAVVACC.Text) = "" Then
            stHIAVVACC = "%"
        Else
            stHIAVVACC = Trim(Me.txtHIAVVACC.Text)
        End If

        If Trim(Me.txtHIAVAVAL.Text) = "" Then
            stHIAVAVAL = "%"
        Else
            stHIAVAVAL = Trim(Me.txtHIAVAVAL.Text)
        End If

        If Trim(Me.cboHIAVESTA.Text) = "" Then
            stHIAVESTA = "%"
        Else
            stHIAVESTA = Trim(Me.cboHIAVESTA.SelectedValue)
        End If

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < dgvCONSULTA.RowCount And SW = 0
                If dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos de ficha predial
                    Me.txtSUIMNUFI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())
                    Me.txtSUIMDIRE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    Me.txtSUIMMUNI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    Me.txtSUIMCORR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(3).Value.ToString())
                    Me.txtSUIMBARR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    Me.txtSUIMMANZ.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    Me.txtSUIMPRED.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    Me.txtSUIMEDIF.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    Me.txtSUIMUNPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    Me.cboSUIMCLSE.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(9).Value.ToString()
                    Me.cboSUIMCAPR.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(10).Value.ToString()
                    Me.cboSUIMMOAD.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString()
                    Me.cboSUIMESTA.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(12).Value.ToString()

                    ' llena los campos de avaluos
                    Me.cboHIAVVIGE.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(13).Value.ToString()
                    Me.txtHIAVATPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(14).Value.ToString())
                    Me.txtHIAVATCO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(15).Value.ToString())
                    Me.txtHIAVACPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(16).Value.ToString())
                    Me.txtHIAVACCO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(17).Value.ToString())
                    Me.txtHIAVVATP.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(18).Value.ToString())
                    Me.txtHIAVVATC.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(19).Value.ToString())
                    Me.txtHIAVVACP.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(20).Value.ToString())
                    Me.txtHIAVVACC.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(21).Value.ToString())
                    Me.txtHIAVAVAL.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(22).Value.ToString())
                    Me.cboHIAVESTA.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(23).Value.ToString()

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

        Guardar_stSUIMNUFI = Trim(Me.txtSUIMNUFI.Text)
        Guardar_stSUIMDIRE = Trim(Me.txtSUIMDIRE.Text)
        Guardar_stSUIMMUNI = Trim(Me.txtSUIMMUNI.Text)
        Guardar_stSUIMCORR = Trim(Me.txtSUIMCORR.Text)
        Guardar_stSUIMBARR = Trim(Me.txtSUIMBARR.Text)
        Guardar_stSUIMMANZ = Trim(Me.txtSUIMMANZ.Text)
        Guardar_stSUIMPRED = Trim(Me.txtSUIMPRED.Text)
        Guardar_stSUIMEDIF = Trim(Me.txtSUIMEDIF.Text)
        Guardar_stSUIMUNPR = Trim(Me.txtSUIMUNPR.Text)
        Guardar_stSUIMCLSE = Trim(Me.cboSUIMCLSE.SelectedValue)
        Guardar_stSUIMCAPR = Trim(Me.cboSUIMCAPR.SelectedValue)
        Guardar_stSUIMMOAD = Trim(Me.cboSUIMMOAD.SelectedValue)
        Guardar_stSUIMESTA = Trim(Me.cboSUIMESTA.SelectedValue)
        Guardar_stHIAVVIGE = Trim(Me.cboHIAVVIGE.SelectedValue)
        Guardar_stHIAVATPR = Trim(Me.txtHIAVATPR.Text)
        Guardar_stHIAVATCO = Trim(Me.txtHIAVATCO.Text)
        Guardar_stHIAVACPR = Trim(Me.txtHIAVACPR.Text)
        Guardar_stHIAVACCO = Trim(Me.txtHIAVACCO.Text)
        Guardar_stHIAVVACP = Trim(Me.txtHIAVVACP.Text)
        Guardar_stHIAVVACC = Trim(Me.txtHIAVVACC.Text)
        Guardar_stHIAVAVAL = Trim(Me.txtHIAVAVAL.Text)
        Guardar_stHIAVESTA = Trim(Me.cboHIAVESTA.SelectedValue)

    End Sub
    Private Sub pro_ObtenerConsulta()

        Me.txtSUIMNUFI.Text = Guardar_stSUIMNUFI
        Me.txtSUIMDIRE.Text = Guardar_stSUIMDIRE
        Me.txtSUIMMUNI.Text = Guardar_stSUIMMUNI
        Me.txtSUIMCORR.Text = Guardar_stSUIMCORR
        Me.txtSUIMBARR.Text = Guardar_stSUIMBARR
        Me.txtSUIMMANZ.Text = Guardar_stSUIMMANZ
        Me.txtSUIMPRED.Text = Guardar_stSUIMPRED
        Me.txtSUIMEDIF.Text = Guardar_stSUIMEDIF
        Me.txtSUIMUNPR.Text = Guardar_stSUIMUNPR

        If Guardar_stSUIMCLSE <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboSUIMCLSE, Me.cboSUIMCLSE.SelectedIndex)
        End If
        If Guardar_stSUIMCAPR <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboSUIMCAPR, Me.cboSUIMCAPR.SelectedIndex)
        End If
        If Guardar_stSUIMMOAD <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU_Descripcion(Me.cboSUIMMOAD, Me.cboSUIMMOAD.SelectedIndex)
        End If
        If Guardar_stSUIMESTA <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboSUIMESTA, Me.cboSUIMESTA.SelectedIndex)
        End If
        If Guardar_stHIAVVIGE <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboHIAVVIGE, Me.cboHIAVVIGE.SelectedIndex)
        End If
        If Guardar_stHIAVESTA <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboHIAVESTA, Me.cboHIAVESTA.SelectedIndex)
        End If

        Me.cboSUIMCLSE.SelectedValue = Guardar_stSUIMCLSE
        Me.cboSUIMCAPR.SelectedValue = Guardar_stSUIMCAPR
        Me.cboSUIMMOAD.SelectedValue = Guardar_stSUIMMOAD
        Me.cboSUIMESTA.SelectedValue = Guardar_stSUIMESTA
        Me.cboHIAVVIGE.SelectedValue = Guardar_stHIAVVIGE
        Me.cboHIAVESTA.SelectedValue = Guardar_stHIAVESTA

        Me.txtHIAVATPR.Text = Guardar_stHIAVATPR
        Me.txtHIAVATCO.Text = Guardar_stHIAVATCO
        Me.txtHIAVACPR.Text = Guardar_stHIAVACPR
        Me.txtHIAVACCO.Text = Guardar_stHIAVACCO
        Me.txtHIAVVATP.Text = Guardar_stHIAVVATP
        Me.txtHIAVVATC.Text = Guardar_stHIAVVATC
        Me.txtHIAVVACP.Text = Guardar_stHIAVVACP
        Me.txtHIAVVACC.Text = Guardar_stHIAVVACC
        Me.txtHIAVAVAL.Text = Guardar_stHIAVAVAL



    End Sub
    Private Sub pro_SumaAvaluosTotales()

        Try
            If Me.dgvCONSULTA.RowCount > 0 Then

                Dim loHIAVTVTP As Long = 0
                Dim loHIAVTVTC As Long = 0
                Dim loHIAVTVCP As Long = 0
                Dim loHIAVTVCC As Long = 0
                Dim loHIAVTOAV As Long = 0

                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    loHIAVTVTP += Double.Parse(dt.Rows(i).Item("Valor_terreno_privado"))
                    loHIAVTVTC += Double.Parse(dt.Rows(i).Item("Valor_terreno_comun"))
                    loHIAVTVCP += Double.Parse(dt.Rows(i).Item("Valor_const_privado"))
                    loHIAVTVCC += Double.Parse(dt.Rows(i).Item("Valor_const_comun"))
                    loHIAVTOAV += Double.Parse(dt.Rows(i).Item("Avalúo_total"))

                Next

                Me.txtHIAVTVTP.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(loHIAVTVTP))
                Me.txtHIAVTVTC.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(loHIAVTVTC))
                Me.txtHIAVTVCP.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(loHIAVTVCP))
                Me.txtHIAVTVCC.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(loHIAVTVCC))
                Me.txtHIAVTOAV.Text = CStr(fun_Formato_Mascara_Pesos_Enteros(loHIAVTOAV))

            Else
                Me.txtHIAVTVTP.Text = ""
                Me.txtHIAVTVTC.Text = ""
                Me.txtHIAVTVCP.Text = ""
                Me.txtHIAVTVCC.Text = ""
                Me.txtHIAVTOAV.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_FormatoDeCampos()

        Me.dgvCONSULTA.Columns("Valor_terreno_privado").DefaultCellStyle.Format = "c"
        Me.dgvCONSULTA.Columns("Valor_terreno_comun").DefaultCellStyle.Format = "c"
        Me.dgvCONSULTA.Columns("Valor_const_privado").DefaultCellStyle.Format = "c"
        Me.dgvCONSULTA.Columns("Valor_const_comun").DefaultCellStyle.Format = "c"
        Me.dgvCONSULTA.Columns("Avalúo_total").DefaultCellStyle.Format = "c"

    End Sub
    Private Sub pro_CargaListaDesplegable()

        ' carga los combobox
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboSUIMESTA, Me.cboSUIMESTA.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboSUIMCLSE, Me.cboSUIMCLSE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboSUIMCAPR, Me.cboSUIMCAPR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU_Descripcion(Me.cboSUIMMOAD, Me.cboSUIMMOAD.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboHIAVVIGE, Me.cboHIAVVIGE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboHIAVESTA, Me.cboHIAVESTA.SelectedIndex)

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
            ParametrosConsulta += "SuimNufi as Nro_Ficha, "
            ParametrosConsulta += "SuimDire as Dirección, "
            ParametrosConsulta += "SuimMuni as Municipio, "
            ParametrosConsulta += "SuimCorr as Corregimiento, "
            ParametrosConsulta += "SuimBarr as Barrio, "
            ParametrosConsulta += "SuimManz as Manzana, "
            ParametrosConsulta += "SuimPred as Predio, "
            ParametrosConsulta += "SuimEdif as Edificio, "
            ParametrosConsulta += "SuimUnpr as Unidad, "
            ParametrosConsulta += "SuimClse as Sector, "
            ParametrosConsulta += "SuimCapr as Caracteristica, "
            ParametrosConsulta += "SuimMoad as Modo_de_adqui, "
            ParametrosConsulta += "SuimEsta as Estado_sujeto, "
            ParametrosConsulta += "HiavVige as Vigencia, "
            ParametrosConsulta += "HiavAtpr as Area_terreno_privado, "
            ParametrosConsulta += "HiavAtco as Area_terreno_comun, "
            ParametrosConsulta += "HiavAcpr as Area_const_privado, "
            ParametrosConsulta += "HiavAcco as Area_const_comun, "
            ParametrosConsulta += "HiavVatp as Valor_terreno_privado, "
            ParametrosConsulta += "HiavVatc as Valor_terreno_comun, "
            ParametrosConsulta += "HiavVaCp as Valor_const_privado, "
            ParametrosConsulta += "HiavVaCc as Valor_const_comun, "
            ParametrosConsulta += "HiavAval as Avalúo_total, "
            ParametrosConsulta += "HiavEsta as Estado_avalúo "
            ParametrosConsulta += "From SujeImpu, HistAval where "
            ParametrosConsulta += "SuimNufi = HiavNufi and "
            ParametrosConsulta += "SuimNufi like '" & stSUIMNUFI & "' and "
            ParametrosConsulta += "SuimDire like '" & stSUIMDIRE & "' and "
            ParametrosConsulta += "SuimMuni like '" & stSUIMMUNI & "' and "
            ParametrosConsulta += "SuimCorr like '" & stSUIMCORR & "' and "
            ParametrosConsulta += "SuimBarr like '" & stSUIMBARR & "' and "
            ParametrosConsulta += "SuimManz like '" & stSUIMMANZ & "' and "
            ParametrosConsulta += "SuimPred like '" & stSUIMPRED & "' and "
            ParametrosConsulta += "SuimEdif like '" & stSUIMEDIF & "' and "
            ParametrosConsulta += "SuimUnpr like '" & stSUIMUNPR & "' and "
            ParametrosConsulta += "SuimClse like '" & stSUIMCLSE & "' and "
            ParametrosConsulta += "SuimCapr like '" & stSUIMCAPR & "' and "
            ParametrosConsulta += "SuimMoad like '" & stSUIMMOAD & "' and "
            ParametrosConsulta += "SuimEsta like '" & stSUIMESTA & "' and "
            ParametrosConsulta += "HIAVVIGE like '" & stHIAVVIGE & "' and "
            ParametrosConsulta += "HIAVATPR like '" & stHIAVATPR & "' and "
            ParametrosConsulta += "HIAVATCO like '" & stHIAVATCO & "' and "
            ParametrosConsulta += "HIAVACPR like '" & stHIAVACPR & "' and "
            ParametrosConsulta += "HIAVACCO like '" & stHIAVACCO & "' and "
            ParametrosConsulta += "HIAVVATP like '" & stHIAVVATP & "' and "
            ParametrosConsulta += "HIAVVATC like '" & stHIAVVATC & "' and "
            ParametrosConsulta += "HIAVVACP like '" & stHIAVVACP & "' and "
            ParametrosConsulta += "HIAVVACC like '" & stHIAVVACC & "' and "
            ParametrosConsulta += "HIAVAVAL like '" & stHIAVAVAL & "' and "
            ParametrosConsulta += "HIAVESTA like '" & stHIAVESTA & "' "
            ParametrosConsulta += "order by SuimClse,SuimMuni,SuimCorr,SuimBarr,SuimManz,SuimPred,SuimEdif,SuimUnpr"

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
                pro_SumaAvaluosTotales()
                pro_ListaDeValores()

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
                    txtSUIMNUFI.Focus()
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
        Me.txtSUIMNUFI.Focus()
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
        Me.txtSUIMNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtSUIMNUFI.Focus()

        pro_PermisoControlDeComandos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consulta_historico_de_avaluos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtSUIMNUFI.Focus()
    End Sub

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMNUFI.GotFocus, _
                                                                                                  txtSUIMDIRE.GotFocus, _
                                                                                                  txtSUIMMUNI.GotFocus, _
                                                                                                  txtSUIMCORR.GotFocus, _
                                                                                                  txtSUIMBARR.GotFocus, _
                                                                                                  txtSUIMMANZ.GotFocus, _
                                                                                                  txtSUIMPRED.GotFocus, _
                                                                                                  txtSUIMEDIF.GotFocus, _
                                                                                                  txtSUIMUNPR.GotFocus, _
 _
 _
 _
 _
 _
 _
                                                                                                  txtHIAVATPR.GotFocus, _
                                                                                                  txtHIAVATCO.GotFocus, _
                                                                                                  txtHIAVACPR.GotFocus, _
                                                                                                  txtHIAVACCO.GotFocus, _
                                                                                                  txtHIAVVATP.GotFocus, _
                                                                                                  txtHIAVVATC.GotFocus, _
                                                                                                  txtHIAVVACP.GotFocus, _
                                                                                                  txtHIAVVACC.GotFocus, _
                                                                                                  txtHIAVAVAL.GotFocus, _
                                                                                                  txtHIAVTVTP.GotFocus, _
                                                                                                  txtHIAVTVTC.GotFocus, _
                                                                                                  txtHIAVTVCP.GotFocus, _
                                                                                                  txtHIAVTVCC.GotFocus, _
                                                                                                  txtHIAVTOAV.GotFocus

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

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSUIMNUFI.KeyPress, _
                                                                                                  txtSUIMDIRE.KeyPress, _
                                                                                                  txtSUIMMUNI.KeyPress, _
                                                                                                  txtSUIMCORR.KeyPress, _
                                                                                                  txtSUIMBARR.KeyPress, _
                                                                                                  txtSUIMMANZ.KeyPress, _
                                                                                                  txtSUIMPRED.KeyPress, _
                                                                                                  txtSUIMEDIF.KeyPress, _
                                                                                                  txtSUIMUNPR.KeyPress, _
 _
 _
 _
 _
 _
 _
                                                                                                  txtHIAVATPR.KeyPress, _
                                                                                                  txtHIAVATCO.KeyPress, _
                                                                                                  txtHIAVACPR.KeyPress, _
                                                                                                  txtHIAVACCO.KeyPress, _
                                                                                                  txtHIAVVATP.KeyPress, _
                                                                                                  txtHIAVVATC.KeyPress, _
                                                                                                  txtHIAVVACP.KeyPress, _
                                                                                                  txtHIAVVACC.KeyPress, _
                                                                                                  txtHIAVAVAL.KeyPress, _
                                                                                                  txtHIAVTVTP.KeyPress, _
                                                                                                  txtHIAVTVTC.KeyPress, _
                                                                                                  txtHIAVTVCP.KeyPress, _
                                                                                                  txtHIAVTVCC.KeyPress, _
                                                                                                  txtHIAVTOAV.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtSUIMNUFI.KeyDown, txtSUIMDIRE.KeyDown, txtSUIMMUNI.KeyDown, txtSUIMCORR.KeyDown, txtSUIMBARR.KeyDown, txtSUIMMANZ.KeyDown, txtSUIMPRED.KeyDown, txtSUIMEDIF.KeyDown, txtSUIMUNPR.KeyDown, dgvCONSULTA.KeyDown, txtHIAVATPR.KeyDown, txtHIAVATCO.KeyDown, txtHIAVACPR.KeyDown, txtHIAVACCO.KeyDown
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

    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMMUNI.Validated
        If Me.txtSUIMMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMMUNI.Text) = True Then
            Me.txtSUIMMUNI.Text = fun_Formato_Mascara_3_String(Me.txtSUIMMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMCORR.Validated
        If Me.txtSUIMCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMCORR.Text) = True Then
            Me.txtSUIMCORR.Text = fun_Formato_Mascara_2_String(Me.txtSUIMCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMBARR.Validated
        If Me.txtSUIMBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMBARR.Text) = True Then
            Me.txtSUIMBARR.Text = fun_Formato_Mascara_3_String(Me.txtSUIMBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMMANZ.Validated
        If Me.txtSUIMMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMMANZ.Text) = True Then
            Me.txtSUIMMANZ.Text = fun_Formato_Mascara_3_String(Me.txtSUIMMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMPRED.Validated
        If Me.txtSUIMPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMPRED.Text) = True Then
            Me.txtSUIMPRED.Text = fun_Formato_Mascara_5_String(Me.txtSUIMPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMEDIF.Validated
        If Me.txtSUIMEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMEDIF.Text) = True Then
            Me.txtSUIMEDIF.Text = fun_Formato_Mascara_3_String(Me.txtSUIMEDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSUIMUNPR.Validated
        If Me.txtSUIMUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtSUIMUNPR.Text) = True Then
            Me.txtSUIMUNPR.Text = fun_Formato_Mascara_5_String(Me.txtSUIMUNPR.Text)
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

    Private Sub cboFIPRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSUIMESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboSUIMESTA, Me.cboSUIMESTA.SelectedIndex)
    End Sub
    Private Sub cboFIPRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSUIMCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboSUIMCLSE, Me.cboSUIMCLSE.SelectedIndex)
    End Sub
    Private Sub cboFIPRCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSUIMCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboSUIMCAPR, Me.cboSUIMCAPR.SelectedIndex)
    End Sub
    Private Sub cboFIPRMOAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSUIMMOAD.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU_Descripcion(Me.cboSUIMMOAD, Me.cboSUIMMOAD.SelectedIndex)
    End Sub
    Private Sub cboHIAVVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHIAVVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboHIAVVIGE, Me.cboHIAVVIGE.SelectedIndex)
    End Sub
    Private Sub cboHIAVESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHIAVESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboHIAVESTA, Me.cboHIAVESTA.SelectedIndex)
    End Sub

#End Region

#End Region


End Class