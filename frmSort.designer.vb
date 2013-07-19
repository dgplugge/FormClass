<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSort
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
        Me.flgUser = New System.Windows.Forms.RadioButton()
        Me.flgRun = New System.Windows.Forms.RadioButton()
        Me.flgDate = New System.Windows.Forms.RadioButton()
        Me.cmdReload = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.flgMachine = New System.Windows.Forms.RadioButton()
        Me.lstRuns = New System.Windows.Forms.ComboBox()
        Me.flgRecent = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        'cmdReload
        '
        Me.cmdReload.Location = New System.Drawing.Point(12, 115)
        Me.cmdReload.Name = "cmdReload"
        Me.cmdReload.Size = New System.Drawing.Size(75, 23)
        Me.cmdReload.TabIndex = 3
        Me.cmdReload.Text = "Reload Data"
        Me.cmdReload.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(308, 115)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
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
        'lstRuns
        '
        Me.lstRuns.FormattingEnabled = True
        Me.lstRuns.Location = New System.Drawing.Point(12, 88)
        Me.lstRuns.Name = "lstRuns"
        Me.lstRuns.Size = New System.Drawing.Size(371, 21)
        Me.lstRuns.TabIndex = 6
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.flgUser)
        Me.GroupBox1.Controls.Add(Me.flgRecent)
        Me.GroupBox1.Controls.Add(Me.flgDate)
        Me.GroupBox1.Controls.Add(Me.flgRun)
        Me.GroupBox1.Controls.Add(Me.flgMachine)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 70)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sort By"
        '
        'cmdSelect
        '
        Me.cmdSelect.Location = New System.Drawing.Point(227, 115)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelect.TabIndex = 9
        Me.cmdSelect.Text = "Select"
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'frmSort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 145)
        Me.Controls.Add(Me.cmdSelect)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstRuns)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdReload)
        Me.Name = "frmSort"
        Me.Text = "Sort Data"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flgUser As System.Windows.Forms.RadioButton
    Friend WithEvents flgRun As System.Windows.Forms.RadioButton
    Friend WithEvents flgDate As System.Windows.Forms.RadioButton
    Friend WithEvents cmdReload As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents flgMachine As System.Windows.Forms.RadioButton
    Friend WithEvents lstRuns As System.Windows.Forms.ComboBox
    Friend WithEvents flgRecent As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelect As System.Windows.Forms.Button
End Class
