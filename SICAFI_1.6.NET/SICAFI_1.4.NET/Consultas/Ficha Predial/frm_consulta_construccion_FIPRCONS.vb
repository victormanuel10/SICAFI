Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_construccion_FIPRCONS

    '====================================
    ' CONSULTA CONSTRUCCION FICHA PREDIAL
    '====================================

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

    Public Shared Function instance() As frm_consulta_construccion_FIPRCONS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_construccion_FIPRCONS
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
    Dim stFIPRCASU As String
    Dim stFIPRCAPR As String
    Dim stFIPRMOAD As String
    Dim stFIPRESTA As String
    Dim stFPCOUNID As String
    Dim stFPCOCLCO As String
    Dim stFPCOTICO As String
    Dim stFPCOPUNT As String
    Dim stFPCOARCO As String
    Dim stFPCOACUE As String
    Dim stFPCOALCA As String
    Dim stFPCOENER As String
    Dim stFPCOTELE As String
    Dim stFPCOGAS As String
    Dim stFPCOMEJO As String
    Dim stFPCOLEY As String
    Dim stFPCOPISO As String
    Dim stFPCOEDCO As String
    Dim stFPCOPOCO As String
    Dim stFPCOESTA As String
    Dim Separador As String
    Dim stFPCODEPA As String

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
    Dim Guardar_stFIPRCASU As String
    Dim Guardar_stFIPRCAPR As String
    Dim Guardar_stFIPRMOAD As String
    Dim Guardar_stFIPRESTA As String
    Dim Guardar_stFPCOUNID As String
    Dim Guardar_stFPCOCLCO As String
    Dim Guardar_stFPCOTICO As String
    Dim Guardar_stFPCOPUNT As String
    Dim Guardar_stFPCOARCO As String
    Dim Guardar_stFPCOACUE As String
    Dim Guardar_stFPCOALCA As String
    Dim Guardar_stFPCOENER As String
    Dim Guardar_stFPCOTELE As String
    Dim Guardar_stFPCOGAS As String
    Dim Guardar_boFPCOMEJO As Boolean
    Dim Guardar_boFPCOLEY As Boolean
    Dim Guardar_stFPCOPISO As String
    Dim Guardar_stFPCOEDCO As String
    Dim Guardar_stFPCOPOCO As String
    Dim Guardar_stFPCOESTA As String

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        txtFIPRNUFI.Text = ""
        txtFIPRDIRE.Text = ""
        txtFIPRMUNI.Text = ""
        txtFIPRCORR.Text = ""
        txtFIPRBARR.Text = ""
        txtFIPRMANZ.Text = ""
        txtFIPRPRED.Text = ""
        txtFIPREDIF.Text = ""
        txtFIPRUNPR.Text = ""
        txtFIPRCLSE.Text = ""
        txtFIPRCASU.Text = ""
        txtFIPRCAPR.Text = ""
        txtFIPRMOAD.Text = ""
        txtFIPRESTA.Text = ""
        lblFIPRCLSE.Text = ""
        lblFIPRCASU.Text = ""
        lblFIPRCAPR.Text = ""
        lblFIPRMOAD.Text = ""
        txtFPCOUNID.Text = ""
        txtFPCOCLCO.Text = ""
        txtFPCOTICO.Text = ""
        txtFPCOPUNT.Text = ""
        txtFPCOARCO.Text = ""
        txtFPCOACUE.Text = ""
        txtFPCOALCA.Text = ""
        txtFPCOENER.Text = ""
        txtFPCOTELE.Text = ""
        txtFPCOGAS.Text = ""
        txtFPCOPISO.Text = ""
        txtFPCOEDCO.Text = ""
        txtFPCOPOCO.Text = ""
        txtFPCOESTA.Text = ""
        lblFPCOCLCO.Text = ""
        lblFPCOTICO.Text = ""
        txtRESOMUNI.Text = ""
        txtRESOTIRE.Text = ""
        txtRESOVIGE.Text = ""
        txtRESORESO.Text = ""
        chkFPCOMEJO.CheckState = CheckState.Indeterminate
        chkFPCOLEY.CheckState = CheckState.Indeterminate
        strBARRESTA.Items(2).Text = "Registros : 0"

        Dim tbl As New DataTable
        dgvCONSULTA.DataSource = tbl

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

        If Trim(txtFIPRCASU.Text) = "" Then
            stFIPRCASU = "%"
        Else
            stFIPRCASU = Trim(txtFIPRCASU.Text)
        End If

        If Trim(txtFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(txtFIPRCAPR.Text)
        End If

        If Trim(txtFIPRMOAD.Text) = "" Then
            stFIPRMOAD = "%"
        Else
            stFIPRMOAD = Trim(txtFIPRMOAD.Text)
        End If

        If Trim(txtFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(txtFIPRESTA.Text)
        End If

        '*** VERIFICA DATOS DE CONSTRUCCIÓN ***

        If Trim(txtFPCOUNID.Text) = "" Then
            stFPCOUNID = "%"
        Else
            stFPCOUNID = Trim(txtFPCOUNID.Text)
        End If

        If Trim(txtFPCOCLCO.Text) = "" Then
            stFPCOCLCO = "%"
        Else
            stFPCOCLCO = Trim(txtFPCOCLCO.Text)
        End If

        If Trim(txtFPCOTICO.Text) = "" Then
            stFPCOTICO = "%"
        Else
            stFPCOTICO = Trim(txtFPCOTICO.Text)
        End If

        If Trim(txtFPCOPUNT.Text) = "" Then
            stFPCOPUNT = "%"
        Else
            stFPCOPUNT = Trim(txtFPCOPUNT.Text)
        End If

        If Trim(txtFPCOARCO.Text) = "" Then
            stFPCOARCO = "%"
        Else
            stFPCOARCO = Trim(txtFPCOARCO.Text)
        End If

        If Trim(txtFPCOACUE.Text) = "" Then
            stFPCOACUE = "%"
        Else
            stFPCOACUE = Trim(txtFPCOACUE.Text)
        End If

        If Trim(txtFPCOALCA.Text) = "" Then
            stFPCOALCA = "%"
        Else
            stFPCOALCA = Trim(txtFPCOALCA.Text)
        End If

        If Trim(txtFPCOENER.Text) = "" Then
            stFPCOENER = "%"
        Else
            stFPCOENER = Trim(txtFPCOENER.Text)
        End If

        If Trim(txtFPCOTELE.Text) = "" Then
            stFPCOTELE = "%"
        Else
            stFPCOTELE = Trim(txtFPCOTELE.Text)
        End If

        If Trim(txtFPCOGAS.Text) = "" Then
            stFPCOGAS = "%"
        Else
            stFPCOGAS = Trim(txtFPCOGAS.Text)
        End If

        If Trim(txtFPCOPISO.Text) = "" Then
            stFPCOPISO = "%"
        Else
            stFPCOPISO = Trim(txtFPCOPISO.Text)
        End If

        If Trim(txtFPCOEDCO.Text) = "" Then
            stFPCOEDCO = "%"
        Else
            stFPCOEDCO = Trim(txtFPCOEDCO.Text)
        End If

        If Trim(txtFPCOPOCO.Text) = "" Then
            stFPCOPOCO = "%"
        Else
            stFPCOPOCO = Trim(txtFPCOPOCO.Text)
        End If

        If Trim(txtFPCOESTA.Text) = "" Then
            stFPCOESTA = "%"
        Else
            stFPCOESTA = Trim(txtFPCOESTA.Text)
        End If

        If chkFPCOMEJO.CheckState = CheckState.Indeterminate Then
            stFPCOMEJO = "%"
        ElseIf chkFPCOMEJO.Checked = False Then
            stFPCOMEJO = "0"
        ElseIf chkFPCOMEJO.Checked = True Then
            stFPCOMEJO = "1"
        End If

        If chkFPCOLEY.CheckState = CheckState.Indeterminate Then
            stFPCOLEY = "%"
        ElseIf chkFPCOLEY.Checked = False Then
            stFPCOLEY = "0"
        ElseIf chkFPCOLEY.Checked = True Then
            stFPCOLEY = "1"
        End If

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < dgvCONSULTA.RowCount And SW = 0
                If dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos de ficha predial
                    txtFIPRNUFI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())
                    txtFIPRDIRE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    txtFIPRMUNI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    txtFIPRCORR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(3).Value.ToString())
                    txtFIPRBARR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    txtFIPRMANZ.Text = Trim(dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    txtFIPRPRED.Text = Trim(dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    txtFIPREDIF.Text = Trim(dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    txtFIPRUNPR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    txtFIPRCLSE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())
                    txtFIPRCASU.Text = Trim(dgvCONSULTA.CurrentRow.Cells(10).Value.ToString())
                    txtFIPRCAPR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())
                    txtFIPRMOAD.Text = Trim(dgvCONSULTA.CurrentRow.Cells(12).Value.ToString())
                    txtFIPRESTA.Text = Trim(dgvCONSULTA.CurrentRow.Cells(13).Value.ToString())
                    txtRESOMUNI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    txtRESOTIRE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(14).Value.ToString())
                    txtRESOVIGE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(15).Value.ToString())
                    txtRESORESO.Text = Trim(dgvCONSULTA.CurrentRow.Cells(16).Value.ToString())

                    ' llena los campos de propietarios
                    txtFPCOUNID.Text = Trim(dgvCONSULTA.CurrentRow.Cells(17).Value.ToString())
                    txtFPCOCLCO.Text = Trim(dgvCONSULTA.CurrentRow.Cells(18).Value.ToString())
                    txtFPCOTICO.Text = Trim(dgvCONSULTA.CurrentRow.Cells(19).Value.ToString())
                    txtFPCOPUNT.Text = Trim(dgvCONSULTA.CurrentRow.Cells(20).Value.ToString())
                    txtFPCOARCO.Text = Trim(dgvCONSULTA.CurrentRow.Cells(21).Value.ToString())
                    txtFPCOACUE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(22).Value.ToString())
                    txtFPCOALCA.Text = Trim(dgvCONSULTA.CurrentRow.Cells(23).Value.ToString())
                    txtFPCOENER.Text = Trim(dgvCONSULTA.CurrentRow.Cells(24).Value.ToString())
                    txtFPCOTELE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(25).Value.ToString())
                    txtFPCOGAS.Text = Trim(dgvCONSULTA.CurrentRow.Cells(26).Value.ToString())
                    txtFPCOPISO.Text = Trim(dgvCONSULTA.CurrentRow.Cells(27).Value.ToString())
                    txtFPCOEDCO.Text = Trim(dgvCONSULTA.CurrentRow.Cells(28).Value.ToString())
                    txtFPCOPOCO.Text = Trim(dgvCONSULTA.CurrentRow.Cells(29).Value.ToString())
                    txtFPCOESTA.Text = Trim(dgvCONSULTA.CurrentRow.Cells(30).Value.ToString())
                    chkFPCOMEJO.Checked = dgvCONSULTA.CurrentRow.Cells(31).Value.ToString()
                    chkFPCOLEY.Checked = dgvCONSULTA.CurrentRow.Cells(32).Value.ToString()

                    ' Almacena el departamento para poder identificar la lista de valores del identificador
                    stFPCODEPA = Trim(dgvCONSULTA.CurrentRow.Cells(33).Value.ToString())

                    ' busca la lista de valores de ficha predial
                    lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCLSE.Text)), String)
                    lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(txtFIPRCASU.Text)), String)
                    lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(txtFIPRCAPR.Text)), String)
                    lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(txtFIPRMOAD.Text)), String)

                    ' busca la lista de valores de propietarios
                    lblFPCOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(txtFPCOCLCO.Text), String)
                    lblFPCOTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS(stFPCODEPA, Trim(txtRESOMUNI.Text), txtFPCOCLCO.Text, txtFIPRCLSE.Text, Trim(txtFPCOTICO.Text)), String)


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

        Guardar_stFIPRNUFI = Trim(txtFIPRNUFI.Text)
        Guardar_stFIPRDIRE = Trim(txtFIPRDIRE.Text)
        Guardar_stFIPRMUNI = Trim(txtFIPRMUNI.Text)
        Guardar_stFIPRCORR = Trim(txtFIPRCORR.Text)
        Guardar_stFIPRBARR = Trim(txtFIPRBARR.Text)
        Guardar_stFIPRMANZ = Trim(txtFIPRMANZ.Text)
        Guardar_stFIPRPRED = Trim(txtFIPRPRED.Text)
        Guardar_stFIPREDIF = Trim(txtFIPREDIF.Text)
        Guardar_stFIPRUNPR = Trim(txtFIPRUNPR.Text)
        Guardar_stFIPRCLSE = Trim(txtFIPRCLSE.Text)
        Guardar_stFIPRCASU = Trim(txtFIPRCASU.Text)
        Guardar_stFIPRCAPR = Trim(txtFIPRCAPR.Text)
        Guardar_stFIPRMOAD = Trim(txtFIPRMOAD.Text)
        Guardar_stFIPRESTA = Trim(txtFIPRESTA.Text)
        Guardar_stFPCOUNID = Trim(txtFPCOUNID.Text)
        Guardar_stFPCOCLCO = Trim(txtFPCOCLCO.Text)
        Guardar_stFPCOTICO = Trim(txtFPCOTICO.Text)
        Guardar_stFPCOPUNT = Trim(txtFPCOPUNT.Text)
        Guardar_stFPCOARCO = Trim(txtFPCOARCO.Text)
        Guardar_stFPCOACUE = Trim(txtFPCOACUE.Text)
        Guardar_stFPCOALCA = Trim(txtFPCOALCA.Text)
        Guardar_stFPCOENER = Trim(txtFPCOENER.Text)
        Guardar_stFPCOTELE = Trim(txtFPCOTELE.Text)
        Guardar_stFPCOGAS = Trim(txtFPCOGAS.Text)
        Guardar_stFPCOPISO = Trim(txtFPCOPISO.Text)
        Guardar_stFPCOEDCO = Trim(txtFPCOEDCO.Text)
        Guardar_stFPCOPOCO = Trim(txtFPCOPOCO.Text)
        Guardar_stFPCOESTA = Trim(txtFPCOESTA.Text)
        Guardar_boFPCOMEJO = chkFPCOMEJO.Checked
        Guardar_boFPCOLEY = chkFPCOLEY.Checked

    End Sub
    Private Sub pro_ObtenerConsulta()

        txtFIPRNUFI.Text = Guardar_stFIPRNUFI
        txtFIPRDIRE.Text = Guardar_stFIPRDIRE
        txtFIPRMUNI.Text = Guardar_stFIPRMUNI
        txtFIPRCORR.Text = Guardar_stFIPRCORR
        txtFIPRBARR.Text = Guardar_stFIPRBARR
        txtFIPRMANZ.Text = Guardar_stFIPRMANZ
        txtFIPRPRED.Text = Guardar_stFIPRPRED
        txtFIPREDIF.Text = Guardar_stFIPREDIF
        txtFIPRUNPR.Text = Guardar_stFIPRUNPR
        txtFIPRCLSE.Text = Guardar_stFIPRCLSE
        txtFIPRCASU.Text = Guardar_stFIPRCASU
        txtFIPRCAPR.Text = Guardar_stFIPRCAPR
        txtFIPRMOAD.Text = Guardar_stFIPRMOAD
        txtFIPRESTA.Text = Guardar_stFIPRESTA
        txtFPCOUNID.Text = Guardar_stFPCOUNID
        txtFPCOCLCO.Text = Guardar_stFPCOCLCO
        txtFPCOTICO.Text = Guardar_stFPCOTICO
        txtFPCOPUNT.Text = Guardar_stFPCOPUNT
        txtFPCOARCO.Text = Guardar_stFPCOARCO
        txtFPCOACUE.Text = Guardar_stFPCOACUE
        txtFPCOALCA.Text = Guardar_stFPCOALCA
        txtFPCOENER.Text = Guardar_stFPCOENER
        txtFPCOTELE.Text = Guardar_stFPCOTELE
        txtFPCOGAS.Text = Guardar_stFPCOGAS
        txtFPCOPISO.Text = Guardar_stFPCOPISO
        txtFPCOEDCO.Text = Guardar_stFPCOEDCO
        txtFPCOPOCO.Text = Guardar_stFPCOPOCO
        txtFPCOESTA.Text = Guardar_stFPCOESTA
        chkFPCOMEJO.Checked = Guardar_boFPCOMEJO
        chkFPCOLEY.Checked = Guardar_boFPCOLEY
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
            ' propiedad del boton
            Me.cmdCONSULTAR.Enabled = False

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
            ParametrosConsulta += "FiprNufi as NroFicha, "
            ParametrosConsulta += "FiprDire as Direccion, "
            ParametrosConsulta += "FiprMuni as Municio, "
            ParametrosConsulta += "FiprCorr as Corregi, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as UnidPred, "
            ParametrosConsulta += "FiprClse as Sector, "
            ParametrosConsulta += "FiprCasu as CateSuel, "
            ParametrosConsulta += "FiprCapr as CaraPred, "
            ParametrosConsulta += "FiprMoad as ModoAdqu, "
            ParametrosConsulta += "FiprEsta as Estado, "
            ParametrosConsulta += "FiprTire as TipoReso, "
            ParametrosConsulta += "FiprVige as Vigencia, "
            ParametrosConsulta += "FiprReso as Resoluci, "
            ParametrosConsulta += "FpcoUnid as NroCons, "
            ParametrosConsulta += "FpcoClco as ClaseCons, "
            ParametrosConsulta += "FpcoTico as Identificador, "
            ParametrosConsulta += "FpcoPunt as Puntos, "
            ParametrosConsulta += "FpcoArco as AreaConst, "
            ParametrosConsulta += "FpcoAcue as Acueducto, "
            ParametrosConsulta += "FpcoAlca as Alcantari, "
            ParametrosConsulta += "FpcoEner as Energia, "
            ParametrosConsulta += "FpcoTele as Telefono, "
            ParametrosConsulta += "FpcoGas as Gas, "
            ParametrosConsulta += "FpcoPiso as NroPisos, "
            ParametrosConsulta += "FpcoEdco as EdadConst, "
            ParametrosConsulta += "FpcoPoco as PorcenConst, "
            ParametrosConsulta += "FpcoEsta as Estado, "
            ParametrosConsulta += "FpcoMejo as Mejora, "
            ParametrosConsulta += "FpcoLey as Ley56, "
            ParametrosConsulta += "FpcoDepa as Departamento "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
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
            ParametrosConsulta += "FpcoUnid like '" & stFPCOUNID & "' and "
            ParametrosConsulta += "FpcoClco like '" & stFPCOCLCO & "' and "
            ParametrosConsulta += "FpcoTico like '" & stFPCOTICO & "' and "
            ParametrosConsulta += "FpcoPunt like '" & stFPCOPUNT & "' and "
            ParametrosConsulta += "FpcoArco like '" & stFPCOARCO & "' and "
            ParametrosConsulta += "FpcoAcue like '" & stFPCOACUE & "' and "
            ParametrosConsulta += "FpcoAlca like '" & stFPCOALCA & "' and "
            ParametrosConsulta += "FpcoEner like '" & stFPCOENER & "' and "
            ParametrosConsulta += "FpcoTele like '" & stFPCOTELE & "' and "
            ParametrosConsulta += "FpcoGas like '" & stFPCOGAS & "' and "
            ParametrosConsulta += "FpcoPiso like '" & stFPCOPISO & "' and "
            ParametrosConsulta += "FpcoEdco like '" & stFPCOEDCO & "' and "
            ParametrosConsulta += "FpcoPoco like '" & stFPCOPOCO & "' and "
            ParametrosConsulta += "FpcoEsta like '" & stFPCOESTA & "' and "
            ParametrosConsulta += "FpcoMejo like '" & stFPCOMEJO & "' and "
            ParametrosConsulta += "FpcoLey like '" & stFPCOLEY & "' "
            ParametrosConsulta += "order by FiprNufi,FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            ' cuenta los registros
            If dt.Rows.Count > 0 Then
                ' llena el datagridview
                If dt.Rows.Count > 500 Then
                    ' controla la sobregarga del datagridview
                    If MessageBox.Show("La consulta sobrecargara el sistema" & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "Nro. de registros para cargar :  " & dt.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' llena el datagridview
                        dgvCONSULTA.DataSource = dt
                    Else
                        ' sale del proceso de consulta
                        Exit Sub
                    End If
                End If

                ' llena el datagridview
                dgvCONSULTA.DataSource = dt

                ' Coloca la mascara del campo
                txtFPCOARCO.Text = CType(fun_Formato_Decimal_2_Decimales(Trim(txtFPCOARCO.Text)), String)

                ' oculta las columnas del datagridview
                dgvCONSULTA.Columns(33).Visible = False

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

            ' propiedad del boton
            Me.cmdCONSULTAR.Enabled = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdULTIMACONSULTA.Click
        pro_LimpiarCampos()
        pro_ObtenerConsulta()
        cmdCONSULTAR.Focus()
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        txtFPCOUNID.Focus()
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
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFPCOUNID.Focus()
        Me.Close()
    End Sub
    Private Sub cmdCALIFICACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCALIFICACION.Click
        If Trim(txtFIPRNUFI.Text) <> "" And Trim(txtFPCOUNID.Text) <> "" Then
            Dim frm_consulta_calificacion_FIPRCACO As New frm_consulta_calificacion_FIPRCACO(txtFIPRNUFI.Text, Trim(txtFPCOUNID.Text))
            frm_consulta_calificacion_FIPRCACO.ShowDialog()
        Else
            MessageBox.Show("Seleccione una construcción", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
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

#Region "Load"

    Private Sub frm_consulta_construccion_FIPRCONS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        txtFPCOUNID.Focus()

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
    Private Sub txtFIPRCASU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCASU.GotFocus
        txtFIPRCASU.SelectionStart = 0
        txtFIPRCASU.SelectionLength = Len(txtFIPRCASU.Text)
        strBARRESTA.Items(0).Text = txtFIPRCASU.AccessibleDescription
    End Sub
    Private Sub txtFIPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.GotFocus
        txtFIPRCAPR.SelectionStart = 0
        txtFIPRCAPR.SelectionLength = Len(txtFIPRCAPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMOAD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.GotFocus
        txtFIPRMOAD.SelectionStart = 0
        txtFIPRMOAD.SelectionLength = Len(txtFIPRMOAD.Text)
        strBARRESTA.Items(0).Text = txtFIPRMOAD.AccessibleDescription
    End Sub
    Private Sub txtFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRESTA.GotFocus
        txtFIPRESTA.SelectionStart = 0
        txtFIPRESTA.SelectionLength = Len(txtFIPRESTA.Text)
        strBARRESTA.Items(0).Text = txtFIPRESTA.AccessibleDescription
    End Sub
    Private Sub txtFPCOUNID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOUNID.GotFocus
        txtFPCOUNID.SelectionStart = 0
        txtFPCOUNID.SelectionLength = Len(txtFPCOUNID.Text)
        strBARRESTA.Items(0).Text = txtFPCOUNID.AccessibleDescription
    End Sub
    Private Sub txtFPCOCLCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOCLCO.GotFocus
        txtFPCOCLCO.SelectionStart = 0
        txtFPCOCLCO.SelectionLength = Len(txtFPCOCLCO.Text)
        strBARRESTA.Items(0).Text = txtFPCOCLCO.AccessibleDescription
    End Sub
    Private Sub txtFPCOTICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOTICO.GotFocus
        txtFPCOTICO.SelectionStart = 0
        txtFPCOTICO.SelectionLength = Len(txtFPCOTICO.Text)
        strBARRESTA.Items(0).Text = txtFPCOTICO.AccessibleDescription
    End Sub
    Private Sub txtFPCOPUNT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOPUNT.GotFocus
        txtFPCOPUNT.SelectionStart = 0
        txtFPCOPUNT.SelectionLength = Len(txtFPCOPUNT.Text)
        strBARRESTA.Items(0).Text = txtFPCOPUNT.AccessibleDescription
    End Sub
    Private Sub txtFPCOARCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOARCO.GotFocus
        txtFPCOARCO.SelectionStart = 0
        txtFPCOARCO.SelectionLength = Len(txtFPCOARCO.Text)
        strBARRESTA.Items(0).Text = txtFPCOARCO.AccessibleDescription
    End Sub
    Private Sub txtFPCOACUE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOACUE.GotFocus
        txtFPCOACUE.SelectionStart = 0
        txtFPCOACUE.SelectionLength = Len(txtFPCOACUE.Text)
        strBARRESTA.Items(0).Text = txtFPCOACUE.AccessibleDescription
    End Sub
    Private Sub txtFPCOALCA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOALCA.GotFocus
        txtFPCOALCA.SelectionStart = 0
        txtFPCOALCA.SelectionLength = Len(txtFPCOALCA.Text)
        strBARRESTA.Items(0).Text = txtFPCOALCA.AccessibleDescription
    End Sub
    Private Sub txtFPCOENER_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOENER.GotFocus
        txtFPCOENER.SelectionStart = 0
        txtFPCOENER.SelectionLength = Len(txtFPCOENER.Text)
        strBARRESTA.Items(0).Text = txtFPCOENER.AccessibleDescription
    End Sub
    Private Sub txtFPCOTELE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOTELE.GotFocus
        txtFPCOTELE.SelectionStart = 0
        txtFPCOTELE.SelectionLength = Len(txtFPCOTELE.Text)
        strBARRESTA.Items(0).Text = txtFPCOTELE.AccessibleDescription
    End Sub
    Private Sub txtFPCOGAS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOGAS.GotFocus
        txtFPCOGAS.SelectionStart = 0
        txtFPCOGAS.SelectionLength = Len(txtFPCOGAS.Text)
        strBARRESTA.Items(0).Text = txtFPCOGAS.AccessibleDescription
    End Sub
    Private Sub txtFPCOPISO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOPISO.GotFocus
        txtFPCOPISO.SelectionStart = 0
        txtFPCOPISO.SelectionLength = Len(txtFPCOPISO.Text)
        strBARRESTA.Items(0).Text = txtFPCOPISO.AccessibleDescription
    End Sub
    Private Sub txtFPCOEDCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOEDCO.GotFocus
        txtFPCOEDCO.SelectionStart = 0
        txtFPCOEDCO.SelectionLength = Len(txtFPCOEDCO.Text)
        strBARRESTA.Items(0).Text = txtFPCOEDCO.AccessibleDescription
    End Sub
    Private Sub txtFPCOPOCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOPOCO.GotFocus
        txtFPCOPOCO.SelectionStart = 0
        txtFPCOPOCO.SelectionLength = Len(txtFPCOPOCO.Text)
        strBARRESTA.Items(0).Text = txtFPCOPOCO.AccessibleDescription
    End Sub
    Private Sub chkFPCOMEJO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFPCOMEJO.GotFocus
        strBARRESTA.Items(0).Text = chkFPCOMEJO.AccessibleDescription
    End Sub
    Private Sub chkFPCOLEY_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFPCOLEY.GotFocus
        strBARRESTA.Items(0).Text = chkFPCOLEY.AccessibleDescription
    End Sub
    Private Sub txtFPCOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOESTA.GotFocus
        txtFPCOESTA.SelectionStart = 0
        txtFPCOESTA.SelectionLength = Len(txtFPCOESTA.Text)
        strBARRESTA.Items(0).Text = txtFPCOESTA.AccessibleDescription
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
            txtFIPRCASU.Focus()
        End If
    End Sub
    Private Sub txtFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCASU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMOAD.Focus()
        End If
    End Sub
    Private Sub txtFIPRMOAD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMOAD.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFPCOUNID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOUNID.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOCLCO.Focus()
        End If
    End Sub
    Private Sub txtFPCOCLCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOCLCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOTICO.Focus()
        End If
    End Sub
    Private Sub txtFPCOTICO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOTICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOPUNT.Focus()
        End If
    End Sub
    Private Sub txtFPCOPUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOPUNT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOARCO.Focus()
        End If
    End Sub
    Private Sub txtFPCOARCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOARCO.KeyPress
        If fun_Verificar_Dato_Decimal_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
            e.Handled = True
        ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOACUE.Focus()
        End If
    End Sub
    Private Sub txtFPCOACUE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOACUE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOALCA.Focus()
        End If
    End Sub
    Private Sub txtFPCOALCA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOALCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOENER.Focus()
        End If
    End Sub
    Private Sub txtFPCOENER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOENER.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOTELE.Focus()
        End If
    End Sub
    Private Sub txtFPCOTELE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOTELE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOGAS.Focus()
        End If
    End Sub
    Private Sub txtFPCOGAS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOGAS.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOPISO.Focus()
        End If
    End Sub
    Private Sub txtFPCOPISO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOPISO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOEDCO.Focus()
        End If
    End Sub
    Private Sub txtFPCOEDCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOEDCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOPOCO.Focus()
        End If
    End Sub
    Private Sub txtFPCOPOCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOPOCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkFPCOMEJO.Focus()
        End If
    End Sub
    Private Sub chkFPCOMEJO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkFPCOMEJO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkFPCOLEY.Focus()
        End If
    End Sub
    Private Sub chkFPCOLEY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkFPCOLEY.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOESTA.Focus()
        End If
    End Sub
    Private Sub txtFPCOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRNUFI.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRCASU.KeyDown, txtFIPRCAPR.KeyDown, txtFIPRMOAD.KeyDown, txtFIPRESTA.KeyDown, dgvCONSULTA.KeyDown, txtFPCOUNID.KeyDown, txtFPCOCLCO.KeyDown, txtFPCOTICO.KeyDown, txtFPCOPUNT.KeyDown, txtFPCOARCO.KeyDown, txtFPCOALCA.KeyDown, txtFPCOACUE.KeyDown, txtFPCOENER.KeyDown, txtFPCOTELE.KeyDown, txtFPCOGAS.KeyDown, txtFPCOPISO.KeyDown, txtFPCOEDCO.KeyDown, txtFPCOPOCO.KeyDown, txtFPCOESTA.KeyDown, chkFPCOLEY.KeyDown, chkFPCOMEJO.KeyDown
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

    Private Sub txtFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.Validated
        If Trim(txtFIPRCLSE.Text) = "" Then
            lblFIPRCLSE.Text = ""
        Else
            lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCLSE.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRCASU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCASU.Validated
        If Trim(txtFIPRCASU.Text) = "" Then
            lblFIPRCASU.Text = ""
        Else
            lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(txtFIPRCASU.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.Validated
        If Trim(txtFIPRCAPR.Text) = "" Then
            lblFIPRCAPR.Text = ""
        Else
            lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(txtFIPRCAPR.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRMOAD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.Validated
        If Trim(txtFIPRMOAD.Text) = "" Then
            lblFIPRMOAD.Text = ""
        Else
            lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(txtFIPRMOAD.Text)), String)
        End If
    End Sub
    Private Sub txtFPCOCLCO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOCLCO.Validated
        If Trim(txtFPCOCLCO.Text) = "" Then
            lblFPCOCLCO.Text = ""
        Else
            lblFPCOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(txtFPCOCLCO.Text), String)
        End If
    End Sub
    Private Sub txtFPCOTICO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOTICO.Validated
        If Trim(txtFPCOTICO.Text) = "" Then
            lblFPCOTICO.Text = ""
        Else
            lblFPCOTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS(stFPCODEPA, Trim(txtRESOMUNI.Text), txtFPCOCLCO.Text, txtFIPRCLSE.Text, Trim(txtFPCOTICO.Text)), String)
        End If
    End Sub
    Private Sub txtFPCOARCO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOARCO.Validated
        If Trim(txtFPCOARCO.Text) <> "" Then
            If Val(txtFPCOARCO.Text) >= 0 Then
                txtFPCOARCO.Text = CType(fun_Formato_Decimal_2_Decimales(txtFPCOARCO.Text.ToString), String)
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