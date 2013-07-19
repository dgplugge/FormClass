<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServerData
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
        Me.lstRuns = New System.Windows.Forms.ComboBox()
        Me.ofdData = New System.Windows.Forms.OpenFileDialog()
        Me.cmdTable = New System.Windows.Forms.Button()
        Me.cmdReport = New System.Windows.Forms.Button()
        Me.cmdDownload = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fbdData = New System.Windows.Forms.FolderBrowserDialog()
        Me.lstRunNames = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lstDates = New System.Windows.Forms.ComboBox()
        Me.lstUsers = New System.Windows.Forms.ComboBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstRuns
        '
        Me.lstRuns.FormattingEnabled = True
        Me.lstRuns.Location = New System.Drawing.Point(10, 42)
        Me.lstRuns.Name = "lstRuns"
        Me.lstRuns.Size = New System.Drawing.Size(350, 21)
        Me.lstRuns.TabIndex = 25
        '
        'ofdData
        '
        Me.ofdData.FileName = "OpenFileDialog1"
        '
        'cmdTable
        '
        Me.cmdTable.Location = New System.Drawing.Point(285, 13)
        Me.cmdTable.Name = "cmdTable"
        Me.cmdTable.Size = New System.Drawing.Size(75, 23)
        Me.cmdTable.TabIndex = 23
        Me.cmdTable.Text = "Table"
        Me.cmdTable.UseVisualStyleBackColor = True
        '
        'cmdReport
        '
        Me.cmdReport.Location = New System.Drawing.Point(204, 13)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(75, 23)
        Me.cmdReport.TabIndex = 22
        Me.cmdReport.Text = "Report"
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'cmdDownload
        '
        Me.cmdDownload.Location = New System.Drawing.Point(285, 175)
        Me.cmdDownload.Name = "cmdDownload"
        Me.cmdDownload.Size = New System.Drawing.Size(75, 23)
        Me.cmdDownload.TabIndex = 21
        Me.cmdDownload.Text = "Download"
        Me.cmdDownload.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(11, 19)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(150, 98)
        Me.lblStatus.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(173, 129)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'lstRunNames
        '
        Me.lstRunNames.FormattingEnabled = True
        Me.lstRunNames.Location = New System.Drawing.Point(23, 19)
        Me.lstRunNames.Name = "lstRunNames"
        Me.lstRunNames.Size = New System.Drawing.Size(121, 21)
        Me.lstRunNames.TabIndex = 29
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstDates)
        Me.GroupBox3.Controls.Add(Me.lstRunNames)
        Me.GroupBox3.Location = New System.Drawing.Point(204, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(156, 100)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Locate"
        '
        'lstDates
        '
        Me.lstDates.FormattingEnabled = True
        Me.lstDates.Location = New System.Drawing.Point(23, 46)
        Me.lstDates.Name = "lstDates"
        Me.lstDates.Size = New System.Drawing.Size(121, 21)
        Me.lstDates.TabIndex = 30
        '
        'lstUsers
        '
        Me.lstUsers.FormattingEnabled = True
        Me.lstUsers.Location = New System.Drawing.Point(10, 13)
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.Size = New System.Drawing.Size(156, 21)
        Me.lstUsers.TabIndex = 32
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(204, 175)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 33
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmServerData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 210)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lstUsers)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lstRuns)
        Me.Controls.Add(Me.cmdTable)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdDownload)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmServerData"
        Me.Text = "Find FCS Data Run"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstRuns As System.Windows.Forms.ComboBox
    Friend WithEvents ofdData As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdTable As System.Windows.Forms.Button
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents cmdDownload As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents fbdData As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lstRunNames As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstDates As System.Windows.Forms.ComboBox
    Friend WithEvents lstUsers As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
