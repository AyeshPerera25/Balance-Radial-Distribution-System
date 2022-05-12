Module Project

    Public edges As New Dictionary(Of Integer, Edge)
    Public edgeCount As Integer
    Public loads As New Dictionary(Of Integer, Node)
    Public nodeLoadCount As Integer = 0

    Public filePath As String = Nothing

    Public passList As ListView



    Public connectionString As String = "PROVIDER=Microsoft.ACE.OLEDB.12.0;Data Source = 'db.accdb'"

    Public Function connectDatabase()
        Try
            Dim con As New OleDb.OleDbConnection
            con.ConnectionString = connectionString
            con.Open()
            con.Close()
            Return True
        Catch ex As Exception
            MsgBox("Database not found. Please reinstall the application.", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            Return False
        End Try
    End Function
End Module
