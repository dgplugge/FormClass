<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEFL
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstRuns = New System.Windows.Forms.ComboBox
        Me.lstFiles = New System.Windows.Forms.ListBox
        Me.lstUsers = New System.Windows.Forms.ComboBox
        Me.cmdDownload = New System.Windows.Forms.Button
        Me.cmdDone = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.SPWorking = New Form_Class.SpinningProgress
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstRuns
        '
        Me.lstRuns.FormattingEnabled = True
        Me.lstRuns.Location = New System.Drawing.Point(12, 12)
        Me.lstRuns.Name = "lstRuns"
        Me.lstRuns.Size = New System.Drawing.Size(268, 21)
        Me.lstRuns.TabIndex = 0
        '
        'lstFiles
        '
        Me.lstFiles.FormattingEnabled = True
        Me.lstFiles.Location = New System.Drawing.Point(12, 53)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(268, 121)
        Me.lstFiles.TabIndex = 1
        '
        'lstUsers
        '
        Me.lstUsers.FormattingEnabled = True
        Me.lstUsers.Location = New System.Drawing.Point(77, 188)
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.Size = New System.Drawing.Size(121, 21)
        Me.lstUsers.TabIndex = 2
        '
        'cmdDownload
        '
        Me.cmdDownload.Location = New System.Drawing.Point(123, 215)
        Me.cmdDownload.Name = "cmdDownload"
        Me.cmdDownload.Size = New System.Drawing.Size(75, 23)
        Me.cmdDownload.TabIndex = 3
        Me.cmdDownload.Text = "Download"
        Me.cmdDownload.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Location = New System.Drawing.Point(205, 320)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(75, 23)
        Me.cmdDone.TabIndex = 4
        Me.cmdDone.Text = "Done"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select User"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 244)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 70)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(6, 19)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(256, 45)
        Me.txtStatus.TabIndex = 0
        '
        'SPWorking
        '
        Me.SPWorking.Location = New System.Drawing.Point(226, 191)
        Me.SPWorking.Name = "SPWorking"
        Me.SPWorking.Size = New System.Drawing.Size(30, 30)
        Me.SPWorking.TabIndex = 7
        Me.SPWorking.TransistionSegment = 10
        '
        'frmEFL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 347)
        Me.Controls.Add(Me.SPWorking)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdDone)
        Me.Controls.Add(Me.cmdDownload)
        Me.Controls.Add(Me.lstUsers)
        Me.Controls.Add(Me.lstFiles)
        Me.Controls.Add(Me.lstRuns)
        Me.Name = "frmEFL"
        Me.Text = "EIB Flow Lab Server"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstRuns As System.Windows.Forms.ComboBox
    Friend WithEvents lstFiles As System.Windows.Forms.ListBox
    Friend WithEvents lstUsers As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDownload As System.Windows.Forms.Button
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents SPWorking As Form_Class.SpinningProgress
End Class
