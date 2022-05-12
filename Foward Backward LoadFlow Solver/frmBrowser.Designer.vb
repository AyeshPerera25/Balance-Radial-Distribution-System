<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBrowser
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
        Me.listModels = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnAddTransformer = New System.Windows.Forms.Button()
        Me.btnAddLine = New System.Windows.Forms.Button()
        Me.btnAddLoad = New System.Windows.Forms.Button()
        Me.btnAddCapacitor = New System.Windows.Forms.Button()
        Me.btnAddGenerator = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'listModels
        '
        Me.listModels.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.listModels.FullRowSelect = True
        Me.listModels.GridLines = True
        Me.listModels.HideSelection = False
        Me.listModels.Location = New System.Drawing.Point(12, 43)
        Me.listModels.Name = "listModels"
        Me.listModels.Size = New System.Drawing.Size(577, 366)
        Me.listModels.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.listModels.TabIndex = 3
        Me.listModels.UseCompatibleStateImageBehavior = False
        Me.listModels.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "#"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Category"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Title"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Description"
        Me.ColumnHeader3.Width = 200
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"All", "Loads", "Capacitor Banks", "Distributed Generators", "Transmission Lines", "Transformers"})
        Me.cmbType.Location = New System.Drawing.Point(456, 11)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(133, 21)
        Me.cmbType.TabIndex = 12
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(61, 11)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(308, 20)
        Me.txtSearch.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Search"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(375, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 13
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnAddTransformer
        '
        Me.btnAddTransformer.Location = New System.Drawing.Point(12, 418)
        Me.btnAddTransformer.Name = "btnAddTransformer"
        Me.btnAddTransformer.Size = New System.Drawing.Size(111, 23)
        Me.btnAddTransformer.TabIndex = 14
        Me.btnAddTransformer.Text = "Add Transformer"
        Me.btnAddTransformer.UseVisualStyleBackColor = True
        '
        'btnAddLine
        '
        Me.btnAddLine.Location = New System.Drawing.Point(129, 418)
        Me.btnAddLine.Name = "btnAddLine"
        Me.btnAddLine.Size = New System.Drawing.Size(75, 23)
        Me.btnAddLine.TabIndex = 15
        Me.btnAddLine.Text = "Add Line"
        Me.btnAddLine.UseVisualStyleBackColor = True
        '
        'btnAddLoad
        '
        Me.btnAddLoad.Location = New System.Drawing.Point(210, 418)
        Me.btnAddLoad.Name = "btnAddLoad"
        Me.btnAddLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnAddLoad.TabIndex = 16
        Me.btnAddLoad.Text = "Add Load"
        Me.btnAddLoad.UseVisualStyleBackColor = True
        '
        'btnAddCapacitor
        '
        Me.btnAddCapacitor.Location = New System.Drawing.Point(291, 418)
        Me.btnAddCapacitor.Name = "btnAddCapacitor"
        Me.btnAddCapacitor.Size = New System.Drawing.Size(101, 23)
        Me.btnAddCapacitor.TabIndex = 17
        Me.btnAddCapacitor.Text = "Add Capacitor"
        Me.btnAddCapacitor.UseVisualStyleBackColor = True
        '
        'btnAddGenerator
        '
        Me.btnAddGenerator.Location = New System.Drawing.Point(398, 418)
        Me.btnAddGenerator.Name = "btnAddGenerator"
        Me.btnAddGenerator.Size = New System.Drawing.Size(96, 23)
        Me.btnAddGenerator.TabIndex = 18
        Me.btnAddGenerator.Text = "Add Generator"
        Me.btnAddGenerator.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(515, 418)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.Text = "Remove"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 450)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddGenerator)
        Me.Controls.Add(Me.btnAddCapacitor)
        Me.Controls.Add(Me.btnAddLoad)
        Me.Controls.Add(Me.btnAddLine)
        Me.Controls.Add(Me.btnAddTransformer)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listModels)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmBrowser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Model Browser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents listModels As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnAddTransformer As Button
    Friend WithEvents btnAddLine As Button
    Friend WithEvents btnAddLoad As Button
    Friend WithEvents btnAddCapacitor As Button
    Friend WithEvents btnAddGenerator As Button
    Friend WithEvents btnDelete As Button
End Class
