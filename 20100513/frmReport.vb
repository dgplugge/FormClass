' Name:     Report Form
' Author:   Donald G Plugge
' Date:     5/19/09
Imports FCS_Classes

Public Class frmReport

    Dim DataSet As DataSet
    Dim KeyList As ArrayList
    Dim TableInfo As ArrayList
    Dim AllKeys As ArrayList

    ' dgp rev Run and Sort order may be predefined, otherwise use global settings
    Public Report_Run As FCS_Classes.FCSRun
    Public RunOrder As ArrayList

    Dim New_Key As String

    ' dgp rev 6/14/07 fill the table with header data
    Private Sub Fill_Table()

        Dim run_idx
        Dim key_idx

        Dim key As String
        Dim val As String

        For run_idx = 0 To Report_Run.FCS_cnt - 1
            For key_idx = 0 To KeyList.Count - 1
                key = KeyList.Item(key_idx).ToString
                val = Report_Run.FCS_Files(run_idx).Header.Item(key)
                dgvReport.Rows.Item(run_idx).Cells(key_idx).value = val
            Next
        Next

    End Sub

    ' dgp rev 6/14/07 fill the table with header data
    Private Sub Fill_Column(ByVal key As String, ByVal col As Integer)

        Dim run_idx
        Dim val As String

        For run_idx = 0 To Report_Run.FCS_cnt - 1
            val = Report_Run.FCS_Files(run_idx).Header.Item(key)
            dgvReport.Rows.Item(run_idx).Cells(col).Value = val
        Next

    End Sub
    ' dgp rev 6/14/07 Retrieve the Keys
    Private Sub Extract_Keys()

        TableInfo = New ArrayList
        AllKeys = New ArrayList

        Dim item As String

        For Each item In Report_Run.FCS_Files(0).Header.Keys
            AllKeys.Add(item)
            If (item.StartsWith("#")) Then TableInfo.Add(item)
        Next

    End Sub

    ' dgp rev 6/14/07 Retrieve the Keys
    Private Sub Reflect_Keys()

        lstKeys.Items.Clear()
        Dim item As String

        For Each item In AllKeys
            lstKeys.Items.Add(item)
        Next
        If (lstKeys.Items.Count > 0) Then lstKeys.SelectedIndex = 0
        lstKeys.Refresh()

    End Sub

    ' dgp rev 6/14/07 Retrieve the Keys
    Private Sub Create_Header()

        Dim idx = 0
        For idx = 0 To KeyList.Count - 1
            dgvReport.Columns.Item(idx).HeaderText = KeyList.Item(idx).ToString
        Next

    End Sub

    ' dgp rev 6/14/07 Build the key list
    Private Sub Build_Columns()

        KeyList = New ArrayList

        KeyList.Add("$FIL")
        KeyList.Add("$TOT")
        Dim item
        For Each item In TableInfo
            KeyList.Add(item)
        Next

    End Sub

    ' dgp rev 6/14/07 Retrieve the Keys
    Private Sub Create_Report()

        If (Report_Run.FCS_cnt = 0) Then
            MsgBox("No FCS files in " + Report_Run.UniqueName, MsgBoxStyle.Information)
            Exit Sub
        End If

        Extract_Keys()

        Build_Columns()

        dgvReport.ColumnCount = KeyList.Count

        dgvReport.RowCount = Report_Run.FCS_cnt

        Create_Header()

        Fill_Table()

        Reflect_Keys()

        Resize_View()

        dgvReport.Refresh()

    End Sub

    ' dgp rev 6/14/07 Retrieve the Keys
    Private Sub RunReport()

        Dim fcs_file As FCS_Classes.FCS_File
        Dim idx As Integer
        For idx = 0 To Report_Run.FCS_cnt - 1
            fcs_file = Report_Run.FCS_Files(idx)
            '            dgvReport.Rows.Item(idx)
        Next

    End Sub

    ' dgp rev Reflect all internal runs with current data selected
    ' xyzzy 
    Private Sub Reflect_Runs()

        Dim item
        lstRuns.Items.Clear()
        Dim run = Report_Run.MDT_UR

        For Each item In RunOrder
            lstRuns.Items.Add(item)
            If (item.ToString.ToLower.Contains(run.ToString.ToLower)) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
        Next
        If (lstRuns.SelectedIndex = -1) Then lstRuns.SelectedIndex = lstRuns.Items.Count - 1
        lstRuns.Refresh()

    End Sub

    ' dgp rev 5/19/09 Initialize Structure
    Private Function Init() As Boolean

        If (RunOrder Is Nothing) Then RunOrder = FlowStructure.RunArray
        If Report_Run Is Nothing Then Report_Run = New FCSRun(FlowStructure.DefaultRun.Orig_Path)

        Return Report_Run.Valid_Run

    End Function

    ' dgp rev 6/14/07 Retrieve the Keys
    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If (Init()) Then
            Reflect_Runs()
        Else
            MsgBox("Invalid run " + Report_Run.Orig_Path, MsgBoxStyle.Information)
            Me.Close()
        End If

    End Sub

    ' dgp rev 6/14/07 Select a new key to insert
    Private Sub lstKeys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstKeys.SelectedIndexChanged

        New_Key = lstKeys.SelectedItem

        Reflect_Buttons()

    End Sub

    ' dgp rev 6/14/07 Insert a new column
    Private Sub cmdInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsert.Click

        dgvReport.Columns.Add(New_Key, New_Key)

        KeyList.Add(New_Key)

        Fill_Column(New_Key, dgvReport.Columns.Count - 1)

        Reflect_Buttons()

        Resize_View()

    End Sub
    ' dgp rev 6/14/07 Reflect the state of the insert and delete buttons
    Private Sub Reflect_Buttons()

        cmdDelete.Enabled = KeyList.Contains(New_Key)
        cmdInsert.Enabled = Not cmdDelete.Enabled
        If (cmdInsert.Enabled) Then
            Me.AcceptButton = cmdInsert
        Else
            Me.AcceptButton = cmdDelete
        End If

    End Sub

    ' dgp rev 6/14/07 Double click to set key
    Private Sub dgvReport_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvReport.ColumnHeaderMouseDoubleClick

        Dim key As String = dgvReport.Columns(e.ColumnIndex).HeaderText
        Dim idx As Integer = lstKeys.Items.IndexOf(key)
        lstKeys.SelectedIndex = idx

    End Sub

    ' dgp rev 6/14/07 Resize the display based upon column count
    Private Sub Resize_View()

        dgvReport.Width = (KeyList.Count + 1) * 100
        lstRuns.Width = dgvReport.Width
        dgvReport.Refresh()
        Me.Width = dgvReport.Width * 1.03

    End Sub

    ' dgp rev 6/14/07 Delete a value
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

        dgvReport.Columns.RemoveAt(KeyList.IndexOf(New_Key))

        KeyList.Remove(New_Key)

        Reflect_Buttons()

        Resize_View()

    End Sub
    ' dgp rev 6/14/07 Close the form
    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click

        Me.Close()

    End Sub

    ' dgp rev 7/16/07 Select a new Run to report
    Private Sub lstRuns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRuns.SelectedIndexChanged

        Report_Run = New FCS_Classes.FCSRun(System.IO.Path.Combine(FlowStructure.Data_Root, lstRuns.SelectedItem))

        Create_Report()

    End Sub
End Class