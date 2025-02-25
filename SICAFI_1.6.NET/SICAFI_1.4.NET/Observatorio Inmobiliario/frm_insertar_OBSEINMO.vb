Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_OBSEINMO

    '==========================================
    '*** INSERTAR OBSERVATORIO INMOBILIARIO ***
    '==========================================

#Region "VARIABLES"

    Private vl_inOBINSECU As Integer = 0

#End Region

#Region "PROCEDIMIENTOS"

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
        Me.lblOBINVIAV.Text = ""
        Me.txtOBINMANZ.Text = ""
        Me.txtOBINPRED.Text = ""
        Me.txtOBINEDIF.Text = ""
        Me.txtOBINUNPR.Text = ""
        Me.lblOBINZOFI.Text = ""

        Me.cboOBINCOMU.DataSource = New DataTable
        Me.cboOBINCORR.DataSource = New DataTable
        Me.cboOBINDEPA.DataSource = New DataTable
        Me.cboOBINMUNI.DataSource = New DataTable
        Me.cboOBINBAVE.DataSource = New DataTable
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
        Me.cboOBINVIAV.DataSource = New DataTable
        Me.cboOBINZOFI.DataSource = New DataTable

        Me.txtOBINDESC.Text = ""
        Me.txtOBINDIRE.Text = ""
        Me.txtOBINNUFI.Text = "0"
        Me.txtOBINOBSE.Text = ""
        Me.txtOBINAVCA.Text = "0"
        Me.txtOBINAVCO.Text = "0"
        Me.txtOBINVM2T.Text = "0"
        Me.txtOBINARTE.Text = "0"
        Me.txtOBINVM2C.Text = "0"
        Me.txtOBINARCO.Text = "0"
        Me.txtOBINEDCO.Text = "0"
        Me.txtOBINNUPI.Text = "0"
        Me.txtOBINOBSE.Text = ""
        Me.txtOBINPUCA.Text = "0"

        Me.chkOBINCONJ.Checked = False
        Me.chkOBINCONJ.Checked = False
        Me.chkOBINVIIS.Checked = False
        Me.chkOBINAVPA.Checked = False
        Me.chkOBINAVCU.Checked = False
        Me.rbdOBINURAB.Checked = False
        Me.rbdOBINURCE.Checked = False

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_OBSEINMO
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_OBSEINMO

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("OBINSECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("OBINSECU"))

                    If NroMayor > Posicion Then
                        inFPDESECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inFPDESECU = Posicion
                    End If
                Next

                inFPDESECU += 1
            End If

            Return inFPDESECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' convierte a numero
            Me.txtOBINAVCA.Text = fun_Quita_Letras(Me.txtOBINAVCA)
            Me.txtOBINAVCO.Text = fun_Quita_Letras(Me.txtOBINAVCO)
            Me.txtOBINVM2C.Text = fun_Quita_Letras(Me.txtOBINVM2C)
            Me.txtOBINVM2T.Text = fun_Quita_Letras(Me.txtOBINVM2T)

            ' instancia la clase
            Dim objdatos As New cla_OBSEINMO

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_OBSEINMO(Me.cboOBINCLSE.SelectedValue & Me.cboOBINMUNI.SelectedValue & Me.cboOBINCORR.SelectedValue & Me.cboOBINBAVE.SelectedValue & Me.txtOBINMANZ.Text & Me.txtOBINPRED.Text & Me.txtOBINEDIF.Text & Me.txtOBINUNPR.Text)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOBINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINDEPA)
            Dim boOBINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINMUNI)
            Dim boOBINCORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINCORR)
            Dim boOBINBAVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINBAVE)
            Dim boOBINCOMU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINCOMU)
            Dim boOBINCAPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINCAPR)
            Dim boOBINESTR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINESTR)
            Dim boOBINMOBI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINMOBI)
            Dim boOBINVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINVIGE)
            Dim boOBINTIPO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINTIPO)
            Dim boOBINMEIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINMEIN)
            Dim boOBINVIAV As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINVIAV)
            Dim boOBINMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINMANZ)
            Dim boOBINPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINPRED)
            Dim boOBINEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINEDIF)
            Dim boOBINUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINUNPR)
            Dim boOBINAVCA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINAVCA)
            Dim boOBINAVCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINAVCO)
            Dim boOBINVM2T As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINVM2T)
            Dim boOBINVM2C As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINVM2C)
            Dim boOBINARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINARTE)
            Dim boOBINARCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINARCO)
            Dim boOBINEDCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINEDCO)
            Dim boOBINNUPI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINNUPI)
            Dim boOBINNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOBINNUFI)
            Dim boOBINCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINCLSE)
            Dim boOBINESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOBINESTA)

            Dim boOBINPUCA As Boolean = False

            If Me.txtOBINPUCA.Text = 0 And Me.cboOBINCLPR.SelectedIndex = 3 Then
                boOBINPUCA = False
                MessageBox.Show("Puntos de calificación en cero", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                boOBINPUCA = True
            End If

            vl_inOBINSECU = fun_NumeroDeSecuenciaDeRegistro()

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
                boOBINDEPA = True And _
                boOBINMUNI = True And _
                boOBINCORR = True And _
                boOBINBAVE = True And _
                boOBINCOMU = True And _
                boOBINCAPR = True And _
                boOBINESTR = True And _
                boOBINMOBI = True And _
                boOBINVIGE = True And _
                boOBINTIPO = True And _
                boOBINMEIN = True And _
                boOBINVIAV = True And _
                boOBINMANZ = True And _
                boOBINPRED = True And _
                boOBINEDIF = True And _
                boOBINUNPR = True And _
                boOBINAVCA = True And _
                boOBINAVCO = True And _
                boOBINVM2T = True And _
                boOBINVM2C = True And _
                boOBINARTE = True And _
                boOBINARCO = True And _
                boOBINEDCO = True And _
                boOBINNUPI = True And _
                boOBINNUFI = True And _
                boOBINCLSE = True And _
                boOBINESTA = True And _
                boOBINPUCA = True Then

                Dim stOBINCECA As String = Trim(Me.cboOBINCLSE.SelectedValue).ToString & Trim(Me.cboOBINMUNI.SelectedValue) & Trim(Me.cboOBINCORR.SelectedValue) & Trim(Me.cboOBINBAVE.SelectedValue) & Trim(Me.txtOBINMANZ.Text) & Trim(Me.txtOBINPRED.Text) & Trim(Me.txtOBINEDIF.Text) & Trim(Me.txtOBINUNPR.Text)
                Dim stOBINFECH As String = fun_fecha()
                Dim stOBINRUIM As String = ""

                Dim objdatos22 As New cla_OBSEINMO

                If (objdatos22.fun_Insertar_OBSEINMO(vl_inOBINSECU, _
                                                     stOBINCECA, _
                                                     Me.txtOBINNUFI.Text, _
                                                     Me.txtOBINDESC.Text, _
                                                     Me.txtOBINDIRE.Text, _
                                                     Me.cboOBINCOMU.SelectedValue, _
                                                     Me.cboOBINDEPA.SelectedValue, _
                                                     Me.cboOBINMUNI.SelectedValue, _
                                                     Me.cboOBINCORR.SelectedValue, _
                                                     Me.cboOBINBAVE.SelectedValue, _
                                                     Me.txtOBINMANZ.Text, _
                                                     Me.txtOBINPRED.Text, _
                                                     Me.txtOBINEDIF.Text, _
                                                     Me.txtOBINUNPR.Text, _
                                                     Me.cboOBINCLSE.SelectedValue, _
                                                     Me.cboOBINCAPR.SelectedValue, _
                                                     Me.txtOBINAVCA.Text, _
                                                     Me.txtOBINAVCO.Text, _
                                                     Me.txtOBINVM2T.Text, _
                                                     Me.txtOBINVM2C.Text, _
                                                     Me.txtOBINARTE.Text, _
                                                     Me.txtOBINARCO.Text, _
                                                     Me.cboOBINVIGE.SelectedValue, _
                                                     Me.txtOBINEDCO.Text, _
                                                     Me.cboOBINESTR.SelectedValue, _
                                                     Me.cboOBINZOEC.SelectedValue, _
                                                     Me.cboOBINTIPO.SelectedValue, _
                                                     Me.cboOBINCLCO.SelectedValue, _
                                                     Me.cboOBINTICO.SelectedValue, _
                                                     Me.txtOBINNUPI.Text, _
                                                     Me.cboOBINMOBI.SelectedValue, _
                                                     Me.cboOBINCLPR.SelectedValue, _
                                                     stOBINFECH, _
                                                     Me.cboOBINMEIN.SelectedValue, _
                                                     Me.txtOBINOBSE.Text, _
                                                     Me.cboOBINVIAV.SelectedValue, _
                                                     Me.cboOBINESTA.SelectedValue, _
                                                     stOBINRUIM, _
                                                     Me.chkOBINCONJ.Checked, _
                                                     Me.chkOBINVIIS.Checked, _
                                                     Me.chkOBINAVPA.Checked, _
                                                     Me.chkOBINAVCU.Checked, _
                                                     Me.rbdOBINURAB.Checked, _
                                                     Me.rbdOBINURCE.Checked, _
                                                     Me.cboOBINZOFI.SelectedValue, _
                                                     Me.txtOBINPUCA.Text)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(8)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.cboOBINMUNI.SelectedValue & "-" & Me.cboOBINCLSE.SelectedValue & "-" & Me.cboOBINCORR.SelectedValue & "-" & Me.cboOBINBAVE.SelectedValue & "-" & Me.txtOBINMANZ.Text & "-" & Me.txtOBINPRED.Text & "-" & Me.txtOBINEDIF.Text & "-" & Me.txtOBINUNPR.Text & "-" & Me.cboOBINVIAV.SelectedValue

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then

                        Dim objdatos1 As New cla_OBSEINMO
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_Buscar_CODIGO_X_OBSEINMO(CInt(vl_inOBINSECU))

                        If tbl1.Rows.Count > 0 Then

                            Dim inNroIdRe As New frm_OBSEINMO(tbl1.Rows(0).Item("OBINIDRE"))

                        End If

                        Me.cboOBINDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboOBINDEPA.Focus()
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
        Dim inNroIdRe As New frm_OBSEINMO(0)
        Me.cboOBINDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboOBINDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboOBINDEPA.KeyPress, cboOBINMUNI.KeyPress, cboOBINCOMU.KeyPress, cboOBINCORR.KeyPress, cboOBINBAVE.KeyPress, cboOBINCLSE.KeyPress, txtOBINMANZ.KeyPress, txtOBINPRED.KeyPress, txtOBINEDIF.KeyPress, txtOBINUNPR.KeyPress, txtOBINDESC.KeyPress, txtOBINDIRE.KeyPress, cboOBINCAPR.KeyPress, txtOBINNUFI.KeyPress, cboOBINESTR.KeyPress, cboOBINZOEC.KeyPress, cboOBINTIPO.KeyPress, cboOBINCLPR.KeyPress, cboOBINCLCO.KeyPress, cboOBINTICO.KeyPress, cboOBINMOBI.KeyPress, cboOBINMEIN.KeyPress, cboOBINVIGE.KeyPress, cboOBINESTA.KeyPress, txtOBINAVCA.KeyPress, txtOBINAVCO.KeyPress, txtOBINVM2T.KeyPress, txtOBINARTE.KeyPress, txtOBINARCO.KeyPress, cboOBINVIAV.KeyPress, txtOBINEDCO.KeyPress, txtOBINNUPI.KeyPress
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
    Private Sub cboOBINBAVE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINBAVE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(Me.cboOBINBAVE, Me.cboOBINBAVE.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE)
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
    Private Sub cboOBINVIAV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINVIAV.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOBINVIAV, Me.cboOBINVIAV.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOBINESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOBINESTA, Me.cboOBINESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBINMANZ.GotFocus, txtOBINPRED.GotFocus, txtOBINEDIF.GotFocus, txtOBINUNPR.GotFocus, txtOBINDESC.GotFocus, txtOBINDIRE.GotFocus, txtOBINNUFI.GotFocus, txtOBINAVCA.GotFocus, txtOBINAVCO.GotFocus, txtOBINVM2T.GotFocus, txtOBINARTE.GotFocus, txtOBINVM2C.GotFocus, txtOBINARCO.GotFocus, txtOBINEDCO.GotFocus, txtOBINNUPI.GotFocus, txtOBINOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINDEPA.GotFocus, cboOBINMUNI.GotFocus, cboOBINCOMU.GotFocus, cboOBINCORR.GotFocus, cboOBINBAVE.GotFocus, cboOBINCLSE.GotFocus, cboOBINCAPR.GotFocus, cboOBINESTR.GotFocus, cboOBINZOEC.GotFocus, cboOBINTIPO.GotFocus, cboOBINCLPR.GotFocus, cboOBINCLCO.GotFocus, cboOBINTICO.GotFocus, cboOBINMOBI.GotFocus, cboOBINMEIN.GotFocus, cboOBINVIGE.GotFocus, cboOBINESTA.GotFocus, cboOBINVIAV.GotFocus
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

        Me.cboOBINBAVE.DataSource = New DataTable
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

        Me.cboOBINBAVE.DataSource = New DataTable
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

        Me.cboOBINBAVE.DataSource = New DataTable
        Me.lblOBINBAVE.Text = ""

        Me.cboOBINZOEC.DataSource = New DataTable
        Me.lblOBINZOEC.Text = ""

        Me.cboOBINZOFI.DataSource = New DataTable
        Me.lblOBINZOFI.Text = ""

        Me.cboOBINTICO.DataSource = New DataTable
        Me.lblOBINTICO.Text = ""

    End Sub
    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINCLSE.SelectedIndexChanged
        Me.lblOBINCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboOBINCLSE), String)

        Me.cboOBINBAVE.DataSource = New DataTable
        Me.lblOBINBAVE.Text = ""

        Me.cboOBINZOEC.DataSource = New DataTable
        Me.lblOBINZOEC.Text = ""

        Me.cboOBINZOFI.DataSource = New DataTable
        Me.lblOBINZOFI.Text = ""

        Me.cboOBINTICO.DataSource = New DataTable
        Me.lblOBINTICO.Text = ""
    End Sub
    Private Sub cboOBINBAVE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINBAVE.SelectedIndexChanged
        Me.lblOBINBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRVERE_Codigo(Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE, Me.cboOBINBAVE), String)
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
    Private Sub cboOBINVIAV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOBINVIAV.SelectedIndexChanged
        Me.lblOBINVIAV.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboOBINVIAV), String)
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
    Private Sub cboOBINBAVE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINBAVE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(Me.cboOBINBAVE, Me.cboOBINBAVE.SelectedIndex, Me.cboOBINDEPA, Me.cboOBINMUNI, Me.cboOBINCLSE, Me.cboOBINCORR)
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
    Private Sub cboOBINVIAV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINVIAV.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboOBINVIAV, Me.cboOBINVIAV.SelectedIndex)
    End Sub
    Private Sub cboOBINESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOBINESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOBINESTA, Me.cboOBINESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBINNUFI.Validated, txtOBINARTE.Validated, txtOBINEDCO.Validated, txtOBINNUPI.Validated, txtOBINVM2T.Validated
        If Trim(sender.text) = "" Then
            sender.text = 0
        End If
    End Sub

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
    Private Sub txtValidated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBINAVCA.Validated, txtOBINAVCO.Validated, txtOBINVM2C.Validated, txtOBINVM2T.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOBINAVCA.Text) = True Then
                Me.txtOBINAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOBINAVCA.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOBINAVCO.Text) = True Then
                Me.txtOBINAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOBINAVCO.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOBINVM2C.Text) = True Then
                Me.txtOBINVM2C.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOBINVM2C.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOBINVM2T.Text) = True Then
                Me.txtOBINVM2T.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOBINVM2T.Text)
            End If

        End If

    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtOBINARCO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOBINARCO.TextChanged
        If Trim(Me.txtOBINAVCO.Text) <> "0" And Trim(Me.txtOBINARCO.Text) <> "0" And Trim(Me.txtOBINARCO.Text) <> "" And Trim(Me.txtOBINAVCO.Text) <> "" Then
            Me.txtOBINVM2C.Text = CInt(Me.txtOBINAVCO.Text / Me.txtOBINARCO.Text)
            Me.txtOBINVM2T.Text = "0"
        End If
    End Sub
    Private Sub txtOBINARTE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOBINARTE.TextChanged
        If Trim(Me.txtOBINAVCO.Text) <> "0" And Trim(Me.txtOBINARTE.Text) <> "0" And Trim(Me.txtOBINARTE.Text) <> "" And Trim(Me.txtOBINAVCO.Text) <> "" Then
            Me.txtOBINVM2T.Text = CInt(Me.txtOBINAVCO.Text / Me.txtOBINARCO.Text)
            Me.txtOBINVM2C.Text = "0"
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