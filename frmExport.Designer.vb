<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
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
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumericColumns = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericRows = New System.Windows.Forms.NumericUpDown
        Me.cmdTest = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericRows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(12, 113)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatus.Size = New System.Drawing.Size(268, 148)
        Me.txtStatus.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdApply)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NumericColumns)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NumericRows)
        Me.GroupBox1.Controls.Add(Me.cmdTest)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 88)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Power Point Setup"
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(187, 53)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 5
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Columns"
        '
        'NumericColumns
        '
        Me.NumericColumns.Location = New System.Drawing.Point(59, 53)
        Me.NumericColumns.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericColumns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericColumns.Name = "NumericColumns"
        Me.NumericColumns.Size = New System.Drawing.Size(39, 20)
        Me.NumericColumns.TabIndex = 3
        Me.NumericColumns.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Rows"
        '
        'NumericRows
        '
        Me.NumericRows.Location = New System.Drawing.Point(59, 22)
        Me.NumericRows.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericRows.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericRows.Name = "NumericRows"
        Me.NumericRows.Size = New System.Drawing.Size(39, 20)
        Me.NumericRows.TabIndex = 1
        Me.NumericRows.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'cmdTest
        '
        Me.cmdTest.Location = New System.Drawing.Point(187, 19)
        Me.cmdTest.Name = "cmdTest"
        Me.cmdTest.Size = New System.Drawing.Size(75, 23)
        Me.cmdTest.TabIndex = 0
        Me.cmdTest.Text = "Test"
        Me.cmdTest.UseVisualStyleBackColor = True
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtStatus)
        Me.Name = "frmExport"
        Me.Text = "Export "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericColumns, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericRows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdTest As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumericColumns As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericRows As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdApply As System.Windows.Forms.Button
End Class
