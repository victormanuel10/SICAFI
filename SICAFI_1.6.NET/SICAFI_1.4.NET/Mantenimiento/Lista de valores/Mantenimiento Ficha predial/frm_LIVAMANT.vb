Imports REGLAS_DEL_NEGOCIO

Public Class frm_LIVAMANT

    '================================================
    '*** LISTA DE VALORES TABLAS DE MANTENIMIENTO ***
    '================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_LIVAMANT
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_LIVAMANT
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

#Region "PASO 1 VERIFICAR TABLAS"

    Private Sub pro_VerificarTablas()

        Dim objdatos1 As New cla_TIPORESO
        Dim tbl1 As New DataTable
        tbl1 = objdatos1.fun_Consultar_MANT_TIPORESO

        If tbl1.Rows.Count > 0 Then
            chkTIPORESO.Checked = True
            chkACTUTIPORESO.Checked = True
            chkACTUTIPORESO.Enabled = False
            lblACTUTIPORESO.Text = "Actualizado"
        Else
            chkTIPORESO.Checked = False
        End If

        '=============================================================

        Dim objdatos2 As New cla_CLASSECT
        Dim tbl2 As New DataTable
        tbl2 = objdatos2.fun_Consultar_MANT_CLASSECT

        If tbl2.Rows.Count > 0 Then
            chkCLASSECT.Checked = True
            chkACTUCLASSECT.Checked = True
            chkACTUCLASSECT.Enabled = False
            lblACTUCLASSECT.Text = "Actualizado"
        Else
            chkCLASSECT.Checked = False
        End If

        '=============================================================

        Dim objdatos3 As New cla_CATESUEL
        Dim tbl3 As New DataTable
        tbl3 = objdatos3.fun_Consultar_MANT_CATESUEL

        If tbl3.Rows.Count > 0 Then
            chkCATESUEL.Checked = True
            chkACTUCATESUEL.Checked = True
            chkACTUCATESUEL.Enabled = False
            lblACTUCATESUEL.Text = "Actualizado"
        Else
            chkCATESUEL.Checked = False
        End If

        '=============================================================

        Dim objdatos4 As New cla_CARAPRED
        Dim tbl4 As New DataTable
        tbl4 = objdatos4.fun_Consultar_MANT_CARAPRED

        If tbl4.Rows.Count > 0 Then
            chkCARAPRED.Checked = True
            chkACTUCARAPRED.Checked = True
            chkACTUCARAPRED.Enabled = False
            lblACTUCARAPRED.Text = "Actualizado"
        Else
            chkCARAPRED.Checked = False
        End If

        '=============================================================

        Dim objdatos5 As New cla_MODOADQU
        Dim tbl5 As New DataTable
        tbl5 = objdatos5.fun_Consultar_MANT_MODOADQU

        If tbl5.Rows.Count > 0 Then
            chkMODOADQU.Checked = True
            chkACTUMODOADQU.Checked = True
            chkACTUMODOADQU.Enabled = False
            lblACTUMODOADQU.Text = "Actualizado"
        Else
            chkMODOADQU.Checked = False
        End If

        '=============================================================

        Dim objdatos6 As New cla_DESTECON
        Dim tbl6 As New DataTable
        tbl6 = objdatos6.fun_Consultar_MANT_DESTECON

        If tbl6.Rows.Count > 0 Then
            chkDESTECON.Checked = True
            chkACTUDESTECON.Checked = True
            chkACTUDESTECON.Enabled = False
            lblACTUDESTECON.Text = "Actualizado"
        Else
            chkDESTECON.Checked = False
        End If

        '=============================================================

        Dim objdatos7 As New cla_CALIPROP
        Dim tbl7 As New DataTable
        tbl7 = objdatos7.fun_Consultar_MANT_CALIPROP

        If tbl7.Rows.Count > 0 Then
            chkCALIPROP.Checked = True
            chkACTUCALIPROP.Checked = True
            chkACTUCALIPROP.Enabled = False
            lblACTUCALIPROP.Text = "Actualizado"
        Else
            chkCALIPROP.Checked = False
        End If

        '=============================================================

        Dim objdatos8 As New cla_TIPODOCU
        Dim tbl8 As New DataTable
        tbl8 = objdatos8.fun_Consultar_MANT_TIPODOCU

        If tbl8.Rows.Count > 0 Then
            chkTIPODOCU.Checked = True
            chkACTUTIPODOCU.Checked = True
            chkACTUTIPODOCU.Enabled = False
            lblACTUTIPODOCU.Text = "Actualizado"
        Else
            chkTIPODOCU.Checked = False
        End If

        '=============================================================

        Dim objdatos14 As New cla_SEXO
        Dim tbl14 As New DataTable
        tbl14 = objdatos14.fun_Consultar_MANT_SEXO

        If tbl14.Rows.Count > 0 Then
            chkSEXO.Checked = True
            chkACTUSEXO.Checked = True
            chkACTUSEXO.Enabled = False
            lblACTUSEXO.Text = "Actualizado"
        Else
            chkSEXO.Checked = False
        End If

        '=============================================================

        Dim objdatos9 As New cla_DEPARTAMENTO
        Dim tbl9 As New DataTable
        tbl9 = objdatos9.fun_Consultar_MANT_DEPARTAMENTO

        If tbl9.Rows.Count > 0 Then
            chkDEPARTAMENTO.Checked = True
            chkACTUDEPARTAMENTO.Checked = True
            chkACTUDEPARTAMENTO.Enabled = False
            lblACTUDEPARTAMENTO.Text = "Actualizado"
        Else
            chkDEPARTAMENTO.Checked = False
        End If

        '=============================================================

        Dim objdatos10 As New cla_MUNICIPIO
        Dim tbl10 As New DataTable
        tbl10 = objdatos10.fun_Consultar_MANT_MUNICIPIO

        If tbl10.Rows.Count > 0 Then
            chkMUNICIPIO.Checked = True
            chkACTUMUNICIPIO.Checked = True
            chkACTUMUNICIPIO.Enabled = False
            lblACTUMUNICIPIO.Text = "Actualizado"
        Else
            chkMUNICIPIO.Checked = False
        End If

        '=============================================================

        Dim objdatos11 As New cla_CLASCONS
        Dim tbl11 As New DataTable
        tbl11 = objdatos11.fun_Consultar_MANT_CLASCONS

        If tbl11.Rows.Count > 0 Then
            chkCLASCONS.Checked = True
            chkACTUCLASCONS.Checked = True
            chkACTUCLASCONS.Enabled = False
            lblACTUCLASCONS.Text = "Actualizado"
        Else
            chkCLASCONS.Checked = False
        End If

        '=============================================================

        Dim objdatos12 As New cla_TIPOCALI
        Dim tbl12 As New DataTable
        tbl12 = objdatos12.fun_Consultar_MANT_TIPOCALI

        If tbl12.Rows.Count > 0 Then
            chkTIPOCALI.Checked = True
            chkACTUTIPOCALI.Checked = True
            chkACTUTIPOCALI.Enabled = False
            lblACTUTIPOCALI.Text = "Actualizado"
        Else
            chkTIPOCALI.Checked = False
        End If

        '=============================================================

        'Dim objdatos13 As New cla_CODICALI
        'Dim tbl13 As New DataTable
        'tbl13 = objdatos13.fun_Consultar_MANT_CODICALI

        'If tbl13.Rows.Count > 0 Then
        '    chkCODICALI.Checked = True
        'Else
        '    chkCODICALI.Checked = False
        'End If

    End Sub

