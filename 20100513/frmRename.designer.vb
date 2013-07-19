<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRename
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.togOrder = New System.Windows.Forms.RadioButton()
        Me.togSample = New System.Windows.Forms.RadioButton()
        Me.lstOrig = New System.Windows.Forms.ListBox()
        Me.lstNew = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.togDate_mdy = New System.Windows.Forms.RadioButton()
        Me.togDate_ymd = New System.Windows.Forms.RadioButton()
        Me.cmdDone = New System.Windows.Forms.Button()
        Me.cmdRename = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.flgCache = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.togOrder)
        Me.GroupBox1.Controls.Add(Me.togSample)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 82)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sequence"
        '
        'togOrder
        '
        Me.togOrder.AutoSize = True
        Me.togOrder.Location = New System.Drawing.Point(6, 42)
        Me.togOrder.Name = "togOrder"
        Me.togOrder.Size = New System.Drawing.Size(70, 17)
        Me.togOrder.TabIndex = 5
        Me.togOrder.TabStop = True
        Me.togOrder.Text = "File Order"
        Me.togOrder.UseVisualStyleBackColor = True
        '
        'togSample
        '
        Me.togSample.AutoSize = True
        Me.togSample.Location = New System.Drawing.Point(6, 19)
        Me.togSample.Name = "togSample"
        Me.togSample.Size = New System.Drawing.Size(80, 17)
        Me.togSample.TabIndex = 4
        Me.togSample.TabStop = True
        Me.togSample.Text = "Sample No."
        Me.togSample.UseVisualStyleBackColor = True
        '
        'lstOrig
        '
        Me.lstOrig.FormattingEnabled = True
        Me.lstOrig.Location = New System.Drawing.Point(12, 39)
        Me.lstOrig.Name = "lstOrig"
        Me.lstOrig.Size = New System.Drawing.Size(190, 290)
        Me.lstOrig.TabIndex = 2
        '
        'lstNew
        '
        Me.lstNew.FormattingEnabled = True
        Me.lstNew.Location = New System.Drawing.Point(352, 39)
        Me.lstNew.Name = "lstNew"
        Me.lstNew.Size = New System.Drawing.Size(190, 290)
        Me.lstNew.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.flgCache)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.cmdDone)
        Me.GroupBox2.Controls.Add(Me.cmdRename)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(220, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(115, 290)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controls"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.togDate_mdy)
        Me.GroupBox3.Controls.Add(Me.togDate_ymd)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(103, 78)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Prefix"
        '
        'togDate_mdy
        '
        Me.togDate_mdy.AutoSize = True
        Me.togDate_mdy.Location = New System.Drawing.Point(6, 42)
        Me.togDate_mdy.Name = "togDate_mdy"
        Me.togDate_mdy.Size = New System.Drawing.Size(95, 17)
        Me.togDate_mdy.TabIndex = 1
        Me.togDate_mdy.TabStop = True
        Me.togDate_mdy.Text = "Date (mmddyy)"
        Me.togDate_mdy.UseVisualStyleBackColor = True
        '
        'togDate_ymd
        '
        Me.togDate_ymd.AutoSize = True
        Me.togDate_ymd.Location = New System.Drawing.Point(6, 19)
        Me.togDate_ymd.Name = "togDate_ymd"
        Me.togDate_ymd.Size = New System.Drawing.Size(95, 17)
        Me.togDate_ymd.TabIndex = 0
        Me.togDate_ymd.TabStop = True
        Me.togDate_ymd.Text = "Date (yymmdd)"
        Me.togDate_ymd.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Location = New System.Drawing.Point(6, 260)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(103, 23)
        Me.cmdDone.TabIndex = 6
        Me.cmdDone.Text = "Done"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'cmdRename
        '
        Me.cmdRename.Location = New System.Drawing.Point(6, 231)
        Me.cmdRename.Name = "cmdRename"
        Me.cmdRename.Size = New System.Drawing.Size(103, 23)
        Me.cmdRename.TabIndex = 5
        Me.cmdRename.Text = "Rename"
        Me.cmdRename.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtStatus)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 335)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(530, 78)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(6, 15)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatus.Size = New System.Drawing.Size(518, 57)
        Me.txtStatus.TabIndex = 5
        '
        'flgCache
        '
        Me.flgCache.AutoSize = True
        Me.flgCache.Location = New System.Drawing.Point(6, 191)
        Me.flgCache.Name = "flgCache"
        Me.flgCache.Size = New System.Drawing.Size(57, 17)
        Me.flgCache.TabIndex = 8
        Me.flgCache.Text = "Cache"
        Me.flgCache.UseVisualStyleBackColor = True
        '
        'frmRename
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 418)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lstNew)
        Me.Controls.Add(Me.lstOrig)
        Me.Name = "frmRename"
        Me.Text = "Rename FCS files"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents togSample As System.Windows.Forms.RadioButton
    Friend WithEvents lstOrig As System.Windows.Forms.ListBox
    Friend WithEvents lstNew As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents cmdRename As System.Windows.Forms.Button
    Friend WithEvents togOrder As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents togDate_ymd As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents togDate_mdy As System.Windows.Forms.RadioButton
    Friend WithEvents flgCache As System.Windows.Forms.CheckBox
End Class
