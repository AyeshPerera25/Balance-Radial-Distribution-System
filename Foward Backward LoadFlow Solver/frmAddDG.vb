Imports System.Numerics

Public Class frmAddDG
    Private generator As DG

    Public Overloads Function ShowDialog(ByVal isEditor As Boolean, ByVal generator As DG) As DG
        Me.generator = generator
        setupForm()
        If isEditor Then
            txtTitle.Text = "Distributed Generator"
            txtDescription.Text = "Distributed Generator Model"
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
        Return generator
    End Function

    Public Overloads Shared Function Show(ByVal overloaded As Boolean, ByVal generator As DG) As DG
        Dim tmp As New frmAddDG
        Return tmp.ShowDialog(isEditor:=True, New DG)
    End Function

    Private Function setupForm()
        txtNode.Text = generator.node
        txtTitle.Text = generator.title
        txtDescription.Text = generator.description
        txtPowerA_I.Text = generator.powerA.Imaginary.ToString
        txtPowerA_R.Text = generator.powerA.Real.ToString
        txtPowerB_I.Text = generator.powerB.Imaginary.ToString
        txtPowerB_R.Text = generator.powerB.Real.ToString
        txtPowerC_I.Text = generator.powerC.Imaginary.ToString
        txtPowerC_R.Text = generator.powerC.Real.ToString
        txtPfA.Text = generator.pfA
        txtPfB.Text = generator.pfB
        txtPfC.Text = generator.pfC
        cmbConnection.Text = generator.connection

        generator.isValid = False
    End Function

    Private Sub validate()
        If txtTitle.Text.Trim <> "" Then
            If txtDescription.Text.Trim <> "" Then
                If txtNode.Text.Trim <> "" Then
                    If txtPfA.Text.Trim <> "" Then
                        If txtPfB.Text.Trim <> "" Then
                            If txtPfC.Text <> "" Then
                                If txtPowerA_I.Text.Trim <> "" Then
                                    If txtPowerA_R.Text <> "" Then
                                        If txtPowerB_I.Text.Trim <> "" Then
                                            If txtPowerB_R.Text <> "" Then
                                                If txtPowerC_I.Text.Trim <> "" Then
                                                    If txtPowerC_R.Text <> "" Then
                                                    End If
                                                End If
                                                generator.isValid = True
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

        If txtNode.Text <> "NA" Then
            If txtNode.Text.Trim = 0 Then
                generator.isValid = False
                MsgBox("You cannot select 0 as Node ID. Please select number above 0.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If

            If cmbConnection.SelectedIndex < 0 Then
                generator.isValid = False
                MsgBox("Please select a connection type.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If generator.isValid = False Then
            MsgBox("Please fill all the required parameters", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
        End If
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        validate()

        If generator.isValid Then
            addData()

            Me.Close()
        End If
    End Sub

    Private Sub btnLibrary_Click(sender As Object, e As EventArgs) Handles btnLibrary.Click
        Dim dbID = frmLoadBrowser.ShowDialog(True, "Distributed Generators")
        If dbID > 0 Then
            Dim _generator = New DG(dbID)
            generator.title = _generator.title
            generator.description = _generator.description
            generator.powerA = _generator.powerA
            generator.powerB = _generator.powerB
            generator.powerC = _generator.powerC
            generator.pfA = _generator.pfA
            generator.pfB = _generator.pfB
            generator.pfC = _generator.pfC
            setupForm()
        End If
    End Sub

    Private Sub btnAddToLibrary_Click(sender As Object, e As EventArgs) Handles btnAddToLibrary.Click
        validate()

        If generator.isValid Then
            Dim data = frmModelName.ShowDialog(True)
            If data(0) <> "" And data(1) <> "" Then
                generator.isValid = False
                addData()

                Dim _generator = generator
                _generator.title = data(0)
                _generator.description = data(1)
                _generator.addToDatabase()
                MsgBox("Model successfully saved to database", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            End If
        End If
    End Sub

    Private Sub addData()
        generator.title = txtTitle.Text
        generator.description = txtDescription.Text
        If txtNode.Text <> "NA" Then
            generator.node = txtNode.Text
        End If
        generator.powerA = New Complex(txtPowerA_R.Text, txtPowerA_I.Text)
        generator.powerB = New Complex(txtPowerB_R.Text, txtPowerB_I.Text)
        generator.powerC = New Complex(txtPowerC_R.Text, txtPowerC_I.Text)
        generator.pfA = txtPfA.Text
        generator.pfB = txtPfB.Text
        generator.pfC = txtPfC.Text
        generator.connection = cmbConnection.Text
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Process.Start(Application.StartupPath & "\help\dg.pdf")
    End Sub
End Class