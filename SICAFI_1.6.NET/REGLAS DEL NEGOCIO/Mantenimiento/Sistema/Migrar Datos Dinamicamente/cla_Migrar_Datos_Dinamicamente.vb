Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_Migrar_Datos_Dinamicamente

    '========================================
    '*** CLASE MIGRAR DATOS DINAMICAMENTE ***
    '========================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar(ByVal stParametros As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = stParametros

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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_MODOLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar(ByVal stParametros As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = stParametros

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MODOLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar(ByVal stParametros As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = stParametros

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MODOLIQU_X_ESTADO")
            Return False
        End Try

    End Function

End Class
