Imports REGLAS_DEL_NEGOCIO

Public Class frm_CODICALI

    '=========================================
    '*** FORMULARIO CÓDIGO DE CALIFICACIÓN ***
    '=========================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_CODICALI
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_CODICALI
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
            Dim objdatos As New cla_CODICALI

            If boCONSULTA = False Then
                BindingSource_CODICALI_1.DataSource = objdatos.fun_Consultar_MANT_CODICALI
            Else

            End If

            dgvCODICALI.DataSource = BindingSource_CODICALI_1
            BindingNavigator_CODICALI_1.BindingSource = BindingSource_CODICALI_1

            '==================================================
            '*** CONFUGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_CODICALI_1.Count
            dgvCODICALI.Columns(0).Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = BindingSource_CODICALI_1.Count

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
    Private Sub pro_ReconsultarCodigosCalificacion()

        Try
            Dim ContarRegistrosCalificacion As Integer = BindingSource_CODICALI_1.Count

            If ContarRegistrosCalificacion > 0 Then
                Dim objdatos As New cla_CODICACO

                BindingSource_CODICACO_1.DataSource = objdatos.fun_Buscar_CODIGO_MANT_CODICACO(Integer.Parse(dgvCODICALI.CurrentRow.Cells(1).Value.ToString()))
                dgvCODICACO.DataSource = BindingSource_CODICACO_1

                dgvCODICACO.Columns(0).Visible = False
                dgvCODICACO.Columns(1).HeaderText = "Código"
                dgvCODICACO.Columns(2).HeaderText = "Tipo"
                dgvCODICACO.Columns(3).HeaderText = "Puntos"
                dgvCODICACO.Columns(4).HeaderText = "Estado"

            End If

            Dim ContarRegistrosCalificacionConstruccion As Integer = BindingSource_CODICACO_1.Count

            If ContarRegistrosCalificacion = 0 Then
                cmdAGREGAR_CODICACO.Enabled = False
                cmdMODIFICAR_CODICACO.Enabled = False
                cmdELIMINAR_CODICACO.Enabled = False
            Else
                cmdAGREGAR_CODICACO.Enabled = True

                If ContarRegistrosCalificacionConstruccion = 0 Then
                    cmdMODIFICAR_CODICACO.Enabled = False
                    cmdELIMINAR_CODICACO.Enabled = False
                Else
                    cmdMODIFICAR_CODICACO.Enabled = True
                    cmdELIMINAR_CODICACO.Enabled = True
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU CODIGO DE CALIFICACIÓN"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        frm_Insertar_CODICALI.ShowDialog()
        boCONSULTA = False
        pro_Reconsultar()

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvCODICALI.CurrentRow.Cells(1).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_CODICALI

                If objdatos.fun_Eliminar_MANT_CODICALI(Integer.Parse(dgvCODICALI.CurrentRow.Cells(0).Value.ToString())) Then
                    boCONSULTA = False
                    pro_Reconsultar()
                    pro_ReconsultarCodigosCalificacion()
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
            Dim frm_modificar_CODICALI As New frm_modificar_CODICALI(Integer.Parse(dgvCODICALI.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar_CODICALI.ShowDialog()
            pro_Reconsultar()
            pro_ReconsultarCodigosCalificacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click
        pro_Reconsultar()
    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR.Click
        boCONSULTA = False
        pro_Reconsultar()
        pro_ReconsultarCodigosCalificacion()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "MENU CODIGO CALIFICACIÓN DE CONSTRUCCIÓN"

    Private Sub cmdAGREGAR_CODICACO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_CODICACO.Click
        Try
            frm_insertar_CODICACO.ShowDialog()
            pro_ReconsultarCodigosCalificacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_PUNTCALI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_CODICACO.Click
        Try
            Dim frm_modificar_CODICACO As New frm_modificar_CODICACO(Integer.Parse(dgvCODICACO.CurrentRow.Cells(0).Value.ToString()))

            frm_modificar_CODICACO.ShowDialog()
            pro_ReconsultarCodigosCalificacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdELIMINAR_PUNTCALI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_CODICACO.Click
        Try
            Dim Codigo As String = dgvCODICACO.CurrentRow.Cells(1).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_CODICACO

                If objdatos.fun_Eliminar_MANT_CODICACO(Integer.Parse(dgvCODICACO.CurrentRow.Cells(0).Value.ToString())) Then
                    pro_ReconsultarCodigosCalificacion()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Mantenimiento_CODICALI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_Reconsultar()
        'pro_ReconsultarCodigosCalificacion()

        '========================================================================
        'Se prende o apaga si existen registro en usuario o en el menu contenedor
        '========================================================================

        Dim ContarRegistrosCalificacion As Integer = BindingSource_CODICALI_1.Count
        Dim ContarRegistroscalificacionConstruccion As Integer = BindingSource_CODICACO_1.Count

        Try
            If ContarRegistrosCalificacion = 0 Then
                cmdAGREGAR_CODICACO.Enabled = False
                cmdMODIFICAR_CODICACO.Enabled = False
                cmdELIMINAR_CODICACO.Enabled = False
            End If

            If ContarRegistroscalificacionConstruccion = 0 Then
                cmdAGREGAR_CODICACO.Enabled = False
                cmdMODIFICAR_CODICACO.Enabled = False
                cmdELIMINAR_CODICACO.Enabled = False
            Else
                cmdAGREGAR_CODICACO.Enabled = True
                cmdMODIFICAR_CODICACO.Enabled = True
                cmdELIMINAR_CODICACO.Enabled = True
            End If



        Catch ex As Exception
            MessageBox.Show(Err.Description & "Menu calificación de construcción")
        End Try


    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_CODICALI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ReconsultarCodigosCalificacion()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvCODICALI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCODICALI.KeyDown
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
                Dim ContarRegistros As Integer = BindingSource_CODICALI_1.Count

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
                Dim ContarRegistros As Integer = BindingSource_CODICALI_1.Count

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

#Region "KeyUp"

    Private Sub dgvCODICALI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCODICALI.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ReconsultarCodigosCalificacion()
        End If
    End Sub

#End Region
    
#Region "CellClick"

    Private Sub dgvCODICALI_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCODICALI.CellClick
        pro_ReconsultarCodigosCalificacion()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub dgvCLSECLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCODICALI.GotFocus
        strBARRESTA.Items(0).Text = dgvCODICALI.AccessibleDescription
    End Sub

#End Region
   
#End Region

End Class