Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports REGLAS_DEL_NEGOCIO

Module mod_fun_CARGAR_ComboBox_CON_TODOS_LOS_DATOS

    '=============================================
    ' CARGA LOS COMBOBOX CON LOS REGISTROS ACTIVOS
    '=============================================

    ''' <summary>
    ''' CARGA LOS COMBOBOX CON TODOS LOS REGISTROS ACTIVOS E INACTIVOS( Nombre del campo, Posicion de la seleccion )
    ''' EJ: (cboFIPRCLSE,cboFIPRCLSE.SelectedIndex)
    ''' </summary>
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_DEPARTAMENTO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_DEPARTAMENTO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            obNombreCampo.DisplayMember = "DEPACODI"
            obNombreCampo.ValueMember = "DEPACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_MUNICIPIO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MUNICIPIO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            obNombreCampo.DisplayMember = "MUNICODI"
            obNombreCampo.ValueMember = "MUNICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_CLASCONS(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASCONS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASCONS
            obNombreCampo.DisplayMember = "CLCOCODI"
            obNombreCampo.ValueMember = "CLCOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_CLASSECT(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CLASSECT

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            obNombreCampo.DisplayMember = "CLSECODI"
            obNombreCampo.ValueMember = "CLSECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_CALIPROP(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CALIPROP

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CALIPROP
            obNombreCampo.DisplayMember = "CAPRCODI"
            obNombreCampo.ValueMember = "CAPRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_CARAPRED(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CARAPRED

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CARAPRED
            obNombreCampo.DisplayMember = "CAPRCODI"
            obNombreCampo.ValueMember = "CAPRCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_CATESUEL(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CATESUEL

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CATESUEL
            obNombreCampo.DisplayMember = "CASUCODI"
            obNombreCampo.ValueMember = "CASUCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_DESTECON(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_DESTECON

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_DESTECON
            obNombreCampo.DisplayMember = "DEECCODI"
            obNombreCampo.ValueMember = "DEECCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_MODOADQU(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_MODOADQU

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_MODOADQU
            obNombreCampo.DisplayMember = "MOADCODI"
            obNombreCampo.ValueMember = "MOADCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_NOTARIA(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_NOTARIA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_NOTARIA
            obNombreCampo.DisplayMember = "NOTACODI"
            obNombreCampo.ValueMember = "NOTACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_SEXO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_SEXO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_SEXO
            obNombreCampo.DisplayMember = "SEXOCODI"
            obNombreCampo.ValueMember = "SEXOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_PUNTCARD(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_PUNTCARD

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_PUNTCARD
            obNombreCampo.DisplayMember = "PUCACODI"
            obNombreCampo.ValueMember = "PUCACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPOCONS(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOCONS

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPOCONS
            obNombreCampo.DisplayMember = "TICOCODI"
            obNombreCampo.ValueMember = "TICOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPOCALI(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPOCALI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPOCALI
            obNombreCampo.DisplayMember = "TICACODI"
            obNombreCampo.ValueMember = "TICACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPODOCU(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPODOCU

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPODOCU
            obNombreCampo.DisplayMember = "TIDOCODI"
            obNombreCampo.ValueMember = "TIDOCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPORESU(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_TIPORESO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPORESO
            obNombreCampo.DisplayMember = "TIRECODI"
            obNombreCampo.ValueMember = "TIRECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_ZONAECON(ByVal obNombreCampo As Object, _
                                                                ByVal inPosicion As Integer, _
                                                                ByVal stZOECDEPA As String, _
                                                                ByVal stZOECMUNI As String, _
                                                                ByVal stZOECCLSE As String)

        Try
            Dim objdatos2 As New cla_ZONAECON

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_ZONAECON(Trim(stZOECDEPA), Trim(stZOECMUNI), Trim(stZOECCLSE))
            obNombreCampo.DisplayMember = "ZOECCODI"
            obNombreCampo.ValueMember = "ZOECCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_ZONAFISI(ByVal obNombreCampo As Object, _
                                                                ByVal inPosicion As Integer, _
                                                                ByVal stZOFIDEPA As String, _
                                                                ByVal stZOFIMUNI As String, _
                                                                ByVal stZOFICLSE As String)

        Try
            Dim objdatos2 As New cla_ZONAFISI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_ZONAFISI(Trim(stZOFIDEPA), Trim(stZOFIMUNI), Trim(stZOFICLSE))
            obNombreCampo.DisplayMember = "ZOFICODI"
            obNombreCampo.ValueMember = "ZOFICODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_CODICALI(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CODICALI

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CODICALI
            obNombreCampo.DisplayMember = "COCACODI"
            obNombreCampo.ValueMember = "COCACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_CODICACO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_CODICACO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CODICACO
            obNombreCampo.DisplayMember = "COCCCODI"
            obNombreCampo.ValueMember = "COCCCODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_VIGENCIA(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_VIGENCIA

            obNombreCampo.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            obNombreCampo.DisplayMember = "VIGECODI"
            obNombreCampo.ValueMember = "VIGECODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Public Sub fun_Cargar_ComboBox_Con_Todos_Los_Datos_ESTADO(ByVal obNombreCampo As Object, ByVal inPosicion As Integer)

        Try
            Dim objdatos2 As New cla_ESTADO

            obNombreCampo.DataSource = objdatos2.fun_Consultar_TODOS_LOS_ESTADOS
            obNombreCampo.DisplayMember = "ESTADESC"
            obNombreCampo.ValueMember = "ESTACODI"

            obNombreCampo.SelectedIndex = inPosicion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

End Module
