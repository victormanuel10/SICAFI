Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_historico_de_liquidacion

    '=========================================
    '*** CONSULTA HISTORICO DE LIQUIDACION ***
    '=========================================

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

    Public Shared Function instance() As frm_consulta_historico_de_liquidacion
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_historico_de_liquidacion
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

    Dim stHILIVIGE As String = ""
    Dim stHILIAVPR As String = ""
    Dim stHILIAVCA As String = ""
    Dim stHILIDEEC As String = ""
    Dim stHILIESTR As String = ""
    Dim stHILILOTE As String = ""
    Dim stHILILOCE As String = ""
    Dim stHILILE44 As String = ""
    Dim stHILILE56 As String = ""
    Dim stHILIAUAV As String = ""
    Dim stHILIESTA As String = ""
    Dim stHILITIPO As String = ""
    Dim stHILIARCO As String = ""
    Dim stHILIARTE As String = ""
    Dim stHILIPUCA As String = ""
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
    Dim Guardar_stHILIVIGE As String = ""
    Dim Guardar_stHILIAVPR As String = ""
    Dim Guardar_stHILIAVCA As String = ""
    Dim Guardar_stHILIDEEC As String = ""
    Dim Guardar_stHILIESTR As String = ""
    Dim Guardar_boHILILOTE As Boolean
    Dim Guardar_boHILILOCE As Boolean
    Dim Guardar_boHILILE44 As Boolean
    Dim Guardar_boHILILE56 As Boolean
    Dim Guardar_boHILIAUAV As Boolean
    Dim Guardar_stHILITIPO As String = ""
    Dim Guardar_stHILIARCO As String = ""
    Dim Guardar_stHILIARTE As String = ""
    Dim Guardar_stHILIPUCA As String = ""
    Dim Guardar_stHILIESTA As String = ""

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
        Me.txtHILIAVPR.Text = ""
        Me.txtHILIAVCA.Text = ""
        Me.txtHILIARCO.Text = ""
        Me.txtHILIARTE.Text = ""
        Me.txtHILIPUCA.Text = ""

        Me.cboFIPRCLSE.DataSource = New DataTable
        Me.cboFIPRCASU.DataSource = New DataTable
        Me.cboFIPRCAPR.DataSource = New DataTable
        Me.cboFIPRMOAD.DataSource = New DataTable
        Me.cboFIPRESTA.DataSource = New DataTable
        Me.cboHILIVIGE.DataSource = New DataTable
        Me.cboHILIESTA.DataSource = New DataTable
        Me.cboHILIDEEC.DataSource = New DataTable
        Me.cboHILIESTR.DataSource = New DataTable
        Me.cboHILITIPO.DataSource = New DataTable

        Me.chkHILILOTE.CheckState = CheckState.Indeterminate
        Me.chkHILILOCE.CheckState = CheckState.Indeterminate
        Me.chkHILILE44.CheckState = CheckState.Indeterminate
        Me.chkHILILE56.CheckState = CheckState.Indeterminate
        Me.chkHILIAUAV.CheckState = CheckState.Indeterminate

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

        If Trim(Me.cboHILIVIGE.Text) = "" Then
            stHILIVIGE = "%"
        Else
            stHILIVIGE = Trim(Me.cboHILIVIGE.SelectedValue)
        End If

        If Trim(Me.txtHILIAVPR.Text) = "" Then
            stHILIAVPR = "%"
        Else
            stHILIAVPR = Trim(Me.txtHILIAVPR.Text)
        End If

        If Trim(Me.txtHILIAVCA.Text) = "" Then
            stHILIAVCA = "%"
        Else
            stHILIAVCA = Trim(Me.txtHILIAVCA.Text)
        End If

        If Trim(Me.cboHILIDEEC.Text) = "" Then
            stHILIDEEC = "%"
        Else
            stHILIDEEC = Trim(Me.cboHILIDEEC.SelectedValue)
        End If

        If Trim(Me.cboHILIESTR.Text) = "" Then
            stHILIESTR = "%"
        Else
            stHILIESTR = Trim(Me.cboHILIESTR.SelectedValue)
        End If

        If Trim(Me.cboHILITIPO.Text) = "" Then
            stHILITIPO = "%"
        Else
            stHILITIPO = Trim(Me.cboHILITIPO.SelectedValue)
        End If

        If Me.chkHILILOTE.CheckState = CheckState.Indeterminate Then
            stHILILOTE = "%"
        ElseIf Me.chkHILILOTE.Checked = False Then
            stHILILOTE = "0"
        ElseIf Me.chkHILILOTE.Checked = True Then
            stHILILOTE = "1"
        End If

        If Me.chkHILILOCE.CheckState = CheckState.Indeterminate Then
            stHILILOCE = "%"
        ElseIf Me.chkHILILOCE.Checked = False Then
            stHILILOCE = "0"
        ElseIf Me.chkHILILOCE.Checked = True Then
            stHILILOCE = "1"
        End If

        If Me.chkHILILE44.CheckState = CheckState.Indeterminate Then
            stHILILE44 = "%"
        ElseIf Me.chkHILILE44.Checked = False Then
            stHILILE44 = "0"
        ElseIf Me.chkHILILE44.Checked = True Then
            stHILILE44 = "1"
        End If

        If Me.chkHILILE56.CheckState = CheckState.Indeterminate Then
            stHILILE56 = "%"
        ElseIf Me.chkHILILE56.Checked = False Then
            stHILILE56 = "0"
        ElseIf Me.chkHILILE56.Checked = True Then
            stHILILE56 = "1"
        End If

        If Me.chkHILIAUAV.CheckState = CheckState.Indeterminate Then
            stHILIAUAV = "%"
        ElseIf Me.chkHILIAUAV.Checked = False Then
            stHILIAUAV = "0"
        ElseIf Me.chkHILIAUAV.Checked = True Then
            stHILIAUAV = "1"
        End If

        If Trim(Me.txtHILIARCO.Text) = "" Then
            stHILIARCO = "%"
        Else
            stHILIARCO = Trim(Me.txtHILIARCO.Text)
        End If

        If Trim(Me.txtHILIARTE.Text) = "" Then
            stHILIARTE = "%"
        Else
            stHILIARTE = Trim(Me.txtHILIARTE.Text)
        End If

        If Trim(Me.txtHILIPUCA.Text) = "" Then
            stHILIPUCA = "%"
        Else
            stHILIPUCA = Trim(Me.txtHILIPUCA.Text)
        End If

        If Trim(Me.cboHILIESTA.Text) = "" Then
            stHILIESTA = "%"
        Else
            stHILIESTA = Trim(Me.cboHILIESTA.SelectedValue)
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
                    Me.cboHILIVIGE.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(14).Value.ToString()
                    Me.txtHILIAVPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(15).Value.ToString())
                    Me.txtHILIAVCA.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(16).Value.ToString())
                    Me.cboHILIDEEC.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(17).Value.ToString()

                    If fun_Buscar_Dato_ESTRATO(Me.dgvCONSULTA.CurrentRow.Cells(18).Value.ToString()) = True Then
                        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboHILIESTR, Me.cboHILIESTR.SelectedIndex)
                        Me.cboHILIESTR.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(18).Value.ToString()
                    Else
                        Me.cboHILIESTR.DataSource = New DataTable
                    End If

                    If fun_Buscar_Dato_TIPOCALI(Me.dgvCONSULTA.CurrentRow.Cells(19).Value.ToString()) = True Then
                        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboHILITIPO, Me.cboHILITIPO.SelectedIndex)
                        Me.cboHILITIPO.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(19).Value.ToString()
                    Else
                        Me.cboHILITIPO.DataSource = New DataTable
                    End If

                    Me.chkHILILOTE.Checked = Me.dgvCONSULTA.CurrentRow.Cells(20).Value
                    Me.chkHILILOCE.Checked = Me.dgvCONSULTA.CurrentRow.Cells(21).Value
                    Me.chkHILILE44.Checked = Me.dgvCONSULTA.CurrentRow.Cells(22).Value
                    Me.chkHILILE56.Checked = Me.dgvCONSULTA.CurrentRow.Cells(23).Value
                    Me.chkHILIAUAV.Checked = Me.dgvCONSULTA.CurrentRow.Cells(24).Value
                    Me.txtHILIARCO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(25).Value.ToString())
                    Me.txtHILIARTE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(26).Value.ToString())
                    Me.txtHILIPUCA.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(27).Value.ToString())
                    Me.cboHILIESTA.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(28).Value.ToString()

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
        Guardar_stHILIVIGE = Trim(Me.cboHILIVIGE.SelectedValue)
        Guardar_stHILIAVCA = Trim(Me.txtHILIAVCA.Text)
        Guardar_stHILIAVPR = Trim(Me.txtHILIAVPR.Text)
        Guardar_stHILIDEEC = Trim(Me.cboHILIDEEC.SelectedValue)
        Guardar_stHILIESTR = Trim(Me.cboHILIESTR.SelectedValue)
        Guardar_stHILITIPO = Trim(Me.cboHILITIPO.SelectedValue)
        Guardar_boHILILOTE = Trim(Me.chkHILILOTE.Checked)
        Guardar_boHILILOCE = Trim(Me.chkHILILOCE.Checked)
        Guardar_boHILILE44 = Trim(Me.chkHILILE44.Checked)
        Guardar_boHILILE56 = Trim(Me.chkHILILE56.Checked)
        Guardar_boHILIAUAV = Trim(Me.chkHILIAUAV.Checked)
        Guardar_stHILIARCO = Trim(Me.txtHILIARCO.Text)
        Guardar_stHILIARTE = Trim(Me.txtHILIARTE.Text)
        Guardar_stHILIPUCA = Trim(Me.txtHILIPUCA.Text)
        Guardar_stHILIESTA = Trim(Me.cboHILIESTA.SelectedValue)

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
        If Guardar_stHILIVIGE <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboHILIVIGE, Me.cboHILIVIGE.SelectedIndex)
        End If
        If Guardar_stHILIDEEC <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboHILIDEEC, Me.cboHILIDEEC.SelectedIndex)
        End If
        If Guardar_stHILIESTR <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboHILIESTR, Me.cboHILIESTR.SelectedIndex)
        End If
        If Guardar_stHILITIPO <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboHILITIPO, Me.cboHILITIPO.SelectedIndex)
        End If
        If Guardar_stHILIESTA <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboHILIESTA, Me.cboHILIESTA.SelectedIndex)
        End If

        Me.cboFIPRCLSE.SelectedValue = Guardar_stFIPRCLSE
        Me.cboFIPRCASU.SelectedValue = Guardar_stFIPRCASU
        Me.cboFIPRCAPR.SelectedValue = Guardar_stFIPRCAPR
        Me.cboFIPRMOAD.SelectedValue = Guardar_stFIPRMOAD
        Me.cboFIPRESTA.SelectedValue = Guardar_stFIPRESTA
        Me.cboHILIVIGE.SelectedValue = Guardar_stHILIVIGE
        Me.cboHILIDEEC.SelectedValue = Guardar_stHILIDEEC
        Me.cboHILIESTR.SelectedValue = Guardar_stHILIESTR
        Me.cboHILITIPO.SelectedValue = Guardar_stHILITIPO
        Me.cboHILIESTA.SelectedValue = Guardar_stHILIESTA

        Me.txtHILIAVPR.Text = Guardar_stHILIAVPR
        Me.txtHILIAVCA.Text = Guardar_stHILIAVCA
        Me.txtHILIARCO.Text = Guardar_stHILIARCO
        Me.txtHILIARTE.Text = Guardar_stHILIARTE
        Me.txtHILIPUCA.Text = Guardar_stHILIPUCA
        Me.txtHILIPUCA.Text = Guardar_stHILIPUCA


    End Sub
    Private Sub pro_FormatoDeCampos()

        Me.dgvCONSULTA.Columns("Avaluo_predial").DefaultCellStyle.Format = "c"
        Me.dgvCONSULTA.Columns("Avaluo_catastral").DefaultCellStyle.Format = "c"

    End Sub
    Private Sub pro_CargaListaDesplegable()

        ' carga los combobox
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboFIPRESTA, Me.cboFIPRESTA.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFIPRCLSE, Me.cboFIPRCLSE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL_Descripcion(Me.cboFIPRCASU, Me.cboFIPRCASU.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboFIPRCAPR, Me.cboFIPRCAPR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU_Descripcion(Me.cboFIPRMOAD, Me.cboFIPRMOAD.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboHILIVIGE, Me.cboHILIVIGE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboHILIDEEC, Me.cboHILIDEEC.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboHILIESTR, Me.cboHILIESTR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboHILITIPO, Me.cboHILITIPO.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboHILIESTA, Me.cboHILIESTA.SelectedIndex)

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
            ParametrosConsulta += "HiliVige as Vigencia, "
            ParametrosConsulta += "HiliAvpr as Avaluo_predial, "
            ParametrosConsulta += "HiliAvca as Avaluo_catastral, "
            ParametrosConsulta += "HiliDeec as Destinacion, "
            ParametrosConsulta += "HiliEstr as Estrato, "
            ParametrosConsulta += "HiliTipo as Tipo, "
            ParametrosConsulta += "HiliLote as Lote, "
            ParametrosConsulta += "HiliLoce as Lote_cercado, "
            ParametrosConsulta += "HiliLe44 as Ley_44, "
            ParametrosConsulta += "HiliLe56 as Ley_56, "
            ParametrosConsulta += "HiliAuav as Autoavaluo, "
            ParametrosConsulta += "HiliArco as Area_construccion, "
            ParametrosConsulta += "HiliArte as Area_terreno, "
            ParametrosConsulta += "HiliPunt as Puntos, "
            ParametrosConsulta += "HiliEsta as Estado "
            ParametrosConsulta += "From FichPred, HistLiqu where "
            ParametrosConsulta += "FiprNufi = HiliNufi and "
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
            ParametrosConsulta += "HiliVIGE like '" & stHILIVIGE & "' and "
            ParametrosConsulta += "HiliAVPR like '" & stHILIAVPR & "' and "
            ParametrosConsulta += "HiliAVCA like '" & stHILIAVCA & "' and "
            ParametrosConsulta += "HiliDEEC like '" & stHILIDEEC & "%' and "
            ParametrosConsulta += "HiliESTR like '" & stHILIESTR & "%' and "
            ParametrosConsulta += "HiliTIPO like '" & stHILITIPO & "%' and "
            ParametrosConsulta += "HiliLOTE like '" & stHILILOTE & "' and "
            ParametrosConsulta += "HiliLOCE like '" & stHILILOCE & "' and "
            ParametrosConsulta += "HiliLE44 like '" & stHILILE44 & "' and "
            ParametrosConsulta += "HiliLE56 like '" & stHILILE56 & "' and "
            ParametrosConsulta += "HiliAUAV like '" & stHILIAUAV & "' and "
            ParametrosConsulta += "HiliARCO like '" & stHILIARCO & "' and "
            ParametrosConsulta += "HiliARTE like '" & stHILIARTE & "' and "
            ParametrosConsulta += "HiliPUNT like '" & stHILIPUCA & "' and "
            ParametrosConsulta += "HiliESTA like '" & stHILIESTA & "' "
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
                                                                                                  txtHILIAVPR.GotFocus, _
                                                                                                  txtHILIAVCA.GotFocus, _
                                                                                                  txtHILIARCO.GotFocus, _
                                                                                                  txtHILIARTE.GotFocus, _
                                                                                                  txtHILIPUCA.GotFocus

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
                                                                                                  txtHILIAVPR.KeyPress, _
                                                                                                  txtHILIAVCA.KeyPress, _
                                                                                                  txtHILIARCO.KeyPress, _
                                                                                                  txtHILIARTE.KeyPress, _
                                                                                                  txtHILIPUCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, dgvCONSULTA.KeyDown, txtHILIAVPR.KeyDown, txtHILIAVCA.KeyDown
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
    Private Sub cboHiliVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHILIVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboHILIVIGE, Me.cboHILIVIGE.SelectedIndex)
    End Sub
    Private Sub cboHiliDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHILIDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboHILIDEEC, Me.cboHILIDEEC.SelectedIndex)
    End Sub
    Private Sub cboHiliESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHILIESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboHILIESTR, Me.cboHILIESTR.SelectedIndex)
    End Sub
    Private Sub cboHiliTIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHILITIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboHILITIPO, Me.cboHILITIPO.SelectedIndex)
    End Sub
    Private Sub cboHiliESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHILIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboHILIESTA, Me.cboHILIESTA.SelectedIndex)
    End Sub

#End Region

#End Region

  
End Class