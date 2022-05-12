Imports System.Numerics

Public Class frmAddShuntCapacitor

    Private capacitor As ShuntCapacitor

    Public Overloads Function ShowDialog(ByVal isEditor As Boolean, ByVal capacitor As ShuntCapacitor) As ShuntCapacitor
        Me.capacitor = capacitor
        setupForm()
        If isEditor Then
            txtTitle.Text = "Shunt Capacitor"
            txtDescription.Text = "Shunt Capacitor Model"
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
        Return capacitor
    End Function

    Public Overloads Shared Function Show(ByVal overloaded As Boolean, ByVal capacitor As ShuntCapacitor) As ShuntCapacitor
        Dim tmp As New frmAddShuntCapacitor
        Return tmp.ShowDialog(isEditor:=True, New ShuntCapacitor)
    End Function

    Private Function setupForm()
        txtNode.Text = capacitor.node
        txtTitle.Text = capacitor.title
        txtDescription.Text = capacitor.description
        txtPowerA_I.Text = capacitor.kvarA.Imaginary.ToString
        txtPowerA_R.Text = capacitor.kvarA.Real.ToString
        txtPowerB_I.Text = capacitor.kvarB.Imaginary.ToString
        txtPowerB_R.Text = capacitor.kvarB.Real.ToString
        txtPowerC_I.Text = capacitor.kvarC.Imaginary.ToString
        txtPowerC_R.Text = capacitor.kvarC.Real.ToString
        txtVoltageA_I.Text = capacitor.kvarA.Imaginary.ToString
        txtVoltageA_R.Text = capacitor.voltageA.Real.ToString
        txtVoltageB_I.Text = capacitor.voltageB.Imaginary.ToString
        txtVoltageB_R.Text = capacitor.voltageB.Real.ToString
        txtVoltageC_I.Text = capacitor.voltageC.Imaginary.ToString
        txtVoltageC_R.Text = capacitor.voltageC.Real.ToString
        cmbConnection.Text = capacitor.connection

        capacitor.isValid = False
    End Function

    Private Sub validate()
        If txtTitle.Text.Trim <> "" Then
            If txtDescription.Text.Trim <> "" Then
                If txtNode.Text.Trim <> "" Then
                    capacitor.isValid = True
                End If
            End If
        End If

        If txtNode.Text <> "NA" Then
            If txtNode.Text.Trim = 0 Then
                capacitor.isValid = False
                MsgBox("You cannot select 0 as Node ID. Please select number above 0.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If

            If cmbConnection.SelectedIndex < 0 Then
                capacitor.isValid = False
                MsgBox("Please select a connection type.", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
                Exit Sub
            End If
        End If

        If capacitor.isValid = False Then
            MsgBox("Please fill all the required parameters", MsgBoxStyle.Exclamation, "Distribution LoadFlow Analysis Software")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        validate()

        If capacitor.isValid Then
            addData()
            Me.Close()
        End If
    End Sub

    Private Sub btnLibrary_Click(sender As Object, e As EventArgs) Handles btnLibrary.Click
        Dim dbID = frmLoadBrowser.ShowDialog(True, "Capacitor Banks")
        If dbID > 0 Then
            Dim _capacitor = New ShuntCapacitor(dbID)
            capacitor.title = _capacitor.title
            capacitor.description = _capacitor.description
            capacitor.kvarA = _capacitor.kvarA
            capacitor.kvarB = _capacitor.kvarB
            capacitor.kvarC = _capacitor.kvarC
            capacitor.voltageA = _capacitor.voltageA
            capacitor.voltageB = _capacitor.voltageB
            capacitor.voltageC = _capacitor.voltageC
            setupForm()
        End If
    End Sub

    Private Sub btnAddToLibrary_Click(sender As Object, e As EventArgs) Handles btnAddToLibrary.Click
        validate()

        If capacitor.isValid Then
            Dim data = frmModelName.ShowDialog(True)
            If data(0) <> "" And data(1) <> "" Then
                capacitor.isValid = False
                addData()

                Dim _capacitor = capacitor
                _capacitor.title = data(0)
                _capacitor.description = data(1)
                _capacitor.addToDatabase()
                MsgBox("Model successfully saved to database", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            End If
        End If
    End Sub

    Private Sub addData()
        capacitor.title = txtTitle.Text
        capacitor.description = txtDescription.Text
        If txtNode.Text <> "NA" Then
            capacitor.node = txtNode.Text
        End If
        capacitor.kvarA = New Complex(txtPowerA_R.Text, txtPowerA_I.Text)
        capacitor.kvarB = New Complex(txtPowerB_R.Text, txtPowerB_I.Text)
        capacitor.kvarC = New Complex(txtPowerC_R.Text, txtPowerC_I.Text)
        capacitor.voltageA = New Complex(txtVoltageA_R.Text, txtVoltageA_I.Text)
        capacitor.voltageB = New Complex(txtVoltageB_R.Text, txtVoltageB_I.Text)
        capacitor.voltageC = New Complex(txtVoltageC_R.Text, txtVoltageC_I.Text)
        capacitor.connection = cmbConnection.Text
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Process.Start(Application.StartupPath & "\help\capacitor.pdf")
    End Sub
End Class