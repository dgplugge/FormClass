Imports System.IO
Imports HelperClasses

' Name:     Color Table Manipulation Form for PV-Wave
' Author:   Donald G Plugge
' Date:     2/14/2011

Public Class frmColorTable

    ' dgp rev 2/13/2011
    Private Sub frmColorTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CalcSizes()
        Threading.Thread.Sleep(500)
        ReflectInit()
        Threading.Thread.Sleep(500)
        ReflectTables()
        Threading.Thread.Sleep(500)
        lstTables.SelectedIndex = 0

    End Sub

    ' dgp rev 2/13/2011 list the existing palettes
    Private Sub ReflectTables()

        lstTables.Items.Clear()
        If ColorPalette.ValidPalettes Then
            Dim tb
            For Each tb In ColorPalette.ColorPalettes
                lstTables.Items.Add(tb)
            Next
        Else
            lstTables.Items.Add("No Color Tables")
        End If
        lstTables.SelectedIndex = 0
        lstTables.Refresh()

    End Sub

    Private mRows As Int16 = 5
    Private mCols As Int16 = 5

    Private mSquWidth
    Private mSquHeight
    Private rect As New Rectangle

    Private mPBGraphics As Graphics


    ' dgp rev 2/24/2011
    Private Sub ReflectPalette()

        Dim br As Brush
        Dim pn As Pen
        Dim r, c
        Dim cidx = 0
        pn = Pens.Pink
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim gr As Graphics = Graphics.FromImage(bm)


        '        mPBGraphics = PictureBox1.CreateGraphics
        For r = 0 To mRows - 1
            For c = 0 To mCols - 1
                If cidx >= ColorPalette.CurColorPage.Length Then
                    br = New SolidBrush(Me.BackColor)
                Else
                    br = New SolidBrush(ColorPalette.CurColorPage(cidx))
                End If
                ' create a Graphics object to draw into it
                rect.X = c * mSquWidth
                rect.Y = r * mSquHeight
                ' create a Graphics object to draw into it
                gr.FillRectangle(br, rect)
                gr.DrawRectangle(pn, rect)
                '                mPBGraphics.FillRectangle(br, rect)
                '                mPBGraphics.DrawRectangle(pn, rect)
                cidx += 1
            Next
        Next
        '        mPBGraphics.Dispose()
        ' Display the result.
        PictureBox1.Image = bm

        ' Free resources.
        br.Dispose()
        gr.Dispose()

    End Sub

    ' dgp rev 2/24/2011 reflect the initial state of the form
    Private Sub ReflectInit()

        cmdNew.Enabled = False
        togDefault.Checked = ColorPalette.DefaultFlag
        cmdUpdate.Enabled = False

    End Sub

    ' dgp rev 2/24/2011 Calculate the size of the picturebox squares
    Private Sub CalcSizes()

        ' create a Graphics object to draw into it
        ColorPalette.PageSize = mRows * mCols
        mSquWidth = PictureBox1.Width / CDbl(mCols)
        mSquHeight = PictureBox1.Height / CDbl(mRows)
        rect.Width = mSquWidth
        rect.Height = mSquHeight

    End Sub

    Private objThread As Threading.Thread

    ' dgp rev 2/24/2011
    Private Sub PickerClosed()

        Threading.Thread.Sleep(1000)
        If InvokeRequired Then
            BeginInvoke(New MethodInvoker(AddressOf PickerClosed))
        Else
            objThread = New Threading.Thread(New Threading.ThreadStart(AddressOf ReflectPalette))
            objThread.Start()
        End If

    End Sub

    ' dgp rev 2/13/2011
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click

        If MsgBox("Are you sure you want to delete this palette", vbYesNo) = MsgBoxResult.Yes Then
            Dim mess = "Failed to delete"
            If ColorPalette.RemovePalette() Then
                ColorPalette.ResetPalettes()
                ReflectTables()
                mess = "Successful Delete"
            End If
            MsgBox(mess, MsgBoxStyle.Information)
        End If

    End Sub

    ' dgp rev 2/24/2011 Change the page and reflect the new page in the picturebox
    Private Sub ReflectNewPage()

        txtPage.Text = String.Format("Page {0} of {1}", ColorPalette.PageNumber, ColorPalette.PageCount)
        txtPage.Refresh()
        ReflectPalette()

    End Sub

    ' dgp rev 2/24/2011 Change palette
    Private Sub ReflectNewPalette()

        tbColorSet.Maximum = ColorPalette.PageCount
        tbColorSet.Minimum = 1
        '        tbColorSet.TickFrequency = Math.Floor(ColorPalette.PageCount / 10.0)
        tbColorSet.TickFrequency = 1
        tbColorSet.LargeChange = 1

        mTrim = 0
        tbTrim.Maximum = ColorPalette.ColorArray.Count
        tbTrim.Minimum = 10
        tbTrim.Value = ColorPalette.ColorArray.Count
        tbTrim.TickFrequency = ColorPalette.PageSize
        txtTrim.Text = String.Format("No trimming")
        txtColorNumber.Text = String.Format("Palette contains {0} colors", ColorPalette.ColorArray.Count)


    End Sub

    ' dgp rev 2/13/2011
    Private Sub lstTables_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTables.SelectedIndexChanged

        ColorPalette.CurIndex = lstTables.SelectedIndex
        ReflectNewPage()
        ReflectNewPalette()

    End Sub

    ' dgp rev 2/13/2011
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        If ColorPalette.SavePalette() Then
            MsgBox("Successful Update", MsgBoxStyle.Information)
        Else
            MsgBox("Failed Update", MsgBoxStyle.Information)
        End If

    End Sub

    Private mOffSet As Int16


    ' dgp rev 2/13/2011 Scroll into color set
    Private Sub tbColorSet_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbColorSet.Scroll

        ColorPalette.PageNumber = tbColorSet.Value
        ReflectNewPage()

    End Sub

    ' dgp rev 2/14/2011
    Private Sub togDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles togDefault.CheckedChanged

        ColorPalette.DefaultFlag = togDefault.Checked

    End Sub

    ' dgp rev 2/14/2011
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    ' dgp rev 2/24/2011
    Class CustomPictureBox
        Inherits PictureBox

        Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(pe)
            pe.Graphics.DrawRectangle(Pens.YellowGreen, New Rectangle(0, 0, 10, 10))
        End Sub

    End Class

    Private mCurColor

    Private mPickerForm As New Form_Class.frmColorChooser

    Private Sub AppendColor()

        Dim pos = ColorPalette.ColorArray.Count
        Dim br = New SolidBrush(ColorPalette.CurColorPage(pos - 1))

        mPickerForm.Color = br.Color
        mPickerForm.ShowDialog()

        ColorPalette.AppendColor(mPickerForm.Color)

    End Sub

    Private Sub SelectColor(ByVal pos)

        Dim br = New SolidBrush(ColorPalette.CurColorPage(pos))

        mPickerForm.Color = br.Color
        mPickerForm.ShowDialog()

        If ColorPalette.ModifyColor(pos, mPickerForm.Color) Then
            cmdUpdate.Enabled = True
        End If

    End Sub

    ' dgp rev 2/24/2011
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp

        Dim row = Math.Floor(e.Y / mSquHeight) + 1
        Dim col = Math.Floor(e.X / mSquWidth) + 1

        Dim pos = ((mCols * (row - 1)) + (col - 1))
        If pos > ColorPalette.CurColorPage.Length - 1 Then
            AppendColor()
        Else
            SelectColor(pos)
        End If

        ReflectNewPage()

    End Sub

    ' dgp rev 2/24/2011 create a new table from existing palette
    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click

        Dim mess = "Failed Update"
        If ColorPalette.ChangeFilename(txtNewName.Text) Then
            If ColorPalette.SavePalette() Then
                ColorPalette.ResetPalettes()
                ReflectTables()
                mess = "Successful Update"
            End If
        End If
        MsgBox(mess, MsgBoxStyle.Information)

    End Sub

    ' dgp rev 2/24/2011
    Private Sub txtNewName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewName.TextChanged

        cmdNew.Enabled = ColorPalette.CheckFilename(txtNewName.Text)

    End Sub

    Private mTrim As Integer = 0

    ' dgp rev 2/24/2011 Trim count
    Private Sub tbTrim_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTrim.Scroll

        mTrim = ColorPalette.ColorArray.Count - tbTrim.Value
        If (mTrim = 0) Then
            cmdTrim.Enabled = False
            txtTrim.Text = String.Format("No trimming")
        Else
            cmdTrim.Enabled = True
            txtTrim.Text = String.Format("Trim the last {0} colors of {1}", mTrim, ColorPalette.ColorArray.Count)
        End If

    End Sub
    ' dgp rev 2/24/2011 Trim colors from palette
    Private Sub cmdTrim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTrim.Click

        cmdUpdate.Enabled = ColorPalette.TrimColors(mTrim)
        ReflectNewPalette()
        ReflectNewPage()

    End Sub

    Private Sub cmdSingle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSingle.Click

        AppendColor()
        ReflectNewPage()
        cmdUpdate.Enabled = True

    End Sub
End Class
