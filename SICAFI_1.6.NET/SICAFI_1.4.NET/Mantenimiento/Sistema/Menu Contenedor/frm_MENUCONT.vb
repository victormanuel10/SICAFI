Imports REGLAS_DEL_NEGOCIO

Public Class frm_MENUCONT

    '=====================================
    '*** MANTENIMIENTO MENU CONTENEDOR ***
    '=====================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_MENUCONT
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_MENUCONT
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

      
            Dim objdatos As New cla_MENUCONT

            Me.BindingSource_MENUCONT_1.DataSource = objdatos.fun_Consultar_MANT_MENUCONT
            Me.dgvMECOMECO.DataSource = BindingSource_MENUCONT_1
            Me.BindingNavigator_MENUCONT_1.BindingSource = BindingSource_MENUCONT_1

            Me.strBARRESTA.Items(2).Text = "Registros : " & BindingSource_MENUCONT_1.Count
            Me.dgvMECOMECO.Columns(0).Visible = False
            Dim ContarRegistros As Integer = BindingSource_MENUCONT_1.Count

            Me.dgvMECOMECO.Columns(1).Width = 100
            Me.dgvMECOMECO.Columns(2).Width = 200
            Me.dgvMECOMECO.Columns(3).Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim objdatos1 As New cla_CONTRASENA
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

            Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
            Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
            Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

            If boCONTAGRE = True Then
                cmdAGREGAR.Enabled = True
            Else
                cmdAGREGAR.Enabled = False
            End If

            If ContarRegistros = 0 Then
                cmdMODIFICAR.Enabled = False
            Else
                If boCONTMODI = True Then
                    cmdMODIFICAR.Enabled = True
                Else
                    cmdMODIFICAR.Enabled = False
                End If
            End If

            If ContarRegistros = 0 Then
                cmdELIMINAR.Enabled = False
            Else
                If boCONTELIM = True Then
                    cmdELIMINAR.Enabled = True
                Else
                    cmdELIMINAR.Enabled = False
                End If
            End If

            If ContarRegistros = 0 Then
                cmdCONSULTAR.Enabled = False
                cmdRECONSULTAR.Enabled = False
            Else
                cmdCONSULTAR.Enabled = True
                cmdRECONSULTAR.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        Try
            frm_insertar_MENUCONT.ShowDialog()
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
        
    End Sub

    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvMECOMECO.CurrentRow.Cells(1).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Dim objdatos As New cla_MENUCONT

                If objdatos.fun_Eliminar_MANT_MENUCONT(Integer.Parse(dgvMECOMECO.CurrentRow.Cells(0).Value.ToString())) Then
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
            Dim frm_modificar_MENUCONT As New frm_modificar_MENUCONT(Integer.Parse(dgvMECOMECO.CurrentRow.Cells(0).Value.ToString()))
            frm_modificar_MENUCONT.ShowDialog()
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click
        pro_Reconsultar()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_Mantenimiento_MENUCONT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pro_Reconsultar()

    End Sub

    Private Sub dgvMECOMECO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvMECOMECO.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_MENUCONT_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_MENUCONT_1.Count

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
    Private Sub dgvMECOMECO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMECOMECO.GotFocus
        strBARRESTA.Items(0).Text = dgvMECOMECO.AccessibleDescription
    End Sub

#End Region


  
End Class