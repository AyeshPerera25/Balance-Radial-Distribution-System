Imports System.IO
Imports OfficeOpenXml
Imports System.Numerics
Imports Microsoft.Glee

Public Class frmMain

    Public dataLog As String

    Private Sub btnAddTransformer_Click(sender As Object, e As EventArgs) Handles btnAddTransformer.Click
        Dim transformer = frmAddTransformer.ShowDialog(isEditor:=True, New Transformer)
        btnFaultAnalys.Enabled = False

        If transformer.isValid Then

            Project.edgeCount = Project.edgeCount + 1

            Dim data(4) As String
            data(0) = Project.edgeCount
            data(1) = transformer.startNode
            data(2) = transformer.endNode
            data(3) = "Transformer " + transformer.type

            Dim item As ListViewItem
            item = New ListViewItem(data)
            listEdges.Items.Add(item)

            Project.edges.Add(Project.edgeCount, transformer)

            createGraph()
        End If

    End Sub

    Private Sub btnAddLine_Click(sender As Object, e As EventArgs) Handles btnAddLine.Click
        Dim line = frmAddLine.ShowDialog(True, New Line)
        btnFaultAnalys.Enabled = False
        If line.isValid Then

            Project.edgeCount = Project.edgeCount + 1

            Dim data(4) As String
            data(0) = Project.edgeCount
            data(1) = line.startNode
            data(2) = line.endNode
            data(3) = "Line " + line.type

            Dim item As ListViewItem
            item = New ListViewItem(data)
            listEdges.Items.Add(item)

            Project.edges.Add(Project.edgeCount, line)

            createGraph()
        End If
    End Sub

    Private Sub btnDeleteEdge_Click(sender As Object, e As EventArgs) Handles btnDeleteEdge.Click
        btnFaultAnalys.Enabled = False
        If listEdges.SelectedItems.Count > 0 Then
            Dim edgeId = Integer.Parse(listEdges.FocusedItem.SubItems(0).Text)
            Project.edges.Remove(edgeId)
            listEdges.Items.Remove(listEdges.FocusedItem)

            createGraph()
        End If
    End Sub

    Private Sub btnAddLoad_Click(sender As Object, e As EventArgs) Handles btnAddLoad.Click
        btnFaultAnalys.Enabled = False
        Dim load = frmAddLoad.ShowDialog(isEditor:=True, New Load)

        If load.isValid Then

            Project.nodeLoadCount = Project.nodeLoadCount + 1

            Dim data(4) As String
            data(0) = Project.nodeLoadCount
            data(1) = load.node
            data(2) = load.connection
            data(3) = "Load"

            Dim item As ListViewItem
            item = New ListViewItem(data)
            listLoads.Items.Add(item)

            Project.loads.Add(Project.nodeLoadCount, load)

            createGraph()
        End If
    End Sub

    Private Sub btnAddCapacitor_Click(sender As Object, e As EventArgs) Handles btnAddCapacitor.Click
        btnFaultAnalys.Enabled = False
        Dim capacitor = frmAddShuntCapacitor.ShowDialog(isEditor:=True, New ShuntCapacitor)

        If capacitor.isValid Then

            Project.nodeLoadCount = Project.nodeLoadCount + 1

            Dim data(4) As String
            data(0) = Project.nodeLoadCount
            data(1) = capacitor.node
            data(2) = capacitor.connection
            data(3) = "Shunt Capacitor"

            Dim item As ListViewItem
            item = New ListViewItem(data)
            listLoads.Items.Add(item)

            Project.loads.Add(Project.nodeLoadCount, capacitor)

            createGraph()
        End If
    End Sub

    Private Sub btnAddDg_Click(sender As Object, e As EventArgs) Handles btnAddDg.Click
        Dim generator = frmAddDG.ShowDialog(isEditor:=True, New DG)
        btnFaultAnalys.Enabled = False
        If generator.isValid Then

            Project.nodeLoadCount = Project.nodeLoadCount + 1

            Dim data(4) As String
            data(0) = Project.nodeLoadCount
            data(1) = generator.node
            data(2) = generator.connection
            data(3) = "Distributed Generator"

            Dim item As ListViewItem
            item = New ListViewItem(data)
            listLoads.Items.Add(item)

            Project.loads.Add(Project.nodeLoadCount, generator)

            createGraph()
        End If
    End Sub

    Private Sub btnDeleteLoad_Click(sender As Object, e As EventArgs) Handles btnDeleteLoad.Click
        btnFaultAnalys.Enabled = False
        If listLoads.SelectedItems.Count > 0 Then
            Dim loadId = Integer.Parse(listLoads.FocusedItem.SubItems(0).Text)
            Project.loads.Remove(loadId)
            listLoads.Items.Remove(listLoads.FocusedItem)

            createGraph()
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ofdProject.Title = "Open Project"

        If ofdProject.ShowDialog() = DialogResult.OK Then

            Dim path As String = ofdProject.FileName

            If path <> "" Then

                ' Save if opened
                If Project.edges.Count > 0 Or Project.loads.Count > 0 Or Project.filePath <> "" Then
                    Dim result As DialogResult = MessageBox.Show("Do you want to save the current project?", "Save Project", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If result = DialogResult.Cancel Then
                        Exit Sub
                    ElseIf result = DialogResult.No Then
                        ' Do Nothing
                    ElseIf result = DialogResult.Yes Then
                        If validateData() Then
                            If Project.filePath Is Nothing Then
                                If sfdProject.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    Project.filePath = sfdProject.FileName
                                    My.Computer.FileSystem.CopyFile("data.xlsx", Project.filePath)
                                    Me.Text = "Distribution LoadFlow Analysis Software (" + Project.filePath + ")"
                                    saveFile()
                                Else
                                    Exit Sub
                                End If
                            Else
                                saveFile()
                            End If
                        Else
                            Exit Sub
                        End If
                    End If
                End If

                ' Reset Project
                Project.edgeCount = 0
                Project.nodeLoadCount = 0
                Project.edges.Clear()
                Project.loads.Clear()
                Project.filePath = path
                listEdges.Items.Clear()
                listLoads.Items.Clear()
                txtIterations.Text = 10
                txtError.Text = 0.001
                txtRoundFactor.Text = 3
                txtPower.Text = 100
                txtVoltage_R.Text = 400
                Me.Text = "Distribution LoadFlow Analysis Software (" + path + ")"

                Dim fileInfo = New FileInfo(path)
                Using package = New ExcelPackage(fileInfo)

                    package.LicenseContext = LicenseContext.NonCommercial

                    ' Import Edges
                    Dim edgeSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(0)

                    For i As Integer = 2 To edgeSheet.Dimension.End.Row
                        If edgeSheet.Cells(i, 4).Value.ToString = "L" Then
                            Dim line = New Line(edgeSheet.Cells(i, 1).Value, edgeSheet.Cells(i, 3).Value, edgeSheet.Cells(i, 5).Value)

                            Project.edgeCount = Project.edgeCount + 1

                            Dim data(4) As String
                            data(0) = Project.edgeCount
                            data(1) = line.startNode
                            data(2) = line.endNode
                            data(3) = "Line " + line.type

                            Dim item As ListViewItem
                            item = New ListViewItem(data)
                            listEdges.Items.Add(item)

                            Project.edges.Add(Project.edgeCount, line)
                        Else
                            Dim transformer = New Transformer(edgeSheet.Cells(i, 1).Value, edgeSheet.Cells(i, 3).Value, edgeSheet.Cells(i, 5).Value)

                            Project.edgeCount = Project.edgeCount + 1

                            Dim data(4) As String
                            data(0) = Project.edgeCount
                            data(1) = transformer.startNode
                            data(2) = transformer.endNode
                            data(3) = "Transformer " + transformer.type

                            Dim item As ListViewItem
                            item = New ListViewItem(data)
                            listEdges.Items.Add(item)

                            Project.edges.Add(Project.edgeCount, transformer)
                        End If
                    Next

                    Dim nodeSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(1)

                    For i As Integer = 2 To nodeSheet.Dimension.End.Row
                        If nodeSheet.Cells(i, 3).Value.ToString = "L" Then
                            Dim load = New Load(nodeSheet.Cells(i, 1).Value, nodeSheet.Cells(i, 2).Value, nodeSheet.Cells(i, 4).Value)

                            Project.nodeLoadCount = Project.nodeLoadCount + 1

                            Dim data(4) As String
                            data(0) = Project.edgeCount
                            data(1) = load.node
                            data(2) = load.connection
                            data(3) = "Load"

                            Dim item As ListViewItem
                            item = New ListViewItem(data)
                            listLoads.Items.Add(item)

                            Project.loads.Add(Project.nodeLoadCount, load)
                        ElseIf nodeSheet.Cells(i, 3).Value.ToString = "C" Then
                            Dim capacitor = New ShuntCapacitor(nodeSheet.Cells(i, 1).Value, nodeSheet.Cells(i, 2).Value, nodeSheet.Cells(i, 4).Value)

                            Project.nodeLoadCount = Project.nodeLoadCount + 1

                            Dim data(4) As String
                            data(0) = Project.edgeCount
                            data(1) = capacitor.node
                            data(2) = capacitor.connection
                            data(3) = "Shunt Capacitor"

                            Dim item As ListViewItem
                            item = New ListViewItem(data)
                            listLoads.Items.Add(item)

                            Project.loads.Add(Project.nodeLoadCount, capacitor)
                        Else
                            Dim generator = New DG(nodeSheet.Cells(i, 1).Value, nodeSheet.Cells(i, 2).Value, nodeSheet.Cells(i, 4).Value)

                            Project.nodeLoadCount = Project.nodeLoadCount + 1

                            Dim data(4) As String
                            data(0) = Project.edgeCount
                            data(1) = generator.node
                            data(2) = generator.connection
                            data(3) = "Distributed Generator"

                            Dim item As ListViewItem
                            item = New ListViewItem(data)
                            listLoads.Items.Add(item)

                            Project.loads.Add(Project.nodeLoadCount, generator)
                        End If
                    Next

                    ' Import Voltage
                    Dim voltageSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(2)

                    txtPower.Text = voltageSheet.Cells(2, 3).Value
                    Dim voltage As String() = voltageSheet.Cells(2, 2).Value.ToString.Split(New Char() {","c})
                    txtVoltage_R.Text = voltage(0)
                    txtVoltage_I.Text = voltage(1)

                    ' Import Settings
                    Dim settingsSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(3)
                    txtError.Text = settingsSheet.Cells(1, 2).Value
                    txtIterations.Text = settingsSheet.Cells(2, 2).Value
                    txtRoundFactor.Text = settingsSheet.Cells(3, 2).Value
                    txtUpperLimit.Text = settingsSheet.Cells(4, 2).Value
                    txtLowerLimit.Text = settingsSheet.Cells(5, 2).Value

                End Using

                listLog.Items.Add("File loaded from " + Project.filePath)

                createGraph()

            End If

        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If validateData() Then
            If sfdProject.ShowDialog = Windows.Forms.DialogResult.OK Then
                Project.filePath = sfdProject.FileName
                My.Computer.FileSystem.CopyFile("data.xlsx", Project.filePath)
                Me.Text = "Distribution LoadFlow Analysis Software (" + Project.filePath + ")"
                saveFile()
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If validateData() Then
            If Project.filePath Is Nothing Then
                If sfdProject.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Project.filePath = sfdProject.FileName
                    My.Computer.FileSystem.CopyFile("data.xlsx", Project.filePath)
                    Me.Text = "Distribution LoadFlow Analysis Software (" + Project.filePath + ")"
                    saveFile()
                End If
            Else
                saveFile()
            End If
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        ' Save if opened
        If Project.edges.Count > 0 And Project.loads.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save the current project?", "Save Project", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                ' Do Nothing
            ElseIf result = DialogResult.Yes Then
                If validateData() Then
                    If Project.filePath Is Nothing Then
                        If sfdProject.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Project.filePath = sfdProject.FileName
                            My.Computer.FileSystem.CopyFile("data.xlsx", Project.filePath)
                            Me.Text = "Distribution LoadFlow Analysis Software (" + Project.filePath + ")"
                            saveFile()
                        Else
                            Exit Sub
                        End If
                    Else
                        saveFile()
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        ' Reset Project
        Project.edgeCount = 0
        Project.nodeLoadCount = 0
        Project.edges.Clear()
        Project.loads.Clear()
        Project.filePath = Nothing
        listEdges.Items.Clear()
        listLoads.Items.Clear()
        txtIterations.Text = 10
        txtError.Text = 0.001
        txtRoundFactor.Text = 3
        txtPower.Text = 100
        txtVoltage_R.Text = 400
        txtLowerLimit.Text = 0.05
        txtUpperLimit.Text = 0.05
        Me.Text = "Distribution LoadFlow Analysis Software"

        createGraph()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Save if opened
        If Project.edges.Count > 0 And Project.loads.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save the current project?", "Save Project", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Cancel Then
                e.Cancel = True
            ElseIf result = DialogResult.No Then
                ' Do Nothing
            ElseIf result = DialogResult.Yes Then
                If validateData() Then
                    If Project.filePath Is Nothing Then
                        If sfdProject.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Project.filePath = sfdProject.FileName
                            My.Computer.FileSystem.CopyFile("data.xlsx", Project.filePath)
                            Me.Text = "Distribution LoadFlow Analysis Software (" + Project.filePath + ")"
                            saveFile()
                        Else
                            e.Cancel = True
                        End If
                    Else
                        saveFile()
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub ValidateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValidateToolStripMenuItem.Click
        arrangeData()
        createGraph()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.ShowDialog()
    End Sub

    Private Sub arrangeData()
        listEdges.Items.Clear()
        Dim edgesSorted As New Dictionary(Of Integer, Edge)
        Dim edgeSort As New List(Of Tuple(Of Integer, Integer))
        Dim counter As Integer = 1

        For Each kvp As KeyValuePair(Of Integer, Edge) In Project.edges
            edgeSort.Add(Tuple.Create(kvp.Key, kvp.Value.startNode))
        Next
        edgeSort = edgeSort.OrderBy(Function(i) i.Item2).ToList

        For Each tpl As Tuple(Of Integer, Integer) In edgeSort
            Dim _edge = Project.edges(tpl.Item1)
            edgesSorted.Add(counter, _edge)
            Dim data(4) As String
            data(0) = counter
            data(1) = _edge.startNode
            data(2) = _edge.endNode
            If _edge.GetType() Is GetType(Line) Then
                data(3) = "Line " + CType(_edge, Line).type
            Else
                data(3) = "Trasformer " + CType(_edge, Transformer).type
            End If

            Dim item As ListViewItem
            item = New ListViewItem(data)
            listEdges.Items.Add(item)

            counter += 1
        Next
        Project.edges = edgesSorted

        ' Arrange Nodes
        listLoads.Items.Clear()
        Dim loadsSorted As New Dictionary(Of Integer, Node)
        Dim nodeSort As New List(Of Tuple(Of Integer, Integer))
        counter = 1

        For Each kvp As KeyValuePair(Of Integer, Node) In Project.loads
            nodeSort.Add(Tuple.Create(kvp.Key, kvp.Value.node))
        Next
        nodeSort = nodeSort.OrderBy(Function(i) i.Item2).ToList

        For Each tpl As Tuple(Of Integer, Integer) In nodeSort
            Dim _load = Project.loads(tpl.Item1)
            loadsSorted.Add(counter, _load)
            Dim data(4) As String
            data(0) = counter
            data(1) = _load.node
            data(2) = _load.connection
            If _load.GetType() Is GetType(Load) Then
                data(3) = "Load"
            ElseIf _load.GetType() Is GetType(ShuntCapacitor) Then
                data(3) = "Shunt Capacitor"
            Else
                data(3) = "Distributed Generator"
            End If

            Dim item As ListViewItem
            item = New ListViewItem(data)
            listLoads.Items.Add(item)

            counter += 1
        Next
        Project.loads = loadsSorted

        listLog.Items.Add("Network data rearranged")
    End Sub

    Private Sub saveFile()
        Dim fileInfo = New FileInfo(Project.filePath)
        Using package = New ExcelPackage(fileInfo)

            package.LicenseContext = LicenseContext.NonCommercial

            ' Export Edges
            Dim i As Integer = 2
            Dim edgeSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(0)
            For Each kvp As KeyValuePair(Of Integer, Edge) In Project.edges
                If kvp.Value.GetType() Is GetType(Line) Then
                    Dim line As Line = kvp.Value
                    edgeSheet.Cells(i, 1).Value = line.startNode
                    edgeSheet.Cells(i, 3).Value = line.endNode
                    edgeSheet.Cells(i, 4).Value = "L"
                    edgeSheet.Cells(i, 5).Value = line.getParameters()
                Else
                    Dim transformer As Transformer = kvp.Value
                    edgeSheet.Cells(i, 1).Value = transformer.startNode
                    edgeSheet.Cells(i, 3).Value = transformer.endNode
                    edgeSheet.Cells(i, 4).Value = "T"
                    edgeSheet.Cells(i, 5).Value = transformer.getParameters()
                End If
                i = i + 1
            Next

            ' Export Nodes
            i = 2
            Dim nodeSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(1)

            For Each kvp As KeyValuePair(Of Integer, Node) In Project.loads
                If kvp.Value.GetType() Is GetType(Load) Then
                    Dim load As Load = kvp.Value

                    nodeSheet.Cells(i, 1).Value = load.node
                    nodeSheet.Cells(i, 2).Value = load.getConnection()
                    nodeSheet.Cells(i, 3).Value = "L"
                    nodeSheet.Cells(i, 4).Value = load.getParameters()
                ElseIf kvp.Value.GetType() Is GetType(ShuntCapacitor) Then
                    Dim capacitor As ShuntCapacitor = kvp.Value

                    nodeSheet.Cells(i, 1).Value = capacitor.node
                    nodeSheet.Cells(i, 2).Value = capacitor.getConnection()
                    nodeSheet.Cells(i, 3).Value = "C"
                    nodeSheet.Cells(i, 4).Value = capacitor.getParameters()
                ElseIf kvp.Value.GetType() Is GetType(DG) Then
                    Dim generator As DG = kvp.Value

                    nodeSheet.Cells(i, 1).Value = generator.node
                    nodeSheet.Cells(i, 2).Value = generator.getConnection()
                    nodeSheet.Cells(i, 3).Value = "D"
                    nodeSheet.Cells(i, 4).Value = generator.getParameters()
                End If
                i = i + 1
            Next

            ' Export Voltage
            Dim voltageSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(2)

            ' Add All Nodes
            voltageSheet.Cells(2, 1).Value = 1
            For j As Integer = 1 To findMaximumNode()
                voltageSheet.Cells(j + 1, 1).Value = j
            Next

            ' Add Swing Bus Voltage
            voltageSheet.Cells(2, 2).Value = txtVoltage_R.Text + "," + txtVoltage_I.Text
            voltageSheet.Cells(2, 3).Value = Convert.ToDouble(txtPower.Text)

            ' Export Settings
            Dim settingsSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(3)
            settingsSheet.Cells(1, 2).Value = Convert.ToDouble(txtError.Text)
            settingsSheet.Cells(2, 2).Value = Convert.ToDouble(txtIterations.Text)
            settingsSheet.Cells(3, 2).Value = Convert.ToDouble(txtRoundFactor.Text)
            settingsSheet.Cells(4, 2).Value = Convert.ToDouble(txtUpperLimit.Text)
            settingsSheet.Cells(5, 2).Value = Convert.ToDouble(txtLowerLimit.Text)

            package.Save()

            listLog.Items.Add("File saved to " + Project.filePath)
        End Using
    End Sub

    Private Sub createGraph()
        Dim graph = New Microsoft.Glee.Drawing.Graph("Network")
        Dim node_1
        Dim node_2
        Dim loadName As String

        For Each kvp As KeyValuePair(Of Integer, Edge) In Project.edges
            graph.AddEdge(kvp.Value.startNode, kvp.Value.endNode)

            node_1 = graph.FindNode(kvp.Value.startNode)
            node_2 = graph.FindNode(kvp.Value.endNode)
            node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Aqua
            node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle
            node_2.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Aqua
            node_2.Attr.Shape = Microsoft.Glee.Drawing.Shape.Circle
        Next

        For Each kvp As KeyValuePair(Of Integer, Node) In Project.loads

            If kvp.Value.GetType() Is GetType(Load) Then
                loadName = "Load #" + kvp.Key.ToString
            ElseIf kvp.Value.GetType() Is GetType(ShuntCapacitor) Then
                loadName = "SC #" + kvp.Key.ToString
            Else
                loadName = "DG #" + kvp.Key.ToString
            End If

            graph.AddEdge(kvp.Value.node, loadName)
            node_1 = graph.FindNode(loadName)

            If kvp.Value.GetType() Is GetType(Load) Then
                node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Green
                node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Box
            ElseIf kvp.Value.GetType() Is GetType(ShuntCapacitor) Then
                node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Blue
                node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Triangle
            Else
                node_1.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Red
                node_1.Attr.Shape = Microsoft.Glee.Drawing.Shape.Octagon
            End If
        Next

        viewer.Graph = graph
        Me.SuspendLayout()
        viewer.Dock = System.Windows.Forms.DockStyle.Fill
        panViewer.Controls.Add(viewer)
        Me.ResumeLayout()

    End Sub

    Private Function findMaximumNode() As Integer
        Dim edge As Integer = 0
        For Each kvp As KeyValuePair(Of Integer, Edge) In Project.edges
            If kvp.Value.endNode > edge Then
                edge = kvp.Value.endNode
            End If
        Next

        Return edge
    End Function

    Private Function validateData() As Boolean
        If Project.edges.Count = 0 Or Project.loads.Count = 0 Then
            MsgBox("Please add at lease one edge and one node to the network", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            Return False
        End If

        If txtError.Text = "" Or txtIterations.Text = "" Or txtRoundFactor.Text = "" Or txtVoltage_I.Text = "" Or txtVoltage_R.Text = "" Or txtPower.Text = "" Then
            MsgBox("Please add network settings for the iteration", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            Return False
        End If

        If txtIterations.Text = "" Or txtIterations.Text = 0 Then
            MsgBox("Invalid iterations! Please add iterations more than 1", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            Return False
        End If

        If txtPower.Text = "" Or txtPower.Text = 0 Then
            MsgBox("Invalid network setting! Please check and retry", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            Return False
        End If

        If txtUpperLimit.Text = "" Or txtLowerLimit.Text = "" Then
            MsgBox("Invalid violation check setting! Please check and retry", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
            Return False
        Else
            If txtUpperLimit.Text = 0 Or txtLowerLimit.Text = 0 Then
                MsgBox("Invalid violation check setting! Please check and retry", MsgBoxStyle.Information, "Distribution LoadFlow Analysis Software")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub calculateNetwork()
        My.Computer.FileSystem.CopyFile("data.xlsx", "script/dat.xlsx", True)
        Dim fileInfo = New FileInfo("script/dat.xlsx")
        Using package = New ExcelPackage(fileInfo)

            package.LicenseContext = LicenseContext.NonCommercial

            ' Export Edges
            Dim edgeSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(0)
            For Each kvp As KeyValuePair(Of Integer, Edge) In Project.edges
                If kvp.Value.GetType() Is GetType(Line) Then
                    Dim line As Line = kvp.Value
                    edgeSheet.Cells(kvp.Key + 1, 1).Value = line.startNode
                    edgeSheet.Cells(kvp.Key + 1, 3).Value = line.endNode
                    edgeSheet.Cells(kvp.Key + 1, 4).Value = "L"
                    edgeSheet.Cells(kvp.Key + 1, 5).Value = line.getParameters()
                Else
                    Dim transformer As Transformer = kvp.Value
                    edgeSheet.Cells(kvp.Key + 1, 1).Value = transformer.startNode
                    edgeSheet.Cells(kvp.Key + 1, 3).Value = transformer.endNode
                    edgeSheet.Cells(kvp.Key + 1, 4).Value = "T"
                    edgeSheet.Cells(kvp.Key + 1, 5).Value = transformer.getParameters()
                End If
            Next

            ' Export Nodes
            Dim nodeSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(1)

            For Each kvp As KeyValuePair(Of Integer, Node) In Project.loads
                If kvp.Value.GetType() Is GetType(Load) Then
                    Dim load As Load = kvp.Value

                    nodeSheet.Cells(kvp.Key + 1, 1).Value = load.node
                    nodeSheet.Cells(kvp.Key + 1, 2).Value = load.getConnection()
                    nodeSheet.Cells(kvp.Key + 1, 3).Value = "L"
                    nodeSheet.Cells(kvp.Key + 1, 4).Value = load.getParameters()
                ElseIf kvp.Value.GetType() Is GetType(ShuntCapacitor) Then
                    Dim capacitor As ShuntCapacitor = kvp.Value

                    nodeSheet.Cells(kvp.Key + 1, 1).Value = capacitor.node
                    nodeSheet.Cells(kvp.Key + 1, 2).Value = capacitor.getConnection()
                    nodeSheet.Cells(kvp.Key + 1, 3).Value = "C"
                    nodeSheet.Cells(kvp.Key + 1, 4).Value = capacitor.getParameters()
                ElseIf kvp.Value.GetType() Is GetType(DG) Then
                    Dim generator As DG = kvp.Value

                    nodeSheet.Cells(kvp.Key + 1, 1).Value = generator.node
                    nodeSheet.Cells(kvp.Key + 1, 2).Value = generator.getConnection()
                    nodeSheet.Cells(kvp.Key + 1, 3).Value = "D"
                    nodeSheet.Cells(kvp.Key + 1, 4).Value = generator.getParameters()
                End If
            Next

            ' Export Voltage
            Dim voltageSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(2)

            ' Add All Nodes
            voltageSheet.Cells(2, 1).Value = 1
            For i As Integer = 1 To findMaximumNode()
                voltageSheet.Cells(i + 1, 1).Value = i
            Next

            ' Add Swing Bus Voltage
            voltageSheet.Cells(2, 2).Value = txtVoltage_R.Text + "," + txtVoltage_I.Text
            voltageSheet.Cells(2, 3).Value = Convert.ToDouble(txtPower.Text)

            ' Export Settings
            Dim settingsSheet As ExcelWorksheet = package.Workbook.Worksheets.Item(3)
            settingsSheet.Cells(1, 2).Value = Convert.ToDouble(txtError.Text)
            settingsSheet.Cells(2, 2).Value = Convert.ToDouble(txtIterations.Text)
            settingsSheet.Cells(3, 2).Value = Convert.ToDouble(txtRoundFactor.Text)
            settingsSheet.Cells(4, 2).Value = Convert.ToDouble(txtUpperLimit.Text)
            settingsSheet.Cells(5, 2).Value = Convert.ToDouble(txtLowerLimit.Text)

            package.Save()

            listLog.Items.Add("Data file created")
        End Using

        TabControl1.SelectedTab = tabResults
        dataLog = "----- EXECUTION START -----" + vbCrLf + vbCrLf
        dataLog += "File: " + Project.filePath + vbCrLf + vbCrLf

        listLog.Items.Add("Executing data file")
        Dim proc As Process = New Process
        proc.StartInfo.FileName = My.Settings.pythonPath
        proc.StartInfo.Arguments = "script/Base.py"
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.RedirectStandardOutput = True
        proc.Start()
        AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived
        proc.BeginOutputReadLine()
        proc.WaitForExit()

        txtOutput.AppendText(dataLog)
        txtOutput.AppendText(vbCrLf + "----- EXECUTION COMPLETED -----" + vbCrLf + vbCrLf)
        listLog.Items.Add("Execution completed")
    End Sub

    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        ' On Error Resume Next
        If e.Data <> "" Then
            dataLog = dataLog + e.Data + vbCrLf
        End If
    End Sub

    Public Sub addLog(ByVal message As String, ByVal color As Color)
        Dim item As New ListViewItem
        item.Text = message
        item.ForeColor = color
        listLog.Items.Add(item)
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        If validateData() Then
            arrangeData()
            calculateNetwork()
            btnFaultAnalys.Enabled = True



        End If



    End Sub

    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click
        If validateData() Then
            arrangeData()
            calculateNetwork()
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Project.connectDatabase = False Then
            End
        End If
    End Sub

    Private Sub ModelBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModelBrowserToolStripMenuItem.Click
        frmBrowser.Show()
    End Sub


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.Show()
    End Sub

    Private Sub listEdges_DoubleClick(sender As Object, e As EventArgs) Handles listEdges.DoubleClick
        If listEdges.SelectedItems.Count > 0 Then
            Dim edgeId = Integer.Parse(listEdges.FocusedItem.SubItems(0).Text)

            Dim result As Edge = Nothing
            If Project.edges.TryGetValue(edgeId, result) Then
                If result IsNot Nothing Then
                    If result.GetType() Is GetType(Line) Then
                        Dim line = frmAddLine.ShowDialog(True, result)

                        If line.isValid Then

                            listEdges.FocusedItem.SubItems(1).Text = line.startNode
                            listEdges.FocusedItem.SubItems(2).Text = line.endNode
                            listEdges.FocusedItem.SubItems(3).Text = "Line " + line.type

                            Project.edges.Remove(edgeId)
                            Project.edges.Add(edgeId, line)

                            createGraph()
                        End If
                    Else
                        Dim transformer = frmAddTransformer.ShowDialog(isEditor:=True, result)

                        If transformer.isValid Then

                            listEdges.FocusedItem.SubItems(1).Text = transformer.startNode
                            listEdges.FocusedItem.SubItems(2).Text = transformer.endNode
                            listEdges.FocusedItem.SubItems(3).Text = "Transformer " + transformer.type

                            Project.edges.Remove(edgeId)
                            Project.edges.Add(edgeId, transformer)

                            createGraph()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub listLoads_DoubleClick(sender As Object, e As EventArgs) Handles listLoads.DoubleClick
        If listLoads.SelectedItems.Count > 0 Then
            Dim loadId = Integer.Parse(listLoads.FocusedItem.SubItems(0).Text)

            Dim result As Node = Nothing
            If Project.loads.TryGetValue(loadId, result) Then
                If result IsNot Nothing Then
                    If result.GetType() Is GetType(Load) Then
                        Dim load = frmAddLoad.ShowDialog(isEditor:=True, result)

                        If load.isValid Then

                            listLoads.FocusedItem.SubItems(1).Text = load.node
                            listLoads.FocusedItem.SubItems(2).Text = load.connection
                            listLoads.FocusedItem.SubItems(3).Text = "Load"

                            Project.loads.Remove(loadId)
                            Project.loads.Add(loadId, load)

                            createGraph()
                        End If
                    ElseIf result.GetType() Is GetType(ShuntCapacitor) Then
                        Dim capacitor = frmAddShuntCapacitor.ShowDialog(isEditor:=True, result)

                        If capacitor.isValid Then

                            listLoads.FocusedItem.SubItems(1).Text = capacitor.node
                            listLoads.FocusedItem.SubItems(2).Text = capacitor.connection
                            listLoads.FocusedItem.SubItems(3).Text = "Shunt Capacitor"

                            Project.loads.Remove(loadId)
                            Project.loads.Add(loadId, capacitor)

                            createGraph()
                        End If
                    ElseIf result.GetType() Is GetType(DG) Then
                        Dim generator = frmAddDG.ShowDialog(isEditor:=True, result)

                        If generator.isValid Then

                            listLoads.FocusedItem.SubItems(1).Text = generator.node
                            listLoads.FocusedItem.SubItems(2).Text = generator.connection
                            listLoads.FocusedItem.SubItems(3).Text = "Distributed Generator"

                            Project.loads.Remove(loadId)
                            Project.loads.Add(loadId, generator)

                            createGraph()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    ' *** GUI Enhancements ***

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If sfdOutput.ShowDialog = Windows.Forms.DialogResult.OK Then
            If System.IO.File.Exists(sfdOutput.FileName) = True Then
                Dim objWriter As New System.IO.StreamWriter(sfdOutput.FileName)
                objWriter.Write(txtOutput.Text)
                objWriter.Close()
            Else
                My.Computer.FileSystem.WriteAllText(sfdOutput.FileName, txtOutput.Text, False)
            End If
        End If
    End Sub

    Private Sub ExportDataFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportDataFileToolStripMenuItem.Click
        If sfdDatFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.CopyFile("script/dat.xlsx", Project.filePath)
        End If
    End Sub

    Private Sub txtError_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtError.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtIterations_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIterations.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
    End Sub

    Private Sub txtLowerLimit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLowerLimit.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtPower_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPower.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtRoundFactor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRoundFactor.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
    End Sub

    Private Sub txtUpperLimit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUpperLimit.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtVoltage_I_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVoltage_I.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub txtVoltage_R_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVoltage_R.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        If Not Char.IsDigit(e.KeyChar) Then e.Handled = True
        If e.KeyChar = Chr(8) Then e.Handled = False
        If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False
    End Sub

    Private Sub btnFaultCal_Click(sender As Object, e As EventArgs) Handles btnFaultAnalys.Click


        Dim faultAny As New frmFaultCal
        faultAny.passNodeData = listEdges
        faultAny.passLoadData = listLoads



        faultAny.passLineSequ = New FileInfo("script/dat.xlsx")





        faultAny.Show()






    End Sub

    Private Sub viewer_Load(sender As Object, e As EventArgs) Handles viewer.Load

    End Sub

    Private Sub listLog_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listLog.SelectedIndexChanged

    End Sub

    Private Sub listEdges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listEdges.SelectedIndexChanged
        btnFaultAnalys.Enabled = False
    End Sub

    Private Sub listLoads_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listLoads.SelectedIndexChanged
        btnFaultAnalys.Enabled = False
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
