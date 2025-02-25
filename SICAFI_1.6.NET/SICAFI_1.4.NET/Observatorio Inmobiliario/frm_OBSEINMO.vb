Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO

Public Class frm_OBSEINMO

    '=================================
    '*** ONSERVATORIO INMOBILIARIO ***
    '=================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim vl_stRutaDocumentos As String = ""

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_OBSEINMO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_OBSEINMO
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

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

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
                stCarpetaABuscar = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCORR").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINBARR").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMANZ").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINPRED").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINEDIF").Value.ToString) & "-" & _
                                   Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINUNPR").Value.ToString) & "-" & _
                                   Me.txtOBINVIAV.Text

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

    Private Sub pro_ReconsultarObservatorioInmobiliario()

        Try
            Dim objdatos As New cla_OBSEINMO

            If boCONSULTA = False Then
                Me.BindingSource_OBSEINMO_1.DataSource = objdatos.fun_Consultar_OBSEINMO
            Else
                Me.BindingSource_OBSEINMO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBSEINMO(vp_inConsulta)
            End If

            Me.dgvOBSEINMO.DataSource = BindingSource_OBSEINMO_1
            Me.BindingNavigator_OBSEINMO_1.BindingSource = BindingSource_OBSEINMO_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_OBSEINMO_1.Count

            Me.dgvOBSEINMO.Columns("OBINIDRE").HeaderText = "idre"
            Me.dgvOBSEINMO.Columns("OBINSECU").HeaderText = "Secuencia"

            Me.dgvOBSEINMO.Columns("OBINDEPA").HeaderText = "Departamento"
            Me.dgvOBSEINMO.Columns("OBINMUNI").HeaderText = "Municipio"
            Me.dgvOBSEINMO.Columns("OBINCORR").HeaderText = "Corregimiento"
            Me.dgvOBSEINMO.Columns("OBINBARR").HeaderText = "Barrio / Vereda"
            Me.dgvOBSEINMO.Columns("OBINMANZ").HeaderText = "Manzana"
            Me.dgvOBSEINMO.Columns("OBINPRED").HeaderText = "Predio"
            Me.dgvOBSEINMO.Columns("OBINEDIF").HeaderText = "Edificio"
            Me.dgvOBSEINMO.Columns("OBINUNPR").HeaderText = "Unidad Predial"
            Me.dgvOBSEINMO.Columns("OBINCLSE").HeaderText = "Sector"
            Me.dgvOBSEINMO.Columns("OBINVIGE").HeaderText = "Vigencia"
            Me.dgvOBSEINMO.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvOBSEINMO.Columns("OBINIDRE").Visible = False
            Me.dgvOBSEINMO.Columns("OBINSECU").Visible = False
            Me.dgvOBSEINMO.Columns("OBINCECA").Visible = False
            Me.dgvOBSEINMO.Columns("OBINNUFI").Visible = False
            Me.dgvOBSEINMO.Columns("OBINDESC").Visible = False
            Me.dgvOBSEINMO.Columns("OBINDIRE").Visible = False
            Me.dgvOBSEINMO.Columns("OBINCOMU").Visible = False
            Me.dgvOBSEINMO.Columns("OBINCAPR").Visible = False
            Me.dgvOBSEINMO.Columns("OBINAVCA").Visible = False
            Me.dgvOBSEINMO.Columns("OBINAVCO").Visible = False
            Me.dgvOBSEINMO.Columns("OBINVM2T").Visible = False
            Me.dgvOBSEINMO.Columns("OBINVM2C").Visible = False
            Me.dgvOBSEINMO.Columns("OBINARTE").Visible = False
            Me.dgvOBSEINMO.Columns("OBINARCO").Visible = False
            Me.dgvOBSEINMO.Columns("OBINVIGE").Visible = False
            Me.dgvOBSEINMO.Columns("OBINEDCO").Visible = False
            Me.dgvOBSEINMO.Columns("OBINESTR").Visible = False
            Me.dgvOBSEINMO.Columns("OBINZOEC").Visible = False
            Me.dgvOBSEINMO.Columns("OBINTIPO").Visible = False
            Me.dgvOBSEINMO.Columns("OBINCLCO").Visible = False
            Me.dgvOBSEINMO.Columns("OBINTICO").Visible = False
            Me.dgvOBSEINMO.Columns("OBINNUPI").Visible = False
            Me.dgvOBSEINMO.Columns("OBINMOBI").Visible = False
            Me.dgvOBSEINMO.Columns("OBINCLPR").Visible = False
            Me.dgvOBSEINMO.Columns("OBINFECH").Visible = False
            Me.dgvOBSEINMO.Columns("OBINMEIN").Visible = False
            Me.dgvOBSEINMO.Columns("OBINOBSE").Visible = False
            Me.dgvOBSEINMO.Columns("OBINVIAV").Visible = False
            Me.dgvOBSEINMO.Columns("OBINESTA").Visible = False
            Me.dgvOBSEINMO.Columns("OBINRUIM").Visible = False
            Me.dgvOBSEINMO.Columns("OBINCONJ").Visible = False
            Me.dgvOBSEINMO.Columns("ESTADESC").Visible = False
            Me.dgvOBSEINMO.Columns("OBINVIIS").Visible = False
            Me.dgvOBSEINMO.Columns("OBINAVPA").Visible = False
            Me.dgvOBSEINMO.Columns("OBINAVCU").Visible = False
            Me.dgvOBSEINMO.Columns("OBINURAB").Visible = False
            Me.dgvOBSEINMO.Columns("OBINURCE").Visible = False
            Me.dgvOBSEINMO.Columns("OBINZOFI").Visible = False
            Me.dgvOBSEINMO.Columns("OBINPUCA").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_OBSEINMO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR.Enabled = boCONTMODI
            Me.cmdELIMINAR.Enabled = boCONTELIM
            Me.cmdCONSULTAR.Enabled = True
            Me.cmdRECONSULTAR.Enabled = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresObservatorioInmobiliario()

        Try
            If Me.dgvOBSEINMO.RowCount > 0 Then

                Dim objdatos As New cla_OBSEINMO
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBSEINMO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINIDRE").Value.ToString)

                Me.txtOBINCOMU.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCOMU").Value.ToString)
                Me.txtOBINCORR.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCORR").Value.ToString)
                Me.txtOBINDEPA.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString)
                Me.txtOBINMUNI.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString)
                Me.txtOBINBAVE.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINBARR").Value.ToString)
                Me.txtOBINCLSE.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString)
                Me.txtOBINDESC.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDESC").Value.ToString)
                Me.txtOBINDIRE.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDIRE").Value.ToString)
                Me.txtOBINNUFI.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINNUFI").Value.ToString)
                Me.txtOBINCAPR.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCAPR").Value.ToString)
                Me.txtOBINESTR.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINESTR").Value.ToString)
                Me.txtOBINZOEC.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINZOEC").Value.ToString)
                Me.txtOBINTIPO.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINTIPO").Value.ToString)
                Me.txtOBINCLPR.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLPR").Value.ToString)
                Me.txtOBINCLCO.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLCO").Value.ToString)
                Me.txtOBINTICO.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINTICO").Value.ToString)
                Me.txtOBINMOBI.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMOBI").Value.ToString)
                Me.txtOBINMEIN.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMEIN").Value.ToString)
                Me.txtOBINVIGE.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINVIGE").Value.ToString)
                Me.txtOBINOBSE.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINOBSE").Value.ToString)
                Me.txtOBINAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINAVCA").Value.ToString))
                Me.txtOBINAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINAVCO").Value.ToString))
                Me.txtOBINVM2T.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINVM2T").Value.ToString))
                Me.txtOBINARTE.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINARTE").Value.ToString)
                Me.txtOBINVM2C.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINVM2C").Value.ToString))
                Me.txtOBINARCO.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINARCO").Value.ToString)
                Me.txtOBINVIAV.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINVIAV").Value.ToString)
                Me.txtOBINEDCO.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINEDCO").Value.ToString)
                Me.txtOBINNUPI.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINNUPI").Value.ToString)
                Me.txtOBINOBSE.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINOBSE").Value.ToString)
                Me.txtOBINESTA.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINESTA").Value.ToString)
                Me.chkOBINCONJ.Checked = Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCONJ").Value
                Me.chkOBINVIIS.Checked = Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINVIIS").Value
                Me.chkOBINAVPA.Checked = Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINAVPA").Value
                Me.chkOBINAVCU.Checked = Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINAVCU").Value
                Me.rbdOBINURAB.Checked = Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINURAB").Value
                Me.rbdOBINURCE.Checked = Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINURCE").Value
                Me.txtOBINZOFI.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINZOFI").Value.ToString)
                Me.txtOBINPUCA.Text = Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINPUCA").Value.ToString)

                Me.lblOBINCOMU.Text = CType(fun_Buscar_Lista_Valores_COMUNA(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCOMU").Value.ToString), String)
                Me.lblOBINCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCORR").Value.ToString), String)

                If CInt(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString) = 1 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINBARR").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString) = 2 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMANZ").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString) = 3 Then
                    Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINBARR").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCORR").Value.ToString), String)
                End If

                Me.lblOBINDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString), String)
                Me.lblOBINMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString), String)
                Me.lblOBINCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString), String)
                Me.lblOBINCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCAPR").Value.ToString), String)
                Me.lblOBINESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINESTR").Value.ToString), String)
                Me.lblOBINZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINZOEC").Value.ToString), String)
                Me.lblOBINTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINTIPO").Value.ToString), String)
                Me.lblOBINCLPR.Text = CType(fun_Buscar_Lista_Valores_CLASPRED(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLPR").Value.ToString), String)
                Me.lblOBINCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLCO").Value.ToString), String)
                Me.lblOBINTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLCO").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINTICO").Value.ToString), String)
                Me.lblOBINMOBI.Text = CType(fun_Buscar_Lista_Valores_MOBILIARIO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMOBI").Value.ToString), String)
                Me.lblOBINMEIN.Text = CType(fun_Buscar_Lista_Valores_METOINVE(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMEIN").Value.ToString), String)
                Me.lblOBINVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINVIGE").Value.ToString), String)
                Me.lblOBINESTA.Text = CType(fun_Buscar_Lista_Valores_ESTADO(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINESTA").Value.ToString), String)
                Me.lblOBINVIAV.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINVIAV").Value.ToString), String)
                Me.lblOBINZOFI.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINDEPA").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString, Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINZOFI").Value.ToString), String)

                pro_ListadoArchivosDocumentosJPG()
                pro_ListadoArchivosDocumentosPDF()
            Else
                pro_LimpiarCampos()

            End If

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
        Me.lblOBINESTA.Text = ""
        Me.lblOBINVIAV.Text = ""
        Me.lblOBINZOFI.Text = ""

        Me.txtOBINCOMU.Text = ""
        Me.txtOBINCORR.Text = ""
        Me.txtOBINDEPA.Text = ""
        Me.txtOBINMUNI.Text = ""
        Me.txtOBINBAVE.Text = ""
        Me.txtOBINCLSE.Text = ""
        Me.txtOBINDESC.Text = ""
        Me.txtOBINDIRE.Text = ""
        Me.txtOBINNUFI.Text = ""
        Me.txtOBINCAPR.Text = ""
        Me.txtOBINESTR.Text = ""
        Me.txtOBINZOEC.Text = ""
        Me.txtOBINTIPO.Text = ""
        Me.txtOBINCLPR.Text = ""
        Me.txtOBINCLCO.Text = ""
        Me.txtOBINTICO.Text = ""
        Me.txtOBINMOBI.Text = ""
        Me.txtOBINMEIN.Text = ""
        Me.txtOBINVIGE.Text = ""
        Me.txtOBINESTA.Text = ""
        Me.txtOBINOBSE.Text = ""
        Me.txtOBINAVCA.Text = ""
        Me.txtOBINAVCO.Text = ""
        Me.txtOBINVM2T.Text = ""
        Me.txtOBINARTE.Text = ""
        Me.txtOBINVM2C.Text = ""
        Me.txtOBINARCO.Text = ""
        Me.txtOBINVIAV.Text = ""
        Me.txtOBINEDCO.Text = ""
        Me.txtOBINNUPI.Text = ""
        Me.txtOBINOBSE.Text = ""
        Me.txtOBINZOFI.Text = ""
        Me.txtOBINPUCA.Text = ""

        Me.chkOBINCONJ.Checked = False
        Me.chkOBINVIIS.Checked = False
        Me.chkOBINAVPA.Checked = False
        Me.chkOBINAVCU.Checked = False
        Me.rbdOBINURAB.Checked = False
        Me.rbdOBINURCE.Checked = False

        Me.dgvOBSEINMO.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_ListadoArchivosDocumentosJPG()

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

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCORR").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINBARR").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMANZ").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINPRED").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINEDIF").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINUNPR").Value.ToString) & "-" & _
                                                                            Me.txtOBINVIAV.Text

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS_JPG.Items.Clear()

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
    Private Sub pro_ListadoArchivosDocumentosPDF()

        Try
            Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(8)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMUNI").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCLSE").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINCORR").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINBARR").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINMANZ").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINPRED").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINEDIF").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells("OBINUNPR").Value.ToString) & "-" & _
                                                                            Me.txtOBINVIAV.Text

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()

                ContentItem = Dir("*.pdf")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_PDF.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_PDF.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_PDF.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_OBSEINMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_OBSEINMO.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarObservatorioInmobiliario()
                pro_ListaDeValoresObservatorioInmobiliario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_OBSEINMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click

        Try
            Dim frm_modificar As New frm_modificar_OBSEINMO(Integer.Parse(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarObservatorioInmobiliario()
                pro_ListaDeValoresObservatorioInmobiliario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_OBSEINMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_OBSEINMO

                If objdatos.fun_Eliminar_IDRE_OBSEINMO(Integer.Parse(Me.dgvOBSEINMO.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    boCONSULTA = False
                    pro_LimpiarCampos()
                    pro_ReconsultarObservatorioInmobiliario()
                    pro_ListaDeValoresObservatorioInmobiliario()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_OBSEINMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_OBSEINMO.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarObservatorioInmobiliario()
            pro_ListaDeValoresObservatorioInmobiliario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_OBSEINMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click

        Try
            boCONSULTA = False
            pro_ReconsultarObservatorioInmobiliario()
            pro_ListaDeValoresObservatorioInmobiliario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click

        Try
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresObservatorioInmobiliario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresObservatorioInmobiliario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresObservatorioInmobiliario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresObservatorioInmobiliario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_ReconsultarObservatorioInmobiliario()
        Me.strBARRESTA.Items(0).Text = "Observatorio inmobiliario"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_OBSEINMO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresObservatorioInmobiliario()
    End Sub
    Private Sub dgvOBSEINMO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvOBSEINMO.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvOBSEINMO.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvOBSEINMO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBSEINMO.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR.Enabled = True Then
                Me.cmdAGREGAR.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR.Enabled = True Then
                Me.cmdMODIFICAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_OBSEINMO_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            If Me.cmdELIMINAR.Enabled = True Then
                Me.cmdELIMINAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_OBSEINMO_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** CONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F7 Then
            If Me.cmdCONSULTAR.Enabled = True Then
                Me.cmdCONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR.Enabled = True Then
                Me.cmdRECONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOBSEINMO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresObservatorioInmobiliario()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOBSEINMO.CellClick
        pro_ListaDeValoresObservatorioInmobiliario()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_JPG_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_JPG.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_JPG.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_JPG.SelectedItem
                Process.Start(vl_stRutaDocumentos & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_JPG.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub lstLISTADO_DOCUMENTOS_PDF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_PDF.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_PDF.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_PDF.SelectedItem
                Process.Start(vl_stRutaDocumentos & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_PDF.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#End Region


End Class