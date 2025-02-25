Imports REGLAS_DEL_NEGOCIO

Public Class frm_PERMSUFO

    '===========================
    '*** PERMISO FORMULARIOS ***
    '===========================

#Region "VARIABLES"

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

    Public Shared Function instance() As frm_PERMSUFO
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_PERMSUFO
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
            Dim objdatos As New cla_PERMSUFO

            If boCONSULTA = False Then
                BindingSource_PERMSUFO_1.DataSource = objdatos.fun_Consultar_PERMSUFO
            Else
                BindingSource_PERMSUFO_1.DataSource = objdatos.fun_Consultar_PERMSUFO
            End If

            Me.dgvPERMSUFO.DataSource = BindingSource_PERMSUFO_1
            BindingNavigator_PERMSUFO_1.BindingSource = BindingSource_PERMSUFO_1

            Me.dgvPERMSUFO.Columns("Formulario").Width = 250
            Me.dgvPERMSUFO.Columns("Descripcion").Width = 250

            '==================================================
            '*** CONFUGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_PERMSUFO_1.Count
            dgvPERMSUFO.Columns(0).Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_PERMSUFO_1.Count

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
    Private Sub pro_ListaDeValores()

        Try
            If Me.dgvPERMSUFO.RowCount > 0 Then

                ' consulta el Nro. de documento por el usuario
                Dim objdatos11 As New cla_CONTRASENA
                Dim tbl11 As New DataTable

                tbl11 = objdatos11.fun_Buscar_USUARIO_CONTRASENA(Trim(Me.dgvPERMSUFO.SelectedRows.Item(0).Cells(1).Value.ToString()))

                ' declara la variable
                Dim stNroDocumento As String = ""

                ' carga la variable
                stNroDocumento = tbl11.Rows(0).Item("CONTNUDO").ToString

                ' consulta el nombre por Nro. de documento
                Dim objdatos22 As New cla_USUARIO
                Dim tbl As New DataTable

                Dim idNroDocumento As String = Trim(stNroDocumento)

                tbl = objdatos22.fun_Buscar_CODIGO_USUARIO(idNroDocumento)

                If tbl.Rows.Count > 0 Then

                    Dim nombre As String = Trim(tbl.Rows(0).Item("USUANOMB"))
                    Dim PrApellido As String = Trim(tbl.Rows(0).Item("USUAPRAP"))
                    Dim SeApellido As String = Trim(tbl.Rows(0).Item("USUASEAP"))

                    Me.txtPEETUSUA.Text = nombre & " " & PrApellido & " " & SeApellido
                Else
                    Me.txtPEETUSUA.Text = ""
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "lista de valores")
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        frm_insertar_PERMSUFO.ShowDialog()
        boCONSULTA = False
        pro_Reconsultar()

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvPERMSUFO.CurrentRow.Cells(2).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_PERMSUFO

                If Trim(dgvPERMSUFO.CurrentRow.Cells(1).Value.ToString()) = "ADMINISTRADOR" Then
                    MessageBox.Show("El registro no puede ser eliminado", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else

                    If objdatos.fun_Eliminar_PERMSUFO(Integer.Parse(dgvPERMSUFO.CurrentRow.Cells(0).Value.ToString())) Then
                        boCONSULTA = False
                        pro_Reconsultar()
                    Else
                        frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR.Click
        Try
            Dim frm_modificar_PERMSUFO As New frm_modificar_PERMSUFO(Integer.Parse(dgvPERMSUFO.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar_PERMSUFO.ShowDialog()
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click
        Try
            'vp_inConsulta = 0

            'frm_consultar_CLASSECT.ShowDialog()

            'If vp_inConsulta > 0 Then
            '    boCONSULTA = True
            'Else
            '    boCONSULTA = False
            'End If

            'pro_Reconsultar()

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
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREGIMUTA_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPERMSUFO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvREGIMUTA_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPERMSUFO.CellClick
        pro_ListaDeValores()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvCLSECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPERMSUFO.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_PERMSUFO_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_PERMSUFO_1.Count

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

    Private Sub dgvCLSECLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPERMSUFO.GotFocus
        strBARRESTA.Items(0).Text = dgvPERMSUFO.AccessibleDescription
    End Sub

#End Region

#End Region

End Class