Public Class frmAddLine

    Private line As Line


    ' *** Custom Dialog ***
    Public Overloads Function ShowDialog(ByVal isEditor As Boolean, ByVal line As Line) As Line
        Me.line = line
        setupForm()
        If isEditor Then
            txtTitle.Text = "Transmission Line"
            txtDescription.Text = "Model Tx Line with Exact Line Model"
            txtTitle.ReadOnly = True
            txtDescription.ReadOnly = True
            txtStartNode.Enabled = True
            txtEndNode.Enabled = True
            btnLibrary.Visible = True
            btnAddToLibrary.Visible = True
        Else
            txtStartNode.Text = "NA"
            txtEndNode.Text = "NA"
            txtStartNode.Enabled = False
            txtEndNode.Enabled = False
            btnLibrary.Visible = False
            btnAddToLibrary.Visible = False
            txtTitle.ReadOnly = False
            txtDescription.ReadOnly = False
        End If
        Me.ShowDialog()
        Return line
    End Function

    Public Overloads Shared Function Show(ByVal overloaded As Boolean, ByVal line As Line) As Line
        Dim tmp As New frmAddLine
        Return tmp.ShowDialog(isEditor:=True, New Line)
    End Function

    Private Function setupForm()
        txtTitle.Text = line.title
        txtDescription.Text = line.description
        txtStartNode.Text = line.startNode
        txtEndNode.Text = line.endNode
        cmbPhases.Text = line.phases
        chkNeutral.Checked = line.isNeutralAvailable
        txtResistance_P.Text = line.resistance_p
        txtGmr_P.Text = line.gmr_p
        txtResistance_N.Text = line.resistance_n
        txtGmr_N.Text = line.gmr_n
        txtLength.Text = line.length
        txtFrequency.Text = line.frequency
        txtSoilResistivity.Text = line.soilResistivity
        cmbType.Text = line.type
        txt12.Text = line.L_12
        txt13.Text = line.L_13
        txt23.Text = line.L_23
        txt1n.Text = line.L_1N
        txt2n.Text = line.L_2N
        txt3n.Text = line.L_3N
        line.isValid = False

        If chkNeutral.CheckState = CheckState.Checked Then
            If cmbPhases.Text = 3 Then
                txt1n.Enabled = True
                txt2n.Enabled = True
                txt3n.Enabled = True
            ElseIf cmbPhases.Text = 2 Then
                txt1n.Enabled = True
                txt2n.Enabled = True
            Else
                txt1n.Enabled = True
            End If
            txtGmr_N.Enabled = True
            txtResistance_N.Enabled = True
        Else
            txt1n.Enabled = False
            txt2n.Enabled = False
            txt3n.Enabled = False
            txtGmr_N.Enabled = False
            txtResistance_N.Enabled = False
        End If

        If cmbPhases.Text = 3 Then
            txt12.Enabled = True
            txt13.Enabled = True
            txt23.Enabled = True
        ElseIf cmbPhases.Text = 2 Then
            txt12.Enabled = True
            txt13.Enabled = False
            txt23.Enabled = False
        Else
            txt12.Enabled = False
            txt13.Enabled = False
            txt23.Enabled = False
        End If

        If chkNeutral.CheckState = CheckState.Checked Then
            If cmbPhases.Text = 3 Then
                txt1n.Enabled = True
                txt2n.Enabled = True
                txt3n.Enabled = True
            ElseIf cmbPhases.Text = 2 Then
                txt1n.Enabled = True
                txt2n.Enabled = True
                txt3n.Enabled = False
            Else
                txt1n.Enabled = True
                txt2n.Enabled = False
                txt3n.Enabled = False
            End If
        Else
            txt1n.Enabled = False
            txt2n.Enabled = False
            txt3n.Enabled = False
        End If
    End Function

    Private Sub validate()
        If txtTitle.Text <> "" Then
            If txtDescription.Text.Trim <> "" Then
                If txtStartNode.Text <> "" Then
                    If txtEndNode.Text.Trim <> "" Then
                        If txtResistance_P.Text <> "" Then
                            If txtGmr_P.Text.Trim <> "" Then
                                If txtResistance_N.Text <> "" Then
                                    If txtGmr_N.Text.Trim <> "" Then
                                        If txtLength.Text.Trim <> "" Then
                                            If txtFrequency.Text.Trim <> "" Then
                                                If txtSoilResistivity.Text.Trim <> "" Then
                                                    If txt12.Text.Trim <> "" Then
                                                        If txt13.Text.Trim <> "" Then
                                                            If txt23.Text.Trim <> "" Then
                                                                If txt1n.Text.Trim <> "" Then
                                                                    If txt2n.Text.Trim <> "" Then
                                                                        If txt3n.Text.Trim <> "" Then
                                                                            If cmbPhases.SelectedIndex >= 0 Then
                                                                                If cmbType.SelectedIndex >= 0 Then
                                                                                    line.isValid = True
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If txtStartNode.Text <> "NA" Then
            If txtStartNode.Text.Trim = 0 Then
                line.isValid = False
                MsgBox("You cannot select 0 as Node ID. Please select number above 0.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If txtEndNode.Text <> "NA" Then
            If txtEndNode.Text.Trim = 0 Then
                line.isValid = False
                MsgBox("You cannot select 0 as Node ID. Please select number above 0.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If txtStartNode.Text <> "NA" And txtEndNode.Text <> "NA" Then
            If txtStartNode.Text.Trim = txtEndNode.Text.Trim Then
                line.isValid = False
                MsgBox("Start node and end note cannot be same.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If txtGmr_P.Text = 0 Then
            line.isValid = False
            MsgBox("Phase GMR should be greater than 0", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
            Exit Sub
        End If

        If txtResistance_P.Text = 0 Then
            line.isValid = False
            MsgBox("Phase Resistance should be greater than 0", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
            Exit Sub
        End If

        If chkNeutral.Checked And txtGmr_N.Text = 0 Then
            line.isValid = False
            MsgBox("Neutral GMR should be greater than 0", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
            Exit Sub
        End If

        If chkNeutral.Checked And txtResistance_N.Text = 0 Then
            line.isValid = False
            MsgBox("Neutral Resistance should be greater than 0", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
            Exit Sub
        End If

        If txtLength.Text = 0 Then
            line.isValid = False
            MsgBox("Length should be greater than 0", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
            Exit Sub
        End If

        If txtFrequency.Text = 0 Then
            line.isValid = False
            MsgBox("Frequency should be greater than 0", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
            Exit Sub
        End If

        If txtSoilResistivity.Text = 0 Then
            line.isValid = False
            MsgBox("Soil Resistivity should be greater than 0", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
            Exit Sub
        End If

        If line.isValid = False Then
            MsgBox("Please fill all the required parameters", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        validate()

        If line.isValid Then
            line.title = txtTitle.Text
            line.description = txtDescription.Text
            If txtStartNode.Text <> "NA" Then
                line.startNode = txtStartNode.Text
                line.endNode = txtEndNode.Text
            End If
            line.resistance_p = txtResistance_P.Text
            line.gmr_p = txtGmr_P.Text
            line.resistance_n = txtResistance_N.Text
            line.gmr_n = txtGmr_N.Text
            line.length = txtLength.Text
            line.frequency = txtFrequency.Text
            line.soilResistivity = txtSoilResistivity.Text
            line.type = cmbType.Text
            line.phases = cmbPhases.Text
            line.isNeutralAvailable = chkNeutral.Checked
            line.L_12 = txt12.Text
            line.L_23 = txt23.Text
            line.L_13 = txt13.Text
            line.L_1N = txt1n.Text
            line.L_2N = txt2n.Text
            line.L_3N = txt3n.Text
            Me.Close()
        End If
    End Sub

    Private Sub btnLibrary_Click(sender As Object, e As EventArgs) Handles btnLibrary.Click
        Dim dbID = frmLoadBrowser.ShowDialog(True, "Transmission Lines")
        If dbID > 0 Then
            Dim _line = New Line(dbID)
            line.title = _line.title
            line.description = _line.description
            line.resistance_p = _line.resistance_p
            line.gmr_p = _line.gmr_p
            line.resistance_n = _line.resistance_n
            line.gmr_n = _line.gmr_n
            line.length = _line.length
            line.frequency = _line.frequency
            line.soilResistivity = _line.soilResistivity
            line.type = _line.type
            line.phases = _line.phases
            line.isNeutralAvailable = _line.isNeutralAvailable
            line.L_12 = _line.L_12
            line.L_23 = _line.L_23
            line.L_13 = _line.L_13
            line.L_1N = _line.L_1N
            line.L_2N = _line.L_2N
            line.L_3N = _line.L_3N
            setupForm()
        End If
    End Sub

    Private Sub btnAddToLibrary_Click(sender As Object, e As EventArgs) Handles btnAddToLibrary.Click
        Dim data = frmModelName.ShowDialog(True)
        If data(0) <> "" And data(1) <> "" Then
            Dim _line = line
            _line.title = data(0)
            _line.description = data(1)
            _line.addToDatabase()
            MsgBox("Model successfully saved to database", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
        End If
    End Sub

    Private Sub chkNeutral_CheckedChanged(sender As Object, e As EventArgs) Handles chkNeutral.CheckedChanged
        If chkNeutral.CheckState = CheckState.Checked Then
            If cmbPhases.Text = 3 Then
                txt1n.Enabled = True
                txt2n.Enabled = True
                txt3n.Enabled = True
            ElseIf cmbPhases.Text = 2 Then
                txt1n.Enabled = True
                txt2n.Enabled = True
                txt3n.Text = 0
            Else
                txt1n.Enabled = True
                txt2n.Text = 0
                txt3n.Text = 0
            End If
            txtGmr_N.Text = 0
            txtResistance_N.Text = 0
            txtGmr_N.Enabled = True
            txtResistance_N.Enabled = True
        Else
            txt1n.Enabled = False
            txt2n.Enabled = False
            txt3n.Enabled = False
            txt1n.Text = 0
            txt2n.Text = 0
            txt3n.Text = 0
            txtGmr_N.Text = 0
            txtResistance_N.Text = 0
            txtGmr_N.Enabled = False
            txtResistance_N.Enabled = False
        End If
    End Sub

    Private Sub cmbPhases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPhases.SelectedIndexChanged
        If cmbPhases.Text = 3 Then
            txt12.Enabled = True
            txt13.Enabled = True
            txt23.Enabled = True
        ElseIf cmbPhases.Text = 2 Then
            txt12.Enabled = True
            txt13.Enabled = False
            txt23.Enabled = False
            txt13.Text = 0
            txt23.Text = 0
        Else
            txt12.Enabled = False
            txt13.Enabled = False
            txt23.Enabled = False
            txt12.Text = 0
            txt13.Text = 0
            txt23.Text = 0
        End If

        If chkNeutral.CheckState = CheckState.Checked Then
            If cmbPhases.Text = 3 Then
                txt1n.Enabled = True
                txt2n.Enabled = True
                txt3n.Enabled = True
            ElseIf cmbPhases.Text = 2 Then
                txt1n.Enabled = True
                txt2n.Enabled = True
                txt3n.Enabled = False
                txt3n.Text = 0
            Else
                txt1n.Enabled = True
                txt2n.Enabled = False
                txt3n.Enabled = False
                txt2n.Text = 0
                txt3n.Text = 0
            End If
        Else
            txt1n.Enabled = False
            txt2n.Enabled = False
            txt3n.Enabled = False
            txt1n.Text = 0
            txt2n.Text = 0
            txt3n.Text = 0
        End If
    End Sub


    ' *** GUI Enhancements ***
    Private Sub txtEndNode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEndNode.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
    End Sub

    Private Sub txtFrequency_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFrequency.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtGmr_N_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGmr_N.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtGmr_P_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGmr_P.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtLength_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLength.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtResistance_N_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtResistance_N.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtResistance_P_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtResistance_P.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtSoilResistivity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSoilResistivity.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtStartNode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStartNode.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
    End Sub

    Private Sub txt12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt12.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txt13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt13.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txt1n_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt1n.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txt23_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt23.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txt2n_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt2n.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txt3n_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt3n.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Process.Start(Application.StartupPath & "\help\line.pdf")
    End Sub
End Class