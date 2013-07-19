<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.cmdColors = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdScan = New System.Windows.Forms.Button()
        Me.lstServerVers = New System.Windows.Forms.ComboBox()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.lblLocalRoot = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdCurrent = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmdUninstall = New System.Windows.Forms.Button()
        Me.lblCurVer = New System.Windows.Forms.Label()
        Me.lstLocalVers = New System.Windows.Forms.ComboBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdLicense = New System.Windows.Forms.Button()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdColors
        '
        Me.cmdColors.Location = New System.Drawing.Point(117, 19)
        Me.cmdColors.Name = "cmdColors"
        Me.cmdColors.Size = New System.Drawing.Size(75, 23)
        Me.cmdColors.TabIndex = 0
        Me.cmdColors.Text = "Colors"
        Me.cmdColors.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.lblLocalRoot)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 204)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Version"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdScan)
        Me.GroupBox3.Controls.Add(Me.lstServerVers)
        Me.GroupBox3.Controls.Add(Me.cmdUpdate)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 118)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(271, 78)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Available Downloads"
        '
        'cmdScan
        '
        Me.cmdScan.Location = New System.Drawing.Point(149, 46)
        Me.cmdScan.Name = "cmdScan"
        Me.cmdScan.Size = New System.Drawing.Size(116, 24)
        Me.cmdScan.TabIndex = 1
        Me.cmdScan.Text = "Scan Server"
        Me.cmdScan.UseVisualStyleBackColor = True
        '
        'lstServerVers
        '
        Me.lstServerVers.FormattingEnabled = True
        Me.lstServerVers.Location = New System.Drawing.Point(149, 19)
        Me.lstServerVers.Name = "lstServerVers"
        Me.lstServerVers.Size = New System.Drawing.Size(116, 21)
        Me.lstServerVers.TabIndex = 0
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(6, 19)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(123, 24)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = "Install"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'lblLocalRoot
        '
        Me.lblLocalRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocalRoot.Location = New System.Drawing.Point(22, 31)
        Me.lblLocalRoot.Name = "lblLocalRoot"
        Me.lblLocalRoot.Size = New System.Drawing.Size(248, 17)
        Me.lblLocalRoot.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdCurrent)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.cmdUninstall)
        Me.GroupBox2.Controls.Add(Me.lblCurVer)
        Me.GroupBox2.Controls.Add(Me.lstLocalVers)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 96)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Installed Versions"
        '
        'cmdCurrent
        '
        Me.cmdCurrent.Location = New System.Drawing.Point(10, 39)
        Me.cmdCurrent.Name = "cmdCurrent"
        Me.cmdCurrent.Size = New System.Drawing.Size(75, 23)
        Me.cmdCurrent.TabIndex = 16
        Me.cmdCurrent.Text = "Current"
        Me.cmdCurrent.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(10, 70)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Test Version"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdUninstall
        '
        Me.cmdUninstall.Location = New System.Drawing.Point(149, 68)
        Me.cmdUninstall.Name = "cmdUninstall"
        Me.cmdUninstall.Size = New System.Drawing.Size(109, 19)
        Me.cmdUninstall.TabIndex = 2
        Me.cmdUninstall.Text = "Uninstall"
        Me.cmdUninstall.UseVisualStyleBackColor = True
        '
        'lblCurVer
        '
        Me.lblCurVer.AutoSize = True
        Me.lblCurVer.Location = New System.Drawing.Point(102, 49)
        Me.lblCurVer.Name = "lblCurVer"
        Me.lblCurVer.Size = New System.Drawing.Size(41, 13)
        Me.lblCurVer.TabIndex = 1
        Me.lblCurVer.Text = "Current"
        '
        'lstLocalVers
        '
        Me.lstLocalVers.FormattingEnabled = True
        Me.lstLocalVers.Location = New System.Drawing.Point(149, 41)
        Me.lstLocalVers.Name = "lstLocalVers"
        Me.lstLocalVers.Size = New System.Drawing.Size(109, 21)
        Me.lstLocalVers.TabIndex = 0
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(220, 299)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 13
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdExport)
        Me.GroupBox4.Controls.Add(Me.cmdColors)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 222)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Customize"
        '
        'cmdLicense
        '
        Me.cmdLicense.Location = New System.Drawing.Point(220, 241)
        Me.cmdLicense.Name = "cmdLicense"
        Me.cmdLicense.Size = New System.Drawing.Size(75, 23)
        Me.cmdLicense.TabIndex = 1
        Me.cmdLicense.Text = "License"
        Me.cmdLicense.UseVisualStyleBackColor = True
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(117, 48)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(75, 23)
        Me.cmdExport.TabIndex = 1
        Me.cmdExport.Text = "Export"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 332)
        Me.Controls.Add(Me.cmdLicense)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdColors As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdScan As System.Windows.Forms.Button
    Friend WithEvents lstServerVers As System.Windows.Forms.ComboBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents lblLocalRoot As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUninstall As System.Windows.Forms.Button
    Friend WithEvents lblCurVer As System.Windows.Forms.Label
    Friend WithEvents lstLocalVers As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdLicense As System.Windows.Forms.Button
    Friend WithEvents cmdCurrent As System.Windows.Forms.Button
    Friend WithEvents cmdExport As System.Windows.Forms.Button
End Class
