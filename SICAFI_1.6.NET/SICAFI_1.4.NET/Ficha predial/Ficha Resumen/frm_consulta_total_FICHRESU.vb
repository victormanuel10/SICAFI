Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_total_FICHRESU

    '=============================
    ' CONSULTA TOTAL FICHA RESUMEN
    '=============================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    Dim tblCONSULTA As New DataTable

#End Region

#Region "VARIABLES LOCALES"

    Dim stFIPRNUFI As String
    Dim stFIPRDESC As String
    Dim stFIPRCONJ As String
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
    Dim stFIPRMUAN As String
    Dim stFIPRCOAN As String
    Dim stFIPRBAAN As String
    Dim stFIPRMAAN As String
    Dim stFIPRPRAN As String
    Dim stFIPREDAN As String
    Dim stFIPRUPAN As String
    Dim stFIPRCSAN As String
    Dim stFIPRCASA As String
    Dim stFIPRCAPR As String
    Dim stFIPRESTA As String
    Dim stFIPRATLO As String
    Dim stFIPRACLO As String
    Dim stFIPRAPLO As String
    Dim stFIPRTOED As String
    Dim stFIPRUNCO As String
    Dim stFIPRURPH As String
    Dim stFIPRAPCA As String
    Dim stFIPRLOCA As String
    Dim stFIPRCUUT As String
    Dim stFIPRGACU As String
    Dim stFIPRGADE As String
    Dim stFIPRPISO As String
    Dim stFIPRTIFI As String

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRTIFI.Text = ""
        Me.txtFIPRDESC.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.chkFIPRCONJ.CheckState = CheckState.Indeterminate
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.cboFIPRCLSE.Text = ""
        Me.cboFIPRCASU.Text = ""
        Me.txtFIPRMUAN.Text = ""
        Me.txtFIPRCOAN.Text = ""
        Me.txtFIPRBAAN.Text = ""
        Me.txtFIPRMAAN.Text = ""
        Me.txtFIPRPRAN.Text = ""
        Me.txtFIPREDAN.Text = ""
        Me.txtFIPRUPAN.Text = ""
        Me.cboFIPRCSAN.Text = ""
        Me.cboFIPRCASA.Text = ""
        Me.cboFIPRCAPR.Text = ""
        Me.cboFIPRESTA.Text = ""
        Me.lblFIPRCAPR.Text = ""
        Me.lblFIPRCASA.Text = ""
        Me.lblFIPRCASU.Text = ""
        Me.lblFIPRCLSE.Text = ""
        Me.lblFIPRCSAN.Text = ""
        Me.txtFIPRATLO.Text = ""
        Me.txtFIPRACLO.Text = ""
        Me.txtFIPRAPLO.Text = ""
        Me.txtFIPRTOED.Text = ""
        Me.txtFIPRUNCO.Text = ""
        Me.txtFIPRURPH.Text = ""
        Me.txtFIPRAPCA.Text = ""
        Me.txtFIPRLOCA.Text = ""
        Me.txtFIPRCUUT.Text = ""
        Me.txtFIPRGACU.Text = ""
        Me.txtFIPRGADE.Text = ""
        Me.txtFIPRPISO.Text = ""

        Dim tbl As New DataTable
        dgvCONSULTA.DataSource = tbl


    End Sub
    Private Sub pro_VerificarDatos()

        If Trim(txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(txtFIPRNUFI.Text)
        End If

        If Trim(txtFIPRDESC.Text) = "" Then
            stFIPRDESC = "%"
        Else
            stFIPRDESC = Trim(txtFIPRDESC.Text)
        End If

        If chkFIPRCONJ.CheckState = CheckState.Indeterminate Then
            stFIPRCONJ = "%"
        ElseIf chkFIPRCONJ.Checked = False Then
            stFIPRCONJ = "0"
        ElseIf chkFIPRCONJ.Checked = True Then
            stFIPRCONJ = "1"
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

        If Trim(cboFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(cboFIPRCLSE.Text)
        End If

        If Trim(cboFIPRCASU.Text) = "" Then
            stFIPRCASU = "%"
        Else
            stFIPRCASU = Trim(cboFIPRCASU.Text)
        End If

        If Trim(txtFIPRMUAN.Text) = "" Then
            stFIPRMUAN = "%"
        Else
            stFIPRMUAN = Trim(txtFIPRMUAN.Text)
        End If

        If Trim(txtFIPRCOAN.Text) = "" Then
            stFIPRCOAN = "%"
        Else
            stFIPRCOAN = Trim(txtFIPRCOAN.Text)
        End If

        If Trim(txtFIPRBAAN.Text) = "" Then
            stFIPRBAAN = "%"
        Else
            stFIPRBAAN = Trim(txtFIPRBAAN.Text)
        End If

        If Trim(txtFIPRMAAN.Text) = "" Then
            stFIPRMAAN = "%"
        Else
            stFIPRMAAN = Trim(txtFIPRMAAN.Text)
        End If

        If Trim(txtFIPRPRAN.Text) = "" Then
            stFIPRPRAN = "%"
        Else
            stFIPRPRAN = Trim(txtFIPRPRAN.Text)
        End If

        If Trim(txtFIPREDAN.Text) = "" Then
            stFIPREDAN = "%"
        Else
            stFIPREDAN = Trim(txtFIPREDAN.Text)
        End If

        If Trim(txtFIPRUPAN.Text) = "" Then
            stFIPRUPAN = "%"
        Else
            stFIPRUPAN = Trim(txtFIPRUPAN.Text)
        End If

        If Trim(cboFIPRCSAN.Text) = "" Then
            stFIPRCSAN = "%"
        Else
            stFIPRCSAN = Trim(cboFIPRCSAN.Text)
        End If

        If Trim(cboFIPRCASA.Text) = "" Then
            stFIPRCASA = "%"
        Else
            stFIPRCASA = Trim(cboFIPRCASA.Text)
        End If

        If Trim(cboFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(cboFIPRCAPR.Text)
        End If

        If Trim(cboFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(cboFIPRESTA.Text)
        End If

        If Trim(txtFIPRATLO.Text) = "" Then
            stFIPRATLO = "%"
        Else
            stFIPRATLO = Trim(txtFIPRATLO.Text)
        End If

        If Trim(txtFIPRACLO.Text) = "" Then
            stFIPRACLO = "%"
        Else
            stFIPRACLO = Trim(txtFIPRACLO.Text)
        End If

        If Trim(txtFIPRAPLO.Text) = "" Then
            stFIPRAPLO = "%"
        Else
            stFIPRAPLO = Trim(txtFIPRAPLO.Text)
        End If

        If Trim(txtFIPRTOED.Text) = "" Then
            stFIPRTOED = "%"
        Else
            stFIPRTOED = Trim(txtFIPRTOED.Text)
        End If

        If Trim(txtFIPRUNCO.Text) = "" Then
            stFIPRUNCO = "%"
        Else
            stFIPRUNCO = Trim(txtFIPRUNCO.Text)
        End If

        If Trim(txtFIPRURPH.Text) = "" Then
            stFIPRURPH = "%"
        Else
            stFIPRURPH = Trim(txtFIPRURPH.Text)
        End If

        If Trim(txtFIPRAPCA.Text) = "" Then
            stFIPRAPCA = "%"
        Else
            stFIPRAPCA = Trim(txtFIPRAPCA.Text)
        End If

        If Trim(txtFIPRLOCA.Text) = "" Then
            stFIPRLOCA = "%"
        Else
            stFIPRLOCA = Trim(txtFIPRLOCA.Text)
        End If

        If Trim(txtFIPRCUUT.Text) = "" Then
            stFIPRCUUT = "%"
        Else
            stFIPRCUUT = Trim(txtFIPRCUUT.Text)
        End If

        If Trim(txtFIPRGACU.Text) = "" Then
            stFIPRGACU = "%"
        Else
            stFIPRGACU = Trim(txtFIPRGACU.Text)
        End If

        If Trim(txtFIPRGADE.Text) = "" Then
            stFIPRGADE = "%"
        Else
            stFIPRGADE = Trim(txtFIPRGADE.Text)
        End If

        If Trim(txtFIPRPISO.Text) = "" Then
            stFIPRPISO = "%"
        Else
            stFIPRPISO = Trim(txtFIPRPISO.Text)
        End If

        If Trim(txtFIPRTIFI.Text) = "" Then
            stFIPRTIFI = "%"
        Else
            stFIPRTIFI = Trim(txtFIPRTIFI.Text)
        End If


    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < dgvCONSULTA.RowCount And SW = 0
                If dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' selecciona el numero de ficha 
                    txtFIPRNUFI.Text = Trim(dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())

                    ' llena los campos de la ficha predial

                    Dim objdatos15 As New cla_FICHPRED
                    Dim tbl_FICHPRED As New DataTable

                    tbl_FICHPRED = objdatos15.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(Val(txtFIPRNUFI.Text))

                    txtFIPRNUFI.Text = Trim(tbl_FICHPRED.Rows(0).Item(1))
                    'txtFIPRVIGE.Text = Trim(tbl_FICHPRED.Rows(0).Item(2))
                    'txtFIPRTIRE.Text = Trim(tbl_FICHPRED.Rows(0).Item(3))
                    'txtFIPRRESO.Text = Trim(tbl_FICHPRED.Rows(0).Item(4))
                    txtFIPRDIRE.Text = Trim(tbl_FICHPRED.Rows(0).Item(5))
                    txtFIPRDESC.Text = Trim(tbl_FICHPRED.Rows(0).Item(6))
                    chkFIPRCONJ.Checked = tbl_FICHPRED.Rows(0).Item(7)
                    'txtFIPRFECH.Text = Trim(tbl_FICHPRED.Rows(0).Item(8))
                    'txtFIPRNURE.Text = Trim(tbl_FICHPRED.Rows(0).Item(9))
                    'txtFIPRDEPA.Text = Trim(tbl_FICHPRED.Rows(0).Item(10))
                    txtFIPRMUNI.Text = Trim(tbl_FICHPRED.Rows(0).Item(11))
                    txtFIPRCORR.Text = Trim(tbl_FICHPRED.Rows(0).Item(12))
                    txtFIPRBARR.Text = Trim(tbl_FICHPRED.Rows(0).Item(13))
                    txtFIPRMANZ.Text = Trim(tbl_FICHPRED.Rows(0).Item(14))
                    txtFIPRPRED.Text = Trim(tbl_FICHPRED.Rows(0).Item(15))
                    txtFIPREDIF.Text = Trim(tbl_FICHPRED.Rows(0).Item(16))
                    txtFIPRUNPR.Text = Trim(tbl_FICHPRED.Rows(0).Item(17))
                    cboFIPRCLSE.Text = Trim(tbl_FICHPRED.Rows(0).Item(18))
                    cboFIPRCASU.Text = Trim(tbl_FICHPRED.Rows(0).Item(19))
                    txtFIPRMUAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(20))
                    txtFIPRCOAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(21))
                    txtFIPRBAAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(22))
                    txtFIPRMAAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(23))
                    txtFIPRPRAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(24))
                    txtFIPREDAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(25))
                    txtFIPRUPAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(26))
                    cboFIPRCSAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(27))
                    cboFIPRCASA.Text = Trim(tbl_FICHPRED.Rows(0).Item(28))
                    cboFIPRCAPR.Text = Trim(tbl_FICHPRED.Rows(0).Item(29))
                    'cboFIPRMOAD.Text = Trim(tbl_FICHPRED.Rows(0).Item(30))
                    'txtFIPRARTE.Text = Trim(tbl_FICHPRED.Rows(0).Item(31))
                    'txtFIPRCOPR.Text = Trim(tbl_FICHPRED.Rows(0).Item(32))
                    'txtFIPRCOED.Text = Trim(tbl_FICHPRED.Rows(0).Item(33))
                    cboFIPRESTA.Text = tbl_FICHPRED.Rows(0).Item(34)
                    'txtFIPRCECA.Text = Trim(tbl_FICHPRED.Rows(0).Item(35))
                    'txtFIPRDATR.Text = Trim(tbl_FICHPRED.Rows(0).Item(36))
                    'txtFIPRDAVI.Text = Trim(tbl_FICHPRED.Rows(0).Item(37))
                    'txtFIPRDAND.Text = Trim(tbl_FICHPRED.Rows(0).Item(38))
                    'txtFIPRCORE.Text = Trim(tbl_FICHPRED.Rows(0).Item(39))
                    'txtFIPRUSIN.Text = Trim(tbl_FICHPRED.Rows(0).Item(40))
                    'txtFIPRUSMO.Text = Trim(tbl_FICHPRED.Rows(0).Item(41))
                    'txtFIPRFEIN.Text = Trim(tbl_FICHPRED.Rows(0).Item(42))
                    'txtFIPRFEMO.Text = Trim(tbl_FICHPRED.Rows(0).Item(43))
                    'txtFIPRMAQU.Text = Trim(tbl_FICHPRED.Rows(0).Item(44))
                    'txtFIPROBSE.Text = Trim(tbl_FICHPRED.Rows(0).Item(45))
                    'chkFIPRLITI.Checked = tbl_FICHPRED.Rows(0).Item(46)
                    'txtFIPRPOLI.Text = Trim(tbl_FICHPRED.Rows(0).Item(47))
                    Me.txtFIPRTIFI.Text = Trim(tbl_FICHPRED.Rows(0).Item(48))
                    'chkFIPRINCO.Checked = tbl_FICHPRED.Rows(0).Item(49)
                    Me.txtFIPRATLO.Text = Trim(tbl_FICHPRED.Rows(0).Item(51))
                    Me.txtFIPRACLO.Text = Trim(tbl_FICHPRED.Rows(0).Item(52))
                    Me.txtFIPRAPLO.Text = Trim(tbl_FICHPRED.Rows(0).Item(53))
                    Me.txtFIPRTOED.Text = Trim(tbl_FICHPRED.Rows(0).Item(54))
                    Me.txtFIPRUNCO.Text = Trim(tbl_FICHPRED.Rows(0).Item(55))
                    Me.txtFIPRURPH.Text = Trim(tbl_FICHPRED.Rows(0).Item(56))
                    Me.txtFIPRAPCA.Text = Trim(tbl_FICHPRED.Rows(0).Item(57))
                    Me.txtFIPRLOCA.Text = Trim(tbl_FICHPRED.Rows(0).Item(58))
                    Me.txtFIPRCUUT.Text = Trim(tbl_FICHPRED.Rows(0).Item(59))
                    Me.txtFIPRGACU.Text = Trim(tbl_FICHPRED.Rows(0).Item(60))
                    Me.txtFIPRGADE.Text = Trim(tbl_FICHPRED.Rows(0).Item(61))
                    Me.txtFIPRPISO.Text = Trim(tbl_FICHPRED.Rows(0).Item(62))

                    ' busca la lista de valores
                    lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(cboFIPRCLSE.Text)), String)
                    lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(cboFIPRCASU.Text)), String)
                    lblFIPRCSAN.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(cboFIPRCSAN.Text)), String)
                    lblFIPRCASA.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(cboFIPRCASA.Text)), String)
                    lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(cboFIPRCAPR.Text)), String)
                 
                    SW = 1
                Else
                    I = I + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.Click
        Try
            ' si la consulta se realiza con el numero de ficha
            If Trim(txtFIPRNUFI.Text) <> "" Then

                Dim objdatos As New cla_FICHPRED
                Dim tbl As New DataTable

                tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(Val(txtFIPRNUFI.Text))

                If tbl.Rows.Count > 0 Then

                    If tbl.Rows(0).Item("FIPRTIFI") = 1 Or tbl.Rows(0).Item("FIPRTIFI") = 2 Then

                        Dim frm_FICHRESU As New frm_FICHRESU(Val(txtFIPRNUFI.Text))
                        pro_LimpiarCampos()

                        txtFIPRNUFI.Focus()
                        Me.Close()
                    Else
                        txtFIPRNUFI.Focus()
                        MessageBox.Show("El registro consultado NO es ficha resumen 1 ó 2.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                    End If
                Else
                    txtFIPRNUFI.Focus()
                    mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                End If
            Else
                ' si la consulta se realiza por seleccion en el datagrid
                If Integer.Parse(dgvCONSULTA.CurrentRow.Cells(0).Value.ToString) = 1 Or Integer.Parse(dgvCONSULTA.CurrentRow.Cells(0).Value.ToString) = 2 Then

                    If dgvCONSULTA.RowCount > 0 Then
                        Dim frm_FICHRESU As New frm_FICHRESU(Integer.Parse(dgvCONSULTA.CurrentRow.Cells(0).Value.ToString))
                        pro_LimpiarCampos()

                        txtFIPRNUFI.Focus()
                        Me.Close()
                    Else
                        txtFIPRNUFI.Focus()
                        mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                    End If

                Else
                    txtFIPRNUFI.Focus()
                    MessageBox.Show("El registro consultado NO es ficha resumen 1 ó 2.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
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

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi as NroFicha, "
            ParametrosConsulta += "FiprMuni as Municipio, "
            ParametrosConsulta += "FiprCorr as Corregi, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as UnidPred, "
            ParametrosConsulta += "FiprClse as Sector, "
            ParametrosConsulta += "FiprTifi as TipoFicha "
            ParametrosConsulta += "From FichPred where FiprTifi in('1','2') and "
            ParametrosConsulta += "FiprNufi like '" & stFIPRNUFI & "' and "
            ParametrosConsulta += "FiprDire like '" & stFIPRDIRE & "' and "
            ParametrosConsulta += "FiprDesc like '" & stFIPRDESC & "' and "
            ParametrosConsulta += "FiprConj like '" & stFIPRCONJ & "' and "
            ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FiprEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "FiprUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprCasu like '" & stFIPRCASU & "' and "
            ParametrosConsulta += "FiprMuan like '" & stFIPRMUAN & "' and "
            ParametrosConsulta += "FiprCoan like '" & stFIPRCOAN & "' and "
            ParametrosConsulta += "FiprBaan like '" & stFIPRBAAN & "' and "
            ParametrosConsulta += "FiprMaan like '" & stFIPRMAAN & "' and "
            ParametrosConsulta += "FiprPran like '" & stFIPRPRAN & "' and "
            ParametrosConsulta += "FiprEdan like '" & stFIPREDAN & "' and "
            ParametrosConsulta += "FiprUpan like '" & stFIPRUPAN & "' and "
            ParametrosConsulta += "FiprCsan like '" & stFIPRCSAN & "' and "
            ParametrosConsulta += "FiprCasa like '" & stFIPRCASA & "' and "
            ParametrosConsulta += "FiprCapr like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "FiprAtlo like '" & stFIPRATLO & "' and "
            ParametrosConsulta += "FiprAclo like '" & stFIPRACLO & "' and "
            ParametrosConsulta += "FiprAplo like '" & stFIPRAPLO & "' and "
            ParametrosConsulta += "FiprToed like '" & stFIPRTOED & "' and "
            ParametrosConsulta += "FiprUnco like '" & stFIPRUNCO & "' and "
            ParametrosConsulta += "FiprUrph like '" & stFIPRURPH & "' and "
            ParametrosConsulta += "FiprApca like '" & stFIPRAPCA & "' and "
            ParametrosConsulta += "FiprLoca like '" & stFIPRLOCA & "' and "
            ParametrosConsulta += "FiprCuut like '" & stFIPRCUUT & "' and "
            ParametrosConsulta += "FiprGacu like '" & stFIPRGACU & "' and "
            ParametrosConsulta += "FiprGade like '" & stFIPRGADE & "' and "
            ParametrosConsulta += "FiprPiso like '" & stFIPRPISO & "' and "
            ParametrosConsulta += "FiprTifi like '" & stFIPRTIFI & "' and "
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' "
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

            ' llena el datagridview
            If dt.Rows.Count > 0 Then
                ' control de sobrecarga
                If dt.Rows.Count > 500 Then
                    If MessageBox.Show("La consulta puede sobrecargar el sistema ¿ desea continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        dgvCONSULTA.DataSource = dt

                        ' llena la lista de valores
                        pro_ListaDeValores()
                        dgvCONSULTA.Focus()
                    End If
                Else
                    dgvCONSULTA.DataSource = dt

                    ' llena la lista de valores
                    pro_ListaDeValores()
                    dgvCONSULTA.Focus()
                End If
            Else
                Dim tbl_Limpiar As New DataTable
                dgvCONSULTA.DataSource = tbl_Limpiar
                dgvCONSULTA.Focus()
                mod_MENSAJE.Consulta_No_Encontro_Registros()
            End If

            ' cuenta los registros
            strBARRESTA.Items(2).Text = "Nro. registros : " & dgvCONSULTA.RowCount

            dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        txtFIPRNUFI.Focus()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim frm_FICHRESU As New frm_FICHRESU(0)
        txtFIPRNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_total_FICHPRED_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmdACEPTAR.Enabled = False
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If Trim(txtFIPRNUFI.Text) = "" Then
                txtFIPRTIFI.Focus()
            Else
                cmdACEPTAR.Focus()
            End If
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDESC.Focus()
        End If
    End Sub
    Private Sub txtFIPRDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDIRE.Focus()
        End If
    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkFIPRCONJ.Focus()
        End If
    End Sub
    Private Sub chkFIPRCONJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkFIPRCONJ.KeyPress
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
            cboFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub cboFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCASU.Focus()
        End If
    End Sub
    Private Sub cboFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCASU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMUAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCOAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRCOAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCOAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBAAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRBAAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBAAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMAAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRMAAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMAAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRPRAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDAN.Focus()
        End If
    End Sub
    Private Sub txtFIPREDAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUPAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRUPAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUPAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCSAN.Focus()
        End If
    End Sub
    Private Sub cboFIPRCSAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCSAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub cboFIPRCASA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCASA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub cboFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRESTA.Focus()
        End If
    End Sub


    Private Sub cboFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRATLO.Focus()
        End If
    End Sub
    Private Sub txtFIPRATLO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRATLO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRACLO.Focus()
        End If
    End Sub
    Private Sub txtFIPRACLO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRACLO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRAPLO.Focus()
        End If
    End Sub
    Private Sub txtFIPRAPLO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRAPLO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRTOED.Focus()
        End If
    End Sub
    Private Sub txtFIPRTOED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTOED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUNCO.Focus()
        End If
    End Sub
    Private Sub txtFIPRUNCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRURPH.Focus()
        End If
    End Sub
    Private Sub txtFIPRURPH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRURPH.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRAPCA.Focus()
        End If
    End Sub
    Private Sub txtFIPRAPCA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRAPCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRLOCA.Focus()
        End If
    End Sub
    Private Sub txtFIPRLOCA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRLOCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCUUT.Focus()
        End If
    End Sub
    Private Sub txtFIPRCUUT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCUUT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRGACU.Focus()
        End If
    End Sub
    Private Sub txtFIPRGACU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRGACU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRGADE.Focus()
        End If
    End Sub
    Private Sub txtFIPRGADE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRGADE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPISO.Focus()
        End If
    End Sub
    Private Sub txtFIPRPISO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPISO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub



#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRTIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.GotFocus
        strBARRESTA.Items(0).Text = txtFIPRTIFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDESC.GotFocus
        txtFIPRDESC.SelectionStart = 0
        txtFIPRDESC.SelectionLength = Len(txtFIPRDESC.Text)
        strBARRESTA.Items(0).Text = txtFIPRDESC.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription
    End Sub
    Private Sub chkFIPRCONJ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFIPRCONJ.GotFocus
        strBARRESTA.Items(0).Text = chkFIPRCONJ.AccessibleDescription
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
    Private Sub cboFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub cboFIPRCASU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCASU.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUAN.GotFocus
        txtFIPRMUAN.SelectionStart = 0
        txtFIPRMUAN.SelectionLength = Len(txtFIPRMUAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRCOAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOAN.GotFocus
        txtFIPRCOAN.SelectionStart = 0
        txtFIPRCOAN.SelectionLength = Len(txtFIPRCOAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRCOAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRBAAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBAAN.GotFocus
        txtFIPRBAAN.SelectionStart = 0
        txtFIPRBAAN.SelectionLength = Len(txtFIPRBAAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRBAAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRMAAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMAAN.GotFocus
        txtFIPRMAAN.SelectionStart = 0
        txtFIPRMAAN.SelectionLength = Len(txtFIPRMAAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRMAAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRAN.GotFocus
        txtFIPRPRAN.SelectionStart = 0
        txtFIPRPRAN.SelectionLength = Len(txtFIPRPRAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRAN.AccessibleDescription
    End Sub
    Private Sub txtFIPREDAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDAN.GotFocus
        txtFIPREDAN.SelectionStart = 0
        txtFIPREDAN.SelectionLength = Len(txtFIPREDAN.Text)
        strBARRESTA.Items(0).Text = txtFIPREDAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRUPAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUPAN.GotFocus
        txtFIPRUPAN.SelectionStart = 0
        txtFIPRUPAN.SelectionLength = Len(txtFIPRUPAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRUPAN.AccessibleDescription
    End Sub
    Private Sub cboFIPRCSAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCSAN.AccessibleDescription
    End Sub
    Private Sub cboFIPRCASA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCASA.AccessibleDescription
    End Sub
    Private Sub cboFIPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub cboFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRESTA.AccessibleDescription
    End Sub
    Private Sub txtFIPRATLO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRATLO.GotFocus
        txtFIPRATLO.SelectionStart = 0
        txtFIPRATLO.SelectionLength = Len(txtFIPRATLO.Text)
        strBARRESTA.Items(0).Text = txtFIPRATLO.AccessibleDescription
    End Sub
    Private Sub txtFIPRACLO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRACLO.GotFocus
        txtFIPRACLO.SelectionStart = 0
        txtFIPRACLO.SelectionLength = Len(txtFIPRACLO.Text)
        strBARRESTA.Items(0).Text = txtFIPRACLO.AccessibleDescription
    End Sub
    Private Sub txtFIPRAPLO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRAPLO.GotFocus
        txtFIPRAPLO.SelectionStart = 0
        txtFIPRAPLO.SelectionLength = Len(txtFIPRAPLO.Text)
        strBARRESTA.Items(0).Text = txtFIPRAPLO.AccessibleDescription
    End Sub
    Private Sub txtFIPRTOED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTOED.GotFocus
        txtFIPRTOED.SelectionStart = 0
        txtFIPRTOED.SelectionLength = Len(txtFIPRTOED.Text)
        strBARRESTA.Items(0).Text = txtFIPRTOED.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNCO.GotFocus
        txtFIPRUNCO.SelectionStart = 0
        txtFIPRUNCO.SelectionLength = Len(txtFIPRUNCO.Text)
        strBARRESTA.Items(0).Text = txtFIPRUNCO.AccessibleDescription
    End Sub
    Private Sub txtFIPRURPH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRURPH.GotFocus
        txtFIPRURPH.SelectionStart = 0
        txtFIPRURPH.SelectionLength = Len(txtFIPRURPH.Text)
        strBARRESTA.Items(0).Text = txtFIPRURPH.AccessibleDescription
    End Sub
    Private Sub txtFIPRAPCA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRAPCA.GotFocus
        txtFIPRAPCA.SelectionStart = 0
        txtFIPRAPCA.SelectionLength = Len(txtFIPRAPCA.Text)
        strBARRESTA.Items(0).Text = txtFIPRAPCA.AccessibleDescription
    End Sub
    Private Sub txtFIPRLOCA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRLOCA.GotFocus
        txtFIPRLOCA.SelectionStart = 0
        txtFIPRLOCA.SelectionLength = Len(txtFIPRLOCA.Text)
        strBARRESTA.Items(0).Text = txtFIPRLOCA.AccessibleDescription
    End Sub
    Private Sub txtFIPRCUUT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCUUT.GotFocus
        txtFIPRCUUT.SelectionStart = 0
        txtFIPRCUUT.SelectionLength = Len(txtFIPRCUUT.Text)
        strBARRESTA.Items(0).Text = txtFIPRCUUT.AccessibleDescription
    End Sub
    Private Sub txtFIPRGACU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRGACU.GotFocus
        txtFIPRGACU.SelectionStart = 0
        txtFIPRGACU.SelectionLength = Len(txtFIPRGACU.Text)
        strBARRESTA.Items(0).Text = txtFIPRGACU.AccessibleDescription
    End Sub
    Private Sub txtFIPRGADE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRGADE.GotFocus
        txtFIPRGADE.SelectionStart = 0
        txtFIPRGADE.SelectionLength = Len(txtFIPRGADE.Text)
        strBARRESTA.Items(0).Text = txtFIPRGADE.AccessibleDescription
    End Sub
    Private Sub txtFIPRPISO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPISO.GotFocus
        txtFIPRPISO.SelectionStart = 0
        txtFIPRPISO.SelectionLength = Len(txtFIPRPISO.Text)
        strBARRESTA.Items(0).Text = txtFIPRPISO.AccessibleDescription
    End Sub
    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdACEPTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdACEPTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdACEPTAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub dgvCONSULTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        strBARRESTA.Items(0).Text = dgvCONSULTA.AccessibleDescription
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub dgvCONSULTA_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.DoubleClick
        cmdACEPTAR.PerformClick()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, cboFIPRCLSE.KeyDown, cboFIPRCASU.KeyDown, cboFIPRCAPR.KeyDown, cboFIPRESTA.KeyDown, dgvCONSULTA.KeyDown, chkFIPRCONJ.KeyDown, txtFIPRDESC.KeyDown, cboFIPRCSAN.KeyDown, cboFIPRCASA.KeyDown, txtFIPRMUAN.KeyDown, txtFIPRCOAN.KeyDown, txtFIPRBAAN.KeyDown, txtFIPRMAAN.KeyDown, txtFIPRPRAN.KeyDown, txtFIPREDAN.KeyDown, txtFIPRUPAN.KeyDown, txtFIPRATLO.KeyDown, txtFIPRACLO.KeyDown, txtFIPRAPLO.KeyDown, txtFIPRTOED.KeyDown, txtFIPRUNCO.KeyDown, txtFIPRURPH.KeyDown, txtFIPRAPCA.KeyDown, txtFIPRLOCA.KeyDown, txtFIPRCUUT.KeyDown, txtFIPRGACU.KeyDown, txtFIPRGADE.KeyDown, txtFIPRPISO.KeyDown, txtFIPRTIFI.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            pro_LimpiarCampos()
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

    Private Sub txtFIPRNUFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRNUFI.Text)) = False Then
            If Trim(txtFIPRNUFI.Text) <> "" Then
                txtFIPRNUFI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        Else
            Me.txtFIPRNUFI.Text = Val(Me.txtFIPRNUFI.Text)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub
    Private Sub txtFIPRTIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.Validated
        If Trim(txtFIPRTIFI.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRTIFI.Text)) = False Then
                txtFIPRTIFI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
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
    Private Sub txtFIPRMUAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUAN.Validated
        If Me.txtFIPRMUAN.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMUAN.Text) = True Then
            Me.txtFIPRMUAN.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUAN.Text)
        End If
    End Sub
    Private Sub txtFIPRCOAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOAN.Validated
        If Me.txtFIPRCOAN.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRCOAN.Text) = True Then
            Me.txtFIPRCOAN.Text = fun_Formato_Mascara_2_String(Me.txtFIPRCOAN.Text)
        End If
    End Sub
    Private Sub txtFIPRBAAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBAAN.Validated
        If Me.txtFIPRBAAN.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRBAAN.Text) = True Then
            Me.txtFIPRBAAN.Text = fun_Formato_Mascara_3_String(Me.txtFIPRBAAN.Text)
        End If
    End Sub
    Private Sub txtFIPRMAAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMAAN.Validated
        If Me.txtFIPRMAAN.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMAAN.Text) = True Then
            Me.txtFIPRMAAN.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMAAN.Text)
        End If
    End Sub
    Private Sub txtFIPRPRAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRAN.Validated
        If Me.txtFIPRPRAN.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRPRAN.Text) = True Then
            Me.txtFIPRPRAN.Text = fun_Formato_Mascara_5_String(Me.txtFIPRPRAN.Text)
        End If
    End Sub
    Private Sub txtFIPREDAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDAN.Validated
        If Me.txtFIPREDAN.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPREDAN.Text) = True Then
            Me.txtFIPREDAN.Text = fun_Formato_Mascara_3_String(Me.txtFIPREDAN.Text)
        End If
    End Sub
    Private Sub txtFIPRUPAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUPAN.Validated
        If Me.txtFIPRUPAN.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRUPAN.Text) = True Then
            Me.txtFIPRUPAN.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUPAN.Text)
        End If
    End Sub
    Private Sub cboFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(cboFIPRCLSE.Text)) = False Then
            If Trim(cboFIPRCLSE.Text) <> "" Then
                cboFIPRCLSE.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
            lblFIPRCLSE.Text = ""
        Else
            lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(cboFIPRCLSE.Text)), String)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFIPRCASU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(cboFIPRCASU.Text)) = False Then
            If Trim(cboFIPRCASU.Text) <> "" Then
                cboFIPRCASU.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
            lblFIPRCASU.Text = ""
        Else
            lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(cboFIPRCASU.Text)), String)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub
    Private Sub cboFIPRCSAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(cboFIPRCSAN.Text)) = False Then
            If Trim(cboFIPRCSAN.Text) <> "" Then
                cboFIPRCSAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
            lblFIPRCSAN.Text = ""
        Else
            lblFIPRCSAN.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(cboFIPRCSAN.Text)), String)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub
    Private Sub cboFIPRCASA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(cboFIPRCASA.Text)) = False Then
            If Trim(cboFIPRCASA.Text) <> "" Then
                cboFIPRCASA.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
            lblFIPRCASA.Text = ""
        Else
            lblFIPRCASA.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(cboFIPRCASA.Text)), String)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub
    Private Sub cboFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(cboFIPRCAPR.Text)) = False Then
            If Trim(cboFIPRCAPR.Text) <> "" Then
                cboFIPRCAPR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
            lblFIPRCAPR.Text = ""
        Else
            lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(cboFIPRCAPR.Text)), String)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub

    Private Sub txtFIPRATLO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRATLO.Validated
        If Trim(txtFIPRATLO.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRATLO.Text)) = False Then
                txtFIPRATLO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRACLO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRACLO.Validated
        If Trim(txtFIPRACLO.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRACLO.Text)) = False Then
                txtFIPRACLO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRAPLO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRAPLO.Validated
        If Trim(txtFIPRAPLO.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRAPLO.Text)) = False Then
                txtFIPRAPLO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRTOED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTOED.Validated
        If Trim(txtFIPRTOED.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRTOED.Text)) = False Then
                txtFIPRTOED.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRUNCO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNCO.Validated
        If Trim(txtFIPRUNCO.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRUNCO.Text)) = False Then
                txtFIPRUNCO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRURPH_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRURPH.Validated
        If Trim(txtFIPRURPH.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRURPH.Text)) = False Then
                txtFIPRURPH.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRAPCA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRAPCA.Validated
        If Trim(txtFIPRAPCA.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRAPCA.Text)) = False Then
                txtFIPRAPCA.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRLOCA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRLOCA.Validated
        If Trim(txtFIPRLOCA.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRLOCA.Text)) = False Then
                txtFIPRLOCA.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRCUUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCUUT.Validated
        If Trim(txtFIPRCUUT.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRCUUT.Text)) = False Then
                txtFIPRCUUT.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRGACU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRGACU.Validated
        If Trim(txtFIPRGACU.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRGACU.Text)) = False Then
                txtFIPRGACU.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRGADE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRGADE.Validated
        If Trim(txtFIPRGADE.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRGADE.Text)) = False Then
                txtFIPRGADE.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRPISO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPISO.Validated
        If Trim(txtFIPRPISO.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRPISO.Text)) = False Then
                txtFIPRPISO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtFIPRNUFI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.TextChanged
        If Trim(txtFIPRNUFI.Text) <> "" Then
            Me.cmdACEPTAR.Enabled = True
        Else
            Me.cmdACEPTAR.Enabled = False
        End If
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#End Region

End Class