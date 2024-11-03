Imports System.Data.SqlClient
Imports System.IO

Public Class MenuSQL
    ' Método para listar el menú activo
    Public Function ListarMenuActivo() As List(Of Menu)
        Dim listaMenu As New List(Of Menu)

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spListarMenuActivo")

            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim menuFoto As Image = Nothing
                    If Not IsDBNull(dr("MenuFoto")) Then
                        Dim bytes As Byte() = CType(dr("MenuFoto"), Byte())
                        Using ms As New MemoryStream(bytes)
                            menuFoto = Image.FromStream(ms)
                        End Using
                    End If

                    Dim menuItem As New Menu() With {
                        .MenuCodigo = dr("MenuCodigo").ToString().Trim(),
                        .MenuNombre = dr("MenuNombre").ToString(),
                        .MenuDescripcion = dr("MenuDescripcion").ToString(),
                        .MenuPrecio = Convert.ToDouble(dr("MenuPrecio")),
                        .MenuEstado = dr("MenuEstado").ToString(),
                        .MenuFoto = menuFoto
                    }

                    listaMenu.Add(menuItem)
                End While
            End Using
        Catch ex As Exception
            Throw ex

        End Try

        Return listaMenu
    End Function

    ' Método para obtener un menú específico por su código
    Public Function ObtenerMenuPorCodigo(menuCodigo As Menu) As Menu
        Dim menu As Menu = Nothing

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spObtenerMenuPorCodigo")
            cmd.Parameters.Add("@MenuCodigo", SqlDbType.NChar, 8).Value = menuCodigo.MenuCodigo.Trim()

            Using dr As SqlDataReader = cmd.ExecuteReader()
                If dr.Read() Then
                    Dim menuFoto As Image = Nothing
                    If Not IsDBNull(dr("MenuFoto")) Then
                        Dim bytes As Byte() = CType(dr("MenuFoto"), Byte())
                        Using ms As New MemoryStream(bytes)
                            menuFoto = Image.FromStream(ms)
                        End Using
                    End If

                    Dim menuItem As New Menu() With {
                        .MenuCodigo = dr("MenuCodigo").ToString().Trim(),
                        .MenuNombre = dr("MenuNombre").ToString(),
                        .MenuDescripcion = dr("MenuDescripcion").ToString(),
                        .MenuPrecio = Convert.ToDouble(dr("MenuPrecio")),
                        .MenuEstado = dr("MenuEstado").ToString(),
                        .MenuFoto = menuFoto
                    }

                    menu = menuItem
                End If
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener el menú por código: " & ex.Message)

        End Try

        Return menu
    End Function

    ' Método para actualizar un menú
    Public Function ActualizarMenu(menu As Menu) As Boolean
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spActualizarMenu")

            ' Agregar parámetros
            cmd.Parameters.Add("@MenuCodigo", SqlDbType.NChar, 8).Value = menu.MenuCodigo.Trim()
            cmd.Parameters.Add("@MenuNombre", SqlDbType.VarChar, 50).Value = menu.MenuNombre
            cmd.Parameters.Add("@MenuDescripcion", SqlDbType.NVarChar, 100).Value = menu.MenuDescripcion
            cmd.Parameters.Add("@MenuPrecio", SqlDbType.Decimal).Value = menu.MenuPrecio
            cmd.Parameters.Add("@MenuEstado", SqlDbType.NChar, 1).Value = menu.MenuEstado

            ' Manejar la imagen
            If menu.MenuFoto IsNot Nothing Then
                Dim ms As New MemoryStream()
                menu.MenuFoto.Save(ms, menu.MenuFoto.RawFormat)
                Dim imageData As Byte() = ms.ToArray()
                cmd.Parameters.Add("@MenuFoto", SqlDbType.Image).Value = imageData
            Else
                cmd.Parameters.Add("@MenuFoto", SqlDbType.Image).Value = DBNull.Value
            End If

            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw New Exception("Error al actualizar el menú: " & ex.Message)
        End Try
    End Function

    ' Método para insertar un menú
    Public Function InsertarMenu(menu As Menu) As Boolean
        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spInsertarMenu")
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

            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw New Exception("Error al insertar el menú: " & ex.Message)
        End Try
    End Function

    ' Método para listar todos los menús
    Public Function ListarMenu() As List(Of Menu)
        Dim listaMenu As New List(Of Menu)

        Try
            Dim cmd As SqlCommand = ModuloSistema.ObtenerComandoDeProcedimiento("spListarMenu")

            Using dr As SqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    Dim menuFoto As Image = Nothing
                    If Not IsDBNull(dr("MenuFoto")) Then
                        Dim bytes As Byte() = CType(dr("MenuFoto"), Byte())
                        Using ms As New MemoryStream(bytes)
                            menuFoto = Image.FromStream(ms)
                        End Using
                    End If

                    Dim menuItem As New Menu() With {
                        .MenuCodigo = dr("MenuCodigo").ToString().Trim(),
                        .MenuNombre = dr("MenuNombre").ToString(),
                        .MenuDescripcion = dr("MenuDescripcion").ToString(),
                        .MenuPrecio = Convert.ToDouble(dr("MenuPrecio")),
                        .MenuEstado = dr("MenuEstado").ToString(),
                        .MenuFoto = menuFoto
                    }

                    listaMenu.Add(menuItem)
                End While
            End Using
        Catch ex As Exception
            Throw New Exception("Error al listar el menú: " & ex.Message)
        End Try

        Return listaMenu
    End Function


End Class