#End Region

#Region "PASO 2 ACTUALIZAR CAMPOS"

    Private Sub pro_ActualizarCampos()

        Try

            frm_Procesando_ingreso_listas_de_valores.ShowDialog()


            If chkTIPORESO.Checked = False Then
                If chkACTUTIPORESO.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_TIPORESO) Then
                        lblACTUTIPORESO.Text = "Actualizado"
                        chkTIPORESO.Checked = True
                        chkACTUTIPORESO.Enabled = False
                    Else
                        lblACTUTIPORESO.Text = "No actualizado"
                        chkACTUTIPORESO.Checked = False
                    End If

                End If
            End If

            If chkCLASSECT.Checked = False Then
                If chkACTUCLASSECT.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_CLASSECT) Then
                        lblACTUCLASSECT.Text = "Actualizado"
                        chkCLASSECT.Checked = True
                        chkACTUCLASSECT.Enabled = False
                    Else
                        lblACTUCLASSECT.Text = "No actualizado"
                        chkACTUCLASSECT.Checked = False
                    End If

                End If
            End If

            If chkCATESUEL.Checked = False Then
                If chkACTUCATESUEL.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_CATESUEL) Then
                        lblACTUCATESUEL.Text = "Actualizado"
                        chkCATESUEL.Checked = True
                        chkACTUCATESUEL.Enabled = False
                    Else
                        lblACTUCATESUEL.Text = "No actualizado"
                        chkACTUCATESUEL.Checked = False
                    End If

                End If
            End If

            If chkCARAPRED.Checked = False Then
                If chkACTUCARAPRED.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_CARAPRED) Then
                        lblACTUCARAPRED.Text = "Actualizado"
                        chkCARAPRED.Checked = True
                        chkACTUCARAPRED.Enabled = False
                    Else
                        lblACTUCARAPRED.Text = "No actualizado"
                        chkACTUCARAPRED.Checked = False
                    End If

                End If
            End If

            If chkMODOADQU.Checked = False Then
                If chkACTUMODOADQU.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_MODOADQU) Then
                        lblACTUMODOADQU.Text = "Actualizado"
                        chkMODOADQU.Checked = True
                        chkACTUMODOADQU.Enabled = False
                    Else
                        lblACTUMODOADQU.Text = "No actualizado"
                        chkACTUMODOADQU.Checked = False
                    End If

                End If
            End If

            If chkDESTECON.Checked = False Then
                If chkACTUDESTECON.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_DESTECON) Then
                        lblACTUDESTECON.Text = "Actualizado"
                        chkDESTECON.Checked = True
                        chkACTUDESTECON.Enabled = False
                    Else
                        lblACTUDESTECON.Text = "No actualizado"
                        chkACTUDESTECON.Checked = False
                    End If

                End If
            End If

            If chkCALIPROP.Checked = False Then
                If chkACTUCALIPROP.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_CALIPROP) Then
                        lblACTUCALIPROP.Text = "Actualizado"
                        chkCALIPROP.Checked = True
                        chkACTUCALIPROP.Enabled = False
                    Else
                        lblACTUCALIPROP.Text = "No actualizado"
                        chkACTUCALIPROP.Checked = False
                    End If

                End If
            End If

            If chkTIPODOCU.Checked = False Then
                If chkACTUTIPODOCU.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_TIPODOCU) Then
                        lblACTUTIPODOCU.Text = "Actualizado"
                        chkTIPODOCU.Checked = True
                        chkACTUTIPODOCU.Enabled = False
                    Else
                        lblACTUTIPODOCU.Text = "No actualizado"
                        chkACTUTIPODOCU.Checked = False
                    End If

                End If
            End If

            If chkSEXO.Checked = False Then
                If chkACTUSEXO.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_SEXO) Then
                        lblACTUSEXO.Text = "Actualizado"
                        chkSEXO.Checked = True
                        chkACTUSEXO.Enabled = False
                    Else
                        lblACTUSEXO.Text = "No actualizado"
                        chkACTUSEXO.Checked = False
                    End If

                End If
            End If

            If chkDEPARTAMENTO.Checked = False Then
                If chkACTUDEPARTAMENTO.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_DEPARTAMENTO) Then
                        lblACTUDEPARTAMENTO.Text = "Actualizado"
                        chkDEPARTAMENTO.Checked = True
                        chkACTUDEPARTAMENTO.Enabled = False
                    Else
                        lblACTUDEPARTAMENTO.Text = "No actualizado"
                        chkACTUDEPARTAMENTO.Checked = False
                    End If

                End If
            End If

            If chkMUNICIPIO.Checked = False Then
                If chkACTUMUNICIPIO.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_MUNICIPIO) Then
                        lblACTUMUNICIPIO.Text = "Actualizado"
                        chkMUNICIPIO.Checked = True
                        chkACTUMUNICIPIO.Enabled = False
                    Else
                        lblACTUMUNICIPIO.Text = "No actualizado"
                        chkACTUMUNICIPIO.Checked = False
                    End If

                End If
            End If

            If chkTIPODOCU.Checked = False Then
                If chkACTUTIPODOCU.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_TIPODOCU) Then
                        lblACTUTIPODOCU.Text = "Actualizado"
                        chkTIPODOCU.Checked = True
                        chkACTUTIPODOCU.Enabled = False
                    Else
                        lblACTUTIPODOCU.Text = "No actualizado"
                        chkACTUTIPODOCU.Checked = False
                    End If

                End If
            End If

            If chkCLASCONS.Checked = False Then
                If chkACTUCLASCONS.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_CLASCONS) Then

                        lblACTUCLASCONS.Text = "Actualizado"
                        chkCLASCONS.Checked = True
                        chkACTUCLASCONS.Enabled = False
                    Else
                        lblACTUCLASCONS.Text = "No actualizado"
                        chkACTUCLASCONS.Checked = False
                    End If

                End If
            End If

            If chkTIPOCALI.Checked = False Then
                If chkACTUTIPOCALI.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_TIPOCALI) Then

                        lblACTUTIPOCALI.Text = "Actualizado"
                        chkTIPOCALI.Checked = True
                        chkACTUTIPOCALI.Enabled = False
                    Else
                        lblACTUTIPOCALI.Text = "No actualizado"
                        chkACTUTIPOCALI.Checked = False
                    End If

                End If
            End If

            If chkCODICALI.Checked = False Then
                If chkACTUCODICALI.Checked = True Then
                    Dim objdatos As New cla_LIVAMANT

                    If (objdatos.fun_Actualizar_ListaDeValores_MANT_CODICALI) Then

                        lblACTUCODICALI.Text = "Actualizado"
                        chkCODICALI.Checked = True
                        chkACTUCODICALI.Enabled = False
                    Else
                        lblACTUCODICALI.Text = "No actualizado"
                        chkACTUCODICALI.Checked = False
                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PASO 3 ACTIVAR BOTON INSERTAR"

    Private Sub pro_ActivarBotonInsertarDatos()

        If chkACTUCALIPROP.Enabled = True And chkACTUCALIPROP.Checked = True Or _
        chkACTUCARAPRED.Enabled = True And chkACTUCARAPRED.Checked = True Or _
        chkACTUCATESUEL.Enabled = True And chkACTUCATESUEL.Checked = True Or _
        chkACTUCLASCONS.Enabled = True And chkACTUCLASCONS.Checked = True Or _
        chkACTUTIPOCALI.Enabled = True And chkACTUTIPOCALI.Checked = True Or _
        chkACTUCLASSECT.Enabled = True And chkACTUCLASSECT.Checked = True Or _
        chkACTUCODICALI.Enabled = True And chkACTUCODICALI.Checked = True Or _
        chkACTUDEPARTAMENTO.Enabled = True And chkACTUDEPARTAMENTO.Checked = True Or _
        chkACTUDESTECON.Enabled = True And chkACTUDESTECON.Checked = True Or _
        chkACTUMODOADQU.Enabled = True And chkACTUMODOADQU.Checked = True Or _
        chkACTUMUNICIPIO.Enabled = True And chkACTUMUNICIPIO.Checked = True Or _
        chkACTUSEXO.Enabled = True And chkACTUSEXO.Checked = True Or _
        chkACTUTIPODOCU.Enabled = True And chkACTUTIPODOCU.Checked = True Or _
        chkACTUTIPORESO.Enabled = True And chkACTUTIPORESO.Checked = True Then

            cmdActualizarTablas.Enabled = True
        Else
            cmdActualizarTablas.Enabled = False
        End If

    End Sub

