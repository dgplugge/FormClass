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

Public Class frmFindData

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

        target_path = System.IO.Path.Combine(FlowStructure.Data_Root, Prime_Run.Unique_Prefix)

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

        Utility.Create_Tree(target_path)

        Copy_FCS_Data(src_path, target_path)

        ' make instance of run object as target
        FlowStructure.BrowseRun = New FCS_Classes.FCSRun(target_path)
        FlowStructure.CurRun = System.IO.Path.GetFileName(target_path)
        mCurRun = FlowStructure.CurRun
        FlowStructure.NewDataFlag = True

        FlowStructure.Reset_Runs()

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

        Reflect_Runs()

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
        Prep()
        Reflect_Flag()
        Reflect_Runs()

    End Sub
    ' dgp rev 5/8/07 EIB Flow Lab Server Form
    Private Sub cmdEIBServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEIBServer.Click

        Dim insEFL As New frmServerData
        insEFL.objLog = objLog
        insEFL.ShowDialog()
        If insEFL.objRun IsNot Nothing Then
            objRun = insEFL.objRun
            mCurRun = objRun.RunName
        End If

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

        '        Reflect_Runs()

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

    ' dgp rev 7/6/09 Remove locally
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click

        FlowStructure.RemoveBrowseRun()

        FlowStructure.Reset_Runs()


        Reflect_Runs()

    End Sub

    Private mRunPath As String = ""
    Private mCurRun As String = ""

    ' dgp rev 12/4/07 Reflect the sorted runs
    ' dgp rev 8/29/2011 fixed the error with CurRun being blank
    Private Sub Reflect_Runs()

        Dim item
        SortRuns()
        lstRuns.Items.Clear()
        If mCurRun Is Nothing Then mCurRun = ""
        If mSortArray IsNot Nothing Then
            If mSortArray.Count > 0 Then
                For Each item In mSortArray
                    lstRuns.Items.Add(item)
                    ' DGP REV 1/11/2011 compare lowercase
                    If (mCurRun.ToLower = item.ToString.ToLower) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
                Next
                If (lstRuns.SelectedIndex = -1) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
            Else
                lstRuns.Items.Add("No Runs")
                lstRuns.SelectedIndex = 0
            End If
        Else
            lstRuns.Items.Add("No Runs")
            lstRuns.SelectedIndex = 0
        End If
        lstRuns.Refresh()

        Reflect_Runnames()
        Reflect_Rundates()

    End Sub

    Private mRunNameList As ArrayList
    Private mRunDateList As ArrayList
    Private mSortArray As ArrayList

    Private Sub SortRuns()

        mSortArray = FlowStructure.RunArray
        If mSortArray Is Nothing Then
            mSortArray = New ArrayList
            Exit Sub
        End If
        '        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        ' Sorts the values of the ArrayList using the reverse case-insensitive comparer.
        Dim myComparer = New RunCompare
        RunCompare.Reps = 0

        Try
            If (mSortArray.Count > 1) Then mSortArray.Sort(myComparer)
        Catch ex As Exception

        End Try

        Dim Run As Run_Name
        Dim name
        mRunNameList = New ArrayList
        For Each name In mSortArray
            Run = New Run_Name(System.IO.Path.GetFileName(name))
            If (Run.RunName IsNot Nothing) Then mRunNameList.Add(Run.RunName)
        Next
        mRunNameList.Sort()

        mRunDateList = New ArrayList
        For Each name In mSortArray
            Run = New Run_Name(System.IO.Path.GetFileName(name))
            If (Run.RunName IsNot Nothing) Then mRunDateList.Add(Run.Dat)
        Next
        mRunDateList.Sort(New CustomSort)

    End Sub

    ' dgp rev 5/13/2010 Look at objRun, then SourcePath, finally use default
    Private Sub Prep()

        If objRun Is Nothing Then
            mCurRun = FlowStructure.RunArray(0)
            mRunPath = System.IO.Path.Combine(FlowStructure.Data_Root, mCurRun)
        Else
            mRunPath = objRun.Data_Path
            mCurRun = objRun.RunName
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

    ' dgp rev 5/22/08 Which flag is currently set
    Private Sub Reflect_Flag()

        Select Case RunCompare.Idx
            Case 1
                flgRun.Checked = True
            Case 2
                flgUser.Checked = True
            Case 3
                flgDate.Checked = True
            Case 4
                flgMachine.Checked = True
        End Select

    End Sub

    ' dgp rev 5/22/08 Toggle Flag for Date
    Private Sub flgDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgDate.CheckedChanged

        If (flgDate.Checked) Then
            RunCompare.Idx = 3
            Reflect_Runs()
        End If

    End Sub

    ' dgp rev 5/22/08 Toggle Flag for User
    Private Sub flgUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgUser.CheckedChanged

        If (flgUser.Checked) Then
            RunCompare.Idx = 2
            Reflect_Runs()
        End If

    End Sub

    ' dgp rev 5/22/08 Toggle Machine Sort Flag
    Private Sub flgMachine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgMachine.CheckedChanged

        If (flgMachine.Checked) Then
            RunCompare.Idx = 4
            Reflect_Runs()
        End If

    End Sub

    ' dgp rev 5/22/08 Toggle Run Sort Flag
    Private Sub flgRun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgRun.CheckedChanged

        If (flgRun.Checked) Then
            RunCompare.Idx = 1
            Reflect_Runs()
        End If

    End Sub

    Private Sub flgRecent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgRecent.CheckedChanged

        If (flgRecent.Checked) Then
            RunCompare.Idx = 5
            Reflect_Runs()
        End If

    End Sub

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

    Private Sub cmdDerived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDerived.Click

        Dim insDerivedData As New frmDerivedData
        insDerivedData.ShowDialog()

    End Sub

    ' dgp rev 4/24/2012
    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub
End Class