<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindData

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
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.lstRuns = New System.Windows.Forms.ComboBox()
        Me.cmdRename = New System.Windows.Forms.Button()
        Me.ofdData = New System.Windows.Forms.OpenFileDialog()
        Me.cmdTable = New System.Windows.Forms.Button()
        Me.cmdReport = New System.Windows.Forms.Button()
        Me.cmdDone = New System.Windows.Forms.Button()
        Me.cmdEIBServer = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.fbdData = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdVMS = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.flgUser = New System.Windows.Forms.RadioButton()
        Me.flgRecent = New System.Windows.Forms.RadioButton()
        Me.flgDate = New System.Windows.Forms.RadioButton()
        Me.flgRun = New System.Windows.Forms.RadioButton()
        Me.flgMachine = New System.Windows.Forms.RadioButton()
        Me.lstRunNames = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lstDates = New System.Windows.Forms.ComboBox()
        Me.cmdDerived = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(130, 279)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemove.TabIndex = 27
        Me.cmdRemove.Text = "Archive"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'lstRuns
        '
        Me.lstRuns.FormattingEnabled = True
        Me.lstRuns.Location = New System.Drawing.Point(17, 175)
        Me.lstRuns.Name = "lstRuns"
        Me.lstRuns.Size = New System.Drawing.Size(350, 21)
        Me.lstRuns.TabIndex = 25
        '
        'cmdRename
        '
        Me.cmdRename.Location = New System.Drawing.Point(17, 146)
        Me.cmdRename.Name = "cmdRename"
        Me.cmdRename.Size = New System.Drawing.Size(106, 23)
        Me.cmdRename.TabIndex = 24
        Me.cmdRename.Text = "Rename Files"
        Me.cmdRename.UseVisualStyleBackColor = True
        '
        'ofdData
        '
        Me.ofdData.FileName = "OpenFileDialog1"
        '
        'cmdTable
        '
        Me.cmdTable.Location = New System.Drawing.Point(211, 146)
        Me.cmdTable.Name = "cmdTable"
        Me.cmdTable.Size = New System.Drawing.Size(75, 23)
        Me.cmdTable.TabIndex = 23
        Me.cmdTable.Text = "Table"
        Me.cmdTable.UseVisualStyleBackColor = True
        '
        'cmdReport
        '
        Me.cmdReport.Location = New System.Drawing.Point(130, 146)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(75, 23)
        Me.cmdReport.TabIndex = 22
        Me.cmdReport.Text = "Report"
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Location = New System.Drawing.Point(292, 308)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(75, 23)
        Me.cmdDone.TabIndex = 21
        Me.cmdDone.Text = "Select"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'cmdEIBServer
        '
        Me.cmdEIBServer.Location = New System.Drawing.Point(10, 41)
        Me.cmdEIBServer.Name = "cmdEIBServer"
        Me.cmdEIBServer.Size = New System.Drawing.Size(103, 23)
        Me.cmdEIBServer.TabIndex = 17
        Me.cmdEIBServer.Text = "EIB Flow Server"
        Me.cmdEIBServer.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(11, 19)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(223, 79)
        Me.lblStatus.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblStatus)
        Me.GroupBox1.Location = New System.Drawing.Point(133, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 110)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(10, 70)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(103, 23)
        Me.cmdBrowse.TabIndex = 18
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'cmdVMS
        '
        Me.cmdVMS.Location = New System.Drawing.Point(10, 12)
        Me.cmdVMS.Name = "cmdVMS"
        Me.cmdVMS.Size = New System.Drawing.Size(103, 23)
        Me.cmdVMS.TabIndex = 16
        Me.cmdVMS.Text = "Pre-2010 Server"
        Me.cmdVMS.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.flgUser)
        Me.GroupBox2.Controls.Add(Me.flgRecent)
        Me.GroupBox2.Controls.Add(Me.flgDate)
        Me.GroupBox2.Controls.Add(Me.flgRun)
        Me.GroupBox2.Controls.Add(Me.flgMachine)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 202)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(186, 70)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sort By"
        '
        'flgUser
        '
        Me.flgUser.AutoSize = True
        Me.flgUser.Location = New System.Drawing.Point(6, 19)
        Me.flgUser.Name = "flgUser"
        Me.flgUser.Size = New System.Drawing.Size(47, 17)
        Me.flgUser.TabIndex = 0
        Me.flgUser.TabStop = True
        Me.flgUser.Text = "User"
        Me.flgUser.UseVisualStyleBackColor = True
        '
        'flgRecent
        '
        Me.flgRecent.AutoSize = True
        Me.flgRecent.Location = New System.Drawing.Point(113, 19)
        Me.flgRecent.Name = "flgRecent"
        Me.flgRecent.Size = New System.Drawing.Size(60, 17)
        Me.flgRecent.TabIndex = 7
        Me.flgRecent.TabStop = True
        Me.flgRecent.Text = "Recent"
        Me.flgRecent.UseVisualStyleBackColor = True
        '
        'flgDate
        '
        Me.flgDate.AutoSize = True
        Me.flgDate.Location = New System.Drawing.Point(59, 19)
        Me.flgDate.Name = "flgDate"
        Me.flgDate.Size = New System.Drawing.Size(48, 17)
        Me.flgDate.TabIndex = 2
        Me.flgDate.TabStop = True
        Me.flgDate.Text = "Date"
        Me.flgDate.UseVisualStyleBackColor = True
        '
        'flgRun
        '
        Me.flgRun.AutoSize = True
        Me.flgRun.Location = New System.Drawing.Point(6, 42)
        Me.flgRun.Name = "flgRun"
        Me.flgRun.Size = New System.Drawing.Size(45, 17)
        Me.flgRun.TabIndex = 1
        Me.flgRun.TabStop = True
        Me.flgRun.Text = "Run"
        Me.flgRun.UseVisualStyleBackColor = True
        '
        'flgMachine
        '
        Me.flgMachine.AutoSize = True
        Me.flgMachine.Location = New System.Drawing.Point(59, 42)
        Me.flgMachine.Name = "flgMachine"
        Me.flgMachine.Size = New System.Drawing.Size(66, 17)
        Me.flgMachine.TabIndex = 5
        Me.flgMachine.TabStop = True
        Me.flgMachine.Text = "Machine"
        Me.flgMachine.UseVisualStyleBackColor = True
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
        Me.GroupBox3.Location = New System.Drawing.Point(211, 202)
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
        'cmdDerived
        '
        Me.cmdDerived.Location = New System.Drawing.Point(45, 279)
        Me.cmdDerived.Name = "cmdDerived"
        Me.cmdDerived.Size = New System.Drawing.Size(75, 23)
        Me.cmdDerived.TabIndex = 31
        Me.cmdDerived.Text = "Derived FCS"
        Me.cmdDerived.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(10, 128)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(367, 213)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Local Data"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(292, 347)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 33
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmFindData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 376)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdDerived)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.lstRuns)
        Me.Controls.Add(Me.cmdRename)
        Me.Controls.Add(Me.cmdTable)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.cmdDone)
        Me.Controls.Add(Me.cmdEIBServer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.cmdVMS)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "frmFindData"
        Me.Text = "Find FCS Data Run"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents lstRuns As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRename As System.Windows.Forms.Button
    Friend WithEvents ofdData As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdTable As System.Windows.Forms.Button
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents cmdEIBServer As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents fbdData As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmdVMS As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents flgUser As System.Windows.Forms.RadioButton
    Friend WithEvents flgRecent As System.Windows.Forms.RadioButton
    Friend WithEvents flgDate As System.Windows.Forms.RadioButton
    Friend WithEvents flgRun As System.Windows.Forms.RadioButton
    Friend WithEvents flgMachine As System.Windows.Forms.RadioButton
    Friend WithEvents lstRunNames As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstDates As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDerived As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
