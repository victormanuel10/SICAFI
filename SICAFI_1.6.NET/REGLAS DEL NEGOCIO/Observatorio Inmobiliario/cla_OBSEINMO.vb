Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBSEINMO

    '=======================================
    '*** CLASE OBSERVATORIO INMOBILIARIO ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBSEINMO(ByVal obOBINCECA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obOBINCECA) = True Then

                Dim objdatos1 As New cla_OBSEINMO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_CECA_X_OBSEINMO(obOBINCECA)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos. " & "Cadula catastral: " & Trim(obOBINCECA), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    obOBINCECA.Focus()
                    boRespuesta = False
                Else
                    boRespuesta = True
                End If

            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function


    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_OBSEINMO(ByVal inOBINSECU As Integer, _
                                            ByVal stOBINCECA As String, _
                                            ByVal inOBINNUFI As Integer, _
                                            ByVal stOBINDESC As String, _
                                            ByVal stOBINDIRE As String, _
                                            ByVal stOBINCOMU As String, _
                                            ByVal stOBINDEPA As String, _
                                            ByVal stOBINMUNI As String, _
                                            ByVal stOBINCORR As String, _
                                            ByVal stOBINBARR As String, _
                                            ByVal stOBINMANZ As String, _
                                            ByVal stOBINPRED As String, _
                                            ByVal stOBINEDIF As String, _
                                            ByVal stOBINUNPR As String, _
                                            ByVal inOBINCLSE As Integer, _
                                            ByVal inOBINCAPR As Integer, _
                                            ByVal loOBINAVCA As Long, _
                                            ByVal loOBINAVCO As Long, _
                                            ByVal inOBINVM2T As Integer, _
                                            ByVal inOBINVM2C As Integer, _
                                            ByVal inOBINARTE As Integer, _
                                            ByVal inOBINARCO As Integer, _
                                            ByVal inOBINVIGE As Integer, _
                                            ByVal inOBINEDCO As Integer, _
                                            ByVal inOBINESTR As Integer, _
                                            ByVal inOBINZOEC As Integer, _
                                            ByVal stOBINTIPO As String, _
                                            ByVal inOBINCLCO As Integer, _
                                            ByVal stOBINTICO As String, _
                                            ByVal inOBINNUPI As Integer, _
                                            ByVal inOBINMOBI As Integer, _
                                            ByVal inOBINCLPR As Integer, _
                                            ByVal stOBINFECH As String, _
                                            ByVal inOBINMEIN As Integer, _
                                            ByVal stOBINOBSE As String, _
                                            ByVal inOBINVIAV As Integer, _
                                            ByVal stOBINESTA As String, _
                                            ByVal stOBINRUIM As String, _
                                            ByVal boOBINCONJ As Boolean, _
                                            ByVal boOBINVIIS As Boolean, _
                                            ByVal boOBINAVPA As Boolean, _
                                            ByVal boOBINAVCU As Boolean, _
                                            ByVal boOBINURAB As Boolean, _
                                            ByVal boOBINURCE As Boolean, _
                                            ByVal inOBINZOFI As Integer, _
                                            ByVal inOBINPUCA As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "( "
            stConsultaSQL += "OBINSECU, "
            stConsultaSQL += "OBINCECA, "
            stConsultaSQL += "OBINNUFI, "
            stConsultaSQL += "OBINDESC, "
            stConsultaSQL += "OBINDIRE, "
            stConsultaSQL += "OBINCOMU, "
            stConsultaSQL += "OBINDEPA, "
            stConsultaSQL += "OBINMUNI, "
            stConsultaSQL += "OBINCORR, "
            stConsultaSQL += "OBINBARR, "
            stConsultaSQL += "OBINMANZ, "
            stConsultaSQL += "OBINPRED, "
            stConsultaSQL += "OBINEDIF, "
            stConsultaSQL += "OBINUNPR, "
            stConsultaSQL += "OBINCLSE, "
            stConsultaSQL += "OBINCAPR, "
            stConsultaSQL += "OBINAVCA, "
            stConsultaSQL += "OBINAVCO, "
            stConsultaSQL += "OBINVM2T, "
            stConsultaSQL += "OBINVM2C, "
            stConsultaSQL += "OBINARTE, "
            stConsultaSQL += "OBINARCO, "
            stConsultaSQL += "OBINVIGE, "
            stConsultaSQL += "OBINEDCO, "
            stConsultaSQL += "OBINESTR, "
            stConsultaSQL += "OBINZOEC, "
            stConsultaSQL += "OBINTIPO, "
            stConsultaSQL += "OBINCLCO, "
            stConsultaSQL += "OBINTICO, "
            stConsultaSQL += "OBINNUPI, "
            stConsultaSQL += "OBINMOBI, "
            stConsultaSQL += "OBINCLPR, "
            stConsultaSQL += "OBINFECH, "
            stConsultaSQL += "OBINMEIN, "
            stConsultaSQL += "OBINOBSE, "
            stConsultaSQL += "OBINVIAV, "
            stConsultaSQL += "OBINESTA, "
            stConsultaSQL += "OBINRUIM, "
            stConsultaSQL += "OBINCONJ, "
            stConsultaSQL += "OBINVIIS, "
            stConsultaSQL += "OBINAVPA, "
            stConsultaSQL += "OBINAVCU, "
            stConsultaSQL += "OBINURAB, "
            stConsultaSQL += "OBINURCE, "
            stConsultaSQL += "OBINZOFI, "
            stConsultaSQL += "OBINPUCA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOBINSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINCECA)) & "', "
            stConsultaSQL += "'" & CInt(inOBINNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINCOMU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inOBINCLSE) & "', "
            stConsultaSQL += "'" & CInt(inOBINCAPR) & "', "
            stConsultaSQL += "'" & CLng(loOBINAVCA) & "', "
            stConsultaSQL += "'" & CLng(loOBINAVCO) & "', "
            stConsultaSQL += "'" & CInt(inOBINVM2T) & "', "
            stConsultaSQL += "'" & CInt(inOBINVM2C) & "', "
            stConsultaSQL += "'" & CInt(inOBINARTE) & "', "
            stConsultaSQL += "'" & CInt(inOBINARCO) & "', "
            stConsultaSQL += "'" & CInt(inOBINVIGE) & "', "
            stConsultaSQL += "'" & CInt(inOBINEDCO) & "', "
            stConsultaSQL += "'" & CInt(inOBINESTR) & "', "
            stConsultaSQL += "'" & CInt(inOBINZOEC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINTIPO)) & "', "
            stConsultaSQL += "'" & CInt(inOBINCLCO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINTICO)) & "', "
            stConsultaSQL += "'" & CInt(inOBINNUPI) & "', "
            stConsultaSQL += "'" & CInt(inOBINMOBI) & "', "
            stConsultaSQL += "'" & CInt(inOBINCLPR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINFECH)) & "', "
            stConsultaSQL += "'" & CInt(inOBINMEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINOBSE)) & "', "
            stConsultaSQL += "'" & CInt(inOBINVIAV) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOBINRUIM)) & "', "
            stConsultaSQL += "'" & CBool(boOBINCONJ) & "', "
            stConsultaSQL += "'" & CBool(boOBINVIIS) & "', "
            stConsultaSQL += "'" & CBool(boOBINAVPA) & "', "
            stConsultaSQL += "'" & CBool(boOBINAVCU) & "', "
            stConsultaSQL += "'" & CBool(boOBINURAB) & "', "
            stConsultaSQL += "'" & CBool(boOBINURCE) & "', "
            stConsultaSQL += "'" & CInt(inOBINZOFI) & "', "
            stConsultaSQL += "'" & CInt(inOBINPUCA) & "' "
            stConsultaSQL += ") "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBSEINMO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBSEINMO(ByVal inOBINIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINIDRE = '" & CInt(inOBINIDRE) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBSEINMO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBSEINMO(ByVal inOBINSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINSECU = '" & CInt(inOBINSECU) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBSEINMO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBSEINMO(ByVal inOBINIDRE As Integer, _
                                            ByVal inOBINSECU As Integer, _
                                            ByVal stOBINCECA As String, _
                                            ByVal inOBINNUFI As Integer, _
                                            ByVal stOBINDESC As String, _
                                            ByVal stOBINDIRE As String, _
                                            ByVal stOBINCOMU As String, _
                                            ByVal stOBINDEPA As String, _
                                            ByVal stOBINMUNI As String, _
                                            ByVal stOBINCORR As String, _
                                            ByVal stOBINBARR As String, _
                                            ByVal stOBINMANZ As String, _
                                            ByVal stOBINPRED As String, _
                                            ByVal stOBINEDIF As String, _
                                            ByVal stOBINUNPR As String, _
                                            ByVal inOBINCLSE As Integer, _
                                            ByVal inOBINCAPR As Integer, _
                                            ByVal loOBINAVCA As Long, _
                                            ByVal loOBINAVCO As Long, _
                                            ByVal inOBINVM2T As Integer, _
                                            ByVal inOBINVM2C As Integer, _
                                            ByVal inOBINARTE As Integer, _
                                            ByVal inOBINARCO As Integer, _
                                            ByVal inOBINVIGE As Integer, _
                                            ByVal inOBINEDCO As Integer, _
                                            ByVal inOBINESTR As Integer, _
                                            ByVal inOBINZOEC As Integer, _
                                            ByVal stOBINTIPO As String, _
                                            ByVal inOBINCLCO As Integer, _
                                            ByVal stOBINTICO As String, _
                                            ByVal inOBINNUPI As Integer, _
                                            ByVal inOBINMOBI As Integer, _
                                            ByVal inOBINCLPR As Integer, _
                                            ByVal stOBINFECH As String, _
                                            ByVal inOBINMEIN As Integer, _
                                            ByVal stOBINOBSE As String, _
                                            ByVal inOBINVIAV As Integer, _
                                            ByVal stOBINESTA As String, _
                                            ByVal boOBINCONJ As Boolean, _
                                            ByVal boOBINVIIS As Boolean, _
                                            ByVal boOBINAVPA As Boolean, _
                                            ByVal boOBINAVCU As Boolean, _
                                            ByVal boOBINURAB As Boolean, _
                                            ByVal boOBINURCE As Boolean, _
                                            ByVal inOBINZOFI As Integer, _
                                            ByVal inOBINPUCA As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "SET "
            stConsultaSQL += "OBINSECU = '" & CInt(inOBINSECU) & "', "
            stConsultaSQL += "OBINCECA = '" & CStr(Trim(stOBINCECA)) & "', "
            stConsultaSQL += "OBINNUFI = '" & CInt(inOBINNUFI) & "', "
            stConsultaSQL += "OBINDESC = '" & CStr(Trim(stOBINDESC)) & "', "
            stConsultaSQL += "OBINDIRE = '" & CStr(Trim(stOBINDIRE)) & "', "
            stConsultaSQL += "OBINCOMU = '" & CStr(Trim(stOBINCOMU)) & "', "
            stConsultaSQL += "OBINDEPA = '" & CStr(Trim(stOBINDEPA)) & "', "
            stConsultaSQL += "OBINMUNI = '" & CStr(Trim(stOBINMUNI)) & "', "
            stConsultaSQL += "OBINCORR = '" & CStr(Trim(stOBINCORR)) & "', "
            stConsultaSQL += "OBINBARR = '" & CStr(Trim(stOBINBARR)) & "', "
            stConsultaSQL += "OBINMANZ = '" & CStr(Trim(stOBINMANZ)) & "', "
            stConsultaSQL += "OBINPRED = '" & CStr(Trim(stOBINPRED)) & "', "
            stConsultaSQL += "OBINEDIF = '" & CStr(Trim(stOBINEDIF)) & "', "
            stConsultaSQL += "OBINUNPR = '" & CStr(Trim(stOBINUNPR)) & "', "
            stConsultaSQL += "OBINCLSE = '" & CInt(inOBINCLSE) & "', "
            stConsultaSQL += "OBINCAPR = '" & CInt(inOBINCAPR) & "', "
            stConsultaSQL += "OBINAVCA = '" & CLng(loOBINAVCA) & "', "
            stConsultaSQL += "OBINAVCO = '" & CLng(loOBINAVCO) & "', "
            stConsultaSQL += "OBINVM2T = '" & CInt(inOBINVM2T) & "', "
            stConsultaSQL += "OBINVM2C = '" & CInt(inOBINVM2C) & "', "
            stConsultaSQL += "OBINARTE = '" & CInt(inOBINARTE) & "', "
            stConsultaSQL += "OBINARCO = '" & CInt(inOBINARCO) & "', "
            stConsultaSQL += "OBINVIGE = '" & CInt(inOBINVIGE) & "', "
            stConsultaSQL += "OBINEDCO = '" & CInt(inOBINEDCO) & "', "
            stConsultaSQL += "OBINESTR = '" & CInt(inOBINESTR) & "', "
            stConsultaSQL += "OBINZOEC = '" & CInt(inOBINZOEC) & "', "
            stConsultaSQL += "OBINTIPO = '" & CStr(Trim(stOBINTIPO)) & "', "
            stConsultaSQL += "OBINCLCO = '" & CInt(inOBINCLCO) & "', "
            stConsultaSQL += "OBINTICO = '" & CStr(Trim(stOBINTICO)) & "', "
            stConsultaSQL += "OBINNUPI = '" & CInt(inOBINNUPI) & "', "
            stConsultaSQL += "OBINMOBI = '" & CInt(inOBINMOBI) & "', "
            stConsultaSQL += "OBINCLPR = '" & CInt(inOBINCLPR) & "', "
            stConsultaSQL += "OBINFECH = '" & CStr(Trim(stOBINFECH)) & "', "
            stConsultaSQL += "OBINMEIN = '" & CInt(inOBINMEIN) & "', "
            stConsultaSQL += "OBINOBSE = '" & CStr(Trim(stOBINOBSE)) & "', "
            stConsultaSQL += "OBINVIAV = '" & CInt(inOBINVIAV) & "', "
            stConsultaSQL += "OBINESTA = '" & CStr(Trim(stOBINESTA)) & "', "
            stConsultaSQL += "OBINCONJ = '" & CBool(boOBINCONJ) & "', "
            stConsultaSQL += "OBINVIIS = '" & CBool(boOBINVIIS) & "', "
            stConsultaSQL += "OBINAVPA = '" & CBool(boOBINAVPA) & "', "
            stConsultaSQL += "OBINAVCU = '" & CBool(boOBINAVCU) & "', "
            stConsultaSQL += "OBINURAB = '" & CBool(boOBINURAB) & "', "
            stConsultaSQL += "OBINURCE = '" & CBool(boOBINURCE) & "', "
            stConsultaSQL += "OBINZOFI = '" & CInt(inOBINZOFI) & "', "
            stConsultaSQL += "OBINPUCA = '" & CInt(inOBINPUCA) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINIDRE = '" & CInt(inOBINIDRE) & "'"

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBSEINMO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBSEINMO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1  "
            stConsultaSQL += "OBINIDRE, "
            stConsultaSQL += "OBINSECU, "
            stConsultaSQL += "OBINCECA, "
            stConsultaSQL += "OBINNUFI, "
            stConsultaSQL += "OBINDESC, "
            stConsultaSQL += "OBINDIRE, "
            stConsultaSQL += "OBINCOMU, "
            stConsultaSQL += "OBINDEPA, "
            stConsultaSQL += "OBINMUNI, "
            stConsultaSQL += "OBINCORR, "
            stConsultaSQL += "OBINBARR, "
            stConsultaSQL += "OBINMANZ, "
            stConsultaSQL += "OBINPRED, "
            stConsultaSQL += "OBINEDIF, "
            stConsultaSQL += "OBINUNPR, "
            stConsultaSQL += "OBINCLSE, "
            stConsultaSQL += "OBINCAPR, "
            stConsultaSQL += "OBINAVCA, "
            stConsultaSQL += "OBINAVCO, "
            stConsultaSQL += "OBINVM2T, "
            stConsultaSQL += "OBINVM2C, "
            stConsultaSQL += "OBINARTE, "
            stConsultaSQL += "OBINARCO, "
            stConsultaSQL += "OBINVIGE, "
            stConsultaSQL += "OBINEDCO, "
            stConsultaSQL += "OBINESTR, "
            stConsultaSQL += "OBINZOEC, "
            stConsultaSQL += "OBINTIPO, "
            stConsultaSQL += "OBINCLCO, "
            stConsultaSQL += "OBINTICO, "
            stConsultaSQL += "OBINNUPI, "
            stConsultaSQL += "OBINMOBI, "
            stConsultaSQL += "OBINCLPR, "
            stConsultaSQL += "OBINFECH, "
            stConsultaSQL += "OBINMEIN, "
            stConsultaSQL += "OBINOBSE, "
            stConsultaSQL += "OBINVIAV, "
            stConsultaSQL += "OBINESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OBINCONJ, "
            stConsultaSQL += "OBINRUIM, "
            stConsultaSQL += "OBINVIIS, "
            stConsultaSQL += "OBINAVPA, "
            stConsultaSQL += "OBINAVCU, "
            stConsultaSQL += "OBINURAB, "
            stConsultaSQL += "OBINURCE, "
            stConsultaSQL += "OBINZOFI, "
            stConsultaSQL += "OBINPUCA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBSEINMO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBINDEPA, OBINCORR, OBINBARR, OBINMANZ, OBINPRED, OBINCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBSEINMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBSEINMO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBINVIGE, OBINCLSE, OBINDEPA, OBINCORR, OBINBARR, OBINMANZ, OBINPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBSEINMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_OBSEINMO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBINVIGE, OBINCLSE, OBINDEPA, OBINCORR, OBINBARR, OBINMANZ, OBINPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBSEINMO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBSEINMO(ByVal inOBINIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINIDRE = '" & CInt(inOBINIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBSEINMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBSEINMO(ByVal inOBINSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINSECU = '" & CInt(inOBINSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_OBSEINMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CECA_X_OBSEINMO(ByVal sOBINCECA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBSEINMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINCECA = '" & CStr(Trim(sOBINCECA)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_OBSEINMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBSEINMO(ByVal inOBINIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OBINIDRE, "
            stConsultaSQL += "OBINSECU, "
            stConsultaSQL += "OBINCECA, "
            stConsultaSQL += "OBINNUFI, "
            stConsultaSQL += "OBINDESC, "
            stConsultaSQL += "OBINDIRE, "
            stConsultaSQL += "OBINCOMU, "
            stConsultaSQL += "OBINDEPA, "
            stConsultaSQL += "OBINMUNI, "
            stConsultaSQL += "OBINCORR, "
            stConsultaSQL += "OBINBARR, "
            stConsultaSQL += "OBINMANZ, "
            stConsultaSQL += "OBINPRED, "
            stConsultaSQL += "OBINEDIF, "
            stConsultaSQL += "OBINUNPR, "
            stConsultaSQL += "OBINCLSE, "
            stConsultaSQL += "OBINCAPR, "
            stConsultaSQL += "OBINAVCA, "
            stConsultaSQL += "OBINAVCO, "
            stConsultaSQL += "OBINVM2T, "
            stConsultaSQL += "OBINVM2C, "
            stConsultaSQL += "OBINARTE, "
            stConsultaSQL += "OBINARCO, "
            stConsultaSQL += "OBINVIGE, "
            stConsultaSQL += "OBINEDCO, "
            stConsultaSQL += "OBINESTR, "
            stConsultaSQL += "OBINZOEC, "
            stConsultaSQL += "OBINTIPO, "
            stConsultaSQL += "OBINCLCO, "
            stConsultaSQL += "OBINTICO, "
            stConsultaSQL += "OBINNUPI, "
            stConsultaSQL += "OBINMOBI, "
            stConsultaSQL += "OBINCLPR, "
            stConsultaSQL += "OBINFECH, "
            stConsultaSQL += "OBINMEIN, "
            stConsultaSQL += "OBINOBSE, "
            stConsultaSQL += "OBINVIAV, "
            stConsultaSQL += "OBINESTA, "
            stConsultaSQL += "OBINRUIM, "
            stConsultaSQL += "OBINCONJ, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OBINVIIS, "
            stConsultaSQL += "OBINAVPA, "
            stConsultaSQL += "OBINAVCU, "
            stConsultaSQL += "OBINURAB, "
            stConsultaSQL += "OBINURCE, "
            stConsultaSQL += "OBINZOFI, "
            stConsultaSQL += "OBINPUCA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBSEINMO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBINESTA = ESTACODI and "
            stConsultaSQL += "OBINIDRE = '" & CInt(inOBINIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBINVIGE, OBINCLSE, OBINDEPA, OBINCORR, OBINBARR, OBINMANZ, OBINPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBSEINMO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_OBSEINMO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OBINSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBSEINMO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_OBSEINMO")
            Return Nothing
        End Try

    End Function

End Class
