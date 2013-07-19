' Author: Donald G Plugge
' Name:   Sort Form
' Date:   5/22/08
Imports FCS_Classes

Public Class frmSort

    Public objRun As FCSRun
    Private mRunPath As String = ""
    Private mRunArray As ArrayList
    Private mCurRun As String = ""

    ' dgp rev 5/22/08 Close Form    
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    ' dgp rev 12/4/07 Reflect the sorted runs
    Private Sub Reflect_Runs()

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

    ' dgp rev 5/13/2010 Look at objRun, then SourcePath, finally use default
    Private Sub Prep()

        If objRun Is Nothing Then
            mDataRoot = FlowStructure.Data_Root
            mRunArray = FlowStructure.RunArray
            mCurRun = mRunArray(0)
            mRunPath = System.IO.Path.Combine(mDataRoot, mCurRun)
        Else
            mDataRoot = System.IO.Path.GetDirectoryName(objRun.Data_Path)
            mRunPath = objRun.Data_Path
            mCurRun = objRun.RunName
            mRunArray = New ArrayList
            If System.IO.Directory.Exists(mDataRoot) Then
                Dim item
                For Each item In System.IO.Directory.GetDirectories(mDataRoot)
                    mRunArray.Add(System.IO.Path.GetFileName(item))
                Next
            Else
                mRunArray = FlowStructure.RunArray
            End If
        End If

    End Sub

    ' dgp rev 5/22/08 Load form and Runs
    Private Sub frmSort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Prep()
        Reflect_Flag()

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

    ' dgp rev 5/22/08 Toggle Flag for Date
    Private Sub flgDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgDate.CheckedChanged

        If (flgDate.Checked) Then
            RunCompare.Idx = 3
            Sort_Runs()
            Reflect_Runs()
        End If

    End Sub

    ' dgp rev 5/22/08 Toggle Flag for User
    Private Sub flgUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgUser.CheckedChanged

        If (flgUser.Checked) Then
            RunCompare.Idx = 2
            Sort_Runs()
            Reflect_Runs()
        End If

    End Sub
    ' dgp rev 5/22/08 Reload Data Runs
    Private Sub cmdReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReload.Click

        FlowStructure.Reset_Runs()
        Reflect_Runs()

    End Sub

    ' dgp rev 5/22/08 Toggle Machine Sort Flag
    Private Sub flgMachine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgMachine.CheckedChanged

        If (flgMachine.Checked) Then
            RunCompare.Idx = 4
            Sort_Runs()
            Reflect_Runs()
        End If

    End Sub

    ' dgp rev 5/22/08 Toggle Run Sort Flag
    Private Sub flgRun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgRun.CheckedChanged

        If (flgRun.Checked) Then
            RunCompare.Idx = 1
            Sort_Runs()
            Reflect_Runs()
        End If

    End Sub

    Private Sub flgRecent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgRecent.CheckedChanged

        If (flgRecent.Checked) Then
            RunCompare.Idx = 5
            Sort_Runs()
            Reflect_Runs()
        End If

    End Sub

    'dgp rev 6/5/08 Set the new current run
    Private Sub lstRuns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRuns.SelectedIndexChanged

        mCurRun = lstRuns.SelectedItem
        mRunPath = System.IO.Path.Combine(mDataRoot, mCurRun)

    End Sub

    Private Sub cmdSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelect.Click

        objRun = New FCSRun(mRunPath)
        Me.Close()

    End Sub
End Class