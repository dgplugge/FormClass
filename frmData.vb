' Name:     PV-Wave Data Handling Form
' Author:   Donald G Plugge
' Date:     5/9/07
' Purpose:  Main Module to handle the configuration of PV-Wave Data Sets
' dgp rev 5/9/07 Handles Aria Server data 
' dgp rev 5/9/07 Handles Local Data cache
' dgp rev 5/9/07 Handles Browse for Data
' dgp rev 12/5/08 The data manipulation forms will change selected run, not current
Imports FCS_Classes
Imports HelperClasses

' Author: Donald G Plugge
' Date: 12/3/08 
Public Class frmData

    Public objLog As HelperClasses.Logger
    Dim objFCS As FCS_Classes.FCS_File

    Public objRun As FCSRun

    Dim Target_Path As String
    Dim Target_Spec As String
    Dim Source_Spec As String

    Dim Browse_Data As String

    Dim ScanFlag As Boolean = True

    ' dgp rev 5/17/07 moves only valid FCS files from source to target
    Private Sub Copy_FCS_Data(ByVal source As String, ByVal target As String)

        Dim file
        Dim objFile As FCS_Classes.FCS_File

        Dim target_spec As String

        ' loop thru folder
        For Each file In System.IO.Directory.GetFiles(source)
            ' create an FCS run object
            objFile = New FCS_Classes.FCS_File(file)
            If (objFile.Valid) Then
                Try
                    target_spec = System.IO.Path.Combine(target, System.IO.Path.GetFileName(file))
                    System.IO.File.Copy(file, target_spec, True)
                    objLog.Log_Info(file + " to " + target_spec)
                    lblStatus.Text = System.IO.Path.GetFileName(file)
                    lblStatus.Refresh()
                Catch ex As Exception
                    objLog.Log_Info(ex.Message)
                    lblStatus.Text = ex.Message
                    lblStatus.Refresh()
                End Try
            End If
        Next

    End Sub

    ' dgp rev 2/13/07 download the selected run
    ' dgp rev 8/1/07 modify Browse Download to include Run if available
    Private Sub Download_Run(ByVal src_path As String)

        Dim target_path As String

        objLog.Log_Info("Source_Path " + src_path)

        ' is run valid
        Dim Prime_Run As New FCS_Classes.FCSRun(src_path)
        If (Not Prime_Run.Valid_Run) Then Exit Sub

        Prime_Run.IsAria()

        target_path = system.io.path.combine(FlowStructure.Data_Root, Prime_Run.Unique_Prefix)

        objLog.Log_Info("src_path " + src_path)
        objLog.Log_Info("target_path " + target_path)

        If (System.IO.Directory.exists(target_path)) Then
            If (MsgBox("Overwrite", vbYesNo, "Run Exists") <> vbYes) Then Exit Sub
            ' dgp rev 8/1/07 delete the run in order to overwrite
            Try
                Utility.DeleteTree(target_path)
            Catch ex As Exception
                MsgBox("Error Deleting Run", MsgBoxStyle.Information)
                Exit Sub
            End Try
        End If

        Dim old_curse As Cursor = Me.Cursor

        ' change the cursor to the one you want
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Windows.Forms.Cursor.Show()

        Utility.Create_Tree(target_path)

        Copy_FCS_Data(src_path, target_path)

        ' make instance of run object as target
        FlowStructure.BrowseRun = New FCS_Classes.FCSRun(target_path)
        FlowStructure.CurRun = System.IO.Path.GetDirectoryName(target_path)
        FlowStructure.NewDataFlag = True

        lblStatus.Text = lblStatus.Text + vbCrLf + "Validation Complete"
        lblStatus.Refresh()

        Windows.Forms.Cursor.Hide()
        Windows.Forms.Cursor.Current = old_curse

    End Sub

    ' dgp rev 6/14/07
    Private Sub Browse()

        Dim Copy_Flag As Boolean = False

        fbdData.RootFolder = Environment.SpecialFolder.MyComputer

        fbdData.SelectedPath = Browse_Data

        If (fbdData.ShowDialog <> Windows.Forms.DialogResult.OK) Then Exit Sub

        Browse_Data = fbdData.SelectedPath

        Download_Run(Browse_Data)

    End Sub

    ' dgp rev 6/14/07
    <STAThreadAttribute()> Private Sub Browse2()

        Dim Copy_Flag As Boolean = False

        ofdData.CheckPathExists = True
        ofdData.CheckFileExists = False
        ofdData.DefaultExt = "*.fcs"
        ofdData.Filter = "FCS Data (*.fcs)|*.fcs|All files (*.*)|*.*"
        ofdData.FileName = ""

        ofdData.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

        If (ofdData.ShowDialog <> Windows.Forms.DialogResult.OK) Then Exit Sub

        Browse_Data = system.io.Path.GetDirectoryName(ofdData.FileName)

        ofdData.InitialDirectory = Browse_Data

        Download_Run(Browse_Data)

    End Sub

    'dgp rev 5/8/07 Browse for Data
    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click

        Browse2()

        FlowStructure.Reset_Runs()
        Reflect_Runs()

    End Sub

    ' dgp rev 5/9/07 Do nothing
    Private Sub frmData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If objRun Is Nothing Then objRun = FlowStructure.BrowseRun
        If objLog Is Nothing Then objLog = New Logger("Data")
        ' reflect run first, so a run is established before state
        Reflect_Runs()

    End Sub
    ' dgp rev 5/8/07 EIB Flow Lab Server Form
    Private Sub cmdEIBServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEIBServer.Click

        Dim insEFL As New frmEFL
        insEFL.objLog = objLog
        insEFL.ShowDialog()
        objRun = FlowStructure.BrowseRun
        '        If (BrowseSession.Data_Path_Flag) Then FlowStructure.Scan_Runs()

        FlowStructure.Reset_Runs()
        Reflect_Runs()

    End Sub
    ' dgp rev 5/9/07 Work Set Select
    Private Sub cmdWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWS.Click

        ' dgp rev 12/5/08 create the instance of the form
        Dim dfiData As New Form_Class.frmRuns
        ' dgp rev 12/5/08 display the form
        dfiData.ShowDialog()

        ' dgp rev 12/5/08 if data changed then use the new data

        FlowStructure.Reset_Runs()
        Reflect_Runs()

    End Sub
    ' dgp rev 5/9/07 VMS Server
    Private Sub cmdVMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVMS.Click

        frmVMS.ShowDialog()
        FlowStructure.BrowseRun = frmVMS.objRun
        '        If (BrowseSession.Data_Path_Flag) Then FlowStructure.Scan_Runs()

        FlowStructure.Reset_Runs()
        Reflect_Runs()

    End Sub

    Public Sub SetData(ByRef SomeObj As Object)

        objRun = SomeObj

    End Sub

    Public Sub GetData(ByRef SomeObj As Object)

        SomeObj = objRun

    End Sub


    ' dgp rev 5/11/07 Close Form
    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click

        Me.Close()

    End Sub
    ' dgp rev 6/14/07 Report On Data
    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click

        Dim fReport As New frmReport

        fReport.Report_Run = objRun
        fReport.ShowDialog()

        Reflect_Runs()

    End Sub

    ' dgp rev 5/26/09 Table Information
    Private Sub cmdTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable.Click

        Dim insTable As New frmProtocol
        If (objRun.ExtractRunProtocol) Then
            insTable.FormFCSProtocol = objRun.Protocol
            insTable.ShowDialog()
        Else
            MsgBox("No Protocol Found in " + objRun.RunName, MsgBoxStyle.Information)
        End If

    End Sub

    ' dgp rev 7/11/07
    Private Sub cmdRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRename.Click

        Dim objRename As New frmRename
        objRename.objRenameRun = objRun
        objRename.ShowDialog()

        'Reflect_Runs()

    End Sub

    ' dgp rev 12/4/07 Reflect the sorted runs
    Private Sub Reflect_Runs()

        Dim item
        lstRuns.Items.Clear()
        If FlowStructure.RunArray.Count > 0 Then
            Dim CurRun = System.IO.Path.GetFileName(FlowStructure.BrowseRun.Orig_Path).ToLower
            For Each item In FlowStructure.RunArray
                lstRuns.Items.Add(item)
                If (CurRun = item.ToString.ToLower) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
            Next
            If (lstRuns.SelectedIndex = -1) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
        Else
            lstRuns.Items.Add("No Runs")
            lstRuns.SelectedIndex = 0
        End If
        lstRuns.Refresh()

    End Sub

    ' dgp rev 5/26/09 Reflect the Commands
    Private Sub Reflect_Commands()

        cmdRename.Enabled = objRun.Valid_Run
        cmdReport.Enabled = cmdRename.Enabled
        cmdTable.Enabled = cmdRename.Enabled

    End Sub

    ' dgp rev 7/16/07 Change the current run
    ' dgp rev 5/20/09 does the run need to be validated at this point.
    Private Sub lstRuns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRuns.SelectedIndexChanged

        objRun = New FCS_Classes.FCSRun(System.IO.Path.Combine(FlowStructure.Data_Root, lstRuns.SelectedItem))
        FlowStructure.BrowseRun = objRun

        Reflect_Commands()

    End Sub
    ' dgp rev 5/22/08 Call Sort Interface
    Private Sub cmdSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSort.Click

        Dim objSort As New frmSort
        objSort.ShowDialog()

        FlowStructure.Reset_Runs()
        Reflect_Runs()

    End Sub

    ' dgp rev 7/6/09 Remove locally
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click

        FlowStructure.RemoveBrowseRun()

        FlowStructure.Reset_Runs()

        Reflect_Runs()

    End Sub
End Class