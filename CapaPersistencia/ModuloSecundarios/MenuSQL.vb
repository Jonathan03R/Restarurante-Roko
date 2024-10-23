Imports System.Data.SqlClient
Imports System.IO

Public Class MenuSQL
    Public Function ListarMenuActivo() As List(Of Menu)
        Dim listaMenu As New List(Of Menu)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spListarMenuActivo", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                Dim menuFoto As Image = Nothing
                If Not IsDBNull(dr("MenuFoto")) Then
                    Dim bytes As Byte() = CType(dr("MenuFoto"), Byte())
                    Using ms As New MemoryStream(bytes)
                        menuFoto = Image.FromStream(ms)
                    End Using
                End If
                Dim menuItem As New Menu()
                menuItem.MenuCodigo = dr("MenuCodigo").ToString().Trim()
                menuItem.MenuNombre = dr("MenuNombre").ToString()
                menuItem.MenuDescripcion = dr("MenuDescripcion").ToString()
                menuItem.MenuPrecio = Convert.ToDouble(dr("MenuPrecio"))
                menuItem.MenuEstado = dr("MenuEstado").ToString()
                menuItem.MenuFoto = menuFoto

                listaMenu.Add(menuItem)
            End While
        End Using

        Return listaMenu
    End Function

    Public Function ObtenerMenuPorCodigo(menuCodigo As String) As Menu
        Dim menu As Menu = Nothing

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spObtenerMenuPorCodigo", cn)
            cmd.CommandType = CommandType.StoredProcedure
            ' Asegurar que el parámetro es de tipo NChar y tiene longitud 8
            cmd.Parameters.Add("@MenuCodigo", SqlDbType.NChar, 8).Value = menuCodigo.Trim()

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.Read() Then
                ' Resto del código para asignar valores...
                Dim menuFoto As Image = Nothing
                If Not IsDBNull(dr("MenuFoto")) Then
                    Dim bytes As Byte() = CType(dr("MenuFoto"), Byte())
                    Using ms As New MemoryStream(bytes)
                        menuFoto = Image.FromStream(ms)
                    End Using
                End If
                Dim menuItem As New Menu()
                menuItem.MenuCodigo = dr("MenuCodigo").ToString().Trim()
                menuItem.MenuNombre = dr("MenuNombre").ToString()
                menuItem.MenuDescripcion = dr("MenuDescripcion").ToString()
                menuItem.MenuPrecio = Convert.ToDouble(dr("MenuPrecio"))
                menuItem.MenuEstado = dr("MenuEstado").ToString()
                menuItem.MenuFoto = menuFoto

                menu = menuItem
            End If
        End Using

        Return menu
    End Function


    Public Function ActualizarMenu(menu As Menu) As Boolean
        Try
            Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
                Using cmd As New SqlCommand("spActualizarMenu", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    ' Agregar parámetros
                    cmd.Parameters.Add("@MenuCodigo", SqlDbType.NChar, 8).Value = menu.MenuCodigo.Trim()
                    cmd.Parameters.Add("@MenuNombre", SqlDbType.VarChar, 50).Value = menu.MenuNombre
                    cmd.Parameters.Add("@MenuDescripcion", SqlDbType.NVarChar, 100).Value = menu.MenuDescripcion
                    cmd.Parameters.Add("@MenuPrecio", SqlDbType.Decimal).Value = menu.MenuPrecio
                    cmd.Parameters.Add("@MenuEstado", SqlDbType.NChar, 1).Value = menu.MenuEstado

                    ' Manejar la imagen
                    If menu.MenuFoto IsNot Nothing Then
                        ' Convertir la imagen a un arreglo de bytes
                        Dim ms As New MemoryStream()
                        menu.MenuFoto.Save(ms, menu.MenuFoto.RawFormat)
                        Dim imageData As Byte() = ms.ToArray()
                        cmd.Parameters.Add("@MenuFoto", SqlDbType.Image).Value = imageData
                    Else
                        cmd.Parameters.Add("@MenuFoto", SqlDbType.Image).Value = DBNull.Value
                    End If

                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            ' Manejar excepciones (puedes registrar el error o mostrar un mensaje)
            Throw New Exception("Error al actualizar el menú: " & ex.Message)
        End Try
    End Function

    Public Function InsertarMenu(menu As Menu) As Boolean
        Try
            Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
                Using cmd As New SqlCommand("spInsertarMenu", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@MenuCodigo", SqlDbType.NChar, 8).Value = menu.MenuCodigo.Trim()
                    cmd.Parameters.Add("@MenuNombre", SqlDbType.VarChar, 50).Value = menu.MenuNombre
                    cmd.Parameters.Add("@MenuDescripcion", SqlDbType.NVarChar, 100).Value = menu.MenuDescripcion
                    cmd.Parameters.Add("@MenuPrecio", SqlDbType.Decimal).Value = menu.MenuPrecio
                    If menu.MenuFoto IsNot Nothing Then
                        Dim ms As New MemoryStream()
                        menu.MenuFoto.Save(ms, menu.MenuFoto.RawFormat)
                        Dim imageData As Byte() = ms.ToArray()
                        cmd.Parameters.Add("@MenuFoto", SqlDbType.Image).Value = imageData
                    Else
                        cmd.Parameters.Add("@MenuFoto", SqlDbType.Image).Value = DBNull.Value
                    End If

                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            Throw New Exception("Error al insertar el menú: " & ex.Message)
        End Try
    End Function

    Public Function ListarMenu() As List(Of Menu)
        Dim listaMenu As New List(Of Menu)

        Using cn As New SqlConnection(ModuloSistema.cCadenaConexion)
            Dim cmd As New SqlCommand("spListarMenu", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                Dim menuFoto As Image = Nothing
                If Not IsDBNull(dr("MenuFoto")) Then
                    Dim bytes As Byte() = CType(dr("MenuFoto"), Byte())
                    Using ms As New MemoryStream(bytes)
                        menuFoto = Image.FromStream(ms)
                    End Using
                End If

                Dim menuItem As New Menu()
                menuItem.MenuCodigo = dr("MenuCodigo").ToString().Trim()
                menuItem.MenuNombre = dr("MenuNombre").ToString()
                menuItem.MenuDescripcion = dr("MenuDescripcion").ToString()
                menuItem.MenuPrecio = Convert.ToDouble(dr("MenuPrecio"))
                menuItem.MenuEstado = dr("MenuEstado").ToString()
                menuItem.MenuFoto = menuFoto

                listaMenu.Add(menuItem)
            End While
        End Using

        Return listaMenu
    End Function


End Class
