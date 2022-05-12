<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddShuntCapacitor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddShuntCapacitor))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVoltageC_I = New System.Windows.Forms.TextBox()
        Me.txtVoltageB_I = New System.Windows.Forms.TextBox()
        Me.txtVoltageA_I = New System.Windows.Forms.TextBox()
        Me.cmbConnection = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVoltageC_R = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVoltageB_R = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnLibrary = New System.Windows.Forms.Button()
        Me.txtVoltageA_R = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPowerC_I = New System.Windows.Forms.TextBox()
        Me.txtPowerB_I = New System.Windows.Forms.TextBox()
        Me.txtPowerA_I = New System.Windows.Forms.TextBox()
        Me.txtPowerC_R = New System.Windows.Forms.TextBox()
        Me.txtPowerB_R = New System.Windows.Forms.TextBox()
        Me.txtPowerA_R = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btnAddToLibrary = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(238, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "+"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(238, 118)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 13)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "+"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(238, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(13, 13)
        Me.Label11.TabIndex = 85
        Me.Label11.Text = "+"
        '
        'txtVoltageC_I
        '
        Me.txtVoltageC_I.Location = New System.Drawing.Point(256, 166)
        Me.txtVoltageC_I.Name = "txtVoltageC_I"
        Me.txtVoltageC_I.Size = New System.Drawing.Size(86, 20)
        Me.txtVoltageC_I.TabIndex = 84
        '
        'txtVoltageB_I
        '
        Me.txtVoltageB_I.Location = New System.Drawing.Point(256, 141)
        Me.txtVoltageB_I.Name = "txtVoltageB_I"
        Me.txtVoltageB_I.Size = New System.Drawing.Size(86, 20)
        Me.txtVoltageB_I.TabIndex = 83
        '
        'txtVoltageA_I
        '
        Me.txtVoltageA_I.Location = New System.Drawing.Point(256, 116)
        Me.txtVoltageA_I.Name = "txtVoltageA_I"
        Me.txtVoltageA_I.Size = New System.Drawing.Size(86, 20)
        Me.txtVoltageA_I.TabIndex = 82
        '
        'cmbConnection
        '
        Me.cmbConnection.FormattingEnabled = True
        Me.cmbConnection.Items.AddRange(New Object() {"Star", "Delta"})
        Me.cmbConnection.Location = New System.Drawing.Point(148, 266)
        Me.cmbConnection.Name = "cmbConnection"
        Me.cmbConnection.Size = New System.Drawing.Size(86, 21)
        Me.cmbConnection.TabIndex = 81
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 269)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 80
        Me.Label14.Text = "Connection"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(347, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "j    kV"
        '
        'txtVoltageC_R
        '
        Me.txtVoltageC_R.Location = New System.Drawing.Point(148, 166)
        Me.txtVoltageC_R.Name = "txtVoltageC_R"
        Me.txtVoltageC_R.Size = New System.Drawing.Size(86, 20)
        Me.txtVoltageC_R.TabIndex = 78
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Voltage - Phase C"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(347, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "j    kV"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(347, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "j    kV"
        '
        'txtVoltageB_R
        '
        Me.txtVoltageB_R.Location = New System.Drawing.Point(148, 141)
        Me.txtVoltageB_R.Name = "txtVoltageB_R"
        Me.txtVoltageB_R.Size = New System.Drawing.Size(86, 20)
        Me.txtVoltageB_R.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Voltage - Phase B"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(306, 303)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 23)
        Me.btnAdd.TabIndex = 72
        Me.btnAdd.Text = "Save"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnLibrary
        '
        Me.btnLibrary.Location = New System.Drawing.Point(15, 303)
        Me.btnLibrary.Name = "btnLibrary"
        Me.btnLibrary.Size = New System.Drawing.Size(86, 23)
        Me.btnLibrary.TabIndex = 71
        Me.btnLibrary.Text = "Browse Library"
        Me.btnLibrary.UseVisualStyleBackColor = True
        '
        'txtVoltageA_R
        '
        Me.txtVoltageA_R.Location = New System.Drawing.Point(148, 116)
        Me.txtVoltageA_R.Name = "txtVoltageA_R"
        Me.txtVoltageA_R.Size = New System.Drawing.Size(86, 20)
        Me.txtVoltageA_R.TabIndex = 70
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Voltage - Phase A"
        '
        'txtNode
        '
        Me.txtNode.Location = New System.Drawing.Point(148, 90)
        Me.txtNode.Name = "txtNode"
        Me.txtNode.Size = New System.Drawing.Size(86, 20)
        Me.txtNode.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Connected Node"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(347, 244)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 96
        Me.Label15.Text = "j    kVar"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 244)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(132, 13)
        Me.Label16.TabIndex = 94
        Me.Label16.Text = "Reactive Power - Phase C"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(347, 194)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 93
        Me.Label17.Text = "j    kVar"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(347, 219)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 92
        Me.Label18.Text = "j    kVar"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 219)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(132, 13)
        Me.Label19.TabIndex = 90
        Me.Label19.Text = "Reactive Power - Phase B"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 194)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(132, 13)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "Reactive Power - Phase A"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(238, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 13)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "+"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(238, 194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 13)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "+"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(238, 219)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 103
        Me.Label13.Text = "+"
        '
        'txtPowerC_I
        '
        Me.txtPowerC_I.Location = New System.Drawing.Point(256, 241)
        Me.txtPowerC_I.Name = "txtPowerC_I"
        Me.txtPowerC_I.Size = New System.Drawing.Size(86, 20)
        Me.txtPowerC_I.TabIndex = 102
        '
        'txtPowerB_I
        '
        Me.txtPowerB_I.Location = New System.Drawing.Point(256, 216)
        Me.txtPowerB_I.Name = "txtPowerB_I"
        Me.txtPowerB_I.Size = New System.Drawing.Size(86, 20)
        Me.txtPowerB_I.TabIndex = 101
        '
        'txtPowerA_I
        '
        Me.txtPowerA_I.Location = New System.Drawing.Point(256, 191)
        Me.txtPowerA_I.Name = "txtPowerA_I"
        Me.txtPowerA_I.Size = New System.Drawing.Size(86, 20)
        Me.txtPowerA_I.TabIndex = 100
        '
        'txtPowerC_R
        '
        Me.txtPowerC_R.Location = New System.Drawing.Point(148, 241)
        Me.txtPowerC_R.Name = "txtPowerC_R"
        Me.txtPowerC_R.Size = New System.Drawing.Size(86, 20)
        Me.txtPowerC_R.TabIndex = 99
        '
        'txtPowerB_R
        '
        Me.txtPowerB_R.Location = New System.Drawing.Point(148, 216)
        Me.txtPowerB_R.Name = "txtPowerB_R"
        Me.txtPowerB_R.Size = New System.Drawing.Size(86, 20)
        Me.txtPowerB_R.TabIndex = 98
        '
        'txtPowerA_R
        '
        Me.txtPowerA_R.Location = New System.Drawing.Point(148, 191)
        Me.txtPowerA_R.Name = "txtPowerA_R"
        Me.txtPowerA_R.Size = New System.Drawing.Size(86, 20)
        Me.txtPowerA_R.TabIndex = 97
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label31.Location = New System.Drawing.Point(12, 68)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(71, 15)
        Me.Label31.TabIndex = 110
        Me.Label31.Text = "Parameters"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(147, 39)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(233, 20)
        Me.txtDescription.TabIndex = 109
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(12, 41)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(60, 13)
        Me.Label29.TabIndex = 108
        Me.Label29.Text = "Description"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(147, 13)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(233, 20)
        Me.txtTitle.TabIndex = 107
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(12, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(27, 13)
        Me.Label30.TabIndex = 106
        Me.Label30.Text = "Title"
        '
        'btnAddToLibrary
        '
        Me.btnAddToLibrary.Location = New System.Drawing.Point(107, 303)
        Me.btnAddToLibrary.Name = "btnAddToLibrary"
        Me.btnAddToLibrary.Size = New System.Drawing.Size(104, 23)
        Me.btnAddToLibrary.TabIndex = 111
        Me.btnAddToLibrary.Text = "Add To Library"
        Me.btnAddToLibrary.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Image = CType(resources.GetObject("btnHelp.Image"), System.Drawing.Image)
        Me.btnHelp.Location = New System.Drawing.Point(277, 303)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(23, 23)
        Me.btnHelp.TabIndex = 112
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmAddShuntCapacitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 339)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnAddToLibrary)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtPowerC_I)
        Me.Controls.Add(Me.txtPowerB_I)
        Me.Controls.Add(Me.txtPowerA_I)
        Me.Controls.Add(Me.txtPowerC_R)
        Me.Controls.Add(Me.txtPowerB_R)
        Me.Controls.Add(Me.txtPowerA_R)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtVoltageC_I)
        Me.Controls.Add(Me.txtVoltageB_I)
        Me.Controls.Add(Me.txtVoltageA_I)
        Me.Controls.Add(Me.cmbConnection)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtVoltageC_R)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtVoltageB_R)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnLibrary)
        Me.Controls.Add(Me.txtVoltageA_R)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNode)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddShuntCapacitor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shunt Capacitor Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtVoltageC_I As TextBox
    Friend WithEvents txtVoltageB_I As TextBox
    Friend WithEvents txtVoltageA_I As TextBox
    Friend WithEvents cmbConnection As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVoltageC_R As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtVoltageB_R As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnLibrary As Button
    Friend WithEvents txtVoltageA_R As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtPowerC_I As TextBox
    Friend WithEvents txtPowerB_I As TextBox
    Friend WithEvents txtPowerA_I As TextBox
    Friend WithEvents txtPowerC_R As TextBox
    Friend WithEvents txtPowerB_R As TextBox
    Friend WithEvents txtPowerA_R As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents btnAddToLibrary As Button
    Friend WithEvents btnHelp As Button
End Class
