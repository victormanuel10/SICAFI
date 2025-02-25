Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUPRMUTA

    '====================================================
    '*** CLASE MUTACIONES DE PRIMERA CLASE - MUTACION ***
    '====================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUPRMUTA(ByVal inMPMUVIGE As Integer, _
                                                         ByVal inMPMUTIRE As Integer, _
                                                         ByVal inMPMURESO As Integer, _
                                                         ByVal obMPMUNUFI As Object, _
                                                         ByVal inMPMUNURE As Integer) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inMPMUVIGE) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(inMPMUTIRE) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(inMPMURESO) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMPMUNUFI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(inMPMUNURE) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inMPMUVIGE) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(inMPMUTIRE) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(inMPMURESO) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMPMUNUFI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(inMPMUNURE) = True Then

                    Dim objdatos1 As New cla_MUPRMUTA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUPRMUTA(inMPMUVIGE, _
                                                                 inMPMUTIRE, _
                                                                 inMPMURESO, _
                                                                 obMPMUNUFI.Text, _
                                                                 inMPMUNURE)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
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
    Public Function fun_Insertar_MUPRMUTA(ByVal inMPMUSECU As Integer, _
                                          ByVal inMPMUVIGE As Integer, _
                                          ByVal inMPMUTIRE As Integer, _
                                          ByVal inMPMURESO As Integer, _
                                          ByVal inMPMUNUFI As Integer, _
                                          ByVal inMPMUNURE As Integer, _
                                          ByVal inMPMUNOVE As Integer, _
                                          ByVal inMPMUNOVC As Integer, _
                                          ByVal stMPMUMUNI As String, _
                                          ByVal stMPMUCORR As String, _
                                          ByVal stMPMUBARR As String, _
                                          ByVal stMPMUMANZ As String, _
                                          ByVal stMPMUPRED As String, _
                                          ByVal stMPMUEDIF As String, _
                                          ByVal stMPMUUNPR As String, _
                                          ByVal inMPMUCLSE As Integer, _
                                          ByVal stMPMUCAAC As String, _
                                          ByVal stMPMUESTA As String) As Boolean


        Try
            ' variables 
            Dim daMPMUFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "( "
            stConsultaSQL += "MPMUSECU, "
            stConsultaSQL += "MPMUVIGE, "
            stConsultaSQL += "MPMUTIRE, "
            stConsultaSQL += "MPMURESO, "
            stConsultaSQL += "MPMUNUFI, "
            stConsultaSQL += "MPMUNURE, "
            stConsultaSQL += "MPMUNOVE, "
            stConsultaSQL += "MPMUNOVC, "
            stConsultaSQL += "MPMUMUNI, "
            stConsultaSQL += "MPMUCORR, "
            stConsultaSQL += "MPMUBARR, "
            stConsultaSQL += "MPMUMANZ, "
            stConsultaSQL += "MPMUPRED, "
            stConsultaSQL += "MPMUEDIF, "
            stConsultaSQL += "MPMUUNPR, "
            stConsultaSQL += "MPMUCLSE, "
            stConsultaSQL += "MPMUCAAC, "
            stConsultaSQL += "MPMUESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMPMUSECU) & "', "
            stConsultaSQL += "'" & CInt(inMPMUVIGE) & "', "
            stConsultaSQL += "'" & CInt(inMPMUTIRE) & "', "
            stConsultaSQL += "'" & CInt(inMPMURESO) & "', "
            stConsultaSQL += "'" & CInt(inMPMUNUFI) & "', "
            stConsultaSQL += "'" & CInt(inMPMUNURE) & "', "
            stConsultaSQL += "'" & CInt(inMPMUNOVE) & "', "
            stConsultaSQL += "'" & CInt(inMPMUNOVC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inMPMUCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUCAAC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMPMUESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUPRMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUPRMUTA(ByVal inMPMUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUIDRE = '" & CInt(inMPMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUPRMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUPRMUTA(ByVal inMPMUSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUSECU = '" & CInt(inMPMUSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUPRMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CODIGO_X_MUPRMUTA(ByVal inMPMUVIGE As Integer, _
                                                   ByVal inMPMUTIRE As Integer, _
                                                   ByVal inMPMURESO As Integer, _
                                                   ByVal inMPMUNUFI As Integer, _
                                                   ByVal inMPMUNURE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUVIGE = '" & CInt(inMPMUVIGE) & "' AND "
            stConsultaSQL += "MPMUTIRE = '" & CInt(inMPMUTIRE) & "' AND "
            stConsultaSQL += "MPMURESO = '" & CInt(inMPMURESO) & "' AND "
            stConsultaSQL += "MPMUNUFI = '" & CInt(inMPMUNUFI) & "' AND "
            stConsultaSQL += "MPMUNURE = '" & CInt(inMPMUNURE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUPRMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUPRMUTA(ByVal inMPMUIDRE As Integer, _
                                            ByVal inMPMUSECU As Integer, _
                                            ByVal inMPMUVIGE As Integer, _
                                            ByVal inMPMUTIRE As Integer, _
                                            ByVal inMPMURESO As Integer, _
                                            ByVal inMPMUNUFI As Integer, _
                                            ByVal inMPMUNURE As Integer, _
                                            ByVal inMPMUNOVE As Integer, _
                                            ByVal inMPMUNOVC As Integer, _
                                            ByVal stMPMUMUNI As String, _
                                            ByVal stMPMUCORR As String, _
                                            ByVal stMPMUBARR As String, _
                                            ByVal stMPMUMANZ As String, _
                                            ByVal stMPMUPRED As String, _
                                            ByVal stMPMUEDIF As String, _
                                            ByVal stMPMUUNPR As String, _
                                            ByVal inMPMUCLSE As Integer, _
                                            ByVal stMPMUCAAC As String, _
                                            ByVal stMPMUESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "SET "
            stConsultaSQL += "MPMUSECU = '" & CInt(inMPMUSECU) & "', "
            stConsultaSQL += "MPMUVIGE = '" & CInt(inMPMUVIGE) & "', "
            stConsultaSQL += "MPMUTIRE = '" & CInt(inMPMUTIRE) & "', "
            stConsultaSQL += "MPMURESO = '" & CInt(inMPMURESO) & "', "
            stConsultaSQL += "MPMUNUFI = '" & CInt(inMPMUNUFI) & "', "
            stConsultaSQL += "MPMUNURE = '" & CInt(inMPMUNURE) & "', "
            stConsultaSQL += "MPMUNOVE = '" & CInt(inMPMUNOVE) & "', "
            stConsultaSQL += "MPMUNOVC = '" & CInt(inMPMUNOVC) & "', "
            stConsultaSQL += "MPMUMUNI = '" & CStr(Trim(stMPMUMUNI)) & "', "
            stConsultaSQL += "MPMUCORR = '" & CStr(Trim(stMPMUCORR)) & "', "
            stConsultaSQL += "MPMUBARR = '" & CStr(Trim(stMPMUBARR)) & "', "
            stConsultaSQL += "MPMUMANZ = '" & CStr(Trim(stMPMUMANZ)) & "', "
            stConsultaSQL += "MPMUPRED = '" & CStr(Trim(stMPMUPRED)) & "', "
            stConsultaSQL += "MPMUEDIF = '" & CStr(Trim(stMPMUEDIF)) & "', "
            stConsultaSQL += "MPMUUNPR = '" & CStr(Trim(stMPMUUNPR)) & "', "
            stConsultaSQL += "MPMUCLSE = '" & CInt(inMPMUCLSE) & "', "
            stConsultaSQL += "MPMUCAAC = '" & CStr(Trim(stMPMUCAAC)) & "', "
            stConsultaSQL += "MPMUESTA = '" & CStr(Trim(stMPMUESTA)) & "' "
            
            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUIDRE = '" & CInt(inMPMUIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUPRMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUPRMUTA(ByVal inMPMUSECU As Integer, _
                                            ByVal inMPMUNURE As Integer, _
                                            ByVal boMPMUANDO As Boolean) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "SET "
            stConsultaSQL += "MPMUANDO = '" & CBool(boMPMUANDO) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUSECU = '" & CInt(inMPMUSECU) & "' AND "
            stConsultaSQL += "MPMUNURE = '" & CInt(inMPMUNURE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUPRMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUPRMUTA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MPMUIDRE, "
            stConsultaSQL += "MPMUSECU, "
            stConsultaSQL += "MPMUVIGE, "
            stConsultaSQL += "MPMUTIRE, "
            stConsultaSQL += "MPMURESO, "
            stConsultaSQL += "MPMUNUFI, "
            stConsultaSQL += "MPMUNURE, "
            stConsultaSQL += "MPMUNOVE, "
            stConsultaSQL += "NOVEDESC, "
            stConsultaSQL += "MPMUANDO, "
            stConsultaSQL += "MPMUNOVC, "
            stConsultaSQL += "MPMUMUNI, "
            stConsultaSQL += "MPMUCORR, "
            stConsultaSQL += "MPMUBARR, "
            stConsultaSQL += "MPMUMANZ, "
            stConsultaSQL += "MPMUPRED, "
            stConsultaSQL += "MPMUEDIF, "
            stConsultaSQL += "MPMUUNPR, "
            stConsultaSQL += "MPMUCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MPMUCAAC, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA, ESTADO, MANT_NOVEDAD, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUESTA = ESTACODI AND "
            stConsultaSQL += "MPMUNOVE = NOVECODI AND "
            stConsultaSQL += "MPMUCLSE = CLSECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPMUVIGE, MPMUTIRE, MPMURESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUPRMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MUPRMUTA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPMUVIGE, MPMUTIRE, MPMURESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MUPRMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MUPRMUTA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPMUVIGE, MPMUTIRE, MPMURESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUPRMUTA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MUPRMUTA(ByVal inMPMUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUIDRE = '" & CInt(inMPMUIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MUPRMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUPRMUTA(ByVal inMPMUVIGE As Integer, _
                                                 ByVal inMPMUTIRE As Integer, _
                                                 ByVal inMPMURESO As Integer, _
                                                 ByVal inMPMUNUFI As Integer, _
                                                 ByVal inMPMUNURE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUVIGE = '" & CInt(inMPMUVIGE) & "' AND "
            stConsultaSQL += "MPMUTIRE = '" & CInt(inMPMUTIRE) & "' AND "
            stConsultaSQL += "MPMURESO = '" & CInt(inMPMURESO) & "' AND "
            stConsultaSQL += "MPMUNUFI = '" & CInt(inMPMUNUFI) & "' AND "
            stConsultaSQL += "MPMUNURE = '" & CInt(inMPMUNURE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MUPRMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUPRMUTA(ByVal inMPMUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUSECU = '" & CInt(inMPMUSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPMUNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUPRMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_NURE_X_MUPRMUTA(ByVal inMPMUNURE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUNURE = '" & CInt(inMPMUNURE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPMUNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUPRMUTA")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_MUPRMUTA(ByVal inMPMUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUSECU = '" & CInt(inMPMUSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPMUNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUPRMUTA")
            Return Nothing
        End Try

    End Function


    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUPRMUTA(ByVal inMPMUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MPMUIDRE, "
            stConsultaSQL += "MPMUSECU, "
            stConsultaSQL += "MPMUVIGE, "
            stConsultaSQL += "MPMUTIRE, "
            stConsultaSQL += "MPMURESO, "
            stConsultaSQL += "MPMUNUFI, "
            stConsultaSQL += "MPMUNURE, "
            stConsultaSQL += "MPMUNOVE, "
            stConsultaSQL += "NOVEDESC, "
            stConsultaSQL += "MPMUANDO, "
            stConsultaSQL += "MPMUNOVC, "
            stConsultaSQL += "MPMUMUNI, "
            stConsultaSQL += "MPMUCORR, "
            stConsultaSQL += "MPMUBARR, "
            stConsultaSQL += "MPMUMANZ, "
            stConsultaSQL += "MPMUPRED, "
            stConsultaSQL += "MPMUEDIF, "
            stConsultaSQL += "MPMUUNPR, "
            stConsultaSQL += "MPMUCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MPMUCAAC, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA, ESTADO, MANT_NOVEDAD, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUESTA = ESTACODI AND "
            stConsultaSQL += "MPMUNOVE = NOVECODI AND "
            stConsultaSQL += "MPMUCLSE = CLSECODI AND "
            stConsultaSQL += "MPMUIDRE = '" & CInt(inMPMUIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPMUNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUPRMUTA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUPRMUTA(ByVal inMPMUSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MPMUIDRE, "
            stConsultaSQL += "MPMUSECU, "
            stConsultaSQL += "MPMUVIGE, "
            stConsultaSQL += "MPMUTIRE, "
            stConsultaSQL += "MPMURESO, "
            stConsultaSQL += "MPMUNUFI, "
            stConsultaSQL += "MPMUNURE, "
            stConsultaSQL += "MPMUNOVE, "
            stConsultaSQL += "NOVEDESC, "
            stConsultaSQL += "MPMUANDO, "
            stConsultaSQL += "MPMUNOVC, "
            stConsultaSQL += "MPMUMUNI, "
            stConsultaSQL += "MPMUCORR, "
            stConsultaSQL += "MPMUBARR, "
            stConsultaSQL += "MPMUMANZ, "
            stConsultaSQL += "MPMUPRED, "
            stConsultaSQL += "MPMUEDIF, "
            stConsultaSQL += "MPMUUNPR, "
            stConsultaSQL += "MPMUCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "MPMUCAAC, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA, ESTADO, MANT_NOVEDAD, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUESTA = ESTACODI AND "
            stConsultaSQL += "MPMUNOVE = NOVECODI AND "
            stConsultaSQL += "MPMUCLSE = CLSECODI AND "
            stConsultaSQL += "MPMUSECU = '" & CInt(inMPMUSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MPMUNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUPRMUTA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_MUPRMUTA(ByVal inMPMUVIGE As Integer, _
                                                    ByVal inMPMUTIRE As Integer, _
                                                    ByVal inMPMURESO As Integer, _
                                                    ByVal inMPMUNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MPMUNURE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUPRMUTA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MPMUVIGE = '" & CInt(inMPMUVIGE) & "' AND "
            stConsultaSQL += "MPMUTIRE = '" & CInt(inMPMUTIRE) & "' AND "
            stConsultaSQL += "MPMURESO = '" & CInt(inMPMURESO) & "' AND "
            stConsultaSQL += "MPMUNUFI = '" & CInt(inMPMUNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_MUPRMUTA")
            Return Nothing
        End Try

    End Function

End Class
