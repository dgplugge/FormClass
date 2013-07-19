
Public Class frmPVWave

    Private mLicVar = Environment.GetEnvironmentVariable("LM_LICENSE_FILE")

    ' dgp rev 12/16/2011 
    Private Sub ReflectLicVar()

        txtLicenseProcess.Text = Environment.GetEnvironmentVariable("LM_LICENSE_FILE", EnvironmentVariableTarget.Process)
        txtLicenseUser.Text = Environment.GetEnvironmentVariable("LM_LICENSE_FILE", EnvironmentVariableTarget.User)
        txtLicenseMachine.Text = Environment.GetEnvironmentVariable("LM_LICENSE_FILE", EnvironmentVariableTarget.Machine)
        txtLicenseProcess.Refresh()

    End Sub

    ' dgp rev 12/16/2011 
    Private Sub frmPVWave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReflectLicVar()

    End Sub
End Class