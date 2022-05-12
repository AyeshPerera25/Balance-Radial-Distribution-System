Imports System.Numerics

Public Class frmAddLoad

    Private load As Load

    ' *** Custom Dialog ***
    Public Overloads Function ShowDialog(ByVal isEditor As Boolean, ByVal load As Load) As Load
        Me.load = load
        setupForm()
        If isEditor Then
            txtTitle.Text = "Load"
            txtDescription.Text = "Composite Load Model"
            txtTitle.ReadOnly = True
            txtDescription.ReadOnly = True
            txtNode.Enabled = True
            cmbConnection.Text = ""
            cmbConnection.Enabled = True
            btnLibrary.Visible = True
            btnAddToLibrary.Visible = True
        Else
            txtNode.Text = "NA"
            txtNode.Enabled = False
            cmbConnection.Text = "NA"
            cmbConnection.Enabled = False
            btnLibrary.Visible = False
            btnAddToLibrary.Visible = False
            txtTitle.ReadOnly = False
            txtDescription.ReadOnly = False
        End If
        Me.ShowDialog()
        Return load
    End Function

    Public Overloads Shared Function Show(ByVal overloaded As Boolean, ByVal load As Load) As Load
        Dim tmp As New frmAddLoad
        Return tmp.ShowDialog(isEditor:=True, New Load)
    End Function

    Private Function setupForm()
        txtNode.Text = load.node
        txtTitle.Text = load.title
        txtDescription.Text = load.description
        txtPowerA_I.Text = load.powerA.Imaginary.ToString
        txtPowerA_R.Text = load.powerA.Real.ToString
        txtPowerB_I.Text = load.powerB.Imaginary.ToString
        txtPowerB_R.Text = load.powerB.Real.ToString
        txtPowerC_I.Text = load.powerC.Imaginary.ToString
        txtPowerC_R.Text = load.powerC.Real.ToString
        txtCP.Text = load.cpq
        txtCC.Text = load.cc
        txtCI.Text = load.ci
        cmbConnection.Text = load.connection

        load.isValid = False
    End Function

    Private Sub validate()
        If txtTitle.Text.Trim <> "" Then
            If txtDescription.Text.Trim <> "" Then
                If txtNode.Text.Trim <> "" Then
                    If txtCP.Text.Trim <> "" Then
                        If txtCC.Text.Trim <> "" Then
                            If txtCI.Text <> "" Then
                                load.isValid = True
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If txtNode.Text <> "NA" Then
            If txtNode.Text.Trim = 0 Then
                load.isValid = False
                MsgBox("You cannot select 0 as Node ID. Please select number above 0.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If

            If cmbConnection.SelectedIndex < 0 Then
                load.isValid = False
                MsgBox("Please select a connection type.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If load.isValid = False Then
            MsgBox("Please fill all the required parameters", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        validate()

        If load.isValid Then
            addData()
            Me.Close()
        End If
    End Sub

    Private Sub btnLibrary_Click(sender As Object, e As EventArgs) Handles btnLibrary.Click
        Dim dbID = frmLoadBrowser.ShowDialog(True, "Loads")
        If dbID > 0 Then
            Dim _load = New Load(dbID)
            load.title = _load.title
            load.description = _load.description
            load.powerA = _load.powerA
            load.powerB = _load.powerB
            load.powerC = _load.powerC
            load.cpq = _load.cpq
            load.cc = _load.cc
            load.ci = _load.ci
            setupForm()
        End If
    End Sub

    Private Sub btnAddToLibrary_Click(sender As Object, e As EventArgs) Handles btnAddToLibrary.Click
        validate()

        If load.isValid Then
            Dim data = frmModelName.ShowDialog(True)
            If data(0) <> "" And data(1) <> "" Then
                load.isValid = False
                addData()

                Dim _load = load
                _load.title = data(0)
                _load.description = data(1)
                _load.addToDatabase()
                MsgBox("Model successfully saved to database", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            End If
        End If
    End Sub

    Private Sub addData()
        load.title = txtTitle.Text
        load.description = txtDescription.Text
        If txtNode.Text <> "NA" Then
            load.node = txtNode.Text
        End If
        load.powerA = New Complex(txtPowerA_R.Text, txtPowerA_I.Text)
        load.powerB = New Complex(txtPowerB_R.Text, txtPowerB_I.Text)
        load.powerC = New Complex(txtPowerC_R.Text, txtPowerC_I.Text)
        load.cpq = txtCP.Text
        load.cc = txtCC.Text
        load.ci = txtCI.Text
        load.connection = cmbConnection.Text
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Process.Start(Application.StartupPath & "\help\load.pdf")
    End Sub
End Class