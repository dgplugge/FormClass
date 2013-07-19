' Author: Donald G Plugge
' Date: 12/9/08
' Authentication of credentials
Imports HelperClasses

Public Class frmAuth

    Inherits System.Windows.Forms.Form

    Public objAccess As UserAccess
    Public objFTP As FTPtoVMS
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblUser = New System.Windows.Forms.Label
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 24)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(120, 56)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(136, 20)
        Me.txtPassword.TabIndex = 6
        Me.txtPassword.Text = ""
        '
        'lblUser
        '
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(32, 24)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(72, 24)
        Me.lblUser.TabIndex = 5
        Me.lblUser.Text = "Username:"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(120, 24)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(136, 20)
        Me.txtUser.TabIndex = 4
        Me.txtUser.Text = ""
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(16, 88)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(96, 32)
        Me.cmdApply.TabIndex = 8
        Me.cmdApply.Text = "Apply"
        '
        'frmAuth
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 133)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.txtUser)
        Me.Name = "frmAuth"
        Me.Text = "frmAuth"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' dgp rev 5/1/06 apply the new authentication settings
    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click

        objAccess.Username = txtUser.Text.ToString
        objAccess.Password = txtPassword.Text.ToString
        If (Not objFTP.authenticate()) Then
            objAccess.Username = objFTP.Auth_User.ToUpper
            objAccess.Password = objFTP.Auth_Pass.ToString
        End If
        Me.Close()

    End Sub

    ' dgp rev 5/1/06 load the current settings for authentication
    Private Sub frmAuth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If (objFTP Is Nothing) Then
            txtUser.Text = objAccess.Username
            txtPassword.Text = objAccess.Password
        Else
            txtUser.Text = objFTP.Auth_User.ToUpper
            txtPassword.Text = objFTP.Auth_Pass.ToString
        End If

    End Sub
End Class
