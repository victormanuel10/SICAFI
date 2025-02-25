Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO

Public Class frm_consultar_OBSEINMO

    '==========================================
    '*** CONSULTA OBSERVATORIO INMOBILIARIO ***
    '==========================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim vl_stRutaDocumentos As String = ""

    Dim dt As DataTable

#End Region

#Region "FUNCIONES"

    Private Function fun_VerificarCarpetaExistenteDocumentos() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(8)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Municipio").Value.ToString) & "-" & _
                                   Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Sector").Value.ToString) & "-" & _
                                   Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Corregi").Value.ToString) & "-" & _
                                   Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Barrio - Vereda").Value.ToString) & "-" & _
                                   Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Manzana").Value.ToString) & "-" & _
                                   Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Predio").Value.ToString) & "-" & _
                                   Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Edicio").Value.ToString) & "-" & _
                                   Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Unidad").Value.ToString) & "-" & _
                                   Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Vigencia_Predio").Value.ToString)


                Dim Ruta As New DirectoryInfo(stRuta)

                Dim TodasLasCarpetas(), CarpetaABuscar As DirectoryInfo

                ' declara la variable 
                Dim sw As Byte = 1

                TodasLasCarpetas = Ruta.GetDirectories()

                ' recorre el directorio
                For Each CarpetaABuscar In TodasLasCarpetas

                    If CarpetaABuscar.FullName = Ruta.FullName & stCarpetaABuscar Then
                        sw = 0
                    End If

                Next

                ' retorna la respuesta
                If sw = 1 Then
                    Return False
                Else
                    Return True
                End If

            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try

            ' crea la variable de los campos
            Dim stOBINNUFI As String = ""
            Dim stOBINDESC As String = ""
            Dim stOBINDIRE As String = ""
            Dim stOBINMANZ As String = ""
            Dim stOBINPRED As String = ""
            Dim stOBINEDIF As String = ""
            Dim stOBINUNPR As String = ""

            Dim stOBINCOMU As String = ""
            Dim stOBINDEPA As String = ""
            Dim stOBINMUNI As String = ""
            Dim stOBINCORR As String = ""
            Dim stOBINBAVE As String = ""
            Dim stOBINCLSE As String = ""
            Dim stOBINCAPR As String = ""
            Dim stOBINVIGE As String = ""
            Dim stOBINESTR As String = ""
            Dim stOBINZOEC As String = ""
            Dim stOBINTIPO As String = ""
            Dim stOBINCLCO As String = ""
            Dim stOBINTICO As String = ""
            Dim stOBINMOBI As String = ""
            Dim stOBINCLPR As String = ""
            Dim stOBINMEIN As String = ""
            Dim stOBINESTA As String = ""
            Dim stOBINZOFI As String = ""
            Dim stOBINPUCA As String = ""

            Dim stOBINCONJ As String = ""
            Dim stOBINVIIS As String = ""
            Dim stOBINAVPA As String = ""
            Dim stOBINAVCU As String = ""
            Dim stOBINURAB As String = ""
            Dim stOBINURCE As String = ""

            ' carga los campos
            If Trim(Me.txtOBINNUFI.Text) = "" Then
                stOBINNUFI = "%"
            Else
                stOBINNUFI = Trim(Me.txtOBINNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBINDESC.Text) = "" Then
                stOBINDESC = "%"
            Else
                stOBINDESC = Trim(Me.txtOBINDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBINDIRE.Text) = "" Then
                stOBINDIRE = "%"
            Else
                stOBINDIRE = Trim(Me.txtOBINDIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBINMANZ.Text) = "" Then
                stOBINMANZ = "%"
            Else
                stOBINMANZ = Trim(Me.txtOBINMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBINPRED.Text) = "" Then
                stOBINPRED = "%"
            Else
                stOBINPRED = Trim(Me.txtOBINPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBINEDIF.Text) = "" Then
                stOBINEDIF = "%"
            Else
                stOBINEDIF = Trim(Me.txtOBINEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBINUNPR.Text) = "" Then
                stOBINUNPR = "%"
            Else
                stOBINUNPR = Trim(Me.txtOBINUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.cboOBINCOMU.Text) = "" Then
                stOBINCOMU = "%"
            Else
                stOBINCOMU = Trim(Me.cboOBINCOMU.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINDEPA.Text) = "" Then
                stOBINDEPA = "%"
            Else
                stOBINDEPA = Trim(Me.cboOBINDEPA.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINMUNI.Text) = "" Then
                stOBINMUNI = "%"
            Else
                stOBINMUNI = Trim(Me.cboOBINMUNI.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINCORR.Text) = "" Then
                stOBINCORR = "%"
            Else
                stOBINCORR = Trim(Me.cboOBINCORR.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINBARR.Text) = "" Then
                stOBINBAVE = "%"
            Else
                stOBINBAVE = Trim(Me.cboOBINBARR.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINCLSE.Text) = "" Then
                stOBINCLSE = "%"
            Else
                stOBINCLSE = Trim(Me.cboOBINCLSE.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINCAPR.Text) = "" Then
                stOBINCAPR = "%"
            Else
                stOBINCAPR = Trim(Me.cboOBINCAPR.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINVIGE.Text) = "" Then
                stOBINVIGE = "%"
            Else
                stOBINVIGE = Trim(Me.cboOBINVIGE.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINESTR.Text) = "" Then
                stOBINESTR = "%"
            Else
                stOBINESTR = Trim(Me.cboOBINESTR.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINZOEC.Text) = "" Then
                stOBINZOEC = "%"
            Else
                stOBINZOEC = Trim(Me.cboOBINZOEC.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINZOFI.Text) = "" Then
                stOBINZOFI = "%"
            Else
                stOBINZOFI = Trim(Me.cboOBINZOFI.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINTIPO.Text) = "" Then
                stOBINTIPO = "%"
            Else
                stOBINTIPO = Trim(Me.cboOBINTIPO.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINCLCO.Text) = "" Then
                stOBINCLCO = "%"
            Else
                stOBINCLCO = Trim(Me.cboOBINCLCO.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINTICO.Text) = "" Then
                stOBINTICO = "%"
            Else
                stOBINTICO = Trim(Me.cboOBINTICO.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINMOBI.Text) = "" Then
                stOBINMOBI = "%"
            Else
                stOBINMOBI = Trim(Me.cboOBINMOBI.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINCLPR.Text) = "" Then
                stOBINCLPR = "%"
            Else
                stOBINCLPR = Trim(Me.cboOBINCLPR.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINMEIN.Text) = "" Then
                stOBINMEIN = "%"
            Else
                stOBINMEIN = Trim(Me.cboOBINMEIN.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboOBINESTA.Text) = "" Then
                stOBINESTA = "%"
            Else
                stOBINESTA = Trim(Me.cboOBINESTA.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.txtOBINPUCA.Text) = "" Then
                stOBINPUCA = "%"
            Else
                stOBINPUCA = Trim(Me.txtOBINPUCA.Text)
            End If

            If Me.chkOBINCONJ.CheckState = CheckState.Indeterminate Then
                stOBINCONJ = "%"
            ElseIf Me.chkOBINCONJ.Checked = False Then
                stOBINCONJ = "0"
            ElseIf Me.chkOBINCONJ.Checked = True Then
                stOBINCONJ = "1"
            End If

            If Me.chkOBINVIIS.CheckState = CheckState.Indeterminate Then
                stOBINVIIS = "%"
            ElseIf Me.chkOBINVIIS.Checked = False Then
                stOBINVIIS = "0"
            ElseIf Me.chkOBINVIIS.Checked = True Then
                stOBINVIIS = "1"
            End If

            If Me.chkOBINAVPA.CheckState = CheckState.Indeterminate Then
                stOBINAVPA = "%"
            ElseIf Me.chkOBINAVPA.Checked = False Then
                stOBINAVPA = "0"
            ElseIf Me.chkOBINAVPA.Checked = True Then
                stOBINAVPA = "1"
            End If

            If Me.chkOBINAVCU.CheckState = CheckState.Indeterminate Then
                stOBINAVCU = "%"
            ElseIf Me.chkOBINAVCU.Checked = False Then
                stOBINAVCU = "0"
            ElseIf Me.chkOBINAVCU.Checked = True Then
                stOBINAVCU = "1"
            End If

            If Me.chkOBINURAB.CheckState = CheckState.Indeterminate Then
                stOBINURAB = "%"
            ElseIf Me.chkOBINURAB.Checked = False Then
                stOBINURAB = "0"
            ElseIf Me.chkOBINURAB.Checked = True Then
                stOBINURAB = "1"
            End If

            If Me.chkOBINURCE.CheckState = CheckState.Indeterminate Then
                stOBINURCE = "%"
            ElseIf Me.chkOBINURCE.Checked = False Then
                stOBINURCE = "0"
            ElseIf Me.chkOBINURCE.Checked = True Then
                stOBINURCE = "1"
            End If

            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "OBINIDRE , "
            stConsulta += "OBINCECA , "
            stConsulta += "OBINDEPA as 'Departa', "
            stConsulta += "OBINMUNI as 'Municipio', "
            stConsulta += "OBINCLSE as 'Sector', "
            stConsulta += "OBINCORR as 'Corregi', "
            stConsulta += "OBINCOMU as 'Comuna', "
            stConsulta += "OBINBARR as 'Barrio - Vereda', "
            stConsulta += "OBINMANZ as 'Manzana', "
            stConsulta += "OBINPRED as 'Predio', "
            stConsulta += "OBINEDIF as 'Edicio', "
            stConsulta += "OBINUNPR as 'Unidad', "
            stConsulta += "OBINDESC as 'Descripción', "
            stConsulta += "OBINDIRE as 'Dirección', "
            stConsulta += "OBINCAPR as 'Cara_Predio', "
            stConsulta += "OBINNUFI as 'Nro_Ficha', "
            stConsulta += "OBINESTR as 'Estrato', "
            stConsulta += "OBINZOEC as 'Zona_Econ', "
            stConsulta += "OBINTIPO as 'Tipo_Cali', "
            stConsulta += "OBINCLCO as 'Clase_Cons', "
            stConsulta += "OBINTICO as 'Tipo_Cons', "
            stConsulta += "OBINMOBI as 'Mobilia', "
            stConsulta += "OBINMEIN as 'Metodo_Inve', "
            stConsulta += "OBINVIGE as 'Vigencia', "
            stConsulta += "OBINESTA as 'Estado', "
            stConsulta += "OBINCONJ as 'Conjunto', "
            stConsulta += "OBINAVCA as 'Avalúo_Catastral', "
            stConsulta += "OBINAVCO as 'Avalúo_Comercial', "
            stConsulta += "OBINARCO as 'Área_Cons', "
            stConsulta += "OBINARTE as 'Área_Terr' , "
            stConsulta += "OBINVM2C as 'Valor_Mts2_Comercial', "
            stConsulta += "OBINZOFI as 'Zona_Fisi', "
            stConsulta += "OBINPUCA as 'Puntos_Calif.', "
            stConsulta += "OBINVIAV as 'Vigencia_Predio' "

            stConsulta += "From OBSEINMO  "
            stConsulta += "Where "

            stConsulta += "OBINDEPA like '" & stOBINDEPA & "' and "
            stConsulta += "OBINCOMU like '" & stOBINCOMU & "' and "
            stConsulta += "OBINMUNI like '" & stOBINMUNI & "' and "
            stConsulta += "OBINCORR like '" & stOBINCORR & "' and "
            stConsulta += "OBINBARR like '" & stOBINBAVE & "' and "
            stConsulta += "OBINMANZ like '" & stOBINMANZ & "' and "
            stConsulta += "OBINPRED like '" & stOBINPRED & "' and "
            stConsulta += "OBINEDIF like '" & stOBINEDIF & "' and "
            stConsulta += "OBINUNPR like '" & stOBINUNPR & "' and "
            stConsulta += "OBINCLSE like '" & stOBINCLSE & "' and "
            stConsulta += "OBINVIGE like '" & stOBINVIGE & "' and "
            stConsulta += "OBINDESC like '" & stOBINDESC & "' and "
            stConsulta += "OBINDIRE like '" & stOBINDIRE & "' and "
            stConsulta += "OBINCAPR like '" & stOBINCAPR & "' and "
            stConsulta += "OBINNUFI like '" & stOBINNUFI & "' and "
            stConsulta += "OBINESTR like '" & stOBINESTR & "' and "
            stConsulta += "OBINZOEC like '" & stOBINZOEC & "' and "
            stConsulta += "OBINZOFI like '" & stOBINZOFI & "' and "
            stConsulta += "OBINTIPO like '" & stOBINTIPO & "' and "
            stConsulta += "OBINCLPR like '" & stOBINCLPR & "' and "
            stConsulta += "OBINCLCO like '" & stOBINCLCO & "' and "
            stConsulta += "OBINTICO like '" & stOBINTICO & "' and "
            stConsulta += "OBINMOBI like '" & stOBINMOBI & "' and "
            stConsulta += "OBINMEIN like '" & stOBINMEIN & "' and "
            stConsulta += "OBINESTA like '" & stOBINESTA & "' and "
            stConsulta += "OBINCONJ like '" & stOBINCONJ & "' and "
            stConsulta += "OBINVIIS like '" & stOBINVIIS & "' and "
            stConsulta += "OBINAVPA like '" & stOBINAVPA & "' and "
            stConsulta += "OBINAVCU like '" & stOBINAVCU & "' and "
            stConsulta += "OBINURAB like '" & stOBINURAB & "' and "
            stConsulta += "OBINURCE like '" & stOBINURCE & "' and "
            stConsulta += "OBINPUCA like '" & stOBINPUCA & "' "

            stConsulta += "Order by OBINCLSE,OBINDEPA, OBINMUNI, OBINCORR, OBINBARR, OBINMANZ, OBINPRED, OBINEDIF, OBINUNPR, OBINVIGE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns("OBINIDRE").Visible = False
            Me.dgvCONSULTA.Columns("OBINCECA").Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.cmdCoeficienteVariacion.Enabled = False
                Me.cboOBINDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
                Me.cmdCoeficienteVariacion.Enabled = True

                Me.dgvCONSULTA.Columns(27).DefaultCellStyle.Format = "c"
                Me.dgvCONSULTA.Columns(26).DefaultCellStyle.Format = "c"
                Me.dgvCONSULTA.Columns(30).DefaultCellStyle.Format = "c"

            End If

            If Me.dgvCONSULTA.RowCount = 0 Then
                Me.cmdAceptar.Enabled = False
                Me.cmdCoeficienteVariacion.Enabled = False
            Else
                Me.cmdAceptar.Enabled = True
                Me.cmdCoeficienteVariacion.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CargaListaDesplegable()

        ' carga los combobox
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboOBINDEPA, Me.cboOBINDEPA.SelectedIndex)
        'fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboOBINMUNI, Me.cboOBINMUNI.SelectedIndex, Me.cboOBINDEPA)
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO(Me.cboOBINMUNI, Me.cboOBINMUNI.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOBINCLSE, Me.cboOBINCLSE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_Descripcion(Me.cboOBINCORR, Me.cboOBINCORR.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        fun_Cargar_ComboBox_Con_Datos_Activos_COMUNA_Descripcion(Me.cboOBINCOMU, Me.cboOBINCOMU.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_Descripcion(Me.cboOBINBARR, Me.cboOBINBARR.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboOBINCAPR, Me.cboOBINCAPR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboOBINESTR, Me.cboOBINESTR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboOBINTIPO, Me.cboOBINTIPO.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboOBINCLCO, Me.cboOBINCLCO.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_MOBILIARIO_Descripcion(Me.cboOBINMOBI, Me.cboOBINMOBI.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOBINVIGE, Me.cboOBINVIGE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboOBINESTA, Me.cboOBINESTA.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(Me.cboOBINZOEC, Me.cboOBINZOEC.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_X_MUNICIPIO_Descripcion(Me.cboOBINZOEC, Me.cboOBINZOEC.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASPRED_Descripcion(Me.cboOBINCLPR, Me.cboOBINCLPR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_MUNICIPIO_Descripcion(Me.cboOBINTICO, Me.cboOBINTICO.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLCO, Me.cboOBINCLSE)
        fun_Cargar_ComboBox_Con_Datos_Activos_METOINVE_Descripcion(Me.cboOBINMEIN, Me.cboOBINMEIN.SelectedIndex)

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < Me.dgvCONSULTA.RowCount And SW = 0
                If Me.dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    Me.cboOBINDEPA.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(2).Value.ToString()
                    Me.cboOBINMUNI.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(3).Value.ToString()
                    Me.cboOBINCLSE.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString()
                    Me.cboOBINCORR.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString()
                    Me.cboOBINCOMU.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString()
                    Me.cboOBINBARR.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString()
                    Me.txtOBINMANZ.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    Me.txtOBINPRED.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())
                    Me.txtOBINEDIF.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(10).Value.ToString())
                    Me.txtOBINUNPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(11).Value.ToString())
                    Me.txtOBINDESC.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(12).Value.ToString())
                    Me.txtOBINDIRE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(13).Value.ToString())
                    Me.cboOBINCAPR.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(14).Value.ToString()
                    Me.txtOBINNUFI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(15).Value.ToString())
                    Me.cboOBINESTR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(16).Value.ToString())
                    Me.cboOBINZOEC.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(17).Value.ToString()
                    Me.cboOBINTIPO.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(18).Value.ToString()
                    Me.cboOBINCLCO.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(19).Value.ToString()
                    Me.cboOBINTICO.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(20).Value.ToString()
                    Me.cboOBINMOBI.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(21).Value.ToString()
                    Me.cboOBINMEIN.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(22).Value.ToString()
                    Me.cboOBINVIGE.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(23).Value.ToString()
                    Me.cboOBINESTA.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(24).Value.ToString()
                    Me.chkOBINCONJ.Checked = Me.dgvCONSULTA.CurrentRow.Cells(25).Value
                    Me.cboOBINZOFI.SelectedValue = Me.dgvCONSULTA.CurrentRow.Cells(31).Value.ToString()
                    Me.txtOBINPUCA.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(32).Value.ToString())

                    'Me.chkOBINVIIS.Checked = Me.dgvCONSULTA.CurrentRow.Cells(26).Value.ToString()
                    'Me.chkOBINAVPA.Checked = Me.dgvCONSULTA.CurrentRow.Cells(27).Value.ToString()
                    'Me.chkOBINAVCU.Checked = Me.dgvCONSULTA.CurrentRow.Cells(28).Value.ToString()
                    'Me.chkOBINURAB.Checked = Me.dgvCONSULTA.CurrentRow.Cells(29).Value.ToString()

                    SW = 1
                Else
                    I = I + 1
                End If

            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblOBINCOMU.Text = ""
        Me.lblOBINCORR.Text = ""
        Me.lblOBINDEPA.Text = ""
        Me.lblOBINMUNI.Text = ""
        Me.lblOBINBAVE.Text = ""
        Me.lblOBINCLSE.Text = ""
        Me.lblOBINCAPR.Text = ""
        Me.lblOBINESTR.Text = ""
        Me.lblOBINZOEC.Text = ""
        Me.lblOBINTIPO.Text = ""
        Me.lblOBINCLPR.Text = ""
        Me.lblOBINCLCO.Text = ""
        Me.lblOBINTICO.Text = ""
        Me.lblOBINMOBI.Text = ""
        Me.lblOBINMEIN.Text = ""
        Me.lblOBINVIGE.Text = ""
        Me.lblOBINZOFI.Text = ""
        Me.txtOBINMANZ.Text = ""
        Me.txtOBINPRED.Text = ""
        Me.txtOBINEDIF.Text = ""
        Me.txtOBINUNPR.Text = ""
        Me.txtOBINDESC.Text = ""
        Me.txtOBINDIRE.Text = ""
        Me.txtOBINNUFI.Text = ""
        Me.txtOBINPUCA.Text = ""

        Me.pibImagenPredio.Image = Nothing
        Me.lstLISTADO_DOCUMENTOS_JPG.Items.Clear()

        Me.cboOBINCOMU.DataSource = New DataTable
        Me.cboOBINCORR.DataSource = New DataTable
        Me.cboOBINDEPA.DataSource = New DataTable
        Me.cboOBINMUNI.DataSource = New DataTable
        Me.cboOBINBARR.DataSource = New DataTable
        Me.cboOBINCLSE.DataSource = New DataTable
        Me.cboOBINCAPR.DataSource = New DataTable
        Me.cboOBINESTR.DataSource = New DataTable
        Me.cboOBINZOEC.DataSource = New DataTable
        Me.cboOBINTIPO.DataSource = New DataTable
        Me.cboOBINCLPR.DataSource = New DataTable
        Me.cboOBINCLCO.DataSource = New DataTable
        Me.cboOBINTICO.DataSource = New DataTable
        Me.cboOBINMOBI.DataSource = New DataTable
        Me.cboOBINMEIN.DataSource = New DataTable
        Me.cboOBINVIGE.DataSource = New DataTable
        Me.cboOBINESTA.DataSource = New DataTable
        Me.cboOBINZOFI.DataSource = New DataTable

        Me.chkOBINCONJ.CheckState = CheckState.Indeterminate
        Me.chkOBINCONJ.CheckState = CheckState.Indeterminate
        Me.chkOBINVIIS.CheckState = CheckState.Indeterminate
        Me.chkOBINAVPA.CheckState = CheckState.Indeterminate
        Me.chkOBINAVCU.CheckState = CheckState.Indeterminate
        Me.chkOBINURAB.CheckState = CheckState.Indeterminate
        Me.chkOBINURCE.CheckState = CheckState.Indeterminate

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_MostrarImagen()

        Try

            Me.lstLISTADO_DOCUMENTOS_JPG.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(8)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Municipio").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Sector").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Corregi").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Barrio - Vereda").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Manzana").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Predio").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Edicio").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Unidad").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Vigencia_Predio").Value.ToString)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS_JPG.Items.Clear()
                Me.pibImagenPredio.Image = Nothing

                ContentItem = Dir("*.jpg")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_JPG.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_JPG.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_JPG.Items.Clear()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click

        Try
            pro_Reconsultar()
            'pro_CargaListaDesplegable()
            'pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCoeficienteVariacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCoeficienteVariacion.Click

        Dim oAvaluoComercial As New frm_AVALCOME(dt)
        oAvaluoComercial.ShowDialog()

    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        If Me.dgvCONSULTA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RECLAMOS(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.cboOBINDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.cboOBINDEPA.Focus()
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

#Region "Load"

    Private Sub frm_consultar_OBSEINMO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub

    Private Sub frm_insertar_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboOBINDEPA.Focus()

        If Me.dgvCONSULTA.RowCount = 0 Then
            Me.cmdAceptar.Enabled = False
            Me.cmdCoeficienteVariacion.Enabled = False
        End If

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboOBINDEPA.KeyPress, cboOBINMUNI.KeyPress, cboOBINCOMU.KeyPress, cboOBINCORR.KeyPress, cboOBINBARR.KeyPress, cboOBINCLSE.KeyPress, txtOBINMANZ.KeyPress, txtOBINPRED.KeyPress, txtOBINEDIF.KeyPress, txtOBINUNPR.KeyPress, txtOBINDESC.KeyPress, txtOBINDIRE.KeyPress, cboOBINCAPR.KeyPress, txtOBINNUFI.KeyPress, cboOBINESTR.KeyPress, cboOBINZOEC.KeyPress, cboOBINTIPO.KeyPress, cboOBINCLPR.KeyPress, cboOBINCLCO.KeyPress, cboOBINTICO.KeyPress, cboOBINMOBI.KeyPress, cboOBINMEIN.KeyPress, cboOBINVIGE.KeyPress, cboOBINESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboOBINDEPA, Me.cboOBINDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboOBINMUNI, Me.cboOBINMUNI.SelectedIndex, Me.cboOBINDEPA)
        End If
    End Sub
    Private Sub cboOBINCORR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINCORR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboOBINCORR, Me.cboOBINCORR.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        End If
    End Sub
    Private Sub cboOBINCOMU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINCOMU.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_COMUNA_X_MUNICIPIO_Descripcion(Me.cboOBINCOMU, Me.cboOBINCOMU.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        End If
    End Sub
    Private Sub cboOBINBAVE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINBARR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(Me.cboOBINBARR, Me.cboOBINBARR.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        End If
    End Sub
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOBINCLSE, Me.cboOBINCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCAPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINCAPR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboOBINCAPR, Me.cboOBINCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINESTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINESTR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboOBINESTR, Me.cboOBINESTR.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINZOEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(Me.cboOBINZOEC, Me.cboOBINZOEC.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
        End If
    End Sub
    Private Sub cboOBINTIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINTIPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboOBINTIPO, Me.cboOBINTIPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINCLPR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASPRED_Descripcion(Me.cboOBINCLPR, Me.cboOBINCLPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINCLCO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboOBINCLCO, Me.cboOBINCLCO.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINTICO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINTICO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_MUNICIPIO_Descripcion(Me.cboOBINTICO, Me.cboOBINTICO.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLCO, Me.cboOBINCLSE)
        End If
    End Sub
    Private Sub cboOBINMOBI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINMOBI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MOBILIARIO_Descripcion(Me.cboOBINMOBI, Me.cboOBINMOBI.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMEIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINMEIN.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_METOINVE_Descripcion(Me.cboOBINMEIN, Me.cboOBINMEIN.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOBINVIGE, Me.cboOBINVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOBINESTA, Me.cboOBINESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBINMANZ.GotFocus, txtOBINPRED.GotFocus, txtOBINEDIF.GotFocus, txtOBINUNPR.GotFocus, txtOBINDESC.GotFocus, txtOBINDIRE.GotFocus, txtOBINNUFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSalir.GotFocus, cmdAceptar.GotFocus, cmdCoeficienteVariacion.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINDEPA.GotFocus, cboOBINMUNI.GotFocus, cboOBINCOMU.GotFocus, cboOBINCORR.GotFocus, cboOBINBARR.GotFocus, cboOBINCLSE.GotFocus, cboOBINCAPR.GotFocus, cboOBINESTR.GotFocus, cboOBINZOEC.GotFocus, cboOBINTIPO.GotFocus, cboOBINCLPR.GotFocus, cboOBINCLCO.GotFocus, cboOBINTICO.GotFocus, cboOBINMOBI.GotFocus, cboOBINMEIN.GotFocus, cboOBINVIGE.GotFocus, cboOBINESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINDEPA.SelectedIndexChanged
        Me.lblOBINDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboOBINDEPA), String)

        Me.cboOBINMUNI.DataSource = New DataTable
        Me.lblOBINMUNI.Text = ""

        Me.cboOBINCOMU.DataSource = New DataTable
        Me.lblOBINCOMU.Text = ""

        Me.cboOBINCORR.DataSource = New DataTable
        Me.lblOBINCORR.Text = ""

        Me.cboOBINBARR.DataSource = New DataTable
        Me.lblOBINBAVE.Text = ""

        Me.cboOBINZOEC.DataSource = New DataTable
        Me.lblOBINZOEC.Text = ""

        Me.cboOBINZOFI.DataSource = New DataTable
        Me.lblOBINZOFI.Text = ""

        Me.cboOBINTICO.DataSource = New DataTable
        Me.lblOBINTICO.Text = ""

    End Sub
    Private Sub cboOBINMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINMUNI.SelectedIndexChanged
        Me.lblOBINMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboOBINDEPA, Me.cboOBINMUNI), String)

        Me.cboOBINCOMU.DataSource = New DataTable
        Me.lblOBINCOMU.Text = ""

        Me.cboOBINCORR.DataSource = New DataTable
        Me.lblOBINCORR.Text = ""

        Me.cboOBINBARR.DataSource = New DataTable
        Me.lblOBINBAVE.Text = ""

        Me.cboOBINZOEC.DataSource = New DataTable
        Me.lblOBINZOEC.Text = ""

        Me.cboOBINZOFI.DataSource = New DataTable
        Me.lblOBINZOFI.Text = ""

        Me.cboOBINTICO.DataSource = New DataTable
        Me.lblOBINTICO.Text = ""

    End Sub
    Private Sub cboFPPRCOMU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINCOMU.SelectedIndexChanged
        Me.lblOBINCOMU.Text = CType(fun_Buscar_Lista_Valores_COMUNA_Codigo(Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE, Me.cboOBINCOMU), String)
    End Sub
    Private Sub cboFPPRCORR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINCORR.SelectedIndexChanged
        Me.lblOBINCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO_Codigo(Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE, Me.cboOBINCORR), String)
    End Sub
    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINCLSE.SelectedIndexChanged
        Me.lblOBINCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboOBINCLSE), String)

        Me.cboOBINBARR.DataSource = New DataTable
        Me.lblOBINBAVE.Text = ""

        Me.cboOBINZOEC.DataSource = New DataTable
        Me.lblOBINZOEC.Text = ""

        Me.cboOBINZOFI.DataSource = New DataTable
        Me.lblOBINZOFI.Text = ""

        Me.cboOBINTICO.DataSource = New DataTable
        Me.lblOBINTICO.Text = ""
    End Sub
    Private Sub cboOBINBAVE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINBARR.SelectedIndexChanged
        Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRVERE_Codigo(Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE, Me.cboOBINBARR), String)
    End Sub
    Private Sub cboOBINCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINCAPR.SelectedIndexChanged
        Me.lblOBINCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED_Codigo(Me.cboOBINCAPR), String)
    End Sub
    Private Sub cboOBINESTR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINESTR.SelectedIndexChanged
        Me.lblOBINESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboOBINESTR), String)
    End Sub
    Private Sub cboOBINZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINZOEC.SelectedIndexChanged
        Me.lblOBINZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE, Me.cboOBINZOEC), String)
    End Sub
    Private Sub cboOBINZOFI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINZOFI.SelectedIndexChanged
        Me.lblOBINZOFI.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI_Codigo(Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE, Me.cboOBINZOFI), String)
    End Sub
    Private Sub cboOBINTIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINTIPO.SelectedIndexChanged
        Me.lblOBINTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboOBINTIPO), String)
    End Sub
    Private Sub cboOBINCLPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINCLPR.SelectedIndexChanged
        Me.lblOBINCLPR.Text = CType(fun_Buscar_Lista_Valores_CLASPRED_Codigo(Me.cboOBINCLPR), String)
    End Sub
    Private Sub cboOBINCLCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINCLCO.SelectedIndexChanged
        Me.lblOBINCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS_Codigo(Me.cboOBINCLCO), String)

        Me.cboOBINTICO.DataSource = New DataTable
        Me.lblOBINTICO.Text = ""
    End Sub
    Private Sub cboOBINTICO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINTICO.SelectedIndexChanged
        Me.lblOBINTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS_Codigo(Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLCO, Me.cboOBINCLSE, Me.cboOBINTICO), String)
    End Sub
    Private Sub cboOBINMOBI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINMOBI.SelectedIndexChanged
        Me.lblOBINMOBI.Text = CType(fun_Buscar_Lista_Valores_MOBILIARIO_Codigo(Me.cboOBINMOBI), String)
    End Sub
    Private Sub cboOBINMEIN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINMEIN.SelectedIndexChanged
        Me.lblOBINMEIN.Text = CType(fun_Buscar_Lista_Valores_METOINVE_Codigo(Me.cboOBINMEIN), String)
    End Sub
    Private Sub cboOBINVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINVIGE.SelectedIndexChanged
        Me.lblOBINVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboOBINVIGE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboOBINDEPA, Me.cboOBINDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboOBINMUNI, Me.cboOBINMUNI.SelectedIndex, Me.cboOBINDEPA)
    End Sub
    Private Sub cboOBINCORR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINCORR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboOBINCORR, Me.cboOBINCORR.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
    End Sub
    Private Sub cboOBINCOMU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINCOMU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_COMUNA_X_MUNICIPIO_Descripcion(Me.cboOBINCOMU, Me.cboOBINCOMU.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
    End Sub
    Private Sub cboOBINBAVE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINBARR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(Me.cboOBINBARR, Me.cboOBINBARR.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOBINCLSE, Me.cboOBINCLSE.SelectedIndex)
    End Sub
    Private Sub cboOBINCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(Me.cboOBINCAPR, Me.cboOBINCAPR.SelectedIndex)
    End Sub
    Private Sub cboOBINESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboOBINESTR, Me.cboOBINESTR.SelectedIndex)
    End Sub
    Private Sub cboOBINZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(Me.cboOBINZOEC, Me.cboOBINZOEC.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
    End Sub
    Private Sub cboOBINZOFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINZOFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_X_MUNICIPIO_Descripcion(Me.cboOBINZOFI, Me.cboOBINZOFI.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
    End Sub
    Private Sub cboOBINTIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINTIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboOBINTIPO, Me.cboOBINTIPO.SelectedIndex)
    End Sub
    Private Sub cboOBINCLPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINCLPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASPRED_Descripcion(Me.cboOBINCLPR, Me.cboOBINCLPR.SelectedIndex)
    End Sub
    Private Sub cboOBINCLCO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINCLCO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboOBINCLCO, Me.cboOBINCLCO.SelectedIndex)
    End Sub
    Private Sub cboOBINTICO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINTICO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_MUNICIPIO_Descripcion(Me.cboOBINTICO, Me.cboOBINTICO.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLCO, Me.cboOBINCLSE)
    End Sub
    Private Sub cboOBINMOBI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINMOBI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MOBILIARIO_Descripcion(Me.cboOBINMOBI, Me.cboOBINMOBI.SelectedIndex)
    End Sub
    Private Sub cboOBINMEIN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINMEIN.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_METOINVE_Descripcion(Me.cboOBINMEIN, Me.cboOBINMEIN.SelectedIndex)
    End Sub
    Private Sub cboOBINVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOBINVIGE, Me.cboOBINVIGE.SelectedIndex)
    End Sub
    Private Sub cboOBINESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOBINESTA, Me.cboOBINESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtOBINMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBINMANZ.Validated
        If Me.txtOBINMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOBINMANZ.Text) = True Then
            Me.txtOBINMANZ.Text = fun_Formato_Mascara_3_String(Me.txtOBINMANZ.Text)
        End If
    End Sub
    Private Sub txtOBINPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBINPRED.Validated
        If Me.txtOBINPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOBINPRED.Text) = True Then
            Me.txtOBINPRED.Text = fun_Formato_Mascara_5_String(Me.txtOBINPRED.Text)
        End If
    End Sub
    Private Sub txtOBINEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBINEDIF.Validated
        If Me.txtOBINEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOBINEDIF.Text) = True Then
            Me.txtOBINEDIF.Text = fun_Formato_Mascara_3_String(Me.txtOBINEDIF.Text)
        End If
    End Sub
    Private Sub txtOBINUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBINUNPR.Validated
        If Me.txtOBINUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOBINUNPR.Text) = True Then
            Me.txtOBINUNPR.Text = fun_Formato_Mascara_5_String(Me.txtOBINUNPR.Text)
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONSULTA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA.CellClick
        'pro_ListaDeValores()
        pro_MostrarImagen()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_MostrarImagen()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub lstLISTADO_DOCUMENTOS_JPG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_JPG.SelectedIndexChanged

        ' declara la variable
        Dim stRuta As String = ""
        Dim stNewPath As String = ""
        Dim ContentItem As String = ""

        ' instancia la clase
        Dim objRutas As New cla_RUTAS
        Dim tblRutas As New DataTable

        tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(8)

        If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

            stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Municipio").Value.ToString) & "-" & _
                                                                        Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Sector").Value.ToString) & "-" & _
                                                                        Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Corregi").Value.ToString) & "-" & _
                                                                        Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Barrio - Vereda").Value.ToString) & "-" & _
                                                                        Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Manzana").Value.ToString) & "-" & _
                                                                        Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Predio").Value.ToString) & "-" & _
                                                                        Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Edicio").Value.ToString) & "-" & _
                                                                        Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Unidad").Value.ToString) & "-" & _
                                                                        Trim(Me.dgvCONSULTA.SelectedRows.Item(0).Cells("Vigencia_Predio").Value.ToString)

            vl_stRutaDocumentos = stNewPath

            Me.pibImagenPredio.Image = Image.FromFile(vl_stRutaDocumentos & "\" & Me.lstLISTADO_DOCUMENTOS_JPG.SelectedItem)
            Me.pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom

        Else
            Me.lstLISTADO_DOCUMENTOS_JPG.Items.Clear()
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