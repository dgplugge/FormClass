Imports HelperClasses
Imports FCS_Classes

Public Class frmEFL

    '********************************************************************************
    'Author    : Donald G Plugge
    'Date      : 11/22/06
    'Purpose   : Form used to select a run from internal cache
    '********************************************************************************
    ' dgp rev 2/10/07 grab data from EIB Flow Lab Server
    Private mUser = Nothing

    Public objLog As Logger
    Public objRun As FCSRun

    Private mCurRun As String

    ' dgp rev 2/13/07 onetime routine, scan users on server
    Private Sub Reflect_Users()

        Dim item

        lstUsers.Items.Clear()
        If (NIHNet.FlowLabUsers.Count > 0) Then
            For Each item In NIHNet.FlowLabUsers
                lstUsers.Items.Add(item)
                If (item.ToString.ToLower = mUser.ToLower) Then lstUsers.SelectedIndex = lstUsers.Items.Count - 1
            Next
        Else
            ' if no users found
            lstUsers.Items.Add("No Users")
        End If
        ' if no selection then select last item
        If (lstUsers.SelectedIndex = -1) Then lstUsers.SelectedIndex = lstUsers.Items.Count - 1

    End Sub

    ' dgp rev 12/4/07 Reflect the sorted runs
    Private Sub Reflect_Runs()

        Dim item
        lstRuns.Items.Clear()
        If FlowServer.ServerUserRuns(mUser).Count > 0 Then
            For Each item In FlowServer.ServerUserRuns(mUser)
                lstRuns.Items.Add(item)
                If (mCurRun.ToLower = item.ToString.ToLower) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
            Next
            If (lstRuns.SelectedIndex = -1) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
        Else
            lstRuns.Items.Add("No Runs")
            lstRuns.SelectedIndex = 0
        End If
        lstRuns.Refresh()

    End Sub

    ' dgp rev 2/13/07 Scan files based upon current user and current run
    Private Sub Reflect_Files()

        Dim item
        lstFiles.Items.Clear()
        ' scan files in run
        If (FlowServer.ServerUserRun(mUser, mCurRun).Count > 0) Then
            For Each item In FlowServer.ServerUserRun(mUser, mCurRun)
                lstFiles.Items.Add(item)
            Next
        End If

        If (lstFiles.Items.Count = 0) Then lstFiles.Items.Add("No files")
        lstFiles.Refresh()

    End Sub

    Private mUsername = Environment.GetEnvironmentVariable("username")
    ' dgp rev 5/8/07 Load the Form
    Private Sub frmWS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SPWorking.Hide()
        txtStatus.ScrollBars = ScrollBars.Vertical

        If objLog Is Nothing Then objLog = New Logger("Aria")
        If mUser Is Nothing Then mUser = mUsername
        If objRun Is Nothing Then
            mCurRun = FlowStructure.BrowseRun.RunName
        Else
            mCurRun = objRun.RunName
        End If

        Me.Text = FlowServer.Server

        Reflect_Users()

    End Sub


    ' dgp rev 5/8/07 select a user
    ' dgp rev 2/13/07 Change the current user and rescan the runs
    Private Sub lstUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUsers.SelectedIndexChanged

        mUser = lstUsers.Items(lstUsers.SelectedIndex)

        Reflect_Runs()

    End Sub

    ' dgp rev 7/6/09 Download
    Private Sub Reflect_Download()

        Dim local_run = System.IO.Path.Combine(FlowStructure.Data_Root, mCurRun)
        cmdDownload.Enabled = (Not System.IO.Directory.Exists(local_run))

    End Sub

    ' dgp rev 2/13/07 select a run
    Private Sub lstRuns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRuns.SelectedIndexChanged

        mCurRun = lstRuns.SelectedItem
        Reflect_Download()

        Reflect_Files()

    End Sub

    ' dgp rev 7/6/09 Reflect each transfer
    Private Sub Transfer_Handler(ByVal info As String)

        mFile = info
        Reflect_Transfer()

    End Sub

    Private mFile

    ' dgp rev 7/6/09 Reflect each transfer
    Private Sub Reflect_Transfer()

        If InvokeRequired Then
            BeginInvoke(New MethodInvoker(AddressOf Reflect_Transfer))
        Else
            txtStatus.Text = txtStatus.Text + vbCrLf + mFile
            txtStatus.SelectionStart = txtStatus.Text.Length
            txtStatus.ScrollToCaret()
            txtStatus.Refresh()
        End If

    End Sub

    ' dgp rev 5/8/07 Download
    Private Sub cmdDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownload.Click

        ' dgp rev 7/6/09 download from server, add event handler
        SPWorking.Show()
        AddHandler FlowServer.FSSRemoteEvent, AddressOf Transfer_Handler

        FlowServer.Download_Run(mUser, mCurRun)
        Dim local As String = System.IO.Path.Combine(FlowStructure.Data_Root, mCurRun)
        If System.IO.Directory.Exists(local) Then objRun = New FCSRun(local)

        RemoveHandler FlowServer.FSSRemoteEvent, AddressOf Transfer_Handler
        SPWorking.Hide()

    End Sub

    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click

        Me.Close()

    End Sub

    ' dgp rev 5/13/2010 Sort and find data
    Private Sub cmdSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSort.Click

        Dim insSort As New frmSort
        insSort.objRun = New FCSRun(FlowServer.UserRunPath(mUser, FlowServer.ServerUserRuns(mUser)(0)))
        insSort.ShowDialog()
        objRun = insSort.objRun

    End Sub
End Class