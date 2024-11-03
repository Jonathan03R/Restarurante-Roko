Imports System.Data.SqlClient
'Module ModuloSistema
'    'Cadena de conexión
'    Public cCadenaConexion As String = "Data Source=DESKTOP-D9BFG02;Initial Catalog=BDRestauranteRoko;Integrated Security=True"
'    Public vClientesRecuperado As Integer = 0
'End Module


' aqui estoy haciendo otro enfoque de conexion para llevar a cado un manejo de los datos mas optimizados.
Module ModuloSistema
    ' Cadena de conexión a la base de datos
    Public cCadenaConexion As String = "Data Source=DESKTOP-D9BFG02;Initial Catalog=BDRestauranteRoko;Integrated Security=True"
    Private conexion As SqlConnection
    Private transaccion As SqlTransaction

    ' Método para abrir la conexión
    Public Sub AbrirConexion()
        Try
            If conexion Is Nothing OrElse conexion.State = ConnectionState.Closed Then
                conexion = New SqlConnection(cCadenaConexion)
                conexion.Open()
            End If
        Catch ex As Exception
            Throw New Exception("Error en la conexión con la base de datos.", ex)
        End Try
    End Sub


    ' Método para cerrar la conexión
    Public Sub CerrarConexion()
        Try
            If transaccion Is Nothing AndAlso conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        Catch ex As Exception
            Throw New Exception("Error al cerrar la conexión con la base de datos.", ex)
        End Try
    End Sub

    ' Método para iniciar una transacción
    Public Sub IniciarTransaccion()
        Try
            If transaccion Is Nothing Then
                AbrirConexion() ' Abrir la conexión solo si no hay una transacción activa
                transaccion = conexion.BeginTransaction()
                Debug.WriteLine("Transacción INICIADA -----------------------------------------------------------------------------------------------------------------------------------.")
            Else
                Throw New Exception("Ya hay una transacción activa.")
            End If
        Catch ex As Exception
            Throw New Exception("Error al iniciar la transacción con la base de datos.", ex)
        End Try
    End Sub

    ' Método para confirmar la transacción y cerrar la conexión
    Public Sub TerminarTransaccion()
        Try
            If transaccion IsNot Nothing Then
                transaccion.Commit()
                transaccion = Nothing
                Debug.WriteLine("Transacción TERMINADA ********************************************************************************************************************************************************************************************.")
                CerrarConexion() ' Cerrar la conexión si la transacción ha terminado
            End If
        Catch ex As Exception
            Throw New Exception("Error al terminar la transacción con la base de datos.", ex)
        End Try
    End Sub

    ' Método para cancelar la transacción y cerrar la conexión
    Public Sub CancelarTransaccion()
        Try
            If transaccion IsNot Nothing Then
                transaccion.Rollback()
                transaccion = Nothing
                CerrarConexion() ' Cerrar la conexión si la transacción ha sido cancelada
            End If
        Catch ex As Exception
            Throw New Exception("Error al cancelar la transacción con la base de datos.", ex)
        End Try
    End Sub

    ' Método para ejecutar un procedimiento almacenado sin abrir conexión automáticamente
    Public Function ObtenerComandoDeProcedimiento(procedimientoAlmacenado As String) As SqlCommand
        Try
            If conexion Is Nothing OrElse conexion.State = ConnectionState.Closed Then
                Throw New InvalidOperationException("La conexión no está abierta. Inicie una transacción o abra la conexión manualmente.")
            End If

            Dim comandoSQL As SqlCommand = conexion.CreateCommand()
            comandoSQL.Transaction = transaccion
            comandoSQL.CommandText = procedimientoAlmacenado
            comandoSQL.CommandType = CommandType.StoredProcedure
            Return comandoSQL
        Catch ex As Exception
            Throw New Exception("Error al obtener comando de ejecución: " & ex.Message)
        End Try
    End Function
End Module



