Imports REGLAS_DEL_NEGOCIO

Public Class frm_RANGOS

    '============================
    '*** MANTENIMIENTO RANGOS ***
    '============================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_RANGOS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_RANGOS
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

#Region "PROCEDIMIENTOS"

    Private Sub pro_ReconsultarFactores()

        Try
            Dim objdatos As New cla_FACTPROY

            If boCONSULTA = False Then
                Me.BindingSource_FACTORES_1.DataSource = objdatos.fun_Consultar_MANT_FACTPROY_X_RANGO
            Else
                Me.BindingSource_FACTORES_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FACTPROY_X_RANGO(vp_inConsulta)
            End If

            Me.dgvFACTORES.DataSource = BindingSource_FACTORES_1
            'Me.BindingNavigator_RANGOS_1.BindingSource = BindingSource_FACTORES_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FACTORES_1.Count

            Me.dgvFACTORES.Columns("DEPADESC").HeaderText = "Departamento"
            Me.dgvFACTORES.Columns("MUNIDESC").HeaderText = "Municipio"
            Me.dgvFACTORES.Columns("CLSEDESC").HeaderText = "Clase o Sector"
            Me.dgvFACTORES.Columns("PROYDESC").HeaderText = "Proyecto"
            Me.dgvFACTORES.Columns("TIVADESC").HeaderText = "Tipo Variable"
            Me.dgvFACTORES.Columns("VARIDESC").HeaderText = "Variable"
            Me.dgvFACTORES.Columns("FAPRFAIN").HeaderText = "Factor Inicial"
            Me.dgvFACTORES.Columns("FAPRFAFI").HeaderText = "Factor Final"
            Me.dgvFACTORES.Columns("FAPRFAAP").HeaderText = "Factor Aplicado"
            Me.dgvFACTORES.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvFACTORES.Columns("FAPRIDRE").Visible = False
            Me.dgvFACTORES.Columns("FAPRDEPA").Visible = False
            Me.dgvFACTORES.Columns("FAPRMUNI").Visible = False
            Me.dgvFACTORES.Columns("FAPRCLSE").Visible = False
            Me.dgvFACTORES.Columns("FAPRPROY").Visible = False
            Me.dgvFACTORES.Columns("FAPRTIVA").Visible = False
            Me.dgvFACTORES.Columns("FAPRVARI").Visible = False
            Me.dgvFACTORES.Columns("FAPRESTA").Visible = False
            Me.dgvFACTORES.Columns("FAPRDESC").Visible = False
            Me.dgvFACTORES.Columns("FAPRAPRA").Visible = False
            Me.dgvFACTORES.Columns("FAPRFAIN").Visible = False
            Me.dgvFACTORES.Columns("FAPRFAFI").Visible = False
            Me.dgvFACTORES.Columns("FAPRFAAP").Visible = False

            Me.dgvFACTORES.Columns("DEPADESC").Width = 90
            Me.dgvFACTORES.Columns("MUNIDESC").Width = 70
            Me.dgvFACTORES.Columns("CLSEDESC").Width = 70
            Me.dgvFACTORES.Columns("PROYDESC").Width = 250
            Me.dgvFACTORES.Columns("TIVADESC").Width = 90
            Me.dgvFACTORES.Columns("VARIDESC").Width = 90
            Me.dgvFACTORES.Columns("ESTADESC").Width = 80

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarRangos()

        Try
            Dim objdatos As New cla_RANGOS

            If boCONSULTA = False Then
                Me.BindingSource_RANGOS_1.DataSource = objdatos.fun_Buscar_CODIGO_RANGOS(Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRDEPA").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRMUNI").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRCLSE").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRPROY").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRTIVA").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRVARI").Value.ToString())
            Else
                Me.BindingSource_RANGOS_1.DataSource = objdatos.fun_Buscar_CODIGO_RANGOS(Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRDEPA").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRMUNI").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRCLSE").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRPROY").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRTIVA").Value.ToString(), _
                                                                                         Me.dgvFACTORES.SelectedRows.Item(0).Cells("FAPRVARI").Value.ToString())
            End If

            Me.dgvRANGOS.DataSource = BindingSource_RANGOS_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_RANGOS_1.Count

            Me.dgvRANGOS.Columns("RANGRAIN").HeaderText = "Rango Inicial"
            Me.dgvRANGOS.Columns("RANGRAFI").HeaderText = "Rango Final"
            Me.dgvRANGOS.Columns("RANGFAIN").HeaderText = "Factor Inicial"
            Me.dgvRANGOS.Columns("RANGFAFI").HeaderText = "Factor Final"
            Me.dgvRANGOS.Columns("RANGFAAP").HeaderText = "Factor Aplicado"

            Me.dgvRANGOS.Columns("RANGIDRE").Visible = False
            Me.dgvRANGOS.Columns("RANGDEPA").Visible = False
            Me.dgvRANGOS.Columns("RANGMUNI").Visible = False
            Me.dgvRANGOS.Columns("RANGCLSE").Visible = False
            Me.dgvRANGOS.Columns("RANGPROY").Visible = False
            Me.dgvRANGOS.Columns("RANGTIVA").Visible = False
            Me.dgvRANGOS.Columns("RANGVARI").Visible = False
            Me.dgvRANGOS.Columns("RANGESTA").Visible = False

            Me.dgvRANGOS.Columns("RANGRAIN").DefaultCellStyle.Format = "n"
            Me.dgvRANGOS.Columns("RANGRAFI").DefaultCellStyle.Format = "n"

            Me.dgvRANGOS.Columns("RANGRAIN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            Me.dgvRANGOS.Columns("RANGRAFI").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_RANGOS_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR.Enabled = boCONTMODI
            Me.cmdELIMINAR.Enabled = boCONTELIM
            Me.cmdCONSULTAR.Enabled = boCONTCONS
            Me.cmdRECONSULTAR.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            If Me.BindingSource_FACTORES_1.Count > 0 Then

                Me.lblRANGDEPA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_DEPARTAMENTO_Codigo(Me.dgvFACTORES.CurrentRow.Cells("FAPRDEPA").Value.ToString()), String)
                Me.lblRANGMUNI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_MUNICIPIO_Codigo(Me.dgvFACTORES.CurrentRow.Cells("FAPRDEPA").Value.ToString(), Me.dgvFACTORES.CurrentRow.Cells("FAPRMUNI").Value.ToString()), String)
                Me.lblRANGCLSE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_CLASSECT_Codigo(Me.dgvFACTORES.CurrentRow.Cells("FAPRCLSE").Value.ToString()), String)
                Me.lblRANGPROY.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_PROYECTO_Codigo(Me.dgvFACTORES.CurrentRow.Cells("FAPRDEPA").Value.ToString(), Me.dgvFACTORES.CurrentRow.Cells("FAPRMUNI").Value.ToString(), Me.dgvFACTORES.CurrentRow.Cells("FAPRCLSE").Value.ToString(), Me.dgvFACTORES.CurrentRow.Cells("FAPRPROY").Value.ToString()), String)
                Me.lblRANGTIVA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_TIPOVARI_Codigo(Me.dgvFACTORES.CurrentRow.Cells("FAPRTIVA").Value.ToString()), String)
                Me.lblRANGVARI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_VARIABLE_Codigo(Me.dgvFACTORES.CurrentRow.Cells("FAPRTIVA").Value.ToString(), Me.dgvFACTORES.CurrentRow.Cells("FAPRVARI").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblRANGDEPA.Text = ""
        Me.lblRANGMUNI.Text = ""
        Me.lblRANGCLSE.Text = ""
        Me.lblRANGPROY.Text = ""
        Me.lblRANGTIVA.Text = ""
        Me.lblRANGVARI.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            Dim frm_insertar_RANGOS As New frm_insertar_RANGOS(Integer.Parse(Me.dgvFACTORES.SelectedRows.Item(0).Cells(0).Value.ToString()))

            frm_insertar_RANGOS.ShowDialog()
            pro_ReconsultarFactores()
            pro_ReconsultarRangos()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RANGOS

                If objdatos.fun_Eliminar_MANT_RANGOS(Integer.Parse(Me.dgvRANGOS.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
                    boCONSULTA = False
                    pro_ReconsultarFactores()
                    pro_ReconsultarRangos()
                    pro_ListaDeValores()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click

        Try
            Dim frm_modificar_RANGOS As New frm_modificar_RANGOS(Integer.Parse(Me.dgvFACTORES.SelectedRows.Item(0).Cells(0).Value.ToString()), Integer.Parse(Me.dgvRANGOS.SelectedRows.Item(0).Cells(0).Value.ToString()))

            frm_modificar_RANGOS.ShowDialog()
            pro_ReconsultarFactores()
            pro_ReconsultarRangos()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            'vp_inConsulta = 0

            'frm_consultar_FACTPROY.ShowDialog()

            'If vp_inConsulta > 0 Then
            '    boCONSULTA = True
            'Else
            '    boCONSULTA = False
            'End If

            'pro_ReconsultarFactores()
            'pro_ReconsultarRangos()
            'pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click

        Try
            boCONSULTA = False
            pro_ReconsultarFactores()
            pro_ReconsultarRangos()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Mantenimiento_FACTORES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_ReconsultarFactores()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_FACTORES_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
        pro_ReconsultarRangos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvCLSECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFACTORES.KeyDown, dgvRANGOS.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR.Enabled = True Then
                cmdAGREGAR.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR.Enabled = True Then
                cmdMODIFICAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_RANGOS_1.Count

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
            If cmdELIMINAR.Enabled = True Then
                cmdELIMINAR.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_RANGOS_1.Count

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
            If cmdCONSULTAR.Enabled = True Then
                cmdCONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR.Enabled = True Then
                cmdRECONSULTAR.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "GotFocus"

    Private Sub dgvCLSECLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFACTORES.GotFocus, dgvRANGOS.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvFACTORES.AccessibleDescription
        Me.strBARRESTA.Items(0).Text = Me.dgvRANGOS.AccessibleDescription
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvFACTORES_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFACTORES.KeyUp, dgvRANGOS.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
            pro_ReconsultarRangos()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvFACTORES_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFACTORES.CellClick, dgvRANGOS.CellClick
        pro_ListaDeValores()
        pro_ReconsultarRangos()
    End Sub

#End Region

#End Region

End Class