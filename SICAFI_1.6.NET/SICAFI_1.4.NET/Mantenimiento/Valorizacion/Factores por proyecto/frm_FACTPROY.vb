Imports REGLAS_DEL_NEGOCIO

Public Class frm_FACTPROY

    '====================================
    '*** MANTENIMIENTO CLASE DE SUELO ***
    '====================================

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

    Public Shared Function instance() As frm_FACTPROY
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_FACTPROY
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

    Private Sub pro_Reconsultar()

        Try
            Dim objdatos As New cla_FACTPROY

            If boCONSULTA = False Then
                Me.BindingSource_FACTPROY_1.DataSource = objdatos.fun_Consultar_MANT_FACTPROY
            Else
                Me.BindingSource_FACTPROY_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FACTPROY(vp_inConsulta)
            End If

            Me.dgvFACTPROY_1.DataSource = BindingSource_FACTPROY_1
            Me.dgvFACTPROY_2.DataSource = BindingSource_FACTPROY_1
            Me.BindingNavigator_FACTPROY_1.BindingSource = BindingSource_FACTPROY_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FACTPROY_1.Count

            Me.dgvFACTPROY_1.Columns("DEPADESC").HeaderText = "Departamento"
            Me.dgvFACTPROY_1.Columns("MUNIDESC").HeaderText = "Municipio"
            Me.dgvFACTPROY_1.Columns("CLSEDESC").HeaderText = "Clase o Sector"
            Me.dgvFACTPROY_1.Columns("PROYDESC").HeaderText = "Proyecto"
            Me.dgvFACTPROY_2.Columns("TIVADESC").HeaderText = "Tipo Variable"
            Me.dgvFACTPROY_2.Columns("VARIDESC").HeaderText = "Variable"
            Me.dgvFACTPROY_2.Columns("FAPRDESC").HeaderText = "Descripción"
            Me.dgvFACTPROY_2.Columns("FAPRFAIN").HeaderText = "Factor Inicial"
            Me.dgvFACTPROY_2.Columns("FAPRFAFI").HeaderText = "Factor Final"
            Me.dgvFACTPROY_2.Columns("FAPRFAAP").HeaderText = "Factor Aplicado"
            Me.dgvFACTPROY_1.Columns("ESTADESC").HeaderText = "Estado"
            Me.dgvFACTPROY_2.Columns("FAPRAPRA").HeaderText = "Aplicar Rango"

            Me.dgvFACTPROY_1.Columns("FAPRIDRE").Visible = False
            Me.dgvFACTPROY_1.Columns("TIVADESC").Visible = False
            Me.dgvFACTPROY_1.Columns("VARIDESC").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRDESC").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRFAIN").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRFAFI").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRFAAP").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRESTA").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRAPRA").Visible = False

            Me.dgvFACTPROY_1.Columns("FAPRDEPA").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRMUNI").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRCLSE").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRPROY").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRTIVA").Visible = False
            Me.dgvFACTPROY_1.Columns("FAPRVARI").Visible = False
            Me.dgvFACTPROY_2.Columns("ESTADESC").Visible = False
            Me.dgvFACTPROY_2.Columns("FAPRESTA").Visible = False

            Me.dgvFACTPROY_2.Columns("FAPRIDRE").Visible = False
            Me.dgvFACTPROY_2.Columns("DEPADESC").Visible = False
            Me.dgvFACTPROY_2.Columns("MUNIDESC").Visible = False
            Me.dgvFACTPROY_2.Columns("CLSEDESC").Visible = False
            Me.dgvFACTPROY_2.Columns("PROYDESC").Visible = False
            Me.dgvFACTPROY_2.Columns("FAPRDEPA").Visible = False
            Me.dgvFACTPROY_2.Columns("FAPRMUNI").Visible = False
            Me.dgvFACTPROY_2.Columns("FAPRCLSE").Visible = False
            Me.dgvFACTPROY_2.Columns("FAPRPROY").Visible = False
            Me.dgvFACTPROY_2.Columns("FAPRTIVA").Visible = False
            Me.dgvFACTPROY_2.Columns("FAPRVARI").Visible = False

            Me.dgvFACTPROY_1.Columns("DEPADESC").Width = 100
            Me.dgvFACTPROY_1.Columns("MUNIDESC").Width = 100
            Me.dgvFACTPROY_1.Columns("CLSEDESC").Width = 100
            Me.dgvFACTPROY_1.Columns("ESTADESC").Width = 100
            Me.dgvFACTPROY_1.Columns("PROYDESC").Width = 350
            Me.dgvFACTPROY_2.Columns("FAPRDESC").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_FACTPROY_1.Count

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
            If Me.BindingSource_FACTPROY_1.Count > 0 Then

                Me.lblFACTDEPA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_DEPARTAMENTO_Codigo(Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRDEPA").Value.ToString()), String)
                Me.lblFACTMUNI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_MUNICIPIO_Codigo(Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRDEPA").Value.ToString(), Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRMUNI").Value.ToString()), String)
                Me.lblFACTCLSE.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_CLASSECT_Codigo(Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRCLSE").Value.ToString()), String)
                Me.lblFACTPROY.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_PROYECTO_Codigo(Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRDEPA").Value.ToString(), Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRMUNI").Value.ToString(), Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRCLSE").Value.ToString(), Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRPROY").Value.ToString()), String)
                Me.lblFACTTIVA.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_TIPOVARI_Codigo(Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRTIVA").Value.ToString()), String)
                Me.lblFACTVARI.Text = CType(fun_Buscar_Lista_Valores_Formulario_Principal_VARIABLE_Codigo(Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRTIVA").Value.ToString(), Me.dgvFACTPROY_1.CurrentRow.Cells("FAPRVARI").Value.ToString()), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblFACTDEPA.Text = ""
        Me.lblFACTMUNI.Text = ""
        Me.lblFACTCLSE.Text = ""
        Me.lblFACTPROY.Text = ""
        Me.lblFACTTIVA.Text = ""
        Me.lblFACTVARI.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click

        Try
            frm_insertar_FACTPROY.ShowDialog()
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click

        Try

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_FACTPROY

                If objdatos.fun_Eliminar_MANT_FACTPROY(Integer.Parse(Me.dgvFACTPROY_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then
                    boCONSULTA = False
                    pro_Reconsultar()
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
            Dim frm_modificar_FACTORES As New frm_modificar_FACTPROY(Integer.Parse(Me.dgvFACTPROY_1.SelectedRows.Item(0).Cells(0).Value.ToString()))

            frm_modificar_FACTORES.ShowDialog()
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            vp_inConsulta = 0

            frm_consultar_FACTPROY.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click

        Try
            boCONSULTA = False
            pro_Reconsultar()
            pro_ListaDeValores()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pro_ListaDeValores()
    End Sub
    Private Sub BindingNavigatorMoveLastItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pro_ListaDeValores()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Mantenimiento_FACTORES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_FACTORES_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvCLSECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFACTPROY_1.KeyDown, dgvFACTPROY_2.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_FACTPROY_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_FACTPROY_1.Count

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

    Private Sub dgvCLSECLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFACTPROY_1.GotFocus, dgvFACTPROY_2.GotFocus
        Me.strBARRESTA.Items(0).Text = Me.dgvFACTPROY_1.AccessibleDescription
        Me.strBARRESTA.Items(0).Text = Me.dgvFACTPROY_2.AccessibleDescription
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvFACTORES_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFACTPROY_1.KeyUp, dgvFACTPROY_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvFACTORES_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFACTPROY_1.CellClick, dgvFACTPROY_2.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#End Region

End Class