#End Region

#Region "PASO 4 ACTUALIZAR TODOS LOS CheckBox"

    Private Sub chkActualizarTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActualizarTodas.CheckedChanged

        If chkActualizarTodas.Checked = True Then

            If chkACTUCALIPROP.Checked = False Then
                chkACTUCALIPROP.Checked = True
            End If

            If chkACTUCARAPRED.Checked = False Then
                chkACTUCARAPRED.Checked = True
            End If

            If chkACTUCATESUEL.Checked = False Then
                chkACTUCATESUEL.Checked = True
            End If

            If chkACTUCLASCONS.Checked = False Then
                chkACTUCLASCONS.Checked = True
            End If

            If chkACTUCLASSECT.Checked = False Then
                chkACTUCLASSECT.Checked = True
            End If

            If chkACTUCODICALI.Checked = False Then
                chkACTUCODICALI.Checked = True
            End If

            If chkACTUDEPARTAMENTO.Checked = False Then
                chkACTUDEPARTAMENTO.Checked = True
            End If

            If chkACTUDESTECON.Checked = False Then
                chkACTUDESTECON.Checked = True
            End If

            If chkACTUMODOADQU.Checked = False Then
                chkACTUMODOADQU.Checked = True
            End If

            If chkACTUSEXO.Checked = False Then
                chkACTUSEXO.Checked = True
            End If

            If chkACTUMUNICIPIO.Checked = False Then
                chkACTUMUNICIPIO.Checked = True
            End If

            If chkACTUTIPODOCU.Checked = False Then
                chkACTUTIPODOCU.Checked = True
            End If

            If chkACTUTIPORESO.Checked = False Then
                chkACTUTIPORESO.Checked = True
            End If

            If chkACTUTIPOCALI.Checked = False Then
                chkACTUTIPOCALI.Checked = True
            End If

        Else

            If chkACTUCALIPROP.Enabled = True Then
                chkACTUCALIPROP.Checked = False
            End If

            If chkACTUCARAPRED.Enabled = True Then
                chkACTUCARAPRED.Checked = False
            End If

            If chkACTUCATESUEL.Enabled = True Then
                chkACTUCATESUEL.Checked = False
            End If

            If chkACTUCLASCONS.Enabled = True Then
                chkACTUCLASCONS.Checked = False
            End If

            If chkACTUCLASSECT.Enabled = True Then
                chkACTUCLASSECT.Checked = False
            End If

            If chkACTUCODICALI.Enabled = True Then
                chkACTUCODICALI.Checked = False
            End If

            If chkACTUDEPARTAMENTO.Enabled = True Then
                chkACTUDEPARTAMENTO.Checked = False
            End If

            If chkACTUDESTECON.Enabled = True Then
                chkACTUDESTECON.Checked = False
            End If

            If chkACTUMODOADQU.Enabled = True Then
                chkACTUMODOADQU.Checked = False
            End If

            If chkACTUSEXO.Enabled = True Then
                chkACTUSEXO.Checked = False
            End If

            If chkACTUMUNICIPIO.Enabled = True Then
                chkACTUMUNICIPIO.Checked = False
            End If

            If chkACTUTIPODOCU.Enabled = True Then
                chkACTUTIPODOCU.Checked = False
            End If

            If chkACTUTIPORESO.Enabled = True Then
                chkACTUTIPORESO.Checked = False
            End If

            If chkACTUTIPOCALI.Enabled = True Then
                chkACTUTIPOCALI.Checked = False
            End If
        End If

        pro_ActivarBotonInsertarDatos()

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdVerificarTablas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVerificarTablas.Click
        pro_VerificarTablas()
        MessageBox.Show("La verificación de tablas se realizo correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub
    Private Sub cmdActualizarTablas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActualizarTablas.Click
        pro_ActualizarCampos()
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_VALOMANT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_VerificarTablas()
        pro_ActivarBotonInsertarDatos()

    End Sub
    Private Sub cmdVISTATIPORESO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVISTATIPORESO.Click
        Dim TipoResolicion As frm_TIPORESO = frm_TIPORESO.instance
        TipoResolicion.Show()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ClaseOsector As frm_CLASSECT = frm_CLASSECT.instance
        ClaseOsector.Show()

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim CategoriaDeSuelo As frm_CATESUEL = frm_CATESUEL.instance
        CategoriaDeSuelo.Show()

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim CaracteristicaDePredio As frm_CARAPRED = frm_CARAPRED.instance
        CaracteristicaDePredio.Show()

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ModoDeAdquisicion As frm_MODOADQU = frm_MODOADQU.instance
        ModoDeAdquisicion.Show()

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim DestinacionEconomica As frm_DESTECON = frm_DESTECON.instance
        DestinacionEconomica.Show()

    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim CalidadDePropietario As frm_CALIPROP = frm_CALIPROP.instance
        CalidadDePropietario.Show()

    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim TipoDeDocumento As frm_TIPODOCU = frm_TIPODOCU.instance
        TipoDeDocumento.Show()

    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim Sexo As frm_SEXO = frm_SEXO.instance
        Sexo.Show()

    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim Departamento As frm_DEPARTAMENTO = frm_DEPARTAMENTO.instance
        Departamento.Show()

    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim Municipio As frm_MUNICIPIO = frm_MUNICIPIO.instance
        Municipio.Show()

    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim ClaseDeConstruccion As frm_CLASCONS = frm_CLASCONS.instance
        ClaseDeConstruccion.Show()

    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TipoDeConstruccion As frm_TIPOCONS = frm_TIPOCONS.instance
        TipoDeConstruccion.Show()

    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim TipoCalificacion As frm_TIPOCALI = frm_TIPOCALI.instance
        TipoCalificacion.Show()
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'Dim CodigoDeCalificacion As New frm_CODICALI
        'CodigoDeCalificacion.ShowDialog()
    End Sub

    Private Sub chkACTUTIPORESO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUTIPORESO.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUCLASSECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUCLASSECT.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUCATESUEL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUCATESUEL.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUCARAPRED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUCARAPRED.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUMODOADQU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUMODOADQU.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUDESTECON_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUDESTECON.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUCALIPROP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUCALIPROP.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUTIPODOCU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUTIPODOCU.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUSEXO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUSEXO.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUDEPARTAMENTO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUDEPARTAMENTO.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUMUNICIPIO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUMUNICIPIO.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUCLASCONS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUCLASCONS.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUCODICALI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUCODICALI.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub
    Private Sub chkACTUTIPOCALI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkACTUTIPOCALI.CheckedChanged
        pro_ActivarBotonInsertarDatos()
    End Sub


#End Region

End Class