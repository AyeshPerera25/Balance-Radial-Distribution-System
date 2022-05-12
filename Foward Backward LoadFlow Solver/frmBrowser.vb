Public Class frmBrowser
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

    Private Sub frmBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbType.SelectedIndex = 0
        loadTable()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        loadTable()
    End Sub

    Private Sub listModels_DoubleClick(sender As Object, e As EventArgs) Handles listModels.DoubleClick
        If listModels.SelectedItems.Count > 0 Then
            Dim dbID = Integer.Parse(listModels.FocusedItem.SubItems(0).Text)

            If listModels.FocusedItem.SubItems(1).Text = "Transmission Lines" Then
                Dim result As New Line(dbID)
                Dim line = frmAddLine.ShowDialog(False, result)
                If line.isValid Then
                    line.updateDatabase()
                    loadTable()
                End If
            ElseIf listModels.FocusedItem.SubItems(1).Text = "Transformers" Then
                Dim result As New Transformer(dbID)
                Dim transformer = frmAddTransformer.ShowDialog(False, result)
                If transformer.isValid Then
                    transformer.updateDatabase()
                    loadTable()
                End If
            ElseIf listModels.FocusedItem.SubItems(1).Text = "Loads" Then
                Dim result As New Load(dbID)
                Dim load = frmAddLoad.ShowDialog(False, result)
                If load.isValid Then
                    load.updateDatabase()
                    loadTable()
                End If
            ElseIf listModels.FocusedItem.SubItems(1).Text = "Capacitor Banks" Then
                Dim result As New ShuntCapacitor(dbID)
                Dim capacitor = frmAddShuntCapacitor.ShowDialog(False, result)
                If capacitor.isValid Then
                    capacitor.updateDatabase()
                    loadTable()
                End If
            ElseIf listModels.FocusedItem.SubItems(1).Text = "Distributed Generators" Then
                Dim result As New DG(dbID)
                Dim generator = frmAddDG.ShowDialog(False, result)
                If generator.isValid Then
                    generator.updateDatabase()
                    loadTable()
                End If
            End If
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        loadTable()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If listModels.SelectedItems.Count > 0 Then
            Dim dbID = Integer.Parse(listModels.FocusedItem.SubItems(0).Text)

            Dim dialogResult As DialogResult = MessageBox.Show("Are you sure do you want to delete this model?", "Delete Model", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialogResult = DialogResult.Yes Then
                Dim con As New OleDb.OleDbConnection
                Dim READER As OleDb.OleDbDataReader
                Dim COMMAND As OleDb.OleDbCommand
                con.ConnectionString = Project.connectionString

                If listModels.FocusedItem.SubItems(1).Text = "Transmission Lines" Then
                    COMMAND = New OleDb.OleDbCommand("DELETE FROM lines WHERE ID=@dbID", con)
                    COMMAND.Parameters.AddWithValue("dbID", dbID)
                ElseIf listModels.FocusedItem.SubItems(1).Text = "Transformers" Then
                    COMMAND = New OleDb.OleDbCommand("DELETE FROM transformers WHERE ID=@dbID", con)
                    COMMAND.Parameters.AddWithValue("dbID", dbID)
                ElseIf listModels.FocusedItem.SubItems(1).Text = "Loads" Then
                    COMMAND = New OleDb.OleDbCommand("DELETE FROM loads WHERE ID=@dbID", con)
                    COMMAND.Parameters.AddWithValue("dbID", dbID)
                ElseIf listModels.FocusedItem.SubItems(1).Text = "Capacitor Banks" Then
                    COMMAND = New OleDb.OleDbCommand("DELETE FROM capacitors WHERE ID=@dbID", con)
                    COMMAND.Parameters.AddWithValue("dbID", dbID)
                ElseIf listModels.FocusedItem.SubItems(1).Text = "Distributed Generators" Then
                    COMMAND = New OleDb.OleDbCommand("DELETE FROM generators WHERE ID=@dbID", con)
                    COMMAND.Parameters.AddWithValue("dbID", dbID)
                End If

                Try
                    con.Open()
                    READER = COMMAND.ExecuteReader
                    con.Close()
                Catch ex As Exception
                    frmMain.addLog(ex.Message, Color.Red)
                    con.Dispose()
                End Try

                loadTable()
            End If
        End If
    End Sub

    Private Sub btnAddLine_Click(sender As Object, e As EventArgs) Handles btnAddLine.Click
        Dim line = frmAddLine.ShowDialog(False, New Line)
        If line.isValid Then
            line.addToDatabase()
            loadTable()
        End If
    End Sub

    Private Sub btnAddTransformer_Click(sender As Object, e As EventArgs) Handles btnAddTransformer.Click
        Dim transformer = frmAddTransformer.ShowDialog(False, New Transformer)
        If transformer.isValid Then
            transformer.addToDatabase()
            loadTable()
        End If
    End Sub

    Private Sub btnAddLoad_Click(sender As Object, e As EventArgs) Handles btnAddLoad.Click
        Dim load = frmAddLoad.ShowDialog(False, New Load)
        If load.isValid Then
            load.addToDatabase()
            loadTable()
        End If
    End Sub

    Private Sub btnAddCapacitor_Click(sender As Object, e As EventArgs) Handles btnAddCapacitor.Click
        Dim capacitor = frmAddShuntCapacitor.ShowDialog(False, New ShuntCapacitor)
        If capacitor.isValid Then
            capacitor.addToDatabase()
            loadTable()
        End If
    End Sub

    Private Sub btnAddGenerator_Click(sender As Object, e As EventArgs) Handles btnAddGenerator.Click
        Dim generator = frmAddDG.ShowDialog(False, New DG)
        If generator.isValid Then
            generator.addToDatabase()
            loadTable()
        End If
    End Sub
End Class