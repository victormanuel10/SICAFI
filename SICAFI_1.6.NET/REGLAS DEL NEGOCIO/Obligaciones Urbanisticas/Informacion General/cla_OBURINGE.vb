Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBURINGE

    '===========================================================
    '*** CLASE INFORMACION GENERAL OBLIGACIONES URBANISTICAS ***
    '===========================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBURINGE(ByVal stOUIGCLEN As String, _
                                                         ByVal inOUIGNURE As Integer, _
                                                         ByVal stOUIGFERE As String, _
                                                         ByVal obOUIGCLOU As Object, _
                                                         ByVal obOUIGNULI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(stOUIGCLEN) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inOUIGNURE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stOUIGFERE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUIGCLOU.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUIGNULI.Text) = True Then

                Dim objdatos1 As New cla_OBURINGE
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_OBURINGE(stOUIGCLEN, inOUIGNURE, stOUIGFERE, obOUIGCLOU.SelectedValue, obOUIGNULI.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
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
    Public Function fun_Insertar_OBURINGE(ByVal inOUIGSECU As Integer, _
                                          ByVal stOUIGCLEN As String, _
                                          ByVal inOUIGNURE As Integer, _
                                          ByVal stOUIGFERE As String, _
                                          ByVal inOUIGCLOU As Integer, _
                                          ByVal inOUIGNULI As Integer, _
                                          ByVal inOUIGTILI As Integer, _
                                          ByVal inOUIGCLSE As Integer, _
                                          ByVal inOUIGATLO As Integer, _
                                          ByVal inOUIGATCO As Integer, _
                                          ByVal stOUIGDENS As String, _
                                          ByVal inOUIGUNID As Integer, _
                                          ByVal loOUIGSMLV As Long, _
                                          ByVal inOUIGESSO As Integer, _
                                          ByVal stOUIGTIPO As String, _
                                          ByVal loOUIGAVCA As Long, _
                                          ByVal loOUIGAVCO As Long, _
                                          ByVal loOUIGLIQU As Long, _
                                          ByVal boOUIGPLPA As Boolean, _
                                          ByVal boOUIGADLI As Boolean, _
                                          ByVal stOUIGOBSE As String, _
                                          ByVal stOUIGESTA As String) As Boolean


        Try
            ' variables 
            Dim stOUIGUSLI As String = fun_usuario()
            Dim stOUIGNDLI As String = fun_cedula()
            Dim daOUIGFELI As Date = fun_fecha()
            Dim inOUIGVILI As Integer = fun_Vigencia()
            Dim stOUIGMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "( "
            stConsultaSQL += "OUIGSECU, "
            stConsultaSQL += "OUIGCLEN, "
            stConsultaSQL += "OUIGNURE, "
            stConsultaSQL += "OUIGFERE, "
            stConsultaSQL += "OUIGCLOU, "
            stConsultaSQL += "OUIGNULI, "
            stConsultaSQL += "OUIGTILI, "
            stConsultaSQL += "OUIGCLSE, "
            stConsultaSQL += "OUIGATLO, "
            stConsultaSQL += "OUIGATCO, "
            stConsultaSQL += "OUIGDENS, "
            stConsultaSQL += "OUIGUNID, "
            stConsultaSQL += "OUIGSMLV, "
            stConsultaSQL += "OUIGESSO, "
            stConsultaSQL += "OUIGTIPO, "
            stConsultaSQL += "OUIGAVCA, "
            stConsultaSQL += "OUIGAVCO, "
            stConsultaSQL += "OUIGLIQU, "
            stConsultaSQL += "OUIGPLPA, "
            stConsultaSQL += "OUIGADLI, "
            stConsultaSQL += "OUIGOBSE, "
            stConsultaSQL += "OUIGESTA, "
            stConsultaSQL += "OUIGUSLI, "
            stConsultaSQL += "OUIGNDLI, "
            stConsultaSQL += "OUIGFELI, "
            stConsultaSQL += "OUIGVILI, "
            stConsultaSQL += "OUIGMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOUIGSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOUIGNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGFERE)) & "', "
            stConsultaSQL += "'" & CInt(inOUIGCLOU) & "', "
            stConsultaSQL += "'" & CInt(inOUIGNULI) & "', "
            stConsultaSQL += "'" & CInt(inOUIGTILI) & "', "
            stConsultaSQL += "'" & CInt(inOUIGCLSE) & "', "
            stConsultaSQL += "'" & CInt(inOUIGATLO) & "', "
            stConsultaSQL += "'" & CInt(inOUIGATCO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGDENS)) & "', "
            stConsultaSQL += "'" & CInt(inOUIGUNID) & "', "
            stConsultaSQL += "'" & CDbl(loOUIGSMLV) & "', "
            stConsultaSQL += "'" & CInt(inOUIGESSO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGTIPO)) & "', "
            stConsultaSQL += "'" & CDbl(loOUIGAVCA) & "', "
            stConsultaSQL += "'" & CDbl(loOUIGAVCO) & "', "
            stConsultaSQL += "'" & CDbl(loOUIGLIQU) & "', "
            stConsultaSQL += "'" & CBool(boOUIGPLPA) & "', "
            stConsultaSQL += "'" & CBool(boOUIGADLI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGUSLI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGNDLI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(daOUIGFELI)) & "', "
            stConsultaSQL += "'" & CInt(inOUIGVILI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUIGMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBURINGE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBURINGE(ByVal inOUIGIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGIDRE = '" & CInt(inOUIGIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURINGE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBURINGE(ByVal inOUIGSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGSECU = '" & CInt(inOUIGSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURINGE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBURINGE(ByVal inOUIGIDRE As Integer, _
                                            ByVal inOUIGSECU As Integer, _
                                            ByVal stOUIGCLEN As String, _
                                            ByVal inOUIGNURE As Integer, _
                                            ByVal stOUIGFERE As String, _
                                            ByVal inOUIGCLOU As Integer, _
                                            ByVal inOUIGNULI As Integer, _
                                            ByVal inOUIGTILI As Integer, _
                                            ByVal inOUIGCLSE As Integer, _
                                            ByVal inOUIGATLO As Integer, _
                                            ByVal inOUIGATCO As Integer, _
                                            ByVal stOUIGDENS As String, _
                                            ByVal inOUIGUNID As Integer, _
                                            ByVal loOUIGSMLV As Long, _
                                            ByVal inOUIGESSO As Integer, _
                                            ByVal stOUIGTIPO As String, _
                                            ByVal loOUIGAVCA As Long, _
                                            ByVal loOUIGAVCO As Long, _
                                            ByVal loOUIGLIQU As Long, _
                                            ByVal boOUIGPLPA As Boolean, _
                                            ByVal boOUIGADLI As Boolean, _
                                            ByVal stOUIGOBSE As String, _
                                            ByVal stOUIGESTA As String) As Boolean

        Try
            ' variables 
            Dim stOUIGUSLI As String = fun_usuario()
            Dim stOUIGNDLI As String = fun_cedula()
            Dim daOUIGFELI As Date = fun_fecha()
            Dim inOUIGVILI As Integer = fun_Vigencia()
            Dim stOUIGMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUIGSECU = '" & CInt(inOUIGSECU) & "', "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "', "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "', "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "', "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "', "
            stConsultaSQL += "OUIGNULI = '" & CInt(inOUIGNULI) & "', "
            stConsultaSQL += "OUIGTILI = '" & CInt(inOUIGTILI) & "', "
            stConsultaSQL += "OUIGCLSE = '" & CInt(inOUIGCLSE) & "', "
            stConsultaSQL += "OUIGATLO = '" & CInt(inOUIGATLO) & "', "
            stConsultaSQL += "OUIGATCO = '" & CInt(inOUIGATCO) & "', "
            stConsultaSQL += "OUIGDENS = '" & CStr(Trim(stOUIGDENS)) & "', "
            stConsultaSQL += "OUIGUNID = '" & CInt(inOUIGUNID) & "', "
            stConsultaSQL += "OUIGSMLV = '" & CLng(loOUIGSMLV) & "', "
            stConsultaSQL += "OUIGESSO = '" & CInt(inOUIGESSO) & "', "
            stConsultaSQL += "OUIGTIPO = '" & CStr(Trim(stOUIGTIPO)) & "', "
            stConsultaSQL += "OUIGAVCA = '" & CLng(loOUIGAVCA) & "', "
            stConsultaSQL += "OUIGAVCO = '" & CLng(loOUIGAVCO) & "', "
            stConsultaSQL += "OUIGLIQU = '" & CLng(loOUIGLIQU) & "', "
            stConsultaSQL += "OUIGPLPA = '" & CBool(boOUIGPLPA) & "', "
            stConsultaSQL += "OUIGADLI = '" & CBool(boOUIGADLI) & "', "
            stConsultaSQL += "OUIGOBSE = '" & CStr(Trim(stOUIGOBSE)) & "', "
            stConsultaSQL += "OUIGESTA = '" & CStr(Trim(stOUIGESTA)) & "', "
            stConsultaSQL += "OUIGUSLI = '" & CStr(Trim(stOUIGUSLI)) & "', "
            stConsultaSQL += "OUIGNDLI = '" & CStr(Trim(stOUIGNDLI)) & "', "
            stConsultaSQL += "OUIGFELI = '" & CStr(Trim(daOUIGFELI)) & "', "
            stConsultaSQL += "OUIGVILI = '" & CInt(inOUIGVILI) & "', "
            stConsultaSQL += "OUIGMAQU = '" & CStr(Trim(stOUIGMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGIDRE = '" & CInt(inOUIGIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBURINGE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBURINGE(ByVal inOUIGIDRE As Integer, _
                                            ByVal inOUIGSECU As Integer, _
                                            ByVal stOUIGCLEN As String, _
                                            ByVal inOUIGNURE As Integer, _
                                            ByVal stOUIGFERE As String, _
                                            ByVal inOUIGCLOU As Integer, _
                                            ByVal inOUIGNULI As Integer, _
                                            ByVal loOUIGLIQU As Long) As Boolean

        Try
            ' variables 
            Dim stOUIGUSLI As String = fun_usuario()
            Dim stOUIGNDLI As String = fun_cedula()
            Dim daOUIGFELI As Date = fun_fecha()
            Dim inOUIGVILI As Integer = fun_Vigencia()
            Dim stOUIGMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUIGSECU = '" & CInt(inOUIGSECU) & "', "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "', "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "', "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "', "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "', "
            stConsultaSQL += "OUIGNULI = '" & CInt(inOUIGNULI) & "', "
            stConsultaSQL += "OUIGLIQU = '" & CLng(loOUIGLIQU) & "', "
            stConsultaSQL += "OUIGUSLI = '" & CStr(Trim(stOUIGUSLI)) & "', "
            stConsultaSQL += "OUIGNDLI = '" & CStr(Trim(stOUIGNDLI)) & "', "
            stConsultaSQL += "OUIGFELI = '" & CStr(Trim(daOUIGFELI)) & "', "
            stConsultaSQL += "OUIGVILI = '" & CInt(inOUIGVILI) & "', "
            stConsultaSQL += "OUIGMAQU = '" & CStr(Trim(stOUIGMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGIDRE = '" & CInt(inOUIGIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBURINGE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBURINGE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUIGIDRE, "
            stConsultaSQL += "OUIGSECU, "
            stConsultaSQL += "OUIGCLEN, "
            stConsultaSQL += "OUIGNURE, "
            stConsultaSQL += "OUIGFERE, "
            stConsultaSQL += "OUIGNULI, "
            stConsultaSQL += "OUIGCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUIGTILI, "
            stConsultaSQL += "TILIDESC, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUIGCLSE, "
            stConsultaSQL += "OUIGATLO, "
            stConsultaSQL += "OUIGATCO, "
            stConsultaSQL += "OUIGDENS, "
            stConsultaSQL += "OUIGUNID, "
            stConsultaSQL += "OUIGAJLI, "
            stConsultaSQL += "OUIGADLI, "
            stConsultaSQL += "OUIGSMLV, "
            stConsultaSQL += "OUIGESSO, "
            stConsultaSQL += "ESTRDESC, "
            stConsultaSQL += "OUIGTIPO, "
            stConsultaSQL += "TICADESC, "
            stConsultaSQL += "OUIGAVCA, "
            stConsultaSQL += "OUIGAVCO, "
            stConsultaSQL += "OUIGLIQU, "
            stConsultaSQL += "OUIGPLPA, "
            stConsultaSQL += "OUIGOBSE, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE, MANT_CLASOBUR, MANT_TIPOLIQU, MANT_CLASSECT, MANT_ESTRATO, MANT_TIPOCALI, ESTADO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUIGCLOU = CLOUCODI AND "
            stConsultaSQL += "OUIGTILI = TILICODI AND "
            stConsultaSQL += "OUIGCLSE = CLSECODI AND "
            stConsultaSQL += "OUIGESSO = ESTRCODI AND "
            stConsultaSQL += "OUIGTIPO = TICACODI AND "
            stConsultaSQL += "OUIGESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUIGIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBURINGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBURINGE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUIGIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBURINGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBURINGE(ByVal inOUIGIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGIDRE = '" & CInt(inOUIGIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBURINGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURINGE(ByVal stOUIGCLEN As String, _
                                                 ByVal inOUIGNURE As Integer, _
                                                 ByVal stOUIGFERE As String, _
                                                 ByVal inOUIGCLOU As Integer, _
                                                 ByVal inOUIGNULI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "' AND "
            stConsultaSQL += "OUIGNULI = '" & CInt(inOUIGNULI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURINGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURINGE(ByVal inOUIGIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUIGIDRE, "
            stConsultaSQL += "OUIGSECU, "
            stConsultaSQL += "OUIGCLEN, "
            stConsultaSQL += "OUIGNURE, "
            stConsultaSQL += "OUIGFERE, "
            stConsultaSQL += "OUIGNULI, "
            stConsultaSQL += "OUIGCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUIGTILI, "
            stConsultaSQL += "TILIDESC, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUIGCLSE, "
            stConsultaSQL += "OUIGATLO, "
            stConsultaSQL += "OUIGATCO, "
            stConsultaSQL += "OUIGDENS, "
            stConsultaSQL += "OUIGUNID, "
            stConsultaSQL += "OUIGAJLI, "
            stConsultaSQL += "OUIGADLI, "
            stConsultaSQL += "OUIGSMLV, "
            stConsultaSQL += "OUIGESSO, "
            stConsultaSQL += "ESTRDESC, "
            stConsultaSQL += "OUIGTIPO, "
            stConsultaSQL += "TICADESC, "
            stConsultaSQL += "OUIGAVCA, "
            stConsultaSQL += "OUIGAVCO, "
            stConsultaSQL += "OUIGLIQU, "
            stConsultaSQL += "OUIGPLPA, "
            stConsultaSQL += "OUIGOBSE, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE, MANT_CLASOBUR, MANT_TIPOLIQU, MANT_CLASSECT, MANT_ESTRATO, MANT_TIPOCALI, ESTADO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUIGCLOU = CLOUCODI AND "
            stConsultaSQL += "OUIGTILI = TILICODI AND "
            stConsultaSQL += "OUIGCLSE = CLSECODI AND "
            stConsultaSQL += "OUIGESSO = ESTRCODI AND "
            stConsultaSQL += "OUIGTIPO = TICACODI AND "
            stConsultaSQL += "OUIGESTA = ESTACODI AND "
            stConsultaSQL += "OUIGIDRE = '" & CInt(inOUIGIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUIGIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURINGE")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(ByVal inOUIGSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUIGIDRE, "
            stConsultaSQL += "OUIGSECU, "
            stConsultaSQL += "OUIGCLEN, "
            stConsultaSQL += "OUIGNURE, "
            stConsultaSQL += "OUIGFERE, "
            stConsultaSQL += "OUIGNULI, "
            stConsultaSQL += "OUIGCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUIGTILI, "
            stConsultaSQL += "TILIDESC, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUIGCLSE, "
            stConsultaSQL += "OUIGATLO, "
            stConsultaSQL += "OUIGATCO, "
            stConsultaSQL += "OUIGDENS, "
            stConsultaSQL += "OUIGUNID, "
            stConsultaSQL += "OUIGAJLI, "
            stConsultaSQL += "OUIGADLI, "
            stConsultaSQL += "OUIGSMLV, "
            stConsultaSQL += "OUIGESSO, "
            stConsultaSQL += "ESTRDESC, "
            stConsultaSQL += "OUIGTIPO, "
            stConsultaSQL += "TICADESC, "
            stConsultaSQL += "OUIGAVCA, "
            stConsultaSQL += "OUIGAVCO, "
            stConsultaSQL += "OUIGLIQU, "
            stConsultaSQL += "OUIGPLPA, "
            stConsultaSQL += "OUIGOBSE, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE, MANT_CLASOBUR, MANT_TIPOLIQU, MANT_CLASSECT, MANT_ESTRATO, MANT_TIPOCALI, ESTADO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUIGCLOU = CLOUCODI AND "
            stConsultaSQL += "OUIGTILI = TILICODI AND "
            stConsultaSQL += "OUIGCLSE = CLSECODI AND "
            stConsultaSQL += "OUIGESSO = ESTRCODI AND "
            stConsultaSQL += "OUIGTIPO = TICACODI AND "
            stConsultaSQL += "OUIGESTA = ESTACODI AND "
            stConsultaSQL += "OUIGSECU = '" & CInt(inOUIGSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUIGIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURINGE")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_OBURINGE(ByVal inOUIGSECU As Integer, _
                                                    ByVal stOUIGCLEN As String, _
                                                    ByVal inOUIGNURE As Integer, _
                                                    ByVal stOUIGFERE As String, _
                                                    ByVal inOUIGCLOU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUIGNULI, "
            stConsultaSQL += "OUIGSECU, "
            stConsultaSQL += "OUIGCLEN, "
            stConsultaSQL += "OUIGNURE, "
            stConsultaSQL += "OUIGFERE, "
            stConsultaSQL += "OUIGCLOU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGSECU = '" & CInt(inOUIGSECU) & "' AND "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUIGIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(ByVal stOUIGCLEN As String, _
                                                                         ByVal inOUIGNURE As Integer, _
                                                                         ByVal stOUIGFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUIGCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUIGADLI, "
            stConsultaSQL += "SUM(OUIGLIQU) AS CLOULIQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE, MANT_CLASOBUR  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGCLOU = CLOUCODI AND "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' "

            stConsultaSQL += "GROUP BY "
            stConsultaSQL += "OUIGCLOU, CLOUDESC, OUIGADLI "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(ByVal inOUIGCLOU As Integer, _
                                                                         ByVal stOUIGCLEN As String, _
                                                                         ByVal inOUIGNURE As Integer, _
                                                                         ByVal stOUIGFERE As String, _
                                                                         ByVal stOUIGTIPO As String, _
                                                                         ByVal boOUIGADLI As Boolean) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "SUM(OUIGLIQU) AS CLOULIQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE, MANT_CLASOBUR  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGCLOU = CLOUCODI AND "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "' AND "
            stConsultaSQL += "OUIGTIPO = '" & CStr(Trim(stOUIGTIPO)) & "' AND "
            stConsultaSQL += "OUIGADLI = '" & CBool(boOUIGADLI) & "' "

            stConsultaSQL += "GROUP BY "
            stConsultaSQL += "CLOUDESC "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_LIQUIDACION_X_CLASE_OBLIGACION_X_OBURINGE(ByVal inOUIGCLOU As Integer, _
                                                                         ByVal stOUIGCLEN As String, _
                                                                         ByVal inOUIGNURE As Integer, _
                                                                         ByVal stOUIGFERE As String, _
                                                                         ByVal boOUIGADLI As Boolean) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "SUM(OUIGLIQU) AS CLOULIQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE, MANT_CLASOBUR  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGCLOU = CLOUCODI AND "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "' AND "
            stConsultaSQL += "OUIGADLI = '" & CBool(boOUIGADLI) & "' "

            stConsultaSQL += "GROUP BY "
            stConsultaSQL += "CLOUDESC "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_INFO_GENE_X_OBURINGE(ByVal inOUIGSECU As Integer, _
                                                    ByVal stOUIGCLEN As String, _
                                                    ByVal inOUIGNURE As Integer, _
                                                    ByVal stOUIGFERE As String, _
                                                    ByVal inOUIGCLOU As Integer, _
                                                    ByVal inOUIGNULI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGSECU = '" & CInt(inOUIGSECU) & "' AND "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "' AND "
            stConsultaSQL += "OUIGNULI = '" & CInt(inOUIGNULI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_LIQUIDACION_TOTAL_OBURINGE(ByVal stOUIGCLEN As String, _
                                                          ByVal inOUIGNURE As Integer, _
                                                          ByVal stOUIGFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SUM(OUIGLIQU) "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_LIQUIDACION_TOTAL_1_OBURINGE(ByVal stOUIGCLEN As String, _
                                                            ByVal inOUIGNURE As Integer, _
                                                            ByVal stOUIGFERE As String, _
                                                            ByVal boOUIGADLI As Boolean) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUIGLIQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGADLI = '" & CBool(boOUIGADLI) & "' AND "
            stConsultaSQL += "OUIGCLOU IN ('1','2','6') "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_LIQUIDACION_TOTAL_2_OBURINGE(ByVal stOUIGCLEN As String, _
                                                            ByVal inOUIGNURE As Integer, _
                                                            ByVal stOUIGFERE As String, _
                                                            ByVal boOUIGADLI As Boolean) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUIGLIQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGADLI = '" & CBool(boOUIGADLI) & "' AND "
            stConsultaSQL += "OUIGCLOU IN ('5') "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que consulta la sumatoria de unidades 
    ''' </summary>
    Public Function fun_Consultar_Sumatoria_Unidades_OBURINGE(ByVal inOUIGSECU As Integer, _
                                                              ByVal stOUIGCLEN As String, _
                                                              ByVal inOUIGNURE As Integer, _
                                                              ByVal stOUIGFERE As String, _
                                                              ByVal inOUIGCLOU As Integer, _
                                                              ByVal stOUIGTIPO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SUM(OUIGUNID) AS 'TOTAL' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGSECU = '" & CInt(inOUIGSECU) & "' AND "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "' AND "
            stConsultaSQL += "OUIGTIPO = '" & CStr(Trim(stOUIGTIPO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_Sumatoria_Unidades_OBURINGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que consulta la sumatoria de unidades 
    ''' </summary>
    Public Function fun_Consultar_Unidades_OBURINGE(ByVal inOUIGSECU As Integer, _
                                                    ByVal stOUIGCLEN As String, _
                                                    ByVal inOUIGNURE As Integer, _
                                                    ByVal stOUIGFERE As String, _
                                                    ByVal inOUIGCLOU As Integer, _
                                                    ByVal stOUIGTIPO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURINGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUIGSECU = '" & CInt(inOUIGSECU) & "' AND "
            stConsultaSQL += "OUIGCLEN = '" & CStr(Trim(stOUIGCLEN)) & "' AND "
            stConsultaSQL += "OUIGNURE = '" & CInt(inOUIGNURE) & "' AND "
            stConsultaSQL += "OUIGFERE = '" & CStr(Trim(stOUIGFERE)) & "' AND "
            stConsultaSQL += "OUIGCLOU = '" & CInt(inOUIGCLOU) & "' AND "
            stConsultaSQL += "OUIGTIPO = '" & CStr(Trim(stOUIGTIPO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_Unidades_OBURINGE")
            Return Nothing
        End Try

    End Function

End Class
