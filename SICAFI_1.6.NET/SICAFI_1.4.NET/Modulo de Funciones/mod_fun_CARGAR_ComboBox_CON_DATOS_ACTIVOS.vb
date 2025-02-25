Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports REGLAS_DEL_NEGOCIO

Module mod_fun_CARGAR_ComboBox_CON_DATOS_ACTIVOS

    '====================================================
    '*** CARGA LOS COMBOBOX CON LOS REGISTROS ACTIVOS ***
    '====================================================

    ''' <summary>
    ''' carga la descripcion
    ''' </summary>
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try

            Dim objdatos2 As New cla_DEPARTAMENTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_campos_MANT_DEPARTAMENTO_X_ESTADO
            obNombreCampo.DisplayMember = "DEPADESC"
            obNombreCampo.ValueMember = "DEPACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                          ByVal inPosicion As Integer, _
                                                                                          ByVal obDepatamento As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_MUNICIPIO

                obNombreCampo.DataSource = objdatos2.fun_Buscar_MUNICIPIO_X_DEPARTAMENTO_MANT_MUNICIPIO(obDepatamento.SelectedValue)
                obNombreCampo.DisplayMember = "MUNIDESC"
                obNombreCampo.ValueMember = "MUNICODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_UAU_X_PLANPARC_Descripcion(ByVal obNombreCampo As Object, _
                                                                                ByVal inPosicion As Integer, _
                                                                                ByVal obPlanParcial As Object, _
                                                                                ByVal inResolucion As Integer, _
                                                                                ByVal stFecha As String)
        Try

            If Not obPlanParcial.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_UAUPLPA

                obNombreCampo.DataSource = objdatos2.fun_Buscar_UAU_X_PLANPARC_UAUPLPA(inResolucion, stFecha)
                obNombreCampo.DisplayMember = "UAPPUAU"
                obNombreCampo.ValueMember = "UAPPUAU"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MES_X_VIGENCIA_Descripcion(ByVal obNombreCampo As Object, _
                                                                                ByVal inPosicion As Integer, _
                                                                                ByVal obVigencia As Object)
        Try

            If Not obVigencia.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_PERIODO

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_MES_X_VIGENCIA(obVigencia.SelectedValue)
                obNombreCampo.DisplayMember = "PERIDESC"
                obNombreCampo.ValueMember = "PERIMES"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_VARIABLES_X_TIPOVARI_Descripcion(ByVal obNombreCampo As Object, _
                                                                                      ByVal inPosicion As Integer, _
                                                                                      ByVal obTipoVariable As Object)
        Try

            If Not obTipoVariable.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_VARIABLE

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_VARIABLE_X_TIPOVARI(obTipoVariable.SelectedValue)
                obNombreCampo.DisplayMember = "VARIDESC"
                obNombreCampo.ValueMember = "VARICODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                           ByVal inPosicion As Integer, _
                                                                                           ByVal obDepatamento As Object, _
                                                                                           ByVal obMunicipio As Object, _
                                                                                           ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_CORREGIMIENTO

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_CORREGIMIENTO(obDepatamento.SelectedValue, _
                                                                                                      obMunicipio.SelectedValue, _
                                                                                                      obSector.SelectedValue)
                obNombreCampo.DisplayMember = "CORRDESC"
                obNombreCampo.ValueMember = "CORRCODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_COMUNA_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                    ByVal inPosicion As Integer, _
                                                                                    ByVal obDepatamento As Object, _
                                                                                    ByVal obMunicipio As Object, _
                                                                                    ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_COMUNA

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_COMUNA(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
                obNombreCampo.DisplayMember = "COMUDESC"
                obNombreCampo.ValueMember = "COMUCODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                      ByVal inPosicion As Integer, _
                                                                                      ByVal obDepatamento As Object, _
                                                                                      ByVal obMunicipio As Object, _
                                                                                      ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_BARRVERE

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_BARRVERE(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
                obNombreCampo.DisplayMember = "BAVEDESC"
                obNombreCampo.ValueMember = "BAVECODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_DOCUGENE_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                      ByVal inPosicion As Integer, _
                                                                                      ByVal obDepatamento As Object, _
                                                                                      ByVal obMunicipio As Object, _
                                                                                      ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_RUTADOGE

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_DOCUGENE(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
                obNombreCampo.DisplayMember = "RUDGDESC"
                obNombreCampo.ValueMember = "RUDGDOGE"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                      ByVal inPosicion As Integer, _
                                                                                      ByVal obDepatamento As Object, _
                                                                                      ByVal obMunicipio As Object, _
                                                                                      ByVal obSector As Object, _
                                                                                      ByVal obCorregimiento As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_BARRVERE

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_BARRVERE(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue, obCorregimiento.SelectedValue)
                obNombreCampo.DisplayMember = "BAVEDESC"
                obNombreCampo.ValueMember = "BAVECODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                      ByVal inPosicion As Integer, _
                                                                                      ByVal obDepatamento As Object, _
                                                                                      ByVal obMunicipio As Object, _
                                                                                      ByVal obClase As Object, _
                                                                                      ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_TIPOCONS

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLCO_CLSE_X_TIPOCONS(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obClase.SelectedValue, obSector.SelectedValue)
                obNombreCampo.DisplayMember = "TICODESC"
                obNombreCampo.ValueMember = "TICOCODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                      ByVal inPosicion As Integer, _
                                                                                      ByVal obDepatamento As Object, _
                                                                                      ByVal obMunicipio As Object, _
                                                                                      ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_ZONAECON

                obNombreCampo.DataSource = objdatos2.fun_buscar_ZOECDEPA_X_ZOECMUNI_X_ZOECCLSE_X_MANT_ZONAECON(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
                obNombreCampo.DisplayMember = "ZOECDESC"
                obNombreCampo.ValueMember = "ZOECCODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                     ByVal inPosicion As Integer, _
                                                                                     ByVal obDepatamento As Object, _
                                                                                     ByVal obMunicipio As Object, _
                                                                                     ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_ZONAFISI

                obNombreCampo.DataSource = objdatos2.fun_buscar_ZOFIDEPA_X_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
                obNombreCampo.DisplayMember = "ZOFIDESC"
                obNombreCampo.ValueMember = "ZOFICODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZOFIACTU_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                    ByVal inPosicion As Integer, _
                                                                                    ByVal obDepatamento As Object, _
                                                                                    ByVal obMunicipio As Object, _
                                                                                    ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_ZOFIACTU

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOFIACTU(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
                obNombreCampo.DisplayMember = "ZFACDESC"
                obNombreCampo.ValueMember = "ZFACCODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZOECACTU_X_MUNICIPIO_Descripcion(ByVal obNombreCampo As Object, _
                                                                                      ByVal inPosicion As Integer, _
                                                                                      ByVal obDepatamento As Object, _
                                                                                      ByVal obMunicipio As Object, _
                                                                                      ByVal obSector As Object)
        Try

            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing And _
               Not obSector.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_ZOECACTU

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOECACTU(obDepatamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
                obNombreCampo.DisplayMember = "ZEACDESC"
                obNombreCampo.ValueMember = "ZEACCODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASSECT

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_CLASSECT_X_ESTADO
            obNombreCampo.DisplayMember = "CLSEDESC"
            obNombreCampo.ValueMember = "CLSECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZONAPLAN_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_ZONAPLAN

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_ZONAPLAN_X_ESTADO
            obNombreCampo.DisplayMember = "ZOPLDESC"
            obNombreCampo.ValueMember = "ZOPLCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_SERVPUBL_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_SERVPUBL

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_SERVPUBL_X_ESTADO
            obNombreCampo.DisplayMember = "SEPUDESC"
            obNombreCampo.ValueMember = "SEPUCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASOBUR_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASOBUR

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CLASOBUR_X_ESTADO
            obNombreCampo.DisplayMember = "CLOUDESC"
            obNombreCampo.ValueMember = "CLOUCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_NOVEDAD_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_NOVEDAD

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_NOVEDAD_X_ESTADO
            obNombreCampo.DisplayMember = "NOVEDESC"
            obNombreCampo.ValueMember = "NOVECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOLIQU_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOLIQU

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPOLIQU_X_ESTADO
            obNombreCampo.DisplayMember = "TILIDESC"
            obNombreCampo.ValueMember = "TILICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CONTCOMA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CONTCOMA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_CONTCOMA_X_ESTADO
            obNombreCampo.DisplayMember = "COCODESC"
            obNombreCampo.ValueMember = "COCOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASVERS_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASVERS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_CLASVERS_X_ESTADO
            obNombreCampo.DisplayMember = "CLVEDESC"
            obNombreCampo.ValueMember = "CLVECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CARPFOTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CARPFOTO_X_ESTADO
            obNombreCampo.DisplayMember = "CAFODESC"
            obNombreCampo.ValueMember = "CAFOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PLANCART_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PLANCART

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_PLANCART_X_ESTADO
            obNombreCampo.DisplayMember = "PLCADESC"
            obNombreCampo.ValueMember = "PLCACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_FIPRDIGI_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_FIPRDIGI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_FIPRDIGI_X_ESTADO
            obNombreCampo.DisplayMember = "FPDIDESC"
            obNombreCampo.ValueMember = "FPDICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_DOCUGENE_Descripcion(ByVal obNombreCampo As Object, _
                                                                          ByVal inPosicion As Integer, _
                                                                          ByVal obDepatamento As Object, _
                                                                          ByVal obMunicipio As Object)

        Try
            If Not obDepatamento.SelectedValue Is Nothing And _
               Not obMunicipio.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_DOCUGENE

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_MANT_DOCUGENE(obDepatamento.SelectedValue, obMunicipio.SelectedValue)
                obNombreCampo.DisplayMember = "DOGEDESC"
                obNombreCampo.ValueMember = "DOGECODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If
          

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASSUEL_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASSUEL

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CLASSUEL_X_ESTADO
            obNombreCampo.DisplayMember = "CLSUDESC"
            obNombreCampo.ValueMember = "CLSUCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASCONS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CLASCONS_X_ESTADO
            obNombreCampo.DisplayMember = "CLCODESC"
            obNombreCampo.ValueMember = "CLCOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MOBILIARIO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MOBILIARIO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MOBILIARIO_X_ESTADO
            obNombreCampo.DisplayMember = "MOBIDESC"
            obNombreCampo.ValueMember = "MOBICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_METOINVE_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_METOINVE

            obNombreCampo.DataSource = objdatos2.fun_Consultar_METOINVE_X_ESTADO
            obNombreCampo.DisplayMember = "MEINDESC"
            obNombreCampo.ValueMember = "MEINCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASPRED_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASPRED

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CLASPRED_X_ESTADO
            obNombreCampo.DisplayMember = "CLPRDESC"
            obNombreCampo.ValueMember = "CLPRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_DESTECON

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_DESTECON_X_ESTADO
            obNombreCampo.DisplayMember = "DEECDESC"
            obNombreCampo.ValueMember = "DEECCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(ByVal obNombreCampo As Object, _
                                                                          ByVal inPosicion As Integer, _
                                                                          ByVal obZOECDEPA As Object, _
                                                                          ByVal obZOECMUNI As Object, _
                                                                          ByVal obZOECCLSE As Object)

        Try
            If Not obZOECDEPA.SelectedValue Is Nothing Then
                If Not obZOECMUNI.SelectedValue Is Nothing Then
                    If Not obZOECCLSE.SelectedValue Is Nothing Then

                        Dim objdatos2 As New cla_ZONAECON

                        obNombreCampo.DataSource = objdatos2.fun_buscar_ZOECDEPA_X_ZOECMUNI_X_ZOECCLSE_X_MANT_ZONAECON(Trim(obZOECDEPA.SelectedValue), Trim(obZOECMUNI.SelectedValue), Trim(obZOECCLSE.SelectedValue))
                        obNombreCampo.DisplayMember = "ZOECDESC"
                        obNombreCampo.ValueMember = "ZOECCODI"

                        obNombreCampo.SelectedIndex = inPosicion

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(ByVal obNombreCampo As Object, _
                                                                          ByVal inPosicion As Integer, _
                                                                          ByVal obZOFIDEPA As Object, _
                                                                          ByVal obZOFIMUNI As Object, _
                                                                          ByVal obZOFICLSE As Object)

        Try
            If Not obZOFIDEPA.SelectedValue Is Nothing Then
                If Not obZOFIMUNI.SelectedValue Is Nothing Then
                    If Not obZOFICLSE.SelectedValue Is Nothing Then

                        Dim objdatos2 As New cla_ZONAFISI

                        obNombreCampo.DataSource = objdatos2.fun_buscar_ZOFIDEPA_X_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI(Trim(obZOFIDEPA.SelectedValue), Trim(obZOFIMUNI.SelectedValue), Trim(obZOFICLSE.SelectedValue))
                        obNombreCampo.DisplayMember = "ZOFIDESC"
                        obNombreCampo.ValueMember = "ZOFICODI"

                        obNombreCampo.SelectedIndex = inPosicion

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZOFIACTU_Descripcion(ByVal obNombreCampo As Object, _
                                                                         ByVal inPosicion As Integer, _
                                                                         ByVal obZFACDEPA As Object, _
                                                                         ByVal obZFACMUNI As Object, _
                                                                         ByVal obZFACCLSE As Object)

        Try
            If Not obZFACDEPA.SelectedValue Is Nothing Then
                If Not obZFACMUNI.SelectedValue Is Nothing Then
                    If Not obZFACCLSE.SelectedValue Is Nothing Then

                        Dim objdatos2 As New cla_ZOFIACTU

                        obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOFIACTU(Trim(obZFACDEPA.SelectedValue), Trim(obZFACMUNI.SelectedValue), Trim(obZFACCLSE.SelectedValue))
                        obNombreCampo.DisplayMember = "ZFACDESC"
                        obNombreCampo.ValueMember = "ZFACCODI"

                        obNombreCampo.SelectedIndex = inPosicion

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZOECACTU_Descripcion(ByVal obNombreCampo As Object, _
                                                                          ByVal inPosicion As Integer, _
                                                                          ByVal obZEACDEPA As Object, _
                                                                          ByVal obZEACMUNI As Object, _
                                                                          ByVal obZEACCLSE As Object)

        Try
            If Not obZEACDEPA.SelectedValue Is Nothing Then
                If Not obZEACMUNI.SelectedValue Is Nothing Then
                    If Not obZEACCLSE.SelectedValue Is Nothing Then

                        Dim objdatos2 As New cla_ZOECACTU

                        obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOECACTU(Trim(obZEACDEPA.SelectedValue), Trim(obZEACMUNI.SelectedValue), Trim(obZEACCLSE.SelectedValue))
                        obNombreCampo.DisplayMember = "ZEACDESC"
                        obNombreCampo.ValueMember = "ZEACCODI"

                        obNombreCampo.SelectedIndex = inPosicion

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_VIGENCIA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_campos_MANT_VIGENCIA_X_ESTADO
            obNombreCampo.DisplayMember = "VIGEDESC"
            obNombreCampo.ValueMember = "VIGECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TRATURBA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TRATURBA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TRATURBA_X_ESTADO
            obNombreCampo.DisplayMember = "TRURDESC"
            obNombreCampo.ValueMember = "TRURCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_AREAACTI_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_AREAACTI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_AREAACTI_X_ESTADO
            obNombreCampo.DisplayMember = "ARACDESC"
            obNombreCampo.ValueMember = "ARACCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_SERVICOS_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_SERVICIOS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_SERVICIOS_X_ESTADO
            obNombreCampo.DisplayMember = "SERVDESC"
            obNombreCampo.ValueMember = "SERVCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_VIAS_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_VIAS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_VIAS_X_ESTADO
            obNombreCampo.DisplayMember = "VIASDESC"
            obNombreCampo.ValueMember = "VIASCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TOPOGRAFIA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TOPOGRAFIA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TOPOGRAFIA_X_ESTADO
            obNombreCampo.DisplayMember = "TOPODESC"
            obNombreCampo.ValueMember = "TOPOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_AGUAS_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_AGUAS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_AGUAS_X_ESTADO
            obNombreCampo.DisplayMember = "AGUADESC"
            obNombreCampo.ValueMember = "AGUACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_AHT_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_AHT

            obNombreCampo.DataSource = objdatos2.fun_Consultar_AHT_X_ESTADO
            obNombreCampo.DisplayMember = "AHTDESC"
            obNombreCampo.ValueMember = "AHTCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_ESTRATO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_ESTRATO_X_ESTADO
            obNombreCampo.DisplayMember = "ESTRDESC"
            obNombreCampo.ValueMember = "ESTRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOCALI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_TIPOCALI_X_ESTADO
            obNombreCampo.DisplayMember = "TICADESC"
            obNombreCampo.ValueMember = "TICACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOIMPU

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPOIMPU_X_ESTADO
            obNombreCampo.DisplayMember = "TIIMDESC"
            obNombreCampo.ValueMember = "TIIMCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOVARI_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOVARI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPOVARI_X_ESTADO
            obNombreCampo.DisplayMember = "TIVADESC"
            obNombreCampo.ValueMember = "TIVACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_DESTINACION_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_DESTINACION

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_DESTINACION_X_ESTADO
            obNombreCampo.DisplayMember = "DESTDESC"
            obNombreCampo.ValueMember = "DESTCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PROYECTO_Descripcion(ByVal obNombreCampo As Object, _
                                                                          ByVal inPosicion As Integer, _
                                                                          ByVal obDepatamento As Object, _
                                                                          ByVal obMunicipio As Object, _
                                                                          ByVal obSector As Object)

        Try
            Dim objdatos2 As New cla_PROYECTO

            obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_PROYECTO_X_DEPA_MUNI_CLSE(obDepatamento.SelectedValue, _
                                                                                             obMunicipio.SelectedValue, _
                                                                                             obSector.SelectedValue)
            obNombreCampo.DisplayMember = "PROYDESC"
            obNombreCampo.ValueMember = "PROYCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CONCEPTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CONCEPTO_X_ESTADO
            obNombreCampo.DisplayMember = "CONCDESC"
            obNombreCampo.ValueMember = "CONCCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CABEPLPA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CABEPLPA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CABEPLPA_X_ESTADO
            obNombreCampo.DisplayMember = "CBPPDESC"
            obNombreCampo.ValueMember = "CBPPCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(ByVal obNombreCampo As Object, _
                                                                               ByVal inPosicion As Integer, _
                                                                               ByVal obTipoImpuesto As Object)
        Try

            If Not obTipoImpuesto.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_CONCEPTO

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_CONCEPTO_X_TIPOIMPU(obTipoImpuesto.SelectedValue)
                obNombreCampo.DisplayMember = "CONCDESC"
                obNombreCampo.ValueMember = "CONCCODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_SEGUDEST_Descripcion(ByVal obNombreCampo As Object, _
                                                                          ByVal inPosicion As Integer, _
                                                                          ByVal obDestinos As Object)
        Try

            If Not obDestinos.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_SEGUDEST

                obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_SEGUDEST_X_TIPOSEDE(obDestinos.SelectedValue)
                obNombreCampo.DisplayMember = "SEDEDESC"
                obNombreCampo.ValueMember = "SEDECODI"

                obNombreCampo.SelectedIndex = inPosicion

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_FORMULA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_FORMULA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_FORMULA_X_ESTADO
            obNombreCampo.DisplayMember = "FORMDESC"
            obNombreCampo.ValueMember = "FORMCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_FOPAPLPA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_FOPAPLPA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_FOPAPLPA_X_ESTADO
            obNombreCampo.DisplayMember = "FPPPDESC"
            obNombreCampo.ValueMember = "FPPPCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_COFPPLPA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_COFPPLPA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_COFPPLPA_X_ESTADO
            obNombreCampo.DisplayMember = "COFPDESC"
            obNombreCampo.ValueMember = "COFPCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PERMISO_FORMULARIO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PERMFORM

            obNombreCampo.DataSource = objdatos2.fun_Consultar_PERMFORM_X_ESTADO
            obNombreCampo.DisplayMember = "PEFODESC"
            obNombreCampo.ValueMember = "PEFOFORM"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_FORMULARIO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_FORMULARIO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_FORMULARIO_X_ESTADO
            obNombreCampo.DisplayMember = "FORMDESC"
            obNombreCampo.ValueMember = "FORMCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MATECAMP_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MATECAMP

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_MATECAMP_X_ESTADO
            obNombreCampo.DisplayMember = "MACADESC"
            obNombreCampo.ValueMember = "MACACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CAUSACTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CAUSACTO
            obNombreCampo.DisplayMember = "CAACDESC"
            obNombreCampo.ValueMember = "CAACCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CONTRASENA_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos1 As New cla_CONTRASENA

            obNombreCampo.DataSource = objdatos1.fun_Consultar_USUARIO_CONTRASENA_X_ESTADO
            obNombreCampo.DisplayMember = "CONTUSUA"
            obNombreCampo.ValueMember = "CONTUSUA"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CONTRASENA(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos1 As New cla_CONTRASENA

            obNombreCampo.DataSource = objdatos1.fun_Consultar_USUARIO_CONTRASENA_X_ESTADO
            obNombreCampo.DisplayMember = "CONTUSUA"
            obNombreCampo.ValueMember = "CONTUSUA"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try

            Dim objdatos2 As New cla_USUARIO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Nombre_Completo_USUARIO
            obNombreCampo.DisplayMember = "USUANOMB"
            obNombreCampo.ValueMember = "USUANUDO"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_NOMBRE_USUARIO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try

            Dim objdatos2 As New cla_USUARIO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Nombre_Completo_USUARIO
            obNombreCampo.DisplayMember = "NOMBRE"
            obNombreCampo.ValueMember = "USUANUDO"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPODOCU

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPODOCU_X_ESTADO
            obNombreCampo.DisplayMember = "TIDODESC"
            obNombreCampo.ValueMember = "TIDOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CALIPROP

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CALIPROP_X_ESTADO
            obNombreCampo.DisplayMember = "CAPRDESC"
            obNombreCampo.ValueMember = "CAPRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_SEXO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_SEXO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_SEXO_X_ESTADO
            obNombreCampo.DisplayMember = "SEXODESC"
            obNombreCampo.ValueMember = "SEXOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOTRAM

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPOTRAM
            obNombreCampo.DisplayMember = "TITRDESC"
            obNombreCampo.ValueMember = "TITRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_SOLICITANTE

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_SOLICITANTE
            obNombreCampo.DisplayMember = "SOLIDESC"
            obNombreCampo.ValueMember = "SOLICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASIFICACION_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASIFICACION

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASIFICACION
            obNombreCampo.DisplayMember = "CLASDESC"
            obNombreCampo.ValueMember = "CLASCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MEDIRESE_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MEDIRESE

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_MEDIRESE
            obNombreCampo.DisplayMember = "MEREDESC"
            obNombreCampo.ValueMember = "MERECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MEDINOTI_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MEDINOTI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_MEDINOTI
            obNombreCampo.DisplayMember = "MENODESC"
            obNombreCampo.ValueMember = "MENOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_DIVISION_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_DIVISION

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_DIVISION
            obNombreCampo.DisplayMember = "DIVIDESC"
            obNombreCampo.ValueMember = "DIVICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_RESOAJUS_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_RESOAJUS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_RESOAJUS
            obNombreCampo.DisplayMember = "REAJDESC"
            obNombreCampo.ValueMember = "REAJCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ACTOADMI_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_ACTOADMI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_ACTOADMI
            obNombreCampo.DisplayMember = "ACADDESC"
            obNombreCampo.ValueMember = "ACADCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASENTI_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASENTI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASENTI
            obNombreCampo.DisplayMember = "CLENDESC"
            obNombreCampo.ValueMember = "CLENCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CATESUEL

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_CATESUEL_X_ESTADO
            obNombreCampo.DisplayMember = "CASUDESC"
            obNombreCampo.ValueMember = "CASUCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CARAPRED

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_CARAPRED_X_ESTADO
            obNombreCampo.DisplayMember = "CAPRDESC"
            obNombreCampo.ValueMember = "CAPRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MODOADQU

            obNombreCampo.DataSource = objdatos2.fun_Consultar_Campos_MANT_MODOADQU_X_ESTADO
            obNombreCampo.DisplayMember = "MOADDESC"
            obNombreCampo.ValueMember = "MOADCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPORESO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPORESO_X_ESTADO
            obNombreCampo.DisplayMember = "TIREDESC"
            obNombreCampo.ValueMember = "TIRECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PROCEDIMIENTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_PROCEDIMIENTO_X_ESTADO
            obNombreCampo.DisplayMember = "PROCDESC"
            obNombreCampo.ValueMember = "PROCCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_INSERTAR_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PROCEDIMIENTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_PROCEDIMIENTO_INSERTAR_X_ESTADO
            obNombreCampo.DisplayMember = "PROCDESC"
            obNombreCampo.ValueMember = "PROCCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_ELIMINAR_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PROCEDIMIENTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_PROCEDIMIENTO_ELIMINAR_X_ESTADO
            obNombreCampo.DisplayMember = "PROCDESC"
            obNombreCampo.ValueMember = "PROCCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PROCEDIMIENTO_CONSULTAR_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PROCEDIMIENTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_PROCEDIMIENTO_CONSULTAR_X_ESTADO
            obNombreCampo.DisplayMember = "PROCDESC"
            obNombreCampo.ValueMember = "PROCCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TABLAS_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TABLAS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TABLAS_X_ESTADO
            obNombreCampo.DisplayMember = "TABLDESC"
            obNombreCampo.ValueMember = "TABLCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CAMPOS_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CAMPOS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CAMPOS_X_ESTADO
            obNombreCampo.DisplayMember = "CAMPDESC"
            obNombreCampo.ValueMember = "CAMPCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_ESTADO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_ESTADO_X_ESTADO
            obNombreCampo.DisplayMember = "ESTADESC"
            obNombreCampo.ValueMember = "ESTACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_Descripcion(ByVal obNombreCampo As Object, _
                                                                               ByVal inPosicion As Integer, _
                                                                               ByVal obDepartamento As Object, _
                                                                               ByVal obMunicipio As Object, _
                                                                               ByVal obSector As Object)

        Try
            Dim objdatos2 As New cla_CORREGIMIENTO

            obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_CORREGIMIENTO(obDepartamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
            obNombreCampo.DisplayMember = "CORRDESC"
            obNombreCampo.ValueMember = "CORRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_COMUNA_Descripcion(ByVal obNombreCampo As Object, _
                                                                              ByVal inPosicion As Integer, _
                                                                              ByVal obDepartamento As Object, _
                                                                              ByVal obMunicipio As Object, _
                                                                              ByVal obSector As Object)

        Try
            Dim objdatos2 As New cla_COMUNA

            obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_COMUNA(obDepartamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
            obNombreCampo.DisplayMember = "COMUDESC"
            obNombreCampo.ValueMember = "COMUCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_Descripcion(ByVal obNombreCampo As Object, _
                                                                             ByVal inPosicion As Integer, _
                                                                             ByVal obDepartamento As Object, _
                                                                             ByVal obMunicipio As Object, _
                                                                             ByVal obSector As Object)

        Try
            Dim objdatos2 As New cla_BARRVERE

            obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_BARRVERE(obDepartamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue)
            obNombreCampo.DisplayMember = "BAVEDESC"
            obNombreCampo.ValueMember = "BAVECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_Descripcion(ByVal obNombreCampo As Object, _
                                                                          ByVal inPosicion As Integer, _
                                                                          ByVal obDepartamento As Object, _
                                                                          ByVal obMunicipio As Object, _
                                                                          ByVal obSector As Object, _
                                                                          ByVal obCorregimiento As Object)

        Try
            Dim objdatos2 As New cla_BARRVERE

            obNombreCampo.DataSource = objdatos2.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_BARRVERE(obDepartamento.SelectedValue, obMunicipio.SelectedValue, obSector.SelectedValue, obCorregimiento.SelectedValue)
            obNombreCampo.DisplayMember = "BAVEDESC"
            obNombreCampo.ValueMember = "BAVECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    ''' <summary>
    ''' carga el codigo
    ''' </summary>
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_DEPARTAMENTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_DEPARTAMENTO_X_ESTADO
            obNombreCampo.DisplayMember = "DEPACODI"
            obNombreCampo.ValueMember = "DEPACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(ByVal obNombreCampo As Object, _
                                                                              ByVal stDepatamento As String)

        Try
            Dim objdatos2 As New cla_MUNICIPIO

            obNombreCampo.DataSource = objdatos2.fun_Buscar_MUNICIPIO_X_DEPARTAMENTO_MANT_MUNICIPIO(stDepatamento)
            obNombreCampo.DisplayMember = "MUNICODI"
            obNombreCampo.ValueMember = "MUNICODI"

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PLANPARC

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_PLANPARC_X_ESTADO
            obNombreCampo.DisplayMember = "PLPADESC"
            obNombreCampo.ValueMember = "PLPAIDRE"

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MUNICIPIO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_MUNICIPIO_X_ESTADO
            obNombreCampo.DisplayMember = "MUNICODI"
            obNombreCampo.ValueMember = "MUNICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASCONS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CLASCONS_X_ESTADO
            obNombreCampo.DisplayMember = "CLCOCODI"
            obNombreCampo.ValueMember = "CLCOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASSECT

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CLASSECT_X_ESTADO
            obNombreCampo.DisplayMember = "CLSECODI"
            obNombreCampo.ValueMember = "CLSECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CALIPROP

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CALIPROP_X_ESTADO
            obNombreCampo.DisplayMember = "CAPRCODI"
            obNombreCampo.ValueMember = "CAPRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CARAPRED

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CARAPRED_X_ESTADO
            obNombreCampo.DisplayMember = "CAPRCODI"
            obNombreCampo.ValueMember = "CAPRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CATESUEL

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CATESUEL_X_ESTADO
            obNombreCampo.DisplayMember = "CASUCODI"
            obNombreCampo.ValueMember = "CASUCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CATEPRED(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CATEPRED

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CATEPRED_X_ESTADO
            obNombreCampo.DisplayMember = "CAPRCODI"
            obNombreCampo.ValueMember = "CAPRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_DESTECON

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_DESTECON_X_ESTADO
            obNombreCampo.DisplayMember = "DEECCODI"
            obNombreCampo.ValueMember = "DEECCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MODOADQU

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_MODOADQU_X_ESTADO
            obNombreCampo.DisplayMember = "MOADCODI"
            obNombreCampo.ValueMember = "MOADCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_NOTARIA(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_NOTARIA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_NOTARIA_X_ESTADO
            obNombreCampo.DisplayMember = "NOTACODI"
            obNombreCampo.ValueMember = "NOTACODI"

            'obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_SEXO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_SEXO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_SEXO_X_ESTADO
            obNombreCampo.DisplayMember = "SEXOCODI"
            obNombreCampo.ValueMember = "SEXOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_PUNTCARD(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PUNTCARD

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_PUNTCARD_X_ESTADO
            obNombreCampo.DisplayMember = "PUCACODI"
            obNombreCampo.ValueMember = "PUCACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOCONS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPOCONS_X_ESTADO
            obNombreCampo.DisplayMember = "TICOCODI"
            obNombreCampo.ValueMember = "TICOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_CLASCONS(ByVal obNombreCampo As Object, _
                                                                         ByVal stTICODEPA As String, _
                                                                         ByVal stTICOMUNI As String, _
                                                                         ByVal stTICOCLCO As String, _
                                                                         ByVal stTICOCLSE As String)

        Try
            Dim objdatos2 As New cla_TIPOCONS

            obNombreCampo.DataSource = objdatos2.fun_buscar_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(stTICODEPA), Trim(stTICOMUNI), Trim(stTICOCLCO), Trim(stTICOCLSE))
            obNombreCampo.DisplayMember = "TICOCODI"
            obNombreCampo.ValueMember = "TICOCODI"

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_CLASCONS_X_TIPOCONS(ByVal obNombreCampo As Object, _
                                                                         ByVal stTICODEPA As String, _
                                                                         ByVal stTICOMUNI As String, _
                                                                         ByVal stTICOCLCO As String, _
                                                                         ByVal stTICOCLSE As String, _
                                                                         ByVal stTICOTIPO As String)

        Try
            Dim objdatos2 As New cla_TIPOCONS

            obNombreCampo.DataSource = objdatos2.fun_buscar_TIPOCONS_X_CLASCONS_X_TIPOCONS_MANT_TIPOCONS(Trim(stTICODEPA), Trim(stTICOMUNI), Trim(stTICOCLCO), Trim(stTICOCLSE), Trim(stTICOTIPO))
            obNombreCampo.DisplayMember = "TICOCODI"
            obNombreCampo.ValueMember = "TICOCODI"

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOCALI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPOCALI_X_ESTADO
            obNombreCampo.DisplayMember = "TICACODI"
            obNombreCampo.ValueMember = "TICACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPODOCU

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPODOCU_X_ESTADO
            obNombreCampo.DisplayMember = "TIDOCODI"
            obNombreCampo.ValueMember = "TIDOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPORESO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_TIPORESO_X_ESTADO
            obNombreCampo.DisplayMember = "TIRECODI"
            obNombreCampo.ValueMember = "TIRECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON(ByVal obNombreCampo As Object, _
                                                              ByVal inPosicion As Integer, _
                                                              ByVal stZOECDEPA As String, _
                                                              ByVal stZOECMUNI As String, _
                                                              ByVal stZOECCLSE As String)

        Try
            Dim objdatos2 As New cla_ZONAECON

            If Trim(stZOECCLSE) = "" Then
                stZOECCLSE = "0"
            End If

            obNombreCampo.DataSource = objdatos2.fun_buscar_ZOECDEPA_X_ZOECMUNI_X_ZOECCLSE_X_MANT_ZONAECON(Trim(stZOECDEPA), Trim(stZOECMUNI), Trim(stZOECCLSE))
            obNombreCampo.DisplayMember = "ZOECCODI"
            obNombreCampo.ValueMember = "ZOECCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI(ByVal obNombreCampo As Object, _
                                                               ByVal inPosicion As Integer, _
                                                               ByVal stZOFIDEPA As String, _
                                                               ByVal stZOFIMUNI As String, _
                                                               ByVal stZOFICLSE As String)

        Try
            Dim objdatos2 As New cla_ZONAFISI

            obNombreCampo.DataSource = objdatos2.fun_buscar_ZOFIDEPA_X_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI(Trim(stZOFIDEPA), Trim(stZOFIMUNI), Trim(stZOFICLSE))
            obNombreCampo.DisplayMember = "ZOFICODI"
            obNombreCampo.ValueMember = "ZOFICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CODICALI(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CODICALI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CODICALI_X_ESTADO
            obNombreCampo.DisplayMember = "COCACODI"
            obNombreCampo.ValueMember = "COCACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CODICACO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CODICACO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CODICACO_X_ESTADO
            obNombreCampo.DisplayMember = "COCCCODI"
            obNombreCampo.ValueMember = "COCCCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_VIGENCIA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_VIGENCIA_X_ESTADO
            obNombreCampo.DisplayMember = "VIGECODI"
            obNombreCampo.ValueMember = "VIGECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_ESTADO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_ESTADO_X_ESTADO
            obNombreCampo.DisplayMember = "ESTADESC"
            obNombreCampo.ValueMember = "ESTACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CABEPLPA(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CABEPLPA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CABEPLPA_X_ESTADO
            obNombreCampo.DisplayMember = "CBPPCODI"
            obNombreCampo.ValueMember = "CBPPCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_ESTRATO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_ESTRATO_X_ESTADO
            obNombreCampo.DisplayMember = "ESTRCODI"
            obNombreCampo.ValueMember = "ESTRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_MOBILIARIO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MOBILIARIO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MOBILIARIO_X_ESTADO
            obNombreCampo.DisplayMember = "MOBICODI"
            obNombreCampo.ValueMember = "MOBICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_METOINVE(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_METOINVE

            obNombreCampo.DataSource = objdatos2.fun_Consultar_METOINVE_X_ESTADO
            obNombreCampo.DisplayMember = "MEINCODI"
            obNombreCampo.ValueMember = "MEINCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CAUSACTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_MANT_CAUSACTO_X_ESTADO
            obNombreCampo.DisplayMember = "CAACCODI"
            obNombreCampo.ValueMember = "CAACCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub


End Module
