<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.lstKeys = New System.Windows.Forms.ComboBox
        Me.cmdInsert = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdDone = New System.Windows.Forms.Button
        Me.lstRuns = New System.Windows.Forms.ComboBox
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToOrderColumns = True
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(12, 96)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.Size = New System.Drawing.Size(351, 150)
        Me.dgvReport.TabIndex = 0
        '
        'lstKeys
        '
        Me.lstKeys.FormattingEnabled = True
        Me.lstKeys.Location = New System.Drawing.Point(12, 43)
        Me.lstKeys.Name = "lstKeys"
        Me.lstKeys.Size = New System.Drawing.Size(121, 21)
        Me.lstKeys.TabIndex = 1
        '
        'cmdInsert
        '
        Me.cmdInsert.Location = New System.Drawing.Point(12, 12)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.Size = New System.Drawing.Size(60, 23)
        Me.cmdInsert.TabIndex = 2
        Me.cmdInsert.Text = "Insert"
        Me.cmdInsert.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(73, 12)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(60, 23)
        Me.cmdDelete.TabIndex = 3
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Location = New System.Drawing.Point(139, 12)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(60, 23)
        Me.cmdDone.TabIndex = 5
        Me.cmdDone.Text = "Done"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'lstRuns
        '
        Me.lstRuns.FormattingEnabled = True
        Me.lstRuns.Location = New System.Drawing.Point(12, 70)
        Me.lstRuns.Name = "lstRuns"
        Me.lstRuns.Size = New System.Drawing.Size(351, 21)
        Me.lstRuns.TabIndex = 6
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 252)
        Me.Controls.Add(Me.lstRuns)
        Me.Controls.Add(Me.cmdDone)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdInsert)
        Me.Controls.Add(Me.lstKeys)
        Me.Controls.Add(Me.dgvReport)
        Me.Name = "frmReport"
        Me.Text = "FCS Report"
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents lstKeys As System.Windows.Forms.ComboBox
    Friend WithEvents cmdInsert As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents lstRuns As System.Windows.Forms.ComboBox
End Class
