Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_Insertar_Cartografia_Por_Lotes

    '================================
    ' INSERTAR CARTOGRAFIA POR LOTES
    '================================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

    Private ds As New DataSet
    Private dt As New DataTable
    Private dt_1 As New DataTable

    Dim tblCONSULTA As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Insertar_Cartografia_Por_Lotes
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Insertar_Cartografia_Por_Lotes
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
    Dim stFIPRTIFI As String
    Dim inFIPRNURE As Integer

    Dim stRESODEPA As String
    Dim stRESOMUNI As String
    Dim inRESOTIRE As Integer
    Dim inRESOCLSE As Integer
    Dim inRESOVIGE As Integer
    Dim inRESORESO As Integer

    Dim stFPCAPLAN As String
    Dim stFPCAVENT As String
    Dim stFPCAVIGR As String
    Dim stFPCAESGR As String
    Dim stFPCAVUEL As String
    Dim stFPCAFAJA As String
    Dim stFPCAFOTO As String
    Dim stFPCAVIAE As String
    Dim stFPCAAMPL As String
    Dim stFPCAESAE As String
    Dim inFPCASECU As Integer

    Dim boCAMPOLLENO As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        If chkFichaPredial.Checked = True Then

            Me.txtFIPRNUFI.Text = ""
            Me.txtFIPRTIFI.Text = ""
            Me.txtFIPRDIRE.Text = ""
            Me.txtFIPRMUNI.Text = ""
            Me.txtFIPRCORR.Text = ""
            Me.txtFIPRBARR.Text = ""
            Me.txtFIPRMANZ.Text = ""
            Me.txtFIPRPRED.Text = ""
            Me.txtFIPREDIF.Text = ""
            Me.txtFIPRUNPR.Text = ""
            Me.txtFIPRCLSE.Text = ""
            Me.txtFIPRCASU.Text = ""
            Me.txtFIPRCAPR.Text = ""
            Me.txtFIPRMOAD.Text = ""
            Me.txtFIPRTIFI.Text = ""
            Me.lblFIPRCLSE.Text = ""
            Me.lblFIPRCASU.Text = ""
            Me.lblFIPRCAPR.Text = ""
            Me.lblFIPRMOAD.Text = ""

        End If
      
        If Me.chkCartografia.Checked = True Then

            Me.txtFPCAPLAN.Text = ""
            Me.txtFPCAVENT.Text = ""
            Me.txtFPCAESGR.Text = ""
            Me.txtFPCAVUEL.Text = ""
            Me.txtFPCAFAJA.Text = ""
            Me.txtFPCAFOTO.Text = ""
            Me.txtFPCAAMPL.Text = ""
            Me.txtFPCAESAE.Text = ""

        End If

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.cboFPCAVIAE.DataSource = New DataTable
        Me.cboFPCAVIGR.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        ' VERIFICA LOS CAMPOS DEL FORMULARIO

        If Trim(Me.txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        End If

        If Trim(Me.txtFIPRTIFI.Text) = "" Then
            stFIPRTIFI = "%"
        Else
            stFIPRTIFI = Trim(Me.txtFIPRTIFI.Text)
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

        If Trim(Me.txtFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        End If

        If Trim(Me.txtFIPRCASU.Text) = "" Then
            stFIPRCASU = "%"
        Else
            stFIPRCASU = Trim(Me.txtFIPRCASU.Text)
        End If

        If Trim(Me.txtFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)
        End If

        If Trim(Me.txtFIPRMOAD.Text) = "" Then
            stFIPRMOAD = "%"
        Else
            stFIPRMOAD = Trim(Me.txtFIPRMOAD.Text)
        End If

        If Trim(Me.txtFIPRTIFI.Text) = "" Then
            stFIPRTIFI = "%"
        Else
            stFIPRTIFI = Trim(Me.txtFIPRTIFI.Text)
        End If

        If Trim(Me.txtFPCAPLAN.Text) = "" Then
            stFPCAPLAN = "%"
        Else
            stFPCAPLAN = Trim(Me.txtFPCAPLAN.Text)
        End If

        If Trim(Me.txtFPCAVENT.Text) = "" Then
            stFPCAVENT = "%"
        Else
            stFPCAVENT = Trim(Me.txtFPCAVENT.Text)
        End If

        If Trim(Me.txtFPCAESGR.Text) = "" Then
            stFPCAESGR = "%"
        Else
            stFPCAESGR = Trim(Me.txtFPCAESGR.Text)
        End If

        If Trim(Me.txtFPCAVUEL.Text) = "" Then
            stFPCAVUEL = "%"
        Else
            stFPCAVUEL = Trim(Me.txtFPCAVUEL.Text)
        End If

        If Trim(Me.txtFPCAFAJA.Text) = "" Then
            stFPCAFAJA = "%"
        Else
            stFPCAFAJA = Trim(Me.txtFPCAFAJA.Text)
        End If

        If Trim(Me.txtFPCAFOTO.Text) = "" Then
            stFPCAFOTO = "%"
        Else
            stFPCAFOTO = Trim(Me.txtFPCAFOTO.Text)
        End If

        If Trim(Me.txtFPCAAMPL.Text) = "" Then
            stFPCAAMPL = "%"
        Else
            stFPCAAMPL = Trim(Me.txtFPCAAMPL.Text)
        End If

        If Trim(Me.txtFPCAESAE.Text) = "" Then
            stFPCAESAE = "%"
        Else
            stFPCAESAE = Trim(Me.txtFPCAESAE.Text)
        End If


    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < dgvCONSULTA.RowCount And SW = 0
                If dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos con el registro seleccionado
                    Me.txtFIPRNUFI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())
                    Me.txtFIPRDIRE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    Me.txtFIPRMUNI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    Me.txtFIPRCORR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(3).Value.ToString())
                    Me.txtFIPRBARR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    Me.txtFIPRMANZ.Text = Trim(dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    Me.txtFIPRPRED.Text = Trim(dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    Me.txtFIPREDIF.Text = Trim(dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    Me.txtFIPRUNPR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    Me.txtFIPRCLSE.Text = Trim(dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())
                    Me.txtFIPRCASU.Text = Trim(dgvCONSULTA.CurrentRow.Cells(10).Value.ToString())
                    Me.txtFIPRCAPR.Text = Trim(dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())
                    Me.txtFIPRMOAD.Text = Trim(dgvCONSULTA.CurrentRow.Cells(12).Value.ToString())
                    Me.txtFIPRTIFI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(13).Value.ToString())

                    ' busca la lista de valores
                    Me.lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtFIPRCLSE.Text)), String)
                    Me.lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(Me.txtFIPRCASU.Text)), String)
                    Me.lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(Me.txtFIPRCAPR.Text)), String)
                    Me.lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(Me.txtFIPRMOAD.Text)), String)

                    SW = 1
                Else
                    I = I + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_VerificaCamposLLenosCartografia()

        boCAMPOLLENO = True

        If Trim(Me.txtFPCAPLAN.Text) = "" Then
            boCAMPOLLENO = False
            MessageBox.Show("El campo " & Me.txtFPCAPLAN.AccessibleDescription & " esta vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        If Trim(Me.txtFPCAESGR.Text) = "" Then
            boCAMPOLLENO = False
            MessageBox.Show("El campo " & Me.txtFPCAESGR.AccessibleDescription & " esta vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        If Trim(Me.cboFPCAVIGR.Text) = "" Then
            boCAMPOLLENO = False
            MessageBox.Show("El campo " & Me.cboFPCAVIGR.AccessibleDescription & " esta vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        If Trim(Me.txtFPCAVUEL.Text) = "" Then
            boCAMPOLLENO = False
            MessageBox.Show("El campo " & Me.txtFPCAVUEL.AccessibleDescription & " esta vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        If Trim(Me.txtFPCAFAJA.Text) = "" Then
            boCAMPOLLENO = False
            MessageBox.Show("El campo " & Me.txtFPCAFAJA.AccessibleDescription & " esta vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        If Trim(Me.txtFPCAFOTO.Text) = "" Then
            boCAMPOLLENO = False
            MessageBox.Show("El campo " & Me.txtFPCAFOTO.AccessibleDescription & " esta vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        If Trim(Me.cboFPCAVIAE.Text) = "" Then
            boCAMPOLLENO = False
            MessageBox.Show("El campo " & Me.cboFPCAVIAE.AccessibleDescription & " esta vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        If Trim(Me.txtFPCAESAE.Text) = "" Then
            boCAMPOLLENO = False
            MessageBox.Show("El campo " & Me.txtFPCAESAE.AccessibleDescription & " esta vacio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

    End Sub
    Private Sub pro_NumeroDeSecuenciaDeRegistro()
        inFPCASECU = 0

        Dim objdatos5 As New cla_FIPRCART
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCART_X_FICHA_PREDIAL(Val(stFIPRNUFI))

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

            inFPCASECU = inFPCASECU + 1
        End If

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdEJECUTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEJECUTAR.Click

        Try
            ' verifica los campos llenos de la cartografia
            pro_VerificaCamposLLenosCartografia()

            ' verifica que cumpla la condición
            If boCAMPOLLENO = True And Me.dgvCONSULTA.RowCount > 0 Then

                ' selecciona el modo de operar
                If Me.rbdRemplazar.Checked = True Then

                    ' almacena las variables
                    stFPCAPLAN = Trim(Me.txtFPCAPLAN.Text)
                    stFPCAVENT = Trim(Me.txtFPCAVENT.Text)
                    stFPCAESGR = Trim(Me.txtFPCAESGR.Text)
                    stFPCAVIGR = Trim(Me.cboFPCAVIGR.SelectedValue)
                    stFPCAVUEL = Trim(Me.txtFPCAVUEL.Text)
                    stFPCAFAJA = Trim(Me.txtFPCAFAJA.Text)
                    stFPCAFOTO = Trim(Me.txtFPCAFOTO.Text)
                    stFPCAVIAE = Trim(Me.cboFPCAVIAE.SelectedValue)
                    stFPCAAMPL = Trim(Me.txtFPCAAMPL.Text)
                    stFPCAESAE = Trim(Me.txtFPCAESAE.Text)

                    ' declara la variable
                    Dim i As Integer = 0

                    ' recorre la tabla
                    For i = 0 To dt.Rows.Count - 1

                        ' instancia la clase
                        Dim objdatos As New cla_FICHPRED
                        Dim tbl As New DataTable

                        tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(CInt(dt.Rows(i).Item(0).ToString))

                        ' almacena las variables
                        stFIPRNUFI = Trim(tbl.Rows(0).Item("FIPRNUFI".ToString))
                        stRESODEPA = Trim(tbl.Rows(0).Item("FIPRDEPA".ToString))
                        stRESOMUNI = Trim(tbl.Rows(0).Item("FIPRMUNI".ToString))
                        inRESOTIRE = Trim(tbl.Rows(0).Item("FIPRTIRE".ToString))
                        inRESOCLSE = Trim(tbl.Rows(0).Item("FIPRCLSE".ToString))
                        inRESOVIGE = Trim(tbl.Rows(0).Item("FIPRVIGE".ToString))
                        inRESORESO = Trim(tbl.Rows(0).Item("FIPRRESO".ToString))
                        inFIPRNURE = Trim(tbl.Rows(0).Item("FIPRNURE".ToString))
                        stFIPRCLSE = Trim(tbl.Rows(0).Item("FIPRCLSE".ToString))

                        ' instancia la clase
                        Dim objdatos1 As New cla_FIPRCART

                        ' elimina el registro
                        objdatos1.fun_Eliminar_FIPRCART_X_FICHA_PREDIAL(CInt(stFIPRNUFI))

                        ' procede a buscar la secuencia
                        pro_NumeroDeSecuenciaDeRegistro()

                        ' instancia la clase
                        Dim objdatos2 As New cla_FIPRCART

                        objdatos2.fun_Insertar_FIPRCART(CInt(dt.Rows(i).Item(0).ToString), _
                                                        CStr(Trim(stFPCAPLAN)), _
                                                        CStr(Trim(stFPCAVENT)), _
                                                        CStr(Trim(stFPCAESGR)), _
                                                        CStr(Trim(stFPCAVIGR)), _
                                                        CStr(Trim(stFPCAVUEL)), _
                                                        CStr(Trim(stFPCAFAJA)), _
                                                        CStr(Trim(stFPCAFOTO)), _
                                                        CStr(Trim(stFPCAVIAE)), _
                                                        CStr(Trim(stFPCAAMPL)), _
                                                        CStr(Trim(stFPCAESAE)), _
                                                        CStr(Trim(stRESODEPA)), _
                                                        CStr(Trim(stRESOMUNI)), _
                                                        CInt(Trim(inRESOTIRE)), _
                                                        CStr(Trim(stFIPRCLSE)), _
                                                        CInt(Trim(inRESOVIGE)), _
                                                        CInt(Trim(inRESORESO)), _
                                                        CInt(Trim(inFPCASECU)), _
                                                        CInt(Trim(inFIPRNURE)), _
                                                        CStr(Trim("ac")))


                    Next

                    MessageBox.Show("Proceso termino correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                ElseIf Me.rbdAdicionar.Checked = True Then

                    ' almacena las variables
                    stFPCAPLAN = Trim(Me.txtFPCAPLAN.Text)
                    stFPCAVENT = Trim(Me.txtFPCAVENT.Text)
                    stFPCAESGR = Trim(Me.txtFPCAESGR.Text)
                    stFPCAVIGR = Trim(Me.cboFPCAVIGR.SelectedValue)
                    stFPCAVUEL = Trim(Me.txtFPCAVUEL.Text)
                    stFPCAFAJA = Trim(Me.txtFPCAFAJA.Text)
                    stFPCAFOTO = Trim(Me.txtFPCAFOTO.Text)
                    stFPCAVIAE = Trim(Me.cboFPCAVIAE.SelectedValue)
                    stFPCAAMPL = Trim(Me.txtFPCAAMPL.Text)
                    stFPCAESAE = Trim(Me.txtFPCAESAE.Text)

                    ' declara la variable
                    Dim i As Integer = 0

                    ' recorre la tabla
                    For i = 0 To dt.Rows.Count - 1

                        ' instancia la clase
                        Dim objdatos As New cla_FICHPRED
                        Dim tbl As New DataTable

                        tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(CInt(dt.Rows(i).Item(0).ToString))

                        ' almacena las variables
                        stFIPRNUFI = Trim(tbl.Rows(0).Item("FIPRNUFI".ToString))
                        stRESODEPA = Trim(tbl.Rows(0).Item("FIPRDEPA".ToString))
                        stRESOMUNI = Trim(tbl.Rows(0).Item("FIPRMUNI".ToString))
                        inRESOTIRE = Trim(tbl.Rows(0).Item("FIPRTIRE".ToString))
                        inRESOCLSE = Trim(tbl.Rows(0).Item("FIPRCLSE".ToString))
                        inRESOVIGE = Trim(tbl.Rows(0).Item("FIPRVIGE".ToString))
                        inRESORESO = Trim(tbl.Rows(0).Item("FIPRRESO".ToString))
                        inFIPRNURE = Trim(tbl.Rows(0).Item("FIPRNURE".ToString))
                        stFIPRCLSE = Trim(tbl.Rows(0).Item("FIPRCLSE".ToString))

                        ' procede a buscar la secuencia
                        pro_NumeroDeSecuenciaDeRegistro()

                        ' instancia la clase
                        Dim objdatos2 As New cla_FIPRCART

                        objdatos2.fun_Insertar_FIPRCART(CInt(dt.Rows(i).Item(0).ToString), _
                                                        CStr(Trim(stFPCAPLAN)), _
                                                        CStr(Trim(stFPCAVENT)), _
                                                        CStr(Trim(stFPCAESGR)), _
                                                        CStr(Trim(stFPCAVIGR)), _
                                                        CStr(Trim(stFPCAVUEL)), _
                                                        CStr(Trim(stFPCAFAJA)), _
                                                        CStr(Trim(stFPCAFOTO)), _
                                                        CStr(Trim(stFPCAVIAE)), _
                                                        CStr(Trim(stFPCAAMPL)), _
                                                        CStr(Trim(stFPCAESAE)), _
                                                        CStr(Trim(stRESODEPA)), _
                                                        CStr(Trim(stRESOMUNI)), _
                                                        CInt(Trim(inRESOTIRE)), _
                                                        CStr(Trim(stFIPRCLSE)), _
                                                        CInt(Trim(inRESOVIGE)), _
                                                        CInt(Trim(inRESORESO)), _
                                                        CInt(Trim(inFPCASECU)), _
                                                        CInt(Trim(inFIPRNURE)), _
                                                        CStr(Trim("ac")))


                    Next

                    MessageBox.Show("Proceso termino correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            If Me.chkPrediosSinCatografia.Checked = False Then

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

                ' verifica los datos de los campos
                pro_VerificarDatos()

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "FiprNufi as NroFicha, "
                ParametrosConsulta += "FiprDire as Direccion, "
                ParametrosConsulta += "FiprMuni as Municip, "
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
                ParametrosConsulta += "FiprTifi as TipoFicha "
                ParametrosConsulta += "From FichPred where "
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
                ParametrosConsulta += "FiprTifi like '" & stFIPRTIFI & "' "
                ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            ElseIf Me.chkPrediosSinCatografia.Checked = True Then

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

                ' verifica los datos de los campos
                pro_VerificarDatos()

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "FiprNufi as NroFicha, "
                ParametrosConsulta += "FiprDire as Direccion, "
                ParametrosConsulta += "FiprMuni as Municip, "
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
                ParametrosConsulta += "FiprTifi as TipoFicha "
                ParametrosConsulta += "From FichPred where "
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
                ParametrosConsulta += "FiprTifi like '" & stFIPRTIFI & "' and "
                ParametrosConsulta += "not exists(select 1 from fiprcart where fiprnufi = fpcanufi) "
                ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            End If

            ' cuenta los registros
            If dt.Rows.Count > 0 Then
                ' llena el datagridview
                Me.dgvCONSULTA.DataSource = dt

                ' llena la lista de valores
                pro_ListaDeValores()

                Me.cmdEJECUTAR.Enabled = True
            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

                Me.cmdEJECUTAR.Enabled = False
            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount.ToString

            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Insertar_Cartografia_Por_Lotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPCAVIGR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIGR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIGR, cboFPCAVIGR.SelectedIndex)
    End Sub
    Private Sub cboFPCAVIAE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIAE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIAE, cboFPCAVIAE.SelectedIndex)
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

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRTIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRDIRE.Focus()
        End If
    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRCORR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRBARR.Focus()
        End If
    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRMANZ.Focus()
        End If
    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRPRED.Focus()
        End If
    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPREDIF.Focus()
        End If
    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRUNPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRCASU.Focus()
        End If
    End Sub
    Private Sub txtFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCASU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRMOAD.Focus()
        End If
    End Sub
    Private Sub txtFIPRMOAD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMOAD.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdCONSULTAR.Focus()
        End If
    End Sub

    Private Sub txtFPCAPLAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAPLAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAVENT.Focus()
        End If
    End Sub
    Private Sub txtFPCAVENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAVENT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAESGR.Focus()
        End If
    End Sub
    Private Sub txtFPCAESGR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAESGR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFPCAVIGR.Focus()
        End If
    End Sub
    Private Sub cboFPCAVIGR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCAVIGR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAVUEL.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIGR, cboFPCAVIGR.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPCAVUEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAVUEL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAFAJA.Focus()
        End If
    End Sub
    Private Sub txtFPCAFAJA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAFAJA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAFOTO.Focus()
        End If
    End Sub
    Private Sub txtFPCAFOTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAFOTO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFPCAVIAE.Focus()
        End If
    End Sub
    Private Sub cboFPCAVIAE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCAVIAE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAAMPL.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIAE, cboFPCAVIAE.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPCAAMPL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAAMPL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAESAE.Focus()
        End If
    End Sub
    Private Sub txtFPCAESAE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAESAE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdEJECUTAR.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRCASU.KeyDown, txtFIPRCAPR.KeyDown, txtFIPRMOAD.KeyDown, dgvCONSULTA.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
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
    Private Sub txtFPCAPLAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAPLAN.GotFocus
        txtFPCAPLAN.SelectionStart = 0
        txtFPCAPLAN.SelectionLength = Len(txtFPCAPLAN.Text)
        strBARRESTA.Items(0).Text = txtFPCAPLAN.AccessibleDescription
    End Sub
    Private Sub txtFPCAVENT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAVENT.GotFocus
        txtFPCAVENT.SelectionStart = 0
        txtFPCAVENT.SelectionLength = Len(txtFPCAVENT.Text)
        strBARRESTA.Items(0).Text = txtFPCAVENT.AccessibleDescription
    End Sub
    Private Sub txtFPCAESGR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESGR.GotFocus
        txtFPCAESGR.SelectionStart = 0
        txtFPCAESGR.SelectionLength = Len(txtFPCAESGR.Text)
        strBARRESTA.Items(0).Text = txtFPCAESGR.AccessibleDescription
    End Sub
    Private Sub cboFPCAVIGR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIGR.GotFocus
        strBARRESTA.Items(0).Text = cboFPCAVIGR.AccessibleDescription
    End Sub
    Private Sub txtFPCAVUEL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAVUEL.GotFocus
        txtFPCAVUEL.SelectionStart = 0
        txtFPCAVUEL.SelectionLength = Len(txtFPCAVUEL.Text)
        strBARRESTA.Items(0).Text = txtFPCAVUEL.AccessibleDescription
    End Sub
    Private Sub txtFPCAFAJA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFAJA.GotFocus
        txtFPCAFAJA.SelectionStart = 0
        txtFPCAFAJA.SelectionLength = Len(txtFPCAFAJA.Text)
        strBARRESTA.Items(0).Text = txtFPCAFAJA.AccessibleDescription
    End Sub
    Private Sub txtFPCAFOTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFOTO.GotFocus
        txtFPCAFOTO.SelectionStart = 0
        txtFPCAFOTO.SelectionLength = Len(txtFPCAFOTO.Text)
        strBARRESTA.Items(0).Text = txtFPCAFOTO.AccessibleDescription
    End Sub
    Private Sub cboFPCAVIAE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIAE.GotFocus
        strBARRESTA.Items(0).Text = cboFPCAVIAE.AccessibleDescription
    End Sub
    Private Sub txtFPCAAMPL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAAMPL.GotFocus
        txtFPCAAMPL.SelectionStart = 0
        txtFPCAAMPL.SelectionLength = Len(txtFPCAAMPL.Text)
        strBARRESTA.Items(0).Text = txtFPCAAMPL.AccessibleDescription
    End Sub
    Private Sub txtFPCAESAE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESAE.GotFocus
        txtFPCAESAE.SelectionStart = 0
        txtFPCAESAE.SelectionLength = Len(txtFPCAESAE.Text)
        strBARRESTA.Items(0).Text = txtFPCAESAE.AccessibleDescription
    End Sub



    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdINSERTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEJECUTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdEJECUTAR.AccessibleDescription
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

#End Region

#Region "CheckedChanged"

    Private Sub chkPrediosSinCatografia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrediosSinCatografia.CheckedChanged

        If Me.chkPrediosSinCatografia.Checked = True Then
            Me.rbdAdicionar.Checked = True
            Me.rbdRemplazar.Enabled = False

        ElseIf Me.chkPrediosSinCatografia.Checked = False Then
            Me.rbdAdicionar.Checked = True
            Me.rbdRemplazar.Enabled = True

        End If

    End Sub

#End Region

#End Region

End Class