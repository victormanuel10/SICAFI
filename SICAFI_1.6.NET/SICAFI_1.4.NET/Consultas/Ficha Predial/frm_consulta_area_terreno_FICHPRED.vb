Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_area_terreno_FICHPRED

    '=======================================
    ' CONSULTA AREA DE TERRENO FICHA PREDIAL
    '=======================================

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

    Public Shared Function instance() As frm_consulta_area_terreno_FICHPRED
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_area_terreno_FICHPRED
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
    Dim stFIPRTIFI As String
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
    Dim stFIPRARTE As String
    Dim stFIPRESTA As String
    Dim Separador As String

    ' variables guardar consulta
    Dim Guardar_stCONDICION As String
    Dim Guardar_stFIPRNUFI As String
    Dim Guardar_stFIPRTIFI As String
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
    Dim Guardar_stFIPRARTE As String
    Dim Guardar_stFIPRESTA As String

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

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
        Me.txtFIPRARTE.Text = ""
        Me.txtFIPRESTA.Text = ""
        Me.lblTOTAARTE_MTS.Text = "0"
        Me.lblTOTAARTE_HEC.Text = "0.0000"
        Me.txtFIPRCOND.Text = "like"
        Me.txtRUTA.Text = ""
        Me.cboCONDICION.SelectedIndex = 0
        Me.txtRESOMUNI.Text = ""
        Me.txtRESORESO.Text = ""
        Me.txtRESOTIRE.Text = ""
        Me.txtRESOVIGE.Text = ""
        Me.lblFIPRCLSE.Text = ""
        Me.lblFIPRCASU.Text = ""
        Me.lblFIPRCAPR.Text = ""
        Me.lblFIPRMOAD.Text = ""
        Me.lblTOTAATLO.Text = "0"
        Me.lblTOTAACLO.Text = "0"
        Me.lblTOTAAPLO.Text = "0"
        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

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

        If Trim(Me.txtFIPRARTE.Text) = "" And Trim(Me.txtFIPRCOND.Text) = "like" Then
            stFIPRARTE = "%"
        End If

        If Trim(Me.txtFIPRARTE.Text) = "" And Trim(Me.txtFIPRCOND.Text) <> "like" Then
            stFIPRARTE = ""
            Me.txtFIPRARTE.Focus()
        End If

        If Trim(Me.txtFIPRARTE.Text) = "" Then
            stFIPRARTE = "%"
            Me.txtFIPRCOND.Text = "like"
            Me.cboCONDICION.SelectedIndex = 0
        Else
            stFIPRARTE = Trim(Me.txtFIPRARTE.Text)
        End If

        If Trim(Me.txtFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
        End If

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            ' encuestra la posición seleccionada
            Dim I, SW As Byte

            While I < Me.dgvCONSULTA.RowCount And SW = 0
                If Me.dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos con el registro seleccionado
                    Me.txtFIPRNUFI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())
                    Me.txtFIPRARTE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    Me.txtFIPRMUNI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    Me.txtFIPRCORR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(3).Value.ToString())
                    Me.txtFIPRBARR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    Me.txtFIPRMANZ.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    Me.txtFIPRPRED.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    Me.txtFIPREDIF.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    Me.txtFIPRUNPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    Me.txtFIPRCLSE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())
                    Me.txtFIPRCASU.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(18).Value.ToString())
                    Me.txtFIPRCAPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(19).Value.ToString())
                    Me.txtFIPRMOAD.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(20).Value.ToString())
                    Me.txtFIPRESTA.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(21).Value.ToString())
                    Me.txtRESOMUNI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    Me.txtRESOTIRE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(23).Value.ToString())
                    Me.txtRESOVIGE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(24).Value.ToString())
                    Me.txtRESORESO.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(25).Value.ToString())
                    Me.txtFIPRDIRE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(26).Value.ToString())
                    Me.txtFIPRTIFI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(27).Value.ToString())

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
    Private Sub pro_GuardarConsulta()

        Guardar_stCONDICION = Trim(Me.cboCONDICION.Text)
        Guardar_stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        Guardar_stFIPRTIFI = Trim(Me.txtFIPRTIFI.Text)
        Guardar_stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        Guardar_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        Guardar_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        Guardar_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        Guardar_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        Guardar_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        Guardar_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        Guardar_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        Guardar_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        Guardar_stFIPRCASU = Trim(Me.txtFIPRCASU.Text)
        Guardar_stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)
        Guardar_stFIPRMOAD = Trim(Me.txtFIPRMOAD.Text)
        Guardar_stFIPRARTE = Trim(Me.txtFIPRARTE.Text)
        Guardar_stFIPRESTA = Trim(Me.txtFIPRESTA.Text)

    End Sub
    Private Sub pro_ObtenerConsulta()

        Me.cboCONDICION.Text = Guardar_stCONDICION
        Me.txtFIPRNUFI.Text = Guardar_stFIPRNUFI
        Me.txtFIPRTIFI.Text = Guardar_stFIPRTIFI
        Me.txtFIPRDIRE.Text = Guardar_stFIPRDIRE
        Me.txtFIPRMUNI.Text = Guardar_stFIPRMUNI
        Me.txtFIPRCORR.Text = Guardar_stFIPRCORR
        Me.txtFIPRBARR.Text = Guardar_stFIPRBARR
        Me.txtFIPRMANZ.Text = Guardar_stFIPRMANZ
        Me.txtFIPRPRED.Text = Guardar_stFIPRPRED
        Me.txtFIPREDIF.Text = Guardar_stFIPREDIF
        Me.txtFIPRUNPR.Text = Guardar_stFIPRUNPR
        Me.txtFIPRCLSE.Text = Guardar_stFIPRCLSE
        Me.txtFIPRCASU.Text = Guardar_stFIPRCASU
        Me.txtFIPRCAPR.Text = Guardar_stFIPRCAPR
        Me.txtFIPRMOAD.Text = Guardar_stFIPRMOAD
        Me.txtFIPRARTE.Text = Guardar_stFIPRARTE
        Me.txtFIPRESTA.Text = Guardar_stFIPRESTA

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

            If Trim(stFIPRTIFI) = "%" Or Trim(stFIPRTIFI) = "0" Then

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "FiprNufi as Nro_Ficha, "
                ParametrosConsulta += "FiprArte as Area_Terreno_Mts2, "
                ParametrosConsulta += "FiprMuni as Municipio, "
                ParametrosConsulta += "FiprCorr as Corregimiento, "
                ParametrosConsulta += "FiprBarr as Barrio, "
                ParametrosConsulta += "FiprManz as Manzana, "
                ParametrosConsulta += "FiprPred as Predio, "
                ParametrosConsulta += "FiprEdif as Edificio, "
                ParametrosConsulta += "FiprUnpr as Unidad_Predial, "
                ParametrosConsulta += "FiprClse as Sector, "
                ParametrosConsulta += "FiprMuan as Municipio_Anterior, "
                ParametrosConsulta += "FiprCoan as Corregimi_Anterior, "
                ParametrosConsulta += "FiprBaan as Barrio_Anterior, "
                ParametrosConsulta += "FiprMaan as Manzana_Anterior, "
                ParametrosConsulta += "FiprPran as Predio_Anterior, "
                ParametrosConsulta += "FiprEdan as Edificio_Anterior, "
                ParametrosConsulta += "FiprUpan as Unid_Pred_Anterior, "
                ParametrosConsulta += "FiprCsan as Sector_Anterior, "
                ParametrosConsulta += "FiprCasu as Categoria_Suelo, "
                ParametrosConsulta += "FiprCapr as Caracteristica_Predio, "
                ParametrosConsulta += "FiprMoad as Modo_Adquisicion, "
                ParametrosConsulta += "FiprEsta as Estado, "
                ParametrosConsulta += "FiprDepa as Departamento, "
                ParametrosConsulta += "FiprTire as Tipo_Resolucion, "
                ParametrosConsulta += "FiprVige as Vigencia, "
                ParametrosConsulta += "FiprReso as Resolucion, "
                ParametrosConsulta += "FiprDire as Direccion, "
                ParametrosConsulta += "FiprTifi as Tipo_Ficha, "
                ParametrosConsulta += "FiprAtlo as Area_Total_Lote, "
                ParametrosConsulta += "FiprAclo as Area_Comun_Lote, "
                ParametrosConsulta += "FiprAplo as Area_Priva_Lote "
                ParametrosConsulta += "From FichPred where "
                ParametrosConsulta += "FiprNufi like '" & stFIPRNUFI & "' and "
                ParametrosConsulta += "FiprArte " & cboCONDICION.Text & " "
                ParametrosConsulta += "'" & stFIPRARTE & "' and "
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
                ParametrosConsulta += "FiprDire like '" & stFIPRDIRE & "' and "
                ParametrosConsulta += "FiprTifi like '" & stFIPRTIFI & "' and "
                ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' "
                ParametrosConsulta += "order by FiprNufi,FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr,FiprTifi"

            ElseIf stFIPRTIFI = "1" Or stFIPRTIFI = "2" Then

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "FiprNufi as NroFicha, "
                ParametrosConsulta += "FiprArte as Area_Terreno_Mts2, "
                ParametrosConsulta += "FiprMuni as Municipio, "
                ParametrosConsulta += "FiprCorr as Corregimiento, "
                ParametrosConsulta += "FiprBarr as Barrio, "
                ParametrosConsulta += "FiprManz as Manzana, "
                ParametrosConsulta += "FiprPred as Predio, "
                ParametrosConsulta += "FiprEdif as Edificio, "
                ParametrosConsulta += "FiprUnpr as Unidad_Predial, "
                ParametrosConsulta += "FiprClse as Sector, "
                ParametrosConsulta += "FiprMuan as Municipio_Anterior, "
                ParametrosConsulta += "FiprCoan as Corregimi_Anterior, "
                ParametrosConsulta += "FiprBaan as Barrio_Anterior, "
                ParametrosConsulta += "FiprMaan as Manzana_Anterior, "
                ParametrosConsulta += "FiprPran as Predio_Anterior, "
                ParametrosConsulta += "FiprEdan as Edificio_Anterior, "
                ParametrosConsulta += "FiprUpan as Unid_Pred_Anterior, "
                ParametrosConsulta += "FiprCsan as Sector_Anterior, "
                ParametrosConsulta += "FiprCasu as Categoria_Suelo, "
                ParametrosConsulta += "FiprCapr as Caracteristica_Predio, "
                ParametrosConsulta += "FiprMoad as Modo_Adquisicion, "
                ParametrosConsulta += "FiprEsta as Estado, "
                ParametrosConsulta += "FiprDepa as Departamento, "
                ParametrosConsulta += "FiprTire as Tipo_Resolucion, "
                ParametrosConsulta += "FiprVige as Vigencia, "
                ParametrosConsulta += "FiprReso as Resolucion, "
                ParametrosConsulta += "FiprDire as Direccion, "
                ParametrosConsulta += "FiprTifi as TipoFicha, "
                ParametrosConsulta += "FiprAtlo as Area_Total_Lote, "
                ParametrosConsulta += "FiprAclo as Area_Comun_Lote, "
                ParametrosConsulta += "FiprAplo as Area_Priva_Lote, "
                ParametrosConsulta += "FiprToed as Total_Edificio, "
                ParametrosConsulta += "FiprUnco as Unidades_Condominio, "
                ParametrosConsulta += "FiprUrph as Unidades_RPH, "
                ParametrosConsulta += "FiprApca as Apto_Casas, "
                ParametrosConsulta += "FiprLoca as Locales, "
                ParametrosConsulta += "FiprCuut as Cuartos_Utiles, "
                ParametrosConsulta += "FiprGacu as Garajes_Cubiertos, "
                ParametrosConsulta += "FiprGade as Garajes_Descubiertos, "
                ParametrosConsulta += "FiprPiso as Piso "
                ParametrosConsulta += "From FichPred where "
                ParametrosConsulta += "FiprNufi like '" & stFIPRNUFI & "' and "
                ParametrosConsulta += "FiprArte " & cboCONDICION.Text & " "
                ParametrosConsulta += "'" & stFIPRARTE & "' and "
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
                ParametrosConsulta += "FiprDire like '" & stFIPRDIRE & "' and "
                ParametrosConsulta += "FiprTifi like '" & stFIPRTIFI & "' and "
                ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' "
                ParametrosConsulta += "order by FiprNufi,FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr,FiprTifi"

            End If

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

                ' declaro variables
                Dim i As Integer
                Dim loTotalAreaTerreno As Long = 0
                Dim loTotalAreaTotalLote As Long = 0
                Dim loTotalAreaComunLote As Long = 0
                Dim loTotalAreaPrivateLote As Long = 0


                For i = 0 To dt.Rows.Count - 1

                    ' suma el area de terreno
                    loTotalAreaTerreno += Integer.Parse(dgvCONSULTA.Item(1, i).Value.ToString)

                    ' suma el area total lote
                    loTotalAreaTotalLote += Integer.Parse(dgvCONSULTA.Item(28, i).Value.ToString)

                    ' suma el area comun lote
                    loTotalAreaComunLote += Integer.Parse(dgvCONSULTA.Item(29, i).Value.ToString)

                    ' suma el area privada lote
                    loTotalAreaPrivateLote += Integer.Parse(dgvCONSULTA.Item(30, i).Value.ToString)

                Next

                ' llena los totales
                lblTOTAARTE_MTS.Text = loTotalAreaTerreno.ToString
                lblTOTAARTE_HEC.Text = CType(fun_Formato_Decimal_4_Decimales(Val(loTotalAreaTerreno / 10000)), String)
                lblTOTAATLO.Text = loTotalAreaTotalLote
                lblTOTAACLO.Text = loTotalAreaComunLote
                lblTOTAAPLO.Text = loTotalAreaPrivateLote


                ' oculta las columnas del datagridview
                'dgvCONSULTA.Columns(14).Visible = False
                'dgvCONSULTA.Columns(15).Visible = False
                'dgvCONSULTA.Columns(16).Visible = False
                'dgvCONSULTA.Columns(17).Visible = False

                ' llena la lista de valores
                pro_ListaDeValores()
            Else
                Dim tbl_Limpiar As New DataTable
                dgvCONSULTA.DataSource = tbl_Limpiar
                lblTOTAARTE_MTS.Text = ""
                lblTOTAARTE_HEC.Text = ""
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
                    txtRUTA.Text = oCrear.FileName

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
                    txtRUTA.Text = ""
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
        txtFIPRNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_area_terreno_FICHPRED_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()

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
    Private Sub txtFIPRARTE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRARTE.GotFocus
        txtFIPRARTE.SelectionStart = 0
        txtFIPRARTE.SelectionLength = Len(txtFIPRARTE.Text)
        strBARRESTA.Items(0).Text = txtFIPRARTE.AccessibleDescription
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
    Private Sub cboCONDICION_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCONDICION.GotFocus
        strBARRESTA.Items(0).Text = cboCONDICION.AccessibleDescription
    End Sub
    Private Sub txtFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRESTA.GotFocus
        txtFIPRESTA.SelectionStart = 0
        txtFIPRESTA.SelectionLength = Len(txtFIPRESTA.Text)
        strBARRESTA.Items(0).Text = txtFIPRESTA.AccessibleDescription
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
        'If fun_Verificar_Dato_Numerico_Campo_Consulta_Evento_KeyPress(Short.Parse(Asc(e.KeyChar))) = False Then
        '    e.Handled = True
        'ElseIf e.KeyChar = Convert.ToChar(Keys.Enter) Then
        '    txtFIPRDIRE.Focus()
        'End If
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
            txtFIPRCLSE.Focus()
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
            cboCONDICION.Focus()
        End If
    End Sub
    Private Sub cboCONDICION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCONDICION.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRARTE.Focus()
        End If
    End Sub
    Private Sub txtFIPRARTE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRARTE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRESTA.Focus()
        End If
    End Sub
    Private Sub txtFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCONDICION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCONDICION.SelectedIndexChanged
        Dim seleccion As Integer

        seleccion = cboCONDICION.SelectedIndex

        Select Case seleccion

            ' Se carga la coleccion del combo el campo de texto editable
            Case 0 : cboCONDICION.Text = Me.cboCONDICION.Items(0).ToString
            Case 1 : cboCONDICION.Text = Me.cboCONDICION.Items(1).ToString
            Case 2 : cboCONDICION.Text = Me.cboCONDICION.Items(2).ToString
            Case 3 : cboCONDICION.Text = Me.cboCONDICION.Items(3).ToString
            Case 4 : cboCONDICION.Text = Me.cboCONDICION.Items(4).ToString
            Case 5 : cboCONDICION.Text = Me.cboCONDICION.Items(5).ToString
            Case 6 : cboCONDICION.Text = Me.cboCONDICION.Items(6).ToString

                'Case 0 : txtFIPRCOND.Text = "like"
                'Case 1 : txtFIPRCOND.Text = "="
                'Case 2 : txtFIPRCOND.Text = ">"
                'Case 3 : txtFIPRCOND.Text = "<"
                'Case 4 : txtFIPRCOND.Text = ">="
                'Case 5 : txtFIPRCOND.Text = "<="
                'Case 6 : txtFIPRCOND.Text = "<>"

        End Select

    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRCASU.KeyDown, txtFIPRCAPR.KeyDown, txtFIPRMOAD.KeyDown, cboCONDICION.KeyDown, txtFIPRARTE.KeyDown, txtFIPRESTA.KeyDown, dgvCONSULTA.KeyDown
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