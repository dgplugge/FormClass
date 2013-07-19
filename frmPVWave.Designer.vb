<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPVWave
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
        Me.txtLicenseProcess = New System.Windows.Forms.TextBox()
        Me.txtLicenseUser = New System.Windows.Forms.TextBox()
        Me.txtLicenseMachine = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtLicenseProcess
        '
        Me.txtLicenseProcess.Location = New System.Drawing.Point(12, 12)
        Me.txtLicenseProcess.Name = "txtLicenseProcess"
        Me.txtLicenseProcess.Size = New System.Drawing.Size(391, 20)
        Me.txtLicenseProcess.TabIndex = 0
        '
        'txtLicenseUser
        '
        Me.txtLicenseUser.Location = New System.Drawing.Point(12, 68)
        Me.txtLicenseUser.Name = "txtLicenseUser"
        Me.txtLicenseUser.Size = New System.Drawing.Size(391, 20)
        Me.txtLicenseUser.TabIndex = 1
        '
        'txtLicenseMachine
        '
        Me.txtLicenseMachine.Location = New System.Drawing.Point(12, 94)
        Me.txtLicenseMachine.Name = "txtLicenseMachine"
        Me.txtLicenseMachine.Size = New System.Drawing.Size(391, 20)
        Me.txtLicenseMachine.TabIndex = 2
        '
        'frmPVWave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 156)
        Me.Controls.Add(Me.txtLicenseMachine)
        Me.Controls.Add(Me.txtLicenseUser)
        Me.Controls.Add(Me.txtLicenseProcess)
        Me.Name = "frmPVWave"
        Me.Text = "PV Wave"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLicenseProcess As System.Windows.Forms.TextBox
    Friend WithEvents txtLicenseUser As System.Windows.Forms.TextBox
    Friend WithEvents txtLicenseMachine As System.Windows.Forms.TextBox
End Class
