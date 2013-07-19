'********************************************************************************
'Author    : Donald G Plugge
'Date      : 11/22/06
'Purpose   : Form used to select a run from internal cache
'Input     : Data_Root
'Output    : Cur_Data
'********************************************************************************
Imports FCS_Classes
Imports HelperClasses

Public Class frmRuns

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


    ' dgp rev 11/22/06 reflect the file list of selected run
    Private Sub Reflect_File_List()

        Dim sub_path As String

        lstFiles.Items.Clear()
        sub_path = system.io.path.combine(FlowStructure.Data_Root, lstRuns.SelectedItem)
        If (System.IO.Directory.Exists(sub_path)) Then
            Dim file
            For Each file In System.IO.Directory.GetFiles(sub_path)
                lstFiles.Items.Add(System.IO.Path.GetFileName(file))
            Next
        Else
            MsgBox("No folder -- " + sub_path, vbCritical)
        End If
        lstFiles.Refresh()

    End Sub

    ' dgp rev 11/17/06 load the Runs form for selecting out of a list of cached data
    ' dgp rev 5/9/07 Load Run Form
    Private Sub frmRuns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Reflect_Runs()

    End Sub

    '  dgp rev 5/9/07 Delete Selected Run from Local Cache
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

        Dim del_folder As String
        Dim del_name As String = lstRuns.SelectedItem

        del_folder = system.io.path.combine(FlowStructure.Data_Root, del_name)

        If (System.IO.Directory.Exists(del_folder)) Then

            Try
                Utility.DeleteTree(del_folder)
                lstRuns.Items.Remove(del_name)
                lstRuns.SelectedIndex = lstRuns.Items.Count - 1
            Catch ex As Exception
                MsgBox("Error Deleting Run", MsgBoxStyle.Information)
                Exit Sub
            End Try
        Else
            MsgBox("Folder not found", MsgBoxStyle.Information)
        End If

    End Sub

    '  dgp rev 5/9/07
    Private Sub cmdSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSel.Click

        FlowStructure.BrowseRun = New FCS_Classes.FCSRun(system.io.path.combine(FlowStructure.Data_Root, lstRuns.SelectedItem))
        ' unload and return to data source form
        Me.Close()

    End Sub

    ' dgp rev 11/22/06 reflect the file list of selected run
    '  dgp rev 5/9/07
    Private Sub lstRuns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRuns.SelectedIndexChanged

        FlowStructure.BrowseRun = New FCS_Classes.FCSRun(system.io.path.combine(FlowStructure.Data_Root, lstRuns.SelectedItem))

        Reflect_File_List()

    End Sub
    ' dgp rev 5/16/07 
    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click

        Me.Close()

    End Sub
End Class