<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRuns
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
        Me.cmdSel = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdDone = New System.Windows.Forms.Button
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
        Me.lstFiles.Location = New System.Drawing.Point(12, 49)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.Size = New System.Drawing.Size(268, 147)
        Me.lstFiles.TabIndex = 1
        '
        'cmdSel
        '
        Me.cmdSel.Location = New System.Drawing.Point(12, 213)
        Me.cmdSel.Name = "cmdSel"
        Me.cmdSel.Size = New System.Drawing.Size(97, 23)
        Me.cmdSel.TabIndex = 2
        Me.cmdSel.Text = "Select Run"
        Me.cmdSel.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(183, 213)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(97, 23)
        Me.cmdDelete.TabIndex = 3
        Me.cmdDelete.Text = "Delete Run"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Location = New System.Drawing.Point(183, 242)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(97, 23)
        Me.cmdDone.TabIndex = 4
        Me.cmdDone.Text = "Done"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'frmRuns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.cmdDone)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSel)
        Me.Controls.Add(Me.lstFiles)
        Me.Controls.Add(Me.lstRuns)
        Me.Name = "frmRuns"
        Me.Text = "      "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstRuns As System.Windows.Forms.ComboBox
    Friend WithEvents lstFiles As System.Windows.Forms.ListBox
    Friend WithEvents cmdSel As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdDone As System.Windows.Forms.Button
End Class
