Public Class frmLoadBrowser

    Private dbID As Integer = 0

    Private Function loadTable()
        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString
        listModels.Items.Clear()

        If cmbType.Text = "All" Or cmbType.Text = "Transmission Lines" Then
            Try
                con.Open()
                COMMAND = New OleDb.OleDbCommand("SELECT * FROM lines WHERE title LIKE '%" & txtSearch.Text.Trim & "%' ORDER BY title", con)
                READER = COMMAND.ExecuteReader
                While READER.Read
                    Dim listArray(4) As String
                    listArray(0) = READER("ID").ToString
                    listArray(1) = "Transmission Lines"
                    listArray(2) = READER("title")
                    listArray(3) = READER("description")

                    Dim listItem As ListViewItem
                    listItem = New ListViewItem(listArray)
                    listModels.Items.Add(listItem)
                End While
                con.Close()
            Catch ex As Exception
                con.Dispose()
            End Try
        End If

        If cmbType.Text = "All" Or cmbType.Text = "Transformers" Then
            Try
                con.Open()
                COMMAND = New OleDb.OleDbCommand("SELECT * FROM transformers WHERE title LIKE '%" & txtSearch.Text.Trim & "%' ORDER BY title", con)
                READER = COMMAND.ExecuteReader
                While READER.Read
                    Dim listArray(4) As String
                    listArray(0) = READER("ID").ToString
                    listArray(1) = "Transformers"
                    listArray(2) = READER("title")
                    listArray(3) = READER("description")

                    Dim listItem As ListViewItem
                    listItem = New ListViewItem(listArray)
                    listModels.Items.Add(listItem)
                End While
                con.Close()
            Catch ex As Exception
                con.Dispose()
            End Try
        End If

        If cmbType.Text = "All" Or cmbType.Text = "Loads" Then
            Try
                con.Open()
                COMMAND = New OleDb.OleDbCommand("SELECT * FROM loads WHERE title LIKE '%" & txtSearch.Text.Trim & "%' ORDER BY title", con)
                READER = COMMAND.ExecuteReader
                While READER.Read
                    Dim listArray(4) As String
                    listArray(0) = READER("ID").ToString
                    listArray(1) = "Loads"
                    listArray(2) = READER("title")
                    listArray(3) = READER("description")

                    Dim listItem As ListViewItem
                    listItem = New ListViewItem(listArray)
                    listModels.Items.Add(listItem)
                End While
                con.Close()
            Catch ex As Exception
                con.Dispose()
            End Try
        End If

        If cmbType.Text = "All" Or cmbType.Text = "Capacitor Banks" Then
            Try
                con.Open()
                COMMAND = New OleDb.OleDbCommand("SELECT * FROM capacitors WHERE title LIKE '%" & txtSearch.Text.Trim & "%' ORDER BY title", con)
                READER = COMMAND.ExecuteReader
                While READER.Read
                    Dim listArray(4) As String
                    listArray(0) = READER("ID").ToString
                    listArray(1) = "Capacitor Banks"
                    listArray(2) = READER("title")
                    listArray(3) = READER("description")

                    Dim listItem As ListViewItem
                    listItem = New ListViewItem(listArray)
                    listModels.Items.Add(listItem)
                End While
                con.Close()
            Catch ex As Exception
                con.Dispose()
            End Try
        End If

        If cmbType.Text = "All" Or cmbType.Text = "Distributed Generators" Then
            Try
                con.Open()
                COMMAND = New OleDb.OleDbCommand("SELECT * FROM generators WHERE title LIKE '%" & txtSearch.Text.Trim & "%' ORDER BY title", con)
                READER = COMMAND.ExecuteReader
                While READER.Read
                    Dim listArray(4) As String
                    listArray(0) = READER("ID").ToString
                    listArray(1) = "Distributed Generators"
                    listArray(2) = READER("title")
                    listArray(3) = READER("description")

                    Dim listItem As ListViewItem
                    listItem = New ListViewItem(listArray)
                    listModels.Items.Add(listItem)
                End While
                con.Close()
            Catch ex As Exception
                con.Dispose()
            End Try
        End If

    End Function

    Public Overloads Function ShowDialog(ByVal overloaded As Boolean, ByVal type As String) As Integer
        cmbType.Text = type
        loadTable()
        Me.ShowDialog()
        Return dbID
    End Function

    Public Overloads Shared Function Show(ByVal overloaded As Boolean, ByVal type As String) As Integer
        Dim tmp As New frmLoadBrowser
        Return tmp.ShowDialog(overloaded:=True, type)
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        loadTable()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If listModels.SelectedItems.Count > 0 Then
            dbID = Integer.Parse(listModels.FocusedItem.SubItems(0).Text)
            Me.Close()
        End If
    End Sub

    Private Sub listModels_DoubleClick(sender As Object, e As EventArgs) Handles listModels.DoubleClick
        If listModels.SelectedItems.Count > 0 Then
            dbID = Integer.Parse(listModels.FocusedItem.SubItems(0).Text)
            Me.Close()
        End If
    End Sub
End Class