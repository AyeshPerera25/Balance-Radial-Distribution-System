Public Class frmAddTransformer

    Private transformer As Transformer

    ' *** Custom Dialog ***
    Public Overloads Function ShowDialog(ByVal isEditor As Boolean, ByVal transformer As Transformer) As Transformer
        Me.transformer = transformer
        setupForm()
        If isEditor Then
            txtTitle.Text = "Transformer"
            txtDescription.Text = "Model Transformer"
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
        Return transformer
    End Function

    Public Overloads Shared Function Show(ByVal overloaded As Boolean, ByVal transformer As Transformer) As Transformer
        Dim tmp As New frmAddTransformer
        Return tmp.ShowDialog(isEditor:=True, New Transformer)
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        validate()

        If transformer.isValid Then
            transformer.title = txtTitle.Text
            transformer.description = txtDescription.Text
            If txtStartNode.Text <> "NA" Then
                transformer.startNode = txtStartNode.Text
                transformer.endNode = txtEndNode.Text
            End If
            transformer.power = txtPower.Text
            transformer.primaryVoltage = txtPrimaryVoltage.Text
            transformer.secondaryVoltage = txtSecondaryVoltage.Text
            transformer.percentageImpedance = txtPercentageImpedance.Text
            transformer.phaseAngle = txtPhaseAngle.Text
            transformer.type = cmbType.Text
            transformer.xrRatio = txtXRRatio.Text
            Me.Close()
        End If

    End Sub

    Private Function setupForm()
        txtTitle.Text = transformer.title
        txtDescription.Text = transformer.description
        txtStartNode.Text = transformer.startNode
        txtEndNode.Text = transformer.endNode
        txtPower.Text = transformer.power
        txtPrimaryVoltage.Text = transformer.primaryVoltage
        txtSecondaryVoltage.Text = transformer.secondaryVoltage
        txtPercentageImpedance.Text = transformer.percentageImpedance
        txtPhaseAngle.Text = transformer.phaseAngle
        txtXRRatio.Text = transformer.xrRatio
        cmbType.Text = transformer.type
        transformer.isValid = False
    End Function

    Private Sub validate()
        If txtTitle.Text <> "" Then
            If txtDescription.Text.Trim <> "" Then
                If txtStartNode.Text.Trim <> "" Then
                    If txtEndNode.Text.Trim <> "" Then
                        If txtPower.Text <> "" Then
                            If txtPrimaryVoltage.Text.Trim <> "" Then
                                If txtSecondaryVoltage.Text.Trim <> "" Then
                                    If txtPercentageImpedance.Text.Trim <> "" Then
                                        If txtPhaseAngle.Text.Trim <> "" Then
                                            If txtXRRatio.Text.Trim <> "" Then
                                                If cmbType.SelectedIndex >= 0 Then
                                                    transformer.isValid = True
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
                transformer.isValid = False
                MsgBox("You cannot select 0 as Node ID. Please select number above 0.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If txtEndNode.Text <> "NA" Then
            If txtEndNode.Text.Trim = 0 Then
                transformer.isValid = False
                MsgBox("You cannot select 0 as Node ID. Please select number above 0.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If txtStartNode.Text <> "NA" And txtEndNode.Text <> "NA" Then
            If txtStartNode.Text.Trim = txtEndNode.Text.Trim Then
                transformer.isValid = False
                MsgBox("Start node and end note cannot be same.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If transformer.isValid = False Then
            MsgBox("Please fill all the required parameters", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
        End If
    End Sub

    Private Sub btnLibrary_Click(sender As Object, e As EventArgs) Handles btnLibrary.Click
        Dim dbID = frmLoadBrowser.ShowDialog(True, "Transformers")
        If dbID > 0 Then
            Dim _transformer = New Transformer(dbID)
            transformer.title = _transformer.title
            transformer.description = _transformer.description
            transformer.power = _transformer.power
            transformer.primaryVoltage = _transformer.primaryVoltage
            transformer.secondaryVoltage = _transformer.secondaryVoltage
            transformer.percentageImpedance = _transformer.percentageImpedance
            transformer.phaseAngle = _transformer.phaseAngle
            transformer.type = _transformer.type
            transformer.xrRatio = _transformer.xrRatio
            setupForm()
        End If
    End Sub

    Private Sub btnAddToLibrary_Click(sender As Object, e As EventArgs) Handles btnAddToLibrary.Click
        Dim data = frmModelName.ShowDialog(True)
        If data(0) <> "" And data(1) <> "" Then
            Dim _transformer = transformer
            _transformer.title = data(0)
            _transformer.description = data(1)
            _transformer.addToDatabase()
            MsgBox("Model successfully saved to database", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Process.Start(Application.StartupPath & "\help\transformer.pdf")
    End Sub
End Class