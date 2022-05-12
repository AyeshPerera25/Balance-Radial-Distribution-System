<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SimulationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValidateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportDataFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModelBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabEdges = New System.Windows.Forms.TabPage()
        Me.listEdges = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDeleteEdge = New System.Windows.Forms.Button()
        Me.btnAddTransformer = New System.Windows.Forms.Button()
        Me.btnAddLine = New System.Windows.Forms.Button()
        Me.tabLoads = New System.Windows.Forms.TabPage()
        Me.listLoads = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddDg = New System.Windows.Forms.Button()
        Me.btnAddCapacitor = New System.Windows.Forms.Button()
        Me.btnDeleteLoad = New System.Windows.Forms.Button()
        Me.btnAddLoad = New System.Windows.Forms.Button()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtLowerLimit = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtUpperLimit = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPower = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVoltage_I = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtVoltage_R = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRoundFactor = New System.Windows.Forms.TextBox()
        Me.txtIterations = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtError = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabResults = New System.Windows.Forms.TabPage()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panViewer = New System.Windows.Forms.Panel()
        Me.viewer = New Microsoft.Glee.GraphViewerGdi.GViewer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.ofdProject = New System.Windows.Forms.OpenFileDialog()
        Me.sfdProject = New System.Windows.Forms.SaveFileDialog()
        Me.sfdOutput = New System.Windows.Forms.SaveFileDialog()
        Me.sfdDatFile = New System.Windows.Forms.SaveFileDialog()
        Me.btnFaultAnalys = New System.Windows.Forms.Button()
        Me.listLog = New System.Windows.Forms.ListBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabEdges.SuspendLayout()
        Me.tabLoads.SuspendLayout()
        Me.tabSettings.SuspendLayout()
        Me.tabResults.SuspendLayout()
        Me.panViewer.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 632)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 12, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1090, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Ready"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SimulationToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1090, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "File"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.toolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(143, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'SimulationToolStripMenuItem
        '
        Me.SimulationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalculateToolStripMenuItem, Me.ValidateToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ExportDataFileToolStripMenuItem, Me.ToolStripSeparator2, Me.SettingsToolStripMenuItem})
        Me.SimulationToolStripMenuItem.Name = "SimulationToolStripMenuItem"
        Me.SimulationToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.SimulationToolStripMenuItem.Text = "Simulation"
        '
        'CalculateToolStripMenuItem
        '
        Me.CalculateToolStripMenuItem.Name = "CalculateToolStripMenuItem"
        Me.CalculateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.CalculateToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CalculateToolStripMenuItem.Text = "Calculate Loadflow"
        '
        'ValidateToolStripMenuItem
        '
        Me.ValidateToolStripMenuItem.Name = "ValidateToolStripMenuItem"
        Me.ValidateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.ValidateToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ValidateToolStripMenuItem.Text = "Validate"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ExportToolStripMenuItem.Text = "Export Results"
        '
        'ExportDataFileToolStripMenuItem
        '
        Me.ExportDataFileToolStripMenuItem.Name = "ExportDataFileToolStripMenuItem"
        Me.ExportDataFileToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ExportDataFileToolStripMenuItem.Text = "Export Data File"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(191, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModelBrowserToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'ModelBrowserToolStripMenuItem
        '
        Me.ModelBrowserToolStripMenuItem.Name = "ModelBrowserToolStripMenuItem"
        Me.ModelBrowserToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ModelBrowserToolStripMenuItem.Text = "Model Browser"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabEdges)
        Me.TabControl1.Controls.Add(Me.tabLoads)
        Me.TabControl1.Controls.Add(Me.tabSettings)
        Me.TabControl1.Controls.Add(Me.tabResults)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(11, 58)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(676, 424)
        Me.TabControl1.TabIndex = 2
        '
        'tabEdges
        '
        Me.tabEdges.Controls.Add(Me.listEdges)
        Me.tabEdges.Controls.Add(Me.btnDeleteEdge)
        Me.tabEdges.Controls.Add(Me.btnAddTransformer)
        Me.tabEdges.Controls.Add(Me.btnAddLine)
        Me.tabEdges.Location = New System.Drawing.Point(4, 22)
        Me.tabEdges.Name = "tabEdges"
        Me.tabEdges.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEdges.Size = New System.Drawing.Size(668, 398)
        Me.tabEdges.TabIndex = 0
        Me.tabEdges.Text = "Branches"
        Me.tabEdges.UseVisualStyleBackColor = True
        '
        'listEdges
        '
        Me.listEdges.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.listEdges.FullRowSelect = True
        Me.listEdges.GridLines = True
        Me.listEdges.HideSelection = False
        Me.listEdges.Location = New System.Drawing.Point(2, 3)
        Me.listEdges.Name = "listEdges"
        Me.listEdges.Size = New System.Drawing.Size(665, 360)
        Me.listEdges.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.listEdges.TabIndex = 6
        Me.listEdges.UseCompatibleStateImageBehavior = False
        Me.listEdges.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "#"
        Me.ColumnHeader5.Width = 40
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Start"
        Me.ColumnHeader6.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "End"
        Me.ColumnHeader7.Width = 151
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Type"
        Me.ColumnHeader8.Width = 300
        '
        'btnDeleteEdge
        '
        Me.btnDeleteEdge.Location = New System.Drawing.Point(587, 369)
        Me.btnDeleteEdge.Name = "btnDeleteEdge"
        Me.btnDeleteEdge.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteEdge.TabIndex = 5
        Me.btnDeleteEdge.Text = "Delete"
        Me.btnDeleteEdge.UseVisualStyleBackColor = True
        '
        'btnAddTransformer
        '
        Me.btnAddTransformer.Location = New System.Drawing.Point(87, 369)
        Me.btnAddTransformer.Name = "btnAddTransformer"
        Me.btnAddTransformer.Size = New System.Drawing.Size(115, 23)
        Me.btnAddTransformer.TabIndex = 4
        Me.btnAddTransformer.Text = "Add Trasnformer"
        Me.btnAddTransformer.UseVisualStyleBackColor = True
        '
        'btnAddLine
        '
        Me.btnAddLine.Location = New System.Drawing.Point(6, 369)
        Me.btnAddLine.Name = "btnAddLine"
        Me.btnAddLine.Size = New System.Drawing.Size(75, 23)
        Me.btnAddLine.TabIndex = 3
        Me.btnAddLine.Text = "Add Line"
        Me.btnAddLine.UseVisualStyleBackColor = True
        '
        'tabLoads
        '
        Me.tabLoads.Controls.Add(Me.listLoads)
        Me.tabLoads.Controls.Add(Me.btnAddDg)
        Me.tabLoads.Controls.Add(Me.btnAddCapacitor)
        Me.tabLoads.Controls.Add(Me.btnDeleteLoad)
        Me.tabLoads.Controls.Add(Me.btnAddLoad)
        Me.tabLoads.Location = New System.Drawing.Point(4, 22)
        Me.tabLoads.Name = "tabLoads"
        Me.tabLoads.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLoads.Size = New System.Drawing.Size(668, 398)
        Me.tabLoads.TabIndex = 1
        Me.tabLoads.Text = "Loads, Capacitor Banks & DGs"
        Me.tabLoads.UseVisualStyleBackColor = True
        '
        'listLoads
        '
        Me.listLoads.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.listLoads.FullRowSelect = True
        Me.listLoads.GridLines = True
        Me.listLoads.HideSelection = False
        Me.listLoads.Location = New System.Drawing.Point(0, 3)
        Me.listLoads.Name = "listLoads"
        Me.listLoads.Size = New System.Drawing.Size(665, 360)
        Me.listLoads.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.listLoads.TabIndex = 10
        Me.listLoads.UseCompatibleStateImageBehavior = False
        Me.listLoads.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "#"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Node"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Connection"
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Type"
        Me.ColumnHeader4.Width = 300
        '
        'btnAddDg
        '
        Me.btnAddDg.Location = New System.Drawing.Point(207, 369)
        Me.btnAddDg.Name = "btnAddDg"
        Me.btnAddDg.Size = New System.Drawing.Size(155, 23)
        Me.btnAddDg.TabIndex = 9
        Me.btnAddDg.Text = "Add Distributed Generator"
        Me.btnAddDg.UseVisualStyleBackColor = True
        '
        'btnAddCapacitor
        '
        Me.btnAddCapacitor.Location = New System.Drawing.Point(88, 369)
        Me.btnAddCapacitor.Name = "btnAddCapacitor"
        Me.btnAddCapacitor.Size = New System.Drawing.Size(113, 23)
        Me.btnAddCapacitor.TabIndex = 8
        Me.btnAddCapacitor.Text = "Add Shunt Capacitor"
        Me.btnAddCapacitor.UseVisualStyleBackColor = True
        '
        'btnDeleteLoad
        '
        Me.btnDeleteLoad.Location = New System.Drawing.Point(587, 369)
        Me.btnDeleteLoad.Name = "btnDeleteLoad"
        Me.btnDeleteLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteLoad.TabIndex = 7
        Me.btnDeleteLoad.Text = "Delete"
        Me.btnDeleteLoad.UseVisualStyleBackColor = True
        '
        'btnAddLoad
        '
        Me.btnAddLoad.Location = New System.Drawing.Point(7, 369)
        Me.btnAddLoad.Name = "btnAddLoad"
        Me.btnAddLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnAddLoad.TabIndex = 6
        Me.btnAddLoad.Text = "Add Load"
        Me.btnAddLoad.UseVisualStyleBackColor = True
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.Label18)
        Me.tabSettings.Controls.Add(Me.Label17)
        Me.tabSettings.Controls.Add(Me.txtLowerLimit)
        Me.tabSettings.Controls.Add(Me.Label14)
        Me.tabSettings.Controls.Add(Me.txtUpperLimit)
        Me.tabSettings.Controls.Add(Me.Label15)
        Me.tabSettings.Controls.Add(Me.Label16)
        Me.tabSettings.Controls.Add(Me.Label13)
        Me.tabSettings.Controls.Add(Me.Label12)
        Me.tabSettings.Controls.Add(Me.txtPower)
        Me.tabSettings.Controls.Add(Me.Label10)
        Me.tabSettings.Controls.Add(Me.txtVoltage_I)
        Me.tabSettings.Controls.Add(Me.Label9)
        Me.tabSettings.Controls.Add(Me.txtVoltage_R)
        Me.tabSettings.Controls.Add(Me.Label11)
        Me.tabSettings.Controls.Add(Me.Label8)
        Me.tabSettings.Controls.Add(Me.txtRoundFactor)
        Me.tabSettings.Controls.Add(Me.txtIterations)
        Me.tabSettings.Controls.Add(Me.Label7)
        Me.tabSettings.Controls.Add(Me.txtError)
        Me.tabSettings.Controls.Add(Me.Label6)
        Me.tabSettings.Controls.Add(Me.Label5)
        Me.tabSettings.Controls.Add(Me.Label4)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSettings.Size = New System.Drawing.Size(668, 398)
        Me.tabSettings.TabIndex = 2
        Me.tabSettings.Text = "Calculation Settings"
        Me.tabSettings.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(287, 328)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(15, 13)
        Me.Label18.TabIndex = 80
        Me.Label18.Text = "%"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(287, 303)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(15, 13)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "%"
        '
        'txtLowerLimit
        '
        Me.txtLowerLimit.Location = New System.Drawing.Point(186, 325)
        Me.txtLowerLimit.Name = "txtLowerLimit"
        Me.txtLowerLimit.Size = New System.Drawing.Size(95, 20)
        Me.txtLowerLimit.TabIndex = 78
        Me.txtLowerLimit.Text = "0.05"
        Me.txtLowerLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(17, 276)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 15)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Voltage Limit Check"
        '
        'txtUpperLimit
        '
        Me.txtUpperLimit.Location = New System.Drawing.Point(186, 300)
        Me.txtUpperLimit.Name = "txtUpperLimit"
        Me.txtUpperLimit.Size = New System.Drawing.Size(95, 20)
        Me.txtUpperLimit.TabIndex = 76
        Me.txtUpperLimit.Text = "0.05"
        Me.txtUpperLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(31, 331)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 13)
        Me.Label15.TabIndex = 75
        Me.Label15.Text = "Lower Margin of Error"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(31, 303)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 13)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Upper Margin of Error"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(322, 214)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "kVA"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 214)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 13)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "Substation Fault Level"
        '
        'txtPower
        '
        Me.txtPower.Location = New System.Drawing.Point(232, 211)
        Me.txtPower.Name = "txtPower"
        Me.txtPower.Size = New System.Drawing.Size(86, 20)
        Me.txtPower.TabIndex = 71
        Me.txtPower.Text = "100"
        Me.txtPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(321, 181)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 24)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "∠"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVoltage_I
        '
        Me.txtVoltage_I.Location = New System.Drawing.Point(342, 186)
        Me.txtVoltage_I.Name = "txtVoltage_I"
        Me.txtVoltage_I.Size = New System.Drawing.Size(86, 20)
        Me.txtVoltage_I.TabIndex = 69
        Me.txtVoltage_I.Text = "0"
        Me.txtVoltage_I.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(433, 189)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(14, 13)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "V"
        '
        'txtVoltage_R
        '
        Me.txtVoltage_R.Location = New System.Drawing.Point(232, 186)
        Me.txtVoltage_R.Name = "txtVoltage_R"
        Me.txtVoltage_R.Size = New System.Drawing.Size(86, 20)
        Me.txtVoltage_R.TabIndex = 67
        Me.txtVoltage_R.Text = "400"
        Me.txtVoltage_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(31, 189)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(184, 13)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Substation Voltage (Outgoing Busbar)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(17, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Swing Bus Parameters"
        '
        'txtRoundFactor
        '
        Me.txtRoundFactor.Location = New System.Drawing.Point(186, 92)
        Me.txtRoundFactor.Name = "txtRoundFactor"
        Me.txtRoundFactor.Size = New System.Drawing.Size(95, 20)
        Me.txtRoundFactor.TabIndex = 6
        Me.txtRoundFactor.Text = "3"
        Me.txtRoundFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIterations
        '
        Me.txtIterations.Location = New System.Drawing.Point(186, 67)
        Me.txtIterations.Name = "txtIterations"
        Me.txtIterations.Size = New System.Drawing.Size(95, 20)
        Me.txtIterations.TabIndex = 5
        Me.txtIterations.Text = "10"
        Me.txtIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(17, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Algoritham Settings"
        '
        'txtError
        '
        Me.txtError.Location = New System.Drawing.Point(186, 42)
        Me.txtError.Name = "txtError"
        Me.txtError.Size = New System.Drawing.Size(95, 20)
        Me.txtError.TabIndex = 3
        Me.txtError.Text = "0.001"
        Me.txtError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Round Factor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Maximum Allowable Iterations"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Convergence Checking Value"
        '
        'tabResults
        '
        Me.tabResults.Controls.Add(Me.txtOutput)
        Me.tabResults.Location = New System.Drawing.Point(4, 22)
        Me.tabResults.Name = "tabResults"
        Me.tabResults.Size = New System.Drawing.Size(668, 398)
        Me.tabResults.TabIndex = 3
        Me.tabResults.Text = "Output"
        Me.tabResults.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(3, 3)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutput.Size = New System.Drawing.Size(662, 392)
        Me.txtOutput.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Network Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(693, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Network Visualisation"
        '
        'panViewer
        '
        Me.panViewer.BackColor = System.Drawing.Color.White
        Me.panViewer.Controls.Add(Me.viewer)
        Me.panViewer.Location = New System.Drawing.Point(693, 58)
        Me.panViewer.Name = "panViewer"
        Me.panViewer.Size = New System.Drawing.Size(387, 449)
        Me.panViewer.TabIndex = 5
        '
        'viewer
        '
        Me.viewer.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.viewer.AsyncLayout = False
        Me.viewer.AutoScroll = True
        Me.viewer.BackwardEnabled = False
        Me.viewer.ForwardEnabled = False
        Me.viewer.Graph = Nothing
        Me.viewer.Location = New System.Drawing.Point(0, -2)
        Me.viewer.MouseHitDistance = 0.05R
        Me.viewer.Name = "viewer"
        Me.viewer.NavigationVisible = True
        Me.viewer.PanButtonPressed = False
        Me.viewer.SaveButtonVisible = True
        Me.viewer.Size = New System.Drawing.Size(387, 449)
        Me.viewer.TabIndex = 1
        Me.viewer.ZoomF = 1.0R
        Me.viewer.ZoomFraction = 0.5R
        Me.viewer.ZoomWindowThreshold = 0.05R
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(14, 507)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Log"
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(435, 488)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(121, 23)
        Me.btnCalculate.TabIndex = 8
        Me.btnCalculate.Text = "Calculate Loadflow"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'ofdProject
        '
        Me.ofdProject.Filter = "LF Project Files (*.lfproj*)|*.lfproj|Excel Files (*.xlsx)|*.xlsx"
        '
        'sfdProject
        '
        Me.sfdProject.DefaultExt = "lfproj"
        Me.sfdProject.Filter = "LF Project Files (*.lfproj*)|*.lfproj|Excel Files (*.xlsx)|*.xlsx"
        Me.sfdProject.Title = "Save Project As"
        '
        'sfdOutput
        '
        Me.sfdOutput.DefaultExt = "lfproj"
        Me.sfdOutput.Filter = "Text Files (*.txt*)|*.txt"
        Me.sfdOutput.Title = "Save Project As"
        '
        'sfdDatFile
        '
        Me.sfdDatFile.DefaultExt = "lfproj"
        Me.sfdDatFile.Filter = "Excel Files (*.xlsx)|*.xlsx"
        Me.sfdDatFile.Title = "Save Project As"
        '
        'btnFaultAnalys
        '
        Me.btnFaultAnalys.Enabled = False
        Me.btnFaultAnalys.Location = New System.Drawing.Point(562, 488)
        Me.btnFaultAnalys.Name = "btnFaultAnalys"
        Me.btnFaultAnalys.Size = New System.Drawing.Size(121, 23)
        Me.btnFaultAnalys.TabIndex = 11
        Me.btnFaultAnalys.Text = "Fault Analysis"
        Me.btnFaultAnalys.UseVisualStyleBackColor = True
        '
        'listLog
        '
        Me.listLog.FormattingEnabled = True
        Me.listLog.Items.AddRange(New Object() {"Program Initiated", "Database Connected"})
        Me.listLog.Location = New System.Drawing.Point(11, 529)
        Me.listLog.Name = "listLog"
        Me.listLog.Size = New System.Drawing.Size(1069, 95)
        Me.listLog.TabIndex = 10
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 654)
        Me.Controls.Add(Me.btnFaultAnalys)
        Me.Controls.Add(Me.listLog)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.panViewer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distribution LoadFlow Analysis Software"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabEdges.ResumeLayout(False)
        Me.tabLoads.ResumeLayout(False)
        Me.tabSettings.ResumeLayout(False)
        Me.tabSettings.PerformLayout()
        Me.tabResults.ResumeLayout(False)
        Me.tabResults.PerformLayout()
        Me.panViewer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabEdges As TabPage
    Friend WithEvents tabLoads As TabPage
    Friend WithEvents tabSettings As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents panViewer As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCalculate As Button
    Friend WithEvents tabResults As TabPage
    Friend WithEvents btnAddLine As Button
    Friend WithEvents btnAddTransformer As Button
    Friend WithEvents btnDeleteEdge As Button
    Friend WithEvents btnDeleteLoad As Button
    Friend WithEvents btnAddLoad As Button
    Friend WithEvents btnAddDg As Button
    Friend WithEvents btnAddCapacitor As Button
    Friend WithEvents txtRoundFactor As TextBox
    Friend WithEvents txtIterations As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtError As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ofdProject As OpenFileDialog
    Friend WithEvents Label8 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtPower As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtVoltage_I As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtVoltage_R As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents sfdProject As SaveFileDialog
    Friend WithEvents SimulationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalculateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ValidateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportDataFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents listEdges As ListView
    Friend WithEvents ColumnHeader44 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader33 As ColumnHeader
    Friend WithEvents listLoads As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModelBrowserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Private WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents viewer As Microsoft.Glee.GraphViewerGdi.GViewer
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtLowerLimit As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtUpperLimit As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents sfdOutput As SaveFileDialog
    Friend WithEvents sfdDatFile As SaveFileDialog
    Friend WithEvents btnFaultAnalys As Button
    Friend WithEvents listLog As ListBox
End Class
