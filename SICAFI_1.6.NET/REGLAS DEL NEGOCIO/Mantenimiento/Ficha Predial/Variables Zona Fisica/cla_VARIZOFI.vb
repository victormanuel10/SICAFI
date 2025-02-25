Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_VARIZOFI

    '==================================
    '*** CLASE VARIABLE ZONA FISICA ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_VARIZOFI(ByVal obVAZFDEPA As Object, _
                                                              ByVal obVAZFMUNI As Object, _
                                                              ByVal obVAZFCLSE As Object, _
                                                              ByVal obVAZFZOFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obVAZFDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obVAZFMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obVAZFCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obVAZFZOFI.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obVAZFDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obVAZFMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obVAZFCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obVAZFZOFI.SelectedValue) = True Then

                    Dim objdatos1 As New cla_VARIZOFI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_NUFI_X_MANT_VARIZOFI(obVAZFDEPA.SelectedValue, _
                                                                                          obVAZFMUNI.SelectedValue, _
                                                                                          obVAZFCLSE.SelectedValue, _
                                                                                          obVAZFZOFI.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obVAZFDEPA.Text) & " - " & _
                                                     Trim(obVAZFMUNI.Text) & " - " & _
                                                     Trim(obVAZFCLSE.Text) & " - " & _
                                                     Trim(obVAZFZOFI.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obVAZFDEPA.Focus()
                        boRespuesta = False
                    Else
                        boRespuesta = True
                    End If

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
    Public Function fun_Insertar_MANT_VARIZOFI(ByVal stVAZFDEPA As String, _
                                               ByVal stVAZFMUNI As String, _
                                               ByVal inVAZFCLSE As Integer, _
                                               ByVal inVAZFZOFI As Integer, _
                                               ByVal inVAZFCLSU As Integer, _
                                               ByVal inVAZFARAC As Integer, _
                                               ByVal inVAZFTRUR As Integer, _
                                               ByVal inVAZFDEST As Integer, _
                                               ByVal inVAZFSEDE As Integer, _
                                               ByVal inVAZFSERV As Integer, _
                                               ByVal inVAZFVIAS As Integer, _
                                               ByVal inVAZFTOPO As Integer, _
                                               ByVal inVAZFAGUA As Integer, _
                                               ByVal inVAZFAHT As Integer, _
                                               ByVal stVAZFESTA As String, _
                                               ByVal inVAZFVA01 As Integer, _
                                               ByVal inVAZFVA02 As Integer, _
                                               ByVal inVAZFVA03 As Integer, _
                                               ByVal inVAZFVA04 As Integer, _
                                               ByVal inVAZFVA05 As Integer, _
                                               ByVal inVAZFVA06 As Integer, _
                                               ByVal inVAZFVA07 As Integer, _
                                               ByVal inVAZFVA08 As Integer, _
                                               ByVal inVAZFVA09 As Integer, _
                                               ByVal inVAZFVA10 As Integer, _
                                               ByVal inVAZFVACO As Integer, _
                                               ByVal inVAZFVACA As Integer, _
                                               ByVal inVAZFPOBL As Integer, _
                                               ByVal inVAZFZFAC As Integer, _
                                               ByVal inVAZFZOEC As Integer, _
                                               ByVal inVAZFZEAC As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_VARIZOFI "

            stConsultaSQL += "( "
            stConsultaSQL += "VAZFDEPA, "
            stConsultaSQL += "VAZFMUNI, "
            stConsultaSQL += "VAZFCLSE, "
            stConsultaSQL += "VAZFZOFI, "
            stConsultaSQL += "VAZFCLSU, "
            stConsultaSQL += "VAZFARAC, "
            stConsultaSQL += "VAZFTRUR, "
            stConsultaSQL += "VAZFDEST, "
            stConsultaSQL += "VAZFSEDE, "
            stConsultaSQL += "VAZFSERV, "
            stConsultaSQL += "VAZFVIAS, "
            stConsultaSQL += "VAZFTOPO, "
            stConsultaSQL += "VAZFAGUA, "
            stConsultaSQL += "VAZFAHT, "
            stConsultaSQL += "VAZFESTA, "
            stConsultaSQL += "VAZFVA01, "
            stConsultaSQL += "VAZFVA02, "
            stConsultaSQL += "VAZFVA03, "
            stConsultaSQL += "VAZFVA04, "
            stConsultaSQL += "VAZFVA05, "
            stConsultaSQL += "VAZFVA06, "
            stConsultaSQL += "VAZFVA07, "
            stConsultaSQL += "VAZFVA08, "
            stConsultaSQL += "VAZFVA09, "
            stConsultaSQL += "VAZFVA10, "
            stConsultaSQL += "VAZFVACO, "
            stConsultaSQL += "VAZFVACA, "
            stConsultaSQL += "VAZFPOBL, "
            stConsultaSQL += "VAZFZFAC, "
            stConsultaSQL += "VAZFZOEC, "
            stConsultaSQL += "VAZFZEAC "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stVAZFDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVAZFMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inVAZFCLSE) & "', "
            stConsultaSQL += "'" & CInt(inVAZFZOFI) & "', "
            stConsultaSQL += "'" & CInt(inVAZFCLSU) & "', "
            stConsultaSQL += "'" & CInt(inVAZFARAC) & "', "
            stConsultaSQL += "'" & CInt(inVAZFTRUR) & "', "
            stConsultaSQL += "'" & CInt(inVAZFDEST) & "', "
            stConsultaSQL += "'" & CInt(inVAZFSEDE) & "', "
            stConsultaSQL += "'" & CInt(inVAZFSERV) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVIAS) & "', "
            stConsultaSQL += "'" & CInt(inVAZFTOPO) & "', "
            stConsultaSQL += "'" & CInt(inVAZFAGUA) & "', "
            stConsultaSQL += "'" & CInt(inVAZFAHT) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVAZFESTA)) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA01) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA02) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA03) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA04) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA05) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA06) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA07) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA08) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA09) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVA10) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVACA) & "', "
            stConsultaSQL += "'" & CInt(inVAZFVACO) & "', "
            stConsultaSQL += "'" & CInt(inVAZFPOBL) & "', "
            stConsultaSQL += "'" & CInt(inVAZFZFAC) & "', "
            stConsultaSQL += "'" & CInt(inVAZFZOEC) & "', "
            stConsultaSQL += "'" & CInt(inVAZFZEAC) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_VARIZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_VARIZOFI(ByVal inVAZFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_VARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VAZFIDRE = '" & CInt(inVAZFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_VARIZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_VARIZOFI(ByVal inVAZFIDRE As Integer, _
                                                 ByVal stVAZFDEPA As String, _
                                                 ByVal stVAZFMUNI As String, _
                                                 ByVal inVAZFCLSE As Integer, _
                                                 ByVal inVAZFZOFI As Integer, _
                                                 ByVal inVAZFCLSU As Integer, _
                                                 ByVal inVAZFARAC As Integer, _
                                                 ByVal inVAZFTRUR As Integer, _
                                                 ByVal inVAZFDEST As Integer, _
                                                 ByVal inVAZFSEDE As Integer, _
                                                 ByVal inVAZFSERV As Integer, _
                                                 ByVal inVAZFVIAS As Integer, _
                                                 ByVal inVAZFTOPO As Integer, _
                                                 ByVal inVAZFAGUA As Integer, _
                                                 ByVal inVAZFAHT As Integer, _
                                                 ByVal stVAZFESTA As String, _
                                                 ByVal inVAZFVA01 As Integer, _
                                                 ByVal inVAZFVA02 As Integer, _
                                                 ByVal inVAZFVA03 As Integer, _
                                                 ByVal inVAZFVA04 As Integer, _
                                                 ByVal inVAZFVA05 As Integer, _
                                                 ByVal inVAZFVA06 As Integer, _
                                                 ByVal inVAZFVA07 As Integer, _
                                                 ByVal inVAZFVA08 As Integer, _
                                                 ByVal inVAZFVA09 As Integer, _
                                                 ByVal inVAZFVA10 As Integer, _
                                                 ByVal inVAZFVACO As Integer, _
                                                 ByVal inVAZFVACA As Integer, _
                                                 ByVal inVAZFPOBL As Integer, _
                                                 ByVal inVAZFZFAC As Integer, _
                                                 ByVal inVAZFZOEC As Integer, _
                                                 ByVal inVAZFZEAC As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_VARIZOFI "

            stConsultaSQL += "SET "
            stConsultaSQL += "VAZFDEPA = '" & CStr(Trim(stVAZFDEPA)) & "', "
            stConsultaSQL += "VAZFMUNI = '" & CStr(Trim(stVAZFMUNI)) & "', "
            stConsultaSQL += "VAZFCLSE = '" & CInt(inVAZFCLSE) & "', "
            stConsultaSQL += "VAZFZOFI = '" & CInt(inVAZFZOFI) & "', "
            stConsultaSQL += "VAZFCLSU = '" & CInt(inVAZFCLSU) & "', "
            stConsultaSQL += "VAZFARAC = '" & CInt(inVAZFARAC) & "', "
            stConsultaSQL += "VAZFTRUR = '" & CInt(inVAZFTRUR) & "', "
            stConsultaSQL += "VAZFDEST = '" & CInt(inVAZFDEST) & "', "
            stConsultaSQL += "VAZFSEDE = '" & CInt(inVAZFSEDE) & "', "
            stConsultaSQL += "VAZFSERV = '" & CInt(inVAZFSERV) & "', "
            stConsultaSQL += "VAZFVIAS = '" & CInt(inVAZFVIAS) & "', "
            stConsultaSQL += "VAZFTOPO = '" & CInt(inVAZFTOPO) & "', "
            stConsultaSQL += "VAZFAGUA = '" & CInt(inVAZFAGUA) & "', "
            stConsultaSQL += "VAZFAHT = '" & CInt(inVAZFAHT) & "', "
            stConsultaSQL += "VAZFESTA = '" & CStr(Trim(stVAZFESTA)) & "', "
            stConsultaSQL += "VAZFVA01 = '" & CInt(inVAZFVA01) & "', "
            stConsultaSQL += "VAZFVA02 = '" & CInt(inVAZFVA02) & "', "
            stConsultaSQL += "VAZFVA03 = '" & CInt(inVAZFVA03) & "', "
            stConsultaSQL += "VAZFVA04 = '" & CInt(inVAZFVA04) & "', "
            stConsultaSQL += "VAZFVA05 = '" & CInt(inVAZFVA05) & "', "
            stConsultaSQL += "VAZFVA06 = '" & CInt(inVAZFVA06) & "', "
            stConsultaSQL += "VAZFVA07 = '" & CInt(inVAZFVA07) & "', "
            stConsultaSQL += "VAZFVA08 = '" & CInt(inVAZFVA08) & "', "
            stConsultaSQL += "VAZFVA09 = '" & CInt(inVAZFVA09) & "', "
            stConsultaSQL += "VAZFVA10 = '" & CInt(inVAZFVA10) & "', "
            stConsultaSQL += "VAZFVACO = '" & CInt(inVAZFVACO) & "', "
            stConsultaSQL += "VAZFVACA = '" & CInt(inVAZFVACA) & "', "
            stConsultaSQL += "VAZFPOBL = '" & CInt(inVAZFPOBL) & "', "
            stConsultaSQL += "VAZFZFAC = '" & CInt(inVAZFZFAC) & "', "
            stConsultaSQL += "VAZFZOEC = '" & CInt(inVAZFZOEC) & "', "
            stConsultaSQL += "VAZFZEAC = '" & CInt(inVAZFZEAC) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VAZFIDRE = '" & CInt(inVAZFIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_VARIZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_VARIZOFI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VAZFIDRE, "
            stConsultaSQL += "VAZFDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "VAZFMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "VAZFCLSE, "
            stConsultaSQL += "CLSEDESC, "

            stConsultaSQL += "VAZFZOFI, "
            stConsultaSQL += "ZOFIDESC, "
            stConsultaSQL += "VAZFZOEC, "
            stConsultaSQL += "ZOECDESC, "
            stConsultaSQL += "VAZFZFAC, "
            stConsultaSQL += "ZFACDESC, "
            stConsultaSQL += "VAZFZEAC, "
            stConsultaSQL += "ZEACDESC, "

            stConsultaSQL += "VAZFCLSU, "
            stConsultaSQL += "CLSUDESC, "
            stConsultaSQL += "VAZFARAC, "
            stConsultaSQL += "ARACDESC, "
            stConsultaSQL += "VAZFTRUR, "
            stConsultaSQL += "TRURDESC, "
            stConsultaSQL += "VAZFDEST, "
            stConsultaSQL += "DESTDESC, "
            stConsultaSQL += "VAZFSEDE, "
            stConsultaSQL += "SEDEDESC, "
            stConsultaSQL += "VAZFSERV, "
            stConsultaSQL += "SERVDESC, "
            stConsultaSQL += "VAZFVIAS, "
            stConsultaSQL += "VIASDESC, "
            stConsultaSQL += "VAZFTOPO, "
            stConsultaSQL += "TOPODESC, "

            stConsultaSQL += "VAZFAGUA, "
            stConsultaSQL += "AGUADESC, "
            stConsultaSQL += "VAZFAHT, "
            stConsultaSQL += "AHTDESC, "

            stConsultaSQL += "VAZFESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "VAZFVA01, "
            stConsultaSQL += "VAZFVA02, "
            stConsultaSQL += "VAZFVA03, "
            stConsultaSQL += "VAZFVA04, "
            stConsultaSQL += "VAZFVA05, "
            stConsultaSQL += "VAZFVA06, "
            stConsultaSQL += "VAZFVA07, "
            stConsultaSQL += "VAZFVA08, "
            stConsultaSQL += "VAZFVA09, "
            stConsultaSQL += "VAZFVA10, "
            stConsultaSQL += "VAZFVACO, "
            stConsultaSQL += "VAZFVACA, "
            stConsultaSQL += "VAZFPOBL, "
            stConsultaSQL += "ZEACVACO, "
            stConsultaSQL += "ZEACVACA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIZOFI, MANT_DEPARTAMENTO, MANT_MUNICIPIO, MANT_CLASSECT, MANT_ZONAFISI, MANT_CLASSUEL, MANT_AREAACTI, MANT_TRATURBA, MANT_DESTINACION, MANT_SEGUDEST, MANT_SERVICIOS, MANT_VIAS, MANT_TOPOGRAFIA, ESTADO, MANT_ZONAECON, MANT_ZOFIACTU, MANT_ZOECACTU, MANT_AGUAS, MANT_AHT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VAZFDEPA = DEPACODI AND "
            stConsultaSQL += "VAZFDEPA = MUNIDEPA AND "
            stConsultaSQL += "VAZFMUNI = MUNICODI AND "
            stConsultaSQL += "VAZFCLSE = CLSECODI AND "
            stConsultaSQL += "VAZFDEPA = ZOFIDEPA AND "
            stConsultaSQL += "VAZFMUNI = ZOFIMUNI AND "
            stConsultaSQL += "VAZFCLSE = ZOFICLSE AND "
            stConsultaSQL += "VAZFZOFI = ZOFICODI AND "
            stConsultaSQL += "VAZFCLSU = CLSUCODI AND "
            stConsultaSQL += "VAZFARAC = ARACCODI AND "
            stConsultaSQL += "VAZFTRUR = TRURCODI AND "
            stConsultaSQL += "VAZFDEST = DESTCODI AND "
            stConsultaSQL += "VAZFDEST = SEDEDEST AND "
            stConsultaSQL += "VAZFSEDE = SEDECODI AND "
            stConsultaSQL += "VAZFSERV = SERVCODI AND "
            stConsultaSQL += "VAZFVIAS = VIASCODI AND "
            stConsultaSQL += "VAZFTOPO = TOPOCODI AND "

            stConsultaSQL += "VAZFAGUA = AGUACODI AND "
            stConsultaSQL += "VAZFAHT = AHTCODI AND "

            stConsultaSQL += "VAZFDEPA = ZFACDEPA AND "
            stConsultaSQL += "VAZFMUNI = ZFACMUNI AND "
            stConsultaSQL += "VAZFCLSE = ZFACCLSE AND "
            stConsultaSQL += "VAZFZFAC = ZFACCODI AND "

            stConsultaSQL += "VAZFDEPA = ZOECDEPA AND "
            stConsultaSQL += "VAZFMUNI = ZOECMUNI AND "
            stConsultaSQL += "VAZFCLSE = ZOECCLSE AND "
            stConsultaSQL += "VAZFZOEC = ZOECCODI AND "

            stConsultaSQL += "VAZFDEPA = ZEACDEPA AND "
            stConsultaSQL += "VAZFMUNI = ZEACMUNI AND "
            stConsultaSQL += "VAZFCLSE = ZEACCLSE AND "
            stConsultaSQL += "VAZFZEAC = ZEACCODI AND "

            stConsultaSQL += "VAZFESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VAZFDEPA, VAZFMUNI, VAZFCLSE, VAZFZFAC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_VARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_VARIZOFI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIZOFI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VAZFDEPA, VAZFMUNI, VAZFCLSE, VAZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_VARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_VARIZOFI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VAZFESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VAZFDEPA, VAZFMUNI, VAZFCLSE, VAZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_VARIZOFI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_VARIZOFI(ByVal inVAZFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VAZFIDRE = '" & CInt(inVAZFIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_VARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_NUFI_X_MANT_VARIZOFI(ByVal stVAZFDEPA As String, _
                                                                          ByVal stVAZFMUNI As String, _
                                                                          ByVal inVAZFCLSE As Integer, _
                                                                          ByVal inVAZFZOFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VAZFDEPA = '" & CStr(Trim(stVAZFDEPA)) & "' and "
            stConsultaSQL += "VAZFMUNI = '" & CStr(Trim(stVAZFMUNI)) & "' and "
            stConsultaSQL += "VAZFCLSE = '" & CInt(inVAZFCLSE) & "' and "
            stConsultaSQL += "VAZFZOFI = '" & CInt(inVAZFZOFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_VARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la zona fisica actual 
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MUNI_CLSE_X_MANT_VARIZOFI(ByVal stVAZFMUNI As String, _
                                                                ByVal inVAZFCLSE As Integer, _
                                                                ByVal inVAZFZFAC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VAZFMUNI = '" & CStr(Trim(stVAZFMUNI)) & "' and "
            stConsultaSQL += "VAZFCLSE = '" & CInt(inVAZFCLSE) & "' and "
            stConsultaSQL += "VAZFZFAC = '" & CInt(inVAZFZFAC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUNI_CLSE_X_MANT_VARIZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_VARIZOFI(ByVal inVAZFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VAZFIDRE, "
            stConsultaSQL += "VAZFDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "VAZFMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "VAZFCLSE, "
            stConsultaSQL += "CLSEDESC, "

            stConsultaSQL += "VAZFZOFI, "
            stConsultaSQL += "ZOFIDESC, "
            stConsultaSQL += "VAZFZOEC, "
            stConsultaSQL += "ZOECDESC, "
            stConsultaSQL += "VAZFZFAC, "
            stConsultaSQL += "ZFACDESC, "
            stConsultaSQL += "VAZFZEAC, "
            stConsultaSQL += "ZEACDESC, "

            stConsultaSQL += "VAZFCLSU, "
            stConsultaSQL += "CLSUDESC, "
            stConsultaSQL += "VAZFARAC, "
            stConsultaSQL += "ARACDESC, "
            stConsultaSQL += "VAZFTRUR, "
            stConsultaSQL += "TRURDESC, "
            stConsultaSQL += "VAZFDEST, "
            stConsultaSQL += "DESTDESC, "
            stConsultaSQL += "VAZFSEDE, "
            stConsultaSQL += "SEDEDESC, "
            stConsultaSQL += "VAZFSERV, "
            stConsultaSQL += "SERVDESC, "
            stConsultaSQL += "VAZFVIAS, "
            stConsultaSQL += "VIASDESC, "
            stConsultaSQL += "VAZFTOPO, "
            stConsultaSQL += "TOPODESC, "

            stConsultaSQL += "VAZFAGUA, "
            stConsultaSQL += "AGUADESC, "
            stConsultaSQL += "VAZFAHT, "
            stConsultaSQL += "AHTDESC, "

            stConsultaSQL += "VAZFESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "VAZFVA01, "
            stConsultaSQL += "VAZFVA02, "
            stConsultaSQL += "VAZFVA03, "
            stConsultaSQL += "VAZFVA04, "
            stConsultaSQL += "VAZFVA05, "
            stConsultaSQL += "VAZFVA06, "
            stConsultaSQL += "VAZFVA07, "
            stConsultaSQL += "VAZFVA08, "
            stConsultaSQL += "VAZFVA09, "
            stConsultaSQL += "VAZFVA10, "
            stConsultaSQL += "VAZFVACO, "
            stConsultaSQL += "VAZFVACA, "
            stConsultaSQL += "VAZFPOBL, "
            stConsultaSQL += "ZEACVACO, "
            stConsultaSQL += "ZEACVACA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIZOFI, MANT_DEPARTAMENTO, MANT_MUNICIPIO, MANT_CLASSECT, MANT_ZONAFISI, MANT_CLASSUEL, MANT_AREAACTI, MANT_TRATURBA, MANT_DESTINACION, MANT_SEGUDEST, MANT_SERVICIOS, MANT_VIAS, MANT_TOPOGRAFIA, ESTADO, MANT_ZONAECON, MANT_ZOFIACTU, MANT_ZOECACTU, MANT_AGUAS, MANT_AHT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VAZFDEPA = DEPACODI AND "
            stConsultaSQL += "VAZFDEPA = MUNIDEPA AND "
            stConsultaSQL += "VAZFMUNI = MUNICODI AND "
            stConsultaSQL += "VAZFCLSE = CLSECODI AND "
            stConsultaSQL += "VAZFDEPA = ZOFIDEPA AND "
            stConsultaSQL += "VAZFMUNI = ZOFIMUNI AND "
            stConsultaSQL += "VAZFCLSE = ZOFICLSE AND "
            stConsultaSQL += "VAZFZOFI = ZOFICODI AND "
            stConsultaSQL += "VAZFCLSU = CLSUCODI AND "
            stConsultaSQL += "VAZFARAC = ARACCODI AND "
            stConsultaSQL += "VAZFTRUR = TRURCODI AND "
            stConsultaSQL += "VAZFDEST = DESTCODI AND "
            stConsultaSQL += "VAZFDEST = SEDEDEST AND "
            stConsultaSQL += "VAZFSEDE = SEDECODI AND "
            stConsultaSQL += "VAZFSERV = SERVCODI AND "
            stConsultaSQL += "VAZFVIAS = VIASCODI AND "
            stConsultaSQL += "VAZFTOPO = TOPOCODI AND "

            stConsultaSQL += "VAZFAGUA = AGUACODI AND "
            stConsultaSQL += "VAZFAHT = AHTCODI AND "

            stConsultaSQL += "VAZFDEPA = ZFACDEPA AND "
            stConsultaSQL += "VAZFMUNI = ZFACMUNI AND "
            stConsultaSQL += "VAZFCLSE = ZFACCLSE AND "
            stConsultaSQL += "VAZFZFAC = ZFACCODI AND "

            stConsultaSQL += "VAZFDEPA = ZOECDEPA AND "
            stConsultaSQL += "VAZFMUNI = ZOECMUNI AND "
            stConsultaSQL += "VAZFCLSE = ZOECCLSE AND "
            stConsultaSQL += "VAZFZOEC = ZOECCODI AND "

            stConsultaSQL += "VAZFDEPA = ZEACDEPA AND "
            stConsultaSQL += "VAZFMUNI = ZEACMUNI AND "
            stConsultaSQL += "VAZFCLSE = ZEACCLSE AND "
            stConsultaSQL += "VAZFZEAC = ZEACCODI AND "

            stConsultaSQL += "VAZFESTA = ESTACODI AND "

            stConsultaSQL += "VAZFIDRE = '" & CInt(inVAZFIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VAZFDEPA, VAZFMUNI, VAZFCLSE, VAZFZFAC "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_VARIZOFI")
            Return Nothing

        End Try

    End Function

End Class
