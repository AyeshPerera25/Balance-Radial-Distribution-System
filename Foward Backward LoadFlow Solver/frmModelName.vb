Public Class frmModelName

    Private data(2) As String

    Public Overloads Function ShowDialog(ByVal overloaded As Boolean) As String()
        txtDescription.Clear()
        txtTitle.Clear()
        Me.ShowDialog()
        Return data
    End Function

    Public Overloads Shared Function Show(ByVal overloaded As Boolean) As String()
        Dim tmp As New frmModelName
        Return tmp.ShowDialog(overloaded:=True)
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtTitle.Text.Trim <> "" And txtDescription.Text.Trim <> "" Then
            data(0) = txtTitle.Text
            data(1) = txtDescription.Text
            Me.Close()
        Else
            MsgBox("Please fill all the required parameters", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
        End If
    End Sub
End Class