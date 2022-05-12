Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPython.Text = My.Settings.pythonPath
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.pythonPath = txtPython.Text
        My.Settings.Save()
        Me.Close()
    End Sub
End Class