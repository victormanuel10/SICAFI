Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_VARIZOFI

    '======================================
    '*** INSERTAR VARIABLES ZONA FISICA ***
    '======================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboVAZFDEPA.DataSource = New DataTable
        Me.cboVAZFMUNI.DataSource = New DataTable
        Me.cboVAZFCLSE.DataSource = New DataTable
        Me.cboVAZFZOFI.DataSource = New DataTable
        Me.cboVAZFCLSU.DataSource = New DataTable
        Me.cboVAZFARAC.DataSource = New DataTable
        Me.cboVAZFTRUR.DataSource = New DataTable
        Me.cboVAZFDEST.DataSource = New DataTable
        Me.cboVAZFSEDE.DataSource = New DataTable
        Me.cboVAZFSERV.DataSource = New DataTable
        Me.cboVAZFVIAS.DataSource = New DataTable
        Me.cboVAZFTOPO.DataSource = New DataTable
        Me.cboVAZFESTA.DataSource = New DataTable
        Me.cboVAZFZFAC.DataSource = New DataTable
        Me.cboVAZFZOEC.DataSource = New DataTable
        Me.cboVAZFZEAC.DataSource = New DataTable
        Me.cboVAZFAGUA.DataSource = New DataTable
        Me.cboVAZFAHT.DataSource = New DataTable

        Me.lblVAZFDEPA.Text = ""
        Me.lblVAZFMUNI.Text = ""
        Me.lblVAZFCLSE.Text = ""
        Me.lblVAZFZOFI.Text = ""
        Me.lblVAZFCLSU.Text = ""
        Me.lblVAZFARAC.Text = ""
        Me.lblVAZFTRUR.Text = ""
        Me.lblVAZFDEST.Text = ""
        Me.lblVAZFSEDE.Text = ""
        Me.lblVAZFSERV.Text = ""
        Me.lblVAZFVIAS.Text = ""
        Me.lblVAZFTOPO.Text = ""
        Me.lblVAZFZFAC.Text = ""
        Me.lblVAZFZOEC.Text = ""
        Me.lblVAZFZEAC.Text = ""
        Me.lblVAZFAGUA.Text = ""
        Me.lblVAZFAHT.Text = ""

        Me.txtVAZFVA01.Text = "0"
        Me.txtVAZFVA02.Text = "0"
        Me.txtVAZFVA03.Text = "0"
        Me.txtVAZFVA04.Text = "0"
        Me.txtVAZFVA05.Text = "0"
        Me.txtVAZFVA06.Text = "0"
        Me.txtVAZFVA07.Text = "0"
        Me.txtVAZFVA08.Text = "0"
        Me.txtVAZFVA09.Text = "0"
        Me.txtVAZFVA10.Text = "0"
        Me.txtVAZFVACO.Text = "0"
        Me.txtVAZFVACA.Text = "0"
        Me.txtVAZFPOBL.Text = "5"

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            Me.txtVAZFVACO.Text = fun_Quita_Letras(Me.txtVAZFVACO)
            Me.txtVAZFVACA.Text = fun_Quita_Letras(Me.txtVAZFVACA)
            Me.txtVAZFVA01.Text = fun_Quita_Letras(Me.txtVAZFVA01)
            Me.txtVAZFVA02.Text = fun_Quita_Letras(Me.txtVAZFVA02)
            Me.txtVAZFVA03.Text = fun_Quita_Letras(Me.txtVAZFVA03)
            Me.txtVAZFVA04.Text = fun_Quita_Letras(Me.txtVAZFVA04)
            Me.txtVAZFVA05.Text = fun_Quita_Letras(Me.txtVAZFVA05)
            Me.txtVAZFVA06.Text = fun_Quita_Letras(Me.txtVAZFVA06)
            Me.txtVAZFVA07.Text = fun_Quita_Letras(Me.txtVAZFVA07)
            Me.txtVAZFVA08.Text = fun_Quita_Letras(Me.txtVAZFVA08)
            Me.txtVAZFVA09.Text = fun_Quita_Letras(Me.txtVAZFVA09)
            Me.txtVAZFVA10.Text = fun_Quita_Letras(Me.txtVAZFVA10)

            ' instancia la clase
            Dim objdatos As New cla_VARIZOFI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_VARIZOFI(Me.cboVAZFDEPA, _
                                                                                                Me.cboVAZFMUNI, _
                                                                                                Me.cboVAZFCLSE, _
                                                                                                Me.cboVAZFZOFI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boVAZFDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFDEPA)
            Dim boVAZFMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFMUNI)
            Dim boVAZFCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFCLSE)
            Dim boVAZFZOFI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFZOFI)
            Dim boVAZFCLSU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFCLSU)
            Dim boVAZFARAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFARAC)
            Dim boVAZFTRUR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFTRUR)
            Dim boVAZFDEST As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFDEST)
            Dim boVAZFSEDE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFSEDE)
            Dim boVAZFSERV As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFSERV)
            Dim boVAZFVIAS As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFVIAS)
            Dim boVAZFTOPO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFTOPO)
            Dim boVAZFESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFESTA)
            Dim boVAZFZFAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFZFAC)
            Dim boVAZFZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFZOEC)
            Dim boVAZFZEAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFZEAC)
            Dim boVAZFAGUA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFAGUA)
            Dim boVAZFAHT As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAZFAHT)

            Dim boVAZFVA01 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA01)
            Dim boVAZFVA02 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA02)
            Dim boVAZFVA03 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA03)
            Dim boVAZFVA04 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA04)
            Dim boVAZFVA05 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA05)
            Dim boVAZFVA06 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA06)
            Dim boVAZFVA07 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA07)
            Dim boVAZFVA08 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA08)
            Dim boVAZFVA09 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA09)
            Dim boVAZFVA10 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVA10)
            Dim boVAZFVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVACO)
            Dim boVAZFVACA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFVACA)
            Dim boVAZFPOBL As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVAZFPOBL)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boVAZFDEPA = True And _
               boVAZFMUNI = True And _
               boVAZFCLSE = True And _
               boVAZFZOFI = True And _
               boVAZFCLSU = True And _
               boVAZFARAC = True And _
               boVAZFDEST = True And _
               boVAZFSEDE = True And _
               boVAZFSERV = True And _
               boVAZFVIAS = True And _
               boVAZFTOPO = True And _
               boVAZFESTA = True And _
               boVAZFVA01 = True And _
               boVAZFVA02 = True And _
               boVAZFVA03 = True And _
               boVAZFVA04 = True And _
               boVAZFVA05 = True And _
               boVAZFVA06 = True And _
               boVAZFVA07 = True And _
               boVAZFVA08 = True And _
               boVAZFVA09 = True And _
               boVAZFVA10 = True And _
               boVAZFVACO = True And _
               boVAZFVACA = True And _
               boVAZFZFAC = True And _
               boVAZFZOEC = True And _
               boVAZFZEAC = True And _
               boVAZFAGUA = True And _
               boVAZFAHT = True And _
               boVAZFPOBL = True Then

                Dim objdatos22 As New cla_VARIZOFI

                If (objdatos22.fun_Insertar_MANT_VARIZOFI(Me.cboVAZFDEPA.SelectedValue, _
                                                          Me.cboVAZFMUNI.SelectedValue, _
                                                          Me.cboVAZFCLSE.SelectedValue, _
                                                          Me.cboVAZFZOFI.SelectedValue, _
                                                          Me.cboVAZFCLSU.SelectedValue, _
                                                          Me.cboVAZFARAC.SelectedValue, _
                                                          Me.cboVAZFTRUR.SelectedValue, _
                                                          Me.cboVAZFDEST.SelectedValue, _
                                                          Me.cboVAZFSEDE.SelectedValue, _
                                                          Me.cboVAZFSERV.SelectedValue, _
                                                          Me.cboVAZFVIAS.SelectedValue, _
                                                          Me.cboVAZFTOPO.SelectedValue, _
                                                          Me.cboVAZFAGUA.SelectedValue, _
                                                          Me.cboVAZFAHT.SelectedValue, _
                                                          Me.cboVAZFESTA.SelectedValue, _
                                                          Me.txtVAZFVA01.Text, _
                                                          Me.txtVAZFVA02.Text, _
                                                          Me.txtVAZFVA03.Text, _
                                                          Me.txtVAZFVA04.Text, _
                                                          Me.txtVAZFVA05.Text, _
                                                          Me.txtVAZFVA06.Text, _
                                                          Me.txtVAZFVA07.Text, _
                                                          Me.txtVAZFVA08.Text, _
                                                          Me.txtVAZFVA09.Text, _
                                                          Me.txtVAZFVA10.Text, _
                                                          Me.txtVAZFVACO.Text, _
                                                          Me.txtVAZFVACA.Text, _
                                                          Me.txtVAZFPOBL.Text, _
                                                          Me.cboVAZFZFAC.SelectedValue, _
                                                          Me.cboVAZFZOEC.SelectedValue, _
                                                          Me.cboVAZFZEAC.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboVAZFDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboVAZFDEPA.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboVAZFDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_PREDEXEN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboVAZFDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVAZFDEPA.KeyPress, cboVAZFMUNI.KeyPress, cboVAZFCLSE.KeyPress, cboVAZFZOFI.KeyPress, cboVAZFCLSU.KeyPress, cboVAZFARAC.KeyPress, cboVAZFTRUR.KeyPress, cboVAZFDEST.KeyPress, cboVAZFSEDE.KeyPress, cboVAZFSERV.KeyPress, cboVAZFVIAS.KeyPress, cboVAZFTOPO.KeyPress, cboVAZFESTA.KeyPress, txtVAZFVA01.KeyPress, txtVAZFVA02.KeyPress, txtVAZFVA03.KeyPress, txtVAZFVA04.KeyPress, txtVAZFVA05.KeyPress, txtVAZFVA06.KeyPress, txtVAZFVA07.KeyPress, txtVAZFVA08.KeyPress, txtVAZFVA09.KeyPress, txtVAZFVA10.KeyPress, txtVAZFVACO.KeyPress, txtVAZFVACA.KeyPress, txtVAZFPOBL.KeyPress, cboVAZFZFAC.KeyPress, cboVAZFZOEC.KeyPress, cboVAZFZEAC.KeyPress, cboVAZFAGUA.KeyPress, cboVAZFAHT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboVAZFDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboVAZFDEPA, Me.cboVAZFDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboVAZFMUNI, Me.cboVAZFMUNI.SelectedIndex, Me.cboVAZFDEPA)
        End If
    End Sub
    Private Sub cboVAZFCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboVAZFCLSE, Me.cboVAZFCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFZOFI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFZOFI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboVAZFZOFI, Me.cboVAZFZOFI.SelectedIndex, cboVAZFDEPA, cboVAZFMUNI, cboVAZFCLSE)
        End If
    End Sub
    Private Sub cboVAZFCLSU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFCLSU.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSUEL_Descripcion(Me.cboVAZFCLSU, Me.cboVAZFCLSU.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFARAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFARAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_AREAACTI_Descripcion(Me.cboVAZFARAC, Me.cboVAZFARAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFTRUR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFTRUR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TRATURBA_Descripcion(Me.cboVAZFTRUR, Me.cboVAZFTRUR.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFDEST_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFDEST.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTINACION_Descripcion(Me.cboVAZFDEST, Me.cboVAZFDEST.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFCONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFSEDE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SEGUDEST_Descripcion(Me.cboVAZFSEDE, Me.cboVAZFSEDE.SelectedIndex, Me.cboVAZFDEST)
        End If
    End Sub
    Private Sub cboVAZFSERV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFSERV.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SERVICOS_Descripcion(Me.cboVAZFSERV, Me.cboVAZFSERV.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFVIAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFVIAS.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIAS_Descripcion(Me.cboVAZFVIAS, Me.cboVAZFVIAS.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFTOPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFTOPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TOPOGRAFIA_Descripcion(Me.cboVAZFTOPO, Me.cboVAZFTOPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFAGUA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFAGUA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_AGUAS_Descripcion(Me.cboVAZFAGUA, Me.cboVAZFAGUA.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFAHT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFAHT.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_AHT_Descripcion(Me.cboVAZFAHT, Me.cboVAZFAHT.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVAZFESTA, Me.cboVAZFESTA.SelectedIndex)
        End If
    End Sub
    Private Sub cboVAZFZFAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFZFAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZOFIACTU_Descripcion(Me.cboVAZFZFAC, Me.cboVAZFZFAC.SelectedIndex, cboVAZFDEPA, cboVAZFMUNI, cboVAZFCLSE)
        End If
    End Sub
    Private Sub cboVAZFZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFZOEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(Me.cboVAZFZOEC, Me.cboVAZFZOEC.SelectedIndex, cboVAZFDEPA, cboVAZFMUNI, cboVAZFCLSE)
        End If
    End Sub
    Private Sub cboVAZFZEAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAZFZEAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZOECACTU_Descripcion(Me.cboVAZFZEAC, Me.cboVAZFZEAC.SelectedIndex, cboVAZFDEPA, cboVAZFMUNI, cboVAZFCLSE)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFDEPA.GotFocus, cboVAZFMUNI.GotFocus, cboVAZFCLSE.GotFocus, cboVAZFZOFI.GotFocus, cboVAZFCLSU.GotFocus, cboVAZFARAC.GotFocus, cboVAZFTRUR.GotFocus, cboVAZFDEST.GotFocus, cboVAZFSEDE.GotFocus, cboVAZFSERV.GotFocus, cboVAZFVIAS.GotFocus, cboVAZFTOPO.GotFocus, cboVAZFESTA.GotFocus, cboVAZFZFAC.GotFocus, cboVAZFZOEC.GotFocus, cboVAZFZEAC.GotFocus, cboVAZFAGUA.GotFocus, cboVAZFAHT.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVAZFVA01.GotFocus, txtVAZFVA02.GotFocus, txtVAZFVA03.GotFocus, txtVAZFVA04.GotFocus, txtVAZFVA05.GotFocus, txtVAZFVA06.GotFocus, txtVAZFVA07.GotFocus, txtVAZFVA08.GotFocus, txtVAZFVA09.GotFocus, txtVAZFVA10.GotFocus, txtVAZFVACO.GotFocus, txtVAZFVACA.GotFocus, txtVAZFPOBL.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboVAZFDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFDEPA.SelectedIndexChanged
        Me.lblVAZFDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboVAZFDEPA), String)

        Me.cboVAZFMUNI.DataSource = New DataTable
        Me.lblVAZFMUNI.Text = ""

        Me.cboVAZFZOFI.DataSource = New DataTable
        Me.lblVAZFZOFI.Text = ""

        Me.cboVAZFZFAC.DataSource = New DataTable
        Me.lblVAZFZFAC.Text = ""

        Me.cboVAZFZOEC.DataSource = New DataTable
        Me.lblVAZFZOEC.Text = ""

        Me.cboVAZFZEAC.DataSource = New DataTable
        Me.lblVAZFZEAC.Text = ""
    End Sub
    Private Sub cboVAZFMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFMUNI.SelectedIndexChanged
        Me.lblVAZFMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboVAZFDEPA, Me.cboVAZFMUNI), String)
    End Sub
    Private Sub cboVAZFCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFCLSE.SelectedIndexChanged
        Me.lblVAZFCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboVAZFCLSE), String)
    End Sub
    Private Sub cboVAZFZOFI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFZOFI.SelectedIndexChanged
        Me.lblVAZFZOFI.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI_Codigo(Me.cboVAZFDEPA, Me.cboVAZFMUNI, Me.cboVAZFCLSE, Me.cboVAZFZOFI), String)
    End Sub
    Private Sub cboVAZFCLSU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFCLSU.SelectedIndexChanged
        Me.lblVAZFCLSU.Text = CType(fun_Buscar_Lista_Valores_CLASSUEL_Codigo(Me.cboVAZFCLSU), String)
    End Sub
    Private Sub cboVAZFARAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFARAC.SelectedIndexChanged
        Me.lblVAZFARAC.Text = CType(fun_Buscar_Lista_Valores_AREAACTI_Codigo(Me.cboVAZFARAC), String)
    End Sub
    Private Sub cboVAZFTRUR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFTRUR.SelectedIndexChanged
        Me.lblVAZFTRUR.Text = CType(fun_Buscar_Lista_Valores_TRATURBA_Codigo(Me.cboVAZFTRUR), String)
    End Sub
    Private Sub cboVAZFDEST_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFDEST.SelectedIndexChanged
        Me.lblVAZFDEST.Text = CType(fun_Buscar_Lista_Valores_DESTINACION_Codigo(Me.cboVAZFDEST), String)

        Me.cboVAZFSEDE.DataSource = New DataTable
        Me.lblVAZFSEDE.Text = ""
    End Sub
    Private Sub cboVAZFSEDE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFSEDE.SelectedIndexChanged
        Me.lblVAZFSEDE.Text = CType(fun_Buscar_Lista_Valores_SEGUDEST_Codigo(Me.cboVAZFDEST, Me.cboVAZFSEDE), String)
    End Sub
    Private Sub cboVAZFSERV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFSERV.SelectedIndexChanged
        Me.lblVAZFSERV.Text = CType(fun_Buscar_Lista_Valores_TRATURBA_Codigo(Me.cboVAZFSERV), String)
    End Sub
    Private Sub cboVAZFVIAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFVIAS.SelectedIndexChanged
        Me.lblVAZFVIAS.Text = CType(fun_Buscar_Lista_Valores_VIAS_Codigo(Me.cboVAZFVIAS), String)
    End Sub
    Private Sub cboVAZFTOPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFTOPO.SelectedIndexChanged
        Me.lblVAZFTOPO.Text = CType(fun_Buscar_Lista_Valores_TOPOGRAFIA_Codigo(Me.cboVAZFTOPO), String)
    End Sub
    Private Sub cboVAZFAGUA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFAGUA.SelectedIndexChanged
        Me.lblVAZFAGUA.Text = CType(fun_Buscar_Lista_Valores_AGUAS_Codigo(Me.cboVAZFAGUA), String)
    End Sub
    Private Sub cboVAZFAHT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFAHT.SelectedIndexChanged
        Me.lblVAZFAHT.Text = CType(fun_Buscar_Lista_Valores_AHT_Codigo(Me.cboVAZFAHT), String)
    End Sub
    Private Sub cboVAZFZFAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFZFAC.SelectedIndexChanged
        Me.lblVAZFZFAC.Text = CType(fun_Buscar_Lista_Valores_ZOFIACTU_Codigo(Me.cboVAZFDEPA, Me.cboVAZFMUNI, Me.cboVAZFCLSE, Me.cboVAZFZFAC), String)
    End Sub
    Private Sub cboVAZFZOec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFZOEC.SelectedIndexChanged
        Me.lblVAZFZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboVAZFDEPA, Me.cboVAZFMUNI, Me.cboVAZFCLSE, Me.cboVAZFZOEC), String)
    End Sub
    Private Sub cboVAZFZEAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVAZFZEAC.SelectedIndexChanged
        Me.lblVAZFZEAC.Text = CType(fun_Buscar_Lista_Valores_ZOECACTU_Codigo(Me.cboVAZFDEPA, Me.cboVAZFMUNI, Me.cboVAZFCLSE, Me.cboVAZFZEAC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboVAZFDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboVAZFDEPA, Me.cboVAZFDEPA.SelectedIndex)
    End Sub
    Private Sub cboVAZFMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboVAZFMUNI, Me.cboVAZFMUNI.SelectedIndex, Me.cboVAZFDEPA)
    End Sub
    Private Sub cboVAZFCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboVAZFCLSE, Me.cboVAZFCLSE.SelectedIndex)
    End Sub
    Private Sub cboVAZFZOFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFZOFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_X_MUNICIPIO_Descripcion(Me.cboVAZFZOFI, Me.cboVAZFZOFI.SelectedIndex, Me.cboVAZFDEPA, cboVAZFMUNI, cboVAZFCLSE)
    End Sub
    Private Sub cboVAZFCLSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFCLSU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSUEL_Descripcion(Me.cboVAZFCLSU, Me.cboVAZFCLSU.SelectedIndex)
    End Sub
    Private Sub cboVAZFARAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFARAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_AREAACTI_Descripcion(Me.cboVAZFARAC, Me.cboVAZFARAC.SelectedIndex)
    End Sub
    Private Sub cboVAZFTRUR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFTRUR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TRATURBA_Descripcion(Me.cboVAZFTRUR, Me.cboVAZFTRUR.SelectedIndex)
    End Sub
    Private Sub cboVAZFDEST_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFDEST.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTINACION_Descripcion(Me.cboVAZFDEST, Me.cboVAZFDEST.SelectedIndex)
    End Sub
    Private Sub cboVAZFSEDE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFSEDE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SEGUDEST_Descripcion(Me.cboVAZFSEDE, Me.cboVAZFSEDE.SelectedIndex, Me.cboVAZFDEST)
    End Sub
    Private Sub cboVAZFSERV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFSERV.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SERVICOS_Descripcion(Me.cboVAZFSERV, Me.cboVAZFSERV.SelectedIndex)
    End Sub
    Private Sub cboVAZFVIAS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFVIAS.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIAS_Descripcion(Me.cboVAZFVIAS, Me.cboVAZFVIAS.SelectedIndex)
    End Sub
    Private Sub cboVAZFTOPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFTOPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TOPOGRAFIA_Descripcion(Me.cboVAZFTOPO, Me.cboVAZFTOPO.SelectedIndex)
    End Sub
    Private Sub cboVAZFAGUA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFAGUA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_AGUAS_Descripcion(Me.cboVAZFAGUA, Me.cboVAZFAGUA.SelectedIndex)
    End Sub
    Private Sub cboVAZFAHT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFAHT.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_AHT_Descripcion(Me.cboVAZFAHT, Me.cboVAZFAHT.SelectedIndex)
    End Sub
    Private Sub cboVAZFESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVAZFESTA, Me.cboVAZFESTA.SelectedIndex)
    End Sub
    Private Sub cboVAZFZFAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFZFAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZOFIACTU_X_MUNICIPIO_Descripcion(Me.cboVAZFZFAC, Me.cboVAZFZFAC.SelectedIndex, Me.cboVAZFDEPA, cboVAZFMUNI, cboVAZFCLSE)
    End Sub
    Private Sub cboVAZFZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(Me.cboVAZFZOEC, Me.cboVAZFZOEC.SelectedIndex, Me.cboVAZFDEPA, cboVAZFMUNI, cboVAZFCLSE)
    End Sub
    Private Sub cboVAZFZEAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAZFZEAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZOECACTU_X_MUNICIPIO_Descripcion(Me.cboVAZFZEAC, Me.cboVAZFZEAC.SelectedIndex, Me.cboVAZFDEPA, cboVAZFMUNI, cboVAZFCLSE)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVAZFVACO.Validated, txtVAZFVACA.Validated, txtVAZFVA01.Validated, txtVAZFVA02.Validated, txtVAZFVA03.Validated, txtVAZFVA04.Validated, txtVAZFVA05.Validated, txtVAZFVA06.Validated, txtVAZFVA07.Validated, txtVAZFVA08.Validated, txtVAZFVA09.Validated, txtVAZFVA10.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVACO.Text) = True Then

                If CInt(Me.txtVAZFVACO.Text) <> 0 Then
                    Me.txtVAZFVACA.Text = CInt(Me.txtVAZFVACO.Text) * 0.6
                    Me.txtVAZFVACA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVACA.Text)
                End If

                Me.txtVAZFVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVACO.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVACA.Text) = True Then
                Me.txtVAZFVACA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVACA.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA01.Text) = True Then
                Me.txtVAZFVA01.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA01.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA02.Text) = True Then
                Me.txtVAZFVA02.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA02.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA03.Text) = True Then
                Me.txtVAZFVA03.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA03.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA04.Text) = True Then
                Me.txtVAZFVA04.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA04.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA05.Text) = True Then
                Me.txtVAZFVA05.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA05.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA06.Text) = True Then
                Me.txtVAZFVA06.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA06.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA07.Text) = True Then
                Me.txtVAZFVA07.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA07.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA08.Text) = True Then
                Me.txtVAZFVA08.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA08.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA09.Text) = True Then
                Me.txtVAZFVA09.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA09.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtVAZFVA10.Text) = True Then
                Me.txtVAZFVA10.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtVAZFVA10.Text)
            End If

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