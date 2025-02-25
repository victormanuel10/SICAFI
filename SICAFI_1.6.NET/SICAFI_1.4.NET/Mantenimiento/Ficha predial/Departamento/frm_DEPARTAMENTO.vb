Imports REGLAS_DEL_NEGOCIO

Public Class frm_DEPARTAMENTO

    '==================================
    '*** MANTENIMIENTO DEPARTAMENTO ***
    '==================================

#Region "VARIABLES "

    Dim boCONSULTA As Boolean = False

#End Region

#Region "CONSULTA PARAMETRIZADA"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_DEPARTAMENTO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_DEPARTAMENTO
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
            Dim objdatos As New cla_DEPARTAMENTO

            If boCONSULTA = False Then
                Me.BindingSource_DEPARTAMENTO_1.DataSource = objdatos.fun_Consultar_MANT_DEPARTAMENTO
            Else
                Me.BindingSource_DEPARTAMENTO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DEPARTAMENTO(vp_inConsulta)
            End If

            Me.dgvDEPARTAMENTO.DataSource = BindingSource_DEPARTAMENTO_1
            Me.BindingNavigator_DEPARTAMENTO_1.BindingSource = BindingSource_DEPARTAMENTO_1

            '==================================================
            '*** CONFUGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_DEPARTAMENTO_1.Count
            Me.dgvDEPARTAMENTO.Columns(0).Visible = False

            Me.dgvDEPARTAMENTO.Columns(1).Width = 161
            Me.dgvDEPARTAMENTO.Columns(2).Width = 300
            Me.dgvDEPARTAMENTO.Columns(3).Width = 107

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_DEPARTAMENTO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            cmdAGREGAR.Enabled = boCONTAGRE
            cmdMODIFICAR.Enabled = boCONTMODI
            cmdELIMINAR.Enabled = boCONTELIM
            cmdCONSULTAR.Enabled = boCONTCONS
            cmdRECONSULTAR.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        Try
            frm_insertar_DEPARTAMENTO.ShowDialog()
            boCONSULTA = False
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
        
    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvDEPARTAMENTO.CurrentRow.Cells(1).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_DEPARTAMENTO

                If objdatos.fun_Eliminar_MANT_DEPARTAMENTO(Integer.Parse(dgvDEPARTAMENTO.CurrentRow.Cells(0).Value.ToString())) Then
                    boCONSULTA = False
                    pro_Reconsultar()
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
            Dim frm_modificar_DEPARTAMENTO As New frm_modificar_DEPARTAMENTO(Integer.Parse(dgvDEPARTAMENTO.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar_DEPARTAMENTO.ShowDialog()
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click
        Try
            vp_inConsulta = 0

            frm_consultar_DEPARTAMENTO.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click
        boCONSULTA = False
        pro_Reconsultar()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Mantenimiento_CLASSECT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvDEPARTAMENTO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDEPARTAMENTO.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_DEPARTAMENTO_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_DEPARTAMENTO_1.Count

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

    Private Sub dgvDEPARTAMENTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDEPARTAMENTO.GotFocus
        strBARRESTA.Items(0).Text = dgvDEPARTAMENTO.AccessibleDescription
    End Sub

#End Region
  
#End Region

End Class