Imports REGLAS_DEL_NEGOCIO

Public Class frm_PERMUSUA

    '=================================================================
    '*** PERMISO DE USUARIO PARA LAS ETIQUETAS DEL MENU CONTENEDOR ***
    '=================================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_PERMUSUA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_PERMUSUA
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

    '*** SW VERIFICAR CAMPOS LLENOS QUE VAN A LA DB ***
    Dim SWVerificarCamposLlenos As Boolean = False

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_ReconsultarUsuarios()
        Try

            Dim objdatos As New cla_CONTRASENA

            BindingSource_MENU_1.DataSource = objdatos.fun_Consultar_CONTRASENA
            Me.dgvUSUARIO.DataSource = BindingSource_MENU_1
            BindingNavigator_MENU_1.BindingSource = BindingSource_MENU_1

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_MENU_1.Count

            'Oculta la columna del DataGridView
            Me.dgvUSUARIO.Columns(0).Visible = False
            Me.dgvUSUARIO.Columns(3).Visible = False
            Me.dgvUSUARIO.Columns(4).Visible = False
            Me.dgvUSUARIO.Columns(5).Visible = False
            Me.dgvUSUARIO.Columns(6).Visible = False
            Me.dgvUSUARIO.Columns(7).Visible = False
            Me.dgvUSUARIO.Columns(8).Visible = False

            Dim ContarRegistros As Integer = BindingSource_MENU_1.Count

            '================================================
            'Se prende o apaga si existen registro en usuario
            '================================================

            Dim ContarRegistrosUsuario As Integer = BindingSource_MENU_1.Count


            If ContarRegistrosUsuario = 0 Then
                Me.chkAGREGAR.Enabled = False
                Me.chkMODIFICAR.Enabled = False
                Me.chkELIMINAR.Enabled = False
            Else
                Me.chkAGREGAR.Enabled = True
                Me.chkMODIFICAR.Enabled = True
                Me.chkELIMINAR.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Boton guardar")
        End Try

    End Sub
    Private Sub pro_ReconsultarMenuContenedor()
        Try

      
            Dim objdatos As New cla_MENUCONT

            BindingSource_MENU_2.DataSource = objdatos.fun_Consultar_MANT_MENUCONT
            dgvMENUCONT.DataSource = BindingSource_MENU_2
            BindingNavigator_MENU_1.BindingSource = BindingSource_MENU_2

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_MENU_2.Count

            'Oculta la columna del DataGridView
            Me.dgvMENUCONT.Columns(0).Visible = False
            Me.dgvMENUCONT.Columns(1).Visible = False
            Me.dgvMENUCONT.Columns(3).Visible = False

            Dim ContarRegistros As Integer = BindingSource_MENU_2.Count

            If ContarRegistros = 0 Then
                Me.cmdASIGNAR_PERMISO.Enabled = False
            Else
                Me.cmdASIGNAR_PERMISO.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarPermisoDeUsuarioPorUsuario()
        Try


            Dim objdatos As New cla_PERMUSUA

            BindingSource_MENU_3.DataSource = objdatos.fun_Buscar_USUARIO_PERMUSUA(Me.dgvUSUARIO.CurrentRow.Cells(2).Value.ToString())
            Me.dgvPERMUSUA.DataSource = BindingSource_MENU_3

            'dgvPERMUSUA.Columns(1).HeaderText = "Usuario"
            'dgvPERMUSUA.Columns(2).HeaderText = "Etiqueta menu contenedor"
            Me.dgvPERMUSUA.Columns(10).HeaderText = "Etiqueta menu contenedor"

            Me.dgvPERMUSUA.Columns(0).Visible = False
            Me.dgvPERMUSUA.Columns(1).Visible = False
            Me.dgvPERMUSUA.Columns(2).Visible = False
            Me.dgvPERMUSUA.Columns(3).Visible = False
            Me.dgvPERMUSUA.Columns(4).Visible = False
            Me.dgvPERMUSUA.Columns(5).Visible = False
            Me.dgvPERMUSUA.Columns(6).Visible = False
            Me.dgvPERMUSUA.Columns(7).Visible = False
            Me.dgvPERMUSUA.Columns(8).Visible = False
            Me.dgvPERMUSUA.Columns(9).Visible = False
            'dgvPERMUSUA.Columns(10).Visible = False
            'dgvPERMUSUA.Columns(3).HeaderText = "Permiso_1"
            'dgvPERMUSUA.Columns(4).HeaderText = "Permiso_2"
            'dgvPERMUSUA.Columns(5).HeaderText = "Permiso_3"

            Dim ContarRegistrosUsuario As Integer = BindingSource_MENU_3.Count

            If ContarRegistrosUsuario = 0 Then
                Me.cmdRETIRAR_PERMISO.Enabled = False
            Else
                Me.cmdRETIRAR_PERMISO.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarPermisoDeUsuario()
        Try

            Dim objdatos As New cla_PERMUSUA

            BindingSource_MENU_3.DataSource = objdatos.fun_Buscar_USUARIO_PERMUSUA(dgvUSUARIO.CurrentRow.Cells(2).Value.ToString())
            Me.dgvPERMUSUA.DataSource = BindingSource_MENU_3
            BindingNavigator_MENU_1.BindingSource = BindingSource_MENU_3

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_MENU_3.Count

            'Oculta la columna del DataGridView
            Me.dgvPERMUSUA.Columns(0).Visible = False
            Me.dgvPERMUSUA.Columns(1).HeaderText = "Usuario"
            Me.dgvPERMUSUA.Columns(2).HeaderText = "Etiqueta menu contenedor"
            Me.dgvPERMUSUA.Columns(3).HeaderText = "Permiso_1"
            Me.dgvPERMUSUA.Columns(4).HeaderText = "Permiso_2"
            Me.dgvPERMUSUA.Columns(5).HeaderText = "Permiso_3"

            Dim ContarRegistrosUsuario As Integer = BindingSource_MENU_3.Count

            If ContarRegistrosUsuario = 0 Then
                cmdRETIRAR_PERMISO.Enabled = False
            Else
                cmdRETIRAR_PERMISO.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresUsuario()

        Dim ContarRegistros As Integer = BindingSource_MENU_1.Count

        If ContarRegistros > 0 Then

            '=============================================
            'Limpia los campos si no encuentra registro ID
            '=============================================
            Try
                If (dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()) = "" Then
                    pro_LimpiarCampos()
                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "1")
            End Try

            '======================================================
            'Pregunta si la columna esta vacia para que no se 
            'desborde por la consulta de tipo numerico
            '======================================================
            Try
                If (Me.dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()) <> "" Then

                    Dim objdatos As New cla_USUARIO
                    Dim tbl As New DataTable

                    Dim idNroDocumento As String = (Me.dgvUSUARIO.CurrentRow.Cells(1).Value.ToString())
                    tbl = objdatos.fun_Buscar_CODIGO_USUARIO(idNroDocumento)

                    Dim nombre As String
                    Dim PrApellido As String
                    Dim SeApellido As String

                    Dim sw, j As Integer

                    While j < tbl.Rows.Count And sw = 0
                        If idNroDocumento = tbl.Rows(j).Item("USUANUDO") Then

                            nombre = Trim(tbl.Rows(j).Item("USUANOMB"))
                            PrApellido = Trim(tbl.Rows(j).Item("USUAPRAP"))
                            SeApellido = Trim(tbl.Rows(j).Item("USUASEAP"))

                            lblUSUANOMB.Text = nombre & " " & PrApellido & " " & SeApellido

                            sw = 1
                        Else
                            j = j + 1
                        End If
                    End While

                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "lista de valores")
            End Try

            '===================================================================
            'Manejo de las cajas de verificación de acuerdo a lo existente en bd
            '===================================================================

            Try
                If (dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()) <> "" Then

                    Dim boAGREGAR As Boolean = (Me.dgvUSUARIO.CurrentRow.Cells(4).Value.ToString())
                    Dim boMODIFICAR As Boolean = (Me.dgvUSUARIO.CurrentRow.Cells(5).Value.ToString())
                    Dim boELIMINAR As Boolean = (Me.dgvUSUARIO.CurrentRow.Cells(6).Value.ToString())
                    Dim boConsultarFichaPredial As Boolean = (Me.dgvUSUARIO.CurrentRow.Cells(7).Value.ToString())
                    Dim boConsultarSujetoImpuesto As Boolean = (Me.dgvUSUARIO.CurrentRow.Cells(8).Value.ToString())

                    If boAGREGAR = True Then
                        Me.chkAGREGAR.Checked = True
                    Else
                        Me.chkAGREGAR.Checked = False
                    End If

                    If boMODIFICAR = True Then
                        Me.chkMODIFICAR.Checked = True
                    Else
                        Me.chkMODIFICAR.Checked = False
                    End If

                    If boELIMINAR = True Then
                        Me.chkELIMINAR.Checked = True
                    Else
                        Me.chkELIMINAR.Checked = False
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try

        End If
    End Sub
    Private Sub pro_LimpiarCampos()
        Me.lblUSUANOMB.Text = ""
    End Sub
    Private Sub pro_GuardarRegistro()

        Try
            Dim objdatos As New cla_CONTRASENA
            Dim tbl As New DataTable

            Dim id As Integer = Integer.Parse(Me.dgvUSUARIO.CurrentRow.Cells(0).Value.ToString())

            tbl = objdatos.fun_Buscar_ID_CONTRASENA(id)

            Dim stCONTNUDO As String = Trim(tbl.Rows(0).Item(1))
            Dim stCONTUSUA As String = Trim(tbl.Rows(0).Item(2))
            Dim stCONTCONT As String = Trim(tbl.Rows(0).Item(3))
            Dim stCONTESTA As String = Trim(tbl.Rows(0).Item(4))

            Dim boCONTAGRE As Boolean = chkAGREGAR.Checked
            Dim boCONTMODI As Boolean = chkMODIFICAR.Checked
            Dim boCONTELIM As Boolean = chkELIMINAR.Checked

            If (objdatos.fun_Actualizar_CONTRASENA(id, stCONTNUDO, stCONTUSUA, stCONTCONT, stCONTESTA, boCONTAGRE, boCONTMODI, boCONTELIM, False, False)) Then
                mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
            Else
                mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
            End If

            pro_ReconsultarUsuarios()
            pro_ListaDeValoresUsuario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PERMISO DE USUARIO"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdASIGNAR_PERMISO.Click
        Try

            '*** BUSCAR USUARIO ***
            Dim objdatos3 As New cla_CONTRASENA
            Dim tbl3 As New DataTable

            tbl3 = objdatos3.fun_Buscar_ID_CONTRASENA(Integer.Parse(dgvUSUARIO.CurrentRow.Cells(0).Value.ToString()))
            Dim idUsuario As String = tbl3.Rows(0).Item(2)

            '*** BUSCAR EL NOMBRE DE LA ETIQUETA DEL MENU CONTENEDOR ***
            Dim objdatos4 As New cla_MENUCONT
            Dim tbl4 As New DataTable

            tbl4 = objdatos4.fun_Buscar_ID_MANT_MENUCONT(Integer.Parse(dgvMENUCONT.CurrentRow.Cells(0).Value.ToString()))
            Dim idMenuCont As String = Trim(tbl4.Rows(0).Item(1))

            '*** BUSCAR EL USUARIO Y LA ETIQUETA PARA QUE NO SE REPITA EL PERMISO***
            Dim objdatos1 As New cla_PERMUSUA
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_USUARIO_Y_ETIQUETA_PERMUSUA(idUsuario, idMenuCont)

            If tbl.Rows.Count > 0 Then
                MessageBox.Show("Permiso ya existe para el usuario " & idUsuario, "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim objdatos As New cla_PERMUSUA

                If (objdatos.fun_Insertar_PERMUSUA(idUsuario, idMenuCont, True, True, True)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    pro_ReconsultarPermisoDeUsuarioPorUsuario()
                    pro_ReconsultarPermisoDeUsuario()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRETIRAR_PERMISO.Click
        Try
            Dim usuario As String = dgvPERMUSUA.CurrentRow.Cells(1).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Usuario : " & usuario, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_PERMUSUA

                If objdatos.fun_Eliminar_PERMUSUA(Integer.Parse(dgvPERMUSUA.CurrentRow.Cells(0).Value.ToString())) Then
                    pro_ReconsultarPermisoDeUsuarioPorUsuario()
                    pro_ReconsultarPermisoDeUsuario()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If
                
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "eliminar")
        End Try
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_Mantenimiento_USUARIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_ReconsultarUsuarios()
        pro_ReconsultarMenuContenedor()

        '========================================================================
        'Se prende o apaga si existen registro en usuario o en el menu contenedor
        '========================================================================

        Dim ContarRegistrosUsuario As Integer = BindingSource_MENU_1.Count
        Dim ContarRegistrosMenuCont As Integer = BindingSource_MENU_2.Count

        Try
            If ContarRegistrosUsuario = 0 Or ContarRegistrosMenuCont = 0 Then
                cmdASIGNAR_PERMISO.Enabled = False
            Else
                cmdASIGNAR_PERMISO.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Asignar permiso")
        End Try

    End Sub
    Private Sub frm_PERMUSUA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresUsuario()
        pro_ReconsultarPermisoDeUsuarioPorUsuario()
    End Sub

    '==========================================
    'Configuración del datagridview del usuario
    '==========================================

    Private Sub dgvUSUARIO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUSUARIO.CellClick
        pro_ListaDeValoresUsuario()
        pro_ReconsultarPermisoDeUsuarioPorUsuario()
    End Sub
    Private Sub dgvUSUARIO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUSUARIO.GotFocus
        pro_ReconsultarUsuarios()
        strBARRESTA.Items(0).Text = dgvUSUARIO.AccessibleDescription
    End Sub
    Private Sub dgvUSUARIO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvUSUARIO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresUsuario()
            pro_ReconsultarPermisoDeUsuarioPorUsuario()
        End If
    End Sub
    Private Sub dgvUSUARIO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvUSUARIO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    '==================================================
    'Configuración del datagridview del menu contenedor
    '==================================================

    Private Sub dgvMENUCONT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMENUCONT.GotFocus
        pro_ReconsultarMenuContenedor()
        strBARRESTA.Items(0).Text = dgvMENUCONT.AccessibleDescription
    End Sub
    Private Sub dgvMENUCONT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMENUCONT.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    '=====================================================
    'Configuración del datagridview del permiso de usuario
    '=====================================================

    Private Sub dgvPERMUSUA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPERMUSUA.GotFocus
        pro_ReconsultarPermisoDeUsuario()
        strBARRESTA.Items(0).Text = dgvPERMUSUA.AccessibleDescription
    End Sub
    Private Sub dgvPERMUSUA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPERMUSUA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

    '=======================
    '*** EVENTO GotFocus ***
    '=======================

    Private Sub cmdASIGNAR_PERMISO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdASIGNAR_PERMISO.GotFocus
        strBARRESTA.Items(0).Text = cmdASIGNAR_PERMISO.AccessibleDescription
    End Sub
    Private Sub cmdELIMINAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRETIRAR_PERMISO.GotFocus
        strBARRESTA.Items(0).Text = cmdRETIRAR_PERMISO.AccessibleDescription
    End Sub
    Private Sub chkAGREGAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAGREGAR.GotFocus
        strBARRESTA.Items(0).Text = chkAGREGAR.AccessibleDescription
    End Sub
    Private Sub chkMODIFICAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMODIFICAR.GotFocus
        strBARRESTA.Items(0).Text = chkMODIFICAR.AccessibleDescription
    End Sub
    Private Sub chkELIMINAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkELIMINAR.GotFocus
        strBARRESTA.Items(0).Text = chkELIMINAR.AccessibleDescription
    End Sub

    Private Sub chkAGREGAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAGREGAR.Click, chkELIMINAR.Click, chkMODIFICAR.Click
        If Me.chkAGREGAR.Checked = True Then
            pro_GuardarRegistro()

        ElseIf chkAGREGAR.Checked = False Then
            pro_GuardarRegistro()

        End If
    End Sub

#End Region

  
End Class