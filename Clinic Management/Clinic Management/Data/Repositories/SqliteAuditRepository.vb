Imports Microsoft.Data.Sqlite

Public Class SqliteAuditRepository

    Public Shared Function GetAll() As List(Of AuditEntry)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of AuditEntry)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT log_time, user_name, role, action, details, result
                    FROM audit_logs
                    ORDER BY id DESC;
                "
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim entry As New AuditEntry With {
                            .UserName = reader.GetString(1),
                            .Role = reader.GetString(2),
                            .Action = reader.GetString(3),
                            .Details = If(reader.IsDBNull(4), "", reader.GetString(4)),
                            .Result = reader.GetString(5)
                        }
                        Dim dt As DateTime
                        If DateTime.TryParse(reader.GetString(0), dt) Then
                            entry.Time = dt
                        Else
                            entry.Time = DateTime.Now
                        End If
                        list.Add(entry)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    Public Shared Sub Log(user As String, role As String, action As String, details As String, result As String)
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO audit_logs (log_time, user_name, role, action, details, result)
                    VALUES (@time, @user, @role, @action, @details, @result);
                "
                DatabaseService.AddParam(cmd, "@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                DatabaseService.AddParam(cmd, "@user", If(String.IsNullOrWhiteSpace(user), "System", user))
                DatabaseService.AddParam(cmd, "@role", If(String.IsNullOrWhiteSpace(role), "System", role))
                DatabaseService.AddParam(cmd, "@action", If(String.IsNullOrWhiteSpace(action), "General", action))
                DatabaseService.AddParam(cmd, "@details", If(details, ""))
                DatabaseService.AddParam(cmd, "@result", If(String.IsNullOrWhiteSpace(result), "Success", result))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
