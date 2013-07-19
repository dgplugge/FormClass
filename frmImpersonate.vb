' dgp rev 1/26/07
Imports System.Security.AccessControl.AuthorizationRule
Imports System.Management

Public Class frmImpersonate

    Dim tDomain As String = "NIH"
    Dim tUsername As String
    Dim tPassWord As String
    Dim mValid As Boolean = False
    Public objImp As HelperClasses.RunAs_Impersonator

    ' dgp rev 1/26/07
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtUser.Text = tUsername
        txtPass.Text = tPassWord

        Dim objAuth As New System.Net.Security.AuthenticationLevel

        objAuth = Net.Security.AuthenticationLevel.MutualAuthRequested

    End Sub
    ' dgp rev 1/26/07
    Private Sub NCI_Auth(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click

        Try
            objImp.ImpersonateStart("NIH", tUsername, tPassWord) 'creates new context using token for user
            '            Add code to run as UserName here 'everything between ImpersonateStart and ImpersonateStop will be run as the impersonated user
            objImp.ImpersonateStop()
            mValid = True
        Catch ex As Exception 'make sure impersonation is stopped whether code succeeds or not
            MsgBox(ex.Message, MsgBoxStyle.Information)
            objImp.ImpersonateStop()
            mValid = False
        End Try

        If mValid Then
            '            Init_Access()
            Me.Close()
        End If

    End Sub

    ' dgp rev 6/19/07 Change the username
    Private Sub txtUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUser.TextChanged

        tUsername = txtUser.Text

    End Sub

    ' dgp rev 6/19/07 Change the password
    Private Sub txtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.TextChanged

        tPassWord = txtPass.Text

    End Sub
End Class
