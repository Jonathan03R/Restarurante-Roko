Public Class ProcesoGestionarMesasServicio
    Private mesasSQL As New MesaSQL()

    Public Function CrearUnaNuevaMesa(Optional estado As String = Nothing) As DataTable
        Try
            IniciarTransaccion()

            Dim listaMesas As List(Of Mesa) = mesasSQL.ObtenerMesas(estado)
            Dim dataTable As New DataTable()
            dataTable.Columns.Add("MesasCodigo", GetType(String))
            dataTable.Columns.Add("MesasCapacidad", GetType(Integer))
            dataTable.Columns.Add("MesasEstado", GetType(String))
            For Each mesa As Mesa In listaMesas
                Dim row As DataRow = dataTable.NewRow()
                row("MesasCodigo") = mesa.MesasCodigo
                row("MesasCapacidad") = mesa.MesasCapacidad
                row("MesasEstado") = mesa.MesasEstado
                dataTable.Rows.Add(row)
            Next
            TerminarTransaccion()
            Return dataTable

        Catch ex As Exception
            CancelarTransaccion()
            Throw ex
        End Try
    End Function
End Class