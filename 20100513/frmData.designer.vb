<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmData
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
        Me.cmdVMS = New System.Windows.Forms.Button
        Me.cmdEIBServer = New System.Windows.Forms.Button
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cmdWS = New System.Windows.Forms.Button
        Me.fbdData = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.cmdDone = New System.Windows.Forms.Button
        Me.cmdReport = New System.Windows.Forms.Button
        Me.cmdTable = New System.Windows.Forms.Button
        Me.cmdRename = New System.Windows.Forms.Button
        Me.lstRuns = New System.Windows.Forms.ComboBox
        Me.ofdData = New System.Windows.Forms.OpenFileDialog
        Me.cmdSort = New System.Windows.Forms.Button
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdVMS
        '
        Me.cmdVMS.Location = New System.Drawing.Point(12, 21)
        Me.cmdVMS.Name = "cmdVMS"
        Me.cmdVMS.Size = New System.Drawing.Size(103, 23)
        Me.cmdVMS.TabIndex = 0
        Me.cmdVMS.Text = "Vantage Server"
        Me.cmdVMS.UseVisualStyleBackColor = True
        '
        'cmdEIBServer
        '
        Me.cmdEIBServer.Location = New System.Drawing.Point(12, 50)
        Me.cmdEIBServer.Name = "cmdEIBServer"
        Me.cmdEIBServer.Size = New System.Drawing.Size(103, 23)
        Me.cmdEIBServer.TabIndex = 1
        Me.cmdEIBServer.Text = "Aria Server"
        Me.cmdEIBServer.UseVisualStyleBackColor = True
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(12, 79)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(103, 23)
        Me.cmdBrowse.TabIndex = 2
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'cmdWS
        '
        Me.cmdWS.Location = New System.Drawing.Point(12, 108)
        Me.cmdWS.Name = "cmdWS"
        Me.cmdWS.Size = New System.Drawing.Size(103, 23)
        Me.cmdWS.TabIndex = 3
        Me.cmdWS.Text = "Working Set"
        Me.cmdWS.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(135, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 110)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(11, 19)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(123, 79)
        Me.lblStatus.TabIndex = 0
        '
        'cmdDone
        '
        Me.cmdDone.Location = New System.Drawing.Point(206, 223)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(75, 23)
        Me.cmdDone.TabIndex = 5
        Me.cmdDone.Text = "Done"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'cmdReport
        '
        Me.cmdReport.Location = New System.Drawing.Point(125, 162)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(75, 23)
        Me.cmdReport.TabIndex = 8
        Me.cmdReport.Text = "Report"
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'cmdTable
        '
        Me.cmdTable.Location = New System.Drawing.Point(206, 162)
        Me.cmdTable.Name = "cmdTable"
        Me.cmdTable.Size = New System.Drawing.Size(75, 23)
        Me.cmdTable.TabIndex = 9
        Me.cmdTable.Text = "Table"
        Me.cmdTable.UseVisualStyleBackColor = True
        '
        'cmdRename
        '
        Me.cmdRename.Location = New System.Drawing.Point(9, 162)
        Me.cmdRename.Name = "cmdRename"
        Me.cmdRename.Size = New System.Drawing.Size(106, 23)
        Me.cmdRename.TabIndex = 12
        Me.cmdRename.Text = "Rename Files"
        Me.cmdRename.UseVisualStyleBackColor = True
        '
        'lstRuns
        '
        Me.lstRuns.FormattingEnabled = True
        Me.lstRuns.Location = New System.Drawing.Point(9, 191)
        Me.lstRuns.Name = "lstRuns"
        Me.lstRuns.Size = New System.Drawing.Size(272, 21)
        Me.lstRuns.TabIndex = 13
        '
        'ofdData
        '
        Me.ofdData.FileName = "OpenFileDialog1"
        '
        'cmdSort
        '
        Me.cmdSort.Location = New System.Drawing.Point(12, 223)
        Me.cmdSort.Name = "cmdSort"
        Me.cmdSort.Size = New System.Drawing.Size(75, 23)
        Me.cmdSort.TabIndex = 14
        Me.cmdSort.Text = "Sort"
        Me.cmdSort.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(93, 223)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemove.TabIndex = 15
        Me.cmdRemove.Text = "Archive"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'frmData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 258)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdSort)
        Me.Controls.Add(Me.lstRuns)
        Me.Controls.Add(Me.cmdRename)
        Me.Controls.Add(Me.cmdTable)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdDone)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdWS)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.cmdEIBServer)
        Me.Controls.Add(Me.cmdVMS)
        Me.Name = "frmData"
        Me.Text = "Data Download"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdVMS As System.Windows.Forms.Button
    Friend WithEvents cmdEIBServer As System.Windows.Forms.Button
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents cmdWS As System.Windows.Forms.Button
    Friend WithEvents fbdData As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents cmdTable As System.Windows.Forms.Button
    Friend WithEvents cmdRename As System.Windows.Forms.Button
    Friend WithEvents lstRuns As System.Windows.Forms.ComboBox
    Friend WithEvents ofdData As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdSort As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
End Class
