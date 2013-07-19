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

Public Class frmServerData

    Public objLog As HelperClasses.Logger
    Dim objFCS As FCS_Classes.FCS_File

    Public objRun As FCSRun
    Private objSelectRun As FCSRun

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


    Private mUser = Nothing

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



    ' dgp rev 2/13/07 download the selected run
    ' dgp rev 8/1/07 modify Browse Download to include Run if available
    Private Sub Download_Run(ByVal src_path As String)

        Dim target_path As String

        objLog.Log_Info("Source_Path " + src_path)

        ' is run valid
        Dim Prime_Run As New FCS_Classes.FCSRun(src_path)
        If (Not Prime_Run.Valid_Run) Then Exit Sub

        Prime_Run.IsAria()

        target_path = System.IO.Path.Combine(FlowStructure.Data_Root, Prime_Run.Unique_Prefix)
        'target_path = System.IO.Path.Combine(FlowStructure.Data_Root, Prime_Run.Run_List_Path)

        objLog.Log_Info("src_path " + src_path)
        objLog.Log_Info("target_path " + target_path)

        If (System.IO.Directory.Exists(target_path)) Then
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

        If Utility.Create_Tree(target_path) Then
            Copy_FCS_Data(src_path, target_path)
            ' make instance of run object as target
            FlowStructure.BrowseRun = New FCS_Classes.FCSRun(target_path)
            FlowStructure.CurRun = System.IO.Path.GetFileName(target_path)
            FlowStructure.NewDataFlag = True
            objRun = New FCS_Classes.FCSRun(target_path)

            lblStatus.Text = lblStatus.Text + vbCrLf + "Validation Complete"
        Else
            lblStatus.Text = lblStatus.Text + vbCrLf + "Download error"
            MsgBox("Path creation error - " + target_path)
        End If

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

        Browse_Data = System.IO.Path.GetDirectoryName(ofdData.FileName)

        ofdData.InitialDirectory = Browse_Data

        Download_Run(Browse_Data)

    End Sub

    'dgp rev 5/8/07 Browse for Data
    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Browse2()

        FlowStructure.Reset_Runs()
        Reflect_Runs()

    End Sub
    Private mUsername = Environment.GetEnvironmentVariable("username")

    ' dgp rev 5/9/07 Do nothing
    Private Sub frmData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '        SPWorking.Hide()
        '        txtStatus.ScrollBars = ScrollBars.Vertical

        If objLog Is Nothing Then objLog = New Logger("Aria")
        If mUser Is Nothing Then mUser = mUsername

        Me.Text = FlowServer.Server

        Reflect_Users()
        ' reflect run first, so a run is established before state
        SwitchUsers()
        Reflect_Runs()
        Reflect_Runnames()
        Reflect_Rundates()

    End Sub

    ' dgp rev 5/11/07 Close Form
    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownload.Click

        Download_Run(FlowServer.UserRunPath(mUser, mCurRun))
        Me.Close()

    End Sub
    ' dgp rev 6/14/07 Report On Data
    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click

        Dim fReport As New frmReport

        fReport.Report_Run = objSelectRun
        fReport.ShowDialog()

    End Sub

    ' dgp rev 5/26/09 Table Information
    Private Sub cmdTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTable.Click

        Dim insTable As New frmProtocol
        If (objSelectRun.ExtractRunProtocol) Then
            insTable.FormFCSProtocol = objSelectRun.Protocol
            insTable.ShowDialog()
        Else
            MsgBox("No Protocol Found in " + objSelectRun.RunName, MsgBoxStyle.Information)
        End If

    End Sub

    ' dgp rev 7/11/07
    Private Sub cmdRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim objRename As New frmRename
        objRename.objRenameRun = objSelectRun
        objRename.ShowDialog()

        Reflect_Runs()

    End Sub

    ' dgp rev 5/26/09 Reflect the Commands
    Private Sub Reflect_Commands()

        '        cmdReport.Enabled = objSelectRun.Valid_Run
        cmdReport.Enabled = False
        cmdTable.Enabled = cmdReport.Enabled

    End Sub

    ' dgp rev 7/16/07 Change the current run
    ' dgp rev 5/20/09 does the run need to be validated at this point.
    Private Sub lstRuns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRuns.SelectedIndexChanged

        mCurRun = lstRuns.SelectedItem

        Reflect_Commands()

    End Sub

    ' dgp rev 7/6/09 Remove locally
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FlowStructure.RemoveBrowseRun()

        FlowStructure.Reset_Runs()

        Reflect_Runs()

    End Sub

    Private mRunPath As String = ""
    Private mRunArray As ArrayList
    Private mCurRun As String = ""

    ' dgp rev 12/4/07 Reflect the sorted runs
    Private Sub Reflect_Runsx()

        Dim item
        lstRuns.Items.Clear()
        If mRunArray.Count > 0 Then
            For Each item In mRunArray
                lstRuns.Items.Add(item)
                If (mCurRun = item.ToString.ToLower) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
            Next
            If (lstRuns.SelectedIndex = -1) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
        Else
            lstRuns.Items.Add("No Runs")
            lstRuns.SelectedIndex = 0
        End If
        lstRuns.Refresh()

    End Sub

    Private mDataRoot
    Private mRunNameList As ArrayList
    Private mRunDateList As ArrayList

    ' dgp rev 5/13/2010 Look at objRun, then SourcePath, finally use default
    Private Sub SwitchUsers()

        Dim Run As Run_Name
        Dim item
        ' dgp rev 12/4/07 Reflect the sorted runs
        If FlowServer.ServerUserRuns(mUser).Count > 0 Then
            For Each item In FlowServer.ServerUserRuns(mUser)
                lstRuns.Items.Add(item)
                If (mCurRun.ToLower = item.ToString.ToLower) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
            Next
            If (lstRuns.SelectedIndex = -1) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
            mRunArray = FlowServer.ServerUserRuns(mUser)
            mCurRun = mRunArray(0)
            mRunPath = FlowServer.UserRunPath(mUser, mCurRun)
        Else
            mRunArray = New ArrayList
        End If

        mDataRoot = FlowServer.ServerUserRunRoot(mUser)

        Dim name
        mRunNameList = New ArrayList
        mRunDateList = New ArrayList
        If mRunArray.Count > 0 Then
            For Each name In mRunArray
                Run = New Run_Name(System.IO.Path.GetFileName(name))
                If (Run.RunName IsNot Nothing) Then mRunNameList.Add(Run.RunName)
            Next
            mRunNameList.Sort()

            For Each name In mRunArray
                Run = New Run_Name(System.IO.Path.GetFileName(name))
                If (Run.RunName IsNot Nothing) Then mRunDateList.Add(Run.Dat)
            Next
            mRunDateList.Sort(New CustomSort)
        End If

    End Sub

    Class CustomSort
        Implements System.Collections.IComparer

        Function ToDate(ByVal obj As Object) As DateTime
            Dim s As String = obj.ToString()
            Dim mDate As Date
            If (DateTime.TryParse(s, mDate)) Then
                Return mDate
            End If
            Return ""

        End Function

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Try
                Return ToDate(x).CompareTo(ToDate(y))
            Catch ex As Exception
            End Try
            Return -1
        End Function
    End Class


    ' dgp rev 6/14/2010 Reflect Run Names in order
    Private Sub Reflect_Rundates()

        lstDates.Items.Clear()
        lstDates.Items.Add("Select Date")
        Dim item
        For Each item In mRunDateList
            lstDates.Items.Add(item.ToString.ToUpper)
        Next
        lstDates.SelectedIndex = 0
        lstDates.Refresh()

    End Sub

    ' dgp rev 6/14/2010 Reflect Run Names in order
    Private Sub Reflect_Runnames()

        lstRunNames.Items.Clear()
        lstRunNames.Items.Add("Select Run")
        Dim item
        For Each item In mRunNameList
            lstRunNames.Items.Add(item.ToString.ToUpper)
        Next
        lstRunNames.SelectedIndex = 0
        lstRunNames.Refresh()

    End Sub

    ' dgp rev 5/22/08 Resort the runs
    Public Sub Sort_Runs()

        '        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        ' Sorts the values of the ArrayList using the reverse case-insensitive comparer.
        Dim myComparer = New RunCompare
        RunCompare.Reps = 0

        Try
            If (mRunArray.Count > 1) Then mRunArray.Sort(myComparer)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Sort()

        RunCompare.Idx = 2
        Sort_Runs()

    End Sub
    ' dgp rev 7/20/2010 
    Private Sub lstRunNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRunNames.SelectedIndexChanged

        Dim item
        Dim cnt = 0
        If lstRunNames.SelectedIndex > 0 Then
            For Each item In lstRuns.Items
                If item.ToString.ToLower.Contains(lstRunNames.SelectedItem.ToString.ToLower) Then
                    lstRuns.SelectedIndex = cnt
                End If
                cnt = cnt + 1
            Next
            If lstDates.Items.Count > 0 Then lstDates.SelectedIndex = 0
        End If

    End Sub

    Private Sub lstDates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDates.SelectedIndexChanged

        Dim item
        Dim cnt = 0
        If lstDates.SelectedIndex > 0 Then
            For Each item In lstRuns.Items
                If item.ToString.ToLower.Contains(lstDates.SelectedItem.ToString.ToLower) Then
                    lstRuns.SelectedIndex = cnt
                End If
                cnt = cnt + 1
            Next
            If lstRunNames.Items.Count > 0 Then lstRunNames.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmdDerived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim insDerivedData As New frmDerivedData
        insDerivedData.ShowDialog()

    End Sub

    ' dgp rev 7/9/2010 Select User
    Private Sub lstUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUsers.SelectedIndexChanged

        If lstUsers.SelectedIndex = 0 Then Return
        mUser = lstUsers.SelectedItem

        SwitchUsers()

        Reflect_Runs()
        Reflect_Rundates()
        Reflect_Runnames()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Me.Close()

    End Sub
End Class