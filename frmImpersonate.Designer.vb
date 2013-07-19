<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpersonate
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
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.cmdLogin = New System.Windows.Forms.Button
        Me.lblMess = New System.Windows.Forms.Label
        Me.lblPass = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(116, 59)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(144, 20)
        Me.txtPass.TabIndex = 2
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(116, 16)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(144, 20)
        Me.txtUser.TabIndex = 1
        '
        'cmdLogin
        '
        Me.cmdLogin.Location = New System.Drawing.Point(186, 94)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(74, 37)
        Me.cmdLogin.TabIndex = 3
        Me.cmdLogin.Text = "Login"
        Me.cmdLogin.UseVisualStyleBackColor = True
        '
        'lblMess
        '
        Me.lblMess.AutoSize = True
        Me.lblMess.Location = New System.Drawing.Point(35, 216)
        Me.lblMess.Name = "lblMess"
        Me.lblMess.Size = New System.Drawing.Size(0, 13)
        Me.lblMess.TabIndex = 4
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPass.Location = New System.Drawing.Point(12, 59)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(68, 16)
        Me.lblPass.TabIndex = 7
        Me.lblPass.Text = "Password"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(12, 16)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(82, 16)
        Me.lblUser.TabIndex = 8
        Me.lblUser.Text = "NIH Account"
        '
        'frmImpersonate
        '
        Me.AcceptButton = Me.cmdLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(272, 142)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblMess)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtPass)
        Me.Name = "frmImpersonate"
        Me.Text = "NCI Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents lblMess As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label

End Class
