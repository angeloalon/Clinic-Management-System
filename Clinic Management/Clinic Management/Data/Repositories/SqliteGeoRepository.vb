Imports Microsoft.Data.Sqlite

Public Class SqliteGeoRepository

    ''' <summary>
    ''' Retrieves distinct province names from the PSGC geographic table.
    ''' </summary>
    Public Shared Function GetProvinces() As List(Of String)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of String)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT DISTINCT province_name FROM psgc_geographic ORDER BY province_name ASC;"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(reader.GetString(0))
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ''' <summary>
    ''' Retrieves cities and municipalities belonging to a specific province.
    ''' </summary>
    Public Shared Function GetCitiesByProvince(provinceName As String) As List(Of String)
        If String.IsNullOrWhiteSpace(provinceName) Then Return New List(Of String)()
        DatabaseInitializer.Initialize()
        Dim list As New List(Of String)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT DISTINCT city_name FROM psgc_geographic WHERE province_name = @prov ORDER BY city_name ASC;"
                cmd.Parameters.AddWithValue("@prov", provinceName.Trim())
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(reader.GetString(0))
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

End Class
