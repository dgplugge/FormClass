'********************************************************************************
'Author    : Donald G Plugge
'Date      : 7/12/07
'Purpose   : Form used to rename FCS files in working set
'********************************************************************************
Imports FCS_Classes

Public Class frmRename

    Dim flgPreview As Boolean = False
    Dim Rename_Done As Boolean = False
    Dim Match As Boolean = False
    Public flgUseCache As Boolean = False

    Public objRenameRun As FCSRun

    ' dgp rev 7/12/07 Prefix state 
    Public Enum PrefixType
        [Date_ymd] = 0
        Date_mdy = 1
    End Enum

    ' dgp rev 7/12/07 suffix state 
    Public Enum SuffixType
        [Sample] = 0
        FileOrder = 1
        BTIM = 2
    End Enum

    ' dgp rev 7/11/07
    Private Sub NewLog(ByVal txt As String)

        txtStatus.Text = txt

    End Sub

    ' dgp rev 7/11/07
    Private Sub AppendLog(ByVal txt As String)

        txtStatus.Text = txtStatus.Text + vbCrLf + txt

    End Sub

    ' dpg rev 7/11/07 reflect the buttons based upon preview state
    Private Sub Reflect_Buttons()

        cmdRename.Enabled = Not Rename_Done

    End Sub

    ' dgp rev 7/12/07 reflect the initial state
    Private Sub Reflect_State()

        togDate_ymd.Checked = (objRenameRun.PrefixState = PrefixType.Date_ymd)
        togDate_mdy.Checked = (objRenameRun.PrefixState = PrefixType.Date_mdy)
        togSample.Checked = (objRenameRun.SuffixState = SuffixType.Sample)
        togOrder.Checked = (objRenameRun.SuffixState = SuffixType.FileOrder)

    End Sub

    Private RunCache = New DataCache

    ' dgp rev 7/12/07 Load form
    Private Sub frmRename_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lstNew.DrawMode = DrawMode.OwnerDrawFixed
        lstOrig.DrawMode = DrawMode.OwnerDrawFixed
        LeftColor = Brushes.Black
        RightColor = Brushes.Gray

        ScanData()
        If (objRenameRun.Calc_New_Names()) Then
            flgPreview = True
            Match = Compare_Naming()
        Else
            flgPreview = False
        End If

        ' reflect run first, so a run is established before state
        Reflect_State()

        Reflect_Both()

    End Sub

    Private mRealList As ArrayList

    ' dgp rev 6/2/09 Reflect Real Data Filenames
    Private Sub Reflect_Results()

        lstOrig.Items.Clear()
        mRealList = New ArrayList
        If (mRealList.Count > 0) Then
            Dim item
            For Each item In mRealList
                lstOrig.Items.Add(item)
            Next
        End If
        lstOrig.Refresh()

    End Sub

    ' dgp rev 6/3/09 Scan Data for current files
    Private Sub ScanData()

        mRealList = New ArrayList
        If (objRenameRun Is Nothing) Then Exit Sub

        If (objRenameRun.WorkingDataExists) Then
            Dim item
            For Each item In System.IO.Directory.GetFiles(objRenameRun.WorkingPath)
                mRealList.Add(System.IO.Path.GetFileName(item))
            Next
        End If

    End Sub

    ' dgp rev 6/2/09 Reflect Real Data Filenames
    Private Sub Reflect_RealData()

        lstOrig.Items.Clear()
        If (objRenameRun Is Nothing) Then Exit Sub

        If (objRenameRun.WorkingDataExists) Then
            Dim item
            For Each item In mRealList
                lstOrig.Items.Add(System.IO.Path.GetFileName(item))
            Next
        End If
        lstOrig.Refresh()

    End Sub

    ' dgp rev 7/12/07 Reflect the file in the current data run
    Private Sub Reflect_CurrentName()

        lstOrig.Items.Clear()
        Dim idx
        For idx = 0 To objRenameRun.FCS_cnt - 1
            lstOrig.Items.Add(objRenameRun.FCS_Files(idx).FileName)
        Next
        lstOrig.Refresh()

    End Sub

    ' dgp rev 5/29/09 
    Private LeftColor As Brush
    Private RightColor As Brush

    ' dgp rev 5/29/09 
    Private Sub lstOrig_ChangeColor(ByVal sender As Object, _
     ByVal e As System.Windows.Forms.DrawItemEventArgs) _
     Handles lstOrig.DrawItem

        ' Draw the background of the ListBox control for each item.
        e.DrawBackground()

        ' Define the default color of the brush as black.
        Dim myBrush As Brush = LeftColor

        If (System.IO.File.Exists(System.IO.Path.Combine(objRenameRun.WorkingPath, lstOrig.Items(e.Index)))) Then
            myBrush = Brushes.Black
        Else
            myBrush = Brushes.Gray
        End If
        ' Draw the current item text based on the current 
        ' Font and the custom brush settings.
        e.Graphics.DrawString(lstOrig.Items(e.Index).ToString(), _
            e.Font, myBrush, e.Bounds, StringFormat.GenericDefault)

        ' If the ListBox has focus, draw a focus rectangle around  _ 
        ' the selected item.
        e.DrawFocusRectangle()

    End Sub

    ' dgp rev 5/29/09 Set the correct colors for the draw
    Private Sub lstNew_ChangeColor(ByVal sender As Object, _
     ByVal e As System.Windows.Forms.DrawItemEventArgs) _
     Handles lstNew.DrawItem

        ' Draw the background of the ListBox control for each item.
        e.DrawBackground()

        ' Define the default color of the brush as black.
        Dim myBrush As Brush = RightColor

        ' Draw the current item text based on the current 
        ' Font and the custom brush settings.
        If (System.IO.File.Exists(System.IO.Path.Combine(RunCache.CashDataPath, lstNew.Items(e.Index)))) Then
            myBrush = Brushes.Black
        Else
            myBrush = Brushes.Gray
        End If
        e.Graphics.DrawString(lstNew.Items(e.Index).ToString(), _
            e.Font, myBrush, e.Bounds, StringFormat.GenericDefault)

        ' If the ListBox has focus, draw a focus rectangle around  _ 
        ' the selected item.
        e.DrawFocusRectangle()

    End Sub


    Private Sub ListBox1_DrawItem(ByVal sender As Object, _
     ByVal e As System.Windows.Forms.DrawItemEventArgs)

        ' Draw the background of the ListBox control for each item.
        e.DrawBackground()

        ' Define the default color of the brush as black.
        Dim myBrush As Brush = LeftColor

        ' Determine the color of the brush to draw each item based on   
        ' the index of the item to draw.
        Dim idx = e.Index Mod 3
        Select Case idx
            Case 0
                myBrush = Brushes.Red
            Case 1
                myBrush = Brushes.Orange
            Case 2
                myBrush = Brushes.Purple
        End Select

        ' Draw the current item text based on the current 
        ' Font and the custom brush settings.
        e.Graphics.DrawString(lstNew.Items(e.Index).ToString(), _
            e.Font, myBrush, e.Bounds, StringFormat.GenericDefault)

        ' If the ListBox has focus, draw a focus rectangle around  _ 
        ' the selected item.
        e.DrawFocusRectangle()
    End Sub

    ' dgp rev 6/3/09 Reflect Both Side of the Form
    Private Sub Reflect_Both()

        Reflect_RealData()

        Reflect_Preview()

    End Sub

    Private Sub Reflect_Hold()

        lstNew.Items.Clear()

        If (Match) Then
            AppendLog("Names match")
            cmdRename.Enabled = False
            Exit Sub
        Else
            If (objRenameRun.RenameList.Count > 0) Then
                Dim item
                For Each item In objRenameRun.RenameList
                    lstNew.Items.Add(item.Value)
                Next
            End If
            cmdRename.Enabled = True
        End If

        lstNew.Refresh()
    End Sub

    ' dgp rev 7/11/07
    Private Sub Reflect_Preview()

        lstNew.Items.Clear()

        If (objRenameRun.RenameList.Count > 0) Then
            Dim item
            For Each item In objRenameRun.RenameList
                lstNew.Items.Add(item.Value)
            Next
        End If

        lstNew.Refresh()
        cmdRename.Enabled = Not Match

    End Sub

    ' dgp rev 7/11/07 compare new with old
    Private Function Compare_Naming() As Boolean

        Dim item
        Compare_Naming = True
        For Each item In objRenameRun.RenameList
            If (item.Value.ToString.ToLower <> item.Key.ToString.ToLower) Then Compare_Naming = False
        Next

    End Function
    ' dgp rev 7/11/07 preview any renaming changes
    Private Sub PrepPreview()

        Rename_Done = False
        If (objRenameRun.Calc_New_Names()) Then
            flgPreview = True
            Match = Compare_Naming()
        Else
            flgPreview = False
        End If

    End Sub

    ' dgp rev 7/12/07 Finished
    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click

        Me.Close()

    End Sub

    ' dgp rev 7/12/07 Toggle to sample state
    Private Sub togSample_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles togSample.CheckedChanged

        If (togSample.Checked) Then
            objRenameRun.SuffixState = SuffixType.Sample
            ScanData()
            PrepPreview()
            Reflect_Both()
        End If

    End Sub

    ' dgp rev 7/12/07 Toggle to file order state
    Private Sub togOrder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles togOrder.CheckedChanged

        If (togOrder.Checked) Then
            objRenameRun.SuffixState = SuffixType.FileOrder
            ScanData()
            PrepPreview()
            Reflect_Both()
        End If

    End Sub

    ' dgp rev 7/12/07 Toggle prefix to Date (yymmdd)
    Private Sub togDate_ymd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles togDate_ymd.CheckedChanged

        If (togDate_ymd.Checked) Then
            objRenameRun.PrefixState = PrefixType.Date_ymd
            ScanData()
            PrepPreview()
            Reflect_Both()
        End If

    End Sub

    ' dgp rev 7/12/07 Toggle prefix to Date (mmddyy)
    Private Sub togDate_mdy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles togDate_mdy.CheckedChanged

        If (togDate_mdy.Checked) Then
            objRenameRun.PrefixState = PrefixType.Date_mdy
            ScanData()
            PrepPreview()
            Reflect_Both()
        End If

    End Sub

    ' dgp rev 5/29/09 Reflect the renaming process
    Private Sub Reflect_RenameEvent(ByVal OldName As String, ByVal NewName As String)

        txtStatus.Text = txtStatus.Text + vbCrLf + "Rename " + OldName
        txtStatus.Text = txtStatus.Text + vbCrLf + "to " + NewName
        txtStatus.Refresh()

        '        lstNew

    End Sub

    ' dgp rev 7/11/07 Rename the original files with the preview filenames
    Private Sub cmdRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRename.Click

        ' dgp rev 5/29/09 Switch column colors and rename
        LeftColor = Brushes.Gray
        RightColor = Brushes.Black
        NewLog("Renaming files...")
        AddHandler objRenameRun.RenameEvent, AddressOf Reflect_RenameEvent
        If (objRenameRun.Rename_Files()) Then
            AppendLog("Successfully renamed " + CStr(objRenameRun.RenameCount) + " files")
            Rename_Done = True
            PrepPreview()
        Else
            AppendLog("Successfully renamed " + CStr(objRenameRun.RenameCount) + " files")
            AppendLog("with " + CStr(objRenameRun.RenameErrors) + " rename error(s)")
        End If

        Reflect_Both()
        Reflect_Buttons()

    End Sub

End Class