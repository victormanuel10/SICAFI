Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text
Imports System.Math

Module mod_fun_GENERA_HISTORICO_DE_ZONAS_IMPUESTO

    '================================================
    '*** GENERA HISTORICO DE LIQUIDACIÓN IMPUESTO ***
    '================================================

#Region "VARIABLES"

#Region "Tablas"

    ' Tabla 0
    Private dt_FICHPRED As New DataTable
    ' Tabla 1
    'Private dt_FIPRDEEC As New DataTable
    ' Tabla 2
    'Private dt_FIPRPROP As New DataTable
    ' Tabla 3
    'Private dt_FIPRCONS As New DataTable
    ' Tabla 4
    'Private dt_FIPRCACO As New DataTable
    ' Tabla 5
    'Private dt_FIPRLIND As New DataTable
    ' Tabla 6
    'Private dt_FIPRCART As New DataTable
    ' Tabla 7
    Private dt_FIPRZOEC As New DataTable
    ' Tabla 8
    Private dt_FIPRZOFI As New DataTable

#End Region

#Region "Ficha Predial"

    Private vl_stHIZODEPA As String = ""
    Private vl_stHIZOMUNI As String = ""
    Private vl_stHIZOCORR As String = ""
    Private vl_stHIZOBARR As String = ""
    Private vl_stHIZOMANZ As String = ""
    Private vl_stHIZOPRED As String = ""
    Private vl_stHIZOEDIF As String = ""
    Private vl_stHIZOUNPR As String = ""
    Private vl_inHIZOCLSE As Integer
    Private vl_inHIZOTIFI As Integer
    Private vl_inHIZONUFI As Integer
    Private vl_inHIZOVIGE As Integer
    Private vl_boHIZOZOEC As Boolean = False
    Private vl_boHIZOZOFI As Boolean = False

