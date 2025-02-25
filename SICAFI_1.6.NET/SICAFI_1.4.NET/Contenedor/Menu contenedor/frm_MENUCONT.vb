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

        Dim objdatos As New cla_MENUCONT

        BindingSource_MENUCONT_1.DataSource = objdatos.fun_Consultar_MANT_MENUCONT
        dgvMECOMECO.DataSource = BindingSource_MENUCONT_1
        BindingNavigator_MENUCONT_1.BindingSource = BindingSource_MENUCONT_1

        strBARRESTA.Items(2).Text = "Registros: " & BindingSource_MENUCONT_1.Count

        'Oculta la columna del DataGridView
        dgvMECOMECO.Columns(0).Visible = False

        'Manejo del boton modificar al tener o no registros en el BindingSource
        Dim ContarRegistros As Integer = BindingSource_MENUCONT_1.Count

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



    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR.Click
        frm_insertar_MENUCONT.ShowDialog()
        pro_Reconsultar()

    End Sub

    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR.Click
        Try
            Dim Codigo As String = dgvMECOMECO.CurrentRow.Cells(1).Value.ToString()

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mansaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim contrasena As String

                contrasena = InputBox("Favor ingrese la contraseña para autorizar la eliminación del registro", "Mensaje")
                contrasena = contrasena.ToUpper

                If Trim(contrasena) <> "" Then
                    If contrasena = ClaveEliminar Then
                        Dim objdatos As New cla_MENUCONT

                        objdatos.fun_Eliminar_MANT_MENUCONT(Integer.Parse(dgvMECOMECO.CurrentRow.Cells(0).Value.ToString()))
                        pro_Reconsultar()
                    Else
                        MessageBox.Show("Constraseña incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    MessageBox.Show("Favor Ingrese la constraseña", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
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
                Call cmdAGREGAR_Click(cmdAGREGAR, New System.EventArgs)
            Else
                mod_Mensajes.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR.Enabled = True Then
                Call cmdMODIFICAR_Click(cmdMODIFICAR, New System.EventArgs)
            Else
                Dim ContarRegistros As Integer = BindingSource_MENUCONT_1.Count

                If ContarRegistros = 0 Then
                    mod_Mensajes.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_Mensajes.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            If cmdELIMINAR.Enabled = True Then
                Call cmdELIMINAR_Click(cmdELIMINAR, New System.EventArgs)
            Else
                Dim ContarRegistros As Integer = BindingSource_MENUCONT_1.Count

                If ContarRegistros = 0 Then
                    mod_Mensajes.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_Mensajes.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If


    End Sub
    Private Sub dgvMECOMECO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMECOMECO.GotFocus
        strBARRESTA.Items(0).Text = dgvMECOMECO.AccessibleDescription
    End Sub

#End Region


End Class