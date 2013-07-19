' dgp rev 2/14/2011
Imports FCS_Classes
Imports HelperClasses

Public Class frmSettings

    ' dgp rev 2/14/2011
    Private Sub cmdColors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColors.Click

        Dim insColorTable As New frmColorTable
        insColorTable.ShowDialog()

    End Sub

    Public objPVW As PVWave

    ' dgp rev 4/19/07 Reflect the current local distributions
    Private Sub Reflect_Local()

        lstLocalVers.Items.Clear()
        If (Not objPVW Is Nothing) Then
            Me.lblLocalRoot.Text = FlowStructure.Dist_Root
            If (Not objPVW.Local_List Is Nothing) Then
                Dim item
                For Each item In objPVW.Local_List
                    lstLocalVers.Items.Add(item)
                    If (item = FlowStructure.CurDist) Then lstLocalVers.SelectedIndex = lstLocalVers.Items.Count - 1
                Next
            End If
        End If
        ' dgp rev 12/9/07 default to last item
        If (lstLocalVers.SelectedIndex = -1) Then lstLocalVers.SelectedIndex = lstLocalVers.Items.Count - 1
        lstLocalVers.Refresh()

    End Sub

    ' dgp rev 8/5/2011
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    ' dgp rev 4/19/07 uninstall local version
    Private Sub Uninstall()

        Dim path As String = System.IO.Path.Combine(FlowStructure.Dist_Root, FlowStructure.CurDist)

        If (System.IO.Directory.Exists(path)) Then
            Utility.DeleteTree(path)
            objPVW.ReSetLocalList()
            Reflect_Local()
        End If

    End Sub

    ' dgp rev 4/19/07 Reflect server downloads
    Private Sub Reflect_Update()

        cmdUpdate.Enabled = objPVW.Server_Valid

    End Sub

    ' dgp rev 2/22/07 reflect the current PV-Wave settings
    Private Sub Reflect_PVW()

        Reflect_Update()

    End Sub

    ' dgp rev 2/23/07 download the current server version to the local drive
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim source As String = "\\" + objPVW.Server + "\" + objPVW.Share + "\Versions\" + objPVW.Server_Ver
        Dim target As String = System.IO.Path.Combine(FlowStructure.Dist_Root.ToString, objPVW.Server_Ver)

        Dim UpdateFlag As Boolean = False
        Dim SuccessFlag As Boolean = False

        If (objPVW.ImpFlag) Then objPVW.ObjImp.ImpersonateStart("NIH", objPVW.Account, objPVW.Password)
        If (System.IO.Directory.Exists(source)) Then
            If (Not System.IO.Directory.Exists(target)) Then
                UpdateFlag = True
                Err.Clear()
                Utility.DirectoryCopy(source, target)
                SuccessFlag = (Err.Number = 0)
            End If
        End If
        If (objPVW.ImpFlag) Then objPVW.ObjImp.ImpersonateStop()

        If (UpdateFlag And Not SuccessFlag) Then MsgBox("Update Error " + Err.Description, MsgBoxStyle.Information)

        If (UpdateFlag And SuccessFlag) Then
            ' dgp rev 2/6/08 make the new version active
            FlowStructure.CurDist = objPVW.Server_Ver
            objPVW.Scan_Local_Vers()
            Reflect_PVW()
            Reflect_Local()
        End If

    End Sub

    ' dgp rev 4/19/07 Scan the server for downloads
    Private Sub Scan_Server()

        Dim old_curse As Cursor = Me.Cursor

        ' change the cursor to the one you want
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Windows.Forms.Cursor.Show()
        objPVW.Scan_Server_Vers()
        objPVW.Validate_Server()
        Windows.Forms.Cursor.Hide()
        Windows.Forms.Cursor.Current = old_curse

    End Sub

    ' dgp rev 4/19/07 Scan the server for downloads
    ' dgp rev 3/27/08 Scan the Server for 
    Private Sub Scan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click

        ' dgp rev 3/27/08 check to see if the server has already accessible
        If (Not objPVW.FlagServer) Then
            ' dgp rev 3/27/08 check the server connect
            If (Not objPVW.Check_Server()) Then
                ' dgp rev 3/27/08 Impersonation is needed
                Dim objImpresonate As New frmImpersonate
                objImpresonate.ShowDialog()
            End If
        End If

        ' dgp rev 3/27/08 check again
        If (objPVW.FlagServer) Then
            Scan_Server()
            Reflect_Server()
        End If

    End Sub

    ' dgp rev 4/19/07 Reflect server downloads
    Private Sub Reflect_Server()

        If (Not objPVW.Server_List Is Nothing) Then lstServerVers.DataSource = objPVW.Server_List
        If (Not objPVW.Server_Ver Is Nothing) Then cmdUpdate.Enabled = (Not objPVW.Local_List.Contains(objPVW.Server_Ver))

    End Sub

    ' dgp rev 2/23/07 change the downloadable dsitribution version
    Private Sub lstServerVers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServerVers.SelectedIndexChanged

        objPVW.Server_Ver = lstServerVers.SelectedItem

        objPVW.Validate_Server()

        Reflect_Server()

    End Sub


    ' dgp rev 2/23/07 pulldown changes the current version
    Private Sub lstLocalVers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstLocalVers.SelectedIndexChanged

        FlowStructure.CurDist = lstLocalVers.SelectedItem

    End Sub

    ' dgp rev 8/9/2011 
    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Reflect_Local()

    End Sub

    Private Sub cmdUninstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUninstall.Click

        ' dgp rev 4/19/07 Initiate uninstall

        If (MsgBox("Are you sure you want to uninstall " + FlowStructure.CurDist, MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes) Then
            Uninstall()
        End If

    End Sub

    ' dgp rev 8/9/2011 Test mode
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        objPVW.TestMode = CheckBox1.Checked

    End Sub

    Private Sub cmdLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLicense.Click

        Dim insPVWave As New Form_Class.frmPVWave
        insPVWave.ShowDialog()

    End Sub

    Private Sub cmdExport_Click(sender As System.Object, e As System.EventArgs) Handles cmdExport.Click

        Dim insExport As New frmExport
        insExport.ShowDialog()

    End Sub
End Class