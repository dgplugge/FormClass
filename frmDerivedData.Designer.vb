<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDerivedData
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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.dg_branches = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.dg_branches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstRuns
        '
        Me.lstRuns.FormattingEnabled = True
        Me.lstRuns.Location = New System.Drawing.Point(12, 12)
        Me.lstRuns.Name = "lstRuns"
        Me.lstRuns.Size = New System.Drawing.Size(332, 21)
        Me.lstRuns.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 39)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(332, 338)
        Me.TreeView1.TabIndex = 2
        '
        'dg_branches
        '
        Me.dg_branches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_branches.Location = New System.Drawing.Point(372, 12)
        Me.dg_branches.Name = "dg_branches"
        Me.dg_branches.Size = New System.Drawing.Size(38, 40)
        Me.dg_branches.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(372, 58)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(161, 209)
        Me.TextBox1.TabIndex = 4
        '
        'frmDerivedData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 415)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.dg_branches)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.lstRuns)
        Me.Name = "frmDerivedData"
        Me.Text = "Derived FCS Data"
        CType(Me.dg_branches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstRuns As System.Windows.Forms.ComboBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents dg_branches As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
