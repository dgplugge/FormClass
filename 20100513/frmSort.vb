' Author: Donald G Plugge
' Name:   Sort Form
' Date:   5/22/08
Imports FCS_Classes

Public Class frmSort

    ' dgp rev 5/22/08 Close Form    
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private mCurRun As String = ""
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
    ' dgp rev 5/22/08 Load form and Runs
    Private Sub frmSort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

    ' dgp rev 5/22/08 Toggle Flag for Date
    Private Sub flgDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgDate.CheckedChanged

        If (flgDate.Checked) Then
            RunCompare.Idx = 3
            FlowStructure.Sort_Runs()
            Reflect_Runs()
        End If

    End Sub

    ' dgp rev 5/22/08 Toggle Flag for User
    Private Sub flgUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgUser.CheckedChanged

        If (flgUser.Checked) Then
            RunCompare.Idx = 2
            FlowStructure.Sort_Runs()
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
            FlowStructure.Sort_Runs()
            Reflect_Runs()
        End If

    End Sub

    ' dgp rev 5/22/08 Toggle Run Sort Flag
    Private Sub flgRun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgRun.CheckedChanged

        If (flgRun.Checked) Then
            RunCompare.Idx = 1
            FlowStructure.Sort_Runs()
            Reflect_Runs()
        End If

    End Sub

    Private Sub flgRecent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flgRecent.CheckedChanged

        If (flgRecent.Checked) Then
            RunCompare.Idx = 5
            FlowStructure.Sort_Runs()
            Reflect_Runs()
        End If

    End Sub
    'dgp rev 6/5/08 Set the new current run
    Private Sub lstRuns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRuns.SelectedIndexChanged

        If (Not FlowStructure.BrowseRun Is Nothing) Then FlowStructure.BrowseRun = New FCS_Classes.FCSRun(system.io.path.combine(FlowStructure.Data_Root, lstRuns.SelectedItem))
        mCurRun = lstRuns.SelectedItem

    End Sub
End Class