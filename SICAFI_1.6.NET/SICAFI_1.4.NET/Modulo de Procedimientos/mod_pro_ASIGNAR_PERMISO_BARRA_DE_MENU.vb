Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports REGLAS_DEL_NEGOCIO

Module mod_pro_ASIGNAR_PERMISO_BARRA_DE_MENU

    Public Sub pro_Permiso_Barra_De_Menu(ByVal inNRO_REGISTROS As Integer, _
                                       ByRef boCONTAGRE As Boolean, _
                                       ByRef boCONTMODI As Boolean, _
                                       ByRef boCONTELIM As Boolean, _
                                       ByRef boCONSULTAR As Boolean, _
                                       ByRef boRECONSULTAR As Boolean)

        Try
            Dim objdatos1 As New cla_CONTRASENA
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

            Dim bo_CONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
            Dim bo_CONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
            Dim bo_CONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

            Dim ContarRegistros As Integer = inNRO_REGISTROS

            If bo_CONTAGRE = True Then
                boCONTAGRE = True
            Else
                boCONTAGRE = False
            End If

            If ContarRegistros = 0 Then
                boCONTMODI = False
            Else
                If bo_CONTMODI = True Then
                    boCONTMODI = True
                Else
                    boCONTMODI = False
                End If
            End If

            If ContarRegistros = 0 Then
                boCONTELIM = False
            Else
                If bo_CONTELIM = True Then
                    boCONTELIM = True
                Else
                    boCONTELIM = False
                End If
            End If

            If ContarRegistros = 0 Then
                boCONSULTAR = False
                boRECONSULTAR = False
            Else
                boCONSULTAR = True
                boRECONSULTAR = True
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub pro_Permiso_Barra_De_Menu_Formulario_Formulario(ByVal inNroRegistros As Integer, _
                                                               ByVal stNombreFormulario As String, _
                                                               ByRef boBotonAgregar As Boolean, _
                                                               ByRef boBotonmodificar As Boolean, _
                                                               ByRef boBotonEliminar As Boolean, _
                                                               ByRef boBotonConsultar As Boolean, _
                                                               ByRef boBotonReconsultar As Boolean)

        Try
            '*** PERMISOS PARA ADMINISTRADOR ***

            If vp_usuario = "ADMINISTRADOR" Then

                ' consulto el formulario por usuario
                Dim objdatos1 As New cla_PERMFORM
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_Y_FORMULARIO_PERMFORM(Trim(vp_usuario), Trim(stNombreFormulario))

                ' verifica si existe el formulario para el roles
                If tbl1.Rows.Count = 0 Then

                    boBotonAgregar = False
                    boBotonmodificar = False
                    boBotonEliminar = False
                    boBotonConsultar = False
                    boBotonReconsultar = False
                Else
                    ' declara variables
                    Dim bo_CONTAGRE As Boolean = False
                    Dim bo_CONTMODI As Boolean = False
                    Dim bo_CONTELIM As Boolean = False

                    ' verifica los registro
                    If tbl1.Rows.Count > 0 Then

                        bo_CONTAGRE = Trim(tbl1.Rows(0).Item("PEFOAGRE"))
                        bo_CONTMODI = Trim(tbl1.Rows(0).Item("PEFOMODI"))
                        bo_CONTELIM = Trim(tbl1.Rows(0).Item("PEFOELIM"))

                    End If

                    Dim ContarRegistros As Integer = inNroRegistros

                    If bo_CONTAGRE = True Then
                        boBotonAgregar = True
                    Else
                        boBotonAgregar = False
                    End If

                    If ContarRegistros = 0 Then
                        boBotonmodificar = False
                    Else
                        If bo_CONTMODI = True Then
                            boBotonmodificar = True
                        Else
                            boBotonmodificar = False
                        End If
                    End If

                    If ContarRegistros = 0 Then
                        boBotonEliminar = False
                    Else
                        If bo_CONTELIM = True Then
                            boBotonEliminar = True
                        Else
                            boBotonEliminar = False
                        End If
                    End If

                    If ContarRegistros = 0 Then
                        boBotonConsultar = False
                        boBotonReconsultar = False
                    Else
                        boBotonConsultar = True
                        boBotonReconsultar = True
                    End If

                End If

            Else
                '*** PERMISOS PARA USUARIOS ***

                ' consulta el roles del usuario
                Dim objdatos23 As New cla_PERMROLE
                Dim tbl23 As New DataTable

                tbl23 = objdatos23.fun_Buscar_USUARIO_PERMROLE(vp_usuario)

                ' verifica que el usuario tenga un roles
                If tbl23.Rows.Count = 0 Then

                    boBotonAgregar = False
                    boBotonmodificar = False
                    boBotonEliminar = False
                    boBotonConsultar = False
                    boBotonReconsultar = False

                Else
                    ' declara la variable 
                    Dim stRoles As String = ""

                    ' almacena el roles
                    stRoles = Trim(tbl23.Rows(0).Item("PEROROLE").ToString)

                    ' consulto el formulario por usuario
                    Dim objdatos1 As New cla_PERMFORM
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_USUARIO_Y_FORMULARIO_PERMFORM(Trim(stRoles), Trim(stNombreFormulario))

                    ' verifica si existe el formulario para el roles
                    If tbl1.Rows.Count = 0 Then

                        boBotonAgregar = False
                        boBotonmodificar = False
                        boBotonEliminar = False
                        boBotonConsultar = True
                        boBotonReconsultar = True

                    Else
                        ' declara variables
                        Dim bo_CONTAGRE As Boolean = False
                        Dim bo_CONTMODI As Boolean = False
                        Dim bo_CONTELIM As Boolean = False

                        ' verifica los registro
                        If tbl1.Rows.Count > 0 Then

                            bo_CONTAGRE = Trim(tbl1.Rows(0).Item("PEFOAGRE"))
                            bo_CONTMODI = Trim(tbl1.Rows(0).Item("PEFOMODI"))
                            bo_CONTELIM = Trim(tbl1.Rows(0).Item("PEFOELIM"))

                        End If

                        Dim ContarRegistros As Integer = inNroRegistros

                        If bo_CONTAGRE = True Then
                            boBotonAgregar = True
                        Else
                            boBotonAgregar = False
                        End If

                        If ContarRegistros = 0 Then
                            boBotonmodificar = False
                        Else
                            If bo_CONTMODI = True Then
                                boBotonmodificar = True
                            Else
                                boBotonmodificar = False
                            End If
                        End If

                        If ContarRegistros = 0 Then
                            boBotonEliminar = False
                        Else
                            If bo_CONTELIM = True Then
                                boBotonEliminar = True
                            Else
                                boBotonEliminar = False
                            End If
                        End If

                        If ContarRegistros = 0 Then
                            boBotonConsultar = False
                            boBotonReconsultar = False
                        Else
                            boBotonConsultar = True
                            boBotonReconsultar = True
                        End If

                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ByVal inNroRegistros As Integer, _
                                                    ByVal stNombreSubFormulario As String, _
                                                    ByRef boBotonAgregar As Boolean, _
                                                    ByRef boBotonmodificar As Boolean, _
                                                    ByRef boBotonEliminar As Boolean, _
                                                    ByRef boBotonConsultar As Boolean, _
                                                    ByRef boBotonReconsultar As Boolean)

        Try
            Dim objdatos37 As New cla_PERMSUFO
            Dim tbl37 As New DataTable

            tbl37 = objdatos37.fun_Buscar_USUARIO_Y_FORMULARIO_PERMSUFO(Trim(vp_usuario), Trim(stNombreSubFormulario))

            If tbl37.Rows.Count = 0 And Trim(vp_usuario) <> "ADMINISTRADOR" Then

                boBotonAgregar = False
                boBotonmodificar = False
                boBotonEliminar = False
                boBotonConsultar = True
                boBotonReconsultar = True

            ElseIf Trim(vp_usuario) = "ADMINISTRADOR" Then

                Dim ContarRegistros As Integer = inNroRegistros

                boBotonAgregar = True

                If ContarRegistros = 0 Then
                    boBotonmodificar = False
                Else
                    boBotonmodificar = True
                End If

                If ContarRegistros = 0 Then
                    boBotonEliminar = False
                Else
                    boBotonEliminar = True
                End If

                If ContarRegistros = 0 Then
                    boBotonConsultar = False
                    boBotonReconsultar = False
                Else
                    boBotonConsultar = True
                    boBotonReconsultar = True
                End If

            ElseIf tbl37.Rows.Count <> 0 Then

                ' declara variables
                Dim bo_CONTAGRE As Boolean = False
                Dim bo_CONTMODI As Boolean = False
                Dim bo_CONTELIM As Boolean = False

                ' verifica los registro
                bo_CONTAGRE = Trim(tbl37.Rows(0).Item("PESFAGRE"))
                bo_CONTMODI = Trim(tbl37.Rows(0).Item("PESFMODI"))
                bo_CONTELIM = Trim(tbl37.Rows(0).Item("PESFELIM"))

                Dim ContarRegistros As Integer = inNroRegistros

                If bo_CONTAGRE = True Then
                    boBotonAgregar = True
                Else
                    boBotonAgregar = False
                End If

                If ContarRegistros = 0 Then
                    boBotonmodificar = False
                Else
                    If bo_CONTMODI = True Then
                        boBotonmodificar = True
                    Else
                        boBotonmodificar = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    boBotonEliminar = False
                Else
                    If bo_CONTELIM = True Then
                        boBotonEliminar = True
                    Else
                        boBotonEliminar = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    boBotonConsultar = False
                    boBotonReconsultar = False
                Else
                    boBotonConsultar = True
                    boBotonReconsultar = True
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub

End Module
