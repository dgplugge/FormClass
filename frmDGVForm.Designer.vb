<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDGVForm
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
        Me.dgvProtocol = New System.Windows.Forms.DataGridView()
        Me.cmdPrintOp = New System.Windows.Forms.Button()
        Me.gpControls = New System.Windows.Forms.GroupBox()
        Me.cmdPrintOper = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        CType(Me.dgvProtocol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProtocol
        '
        Me.dgvProtocol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProtocol.Location = New System.Drawing.Point(12, 74)
        Me.dgvProtocol.Name = "dgvProtocol"
        Me.dgvProtocol.Size = New System.Drawing.Size(383, 220)
        Me.dgvProtocol.TabIndex = 0
        '
        'cmdPrintOp
        '
        Me.cmdPrintOp.Location = New System.Drawing.Point(117, 19)
        Me.cmdPrintOp.Name = "cmdPrintOp"
        Me.cmdPrintOp.Size = New System.Drawing.Size(75, 23)
        Me.cmdPrintOp.TabIndex = 2
        Me.cmdPrintOp.Text = "Print"
        Me.cmdPrintOp.UseVisualStyleBackColor = True
        '
        'gpControls
        '
        Me.gpControls.Controls.Add(Me.cmdPrintOper)
        Me.gpControls.Controls.Add(Me.cmdClose)
        Me.gpControls.Controls.Add(Me.cmdPrintOp)
        Me.gpControls.Location = New System.Drawing.Point(14, 12)
        Me.gpControls.Name = "gpControls"
        Me.gpControls.Size = New System.Drawing.Size(381, 56)
        Me.gpControls.TabIndex = 3
        Me.gpControls.TabStop = False
        Me.gpControls.Text = "Controls"
        '
        'cmdPrintOper
        '
        Me.cmdPrintOper.Location = New System.Drawing.Point(198, 19)
        Me.cmdPrintOper.Name = "cmdPrintOper"
        Me.cmdPrintOper.Size = New System.Drawing.Size(96, 23)
        Me.cmdPrintOper.TabIndex = 4
        Me.cmdPrintOper.Text = "Print (Oper)"
        Me.cmdPrintOper.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(300, 19)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmDGVForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 310)
        Me.Controls.Add(Me.gpControls)
        Me.Controls.Add(Me.dgvProtocol)
        Me.Name = "frmDGVForm"
        Me.Text = "Print Protocol"
        CType(Me.dgvProtocol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpControls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProtocol As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrintOp As System.Windows.Forms.Button
    Friend WithEvents gpControls As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdPrintOper As System.Windows.Forms.Button
End Class
