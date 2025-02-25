Imports REGLAS_DEL_NEGOCIO
Imports System.Windows.Forms
'================================================================
' *** GALERIA PARA CAPTURAR LA MAQUINA EN LA QUE OPERA EL SISTEMA
'================================================================
Imports SYSTEM.Security.Principal
Imports SYSTEM.Security.Permissions


Public Class mdi_CONTENEDOR
    Inherits System.Windows.Forms.Form

    '=============================
    '*** FORMULARIO CONTENEDOR ***
    '=============================

#Region "VARIABLES"

    '==============================================
    ' *** PERMISO DE USUARIO PARA LAS ETIQUETAS ***
    '==============================================
    Dim Permiso_Diligenciar As Boolean
    Dim Permiso_Mantenimiento As Boolean
    Dim Permiso_Consultas As Boolean
    Dim Permiso_Reportes As Boolean
    Dim Permiso_GeneracionPlanos As Boolean
    Dim Permiso_Utilidades As Boolean
    Dim Permiso_Ver As Boolean

    '========================================================
    ' *** VARIABLE QUE ALMACENA LA IMAGEN DEL PAPEL TAPIZ ***
    '========================================================
    Dim RutaImagenPapelTapiz As String

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_PermisoUsuarioEtiquetaMenuContenedor()

        Try

            '============================================================================
            '*** CONFIGURA EL PERMISOS DE USUARIO PARA MOSTRAR LAS ETIQUETAS DEL MENU ***
            '============================================================================

            Dim Etiqueta_Diligenciar As String = Trim(DiligenciarToolStripMenuItem.Name)
            Dim Etiqueta_Mantenimiento As String = Trim(MantenimientoToolStripMenuItem.Name)
            Dim Etiqueta_Consultas As String = Trim(ConsultasToolStripMenuItem.Name)
            Dim Etiqueta_Reportes As String = Trim(ReportesToolStripMenuItem.Name)
            Dim Etiqueta_GeneracionPlanos As String = Trim(GeneracionPlanosToolStripMenuItem.Name)
            Dim Etiqueta_Utilidades As String = Trim(UtilidadesToolStripMenuItem.Name)
            Dim Etiqueta_Ver As String = Trim(VerToolStripMenuItem.Name)


            '========================================================
            ' Restablese los permisos de las etiquetas del contenedor
            '========================================================

            Permiso_Diligenciar = False
            Permiso_Mantenimiento = False
            Permiso_Consultas = False
            Permiso_Reportes = False
            Permiso_GeneracionPlanos = False
            Permiso_Utilidades = False
            Permiso_Ver = False

            '===============================================================================
            ' Busca los permisos otorgados al usuario para la visualización de las etiquetas
            '===============================================================================


            Dim objdatos As New cla_PERMUSUA
            Dim tbl As New DataTable

            Dim objdatos1 As New cla_MENUCONT
            Dim tbl1 As New DataTable

            tbl = objdatos.fun_Buscar_USUARIO_PERMUSUA(vp_usuario)
            tbl1 = objdatos1.fun_Consultar_CAMPOS_MANT_MENUCONT()

            Dim j As Integer

            For j = 0 To tbl.Rows.Count - 1

                If vp_usuario = Trim(tbl.Rows(j).Item("PEUSUSUA")) Then

                    Dim Contenido As String = Trim(tbl.Rows(j).Item("PEUSETIQ"))

                    If Trim(Etiqueta_Diligenciar) = Trim(Contenido) Then
                        Permiso_Diligenciar = True

                        If Permiso_Diligenciar = True Then
                            DiligenciarToolStripMenuItem.Visible = True

                            ' busca el nombre de etiqueta personalizada
                            Dim k As Integer

                            For k = 0 To tbl1.Rows.Count - 1

                                If Trim(Etiqueta_Diligenciar) = Trim(tbl1.Rows(k).Item("MECOCODI")) Then
                                    DiligenciarToolStripMenuItem.Text = Trim(tbl1.Rows(k).Item("MECODESC"))
                                End If
                            Next
                        Else
                            DiligenciarToolStripMenuItem.Visible = False
                        End If
                    End If



                    If Trim(Etiqueta_Mantenimiento) = Trim(Contenido) Then
                        Permiso_Mantenimiento = True

                        If Permiso_Mantenimiento = True Then
                            MantenimientoToolStripMenuItem.Visible = True

                            ' busca el nombre de etiqueta personalizada
                            Dim k As Integer

                            For k = 0 To tbl1.Rows.Count - 1

                                If Trim(Etiqueta_Mantenimiento) = Trim(tbl1.Rows(k).Item("MECOCODI")) Then
                                    MantenimientoToolStripMenuItem.Text = Trim(tbl1.Rows(k).Item("MECODESC"))
                                End If
                            Next
                        Else
                            MantenimientoToolStripMenuItem.Visible = False
                        End If
                    End If

                    If Trim(Etiqueta_Consultas) = Trim(Contenido) Then
                        Permiso_Consultas = True

                        If Permiso_Consultas = True Then
                            ConsultasToolStripMenuItem.Visible = True

                            ' busca el nombre de etiqueta personalizada
                            Dim k As Integer

                            For k = 0 To tbl1.Rows.Count - 1

                                If Trim(Etiqueta_Consultas) = Trim(tbl1.Rows(k).Item("MECOCODI")) Then
                                    ConsultasToolStripMenuItem.Text = Trim(tbl1.Rows(k).Item("MECODESC"))
                                End If
                            Next
                        Else
                            ConsultasToolStripMenuItem.Visible = False
                        End If
                    End If

                    If Trim(Etiqueta_Reportes) = Trim(Contenido) Then
                        Permiso_Reportes = True

                        If Permiso_Reportes = True Then
                            ReportesToolStripMenuItem.Visible = True

                            ' busca el nombre de etiqueta personalizada
                            Dim k As Integer

                            For k = 0 To tbl1.Rows.Count - 1

                                If Trim(Etiqueta_Reportes) = Trim(tbl1.Rows(k).Item("MECOCODI")) Then
                                    ReportesToolStripMenuItem.Text = Trim(tbl1.Rows(k).Item("MECODESC"))
                                End If
                            Next
                        Else
                            ReportesToolStripMenuItem.Visible = False
                        End If
                    End If

                    If Trim(Etiqueta_GeneracionPlanos) = Trim(Contenido) Then
                        Permiso_GeneracionPlanos = True

                        If Permiso_GeneracionPlanos = True Then
                            GeneracionPlanosToolStripMenuItem.Visible = True

                            ' busca el nombre de etiqueta personalizada
                            Dim k As Integer

                            For k = 0 To tbl1.Rows.Count - 1

                                If Trim(Etiqueta_GeneracionPlanos) = Trim(tbl1.Rows(k).Item("MECOCODI")) Then
                                    GeneracionPlanosToolStripMenuItem.Text = Trim(tbl1.Rows(k).Item("MECODESC"))
                                End If
                            Next
                        Else
                            GeneracionPlanosToolStripMenuItem.Visible = False
                        End If

                    End If

                    If Trim(Etiqueta_Utilidades) = Trim(Contenido) Then
                        Permiso_Utilidades = True

                        If Permiso_Utilidades = True Then
                            UtilidadesToolStripMenuItem.Visible = True

                            ' busca el nombre de etiqueta personalizada
                            Dim k As Integer

                            For k = 0 To tbl1.Rows.Count - 1

                                If Trim(Etiqueta_Utilidades) = Trim(tbl1.Rows(k).Item("MECOCODI")) Then
                                    UtilidadesToolStripMenuItem.Text = Trim(tbl1.Rows(k).Item("MECODESC"))
                                End If
                            Next
                        Else
                            UtilidadesToolStripMenuItem.Visible = False
                        End If
                    End If

                    If Trim(Etiqueta_Ver) = Trim(Contenido) Then
                        Permiso_Ver = True

                        If Permiso_Ver = True Then
                            VerToolStripMenuItem.Visible = True

                            ' busca el nombre de etiqueta personalizada
                            Dim k As Integer

                            For k = 0 To tbl1.Rows.Count - 1

                                If Trim(Etiqueta_Ver) = Trim(tbl1.Rows(k).Item("MECOCODI")) Then
                                    VerToolStripMenuItem.Text = Trim(tbl1.Rows(k).Item("MECODESC"))
                                End If
                            Next
                        Else
                            VerToolStripMenuItem.Visible = False
                        End If
                    End If

                End If
            Next

            '===========================================
            ' Muestra las barras estandar del contenedor 
            '===========================================

            MenuStrip.Visible = True
            strBARRESTA.Visible = True

            strBARRESTA.Items(0).Text = vp_usuario
            strBARRESTA.Items(1).Text = vp_nombres


        Catch ex As Exception
            MessageBox.Show(Err.Description & "Pro_PermisoUsuarioEtiquetaMenu")
        End Try

    End Sub
    Private Sub pro_PermisoUsuarioSubEtiquetasMenuContenedor()

        Try
            '========================================
            '*** ACTIVA LAS ETIQUETAS SEGUN ROLES ***
            '========================================

            ' instancia la clase
            Dim objdatos66 As New cla_PERMETIQ
            Dim tbj66 As New DataTable

            tbj66 = objdatos66.fun_Buscar_ETIQUETA_X_USUARIO_PERMETIQ("ADMINISTRADOR")

            ' verifica si existe registro
            If tbj66.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To tbj66.Rows.Count - 1

                    ' declara la variable
                    Dim stEtiquetaAdmin As String = ""

                    ' alamace el nombre de la etiqueta
                    stEtiquetaAdmin = Trim(tbj66.Rows(i).Item("PEETETIQ").ToString)

                    ' encuentra y activa la etiqueta
                    If fun_Asignar_Etiqueta_Barra_De_Menu(stEtiquetaAdmin) = True Then

                        If Trim(stEtiquetaAdmin) = Trim(Me.TerceroToolStripMenuItem.Name) Then
                            Me.TerceroToolStripMenuItem.Enabled = True
                            Me.TerceroToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.EstadoToolStripMenuItem.Name) Then
                            Me.EstadoToolStripMenuItem.Enabled = True
                            Me.EstadoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClaseOSectorToolStripMenuItem.Name) Then
                            Me.ClaseOSectorToolStripMenuItem.Enabled = True
                            Me.ClaseOSectorToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CalidadDepropietarioToolStripMenuItem.Name) Then
                            Me.CalidadDepropietarioToolStripMenuItem.Enabled = True
                            Me.CalidadDepropietarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CategoriaDeSueloToolStripMenuItem.Name) Then
                            Me.CategoriaDeSueloToolStripMenuItem.Enabled = True
                            Me.CategoriaDeSueloToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.DestinacioneconomicaToolStripMenuItem.Name) Then
                            Me.DestinacioneconomicaToolStripMenuItem.Enabled = True
                            Me.DestinacioneconomicaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoDeDocumentoToolStripMenuItem.Name) Then
                            Me.TipoDeDocumentoToolStripMenuItem.Enabled = True
                            Me.TipoDeDocumentoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CaracteristicaDePredioToolStripMenuItem.Name) Then
                            Me.CaracteristicaDePredioToolStripMenuItem.Enabled = True
                            Me.CaracteristicaDePredioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClaseDeConstruccionToolStripMenuItem.Name) Then
                            Me.ClaseDeConstruccionToolStripMenuItem.Enabled = True
                            Me.ClaseDeConstruccionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.DepartamentoToolStripMenuItem.Name) Then
                            Me.DepartamentoToolStripMenuItem.Enabled = True
                            Me.DepartamentoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ModoDeAdquisicionToolStripMenuItem.Name) Then
                            Me.ModoDeAdquisicionToolStripMenuItem.Enabled = True
                            Me.ModoDeAdquisicionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MunicipioToolStripMenuItem.Name) Then
                            Me.MunicipioToolStripMenuItem.Enabled = True
                            Me.MunicipioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.NotariaToolStripMenuItem.Name) Then
                            Me.NotariaToolStripMenuItem.Enabled = True
                            Me.NotariaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.SexoToolStripMenuItem.Name) Then
                            Me.SexoToolStripMenuItem.Enabled = True
                            Me.SexoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoDeConstruccionToolStripMenuItem.Name) Then
                            Me.TipoDeConstruccionToolStripMenuItem.Enabled = True
                            Me.TipoDeConstruccionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.VigenciaToolStripMenuItem.Name) Then
                            Me.VigenciaToolStripMenuItem.Enabled = True
                            Me.VigenciaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ZonasEconomicasToolStripMenuItem.Name) Then
                            Me.ZonasEconomicasToolStripMenuItem.Enabled = True
                            Me.ZonasEconomicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ZonasFisicasToolStripMenuItem.Name) Then
                            Me.ZonasFisicasToolStripMenuItem.Enabled = True
                            Me.ZonasFisicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ManualesDeCatastroToolStripMenuItem.Name) Then
                            Me.ManualesDeCatastroToolStripMenuItem.Enabled = True
                            Me.ManualesDeCatastroToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoDeTablasToolStripMenuItem1.Name) Then
                            Me.MantenimientoDeTablasToolStripMenuItem1.Enabled = True
                            Me.MantenimientoDeTablasToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PermisosAUsuariosToolStripMenuItem.Name) Then
                            Me.PermisosAUsuariosToolStripMenuItem.Enabled = True
                            Me.PermisosAUsuariosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PersonalizarMenuPrincipalToolStripMenuItem.Name) Then
                            Me.PersonalizarMenuPrincipalToolStripMenuItem.Enabled = True
                            Me.PersonalizarMenuPrincipalToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoToolStripMenuItem.Name) Then
                            Me.TipoToolStripMenuItem.Enabled = True
                            Me.TipoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.BarraDeHerramientasFichaPredialToolStripMenuItem.Name) Then
                            Me.BarraDeHerramientasFichaPredialToolStripMenuItem.Enabled = True
                            Me.BarraDeHerramientasFichaPredialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.UsuarioToolStripMenuItem.Name) Then
                            Me.UsuarioToolStripMenuItem.Enabled = True
                            Me.UsuarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FichapredialToolStripMenuItem.Name) Then
                            Me.FichapredialToolStripMenuItem.Enabled = True
                            Me.FichapredialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.BarraDeestadoToolStripMenuItem.Name) Then
                            Me.BarraDeestadoToolStripMenuItem.Enabled = True
                            Me.BarraDeestadoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PerfilDeUsuarioToolStripMenuItem.Name) Then
                            Me.PerfilDeUsuarioToolStripMenuItem.Enabled = True
                            Me.PerfilDeUsuarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PlanosTerceroToolStripMenuItem.Name) Then
                            Me.PlanosTerceroToolStripMenuItem.Enabled = True
                            Me.PlanosTerceroToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoDeCalificacionToolStripMenuItem.Name) Then
                            Me.TipoDeCalificacionToolStripMenuItem.Enabled = True
                            Me.TipoDeCalificacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PuntoCardinalToolStripMenuItem.Name) Then
                            Me.PuntoCardinalToolStripMenuItem.Enabled = True
                            Me.PuntoCardinalToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CodigoDeCalificacionToolStripMenuItem.Name) Then
                            Me.CodigoDeCalificacionToolStripMenuItem.Enabled = True
                            Me.CodigoDeCalificacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ResolucionToolStripMenuItem.Name) Then
                            Me.ResolucionToolStripMenuItem.Enabled = True
                            Me.ResolucionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaSQLServerToolStripMenuItem.Name) Then
                            Me.ConsultaSQLServerToolStripMenuItem.Enabled = True
                            Me.ConsultaSQLServerToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaAreaDeTerrenoToolStripMenuItem.Name) Then
                            Me.ConsultaAreaDeTerrenoToolStripMenuItem.Enabled = True
                            Me.ConsultaAreaDeTerrenoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaCoeficientesToolStripMenuItem.Name) Then
                            Me.ConsultaCoeficientesToolStripMenuItem.Enabled = True
                            Me.ConsultaCoeficientesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaPropietarioToolStripMenuItem.Name) Then
                            Me.ConsultaPropietarioToolStripMenuItem.Enabled = True
                            Me.ConsultaPropietarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaConstruccionToolStripMenuItem.Name) Then
                            Me.ConsultaConstruccionToolStripMenuItem.Enabled = True
                            Me.ConsultaConstruccionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ValidarFichaPredialToolStripMenuItem.Name) Then
                            Me.ValidarFichaPredialToolStripMenuItem.Enabled = True
                            Me.ValidarFichaPredialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.EstadisticasFichaPredialToolStripMenuItem.Name) Then
                            Me.EstadisticasFichaPredialToolStripMenuItem.Enabled = True
                            Me.EstadisticasFichaPredialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaDestinacionToolStripMenuItem.Name) Then
                            Me.ConsultaDestinacionToolStripMenuItem.Enabled = True
                            Me.ConsultaDestinacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaZonasEconomicasYFisicasToolStripMenuItem.Name) Then
                            Me.ConsultaZonasEconomicasYFisicasToolStripMenuItem.Enabled = True
                            Me.ConsultaZonasEconomicasYFisicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ImportarFichaToolStripMenuItem1.Name) Then
                            Me.ImportarFichaToolStripMenuItem1.Enabled = True
                            Me.ImportarFichaToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ExportarFichaToolStripMenuItem.Name) Then
                            Me.ExportarFichaToolStripMenuItem.Enabled = True
                            Me.ExportarFichaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CruceFichaPredialVsPlanoToolStripMenuItem.Name) Then
                            Me.CruceFichaPredialVsPlanoToolStripMenuItem.Enabled = True
                            Me.CruceFichaPredialVsPlanoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CrucePropietarioVsPlanoToolStripMenuItem.Name) Then
                            Me.CrucePropietarioVsPlanoToolStripMenuItem.Enabled = True
                            Me.CrucePropietarioVsPlanoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FicharesumenToolStripMenuItem.Name) Then
                            Me.FicharesumenToolStripMenuItem.Enabled = True
                            Me.FicharesumenToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RemplazaridentificadoresToolStripMenuItem.Name) Then
                            Me.RemplazaridentificadoresToolStripMenuItem.Enabled = True
                            Me.RemplazaridentificadoresToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MarcarpredioComoConjutoToolStripMenuItem.Name) Then
                            Me.MarcarpredioComoConjutoToolStripMenuItem.Enabled = True
                            Me.MarcarpredioComoConjutoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AsignarFormularioToolStripMenuItem.Name) Then
                            Me.AsignarFormularioToolStripMenuItem.Enabled = True
                            Me.AsignarFormularioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AsignarRolesToolStripMenuItem1.Name) Then
                            Me.AsignarRolesToolStripMenuItem1.Enabled = True
                            Me.AsignarRolesToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CatastroToolStripMenuItem.Name) Then
                            Me.CatastroToolStripMenuItem.Enabled = True
                            Me.CatastroToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PlanosActualizaciónToolStripMenuItem.Name) Then
                            Me.PlanosActualizaciónToolStripMenuItem.Enabled = True
                            Me.PlanosActualizaciónToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AsignarEtiquetasToolStripMenuItem.Name) Then
                            Me.AsignarEtiquetasToolStripMenuItem.Enabled = True
                            Me.AsignarEtiquetasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FichaPredialToolStripMenuItem2.Name) Then
                            Me.FichaPredialToolStripMenuItem2.Enabled = True
                            Me.FichaPredialToolStripMenuItem2.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PlanosFichapredialToolStripMenuItem4.Name) Then
                            Me.PlanosFichapredialToolStripMenuItem4.Enabled = True
                            Me.PlanosFichapredialToolStripMenuItem4.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PlanosZonasToolStripMenuItem.Name) Then
                            Me.PlanosZonasToolStripMenuItem.Enabled = True
                            Me.PlanosZonasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ImportarFichaToolStripMenuItem1.Name) Then
                            Me.ImportarFichaToolStripMenuItem1.Enabled = True
                            Me.ImportarFichaToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ExportarFichaToolStripMenuItem.Name) Then
                            Me.ExportarFichaToolStripMenuItem.Enabled = True
                            Me.ExportarFichaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.UtilidadedesFichapredialToolStripMenuItem3.Name) Then
                            Me.UtilidadedesFichapredialToolStripMenuItem3.Enabled = True
                            Me.UtilidadedesFichapredialToolStripMenuItem3.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoFichapredialToolStripMenuItem1.Name) Then
                            Me.MantenimientoFichapredialToolStripMenuItem1.Enabled = True
                            Me.MantenimientoFichapredialToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoSistemaToolStripMenuItem.Name) Then
                            Me.MantenimientoSistemaToolStripMenuItem.Enabled = True
                            Me.MantenimientoSistemaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoAdministradorToolStripMenuItem.Name) Then
                            Me.MantenimientoAdministradorToolStripMenuItem.Enabled = True
                            Me.MantenimientoAdministradorToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.GenerarZonasImportarFichaToolStripMenuItem2.Name) Then
                            Me.GenerarZonasImportarFichaToolStripMenuItem2.Enabled = True
                            Me.GenerarZonasImportarFichaToolStripMenuItem2.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.GenerarZonasExportarFichaToolStripMenuItem2.Name) Then
                            Me.GenerarZonasExportarFichaToolStripMenuItem2.Enabled = True
                            Me.GenerarZonasExportarFichaToolStripMenuItem2.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AvaluosToolStripMenuItem.Name) Then
                            Me.AvaluosToolStripMenuItem.Enabled = True
                            Me.AvaluosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ImpuestoPredialToolStripMenuItem.Name) Then
                            Me.ImpuestoPredialToolStripMenuItem.Enabled = True
                            Me.ImpuestoPredialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasPorDestinacionEconomicasToolStripMenuItem.Name) Then
                            Me.TarifasPorDestinacionEconomicasToolStripMenuItem.Enabled = True
                            Me.TarifasPorDestinacionEconomicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasPorZonasEconomicasToolStripMenuItem.Name) Then
                            Me.TarifasPorZonasEconomicasToolStripMenuItem.Enabled = True
                            Me.TarifasPorZonasEconomicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConceptoToolStripMenuItem.Name) Then
                            Me.ConceptoToolStripMenuItem.Enabled = True
                            Me.ConceptoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ImpuestoPredialToolStripMenuItem1.Name) Then
                            Me.ImpuestoPredialToolStripMenuItem1.Enabled = True
                            Me.ImpuestoPredialToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ActualizacionAreaDeTerrenoToolStripMenuItem.Name) Then
                            Me.ActualizacionAreaDeTerrenoToolStripMenuItem.Enabled = True
                            Me.ActualizacionAreaDeTerrenoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ValidacionesEspecialesToolStripMenuItem.Name) Then
                            Me.ValidacionesEspecialesToolStripMenuItem.Enabled = True
                            Me.ValidacionesEspecialesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ModoDeLiquidacionToolStripMenuItem.Name) Then
                            Me.ModoDeLiquidacionToolStripMenuItem.Enabled = True
                            Me.ModoDeLiquidacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.InsertarcartografiaPorLotesToolStripMenuItem.Name) Then
                            Me.InsertarcartografiaPorLotesToolStripMenuItem.Enabled = True
                            Me.InsertarcartografiaPorLotesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.GenerarZonasExportarFichaToolStripMenuItem2.Name) Then
                            Me.GenerarZonasExportarFichaToolStripMenuItem2.Enabled = True
                            Me.GenerarZonasExportarFichaToolStripMenuItem2.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.EstratoToolStripMenuItem.Name) Then
                            Me.EstratoToolStripMenuItem.Enabled = True
                            Me.EstratoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoDeAforoToolStripMenuItem.Name) Then
                            Me.TipoDeAforoToolStripMenuItem.Enabled = True
                            Me.TipoDeAforoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PeriodoToolStripMenuItem.Name) Then
                            Me.PeriodoToolStripMenuItem.Enabled = True
                            Me.PeriodoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PeriodoDeActualizacionToolStripMenuItem.Name) Then
                            Me.PeriodoDeActualizacionToolStripMenuItem.Enabled = True
                            Me.PeriodoDeActualizacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasAlumbradoPublicoToolStripMenuItem.Name) Then
                            Me.TarifasAlumbradoPublicoToolStripMenuItem.Enabled = True
                            Me.TarifasAlumbradoPublicoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasActividadBomberilToolStripMenuItem.Name) Then
                            Me.TarifasActividadBomberilToolStripMenuItem.Enabled = True
                            Me.TarifasActividadBomberilToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RutasToolStripMenuItem.Name) Then
                            Me.RutasToolStripMenuItem.Enabled = True
                            Me.RutasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ImagenDelPredioToolStripMenuItem.Name) Then
                            Me.ImagenDelPredioToolStripMenuItem.Enabled = True
                            Me.ImagenDelPredioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasDePrediosEspecialesToolStripMenuItem.Name) Then
                            Me.TarifasDePrediosEspecialesToolStripMenuItem.Enabled = True
                            Me.TarifasDePrediosEspecialesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.DestinacionEconomicaPorLotesToolStripMenuItem.Name) Then
                            Me.DestinacionEconomicaPorLotesToolStripMenuItem.Enabled = True
                            Me.DestinacionEconomicaPorLotesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasPorLotesToolStripMenuItem.Name) Then
                            Me.TarifasPorLotesToolStripMenuItem.Enabled = True
                            Me.TarifasPorLotesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PariodoActualToolStripMenuItem.Name) Then
                            Me.PariodoActualToolStripMenuItem.Enabled = True
                            Me.PariodoActualToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ValidacionesRetiradasToolStripMenuItem.Name) Then
                            Me.ValidacionesRetiradasToolStripMenuItem.Enabled = True
                            Me.ValidacionesRetiradasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasPorRangosDeAvaluosToolStripMenuItem.Name) Then
                            Me.TarifasPorRangosDeAvaluosToolStripMenuItem.Enabled = True
                            Me.TarifasPorRangosDeAvaluosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ImpuestoToolStripMenuItem.Name) Then
                            Me.ImpuestoToolStripMenuItem.Enabled = True
                            Me.ImpuestoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.SujetoDeImpuestoToolStripMenuItem.Name) Then
                            Me.SujetoDeImpuestoToolStripMenuItem.Enabled = True
                            Me.SujetoDeImpuestoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FormulaToolStripMenuItem.Name) Then
                            Me.FormulaToolStripMenuItem.Enabled = True
                            Me.FormulaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoDeImpuestoToolStripMenuItem.Name) Then
                            Me.TipoDeImpuestoToolStripMenuItem.Enabled = True
                            Me.TipoDeImpuestoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FormulaMunicipioToolStripMenuItem.Name) Then
                            Me.FormulaMunicipioToolStripMenuItem.Enabled = True
                            Me.FormulaMunicipioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CirculoDeRegistroToolStripMenuItem.Name) Then
                            Me.CirculoDeRegistroToolStripMenuItem.Enabled = True
                            Me.CirculoDeRegistroToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CausaDelActoToolStripMenuItem.Name) Then
                            Me.CausaDelActoToolStripMenuItem.Enabled = True
                            Me.CausaDelActoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConservacionToolStripMenuItem.Name) Then
                            Me.ConservacionToolStripMenuItem.Enabled = True
                            Me.ConservacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PropietarioAnteriorToolStripMenuItem.Name) Then
                            Me.PropietarioAnteriorToolStripMenuItem.Enabled = True
                            Me.PropietarioAnteriorToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RangoDeAreaDeTerrenoToolStripMenuItem.Name) Then
                            Me.RangoDeAreaDeTerrenoToolStripMenuItem.Enabled = True
                            Me.RangoDeAreaDeTerrenoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.UtilidadesImpuestoToolStripMenuItem1.Name) Then
                            Me.UtilidadesImpuestoToolStripMenuItem1.Enabled = True
                            Me.UtilidadesImpuestoToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.LiquidaHistoricoDeAvaluoToolStripMenuItem.Name) Then
                            Me.LiquidaHistoricoDeAvaluoToolStripMenuItem.Enabled = True
                            Me.LiquidaHistoricoDeAvaluoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.LiquidaHistoricoDeLiquidacionToolStripMenuItem.Name) Then
                            Me.LiquidaHistoricoDeLiquidacionToolStripMenuItem.Enabled = True
                            Me.LiquidaHistoricoDeLiquidacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.IncrementoDeAvaluoPorDestinacionToolStripMenuItem.Name) Then
                            Me.IncrementoDeAvaluoPorDestinacionToolStripMenuItem.Enabled = True
                            Me.IncrementoDeAvaluoPorDestinacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.HistoricoDeZonaEconomicasToolStripMenuItem.Name) Then
                            Me.HistoricoDeZonaEconomicasToolStripMenuItem.Enabled = True
                            Me.HistoricoDeZonaEconomicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MaterialDeCampoToolStripMenuItem.Name) Then
                            Me.MaterialDeCampoToolStripMenuItem.Enabled = True
                            Me.MaterialDeCampoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.DiligenciarTrabajoDeCampoToolStripMenuItem.Name) Then
                            Me.DiligenciarTrabajoDeCampoToolStripMenuItem.Enabled = True
                            Me.DiligenciarTrabajoDeCampoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PrediosExentosToolStripMenuItem.Name) Then
                            Me.PrediosExentosToolStripMenuItem.Enabled = True
                            Me.PrediosExentosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.LiquidaAforoDeImpuestoToolStripMenuItem.Name) Then
                            Me.LiquidaAforoDeImpuestoToolStripMenuItem.Enabled = True
                            Me.LiquidaAforoDeImpuestoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PeriodoPermitidoDeLiquidacionToolStripMenuItem.Name) Then
                            Me.PeriodoPermitidoDeLiquidacionToolStripMenuItem.Enabled = True
                            Me.PeriodoPermitidoDeLiquidacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PrediosExentosPorNitToolStripMenuItem.Name) Then
                            Me.PrediosExentosPorNitToolStripMenuItem.Enabled = True
                            Me.PrediosExentosPorNitToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ReclamosToolStripMenuItem.Name) Then
                            Me.ReclamosToolStripMenuItem.Enabled = True
                            Me.ReclamosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoDeTramiteToolStripMenuItem.Name) Then
                            Me.TipoDeTramiteToolStripMenuItem.Enabled = True
                            Me.TipoDeTramiteToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AsignarSubformularioToolStripMenuItem.Name) Then
                            Me.AsignarSubformularioToolStripMenuItem.Enabled = True
                            Me.AsignarSubformularioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ActosAdministrativosToolStripMenuItem.Name) Then
                            Me.ActosAdministrativosToolStripMenuItem.Enabled = True
                            Me.ActosAdministrativosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaImpuestosToolStripMenuItem.Name) Then
                            Me.ConsultaImpuestosToolStripMenuItem.Enabled = True
                            Me.ConsultaImpuestosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaAvaluosCatastralesToolStripMenuItem.Name) Then
                            Me.ConsultaAvaluosCatastralesToolStripMenuItem.Enabled = True
                            Me.ConsultaAvaluosCatastralesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaHistoricosDeLiquidacionToolStripMenuItem.Name) Then
                            Me.ConsultaHistoricosDeLiquidacionToolStripMenuItem.Enabled = True
                            Me.ConsultaHistoricosDeLiquidacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaAforosToolStripMenuItem.Name) Then
                            Me.ConsultaAforosToolStripMenuItem.Enabled = True
                            Me.ConsultaAforosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MigrarDatosCatastralesToolStripMenuItem.Name) Then
                            Me.MigrarDatosCatastralesToolStripMenuItem.Enabled = True
                            Me.MigrarDatosCatastralesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PrediosConResolucionAdministrativaToolStripMenuItem.Name) Then
                            Me.PrediosConResolucionAdministrativaToolStripMenuItem.Enabled = True
                            Me.PrediosConResolucionAdministrativaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ProcedimientoToolStripMenuItem.Name) Then
                            Me.ProcedimientoToolStripMenuItem.Enabled = True
                            Me.ProcedimientoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TablasToolStripMenuItem.Name) Then
                            Me.TablasToolStripMenuItem.Enabled = True
                            Me.TablasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CamposToolStripMenuItem.Name) Then
                            Me.CamposToolStripMenuItem.Enabled = True
                            Me.CamposToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MigrarDatosDinamicamenteToolStripMenuItem.Name) Then
                            Me.MigrarDatosDinamicamenteToolStripMenuItem.Enabled = True
                            Me.MigrarDatosDinamicamenteToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaPropietarioAnteriorToolStripMenuItem2.Name) Then
                            Me.ConsultaPropietarioAnteriorToolStripMenuItem2.Enabled = True
                            Me.ConsultaPropietarioAnteriorToolStripMenuItem2.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.InvestigacionJuridicaToolStripMenuItem.Name) Then
                            Me.InvestigacionJuridicaToolStripMenuItem.Enabled = True
                            Me.InvestigacionJuridicaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.HistoricoDeSujetoDeImpuestoToolStripMenuItem.Name) Then
                            Me.HistoricoDeSujetoDeImpuestoToolStripMenuItem.Enabled = True
                            Me.HistoricoDeSujetoDeImpuestoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.SalariosMinimosVigentesLegalesToolStripMenuItem.Name) Then
                            Me.SalariosMinimosVigentesLegalesToolStripMenuItem.Enabled = True
                            Me.SalariosMinimosVigentesLegalesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MarcadorPorcentualPorConceptoToolStripMenuItem.Name) Then
                            Me.MarcadorPorcentualPorConceptoToolStripMenuItem.Enabled = True
                            Me.MarcadorPorcentualPorConceptoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CatastroObservatorioInmobiliarioToolStripMenuItem.Name) Then
                            Me.CatastroObservatorioInmobiliarioToolStripMenuItem.Enabled = True
                            Me.CatastroObservatorioInmobiliarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoObservatorioInmobiliarioToolStripMenuItem.Name) Then
                            Me.MantenimientoObservatorioInmobiliarioToolStripMenuItem.Enabled = True
                            Me.MantenimientoObservatorioInmobiliarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClaseDePredioToolStripMenuItem.Name) Then
                            Me.ClaseDePredioToolStripMenuItem.Enabled = True
                            Me.ClaseDePredioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MetodoDeInvestigacionToolStripMenuItem.Name) Then
                            Me.MetodoDeInvestigacionToolStripMenuItem.Enabled = True
                            Me.MetodoDeInvestigacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MobiliarioToolStripMenuItem.Name) Then
                            Me.MobiliarioToolStripMenuItem.Enabled = True
                            Me.MobiliarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CatastroObservatorioInmobiliarioToolStripMenuItem.Name) Then
                            Me.CatastroObservatorioInmobiliarioToolStripMenuItem.Enabled = True
                            Me.CatastroObservatorioInmobiliarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CorregimientoMantenimientoToolStripMenuItem.Name) Then
                            Me.CorregimientoMantenimientoToolStripMenuItem.Enabled = True
                            Me.CorregimientoMantenimientoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ComunaMantenimientoToolStripMenuItem.Name) Then
                            Me.ComunaMantenimientoToolStripMenuItem.Enabled = True
                            Me.ComunaMantenimientoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.BarrioVeredaToolStripMenuItem.Name) Then
                            Me.BarrioVeredaToolStripMenuItem.Enabled = True
                            Me.BarrioVeredaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MutacionToolStripMenuItem.Name) Then
                            Me.MutacionToolStripMenuItem.Enabled = True
                            Me.MutacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MutacionToolStripMenuItem.Name) Then
                            Me.MutacionToolStripMenuItem.Enabled = True
                            Me.MutacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.EstructurarLinderosToolStripMenuItem.Name) Then
                            Me.EstructurarLinderosToolStripMenuItem.Enabled = True
                            Me.EstructurarLinderosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultarLinderosToolStripMenuItem.Name) Then
                            Me.ConsultarLinderosToolStripMenuItem.Enabled = True
                            Me.ConsultarLinderosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.EstadisticaImpuestoPredialToolStripMenuItem2.Name) Then
                            Me.EstadisticaImpuestoPredialToolStripMenuItem2.Enabled = True
                            Me.EstadisticaImpuestoPredialToolStripMenuItem2.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultarObservatorioInmobiliarioToolStripMenuItem.Name) Then
                            Me.ConsultarObservatorioInmobiliarioToolStripMenuItem.Enabled = True
                            Me.ConsultarObservatorioInmobiliarioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.GeograficasToolStripMenuItem.Name) Then
                            Me.GeograficasToolStripMenuItem.Enabled = True
                            Me.GeograficasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AsignacionDeTarifasToolStripMenuItem.Name) Then
                            Me.AsignacionDeTarifasToolStripMenuItem.Enabled = True
                            Me.AsignacionDeTarifasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaExportarFichaOVCToolStripMenuItem.Name) Then
                            Me.ConsultaExportarFichaOVCToolStripMenuItem.Enabled = True
                            Me.ConsultaExportarFichaOVCToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.SolicitanteToolStripMenuItem.Name) Then
                            Me.SolicitanteToolStripMenuItem.Enabled = True
                            Me.SolicitanteToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoDeVariableToolStripMenuItem.Name) Then
                            Me.TipoDeVariableToolStripMenuItem.Enabled = True
                            Me.TipoDeVariableToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FactoresPorProyectoToolStripMenuItem.Name) Then
                            Me.FactoresPorProyectoToolStripMenuItem.Enabled = True
                            Me.FactoresPorProyectoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoValorizacionToolStripMenuItem.Name) Then
                            Me.MantenimientoValorizacionToolStripMenuItem.Enabled = True
                            Me.MantenimientoValorizacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ProyectoToolStripMenuItem.Name) Then
                            Me.ProyectoToolStripMenuItem.Enabled = True
                            Me.ProyectoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.VariableToolStripMenuItem.Name) Then
                            Me.VariableToolStripMenuItem.Enabled = True
                            Me.VariableToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ResolucionValorizacionToolStripMenuItem1.Name) Then
                            Me.ResolucionValorizacionToolStripMenuItem1.Enabled = True
                            Me.ResolucionValorizacionToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RangosToolStripMenuItem.Name) Then
                            Me.RangosToolStripMenuItem.Enabled = True
                            Me.RangosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClaseDeSueloToolStripMenuItem1.Name) Then
                            Me.ClaseDeSueloToolStripMenuItem1.Enabled = True
                            Me.ClaseDeSueloToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AreasDeActividadToolStripMenuItem.Name) Then
                            Me.AreasDeActividadToolStripMenuItem.Enabled = True
                            Me.AreasDeActividadToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TratamientosUrbanisticosToolStripMenuItem.Name) Then
                            Me.TratamientosUrbanisticosToolStripMenuItem.Enabled = True
                            Me.TratamientosUrbanisticosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.DestinacionToolStripMenuItem.Name) Then
                            Me.DestinacionToolStripMenuItem.Enabled = True
                            Me.DestinacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ServiciosToolStripMenuItem.Name) Then
                            Me.ServiciosToolStripMenuItem.Enabled = True
                            Me.ServiciosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ViasToolStripMenuItem.Name) Then
                            Me.ViasToolStripMenuItem.Enabled = True
                            Me.ViasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TopografiaToolStripMenuItem.Name) Then
                            Me.TopografiaToolStripMenuItem.Enabled = True
                            Me.TopografiaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoSegunDestinacionToolStripMenuItem.Name) Then
                            Me.TipoSegunDestinacionToolStripMenuItem.Enabled = True
                            Me.TipoSegunDestinacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.VariablesZonaFisicaToolStripMenuItem.Name) Then
                            Me.VariablesZonaFisicaToolStripMenuItem.Enabled = True
                            Me.VariablesZonaFisicaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PuntosRequeridosToolStripMenuItem.Name) Then
                            Me.PuntosRequeridosToolStripMenuItem.Enabled = True
                            Me.PuntosRequeridosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoObrasPublicasToolStripMenuItem.Name) Then
                            Me.MantenimientoObrasPublicasToolStripMenuItem.Enabled = True
                            Me.MantenimientoObrasPublicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.EstadoCivilToolStripMenuItem.Name) Then
                            Me.EstadoCivilToolStripMenuItem.Enabled = True
                            Me.EstadoCivilToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ZonaFisicaActualizacionToolStripMenuItem.Name) Then
                            Me.ZonaFisicaActualizacionToolStripMenuItem.Enabled = True
                            Me.ZonaFisicaActualizacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ZonaEconomicaActualizacionToolStripMenuItem.Name) Then
                            Me.ZonaEconomicaActualizacionToolStripMenuItem.Enabled = True
                            Me.ZonaEconomicaActualizacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.VariablesZonasFisicasToolStripMenuItem.Name) Then
                            Me.VariablesZonasFisicasToolStripMenuItem.Enabled = True
                            Me.VariablesZonasFisicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ActualizarPropietarioActualYAnteriorToolStripMenuItem.Name) Then
                            Me.ActualizarPropietarioActualYAnteriorToolStripMenuItem.Enabled = True
                            Me.ActualizarPropietarioActualYAnteriorToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PlanoManzaneroToolStripMenuItem.Name) Then
                            Me.PlanoManzaneroToolStripMenuItem.Enabled = True
                            Me.PlanoManzaneroToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RutaPlanoManzaneroToolStripMenuItem.Name) Then
                            Me.RutaPlanoManzaneroToolStripMenuItem.Enabled = True
                            Me.RutaPlanoManzaneroToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CarpetasFotograficasToolStripMenuItem.Name) Then
                            Me.CarpetasFotograficasToolStripMenuItem.Enabled = True
                            Me.CarpetasFotograficasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RutaCarpetaFotograficaToolStripMenuItem.Name) Then
                            Me.RutaCarpetaFotograficaToolStripMenuItem.Enabled = True
                            Me.RutaCarpetaFotograficaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.DocumentosGeneralesToolStripMenuItem.Name) Then
                            Me.DocumentosGeneralesToolStripMenuItem.Enabled = True
                            Me.DocumentosGeneralesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaDocumentosGeneralesToolStripMenuItem.Name) Then
                            Me.ConsultaDocumentosGeneralesToolStripMenuItem.Enabled = True
                            Me.ConsultaDocumentosGeneralesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RutaDocumentosGeneralesToolStripMenuItem.Name) Then
                            Me.RutaDocumentosGeneralesToolStripMenuItem.Enabled = True
                            Me.RutaDocumentosGeneralesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CopiarYGenerarIndiceDeArchivosFotograficosToolStripMenuItem.Name) Then
                            Me.CopiarYGenerarIndiceDeArchivosFotograficosToolStripMenuItem.Enabled = True
                            Me.CopiarYGenerarIndiceDeArchivosFotograficosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AjusteDeImpuestoPredialToolStripMenuItem.Name) Then
                            Me.AjusteDeImpuestoPredialToolStripMenuItem.Enabled = True
                            Me.AjusteDeImpuestoPredialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClasificacionToolStripMenuItem.Name) Then
                            Me.ClasificacionToolStripMenuItem.Enabled = True
                            Me.ClasificacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MedioDeResepcionToolStripMenuItem.Name) Then
                            Me.MedioDeResepcionToolStripMenuItem.Enabled = True
                            Me.MedioDeResepcionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ResolucionDeAjusteToolStripMenuItem.Name) Then
                            Me.ResolucionDeAjusteToolStripMenuItem.Enabled = True
                            Me.ResolucionDeAjusteToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ComparativosDeLiquidacionToolStripMenuItem.Name) Then
                            Me.ComparativosDeLiquidacionToolStripMenuItem.Enabled = True
                            Me.ComparativosDeLiquidacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasPorRangosDeAreasToolStripMenuItem.Name) Then
                            Me.TarifasPorRangosDeAreasToolStripMenuItem.Enabled = True
                            Me.TarifasPorRangosDeAreasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClaseDeVersionToolStripMenuItem.Name) Then
                            Me.ClaseDeVersionToolStripMenuItem.Enabled = True
                            Me.ClaseDeVersionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CategoriaDePredioToolStripMenuItem.Name) Then
                            Me.CategoriaDePredioToolStripMenuItem.Enabled = True
                            Me.CategoriaDePredioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PlanoPredialCatastralToolStripMenuItem.Name) Then
                            Me.PlanoPredialCatastralToolStripMenuItem.Enabled = True
                            Me.PlanoPredialCatastralToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MovimientosGeograficosToolStripMenuItem.Name) Then
                            Me.MovimientosGeograficosToolStripMenuItem.Enabled = True
                            Me.MovimientosGeograficosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ControlDeComandosToolStripMenuItem.Name) Then
                            Me.ControlDeComandosToolStripMenuItem.Enabled = True
                            Me.ControlDeComandosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AsignarControlDeComandosToolStripMenuItem.Name) Then
                            Me.AsignarControlDeComandosToolStripMenuItem.Enabled = True
                            Me.AsignarControlDeComandosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FotografiaPorIdentificadorDeConstruccionToolStripMenuItem.Name) Then
                            Me.FotografiaPorIdentificadorDeConstruccionToolStripMenuItem.Enabled = True
                            Me.FotografiaPorIdentificadorDeConstruccionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AguasToolStripMenuItem.Name) Then
                            Me.AguasToolStripMenuItem.Enabled = True
                            Me.AguasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.AHTToolStripMenuItem.Name) Then
                            Me.AHTToolStripMenuItem.Enabled = True
                            Me.AHTToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RevisionDeAvaluoToolStripMenuItem.Name) Then
                            Me.RevisionDeAvaluoToolStripMenuItem.Enabled = True
                            Me.RevisionDeAvaluoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MaterialDeCampoPorFormularioToolStripMenuItem.Name) Then
                            Me.MaterialDeCampoPorFormularioToolStripMenuItem.Enabled = True
                            Me.MaterialDeCampoPorFormularioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FormularioToolStripMenuItem.Name) Then
                            Me.FormularioToolStripMenuItem.Enabled = True
                            Me.FormularioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MaterialDeCampoPorFormularioToolStripMenuItem.Name) Then
                            Me.MaterialDeCampoPorFormularioToolStripMenuItem.Enabled = True
                            Me.MaterialDeCampoPorFormularioToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RegistroDeMutacionToolStripMenuItem.Name) Then
                            Me.RegistroDeMutacionToolStripMenuItem.Enabled = True
                            Me.RegistroDeMutacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.GenerarRegistroDeMutacionesToolStripMenuItem.Name) Then
                            Me.GenerarRegistroDeMutacionesToolStripMenuItem.Enabled = True
                            Me.GenerarRegistroDeMutacionesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.DivisionToolStripMenuItem.Name) Then
                            Me.DivisionToolStripMenuItem.Enabled = True
                            Me.DivisionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MedioDeNotificacionToolStripMenuItem.Name) Then
                            Me.MedioDeNotificacionToolStripMenuItem.Enabled = True
                            Me.MedioDeNotificacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.LibroRadicadorToolStripMenuItem.Name) Then
                            Me.LibroRadicadorToolStripMenuItem.Enabled = True
                            Me.LibroRadicadorToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.BitacoraDeMovimientosToolStripMenuItem.Name) Then
                            Me.BitacoraDeMovimientosToolStripMenuItem.Enabled = True
                            Me.BitacoraDeMovimientosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MovimientoAlfanumericoToolStripMenuItem.Name) Then
                            Me.MovimientoAlfanumericoToolStripMenuItem.Enabled = True
                            Me.MovimientoAlfanumericoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaTrabajoDeCampoToolStripMenuItem.Name) Then
                            Me.ConsultaTrabajoDeCampoToolStripMenuItem.Enabled = True
                            Me.ConsultaTrabajoDeCampoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RadicacionToolStripMenuItem.Name) Then
                            Me.RadicacionToolStripMenuItem.Enabled = True
                            Me.RadicacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClaseDeEntidadToolStripMenuItem.Name) Then
                            Me.ClaseDeEntidadToolStripMenuItem.Enabled = True
                            Me.ClaseDeEntidadToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ResolucionesYLicenciasToolStripMenuItem.Name) Then
                            Me.ResolucionesYLicenciasToolStripMenuItem.Enabled = True
                            Me.ResolucionesYLicenciasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PlaneacionToolStripMenuItem.Name) Then
                            Me.PlaneacionToolStripMenuItem.Enabled = True
                            Me.PlaneacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.BitacoraDeRadicadosToolStripMenuItem.Name) Then
                            Me.BitacoraDeRadicadosToolStripMenuItem.Enabled = True
                            Me.BitacoraDeRadicadosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ConsultaPlanoCartograficoToolStripMenuItem.Name) Then
                            Me.ConsultaPlanoCartograficoToolStripMenuItem.Enabled = True
                            Me.ConsultaPlanoCartograficoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.PlanoCartograficoToolStripMenuItem.Name) Then
                            Me.PlanoCartograficoToolStripMenuItem.Enabled = True
                            Me.PlanoCartograficoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RutaPlanoCartograficoToolStripMenuItem.Name) Then
                            Me.RutaPlanoCartograficoToolStripMenuItem.Enabled = True
                            Me.RutaPlanoCartograficoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TarifasPorZonasFisicasToolStripMenuItem.Name) Then
                            Me.TarifasPorZonasFisicasToolStripMenuItem.Enabled = True
                            Me.TarifasPorZonasFisicasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ResolucionDeConservacionToolStripMenuItem.Name) Then
                            Me.ResolucionDeConservacionToolStripMenuItem.Enabled = True
                            Me.ResolucionDeConservacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.SalariosMinimosMensualesLegalesVigentesToolStripMenuItem.Name) Then
                            Me.SalariosMinimosMensualesLegalesVigentesToolStripMenuItem.Enabled = True
                            Me.SalariosMinimosMensualesLegalesVigentesToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoObligacionesUrbanisticasToolStripMenuItem.Name) Then
                            Me.MantenimientoObligacionesUrbanisticasToolStripMenuItem.Enabled = True
                            Me.MantenimientoObligacionesUrbanisticasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CirculoRegistralMunicipalToolStripMenuItem.Name) Then
                            Me.CirculoRegistralMunicipalToolStripMenuItem.Enabled = True
                            Me.CirculoRegistralMunicipalToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClaseDeObligacionUrbanisticaToolStripMenuItem.Name) Then
                            Me.ClaseDeObligacionUrbanisticaToolStripMenuItem.Enabled = True
                            Me.ClaseDeObligacionUrbanisticaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.TipoDeLiquidacionToolStripMenuItem.Name) Then
                            Me.TipoDeLiquidacionToolStripMenuItem.Enabled = True
                            Me.TipoDeLiquidacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CesionesEspacioPublicoToolStripMenuItem.Name) Then
                            Me.CesionesEspacioPublicoToolStripMenuItem.Enabled = True
                            Me.CesionesEspacioPublicoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CesionesEquipamientoToolStripMenuItem.Name) Then
                            Me.CesionesEquipamientoToolStripMenuItem.Enabled = True
                            Me.CesionesEquipamientoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.DensidadToolStripMenuItem.Name) Then
                            Me.DensidadToolStripMenuItem.Enabled = True
                            Me.DensidadToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ObligacionesUrbanisticasToolStripMenuItem.Name) Then
                            Me.ObligacionesUrbanisticasToolStripMenuItem.Enabled = True
                            Me.ObligacionesUrbanisticasToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ClaseDeEntidadMunicipalToolStripMenuItem.Name) Then
                            Me.ClaseDeEntidadMunicipalToolStripMenuItem.Enabled = True
                            Me.ClaseDeEntidadMunicipalToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ZonaDePlanificacionToolStripMenuItem.Name) Then
                            Me.ZonaDePlanificacionToolStripMenuItem.Enabled = True
                            Me.ZonaDePlanificacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ZonaDePanificacionPorBarriosToolStripMenuItem.Name) Then
                            Me.ZonaDePanificacionPorBarriosToolStripMenuItem.Enabled = True
                            Me.ZonaDePanificacionPorBarriosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CertificacionDeEstratoToolStripMenuItem.Name) Then
                            Me.CertificacionDeEstratoToolStripMenuItem.Enabled = True
                            Me.CertificacionDeEstratoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoProyectoSocioeconomicoToolStripMenuItem1.Name) Then
                            Me.MantenimientoProyectoSocioeconomicoToolStripMenuItem1.Enabled = True
                            Me.MantenimientoProyectoSocioeconomicoToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoAsignacionDeEntidadToolStripMenuItem.Name) Then
                            Me.MantenimientoAsignacionDeEntidadToolStripMenuItem.Enabled = True
                            Me.MantenimientoAsignacionDeEntidadToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoUbicacionDeViviendaToolStripMenuItem.Name) Then
                            Me.MantenimientoUbicacionDeViviendaToolStripMenuItem.Enabled = True
                            Me.MantenimientoUbicacionDeViviendaToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MantenimientoCertificacionDeDeEstratoToolStripMenuItem.Name) Then
                            Me.MantenimientoCertificacionDeDeEstratoToolStripMenuItem.Enabled = True
                            Me.MantenimientoCertificacionDeDeEstratoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CertificacionDeEstratoToolStripMenuItem.Name) Then
                            Me.CertificacionDeEstratoToolStripMenuItem.Enabled = True
                            Me.CertificacionDeEstratoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ServiciosPublicosToolStripMenuItem.Name) Then
                            Me.ServiciosPublicosToolStripMenuItem.Enabled = True
                            Me.ServiciosPublicosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ProyectoDelPlanParcialToolStripMenuItem.Name) Then
                            Me.ProyectoDelPlanParcialToolStripMenuItem.Enabled = True
                            Me.ProyectoDelPlanParcialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CargasYBeneficiosDelPlanParcialToolStripMenuItem.Name) Then
                            Me.CargasYBeneficiosDelPlanParcialToolStripMenuItem.Enabled = True
                            Me.CargasYBeneficiosDelPlanParcialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FormaDePagoToolStripMenuItem.Name) Then
                            Me.FormaDePagoToolStripMenuItem.Enabled = True
                            Me.FormaDePagoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ControlFormaDePagoToolStripMenuItem.Name) Then
                            Me.ControlFormaDePagoToolStripMenuItem.Enabled = True
                            Me.ControlFormaDePagoToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.UnidadesDeActuacionDelPlanParcialToolStripMenuItem.Name) Then
                            Me.UnidadesDeActuacionDelPlanParcialToolStripMenuItem.Enabled = True
                            Me.UnidadesDeActuacionDelPlanParcialToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.CargasYBeneficiosPorUnidadesDeActuacionToolStripMenuItem.Name) Then
                            Me.CargasYBeneficiosPorUnidadesDeActuacionToolStripMenuItem.Enabled = True
                            Me.CargasYBeneficiosPorUnidadesDeActuacionToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ContribuyenteToolStripMenuItem.Name) Then
                            Me.ContribuyenteToolStripMenuItem.Enabled = True
                            Me.ContribuyenteToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FichaPredialDigitalToolStripMenuItem.Name) Then
                            Me.FichaPredialDigitalToolStripMenuItem.Enabled = True
                            Me.FichaPredialDigitalToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.RutaFichaPredialDigitalToolStripMenuItem.Name) Then
                            Me.RutaFichaPredialDigitalToolStripMenuItem.Enabled = True
                            Me.RutaFichaPredialDigitalToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FichaPredialDigitalToolStripMenuItem1.Name) Then
                            Me.FichaPredialDigitalToolStripMenuItem1.Enabled = True
                            Me.FichaPredialDigitalToolStripMenuItem1.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.MutacionesPrimeraClaseToolStripMenuItem.Name) Then
                            Me.MutacionesPrimeraClaseToolStripMenuItem.Enabled = True
                            Me.MutacionesPrimeraClaseToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.NovedadToolStripMenuItem.Name) Then
                            Me.NovedadToolStripMenuItem.Enabled = True
                            Me.NovedadToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.FideicomisosToolStripMenuItem.Name) Then
                            Me.FideicomisosToolStripMenuItem.Enabled = True
                            Me.FideicomisosToolStripMenuItem.Visible = True

                        ElseIf Trim(stEtiquetaAdmin) = Trim(Me.ResolucionAdministrativaToolStripMenuItem.Name) Then
                            Me.ResolucionAdministrativaToolStripMenuItem.Enabled = True
                            Me.ResolucionAdministrativaToolStripMenuItem.Visible = True


                        End If
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub TerceroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerceroToolStripMenuItem.Click
        '*** TERCERO ***

        Dim tercero As frm_TERCERO = frm_TERCERO.instance
        tercero.MdiParent = Me
        tercero.Show()

    End Sub
    Private Sub TerminarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerminarToolStripMenuItem.Click
        '*** TERMINA EL SISTEMA GLOBALMENTE ***

        Global.System.Windows.Forms.Application.Exit()

    End Sub
    Private Sub EstadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoToolStripMenuItem.Click
        '*** MANTENIMIENTO DE ESTADO ***

        Dim estado As frm_ESTADO = frm_ESTADO.instance
        estado.MdiParent = Me
        estado.Show()

    End Sub
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Cierre todos los formularios secundarios del primario.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private Sub ClaseOSectorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseOSectorToolStripMenuItem.Click
        Dim claseosector As frm_CLASSECT = frm_CLASSECT.instance
        claseosector.MdiParent = Me
        claseosector.Show()

    End Sub
    Private Sub CalidadDePropietarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalidadDepropietarioToolStripMenuItem.Click
        Dim CalidadPropietario As frm_CALIPROP = frm_CALIPROP.instance
        CalidadPropietario.MdiParent = Me
        CalidadPropietario.Show()

    End Sub
    Private Sub CategoriaDeSueloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriaDeSueloToolStripMenuItem.Click
        Dim CategoriaSuelo As frm_CATESUEL = frm_CATESUEL.instance
        CategoriaSuelo.MdiParent = Me
        CategoriaSuelo.Show()

    End Sub
    Private Sub DestinaciónEconómicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinacioneconomicaToolStripMenuItem.Click
        Dim DestinacionEconomica As frm_DESTECON = frm_DESTECON.instance
        DestinacionEconomica.MdiParent = Me
        DestinacionEconomica.Show()

    End Sub
    Private Sub TipoDeDocumentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeDocumentoToolStripMenuItem.Click
        Dim TipoDocumento As frm_TIPODOCU = frm_TIPODOCU.instance
        TipoDocumento.MdiParent = Me
        TipoDocumento.Show()

    End Sub
    Private Sub CaracteriticaPredioToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaracteristicaDePredioToolStripMenuItem.Click
        Dim CaracteristicaPredio As frm_CARAPRED = frm_CARAPRED.instance
        CaracteristicaPredio.MdiParent = Me
        CaracteristicaPredio.Show()
    End Sub
    Private Sub ClaseDeConstrucciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseDeConstruccionToolStripMenuItem.Click
        Dim ClaseConstruccion As frm_CLASCONS = frm_CLASCONS.instance
        ClaseConstruccion.MdiParent = Me
        ClaseConstruccion.Show()

    End Sub
    Private Sub DepartamentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartamentoToolStripMenuItem.Click
        Dim Departamento As frm_DEPARTAMENTO = frm_DEPARTAMENTO.instance
        Departamento.MdiParent = Me
        Departamento.Show()

    End Sub
    Private Sub ModoDeAdquisiciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModoDeAdquisicionToolStripMenuItem.Click
        Dim ModoAdquisicion As frm_MODOADQU = frm_MODOADQU.instance
        ModoAdquisicion.MdiParent = Me
        ModoAdquisicion.Show()

    End Sub
    Private Sub MunicipioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MunicipioToolStripMenuItem.Click
        Dim Municipio As frm_MUNICIPIO = frm_MUNICIPIO.instance
        Municipio.MdiParent = Me
        Municipio.Show()

    End Sub
    Private Sub NotariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotariaToolStripMenuItem.Click
        Dim Notaria As frm_NOTARIA = frm_NOTARIA.instance
        Notaria.MdiParent = Me
        Notaria.Show()

    End Sub
    Private Sub SexoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SexoToolStripMenuItem.Click
        Dim Sexo As frm_SEXO = frm_SEXO.instance
        Sexo.MdiParent = Me
        Sexo.Show()

    End Sub
    Private Sub TipoDeConstruccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeConstruccionToolStripMenuItem.Click
        Dim TipoConstruccion As frm_TIPOCONS = frm_TIPOCONS.instance
        TipoConstruccion.MdiParent = Me
        TipoConstruccion.Show()

    End Sub
    Private Sub VigenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VigenciaToolStripMenuItem.Click
        Dim Vigencia As frm_MANT_VIGENCIA = frm_MANT_VIGENCIA.instance
        Vigencia.MdiParent = Me
        Vigencia.Show()

    End Sub
    Private Sub ZonaEconómicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZonasEconomicasToolStripMenuItem.Click
        Dim ZonaEconomica As frm_ZONAECON = frm_ZONAECON.instance
        ZonaEconomica.MdiParent = Me
        ZonaEconomica.Show()

    End Sub
    Private Sub ZonaFísicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZonasFisicasToolStripMenuItem.Click
        Dim ZonaFisica As frm_ZONAFISI = frm_ZONAFISI.instance
        ZonaFisica.MdiParent = Me
        ZonaFisica.Show()


    End Sub
    Private Sub ManualesDeCatastroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualesDeCatastroToolStripMenuItem.Click
        Dim ManualesCatastro As frm_MANUCATA = frm_MANUCATA.instance
        ManualesCatastro.MdiParent = Me
        ManualesCatastro.Show()

    End Sub
    Private Sub TablasDemantenimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoDeTablasToolStripMenuItem1.Click
        Dim ListaValoresMantenimiento As frm_LIVAMANT = frm_LIVAMANT.instance
        ListaValoresMantenimiento.MdiParent = Me
        ListaValoresMantenimiento.Show()

    End Sub
    Private Sub PermisosAUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PermisosAUsuariosToolStripMenuItem.Click
        Dim ListaValoresSistemas As frm_PERMUSUA = frm_PERMUSUA.instance
        ListaValoresSistemas.MdiParent = Me
        ListaValoresSistemas.Show()
    End Sub
    Private Sub TipoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoToolStripMenuItem.Click
        Dim TipoResolucion As frm_TIPORESO = frm_TIPORESO.instance
        TipoResolucion.MdiParent = Me
        TipoResolucion.Show()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim AcercaDe As frm_ACERCA_DE = frm_ACERCA_DE.instance
        AcercaDe.MdiParent = Me
        AcercaDe.Show()

    End Sub
    Private Sub BarraDeHerramientasFichaPredialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarraDeHerramientasFichaPredialToolStripMenuItem.Click
        ToolStrip_Diligenciar.Visible = Me.BarraDeHerramientasFichaPredialToolStripMenuItem.Checked

    End Sub
    Private Sub tsTercero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTercero.Click
        '*** TERCERO ***

        Dim tercero As frm_TERCERO = frm_TERCERO.instance
        tercero.MdiParent = Me
        tercero.Show()
    End Sub
    Private Sub UsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuarioToolStripMenuItem.Click
        '*** USUARIO ***

        Dim usuario As frm_USUARIO = frm_USUARIO.instance
        usuario.MdiParent = Me
        usuario.Show()
    End Sub
    Private Sub FichapredialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichapredialToolStripMenuItem.Click
        '*** FICHA PREDIAL ***

        Dim FichaPredial As frm_FICHPRED = frm_FICHPRED.instance
        FichaPredial.MdiParent = Me
        FichaPredial.Show()
    End Sub
    Private Sub tsFichaPredial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFichaPredial.Click
        '*** FICHA PREDIAL ***

        Dim FichaPredial As frm_FICHPRED = frm_FICHPRED.instance
        FichaPredial.MdiParent = Me
        FichaPredial.Show()
    End Sub
    Private Sub tsFichaResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsFichaResumen.Click
        '*** FICHA RESUMEN ***

        Dim FichaResumen As frm_FICHRESU = frm_FICHRESU.instance
        FichaResumen.MdiParent = Me
        FichaResumen.Show()
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub mdi_CONTENEDOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            '============================================
            '*** LLAMA AL FORMULARIO LOGIN DE USUARIO ***
            '============================================
            frm_Login.ShowDialog()

            '============================================================================
            '*** CONFIGURA EL PERMISOS DE USUARIO PARA MOSTRAR LAS ETIQUETAS DEL MENU ***
            '============================================================================
            pro_PermisoUsuarioEtiquetaMenuContenedor()

            '========================================================
            '*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
            '========================================================
            Dim MyIdentity As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim MyPrincipal As New WindowsPrincipal(MyIdentity)

            Me.strBARRESTA.Items(2).Text = MyPrincipal.Identity.Name.ToString.ToUpper & " - " & vp_stConeccion

            ' procedimiento para asignar permiso de sub etiquetas
            pro_PermisoUsuarioSubEtiquetasMenuContenedor()

        Catch ex As Exception
            MessageBox.Show("No existe conexión a la base de datos")
        End Try

        Try
            '=======================================
            '*** INGRESA LOS ESTADOS REGISTRADOS ***
            '=======================================

            Dim objdatos As New cla_ESTADO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_ESTADO

            If tbl.Rows.Count = 0 Then
                Dim objdatos1 As New cla_LIVASIST
                objdatos1.fun_Actualizar_ListaDeValores_ESTADO()
            End If

            '==============================================================
            '*** INGRESA EL USUARIO DE ADMINISTRADOR, PERFIL DE USUARIO ***
            '==============================================================

            Dim objdatos2 As New cla_CONTRASENA
            Dim tbl2 As New DataTable
            Dim admin As String = "ADMINISTRADOR"

            tbl2 = objdatos2.fun_Buscar_USUARIO_CONTRASENA(admin)

            If tbl2.Rows.Count = 0 Then
                Dim objdatos3 As New cla_LIVASIST
                objdatos3.fun_Insertar_Administrador()
            End If

            '=================================================
            '*** INGRESA LAS ETIQUETAS DEL MENU CONTENEDOR ***
            '=================================================

            Dim objdatos4 As New cla_MENUCONT
            Dim tbl4 As New DataTable

            tbl4 = objdatos4.fun_Consultar_MANT_MENUCONT()

            If tbl4.Rows.Count = 0 Then
                Dim objdatos5 As New cla_LIVASIST
                objdatos5.fun_Actualizar_ListaDeValores_ETIQUETAS_MENU_CONTENEDOR()
            End If

            '===================================================
            '*** INGRESA LOS FORMULARIOS DEL MENU CONTENEDOR ***
            '===================================================

            Dim objdatos44 As New cla_PERMFORM
            Dim tbl44 As New DataTable

            tbl44 = objdatos44.fun_Consultar_PERMFORM

            If tbl44.Rows.Count = 0 Then
                Dim objdatos3 As New cla_LIVASIST
                objdatos3.fun_Actualizar_ListaDeValores_FORMULARIO()

            End If

            '=================================================
            '*** INGRESA LAS ETIQUETAS DEL MENU CONTENEDOR ***
            '=================================================

            Dim objdatos45 As New cla_PERMETIQ
            Dim tbl45 As New DataTable

            tbl45 = objdatos45.fun_Consultar_PERMETIQ

            If tbl44.Rows.Count = 0 Then
                Dim objdatos3 As New cla_LIVASIST
                objdatos3.fun_Actualizar_ListaDeValores_ETIQUETAS()

            End If

        Catch ex As Exception
            MessageBox.Show("No existe conexión a la base de datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub Tim_FECHA_HORA_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tim_FECHA_HORA.Tick
        '=========================================================
        '*** INSTANCIA QUE INFORMA LA FECHA Y HORA DEL SISTEMA ***
        '=========================================================
        Dim dateNow As DateTime = DateTime.Now

        Me.strBARRESTA.Items(3).Text = DateTime.Now.ToString & " - semana: " & DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) & " - dia: " & dateNow.DayOfYear.ToString

    End Sub
    Private Sub BarraDeestadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarraDeestadoToolStripMenuItem.Click
        '================================
        '*** AVILITAR BARRA DE ESTADO ***
        '================================

        strBARRESTA.Visible = Me.BarraDeestadoToolStripMenuItem.Checked

        If BarraDeestadoToolStripMenuItem.Checked = True Then
            BarraDeHerramientaDiligenciarToolStripMenuItem.Checked = True
        Else
            BarraDeHerramientaDiligenciarToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub PerfilDeUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PerfilDeUsuarioToolStripMenuItem.Click

        Dim Contrasena As frm_CONTRASENA = frm_CONTRASENA.instance
        Contrasena.MdiParent = Me
        Contrasena.Show()

    End Sub
    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        If MessageBox.Show("¿ Desea cerrar la sesión ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

            '================================
            ' oculta la barras del contenedor
            '================================
            MenuStrip.Visible = False
            ToolStrip_Diligenciar.Visible = False
            strBARRESTA.Visible = False

            '=================================
            ' Limpia los campos del contenedor
            '=================================
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
            vp_usuario = ""
            vp_nombres = ""

            '=======================================================
            ' Cierre todos los formularios secundarios del primario.
            '=======================================================

            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next

            '=============================
            ' LLAMA EL FORMULARIO DE LOGIN
            '=============================
            frm_Login.ShowDialog()

            '============================================================================
            '*** CONFIGURA EL PERMISOS DE USUARIO PARA MOSTRAR LAS ETIQUETAS DEL MENU ***
            '============================================================================
            pro_PermisoUsuarioEtiquetaMenuContenedor()
            pro_PermisoUsuarioSubEtiquetasMenuContenedor()

        End If

    End Sub
    Private Sub CambioDeClaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioDeClaveToolStripMenuItem.Click
        '===========================================================================================
        '*** CAMBIO DE CALVE DEL USUARIO CON BUSQUEDA DE ID PARA ENVIAR AL FORMULARIO CONTRASEÑA ***
        '===========================================================================================

        Try
            Dim objdatos As New cla_CONTRASENA
            Dim tbl_usuario As New DataTable

            '*** BUSCA EL USUARIO ***
            tbl_usuario = objdatos.fun_Buscar_USUARIO_CONTRASENA(strBARRESTA.Items(0).Text)

            '*** SE OBTIENE EL ID DEL USUARIO ***
            Dim id As Integer = Trim(tbl_usuario.Rows(0).Item(0))
            Dim frm_modificar_CONTRASENA As New frm_modificar_CONTRASENA(Integer.Parse(id))
            frm_modificar_CONTRASENA.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub PlanosterceroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanosTerceroToolStripMenuItem.Click
        Dim PlanosTercero As frm_planos_TERCERO = frm_planos_TERCERO.instance
        PlanosTercero.MdiParent = Me
        PlanosTercero.Show()

    End Sub
    Private Sub BarraDeHerramientaDiligenciarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarraDeHerramientaDiligenciarToolStripMenuItem.Click
        '=======================================================================
        '*** EJECUTA LA BARRA DE ESTADO DESDE EL MENU CONTEXTUAL DEL DEL MDI ***
        '=======================================================================

        strBARRESTA.Visible = Me.BarraDeHerramientaDiligenciarToolStripMenuItem.Checked

        If BarraDeHerramientaDiligenciarToolStripMenuItem.Checked = True Then
            BarraDeestadoToolStripMenuItem.Checked = False
        Else
            BarraDeestadoToolStripMenuItem.Checked = True
        End If

        Call BarraDeestadoToolStripMenuItem_Click(BarraDeestadoToolStripMenuItem, New System.EventArgs)

    End Sub
    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        '===========================================================================
        '*** EJECUTA EL FORMULARIO ACERCE DE ...DESDE EL MENU CONTEXTUAL DEL MDI ***
        '===========================================================================

        Dim AcercaDe As frm_ACERCA_DE = frm_ACERCA_DE.instance
        AcercaDe.MdiParent = Me
        AcercaDe.Show()

    End Sub
    Private Sub HongosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HongosToolStripMenuItem.Click
        '=========================================================
        '*** SELECCIONA LAS IMAGENES DE LOS RECURSOS DE SICAFI ***
        '=========================================================

        Me.BackgroundImage = My.Resources.Resources.Dibujo2

    End Sub
    Private Sub CubosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CubosToolStripMenuItem.Click
        '=========================================================
        '*** SELECCIONA LAS IMAGENES DE LOS RECURSOS DE SICAFI ***
        '=========================================================

        Me.BackgroundImage = My.Resources.Resources.Dibujo1
    End Sub
    Private Sub ImportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem.Click
        '=============================================
        '*** IMPORTA LA IMAGEN PARA EL PAPEL TAPIZ ***
        '=============================================

        Dim oLeer As New OpenFileDialog

        Try
            oLeer.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            'oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de imagen (*.jpg)|*.jpg|Archivo de imagen (*.bmp)|*.bmp" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.jpg
            oLeer.ShowDialog() 'abre la caja de dialogo para guardar


            If Trim(oLeer.FileName) <> "" Then
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer
                RutaImagenPapelTapiz = oLeer.FileName
            End If

            If Trim(RutaImagenPapelTapiz) <> "" Then
                FileClose(1)
                Me.BackgroundImage = Image.FromFile(RutaImagenPapelTapiz)
            End If


        Catch ex As Exception
            MsgBox(Err.Description & " " & "Ruta imagen")
        Finally
            FileClose(1)
        End Try


    End Sub
    Private Sub CalculadoraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculadoraToolStripMenuItem.Click
        '*** CALCULADORA ***

        Try
            Process.Start("c:\windows\system32\calc.exe")
        Catch ex As Exception

            MessageBox.Show("" & Err.Description & "", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        End Try
    End Sub
    Private Sub BlocDeNotasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlocDeNotasToolStripMenuItem.Click
        '*** BLOC DE NOTAS ***
        Try
            Process.Start("c:\windows\system32\notepad.exe")
        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub PaintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaintToolStripMenuItem.Click
        '*** PAINT ***
        Try
            Process.Start("c:\windows\system32\mspaint.exe")
        Catch ex As Exception
            MessageBox.Show("" & Err.Description & "", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub TerminarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerminarToolStripMenuItem1.Click
        '*** TERMINA EL SISTEMA GLOBALMENTE ***

        Global.System.Windows.Forms.Application.Exit()
    End Sub
    Private Sub FondoToolStripMenuItem_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FondoToolStripMenuItem.MouseMove
        '===========================================================
        '*** AVILITA LA OPCIÓN IMPORTAR AL USUARIO ADMINISTRADOR ***
        '===========================================================

        If vp_usuario = "ADMINISTRADOR" Then
            ImportarToolStripMenuItem.Enabled = True
        Else
            ImportarToolStripMenuItem.Enabled = False
        End If

    End Sub
    Private Sub CascadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadaToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub MosaicoverticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MosaicoverticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub MosaicohorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MosaicohorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub CerrartodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrartodoToolStripMenuItem.Click
        ' Cierre todos los formularios secundarios del primario.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub TipoDeCalificacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeCalificacionToolStripMenuItem.Click
        Dim TipoCalificacion As frm_TIPOCALI = frm_TIPOCALI.instance
        TipoCalificacion.MdiParent = Me
        TipoCalificacion.Show()
    End Sub
    Private Sub PuntoCardinalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PuntoCardinalToolStripMenuItem.Click
        Dim PuntoCardinal As frm_PUNTCARD = frm_PUNTCARD.instance
        PuntoCardinal.MdiParent = Me
        PuntoCardinal.Show()
    End Sub
    Private Sub CódigoDeCalificaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodigoDeCalificacionToolStripMenuItem.Click
        Dim CodigoCalificacion As frm_CODICALI = frm_CODICALI.instance
        CodigoCalificacion.MdiParent = Me
        CodigoCalificacion.Show()
    End Sub
    Private Sub BloquearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BloquearToolStripMenuItem.Click
        frm_Login.ShowDialog()
    End Sub
    Private Sub ResoluciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResolucionToolStripMenuItem.Click
        Dim Resolucion As frm_RESOLUCION = frm_RESOLUCION.instance
        Resolucion.MdiParent = Me
        Resolucion.Show()
    End Sub
    Private Sub PropiedadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem.Click
        Dim Propiedades As frm_PROPIEDADES = frm_PROPIEDADES.instance
        Propiedades.MdiParent = Me
        Propiedades.Show()
    End Sub
    Private Sub ConsultaSQLServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaSQLServerToolStripMenuItem.Click
        Dim ConsultaSQL As frm_CONSULTA_SQL = frm_CONSULTA_SQL.instance
        ConsultaSQL.MdiParent = Me
        ConsultaSQL.Show()
    End Sub
    Private Sub AreaDeTerrenoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaAreaDeTerrenoToolStripMenuItem.Click
        Dim AreasDeTerrenoFichaPredial As frm_consulta_area_terreno_FICHPRED = frm_consulta_area_terreno_FICHPRED.instance
        AreasDeTerrenoFichaPredial.MdiParent = Me
        AreasDeTerrenoFichaPredial.Show()
    End Sub
    Private Sub CoeficientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaCoeficientesToolStripMenuItem.Click
        Dim CoeficientesFichaPredial As frm_consulta_coeficientes_FICHPRED = frm_consulta_coeficientes_FICHPRED.instance
        CoeficientesFichaPredial.MdiParent = Me
        CoeficientesFichaPredial.Show()
    End Sub
    Private Sub PropietarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaPropietarioToolStripMenuItem.Click
        Dim PropietarioFichaPredial As frm_consulta_propietario_FIPRPROP = frm_consulta_propietario_FIPRPROP.instance
        PropietarioFichaPredial.MdiParent = Me
        PropietarioFichaPredial.Show()
    End Sub
    Private Sub ConstruccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaConstruccionToolStripMenuItem.Click
        Dim ConstruccionFichaPredial As frm_consulta_construccion_FIPRCONS = frm_consulta_construccion_FIPRCONS.instance
        ConstruccionFichaPredial.MdiParent = Me
        ConstruccionFichaPredial.Show()
    End Sub
    Private Sub ValidarFichaPredialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValidarFichaPredialToolStripMenuItem.Click
        Dim ValidarFichaPredial As frm_reporte_Inconsistencias_Ficha_Predial = frm_reporte_Inconsistencias_Ficha_Predial.instance
        ValidarFichaPredial.MdiParent = Me
        ValidarFichaPredial.Show()
    End Sub
    Private Sub DestinacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDestinacionToolStripMenuItem.Click
        Dim Destinacion As frm_consulta_destinacion_FIPRDEEC = frm_consulta_destinacion_FIPRDEEC.instance
        Destinacion.MdiParent = Me
        Destinacion.Show()
    End Sub
    Private Sub ZonasEconomicasYFisicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaZonasEconomicasYFisicasToolStripMenuItem.Click
        Dim ZonasEconomicasYFisicas As frm_consulta_zonas_FIPRZOEC = frm_consulta_zonas_FIPRZOEC.instance
        ZonasEconomicasYFisicas.MdiParent = Me
        ZonasEconomicasYFisicas.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarFichaToolStripMenuItem1.Click
        Dim ImportarDatos As frm_importar_planos_FICHA_PREDIAL = frm_importar_planos_FICHA_PREDIAL.instance
        ImportarDatos.MdiParent = Me
        ImportarDatos.Show()
    End Sub
    Private Sub ExportarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarFichaToolStripMenuItem.Click
        Dim ExportarDatos As frm_exportar_planos_FICHA_PREDIAL = frm_exportar_planos_FICHA_PREDIAL.instance
        ExportarDatos.MdiParent = Me
        ExportarDatos.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarZonasImportarFichaToolStripMenuItem2.Click
        Dim ImportarDatos As frm_importar_planos_ZONAS = frm_importar_planos_ZONAS.instance
        ImportarDatos.MdiParent = Me
        ImportarDatos.Show()
    End Sub
    Private Sub CruceFichaPredialVsPlanoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CruceFichaPredialVsPlanoToolStripMenuItem.Click
        Dim CruceFichaPredial As frm_Cruce_Ficha_Predial_vs_Plano = frm_Cruce_Ficha_Predial_vs_Plano.instance
        CruceFichaPredial.MdiParent = Me
        CruceFichaPredial.Show()
    End Sub
    Private Sub CrucePropietarioVsPlanoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrucePropietarioVsPlanoToolStripMenuItem.Click
        Dim CrucePropietario As frm_Cruce_Propietario_vs_Plano = frm_Cruce_Propietario_vs_Plano.instance
        CrucePropietario.MdiParent = Me
        CrucePropietario.Show()
    End Sub
    Private Sub FicharesumenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FicharesumenToolStripMenuItem.Click
        Dim frm_FICHRESU1 As frm_FICHRESU = frm_FICHRESU.instance
        frm_FICHRESU1.MdiParent = Me
        frm_FICHRESU1.Show()
    End Sub
    Private Sub RemplazaridentificadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemplazaridentificadoresToolStripMenuItem.Click
        Dim frm_Remplazaridentificadores As frm_Remplazar_Identificador_Construccion = frm_Remplazar_Identificador_Construccion.instance
        frm_Remplazaridentificadores.MdiParent = Me
        frm_Remplazaridentificadores.Show()
    End Sub
    Private Sub MarcarpredioComoConjutoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcarpredioComoConjutoToolStripMenuItem.Click
        Dim frm_MarcarPredioComoConjunto As frm_Marcar_Predio_Como_Conjunto = frm_Marcar_Predio_Como_Conjunto.instance
        frm_MarcarPredioComoConjunto.MdiParent = Me
        frm_MarcarPredioComoConjunto.Show()
    End Sub
    Private Sub AvaluosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvaluosToolStripMenuItem.Click
        Dim frm_ReporteAvaluo As frm_reporte_Avaluos_Ficha_Predial = frm_reporte_Avaluos_Ficha_Predial.instance
        frm_ReporteAvaluo.MdiParent = Me
        frm_ReporteAvaluo.Show()
    End Sub
    Private Sub TarifasPorDestinacionEconomicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasPorDestinacionEconomicasToolStripMenuItem.Click
        Dim frm_TarifasPorDestinacion As frm_TARIDEEC = frm_TARIDEEC.instance
        frm_TarifasPorDestinacion.MdiParent = Me
        frm_TarifasPorDestinacion.Show()
    End Sub
    Private Sub TarifasPorZonasEconomicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasPorZonasEconomicasToolStripMenuItem.Click
        Dim frm_TarifasPorZonas As frm_TARIZOEC = frm_TARIZOEC.instance
        frm_TarifasPorZonas.MdiParent = Me
        frm_TarifasPorZonas.Show()
    End Sub
    Private Sub ConceptoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptoToolStripMenuItem.Click
        Dim frm_Concepto As frm_CONCEPTO = frm_Concepto.instance
        frm_Concepto.MdiParent = Me
        frm_Concepto.Show()
    End Sub
    Private Sub AsignarFormularioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarFormularioToolStripMenuItem.Click
        Dim frm_MenuFormulario As frm_PERMFORM = frm_PERMFORM.instance
        frm_MenuFormulario.MdiParent = Me
        frm_MenuFormulario.Show()
    End Sub
    Private Sub AsignarEtiquetasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarEtiquetasToolStripMenuItem.Click
        Dim frm_PermisoEtiqueta As frm_PERMETIQ = frm_PERMETIQ.instance
        frm_PermisoEtiqueta.MdiParent = Me
        frm_PermisoEtiqueta.Show()
    End Sub
    Private Sub AsignarRolesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarRolesToolStripMenuItem1.Click
        Dim frm_PermisoRoles As frm_PERMROLE = frm_PERMROLE.instance
        frm_PermisoRoles.MdiParent = Me
        frm_PermisoRoles.Show()
    End Sub
    Private Sub PersonalizarMenuPrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonalizarMenuPrincipalToolStripMenuItem.Click
        Dim MenuContenedor As frm_MENUCONT = frm_MENUCONT.instance
        MenuContenedor.MdiParent = Me
        MenuContenedor.Show()
    End Sub
    Private Sub ImpuestoPredialToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpuestoPredialToolStripMenuItem1.Click
        Dim LiquidacionPredial As frm_reporte_Liquidacion_Impuesto_Predial = frm_reporte_Liquidacion_Impuesto_Predial.instance
        LiquidacionPredial.MdiParent = Me
        LiquidacionPredial.Show()
    End Sub
    Private Sub CruceMatriculasMunicipioVsRegistroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CruceMatriculasMunicipioVsRegistroToolStripMenuItem.Click
        Dim CruceMatriculaMunicipioVsRegistro As frm_Cruce_Matriculas_vs_Registro = frm_Cruce_Matriculas_vs_Registro.instance
        CruceMatriculaMunicipioVsRegistro.MdiParent = Me
        CruceMatriculaMunicipioVsRegistro.Show()
    End Sub
    Private Sub ActualizacionAreaDeTerrenoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizacionAreaDeTerrenoToolStripMenuItem.Click
        Dim o_Actualizar_Area_Terreno As frm_Actualizar_Area_Terreno = frm_Actualizar_Area_Terreno.instance
        o_Actualizar_Area_Terreno.MdiParent = Me
        o_Actualizar_Area_Terreno.Show()
    End Sub
    Private Sub ValidacionesEspecialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValidacionesEspecialesToolStripMenuItem.Click
        Dim o_ValidacionesEspeciales As frm_ValidacionesEspeciales = frm_ValidacionesEspeciales.instance
        o_ValidacionesEspeciales.MdiParent = Me
        o_ValidacionesEspeciales.Show()
    End Sub
    Private Sub ModoDeLiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModoDeLiquidacionToolStripMenuItem.Click
        Dim o_ModoLiqiquidacion As frm_MODOLIQU = frm_MODOLIQU.instance
        o_ModoLiqiquidacion.MdiParent = Me
        o_ModoLiqiquidacion.Show()
    End Sub
    Private Sub InsertarcartografiaPorLotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertarcartografiaPorLotesToolStripMenuItem.Click
        Dim o_CartografiaPorLotes As frm_Insertar_Cartografia_Por_Lotes = frm_Insertar_Cartografia_Por_Lotes.instance
        o_CartografiaPorLotes.MdiParent = Me
        o_CartografiaPorLotes.Show()
    End Sub
    Private Sub GenerarZonasExportarFichaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarZonasExportarFichaToolStripMenuItem2.Click
        Dim o_ExportarZonas As frm_exportar_planos_ZONAS = frm_exportar_planos_ZONAS.instance
        o_ExportarZonas.MdiParent = Me
        o_ExportarZonas.Show()
    End Sub
    Private Sub EstratoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstratoToolStripMenuItem.Click
        Dim o_Estrato As frm_ESTRATO = frm_ESTRATO.instance
        o_Estrato.MdiParent = Me
        o_Estrato.Show()
    End Sub
    Private Sub TipoDeAforoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeAforoToolStripMenuItem.Click
        Dim o_TipoDeAforo As frm_TIPOAFOR = frm_TIPOAFOR.instance
        o_TipoDeAforo.MdiParent = Me
        o_TipoDeAforo.Show()
    End Sub
    Private Sub PeriodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodoToolStripMenuItem.Click
        Dim o_Periodo As frm_PERIODO = frm_PERIODO.instance
        o_Periodo.MdiParent = Me
        o_Periodo.Show()
    End Sub
    Private Sub PeriodoDeActualizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodoDeActualizacionToolStripMenuItem.Click
        Dim o_VigenciaDeActualizacion As frm_VIGEACTU = frm_VIGEACTU.instance
        o_VigenciaDeActualizacion.MdiParent = Me
        o_VigenciaDeActualizacion.Show()
    End Sub
    Private Sub TarifasAlumbradoPublicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasAlumbradoPublicoToolStripMenuItem.Click
        Dim o_AlumbradoPublico As frm_TARIALPU = frm_TARIALPU.instance
        o_AlumbradoPublico.MdiParent = Me
        o_AlumbradoPublico.Show()
    End Sub
    Private Sub TarifasActividadBomberilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasActividadBomberilToolStripMenuItem.Click
        Dim o_TarifasActividadBomberil As frm_TARIACBO = frm_TARIACBO.instance
        o_TarifasActividadBomberil.MdiParent = Me
        o_TarifasActividadBomberil.Show()
    End Sub
    Private Sub RutasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutasToolStripMenuItem.Click
        Dim o_Rutas As frm_RUTAS = frm_RUTAS.instance
        o_Rutas.MdiParent = Me
        o_Rutas.Show()
    End Sub
    Private Sub ImagenDelPredioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenDelPredioToolStripMenuItem.Click
        Dim o_ConsultaImagenPredio As frm_consulta_imagen_predio_FICHPRED = frm_consulta_imagen_predio_FICHPRED.instance
        o_ConsultaImagenPredio.MdiParent = Me
        o_ConsultaImagenPredio.Show()
    End Sub
    Private Sub TarifasDePrediosEspecialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasDePrediosEspecialesToolStripMenuItem.Click
        Dim o_TarifaPrediosEspeciales As frm_TARIPRES = frm_TARIPRES.instance
        o_TarifaPrediosEspeciales.MdiParent = Me
        o_TarifaPrediosEspeciales.Show()
    End Sub
    Private Sub DestinacionEconomicaPorLotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinacionEconomicaPorLotesToolStripMenuItem.Click
        Dim o_DestinacionEconomicaPorLotes As frm_DEECLOTE = frm_DEECLOTE.instance
        o_DestinacionEconomicaPorLotes.MdiParent = Me
        o_DestinacionEconomicaPorLotes.Show()
    End Sub
    Private Sub TarifasPorLotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasPorLotesToolStripMenuItem.Click
        Dim o_TarifasPorLotes As frm_TARILOTE = frm_TARILOTE.instance
        o_TarifasPorLotes.MdiParent = Me
        o_TarifasPorLotes.Show()
    End Sub
    Private Sub PariodoActualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PariodoActualToolStripMenuItem.Click
        Dim o_PeriodoActual As frm_PERIACTU = frm_PERIACTU.instance
        o_PeriodoActual.MdiParent = Me
        o_PeriodoActual.Show()
    End Sub
    Private Sub ValidacionesRetiradasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValidacionesRetiradasToolStripMenuItem.Click
        Dim o_ValidacionesRetiradas As frm_VALIRETI = frm_VALIRETI.instance
        o_ValidacionesRetiradas.MdiParent = Me
        o_ValidacionesRetiradas.Show()
    End Sub
    Private Sub SujetoDeImpuestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SujetoDeImpuestoToolStripMenuItem.Click
        Dim o_SujetoImpuesto As frm_SUJEIMPU = frm_SUJEIMPU.instance
        o_SujetoImpuesto.MdiParent = Me
        o_SujetoImpuesto.Show()
    End Sub
    Private Sub TarifasPorRangosDeAvaluosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasPorRangosDeAvaluosToolStripMenuItem.Click
        Dim o_TarifasPorRangosDeAvaluos As frm_TARIRAAV = frm_TARIRAAV.instance
        o_TarifasPorRangosDeAvaluos.MdiParent = Me
        o_TarifasPorRangosDeAvaluos.Show()
    End Sub
    Private Sub FormulaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormulaToolStripMenuItem.Click
        Dim o_Formula As frm_FORMULA = frm_FORMULA.instance
        o_Formula.MdiParent = Me
        o_Formula.Show()
    End Sub
    Private Sub TipoDeImpuestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeImpuestoToolStripMenuItem.Click
        Dim o_TipoDeImpuesto As frm_TIPOIMPU = frm_TIPOIMPU.instance
        o_TipoDeImpuesto.MdiParent = Me
        o_TipoDeImpuesto.Show()
    End Sub
    Private Sub FormulaMunicipioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormulaMunicipioToolStripMenuItem.Click
        Dim o_FormulaMunicipio As frm_FORMMUNI = frm_FORMMUNI.instance
        o_FormulaMunicipio.MdiParent = Me
        o_FormulaMunicipio.Show()
    End Sub
    Private Sub CirculoDeRegistroToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CirculoDeRegistroToolStripMenuItem.Click
        Dim o_CirculoDeRegistro As frm_CIRCREGI = frm_CIRCREGI.instance
        o_CirculoDeRegistro.MdiParent = Me
        o_CirculoDeRegistro.Show()
    End Sub
    Private Sub CausaDelActoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CausaDelActoToolStripMenuItem.Click
        Dim o_CausaDelActo As frm_CAUSACTO = frm_CAUSACTO.instance
        o_CausaDelActo.MdiParent = Me
        o_CausaDelActo.Show()
    End Sub
    Private Sub PropietarioAnteriorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropietarioAnteriorToolStripMenuItem.Click
        Dim o_PropietarioAnterior As frm_PROPANTE = frm_PROPANTE.instance
        o_PropietarioAnterior.MdiParent = Me
        o_PropietarioAnterior.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarPropietarioAnteriorGeneracionToolStripMenuItem1.Click
        Dim o_ImportarExcelPropietarioAnterior As frm_importar_excel_PROPANTE = frm_importar_excel_PROPANTE.instance
        o_ImportarExcelPropietarioAnterior.MdiParent = Me
        o_ImportarExcelPropietarioAnterior.Show()
    End Sub
    Private Sub ConsultaPropietarioAnteriorToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaPropietarioAnteriorToolStripMenuItem2.Click
        Dim o_ConsultaPropietarioAnterior As frm_consulta_propietario_anterior_PROPANTE = frm_consulta_propietario_anterior_PROPANTE.instance
        o_ConsultaPropietarioAnterior.MdiParent = Me
        o_ConsultaPropietarioAnterior.Show()
    End Sub
    Private Sub CruceMatriculasMunicipioVsRegistroXlsMdbToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CruceMatriculasMunicipioVsRegistroXlsMdbToolStripMenuItem.Click
        Dim o_CruceMatriculasMunicipioRegistroXls As frm_Cruce_Matriculas_Municipio_vs_Registro_Xls_Mdb = frm_Cruce_Matriculas_Municipio_vs_Registro_Xls_Mdb.instance
        o_CruceMatriculasMunicipioRegistroXls.MdiParent = Me
        o_CruceMatriculasMunicipioRegistroXls.Show()
    End Sub
    Private Sub ImportarEstratoGeneracionToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarEstratoGeneracionToolStripMenuItem2.Click
        Dim o_ImportarExcelEstrato As frm_importar_excel_ESTRFIPR = frm_importar_excel_ESTRFIPR.instance
        o_ImportarExcelEstrato.MdiParent = Me
        o_ImportarExcelEstrato.Show()
    End Sub
    Private Sub ImportarAreaTerrenoGeneracionPlanoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarAreaTerrenoGeneracionPlanoToolStripMenuItem1.Click
        Dim o_ImportarExcelAreaTerreno As frm_importar_excel_AREATERR = frm_importar_excel_AREATERR.instance
        o_ImportarExcelAreaTerreno.MdiParent = Me
        o_ImportarExcelAreaTerreno.Show()
    End Sub
    Private Sub RangoDeAreaDeTerrenoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RangoDeAreaDeTerrenoToolStripMenuItem.Click
        Dim o_RangoAreaDeTerreno As frm_RANGARTE = frm_RANGARTE.instance
        o_RangoAreaDeTerreno.MdiParent = Me
        o_RangoAreaDeTerreno.Show()
    End Sub
    Private Sub CruceÁreasDeTerrenoBdVsShapeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CruceÁreasDeTerrenoBdVsShapeToolStripMenuItem.Click
        Dim o_CruceAreasTerreno As frm_Cruce_Areas_Terreno_DB_vs_Cartografia = frm_Cruce_Areas_Terreno_DB_vs_Cartografia.instance
        o_CruceAreasTerreno.MdiParent = Me
        o_CruceAreasTerreno.Show()
    End Sub
    Private Sub LiquidaHistoricoDeAvaluoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidaHistoricoDeAvaluoToolStripMenuItem.Click
        Dim o_LiquidaHistoricoAvaluo As frm_Liquida_Historico_Avaluo_HISTAVAL = frm_Liquida_Historico_Avaluo_HISTAVAL.instance
        o_LiquidaHistoricoAvaluo.MdiParent = Me
        o_LiquidaHistoricoAvaluo.Show()
    End Sub
    Private Sub LiquidaHistoricoDeLiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidaHistoricoDeLiquidacionToolStripMenuItem.Click
        Dim o_LiquidaHistoricoLiquidacion As frm_Liquida_Historico_Liquidacion_HISTLIQU = frm_Liquida_Historico_Liquidacion_HISTLIQU.instance
        o_LiquidaHistoricoLiquidacion.MdiParent = Me
        o_LiquidaHistoricoLiquidacion.Show()
    End Sub
    Private Sub IncrementoDeAvaluoPorDestinacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncrementoDeAvaluoPorDestinacionToolStripMenuItem.Click
        Dim o_IncrementoPorDestinacion As frm_INAVDEEC = frm_INAVDEEC.instance
        o_IncrementoPorDestinacion.MdiParent = Me
        o_IncrementoPorDestinacion.Show()
    End Sub
    Private Sub HistoricoDeZonaEconomicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoricoDeZonaEconomicasToolStripMenuItem.Click
        Dim o_HistoricoDeZonas As frm_Historico_Zonas_HISTZONA = frm_Historico_Zonas_HISTZONA.instance
        o_HistoricoDeZonas.MdiParent = Me
        o_HistoricoDeZonas.Show()
    End Sub
    Private Sub MaterialDeCampoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialDeCampoToolStripMenuItem.Click
        Dim o_MaterialDeCampo As frm_MATECAMP = frm_MATECAMP.instance
        o_MaterialDeCampo.MdiParent = Me
        o_MaterialDeCampo.Show()
    End Sub
    Private Sub DiligenciarTrabajoDeCampoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiligenciarTrabajoDeCampoToolStripMenuItem.Click
        Dim o_TrabajoDeCampo As frm_TRABCAMP = frm_TRABCAMP.instance
        o_TrabajoDeCampo.MdiParent = Me
        o_TrabajoDeCampo.Show()
    End Sub
    Private Sub PrediosExentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrediosExentosToolStripMenuItem.Click
        Dim o_PrediosExentos As frm_PREDEXEN = frm_PREDEXEN.instance
        o_PrediosExentos.MdiParent = Me
        o_PrediosExentos.Show()
    End Sub
    Private Sub LiquidaAforoDeImpuestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquidaAforoDeImpuestoToolStripMenuItem.Click
        Dim o_Liquida_Aforo As frm_Liquida_Aforo_De_Impuesto_LIQUAFOR = frm_Liquida_Aforo_De_Impuesto_LIQUAFOR.instance
        o_Liquida_Aforo.MdiParent = Me
        o_Liquida_Aforo.Show()
    End Sub
    Private Sub PeriodoPermitidoDeLiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodoPermitidoDeLiquidacionToolStripMenuItem.Click
        Dim o_Perido_Permitido_Liquidacion As frm_PEPELIQU = frm_PEPELIQU.instance
        o_Perido_Permitido_Liquidacion.MdiParent = Me
        o_Perido_Permitido_Liquidacion.Show()
    End Sub
    Private Sub PrediosExentosPorNitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrediosExentosPorNitToolStripMenuItem.Click
        Dim o_Predios_exentos_nit As frm_PREDEXNI = frm_PREDEXNI.instance
        o_Predios_exentos_nit.MdiParent = Me
        o_Predios_exentos_nit.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarCedulaCatastralToolStripMenuItem1.Click
        Dim o_ImportarExcelCedulaCatastral As frm_importar_excel_CEDUCATA = frm_importar_excel_CEDUCATA.instance
        o_ImportarExcelCedulaCatastral.MdiParent = Me
        o_ImportarExcelCedulaCatastral.Show()
    End Sub
    Private Sub ReclamosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReclamosToolStripMenuItem.Click
        Dim o_Reclamos As frm_RECLAMOS = frm_RECLAMOS.instance
        o_Reclamos.MdiParent = Me
        o_Reclamos.Show()
    End Sub
    Private Sub TipoDeTramiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeTramiteToolStripMenuItem.Click
        Dim o_TipoDeTramite As frm_TIPOTRAM = frm_TIPOTRAM.instance
        o_TipoDeTramite.MdiParent = Me
        o_TipoDeTramite.Show()
    End Sub
    Private Sub AsignarSubformularioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarSubformularioToolStripMenuItem.Click
        Dim o_PermisosSubFormulario As frm_PERMSUFO = frm_PERMSUFO.instance
        o_PermisosSubFormulario.MdiParent = Me
        o_PermisosSubFormulario.Show()
    End Sub
    Private Sub ActosAdministrativosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActosAdministrativosToolStripMenuItem.Click
        Dim o_ActoAdministrativo As frm_ACTOADMI = frm_ACTOADMI.instance
        o_ActoAdministrativo.MdiParent = Me
        o_ActoAdministrativo.Show()
    End Sub
    Private Sub CruceDeTablasConLlavePrimariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CruceDeTablasConLlavePrimariaToolStripMenuItem.Click
        Dim o_CruceDeTablas As frm_CruceDeTablas = frm_CruceDeTablas.instance
        o_CruceDeTablas.MdiParent = Me
        o_CruceDeTablas.Show()
    End Sub
    Private Sub ConsultaAvaluosCatastralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaAvaluosCatastralesToolStripMenuItem.Click
        Dim o_ConsultaHistoricoDeAvaluos As frm_consulta_historico_de_avaluos = frm_consulta_historico_de_avaluos.instance
        o_ConsultaHistoricoDeAvaluos.MdiParent = Me
        o_ConsultaHistoricoDeAvaluos.Show()
    End Sub
    Private Sub MigrarDatosCatastralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MigrarDatosCatastralesToolStripMenuItem.Click
        Dim o_MigrarDatosCatastrales As frm_Migrar_Datos_Catastrales = frm_Migrar_Datos_Catastrales.instance
        o_MigrarDatosCatastrales.MdiParent = Me
        o_MigrarDatosCatastrales.Show()
    End Sub
    Private Sub PrediosConResolucionAdministrativaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrediosConResolucionAdministrativaToolStripMenuItem.Click
        Dim o_PrediosConRA As frm_PREDREAD = frm_PREDREAD.instance
        o_PrediosConRA.MdiParent = Me
        o_PrediosConRA.Show()
    End Sub
    Private Sub ProcedimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcedimientoToolStripMenuItem.Click
        Dim o_Procedimeinto As frm_PROCEDIMIENTO = frm_PROCEDIMIENTO.instance
        o_Procedimeinto.MdiParent = Me
        o_Procedimeinto.Show()
    End Sub
    Private Sub TablasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TablasToolStripMenuItem.Click
        Dim o_Tablas As frm_TABLAS = frm_TABLAS.instance
        o_Tablas.MdiParent = Me
        o_Tablas.Show()
    End Sub
    Private Sub CamposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CamposToolStripMenuItem.Click
        Dim o_Campos As frm_CAMPOS = frm_CAMPOS.instance
        o_Campos.MdiParent = Me
        o_Campos.Show()
    End Sub
    Private Sub MigrarDatosDinamicamenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MigrarDatosDinamicamenteToolStripMenuItem.Click
        Dim o_MigrarDatosDinamicamente As frm_Migrar_Datos_Dinamicamente = frm_Migrar_Datos_Dinamicamente.instance
        o_MigrarDatosDinamicamente.MdiParent = Me
        o_MigrarDatosDinamicamente.Show()
    End Sub
    Private Sub FichaPredialToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaCatastroToolStripMenuItem1.Click
        Dim EstadisticasFichaPredial As frm_reporte_Estadisticas_Ficha_Predial = frm_reporte_Estadisticas_Ficha_Predial.instance
        EstadisticasFichaPredial.MdiParent = Me
        EstadisticasFichaPredial.Show()
    End Sub
    Private Sub EstadisticaImpuestoPredialToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaImpuestoPredialToolStripMenuItem2.Click
        Dim EstadisticasImpuestoPredial As frm_reporte_Estadistica_Impuesto_Predial = frm_reporte_Estadistica_Impuesto_Predial.instance
        EstadisticasImpuestoPredial.MdiParent = Me
        EstadisticasImpuestoPredial.Show()
    End Sub
    Private Sub ConsultaHistoricosDeLiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaHistoricosDeLiquidacionToolStripMenuItem.Click
        Dim o_ConsultaHistoricoLiquidacion As frm_consulta_historico_de_liquidacion = frm_consulta_historico_de_liquidacion.instance
        o_ConsultaHistoricoLiquidacion.MdiParent = Me
        o_ConsultaHistoricoLiquidacion.Show()
    End Sub
    Private Sub InvestigacionJuridicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvestigacionJuridicaToolStripMenuItem.Click
        Dim o_ConsultaInvestigacionJuridica As frm_consulta_investigacion_juridica_INVEJURI = frm_consulta_investigacion_juridica_INVEJURI.instance
        o_ConsultaInvestigacionJuridica.MdiParent = Me
        o_ConsultaInvestigacionJuridica.Show()
    End Sub
    Private Sub ImportarInvestigacionJuridicaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarInvestigacionJuridicaToolStripMenuItem1.Click
        Dim o_InvestigacionJuridica As frm_importar_excel_JURIDICA = frm_importar_excel_JURIDICA.instance
        o_InvestigacionJuridica.MdiParent = Me
        o_InvestigacionJuridica.Show()
    End Sub
    Private Sub ImportarRegistroyControlToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarRegistroyControlToolStripMenuItem1.Click
        Dim o_RegistroControl As frm_importar_excel_REGICONT = frm_importar_excel_REGICONT.instance
        o_RegistroControl.MdiParent = Me
        o_RegistroControl.Show()
    End Sub
    Private Sub ImportarResolucionesRAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarResolucionesRAToolStripMenuItem1.Click
        Dim o_ResolucionRA As frm_importar_excel_PREDREAD = frm_importar_excel_PREDREAD.instance
        o_ResolucionRA.MdiParent = Me
        o_ResolucionRA.Show()
    End Sub
    Private Sub HistoricoDeSujetoDeImpuestoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoricoDeSujetoDeImpuestoToolStripMenuItem.Click
        Dim o_HistoricoSujetoImpuesto As frm_Historico_Sujeto_Impuesto = frm_Historico_Sujeto_Impuesto.instance
        o_HistoricoSujetoImpuesto.MdiParent = Me
        o_HistoricoSujetoImpuesto.Show()
    End Sub
    Private Sub SalariosMinimosVigentesLegalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalariosMinimosVigentesLegalesToolStripMenuItem.Click
        Dim o_SalarioMinimo As frm_SALAMINI = frm_SALAMINI.instance
        o_SalarioMinimo.MdiParent = Me
        o_SalarioMinimo.Show()
    End Sub
    Private Sub MarcadorPorcentualPorConceptoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcadorPorcentualPorConceptoToolStripMenuItem.Click
        Dim o_PorcentajePermitidoLiquidacion As frm_POPELIQU = frm_POPELIQU.instance
        o_PorcentajePermitidoLiquidacion.MdiParent = Me
        o_PorcentajePermitidoLiquidacion.Show()
    End Sub
    Private Sub ClaseDePredioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseDePredioToolStripMenuItem.Click
        Dim o_ClaseDePredio As frm_CLASPRED = frm_CLASPRED.instance
        o_ClaseDePredio.MdiParent = Me
        o_ClaseDePredio.Show()
    End Sub
    Private Sub MetodoDeInvestigacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetodoDeInvestigacionToolStripMenuItem.Click
        Dim o_MetodoInvestigativo As frm_METOINVE = frm_METOINVE.instance
        o_MetodoInvestigativo.MdiParent = Me
        o_MetodoInvestigativo.Show()
    End Sub
    Private Sub MobiliarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MobiliarioToolStripMenuItem.Click
        Dim o_Mobiliario As frm_MOBILIARIO = frm_MOBILIARIO.instance
        o_Mobiliario.MdiParent = Me
        o_Mobiliario.Show()
    End Sub
    Private Sub CatastroObservatorioInmobiliarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatastroObservatorioInmobiliarioToolStripMenuItem.Click
        Dim o_ObservatorioInmobiliario As frm_OBSEINMO = frm_OBSEINMO.instance
        o_ObservatorioInmobiliario.MdiParent = Me
        o_ObservatorioInmobiliario.Show()
    End Sub
    Private Sub ConsultaAforosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaAforosToolStripMenuItem.Click
        Dim o_ConsultaAforoDeImpuesto As frm_consulta_historico_de_aforo = frm_consulta_historico_de_aforo.instance
        o_ConsultaAforoDeImpuesto.MdiParent = Me
        o_ConsultaAforoDeImpuesto.Show()
    End Sub
    Private Sub CorregimientoMantenimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorregimientoMantenimientoToolStripMenuItem.Click
        Dim o_Corregimiento As frm_CORREGIMIENTO = frm_CORREGIMIENTO.instance
        o_Corregimiento.MdiParent = Me
        o_Corregimiento.Show()
    End Sub
    Private Sub ComunaMantenimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComunaMantenimientoToolStripMenuItem.Click
        Dim o_Comuna As frm_COMUNA = frm_COMUNA.instance
        o_Comuna.MdiParent = Me
        o_Comuna.Show()
    End Sub
    Private Sub BarrioVeredaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarrioVeredaToolStripMenuItem.Click
        Dim o_BarrioVereda As frm_BARRVERE = frm_BARRVERE.instance
        o_BarrioVereda.MdiParent = Me
        o_BarrioVereda.Show()
    End Sub
    Private Sub MutacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MutacionToolStripMenuItem.Click
        Dim o_Mutaciones As frm_MUTACIONES = frm_MUTACIONES.instance
        o_Mutaciones.MdiParent = Me
        o_Mutaciones.Show()
    End Sub
    Private Sub EstructurarLinderosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstructurarLinderosToolStripMenuItem.Click
        Dim o_EstructurarLinderos As frm_Estructurar_Linderos = frm_Estructurar_Linderos.instance
        o_EstructurarLinderos.MdiParent = Me
        o_EstructurarLinderos.Show()
    End Sub
    Private Sub LinderosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarLinderosToolStripMenuItem.Click
        Dim o_ConsultarLinderos As frm_consulta_linderos_FIPRLIND = frm_consulta_linderos_FIPRLIND.instance
        o_ConsultarLinderos.MdiParent = Me
        o_ConsultarLinderos.Show()
    End Sub
    Private Sub ConsultarObservatorioInmobiliarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultarObservatorioInmobiliarioToolStripMenuItem.Click
        Dim o_ConsultarObservatorioInmobiliario As frm_consulta_Observatorio_inmobiliario = frm_consulta_Observatorio_inmobiliario.instance
        o_ConsultarObservatorioInmobiliario.MdiParent = Me
        o_ConsultarObservatorioInmobiliario.Show()
    End Sub
    Private Sub ImportarAreaDeConstruccionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarAreaDeConstruccionToolStripMenuItem1.Click
        Dim o_ImportarAreaDeConstruccion As frm_importar_excel_AREACONSTRUCCION = frm_importar_excel_AREACONSTRUCCION.instance
        o_ImportarAreaDeConstruccion.MdiParent = Me
        o_ImportarAreaDeConstruccion.Show()
    End Sub
    Private Sub GeograficasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeograficasToolStripMenuItem.Click
        Dim o_ConsultaGeagraficaFichaPredial As frm_consulta_geografica_FICHPRED = frm_consulta_geografica_FICHPRED.instance
        o_ConsultaGeagraficaFichaPredial.MdiParent = Me
        o_ConsultaGeagraficaFichaPredial.Show()
    End Sub
    Private Sub ImportarNroFichaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarNroFichaToolStripMenuItem1.Click
        Dim o_ImportarNroFicha As frm_importar_excel_NROFICHA = frm_importar_excel_NROFICHA.instance
        o_ImportarNroFicha.MdiParent = Me
        o_ImportarNroFicha.Show()
    End Sub
    Private Sub AsignacionDeTarifasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignacionDeTarifasToolStripMenuItem.Click
        Dim o_AsignacionDeTarifas As frm_Asignacion_De_Tarifas = frm_Asignacion_De_Tarifas.instance
        o_AsignacionDeTarifas.MdiParent = Me
        o_AsignacionDeTarifas.Show()
    End Sub
    Private Sub ImportarObservacionFichaPredialToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarObservacionFichaPredialToolStripMenuItem1.Click
        Dim o_ImportarObservacionFicha As frm_importar_excel_FIPROBSE = frm_importar_excel_FIPROBSE.instance
        o_ImportarObservacionFicha.MdiParent = Me
        o_ImportarObservacionFicha.Show()
    End Sub
    Private Sub ExportarFichaOVCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaExportarFichaOVCToolStripMenuItem.Click
        Dim o_ExportarFichaOVC As frm_consulta_exportar_ficha_OVC = frm_consulta_exportar_ficha_OVC.instance
        o_ExportarFichaOVC.MdiParent = Me
        o_ExportarFichaOVC.Show()
    End Sub
    Private Sub SolicitanteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitanteToolStripMenuItem.Click
        Dim o_Solicitante As frm_SOLICITANTE = frm_SOLICITANTE.instance
        o_Solicitante.MdiParent = Me
        o_Solicitante.Show()
    End Sub
    Private Sub TipoDeVariableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeVariableToolStripMenuItem.Click
        Dim o_TipoDeVariable As frm_TIPOVARI = frm_TIPOVARI.instance
        o_TipoDeVariable.MdiParent = Me
        o_TipoDeVariable.Show()
    End Sub
    Private Sub FactoresPorProyectoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FactoresPorProyectoToolStripMenuItem.Click
        Dim o_FactoresProyecto As frm_FACTPROY = frm_FACTPROY.instance
        o_FactoresProyecto.MdiParent = Me
        o_FactoresProyecto.Show()
    End Sub
    Private Sub ProyectoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProyectoToolStripMenuItem.Click
        Dim o_Proyecto As frm_PROYECTO = frm_PROYECTO.instance
        o_Proyecto.MdiParent = Me
        o_Proyecto.Show()
    End Sub
    Private Sub VariableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariableToolStripMenuItem.Click
        Dim o_Variable As frm_VARIABLE = frm_VARIABLE.instance
        o_Variable.MdiParent = Me
        o_Variable.Show()
    End Sub
    Private Sub ResolucionValorizacionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResolucionValorizacionToolStripMenuItem1.Click
        Dim o_ResolucionValorizacion As frm_RESOVALO = frm_RESOVALO.instance
        o_ResolucionValorizacion.MdiParent = Me
        o_ResolucionValorizacion.Show()
    End Sub
    Private Sub PrediosConAutoestimacionDeAvaluoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrediosConAutoestimacionDeAvaluoToolStripMenuItem.Click

    End Sub
    Private Sub RangosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RangosToolStripMenuItem.Click
        Dim o_Rangos As frm_RANGOS = frm_RANGOS.instance
        o_Rangos.MdiParent = Me
        o_Rangos.Show()
    End Sub
    Private Sub ClaseDeSueloToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseDeSueloToolStripMenuItem1.Click
        Dim o_ClaseSuelo As frm_CLASSUEL = frm_CLASSUEL.instance
        o_ClaseSuelo.MdiParent = Me
        o_ClaseSuelo.Show()
    End Sub
    Private Sub AreasDeActividadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AreasDeActividadToolStripMenuItem.Click
        Dim o_AreasdeActividad As frm_AREAACTI = frm_AREAACTI.instance
        o_AreasdeActividad.MdiParent = Me
        o_AreasdeActividad.Show()
    End Sub
    Private Sub TratamientosUrbanisticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TratamientosUrbanisticosToolStripMenuItem.Click
        Dim o_TratamientosUrbanisticos As frm_TRATURBA = frm_TRATURBA.instance
        o_TratamientosUrbanisticos.MdiParent = Me
        o_TratamientosUrbanisticos.Show()
    End Sub
    Private Sub DestinacionToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestinacionToolStripMenuItem.Click
        Dim o_Destinacion As frm_DESTINACION = frm_DESTINACION.instance
        o_Destinacion.MdiParent = Me
        o_Destinacion.Show()
    End Sub
    Private Sub ServiciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiciosToolStripMenuItem.Click
        Dim o_Servicios As frm_SERVICIOS = frm_SERVICIOS.instance
        o_Servicios.MdiParent = Me
        o_Servicios.Show()
    End Sub
    Private Sub ViasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViasToolStripMenuItem.Click
        Dim o_Vias As frm_VIAS = frm_VIAS.instance
        o_Vias.MdiParent = Me
        o_Vias.Show()
    End Sub
    Private Sub TopografiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopografiaToolStripMenuItem.Click
        Dim o_Topografia As frm_TOPOGRAFIA = frm_TOPOGRAFIA.instance
        o_Topografia.MdiParent = Me
        o_Topografia.Show()
    End Sub
    Private Sub TipoSegunDestinacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoSegunDestinacionToolStripMenuItem.Click
        Dim o_SegunDestinacion As frm_SEGUDEST = frm_SEGUDEST.instance
        o_SegunDestinacion.MdiParent = Me
        o_SegunDestinacion.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem1.Click
        Dim o_ImportarTipoConstruccion As frm_importar_excel_TIPOCONS = frm_importar_excel_TIPOCONS.instance
        o_ImportarTipoConstruccion.MdiParent = Me
        o_ImportarTipoConstruccion.Show()
    End Sub
    Private Sub VariablesZonaFisicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariablesZonaFisicaToolStripMenuItem.Click
        Dim o_VariableZonaFisica As frm_VARIZOFI = frm_VARIZOFI.instance
        o_VariableZonaFisica.MdiParent = Me
        o_VariableZonaFisica.Show()
    End Sub
    Private Sub PuntosRequeridosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PuntosRequeridosToolStripMenuItem.Click
        Dim o_PuntosRequeridos As frm_PUNTREQU = frm_PUNTREQU.instance
        o_PuntosRequeridos.MdiParent = Me
        o_PuntosRequeridos.Show()
    End Sub
    Private Sub DuplicarFotografiaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicarFotografiaToolStripMenuItem.Click
        Dim o_DuplicarFotografia As frm_Duplicar_Fotografias = frm_Duplicar_Fotografias.instance
        o_DuplicarFotografia.MdiParent = Me
        o_DuplicarFotografia.Show()
    End Sub
    Private Sub EstadoCivilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoCivilToolStripMenuItem.Click
        Dim o_EstadoCivil As frm_ESTACIVI = frm_ESTACIVI.instance
        o_EstadoCivil.MdiParent = Me
        o_EstadoCivil.Show()
    End Sub
    Private Sub ZonaFisicaActualizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZonaFisicaActualizacionToolStripMenuItem.Click
        Dim o_ZonaFisicaActualizacion As frm_ZOFIACTU = frm_ZOFIACTU.instance
        o_ZonaFisicaActualizacion.MdiParent = Me
        o_ZonaFisicaActualizacion.Show()
    End Sub
    Private Sub ZonaEconomicaActualizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZonaEconomicaActualizacionToolStripMenuItem.Click
        Dim o_ZonaEconomicaActualizacion As frm_ZOECACTU = frm_ZOECACTU.instance
        o_ZonaEconomicaActualizacion.MdiParent = Me
        o_ZonaEconomicaActualizacion.Show()
    End Sub
    Private Sub VariablesFisicasUrbanasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariablesZonasFisicasToolStripMenuItem.Click
        Dim o_VariableZonaFisica As frm_VARIZOFI = frm_VARIZOFI.instance
        o_VariableZonaFisica.MdiParent = Me
        o_VariableZonaFisica.Show()
    End Sub
    Private Sub ActualizarPropietarioActualYAnteriorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarPropietarioActualYAnteriorToolStripMenuItem.Click
        Dim o_ActualizarPropietario As frm_Actualizar_Propietario_Actual_y_Anterior = frm_Actualizar_Propietario_Actual_y_Anterior.instance
        o_ActualizarPropietario.MdiParent = Me
        o_ActualizarPropietario.Show()
    End Sub
    Private Sub PlanoManzaneroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanoManzaneroToolStripMenuItem.Click
        Dim o_PlanoManzanero As frm_consulta_plano_manzanero = frm_consulta_plano_manzanero.instance
        o_PlanoManzanero.MdiParent = Me
        o_PlanoManzanero.Show()
    End Sub
    Private Sub RutaPlanoManzaneroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaPlanoManzaneroToolStripMenuItem.Click
        Dim o_RutaPlanoManzanero As frm_RUTAPLMA = frm_RUTAPLMA.instance
        o_RutaPlanoManzanero.MdiParent = Me
        o_RutaPlanoManzanero.Show()
    End Sub
    Private Sub CarpetasFotograficasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CarpetasFotograficasToolStripMenuItem.Click
        Dim o_CarpetasFotograficas As frm_CARPFOTO = frm_CARPFOTO.instance
        o_CarpetasFotograficas.MdiParent = Me
        o_CarpetasFotograficas.Show()
    End Sub
    Private Sub RutaCarpetaFotograficaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaCarpetaFotograficaToolStripMenuItem.Click
        Dim o_RutaCarpetasFotograficas As frm_RUTACAFO = frm_RUTACAFO.instance
        o_RutaCarpetasFotograficas.MdiParent = Me
        o_RutaCarpetasFotograficas.Show()
    End Sub
    Private Sub DocumentosGeneralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentosGeneralesToolStripMenuItem.Click
        Dim o_DocumentosGenerales As frm_DOCUGENE = frm_DOCUGENE.instance
        o_DocumentosGenerales.MdiParent = Me
        o_DocumentosGenerales.Show()
    End Sub
    Private Sub ConsultaDocumentosGeneralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaDocumentosGeneralesToolStripMenuItem.Click
        Dim o_ConsultaDocumentosGenerales As frm_consulta_Documentos_Generales = frm_consulta_Documentos_Generales.instance
        o_ConsultaDocumentosGenerales.MdiParent = Me
        o_ConsultaDocumentosGenerales.Show()
    End Sub
    Private Sub RutaDocumentosGeneralesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaDocumentosGeneralesToolStripMenuItem.Click
        Dim o_RutaDocumentosGenerales As frm_RUTADOGE = frm_RUTADOGE.instance
        o_RutaDocumentosGenerales.MdiParent = Me
        o_RutaDocumentosGenerales.Show()
    End Sub
    Private Sub CopiarYGenerarIndiceDeArchivosFotograficosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarYGenerarIndiceDeArchivosFotograficosToolStripMenuItem.Click
        Dim o_CopiarYGenerarIndiceArchivoFotografico As frm_Copiar_y_Gegerar_Indice_Archivos_Fotograficos = frm_Copiar_y_Gegerar_Indice_Archivos_Fotograficos.instance
        o_CopiarYGenerarIndiceArchivoFotografico.MdiParent = Me
        o_CopiarYGenerarIndiceArchivoFotografico.Show()
    End Sub
    Private Sub AjusteDeImpuestoPredialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjusteDeImpuestoPredialToolStripMenuItem.Click
        Dim o_AjusteLiquidacionImpuestoPredial As frm_AJUSIMPR = frm_AJUSIMPR.instance
        o_AjusteLiquidacionImpuestoPredial.MdiParent = Me
        o_AjusteLiquidacionImpuestoPredial.Show()
    End Sub
    Private Sub ClasificacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClasificacionToolStripMenuItem.Click
        Dim o_Clasificacion As frm_CLASIFICACION = frm_CLASIFICACION.instance
        o_Clasificacion.MdiParent = Me
        o_Clasificacion.Show()
    End Sub
    Private Sub MedioDeResepcionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedioDeResepcionToolStripMenuItem.Click
        Dim o_MedioDeResepcion As frm_MEDIRESE = frm_MEDIRESE.instance
        o_MedioDeResepcion.MdiParent = Me
        o_MedioDeResepcion.Show()
    End Sub
    Private Sub ResolucionDeAjusteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResolucionDeAjusteToolStripMenuItem.Click
        Dim o_ResolucionDeAjuste As frm_RESOAJUS = frm_RESOAJUS.instance
        o_ResolucionDeAjuste.MdiParent = Me
        o_ResolucionDeAjuste.Show()
    End Sub
    Private Sub DepurarCarpetasFotograficasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepurarCarpetasFotograficasToolStripMenuItem.Click
        Dim o_DepurarCarpetasFotograficas As frm_Depurar_Carpetas_Fotograficas = frm_Depurar_Carpetas_Fotograficas.instance
        o_DepurarCarpetasFotograficas.MdiParent = Me
        o_DepurarCarpetasFotograficas.Show()
    End Sub
    Private Sub GenerarAreasDeConstruccionMediantePoligonosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarAreasDeConstruccionMediantePoligonosToolStripMenuItem.Click
        Dim o_GenerarConstruccionesMediantePoligonos As frm_Generar_Areas_de_Construccion_Mediante_Poligonos = frm_Generar_Areas_de_Construccion_Mediante_Poligonos.instance
        o_GenerarConstruccionesMediantePoligonos.MdiParent = Me
        o_GenerarConstruccionesMediantePoligonos.Show()
    End Sub
    Private Sub ComparativosDeLiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComparativosDeLiquidacionToolStripMenuItem.Click
        Dim o_ComparativosDeLiquidacion As frm_consulta_comparativo_de_liquidacion = frm_consulta_comparativo_de_liquidacion.instance
        o_ComparativosDeLiquidacion.MdiParent = Me
        o_ComparativosDeLiquidacion.Show()
    End Sub
    Private Sub ImportarHistoricosDeAvaluosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarHistoricosDeAvaluosToolStripMenuItem2.Click
        Dim o_ImportarHistoricoDeAvaluos As frm_importar_excel_HISTAVAL = frm_importar_excel_HISTAVAL.instance
        o_ImportarHistoricoDeAvaluos.MdiParent = Me
        o_ImportarHistoricoDeAvaluos.Show()
    End Sub
    Private Sub TarifasPorRangosDeAreasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasPorRangosDeAreasToolStripMenuItem.Click
        Dim o_TarifasPorRangoDeAreas As frm_TARIRAAR = frm_TARIRAAR.instance
        o_TarifasPorRangoDeAreas.MdiParent = Me
        o_TarifasPorRangoDeAreas.Show()
    End Sub
    Private Sub ImportarAforoImpuestosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarAforoImpuestosToolStripMenuItem2.Click
        Dim o_ImportarAforoImpuesto As frm_importar_excel_AFORSUIM = frm_importar_excel_AFORSUIM.instance
        o_ImportarAforoImpuesto.MdiParent = Me
        o_ImportarAforoImpuesto.Show()
    End Sub
    Private Sub ImportarZonaEconomicaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarZonaEconomicaToolStripMenuItem2.Click
        Dim o_ImportarZonaEconomica As frm_importar_excel_FIPRZOEC = frm_importar_excel_FIPRZOEC.instance
        o_ImportarZonaEconomica.MdiParent = Me
        o_ImportarZonaEconomica.Show()
    End Sub
    Private Sub CruceDeAreasDeConstruccionBdVsGeodataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CruceDeAreasDeConstruccionBdVsGeodataToolStripMenuItem.Click
        Dim o_CruceAreaDeConstruccionBdvsGeodata As frm_Cruce_Areas_Construccion_BD_Geodata = frm_Cruce_Areas_Construccion_BD_Geodata.instance
        o_CruceAreaDeConstruccionBdvsGeodata.MdiParent = Me
        o_CruceAreaDeConstruccionBdvsGeodata.Show()
    End Sub
    Private Sub ClaseDeVersionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseDeVersionToolStripMenuItem.Click
        Dim o_ClaseDeVersion As frm_CLASVERS = frm_CLASVERS.instance
        o_ClaseDeVersion.MdiParent = Me
        o_ClaseDeVersion.Show()
    End Sub
    Private Sub MovimientosGeograficosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientosGeograficosToolStripMenuItem.Click
        Dim o_MovimientosGeograficos As frm_MOVIGEOG = frm_MOVIGEOG.instance
        o_MovimientosGeograficos.MdiParent = Me
        o_MovimientosGeograficos.Show()
    End Sub
    Private Sub CategoriaDePredioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriaDePredioToolStripMenuItem.Click
        Dim o_CategoriaDePredio As frm_CATEPRED = frm_CATEPRED.instance
        o_CategoriaDePredio.MdiParent = Me
        o_CategoriaDePredio.Show()
    End Sub
    Private Sub ImportarCategoriaDePredioToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarCategoriaDePredioToolStripMenuItem2.Click
        Dim o_CategoriaDePredioFichaPredial As frm_importar_excel_CAPRFIPR = frm_importar_excel_CAPRFIPR.instance
        o_CategoriaDePredioFichaPredial.MdiParent = Me
        o_CategoriaDePredioFichaPredial.Show()
    End Sub
    Private Sub DuplicarFichaPredialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplicarFichaPredialToolStripMenuItem.Click
        Dim o_DuplicarFichaPredial As frm_Duplicar_Ficha_Predial = frm_Duplicar_Ficha_Predial.instance
        o_DuplicarFichaPredial.MdiParent = Me
        o_DuplicarFichaPredial.Show()
    End Sub
    Private Sub PlanoPredialCatastralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanoPredialCatastralToolStripMenuItem.Click
        Dim o_PlanoPredialCatastral As frm_consulta_plano_predial_catastral = frm_consulta_plano_predial_catastral.instance
        o_PlanoPredialCatastral.MdiParent = Me
        o_PlanoPredialCatastral.Show()
    End Sub
    Private Sub ControlDeComandosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeComandosToolStripMenuItem.Click
        Dim o_ControlDeComandos As frm_CONTCOMA = frm_CONTCOMA.instance
        o_ControlDeComandos.MdiParent = Me
        o_ControlDeComandos.Show()
    End Sub
    Private Sub AsignarControlDeComandosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AsignarControlDeComandosToolStripMenuItem.Click
        Dim o_PermisoControlDeComandos As frm_PERMCOCO = frm_PERMCOCO.instance
        o_PermisoControlDeComandos.MdiParent = Me
        o_PermisoControlDeComandos.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem2.Click
        Dim o_ImportarCoeficienteEdificio As frm_importar_excel_COEFEDIF = frm_importar_excel_COEFEDIF.instance
        o_ImportarCoeficienteEdificio.MdiParent = Me
        o_ImportarCoeficienteEdificio.Show()
    End Sub
    Private Sub FotografiaPorIdentificadorDeConstruccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FotografiaPorIdentificadorDeConstruccionToolStripMenuItem.Click
        Dim o_FotografiaPorIdentificadorDeConstruccion As frm_FOTOTICO = frm_FOTOTICO.instance
        o_FotografiaPorIdentificadorDeConstruccion.MdiParent = Me
        o_FotografiaPorIdentificadorDeConstruccion.Show()
    End Sub
    Private Sub AguasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AguasToolStripMenuItem.Click
        Dim o_Aguas As frm_AGUAS = frm_AGUAS.instance
        o_Aguas.MdiParent = Me
        o_Aguas.Show()
    End Sub
    Private Sub AHTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AHTToolStripMenuItem.Click
        Dim o_AHT As frm_AHT = frm_AHT.instance
        o_AHT.MdiParent = Me
        o_AHT.Show()
    End Sub
    Private Sub RevisionDeAvaluoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisionDeAvaluoToolStripMenuItem.Click
        Dim o_RevisionDeAvaluo As frm_REVIAVAL = frm_REVIAVAL.instance
        o_RevisionDeAvaluo.MdiParent = Me
        o_RevisionDeAvaluo.Show()
    End Sub
    Private Sub FormularioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormularioToolStripMenuItem.Click
        Dim o_Formulario As frm_FORMULARIO = frm_FORMULARIO.instance
        o_Formulario.MdiParent = Me
        o_Formulario.Show()
    End Sub
    Private Sub MaterialDeCampoPorFormularioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialDeCampoPorFormularioToolStripMenuItem.Click
        Dim o_MaterialDeCampoPorFormulario As frm_MACAFORM = frm_MACAFORM.instance
        o_MaterialDeCampoPorFormulario.MdiParent = Me
        o_MaterialDeCampoPorFormulario.Show()
    End Sub
    Private Sub RegistroDeMutacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroDeMutacionToolStripMenuItem.Click
        Dim o_RegistroDeMutaciones As frm_REGIMUTA = frm_REGIMUTA.instance
        o_RegistroDeMutaciones.MdiParent = Me
        o_RegistroDeMutaciones.Show()
    End Sub
    Private Sub GenerarRegistroDeMutacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarRegistroDeMutacionesToolStripMenuItem.Click
        Dim o_GenerarRegistroDeMutaciones As frm_Generar_Registro_de_Mutaciones = frm_Generar_Registro_de_Mutaciones.instance
        o_GenerarRegistroDeMutaciones.MdiParent = Me
        o_GenerarRegistroDeMutaciones.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem3.Click
        Dim o_ImportarInformacionRPH As frm_importar_excel_INFORPH = frm_importar_excel_INFORPH.instance
        o_ImportarInformacionRPH.MdiParent = Me
        o_ImportarInformacionRPH.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem4.Click
        Dim o_ImportarInformacionLinderosFichaPredial As frm_importar_excel_LINDEROS = frm_importar_excel_LINDEROS.instance
        o_ImportarInformacionLinderosFichaPredial.MdiParent = Me
        o_ImportarInformacionLinderosFichaPredial.Show()
    End Sub
    Private Sub DivisionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DivisionToolStripMenuItem.Click
        Dim o_Division As frm_DIVISION = frm_DIVISION.instance
        o_Division.MdiParent = Me
        o_Division.Show()
    End Sub
    Private Sub MedioDeNotificacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedioDeNotificacionToolStripMenuItem.Click
        Dim o_MedioDeNotificacion As frm_MEDINOTI = frm_MEDINOTI.instance
        o_MedioDeNotificacion.MdiParent = Me
        o_MedioDeNotificacion.Show()
    End Sub
    Private Sub LibroRadicadorToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroRadicadorToolStripMenuItem.Click
        Dim o_LibroRadicado As frm_LIBRRADI = frm_LIBRRADI.instance
        o_LibroRadicado.MdiParent = Me
        o_LibroRadicado.Show()
    End Sub
    Private Sub BitacoraDeMovimientosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BitacoraDeMovimientosToolStripMenuItem.Click
        Dim o_BitacoraDeMovimientos As frm_BITAMOVI = frm_BITAMOVI.instance
        o_BitacoraDeMovimientos.MdiParent = Me
        o_BitacoraDeMovimientos.Show()
    End Sub
    Private Sub MovimientoAlfanumericoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientoAlfanumericoToolStripMenuItem.Click
        Dim o_MovimientosAlfanumericos As frm_MOVIALFA = frm_MOVIALFA.instance
        o_MovimientosAlfanumericos.MdiParent = Me
        o_MovimientosAlfanumericos.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem5.Click
        Dim o_ImportarCartografia As frm_importar_excel_CARTOGRAFIA = frm_importar_excel_CARTOGRAFIA.instance
        o_ImportarCartografia.MdiParent = Me
        o_ImportarCartografia.Show()
    End Sub
    Private Sub ConsultaTrabajoDeCampoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaTrabajoDeCampoToolStripMenuItem.Click
        Dim o_ConsultaTrabajoDeCampo As frm_consulta_trabajo_de_campo_TRABCAMP = frm_consulta_trabajo_de_campo_TRABCAMP.instance
        o_ConsultaTrabajoDeCampo.MdiParent = Me
        o_ConsultaTrabajoDeCampo.Show()
    End Sub
    Private Sub ClaseDeEntidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseDeEntidadToolStripMenuItem.Click
        Dim o_ClaseDeEntidad As frm_CLASENTI = frm_CLASENTI.instance
        o_ClaseDeEntidad.MdiParent = Me
        o_ClaseDeEntidad.Show()
    End Sub
    Private Sub ResolucionesYLicenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResolucionesYLicenciasToolStripMenuItem.Click
        Dim o_ResolucionesyLicencias As frm_RESOLICE = frm_RESOLICE.instance
        o_ResolucionesyLicencias.MdiParent = Me
        o_ResolucionesyLicencias.Show()
    End Sub
    Private Sub BitacoraDeRadicadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BitacoraDeRadicadosToolStripMenuItem.Click
        Dim o_BitacoraDeRadicados As frm_BITARADI = frm_BITARADI.instance
        o_BitacoraDeRadicados.MdiParent = Me
        o_BitacoraDeRadicados.Show()
    End Sub
    Private Sub ReducirTamanoDeArchivoFotograficoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReducirTamanoDeArchivoFotograficoToolStripMenuItem.Click
        Dim o_ReducirTamanoArchivoFotografico As frm_Reducir_Tamano_Fotografia = frm_Reducir_Tamano_Fotografia.instance
        o_ReducirTamanoArchivoFotografico.MdiParent = Me
        o_ReducirTamanoArchivoFotografico.Show()
    End Sub
    Private Sub PlanoCartograficoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaPlanoCartograficoToolStripMenuItem.Click
        Dim o_ConsultaPlanoCartografico As frm_consulta_Plano_Cartografico = frm_consulta_Plano_Cartografico.instance
        o_ConsultaPlanoCartografico.MdiParent = Me
        o_ConsultaPlanoCartografico.Show()
    End Sub
    Private Sub PlanoCartograficoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanoCartograficoToolStripMenuItem.Click
        Dim o_PlanoCartografico As frm_PLANCART = frm_PLANCART.instance
        o_PlanoCartografico.MdiParent = Me
        o_PlanoCartografico.Show()
    End Sub
    Private Sub RutaPlanoCartograficoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaPlanoCartograficoToolStripMenuItem.Click
        Dim o_RutaPlanoCartografico As frm_RUTAPLCA = frm_RUTAPLCA.instance
        o_RutaPlanoCartografico.MdiParent = Me
        o_RutaPlanoCartografico.Show()
    End Sub
    Private Sub TarifasPorZonasFisicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarifasPorZonasFisicasToolStripMenuItem.Click
        Dim o_TarifasZonaFisica As frm_TARIZOFI = frm_TARIZOFI.instance
        o_TarifasZonaFisica.MdiParent = Me
        o_TarifasZonaFisica.Show()
    End Sub
    Private Sub ImportarZonasFisicasFichaPredialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarZonasFisicasFichaPredialToolStripMenuItem.Click
        Dim o_ImportarZonaFisicaFichaPredial As frm_importar_excel_FIPRZOFI = frm_importar_excel_FIPRZOFI.instance
        o_ImportarZonaFisicaFichaPredial.MdiParent = Me
        o_ImportarZonaFisicaFichaPredial.Show()
    End Sub
    Private Sub ResolucionDeConservacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResolucionDeConservacionToolStripMenuItem.Click
        Dim o_ResolucionDeConservacion As frm_RESOCONS = frm_RESOCONS.instance
        o_ResolucionDeConservacion.MdiParent = Me
        o_ResolucionDeConservacion.Show()
    End Sub
    Private Sub CruceDeInformacionICAREVsBDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CruceDeInformacionICAREVsBDToolStripMenuItem.Click
        Dim o_CruceInformacionICARE As frm_Cruce_Informacion_ICARE = frm_Cruce_Informacion_ICARE.instance
        o_CruceInformacionICARE.MdiParent = Me
        o_CruceInformacionICARE.Show()
    End Sub
    Private Sub ImportarToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarToolStripMenuItem6.Click
        Dim o_CalcularConstruccion As frm_importar_excel_calcular_construccion = frm_importar_excel_calcular_construccion.instance
        o_CalcularConstruccion.MdiParent = Me
        o_CalcularConstruccion.Show()
    End Sub
    Private Sub SalariosMinimosMensualesLegalesVigentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalariosMinimosMensualesLegalesVigentesToolStripMenuItem.Click
        Dim o_SalarioMinimo As frm_SALAMINI = frm_SALAMINI.instance
        o_SalarioMinimo.MdiParent = Me
        o_SalarioMinimo.Show()
    End Sub
    Private Sub CirculoRegistralMunicipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CirculoRegistralMunicipalToolStripMenuItem.Click
        Dim o_CirculoDeRegistro As frm_CIRCREGI = frm_CIRCREGI.instance
        o_CirculoDeRegistro.MdiParent = Me
        o_CirculoDeRegistro.Show()
    End Sub
    Private Sub ClaseDeEntidadMunicipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseDeEntidadMunicipalToolStripMenuItem.Click
        Dim o_ClaseDeEntidad As frm_CLASENTI = frm_CLASENTI.instance
        o_ClaseDeEntidad.MdiParent = Me
        o_ClaseDeEntidad.Show()
    End Sub
    Private Sub TipoDeLiquidacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeLiquidacionToolStripMenuItem.Click
        Dim o_TipoDeLiquidacion As frm_TIPOLIQU = frm_TIPOLIQU.instance
        o_TipoDeLiquidacion.MdiParent = Me
        o_TipoDeLiquidacion.Show()
    End Sub
    Private Sub ClaseDeObligacionUrbanisticaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClaseDeObligacionUrbanisticaToolStripMenuItem.Click
        Dim o_ClaseDeObligacionUrbanistica As frm_CLASOBUR = frm_CLASOBUR.instance
        o_ClaseDeObligacionUrbanistica.MdiParent = Me
        o_ClaseDeObligacionUrbanistica.Show()
    End Sub
    Private Sub CesionesEspacioPublicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CesionesEspacioPublicoToolStripMenuItem.Click
        Dim o_CesionesEspacioPublico As frm_CESIESPU = frm_CESIESPU.instance
        o_CesionesEspacioPublico.MdiParent = Me
        o_CesionesEspacioPublico.Show()
    End Sub
    Private Sub CesionesEquipamientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CesionesEquipamientoToolStripMenuItem.Click
        Dim o_CesionesEquipamiento As frm_CESIEQUI = frm_CESIEQUI.instance
        o_CesionesEquipamiento.MdiParent = Me
        o_CesionesEquipamiento.Show()
    End Sub
    Private Sub DensidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DensidadToolStripMenuItem.Click
        Dim o_Densidad As frm_DENSIDAD = frm_DENSIDAD.instance
        o_Densidad.MdiParent = Me
        o_Densidad.Show()
    End Sub
    Private Sub ImportarDensidadDeViviendaToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarDensidadDeViviendaToolStripMenuItem7.Click
        Dim o_ImportarDensidadDeVivienda As frm_importar_excel_DENSIDAD = frm_importar_excel_DENSIDAD.instance
        o_ImportarDensidadDeVivienda.MdiParent = Me
        o_ImportarDensidadDeVivienda.Show()
    End Sub
    Private Sub ZonaDePlanificacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZonaDePlanificacionToolStripMenuItem.Click
        Dim o_ZonaDePlanificacionTool As frm_ZONAPLAN = frm_ZONAPLAN.instance
        o_ZonaDePlanificacionTool.MdiParent = Me
        o_ZonaDePlanificacionTool.Show()
    End Sub
    Private Sub ObligacionesUrbanisticasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObligacionesUrbanisticasToolStripMenuItem.Click
        Dim o_ObligacionesUrbanisticasTool As frm_OBLIURBA = frm_OBLIURBA.instance
        o_ObligacionesUrbanisticasTool.MdiParent = Me
        o_ObligacionesUrbanisticasTool.Show()
    End Sub
    Private Sub ZonaDePanificacionPorBarriosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZonaDePanificacionPorBarriosToolStripMenuItem.Click
        Dim o_ZonaDePanificacionPorBarrios As frm_ZOPLBARR = frm_ZOPLBARR.instance
        o_ZonaDePanificacionPorBarrios.MdiParent = Me
        o_ZonaDePanificacionPorBarrios.Show()
    End Sub
    Private Sub CertificacionDeEstratoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CertificacionDeEstratoToolStripMenuItem.Click
        Dim o_CertificacionEstratoSocioeconomico As frm_CERTESSO = frm_CERTESSO.instance
        o_CertificacionEstratoSocioeconomico.MdiParent = Me
        o_CertificacionEstratoSocioeconomico.Show()
    End Sub
    Private Sub MantenimientoProyectoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoProyectoSocioeconomicoToolStripMenuItem1.Click
        Dim o_ProyectoSocioeconomico As frm_PROYSOCI = frm_PROYSOCI.instance
        o_ProyectoSocioeconomico.MdiParent = Me
        o_ProyectoSocioeconomico.Show()
    End Sub
    Private Sub MantenimientoAsignacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoAsignacionDeEntidadToolStripMenuItem.Click
        Dim o_AsignacionEntidad As frm_ASIGENTI = frm_ASIGENTI.instance
        o_AsignacionEntidad.MdiParent = Me
        o_AsignacionEntidad.Show()
    End Sub
    Private Sub MantenimientoUbicacionDeViviendaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoUbicacionDeViviendaToolStripMenuItem.Click
        Dim o_UbicacionDeVivienda As frm_UBICVIVI = frm_UBICVIVI.instance
        o_UbicacionDeVivienda.MdiParent = Me
        o_UbicacionDeVivienda.Show()
    End Sub
    Private Sub ServiciosPublicosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiciosPublicosToolStripMenuItem.Click
        Dim o_ServiciosPublicos As frm_SERVPUBL = frm_SERVPUBL.instance
        o_ServiciosPublicos.MdiParent = Me
        o_ServiciosPublicos.Show()
    End Sub
    Private Sub ProyectoDelPlanParcialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProyectoDelPlanParcialToolStripMenuItem.Click
        Dim o_ProyectoDelPlanParcial As frm_PLANPARC = frm_PLANPARC.instance
        o_ProyectoDelPlanParcial.MdiParent = Me
        o_ProyectoDelPlanParcial.Show()
    End Sub
    Private Sub CargasYBeneficiosDelPlanParcialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargasYBeneficiosDelPlanParcialToolStripMenuItem.Click
        Dim o_CargasyBeneficios As frm_CABEPLPA = frm_CABEPLPA.instance
        o_CargasyBeneficios.MdiParent = Me
        o_CargasyBeneficios.Show()

        'Dim o_CargasyBeneficios As frm_CARGBENE = frm_CARGBENE.instance
        'o_CargasyBeneficios.MdiParent = Me
        'o_CargasyBeneficios.Show()

    End Sub
    Private Sub FormaDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormaDePagoToolStripMenuItem.Click
        Dim o_FormaDePago As frm_FOPAPLPA = frm_FOPAPLPA.instance
        o_FormaDePago.MdiParent = Me
        o_FormaDePago.Show()
    End Sub
    Private Sub ControlFormaDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlFormaDePagoToolStripMenuItem.Click
        Dim o_ControlFormaDePago As frm_COFPPLPA = frm_COFPPLPA.instance
        o_ControlFormaDePago.MdiParent = Me
        o_ControlFormaDePago.Show()
    End Sub
    Private Sub UnidadesDeActuacionDelPlanParcialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnidadesDeActuacionDelPlanParcialToolStripMenuItem.Click
        Dim o_UnidadesDeActuacionDelPlanParcial As frm_UAUPLPA = frm_UAUPLPA.instance
        o_UnidadesDeActuacionDelPlanParcial.MdiParent = Me
        o_UnidadesDeActuacionDelPlanParcial.Show()
    End Sub
    Private Sub CargasYBeneficiosPorUnidadesDeActuacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargasYBeneficiosPorUnidadesDeActuacionToolStripMenuItem.Click
        Dim o_CargasYBeneficiosPorUnidadesDeActuacion As frm_CABEUAU = frm_CABEUAU.instance
        o_CargasYBeneficiosPorUnidadesDeActuacion.MdiParent = Me
        o_CargasYBeneficiosPorUnidadesDeActuacion.Show()
    End Sub
    Private Sub ContribuyenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContribuyenteToolStripMenuItem.Click
        Dim o_Contribuyente As frm_CONTRIBUYENTE = frm_CONTRIBUYENTE.instance
        o_Contribuyente.MdiParent = Me
        o_Contribuyente.Show()
    End Sub
    Private Sub FichaPredialDigitalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichaPredialDigitalToolStripMenuItem.Click
        Dim o_FichaPredialCatastral As frm_FIPRDIGI = frm_FIPRDIGI.instance
        o_FichaPredialCatastral.MdiParent = Me
        o_FichaPredialCatastral.Show()
    End Sub
    Private Sub RutaFichaPredialDigitalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutaFichaPredialDigitalToolStripMenuItem.Click
        Dim o_RutaFichaPredialDigital As frm_RUTAFPDI = frm_RUTAFPDI.instance
        o_RutaFichaPredialDigital.MdiParent = Me
        o_RutaFichaPredialDigital.Show()
    End Sub
    Private Sub FichaPredialDigitalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichaPredialDigitalToolStripMenuItem1.Click
        Dim o_FichaPredialDigital As frm_consulta_ficha_predial_digital = frm_consulta_ficha_predial_digital.instance
        o_FichaPredialDigital.MdiParent = Me
        o_FichaPredialDigital.Show()
    End Sub
    Private Sub MutacionesPrimeraClaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MutacionesPrimeraClaseToolStripMenuItem.Click
        Dim o_MutacionesPrimeraClase As frm_MUTAPRIM = frm_MUTAPRIM.instance
        o_MutacionesPrimeraClase.MdiParent = Me
        o_MutacionesPrimeraClase.Show()
    End Sub
    Private Sub NovedadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovedadToolStripMenuItem.Click
        Dim o_Novedad As frm_NOVEDAD = frm_NOVEDAD.instance
        o_Novedad.MdiParent = Me
        o_Novedad.Show()
    End Sub
    Private Sub FideicomisosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FideicomisosToolStripMenuItem.Click
        Dim o_Fideicomiso As frm_FIDEICOMISO = frm_FIDEICOMISO.instance
        o_Fideicomiso.MdiParent = Me
        o_Fideicomiso.Show()
    End Sub
    Private Sub ResolucionAdministrativaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResolucionAdministrativaToolStripMenuItem.Click
        Dim o_ResolucionAdministrativa As frm_RESOADMI = frm_RESOADMI.instance
        o_ResolucionAdministrativa.MdiParent = Me
        o_ResolucionAdministrativa.Show()
    End Sub

#End Region


    
   
  
End Class