#End Region

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_GENERA_HISTORICO_DE_ZONAS_IMPUESTO(ByVal o_inFIPRNUFI As Integer, _
                                                      ByVal o_stHIZODEPA As String, _
                                                      ByVal o_stHIZOMUNI As String, _
                                                      ByVal o_stHIZOCORR As String, _
                                                      ByVal o_stHIZOBARR As String, _
                                                      ByVal o_stHIZOMANZ As String, _
                                                      ByVal o_stHIZOPRED As String, _
                                                      ByVal o_stHIZOEDIF As String, _
                                                      ByVal o_stHIZOUNPR As String, _
                                                      ByVal o_inHIZOCLSE As Integer, _
                                                      ByVal o_inHIZOVIGE As Integer, _
                                                      ByVal o_inHIZOTIFI As Integer, _
                                                      ByVal o_boHIZOZOEC As Boolean, _
                                                      ByVal o_boHIZOZOFI As Boolean)

        Try
            ' declaro variables
            vl_inHIZONUFI = o_inFIPRNUFI
            vl_stHIZODEPA = o_stHIZODEPA
            vl_stHIZOMUNI = o_stHIZOMUNI
            vl_stHIZOCORR = o_stHIZOCORR
            vl_stHIZOBARR = o_stHIZOBARR
            vl_stHIZOMANZ = o_stHIZOMANZ
            vl_stHIZOPRED = o_stHIZOPRED
            vl_stHIZOEDIF = o_stHIZOEDIF
            vl_stHIZOUNPR = o_stHIZOUNPR
            vl_inHIZOCLSE = o_inHIZOCLSE
            vl_inHIZOVIGE = o_inHIZOVIGE
            vl_inHIZOTIFI = o_inHIZOTIFI
            vl_boHIZOZOEC = o_boHIZOZOEC
            vl_boHIZOZOFI = o_boHIZOZOFI

            ' Carga las tablas
            pro_CargarTablasFichaPredial()

            ' Liquida avaluo por caracteritica de predio
            If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Or dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                If Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) = "ac" Then

                    ' Liquida caracteristica (1) Normal, (2) RPH Edificio, (3) RPH Parcelación, (4) RPH Condominio, (5) Parque Cementerio, (6) Embalse, (7) Baldio
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                        ' inserta zona economica
                        If vl_boHIZOZOEC = True Then
                            pro_GuardarHistoricoDeZonaEconomica()
                        End If

                        ' inserta zona fisica
                        If vl_boHIZOZOFI = True Then
                            pro_GuardarHistoricoDeZonaFisica()
                        End If

                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "Liquida Historicos de Liquidacion Impuestos")
        End Try

    End Sub

    Private Sub pro_CargarTablasFichaPredial()

        Dim objdatos As New cla_FIPRAVAL
        Dim ds As New DataSet

        ds = objdatos.fun_Consultar_TABLAS_FICHA_PREDIAL(vl_inHIZONUFI)

        ' instancia las tablas
        dt_FICHPRED = New DataTable
        dt_FIPRZOEC = New DataTable
        dt_FIPRZOFI = New DataTable

        ' Tabla 0
        dt_FICHPRED = ds.Tables(0)
        ' Tabla 7
        dt_FIPRZOEC = ds.Tables(7)
        ' Tabla 8
        dt_FIPRZOFI = ds.Tables(8)
      
    End Sub
    Private Sub pro_GuardarHistoricoDeZonaEconomica()

        Try
            ' declara la variable
            vl_inHIZOCLSE = dt_FICHPRED.Rows(0).Item("FIPRCLSE")
            vl_inHIZOTIFI = dt_FICHPRED.Rows(0).Item("FIPRTIFI")

            ' declara la variable
            Dim stFIPRESTA As String = "ac"

            ' Guarda las zonas de la ficha predial
            If vl_inHIZOTIFI = 0 Then

                ' declara la instancia
                Dim objZonasFicha As New cla_FIPRZOEC
                Dim tblZonasFicha As New DataTable

                tblZonasFicha = objZonasFicha.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(vl_inHIZONUFI)

                If tblZonasFicha.Rows.Count > 0 Then

                    'declara la instancia
                    Dim objZonasImpuesto1 As New cla_HISTZONA

                    ' elimina las zonas
                    objZonasImpuesto1.fun_Eliminar_NUFI_CLSE_VIGE_X_HISTZONA(vl_inHIZONUFI, vl_inHIZOCLSE, vl_inHIZOVIGE)

                    Dim k As Integer = 0

                    For k = 0 To tblZonasFicha.Rows.Count - 1

                        Dim inZonaEconomica As Integer = tblZonasFicha.Rows(k).Item("FPZEZOEC")
                        Dim inPorcentaje As Integer = tblZonasFicha.Rows(k).Item("FPZEPORC")

                        'declara la instancia
                        Dim objZonasImpuesto2 As New cla_HISTZONA

                        objZonasImpuesto2.fun_Insertar_HISTZONA(vl_inHIZONUFI, _
                                                                vl_stHIZODEPA, _
                                                                vl_stHIZOMUNI, _
                                                                vl_stHIZOCORR, _
                                                                vl_stHIZOBARR, _
                                                                vl_stHIZOMANZ, _
                                                                vl_stHIZOPRED, _
                                                                vl_stHIZOEDIF, _
                                                                vl_stHIZOUNPR, _
                                                                vl_inHIZOTIFI, _
                                                                vl_inHIZOCLSE, _
                                                                vl_inHIZOVIGE, _
                                                                inZonaEconomica, _
                                                                inPorcentaje, _
                                                                stFIPRESTA)


                    Next

                End If

                ' ' Guarda las zonas de la ficha resumen
            ElseIf vl_inHIZOTIFI = 1 Or vl_inHIZOTIFI = 2 Then

                ' declara la instancia
                Dim objZonasFicha As New cla_FIPRZOEC
                Dim tblZonasFicha As New DataTable

                tblZonasFicha = objZonasFicha.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(vl_inHIZONUFI)

                If tblZonasFicha.Rows.Count > 0 Then

                    'declara la instancia
                    Dim objZonasImpuesto1 As New cla_HISTZONA

                    ' elimina las zonas
                    objZonasImpuesto1.fun_Eliminar_ZONAS_FICHA_X_HISTZONA(vl_stHIZODEPA, vl_stHIZOMUNI, vl_stHIZOCORR, vl_stHIZOBARR, vl_stHIZOMANZ, vl_stHIZOPRED, vl_stHIZOEDIF, vl_stHIZOUNPR, vl_inHIZOCLSE, vl_inHIZOVIGE, vl_inHIZOTIFI)

                    Dim k As Integer = 0

                    For k = 0 To tblZonasFicha.Rows.Count - 1

                        Dim inZonaEconomica As Integer = tblZonasFicha.Rows(k).Item("FPZEZOEC")
                        Dim inPorcentaje As Integer = tblZonasFicha.Rows(k).Item("FPZEPORC")

                        'declara la instancia
                        Dim objZonasImpuesto2 As New cla_HISTZONA

                        objZonasImpuesto2.fun_Insertar_HISTZONA(vl_inHIZONUFI, _
                                                                vl_stHIZODEPA, _
                                                                vl_stHIZOMUNI, _
                                                                vl_stHIZOCORR, _
                                                                vl_stHIZOBARR, _
                                                                vl_stHIZOMANZ, _
                                                                vl_stHIZOPRED, _
                                                                vl_stHIZOEDIF, _
                                                                vl_stHIZOUNPR, _
                                                                vl_inHIZOTIFI, _
                                                                vl_inHIZOCLSE, _
                                                                vl_inHIZOVIGE, _
                                                                inZonaEconomica, _
                                                                inPorcentaje, _
                                                                stFIPRESTA)


                    Next

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarHistoricoDeZonaFisica()

        Try
            ' declara la variable
            vl_inHIZOCLSE = dt_FICHPRED.Rows(0).Item("FIPRCLSE")
            vl_inHIZOTIFI = dt_FICHPRED.Rows(0).Item("FIPRTIFI")

            ' declara la variable
            Dim stFIPRESTA As String = "ac"

            ' Guarda las zonas de la ficha predial
            If vl_inHIZOTIFI = 0 Then

                ' declara la instancia
                Dim objZonasFicha As New cla_FIPRZOFI
                Dim tblZonasFicha As New DataTable

                tblZonasFicha = objZonasFicha.fun_Consultar_FIPRZOFI_X_FICHA_PREDIAL(vl_inHIZONUFI)

                If tblZonasFicha.Rows.Count > 0 Then

                    'declara la instancia
                    Dim objZonasImpuesto1 As New cla_HISTZOFI

                    ' elimina las zonas
                    objZonasImpuesto1.fun_Eliminar_NUFI_CLSE_VIGE_X_HISTZOFI(vl_inHIZONUFI, vl_inHIZOCLSE, vl_inHIZOVIGE)

                    Dim k As Integer = 0

                    For k = 0 To tblZonasFicha.Rows.Count - 1

                        Dim inZonaFisica As Integer = tblZonasFicha.Rows(k).Item("FPZFZOEC")
                        Dim inPorcentaje As Integer = tblZonasFicha.Rows(k).Item("FPZFPORC")

                        'declara la instancia
                        Dim objZonasImpuesto2 As New cla_HISTZOFI

                        objZonasImpuesto2.fun_Insertar_HISTZOFI(vl_inHIZONUFI, _
                                                                vl_stHIZODEPA, _
                                                                vl_stHIZOMUNI, _
                                                                vl_stHIZOCORR, _
                                                                vl_stHIZOBARR, _
                                                                vl_stHIZOMANZ, _
                                                                vl_stHIZOPRED, _
                                                                vl_stHIZOEDIF, _
                                                                vl_stHIZOUNPR, _
                                                                vl_inHIZOTIFI, _
                                                                vl_inHIZOCLSE, _
                                                                vl_inHIZOVIGE, _
                                                                inZonaFisica, _
                                                                inPorcentaje, _
                                                                stFIPRESTA)


                    Next

                End If

                ' ' Guarda las zonas de la ficha resumen
            ElseIf vl_inHIZOTIFI = 1 Or vl_inHIZOTIFI = 2 Then

                ' declara la instancia
                Dim objZonasFicha As New cla_FIPRZOFI
                Dim tblZonasFicha As New DataTable

                tblZonasFicha = objZonasFicha.fun_Consultar_FIPRZOFI_X_FICHA_PREDIAL(vl_inHIZONUFI)

                If tblZonasFicha.Rows.Count > 0 Then

                    'declara la instancia
                    Dim objZonasImpuesto1 As New cla_HISTZOFI

                    ' elimina las zonas
                    objZonasImpuesto1.fun_Eliminar_ZONAS_FICHA_X_HISTZOFI(vl_stHIZODEPA, vl_stHIZOMUNI, vl_stHIZOCORR, vl_stHIZOBARR, vl_stHIZOMANZ, vl_stHIZOPRED, vl_stHIZOEDIF, vl_stHIZOUNPR, vl_inHIZOCLSE, vl_inHIZOVIGE, vl_inHIZOTIFI)

                    Dim k As Integer = 0

                    For k = 0 To tblZonasFicha.Rows.Count - 1

                        Dim inZonaFisica As Integer = tblZonasFicha.Rows(k).Item("FPZFZOEC")
                        Dim inPorcentaje As Integer = tblZonasFicha.Rows(k).Item("FPZFPORC")

                        'declara la instancia
                        Dim objZonasImpuesto2 As New cla_HISTZOFI

                        objZonasImpuesto2.fun_Insertar_HISTZOFI(vl_inHIZONUFI, _
                                                                vl_stHIZODEPA, _
                                                                vl_stHIZOMUNI, _
                                                                vl_stHIZOCORR, _
                                                                vl_stHIZOBARR, _
                                                                vl_stHIZOMANZ, _
                                                                vl_stHIZOPRED, _
                                                                vl_stHIZOEDIF, _
                                                                vl_stHIZOUNPR, _
                                                                vl_inHIZOTIFI, _
                                                                vl_inHIZOCLSE, _
                                                                vl_inHIZOVIGE, _
                                                                inZonaFisica, _
                                                                inPorcentaje, _
                                                                stFIPRESTA)


                    Next

                End If

            End If



        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

End Module
