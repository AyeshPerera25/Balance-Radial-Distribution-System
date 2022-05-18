Imports System.IO
Imports OfficeOpenXml
Imports System.Numerics
Imports Microsoft.Glee

Public Class frmFaultCal

    Public Property passNodeData As ListView
    Public Property passTransData As ListView
    Public Property passDGData As ListView
    Public Property passLoadData As ListView

    Public Property passLineSequ As FileInfo

    Public Property passCalValue() As String
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub createFaultGraph()
        Dim graph = New Microsoft.Glee.Drawing.Graph("Network")
        Dim node_1
        Dim node_2
        Dim loadName As String

        For n As Integer = 0 To passNodeData.Items.Count - 1

            graph.AddEdge(passNodeData.Items(n).SubItems(1).Text, passNodeData.Items(n).SubItems(2).Text)
            node_1 = graph.FindNode(passNodeData.Items(n).SubItems(1).Text)
            node_2 = graph.FindNode(passNodeData.Items(n).SubItems(2).Text)

            Try

                If txtFaultBus.Text = "" Then
                    node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Aqua
                    node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle
                    node_2.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Aqua
                    node_2.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle
                Else
                    If Convert.ToInt32(passNodeData.Items(n).SubItems(1).Text) = Convert.ToInt32(txtFaultBus.Text) Then

                        node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.OrangeRed
                        node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.DoubleCircle
                        node_2.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Aqua
                        node_2.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle

                    ElseIf Convert.ToInt32(passNodeData.Items(n).SubItems(2).Text) = Convert.ToInt32(txtFaultBus.Text) Then
                        node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Aqua
                        node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle
                        node_2.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.OrangeRed
                        node_2.Attr.Shape = Microsoft.Glee.Drawing.Shape.DoubleCircle

                    Else
                        node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Aqua
                        node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle
                        node_2.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Aqua
                        node_2.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle

                    End If

                End If


            Catch ex As Exception

                MsgBox("Enter Numbers Only for Fault Bus")
                txtFaultBus.Text = ""

            End Try

        Next

        For n As Integer = 0 To passLoadData.Items.Count - 1

            If passLoadData.Items(n).SubItems(3).Text = "Load" Then
                loadName = "Load #" + passLoadData.Items(n).SubItems(0).Text
            ElseIf passLoadData.Items(n).SubItems(3).Text = "Shunt Capacitor" Then
                loadName = "SC #" + passLoadData.Items(n).SubItems(0).Text
            Else
                loadName = "DG #" + passLoadData.Items(n).SubItems(0).Text
            End If

            graph.AddEdge(passLoadData.Items(n).SubItems(1).Text, loadName)
            node_1 = graph.FindNode(loadName)

            If passLoadData.Items(n).SubItems(3).Text = "Load" Then
                node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Green
                node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Box
            ElseIf passLoadData.Items(n).SubItems(3).Text = "Shunt Capacitor" Then
                node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Blue
                node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Triangle
            Else
                node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red
                node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Octagon
            End If
        Next

        faultViwer.Graph = graph
        Me.SuspendLayout()
        faultViwer.Dock = System.Windows.Forms.DockStyle.Fill
        panFaultViewer.Controls.Add(faultViwer)
        Me.ResumeLayout()


    End Sub

    Private Sub calculateFaultNetwork()
        My.Computer.FileSystem.CopyFile("data2.xlsx", "script/dat2.xlsx", True)
        lstFaultLog.Items.Add("Excel File created in " + "script/dat2.xlsx")
        Dim fileInfo = New FileInfo("script/dat2.xlsx")
        Using package = New ExcelPackage(fileInfo)

            package.LicenseContext = LicenseContext.NonCommercial

            ' Export LineImpedance
            Dim lineImpSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(0)
            For n As Integer = 0 To listFaultImp.Items.Count - 1

                lineImpSheet.Cells(n + 2, 1).Value = listFaultImp.Items(n).SubItems(0).Text
                lineImpSheet.Cells(n + 2, 2).Value = listFaultImp.Items(n).SubItems(1).Text
                lineImpSheet.Cells(n + 2, 3).Value = listFaultImp.Items(n).SubItems(2).Text
                lineImpSheet.Cells(n + 2, 4).Value = listFaultImp.Items(n).SubItems(3).Text
                lineImpSheet.Cells(n + 2, 5).Value = listFaultImp.Items(n).SubItems(4).Text
                lineImpSheet.Cells(n + 2, 6).Value = listFaultImp.Items(n).SubItems(5).Text
                lineImpSheet.Cells(n + 2, 7).Value = listFaultImp.Items(n).SubItems(6).Text
                lineImpSheet.Cells(n + 2, 8).Value = listFaultImp.Items(n).SubItems(7).Text
                lineImpSheet.Cells(n + 2, 9).Value = listFaultImp.Items(n).SubItems(8).Text

            Next
            ' Export TransformerImpedance
            Dim TFImpSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(1)
            For n As Integer = 0 To listTransformer.Items.Count - 1

                TFImpSheet.Cells(n + 2, 1).Value = listTransformer.Items(n).SubItems(0).Text
                TFImpSheet.Cells(n + 2, 2).Value = listTransformer.Items(n).SubItems(1).Text
                TFImpSheet.Cells(n + 2, 3).Value = listTransformer.Items(n).SubItems(2).Text
                TFImpSheet.Cells(n + 2, 4).Value = listTransformer.Items(n).SubItems(3).Text
                TFImpSheet.Cells(n + 2, 5).Value = listTransformer.Items(n).SubItems(4).Text
                TFImpSheet.Cells(n + 2, 6).Value = listTransformer.Items(n).SubItems(5).Text
                TFImpSheet.Cells(n + 2, 7).Value = listTransformer.Items(n).SubItems(6).Text
                TFImpSheet.Cells(n + 2, 8).Value = listTransformer.Items(n).SubItems(7).Text
                TFImpSheet.Cells(n + 2, 9).Value = listTransformer.Items(n).SubItems(8).Text
                TFImpSheet.Cells(n + 2, 10).Value = listTransformer.Items(n).SubItems(9).Text
                TFImpSheet.Cells(n + 2, 11).Value = listTransformer.Items(n).SubItems(10).Text
                TFImpSheet.Cells(n + 2, 12).Value = listTransformer.Items(n).SubItems(11).Text

            Next

            ' Export LoadImpedance

            Dim LoadImpSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(2)
            For n As Integer = 0 To listLoad.Items.Count - 1

                LoadImpSheet.Cells(n + 2, 1).Value = listLoad.Items(n).SubItems(0).Text
                LoadImpSheet.Cells(n + 2, 2).Value = listLoad.Items(n).SubItems(1).Text
                LoadImpSheet.Cells(n + 2, 3).Value = listLoad.Items(n).SubItems(2).Text
                LoadImpSheet.Cells(n + 2, 4).Value = listLoad.Items(n).SubItems(3).Text
                LoadImpSheet.Cells(n + 2, 5).Value = listLoad.Items(n).SubItems(4).Text
                LoadImpSheet.Cells(n + 2, 6).Value = listLoad.Items(n).SubItems(5).Text
                LoadImpSheet.Cells(n + 2, 7).Value = listLoad.Items(n).SubItems(6).Text
                LoadImpSheet.Cells(n + 2, 8).Value = listLoad.Items(n).SubItems(7).Text
                LoadImpSheet.Cells(n + 2, 9).Value = listLoad.Items(n).SubItems(8).Text
                LoadImpSheet.Cells(n + 2, 10).Value = listLoad.Items(n).SubItems(9).Text
                LoadImpSheet.Cells(n + 2, 11).Value = listLoad.Items(n).SubItems(10).Text
                LoadImpSheet.Cells(n + 2, 12).Value = listLoad.Items(n).SubItems(11).Text

            Next



            package.Save()
            lstFaultLog.Items.Add("Data Saved to Excel File in " + "script/dat2.xlsx")

        End Using


    End Sub

    Private Sub listFaultImp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listFaultImp.SelectedIndexChanged
        If listFaultImp.SelectedItems.Count > 0 Then
            txtStart.Text = listFaultImp.SelectedItems(0).SubItems(1).Text
            txtEnd.Text = listFaultImp.SelectedItems(0).SubItems(2).Text
            txtPosRe.Text = listFaultImp.SelectedItems(0).SubItems(3).Text
            txtPosIm.Text = listFaultImp.SelectedItems(0).SubItems(4).Text
            txtNegRe.Text = listFaultImp.SelectedItems(0).SubItems(5).Text
            txtNegIm.Text = listFaultImp.SelectedItems(0).SubItems(6).Text
            txtZerRe.Text = listFaultImp.SelectedItems(0).SubItems(7).Text
            txtZerIm.Text = listFaultImp.SelectedItems(0).SubItems(8).Text



        End If
    End Sub

    Private Sub frmFaultCal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim linecount As Integer = 0
        Using package = New ExcelPackage(passLineSequ)

            package.LicenseContext = LicenseContext.NonCommercial

            Dim lineSequImp As ExcelWorksheet = package.Workbook.Worksheets.Item(5)

            For n As Integer = 0 To passNodeData.Items.Count - 1

                If passNodeData.Items(n).SubItems(3).Text = "Line Overhead" Or passNodeData.Items(n).SubItems(3).Text = "Line Underground" Then
                    listFaultImp.Items.Add(passNodeData.Items(n).Text, n)
                    listFaultImp.Items(linecount).SubItems.Add(lineSequImp.Cells(linecount + 2, 1).Value)
                    listFaultImp.Items(linecount).SubItems.Add(lineSequImp.Cells(linecount + 2, 2).Value)
                    listFaultImp.Items(linecount).SubItems.Add(lineSequImp.Cells(linecount + 2, 3).Value)
                    listFaultImp.Items(linecount).SubItems.Add(lineSequImp.Cells(linecount + 2, 4).Value)
                    listFaultImp.Items(linecount).SubItems.Add(lineSequImp.Cells(linecount + 2, 3).Value)
                    listFaultImp.Items(linecount).SubItems.Add(lineSequImp.Cells(linecount + 2, 4).Value)
                    listFaultImp.Items(linecount).SubItems.Add(lineSequImp.Cells(linecount + 2, 5).Value)
                    listFaultImp.Items(linecount).SubItems.Add(lineSequImp.Cells(linecount + 2, 6).Value)
                    linecount += 1


                ElseIf passNodeData.Items(n).SubItems(3).Text = "Trasformer DY" Or passNodeData.Items(n).SubItems(3).Text = "Trasformer YD" Then
                    listTransformer.Items.Add(Convert.ToString(n - linecount + 1), n - linecount)
                    listTransformer.Items(n - linecount).SubItems.Add(passNodeData.Items(n).SubItems(1).Text)
                    listTransformer.Items(n - linecount).SubItems.Add(passNodeData.Items(n).SubItems(2).Text)
                    listTransformer.Items(n - linecount).SubItems.Add(" ")
                    listTransformer.Items(n - linecount).SubItems.Add(" ")
                    listTransformer.Items(n - linecount).SubItems.Add(" ")
                    listTransformer.Items(n - linecount).SubItems.Add(" ")
                    listTransformer.Items(n - linecount).SubItems.Add(" ")
                    listTransformer.Items(n - linecount).SubItems.Add(" ")
                    listTransformer.Items(n - linecount).SubItems.Add(" ")
                    listTransformer.Items(n - linecount).SubItems.Add(" ")
                    listTransformer.Items(n - linecount).SubItems.Add(" ")


                End If


            Next

            Dim loadCount As Integer = 0

            For n As Integer = 0 To passLoadData.Items.Count - 1

                If passLoadData.Items(n).SubItems(3).Text = "Load" Or passLoadData.Items(n).SubItems(3).Text = "Shunt Capacitor" Then
                    listLoad.Items.Add(passLoadData.Items(n).Text, n)
                    listLoad.Items(loadCount).SubItems.Add(passLoadData.Items(n).SubItems(1).Text)
                    listLoad.Items(loadCount).SubItems.Add(" ")
                    listLoad.Items(loadCount).SubItems.Add(" ")
                    listLoad.Items(loadCount).SubItems.Add(" ")
                    listLoad.Items(loadCount).SubItems.Add(" ")
                    listLoad.Items(loadCount).SubItems.Add(" ")
                    listLoad.Items(loadCount).SubItems.Add(" ")
                    listLoad.Items(loadCount).SubItems.Add(" ")
                    listLoad.Items(loadCount).SubItems.Add(" ")

                    If passLoadData.Items(n).SubItems(2).Text = "Star" Then

                        listLoad.Items(loadCount).SubItems.Add("Star")

                    ElseIf passLoadData.Items(n).SubItems(2).Text = "Delta" Then

                        listLoad.Items(loadCount).SubItems.Add("Delta")


                    End If

                    listLoad.Items(loadCount).SubItems.Add(" ")

                    loadCount += 1
                Else
                    listDG.Items.Add(Convert.ToString(n - linecount + 1), n - loadCount)
                    listDG.Items(n - loadCount).SubItems.Add(passLoadData.Items(n).SubItems(1).Text)
                    listDG.Items(n - loadCount).SubItems.Add(" ")
                    listDG.Items(n - loadCount).SubItems.Add(" ")
                    listDG.Items(n - loadCount).SubItems.Add(" ")
                    listDG.Items(n - loadCount).SubItems.Add(" ")
                    listDG.Items(n - loadCount).SubItems.Add(" ")
                    listDG.Items(n - loadCount).SubItems.Add(" ")
                    listDG.Items(n - loadCount).SubItems.Add(" ")
                    listDG.Items(n - loadCount).SubItems.Add(" ")
                    listDG.Items(n - loadCount).SubItems.Add("DG")


                End If

            Next


            createFaultGraph()




        End Using

    End Sub

    Private Sub btnEdite_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            listFaultImp.SelectedItems(0).SubItems(3).Text = Convert.ToDecimal(txtPosRe.Text)
            listFaultImp.SelectedItems(0).SubItems(4).Text = Convert.ToDecimal(txtPosIm.Text)
            listFaultImp.SelectedItems(0).SubItems(5).Text = Convert.ToDecimal(txtNegRe.Text)
            listFaultImp.SelectedItems(0).SubItems(6).Text = Convert.ToDecimal(txtNegIm.Text)
            listFaultImp.SelectedItems(0).SubItems(7).Text = Convert.ToDecimal(txtZerRe.Text)
            listFaultImp.SelectedItems(0).SubItems(8).Text = Convert.ToDecimal(txtZerIm.Text)
        Catch ex As Exception
            MsgBox("Enter Numbers Only")

        End Try





    End Sub



    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)


    End Sub





    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        calculateFaultNetwork()

    End Sub

    Private Sub listTransformer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listTransformer.SelectedIndexChanged
        If listTransformer.SelectedItems.Count > 0 Then

            txtTFStart.Text = listTransformer.SelectedItems(0).SubItems(1).Text
            txtTFEnd.Text = listTransformer.SelectedItems(0).SubItems(2).Text

            If listTransformer.SelectedItems(0).SubItems(11).Text = "YnD" Then

                rabYnD.Checked = True
                rabYnYn.Checked = False

            ElseIf listTransformer.SelectedItems(0).SubItems(11).Text = "YnYn" Then

                rabYnD.Checked = False
                rabYnYn.Checked = True

            Else
                rabYnD.Checked = False
                rabYnYn.Checked = False

            End If
            txtTFPosRE.Text = listTransformer.SelectedItems(0).SubItems(3).Text
            txtTFPosIM.Text = listTransformer.SelectedItems(0).SubItems(4).Text
            txtTFNegRE.Text = listTransformer.SelectedItems(0).SubItems(5).Text
            txtTFNegIM.Text = listTransformer.SelectedItems(0).SubItems(6).Text
            txtTFZeroRE.Text = listTransformer.SelectedItems(0).SubItems(7).Text
            txtTFZeroIM.Text = listTransformer.SelectedItems(0).SubItems(8).Text
            txtTFGndRE.Text = listTransformer.SelectedItems(0).SubItems(9).Text
            txtTFGndIM.Text = listTransformer.SelectedItems(0).SubItems(10).Text


        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            listTransformer.SelectedItems(0).SubItems(3).Text = Convert.ToDecimal(txtTFPosRE.Text)
            listTransformer.SelectedItems(0).SubItems(4).Text = Convert.ToDecimal(txtTFPosIM.Text)
            listTransformer.SelectedItems(0).SubItems(5).Text = Convert.ToDecimal(txtTFNegRE.Text)
            listTransformer.SelectedItems(0).SubItems(6).Text = Convert.ToDecimal(txtTFNegIM.Text)
            listTransformer.SelectedItems(0).SubItems(7).Text = Convert.ToDecimal(txtTFZeroRE.Text)
            listTransformer.SelectedItems(0).SubItems(8).Text = Convert.ToDecimal(txtTFZeroIM.Text)
            listTransformer.SelectedItems(0).SubItems(9).Text = Convert.ToDecimal(txtTFGndRE.Text)
            listTransformer.SelectedItems(0).SubItems(10).Text = Convert.ToDecimal(txtTFGndIM.Text)

            If rabYnD.Checked = True And rabYnYn.Checked = False Then
                listTransformer.SelectedItems(0).SubItems(11).Text = "YnD"

            ElseIf rabYnD.Checked = False And rabYnYn.Checked = True Then

                listTransformer.SelectedItems(0).SubItems(11).Text = "YnYn"

            Else
                MsgBox("Enter Transformer Type or It get setted to YnD")
                listTransformer.SelectedItems(0).SubItems(11).Text = "YnD"

            End If

        Catch ex As Exception
            MsgBox("Enter Numbers Only")

        End Try
    End Sub

    Private Sub radLodYn_CheckedChanged(sender As Object, e As EventArgs) Handles radLodYn.CheckedChanged
        If radLodYn.Checked Then

            radLodDe.Checked = False
            radLoadY.Checked = False
            txtLodGndImpRe.Enabled = True
            txtLodGndImpIm.Enabled = True

        End If
    End Sub

    Private Sub radLodDe_CheckedChanged(sender As Object, e As EventArgs) Handles radLodDe.CheckedChanged
        If radLodDe.Checked Then

            radLodYn.Checked = False
            radLoadY.Checked = False
            txtLodGndImpRe.Enabled = False
            txtLodGndImpIm.Enabled = False

        End If
    End Sub

    Private Sub radLodMotorLd_CheckedChanged(sender As Object, e As EventArgs) Handles radLodMotorLd.CheckedChanged
        If radLodMotorLd.Checked Then
            radLodRICLd.Checked = False
        End If
    End Sub

    Private Sub radLodRICLd_CheckedChanged(sender As Object, e As EventArgs) Handles radLodRICLd.CheckedChanged
        If radLodRICLd.Checked Then
            radLodMotorLd.Checked = False
        End If
    End Sub

    Private Sub radLoadY_CheckedChanged(sender As Object, e As EventArgs) Handles radLoadY.CheckedChanged
        If radLoadY.Checked Then

            radLodYn.Checked = False
            radLodDe.Checked = False
            txtLodGndImpRe.Enabled = False
            txtLodGndImpIm.Enabled = False

        End If
    End Sub

    Private Sub txtFaultBus_TextChanged(sender As Object, e As EventArgs) Handles txtFaultBus.TextChanged
        createFaultGraph()

    End Sub

    Private Sub listLoad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listLoad.SelectedIndexChanged
        If listLoad.SelectedItems.Count > 0 Then

            txtLodConectNod.Text = listLoad.SelectedItems(0).SubItems(1).Text


            If listLoad.SelectedItems(0).SubItems(11).Text = "Motor" Then

                radLodMotorLd.Checked = True
                radLodRICLd.Checked = False

            ElseIf listLoad.SelectedItems(0).SubItems(11).Text = "RIC" Then

                radLodMotorLd.Checked = False
                radLodRICLd.Checked = True

            Else
                radLodMotorLd.Checked = False
                radLodRICLd.Checked = False

            End If


            If listLoad.SelectedItems(0).SubItems(10).Text = "Star" Then

                radLoadY.Checked = True
                radLodDe.Checked = False
                radLodYn.Checked = False

            ElseIf listLoad.SelectedItems(0).SubItems(10).Text = "Delta" Then

                radLoadY.Checked = False
                radLodDe.Checked = True
                radLodYn.Checked = False

            ElseIf listLoad.SelectedItems(0).SubItems(10).Text = "Star+N" Then
                radLoadY.Checked = False
                radLodDe.Checked = False
                radLodYn.Checked = True

            Else
                radLoadY.Checked = False
                radLodDe.Checked = False
                radLodYn.Checked = False

            End If

            txtLodPosImpRe.Text = listLoad.SelectedItems(0).SubItems(2).Text
            txtLodPosImpIm.Text = listLoad.SelectedItems(0).SubItems(3).Text
            txtLodNegImpRe.Text = listLoad.SelectedItems(0).SubItems(4).Text
            txtLodNegImpIm.Text = listLoad.SelectedItems(0).SubItems(5).Text
            txtLodZeroImpRe.Text = listLoad.SelectedItems(0).SubItems(6).Text
            txtLodZeroImpIm.Text = listLoad.SelectedItems(0).SubItems(7).Text
            txtLodGndImpRe.Text = listLoad.SelectedItems(0).SubItems(8).Text
            txtLodGndImpIm.Text = listLoad.SelectedItems(0).SubItems(9).Text




        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            listLoad.SelectedItems(0).SubItems(2).Text = Convert.ToDecimal(txtLodPosImpRe.Text)
            listLoad.SelectedItems(0).SubItems(3).Text = Convert.ToDecimal(txtLodPosImpIm.Text)
            listLoad.SelectedItems(0).SubItems(4).Text = Convert.ToDecimal(txtLodNegImpRe.Text)
            listLoad.SelectedItems(0).SubItems(5).Text = Convert.ToDecimal(txtLodNegImpIm.Text)
            listLoad.SelectedItems(0).SubItems(6).Text = Convert.ToDecimal(txtLodZeroImpRe.Text)
            listLoad.SelectedItems(0).SubItems(7).Text = Convert.ToDecimal(txtLodZeroImpIm.Text)

            If txtLodGndImpRe.Enabled Then

                listLoad.SelectedItems(0).SubItems(8).Text = Convert.ToDecimal(txtLodGndImpRe.Text)

            Else
                listLoad.SelectedItems(0).SubItems(8).Text = txtLodGndImpRe.Text

            End If

            If txtLodGndImpIm.Enabled Then

                listLoad.SelectedItems(0).SubItems(9).Text = Convert.ToDecimal(txtLodGndImpIm.Text)

            Else
                listLoad.SelectedItems(0).SubItems(9).Text = txtLodGndImpIm.Text


            End If

            If radLoadY.Checked Then

                listLoad.SelectedItems(0).SubItems(10).Text = "Star"

            ElseIf radLodYn.Checked Then

                listLoad.SelectedItems(0).SubItems(10).Text = "Star+N"

            ElseIf radLodDe.Checked Then
                listLoad.SelectedItems(0).SubItems(10).Text = "Delta"

            End If

            If radLodMotorLd.Checked Then
                listLoad.SelectedItems(0).SubItems(11).Text = "Motor"

            ElseIf radLodRICLd.Checked Then
                listLoad.SelectedItems(0).SubItems(11).Text = "RIC"

            End If

        Catch ex As Exception
            MsgBox("Enter Numbers Only")

        End Try
    End Sub

    Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs) Handles txtDGGndSqIm.TextChanged

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox11_Enter(sender As Object, e As EventArgs) Handles GroupBox11.Enter

    End Sub

    Private Sub radbDG_CheckedChanged(sender As Object, e As EventArgs) Handles radbDG.CheckedChanged
        If radbDG.Checked Then
            radbTurnIIDG.Checked = False
            txtDGPosSqRe.Enabled = True
            txtDGPosSqIm.Enabled = True
            txtDGNegSqRe.Enabled = True
            txtDGNegSqIm.Enabled = True
            txtDGZeroSqRe.Enabled = True
            txtDGZeroSqIm.Enabled = True
            txtDGGndSqRe.Enabled = True
            txtDGGndSqIm.Enabled = True
        End If
    End Sub

    Private Sub radbTurnIIDG_CheckedChanged(sender As Object, e As EventArgs) Handles radbTurnIIDG.CheckedChanged
        If radbTurnIIDG.Checked Then
            radbDG.Checked = False
            txtDGPosSqRe.Enabled = False
            txtDGPosSqIm.Enabled = False
            txtDGNegSqRe.Enabled = False
            txtDGNegSqIm.Enabled = False
            txtDGZeroSqRe.Enabled = False
            txtDGZeroSqIm.Enabled = False
            txtDGGndSqRe.Enabled = False
            txtDGGndSqIm.Enabled = False
        End If

    End Sub
End Class