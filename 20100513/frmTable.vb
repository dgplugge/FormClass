' Name:     FCS File Class
' Author:   Donald G Plugge
' Date:     07/17/07
' Purpose:  

Imports System.IO
Imports FCS_Classes
Imports HelperClasses

Public Class frmTable
    Inherits System.Windows.Forms.Form

    Dim InternalTable As DataTable
    Dim CopyRow As DataTable
    Dim CopyBuffer As DataTable
    Dim objClipBoard As MyClipBoard
    Dim MyClipBoardPos(1, 1) As Int16
    Dim SelectedRows As Integer
    Friend WithEvents cmdPaste As System.Windows.Forms.Button
    Dim PasteIdx As DataGridViewSelectedRowCollection
    Dim PasteFlag As Boolean = False
    Dim cnt As Integer
    Dim DefaultColor, SelectColor As New System.Drawing.Color

    Public TableInstance As FCSTable

    Dim OldRow As Integer = 0
    Dim NewRow As Integer = 0

    Dim CurCol As Integer = 0
    Dim x_ratio As Double
    Dim y_ratio As Double
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHeading As System.Windows.Forms.TextBox
    Friend WithEvents cmdColRemove As System.Windows.Forms.Button
    Friend WithEvents cmdColAdd As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Dim ratio_flg As Boolean = False

    Friend WithEvents lblRow As System.Windows.Forms.Label
    Friend WithEvents lblCol As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRowInsert As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdInsertRows As System.Windows.Forms.Button
    Friend WithEvents ControlPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvTable As System.Windows.Forms.DataGridView
    Friend WithEvents cmdRowDelete As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdPaste = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdInsertRows = New System.Windows.Forms.Button
        Me.lblRow = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtHeading = New System.Windows.Forms.TextBox
        Me.lblCol = New System.Windows.Forms.Label
        Me.cmdColRemove = New System.Windows.Forms.Button
        Me.cmdColAdd = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdRowInsert = New System.Windows.Forms.Button
        Me.cmdRowDelete = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.ControlPanel = New System.Windows.Forms.Panel
        Me.dgvTable = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Protocol Name"
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(112, 8)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(270, 20)
        Me.txtTableName.TabIndex = 3
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(12, 19)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(67, 23)
        Me.cmdCopy.TabIndex = 7
        Me.cmdCopy.Text = "Copy"
        '
        'cmdPaste
        '
        Me.cmdPaste.Location = New System.Drawing.Point(12, 45)
        Me.cmdPaste.Name = "cmdPaste"
        Me.cmdPaste.Size = New System.Drawing.Size(67, 23)
        Me.cmdPaste.TabIndex = 9
        Me.cmdPaste.Text = "Paste"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdInsertRows)
        Me.GroupBox1.Controls.Add(Me.cmdPaste)
        Me.GroupBox1.Controls.Add(Me.cmdCopy)
        Me.GroupBox1.Controls.Add(Me.lblRow)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(85, 129)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Row Edit"
        '
        'cmdInsertRows
        '
        Me.cmdInsertRows.Location = New System.Drawing.Point(12, 71)
        Me.cmdInsertRows.Name = "cmdInsertRows"
        Me.cmdInsertRows.Size = New System.Drawing.Size(67, 23)
        Me.cmdInsertRows.TabIndex = 14
        Me.cmdInsertRows.Text = "Insert"
        '
        'lblRow
        '
        Me.lblRow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRow.Location = New System.Drawing.Point(10, 100)
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(63, 23)
        Me.lblRow.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtHeading)
        Me.GroupBox2.Controls.Add(Me.lblCol)
        Me.GroupBox2.Controls.Add(Me.cmdColRemove)
        Me.GroupBox2.Controls.Add(Me.cmdColAdd)
        Me.GroupBox2.Location = New System.Drawing.Point(196, 34)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(87, 129)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Column Edit"
        '
        'txtHeading
        '
        Me.txtHeading.Location = New System.Drawing.Point(6, 74)
        Me.txtHeading.Name = "txtHeading"
        Me.txtHeading.Size = New System.Drawing.Size(67, 20)
        Me.txtHeading.TabIndex = 1
        '
        'lblCol
        '
        Me.lblCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCol.Location = New System.Drawing.Point(6, 99)
        Me.lblCol.Name = "lblCol"
        Me.lblCol.Size = New System.Drawing.Size(67, 23)
        Me.lblCol.TabIndex = 14
        '
        'cmdColRemove
        '
        Me.cmdColRemove.Location = New System.Drawing.Point(6, 16)
        Me.cmdColRemove.Name = "cmdColRemove"
        Me.cmdColRemove.Size = New System.Drawing.Size(67, 23)
        Me.cmdColRemove.TabIndex = 10
        Me.cmdColRemove.Text = "Remove"
        '
        'cmdColAdd
        '
        Me.cmdColAdd.Location = New System.Drawing.Point(6, 45)
        Me.cmdColAdd.Name = "cmdColAdd"
        Me.cmdColAdd.Size = New System.Drawing.Size(67, 23)
        Me.cmdColAdd.TabIndex = 7
        Me.cmdColAdd.Text = "Add"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(314, 125)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(63, 32)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "Save"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdRowInsert)
        Me.GroupBox3.Controls.Add(Me.cmdRowDelete)
        Me.GroupBox3.Location = New System.Drawing.Point(105, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(85, 129)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rows"
        '
        'cmdRowInsert
        '
        Me.cmdRowInsert.Location = New System.Drawing.Point(6, 45)
        Me.cmdRowInsert.Name = "cmdRowInsert"
        Me.cmdRowInsert.Size = New System.Drawing.Size(67, 23)
        Me.cmdRowInsert.TabIndex = 11
        Me.cmdRowInsert.Text = "Insert"
        '
        'cmdRowDelete
        '
        Me.cmdRowDelete.Location = New System.Drawing.Point(6, 19)
        Me.cmdRowDelete.Name = "cmdRowDelete"
        Me.cmdRowDelete.Size = New System.Drawing.Size(67, 23)
        Me.cmdRowDelete.TabIndex = 10
        Me.cmdRowDelete.Text = "Delete"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(314, 87)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(63, 32)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        '
        'ControlPanel
        '
        Me.ControlPanel.Location = New System.Drawing.Point(6, 8)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(390, 173)
        Me.ControlPanel.TabIndex = 7
        '
        'dgvTable
        '
        Me.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTable.Location = New System.Drawing.Point(6, 187)
        Me.dgvTable.Name = "dgvTable"
        Me.dgvTable.Size = New System.Drawing.Size(390, 191)
        Me.dgvTable.TabIndex = 8
        '
        'frmTable
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 390)
        Me.Controls.Add(Me.dgvTable)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ControlPanel)
        Me.KeyPreview = True
        Me.Name = "frmTable"
        Me.Text = "Protocol Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' dgp rev 3/20/06 bind the current Protocol
    Private Sub frmTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UnhandledExceptionManager.AddHandler()

        SelectColor = Color.Beige
        DefaultColor = dgvTable.DefaultCellStyle.BackColor
        dgvTable.AllowUserToOrderColumns = True

        dgvTable.SelectionMode = DataGridViewSelectionMode.CellSelect
        'dgvTable.AutoSize = True

        txtTableName.Text = TableInstance.filename.ToLower.Replace(".xml", "")
        '        Width = 95 * TableInstance.myTable.Columns.Count
        '       dbgTable.Width = Width * 0.9

        '        dbgTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        '       dbgTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

        InternalTable = TableInstance.myTable
        '        TableInstance.myTable.Columns.Count

        Validate_InternalTable()

        CopyRow = New DataTable("Row")
        Dim idx
        For idx = 1 To InternalTable.Columns.Count
            CopyRow.Columns.Add()
        Next
        CopyRow.Rows.Add()

        dgvTable.DataSource = InternalTable
        ' dgp rev 7/23/07 disable sorting
        dgvTable.Columns(0).ReadOnly = True
        dgvTable.Rows(0).Cells.Item(0).Value = String.Format("{0:D3}", CInt(1))

        For idx = 1 To dgvTable.Columns.Count - 1
            dgvTable.Columns(idx).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        dgvTable.Refresh()
        mColMargin = (Width - dgvTable.Width)
        mRowMargin = (Height - dgvTable.Height) + mColMargin

        txtHeading.Text = "#newheader"

        Set_Ratios()

        Reflect_State()

        Prep_Column()

        '        AddHandler dbgTable.RowsRemoved, AddressOf dbgTable_RowsRemoved
        AddHandler dgvTable.SelectionChanged, AddressOf Me.dbgTable_SelectionChanged

    End Sub

    ' dgp rev 8/3/07 Catch keydown events and check for tab on last column
    Private Sub frmTable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If (Not ((e.KeyCode = Keys.Tab) Or (e.KeyCode = Keys.Enter))) Then Exit Sub

        If (dgvTable Is Nothing) Then Exit Sub
        If (dgvTable.CurrentCell Is Nothing) Then Exit Sub
        If (e.KeyCode = Keys.Tab) Then
            If (ActiveControl.Name.Contains("dgvTable")) Then
                If (dgvTable.CurrentCell.ColumnIndex = dgvTable.ColumnCount - 1) Then
                    e.Handled = True
                    Advance_Cell()
                End If
            ElseIf (ActiveControl.Name.Contains("txtHeading")) Then
                Add_Column()
                Resize_Form()
                ' dgp rev 11/12/08 prep for next column header
                Prep_Column()
                e.Handled = True
            End If
        ElseIf (e.KeyCode = Keys.Enter) Then
            ' dgp rev 11/5/08
            If (ActiveControl.Name.Contains("txtHeading")) Then
                Add_Column()
                Resize_Form()
                Prep_Column()
                e.Handled = True
            Else
                e.Handled = True
                Insert_Row()
                Resize_Form()
                ReNumber()
            End If
        End If

        Reflect_State()

    End Sub

    ' dgp rev 1/10/07 reorder the sample numbers
    Sub SMNO_Reorder()

        Dim idx As Integer
        Dim s_idx As Integer
        s_idx = InternalTable.Columns.IndexOf("$SMNO")
        For idx = 0 To InternalTable.Rows.Count - 1
            InternalTable.Rows.Item(idx).Item(s_idx) = CStr(Format(idx + 1, "000"))
        Next

    End Sub

    ' dgp rev 1/11/07 sort the DataTable with Sample first
    Sub Add_Sample_InternalTable()

        If (Not InternalTable.Columns.Contains("$SMNO")) Then

            Dim dc As DataColumn
            dc = New DataColumn("$SMNO")
            InternalTable.Columns.Add(dc)
            ' No sorting with Sample Column
            '            dbgTable.Columns.Item(dbgTable.Columns.Count - 1).SortMode = DataGridViewColumnSortMode.NotSortable
            '            dc = New DataColumn()
            '           CopyRow.Columns.Add(dc)

            SMNO_Reorder()

        End If

    End Sub

    ' dgp rev 11/30/07 Insert a new row at the curent row location
    Private Sub Insert_Row()

        Dim rowidx As Integer = dgvTable.CurrentRow.Index
        ' dgp rev 11/19/08 check row limits
        If (rowidx > InternalTable.Rows.Count - 1) Then rowidx = InternalTable.Rows.Count - 1

        ' add a row if tabbing past the last row
        Dim nr As DataRow
        nr = InternalTable.NewRow()
        Dim idx
        For idx = 0 To InternalTable.Columns.Count - 1
            nr.Item(idx) = InternalTable.Rows(rowidx).Item(idx)
        Next
        InternalTable.Rows.InsertAt(nr, rowidx)
        dgvTable.CurrentCell = dgvTable(1, rowidx + 1)

    End Sub


    ' dgp rev 11/30/07 Advance cell to next column or next row if last column
    Private Sub Advance_Cell()

        Dim rowidx As Integer = dgvTable.CurrentRow.Index
        If (rowidx = dgvTable.RowCount - 2) Then
            ' add a row if tabbing past the last row
            Add_Rows(1)
            Dim pos As Integer
            pos = InternalTable.Rows.Count
            InternalTable.Rows(pos - 1).ItemArray = InternalTable.Rows(pos - 2).ItemArray
            ReNumber()
        End If
        dgvTable.CurrentCell = dgvTable(1, dgvTable.CurrentRow.Index + 1)

    End Sub

    ' dgp rev 8/3/07 Renumber the Protocol
    Private Sub ReNumber()

        Dim idx
        For idx = 0 To InternalTable.Rows.Count - 1
            If (Not InternalTable.Rows(idx).RowState = DataRowState.Deleted) Then
                InternalTable.Rows(idx).Item(0) = String.Format("{0:D3}", idx + 1)
            End If
        Next

    End Sub
    ' 12/12/08 original source -- http://arsalantamiz.blogspot.com
    Public Sub PasteInBoundDataGridView(ByVal dgvToUse As DataGridView, ByVal bsDataGridView As BindingSource, ByVal tblSource As DataTable)
        Dim iCurrentRow As Integer = -1
        Dim bFullRowSelected As Boolean = False

        ' if some row is selected
        If dgvToUse.CurrentRow IsNot Nothing Then
            ' if it is NOT a new row
            If Not dgvToUse.CurrentRow.IsNewRow Then
                ' get the index of that row
                iCurrentRow = dgvToUse.CurrentRow.Index
            End If

            ' if current row is selected
            If dgvToUse.CurrentRow.Selected Then
                ' it means full row is selected
                bFullRowSelected = True
            End If
        End If

        ' cancel the current edit
        bsDataGridView.CancelEdit()

        Dim sText As String
        Dim sLines() As String
        Dim iCurCol As Integer

        ' if full row is selected
        If bFullRowSelected Then
            ' then set the initial column = 0
            iCurCol = 0
        Else ' else if full row is NOT selected
            ' set the initial column = current column
            iCurCol = dgvToUse.CurrentCell.ColumnIndex
        End If

        ' get the text from clipboard
        sText = My.Computer.Clipboard.GetText()
        ' split the text into lines
        sLines = sText.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
        ' for each line in extracted lines
        For Each sLine As String In sLines
            Dim sColValues() As String
            ' split the line into columns
            sColValues = sLine.Split(vbTab)

            Dim c As Integer = iCurCol
            Dim rowEdit As DataRowView

            ' if currently some middle rows are selected and also
            ' selected row is NOT the last row
            If iCurrentRow >= 0 AndAlso iCurrentRow < dgvToUse.Rows.Count - 1 Then
                ' row is selected row
                rowEdit = CType(dgvToUse.Rows(iCurrentRow).DataBoundItem, DataRowView)
                ' now move to next row
                iCurrentRow += 1
            Else ' else it means we are at end then
                ' we will add the row
                rowEdit = bsDataGridView.AddNew
            End If

            ' for each column in extracted columns
            For Each sColValue As String In sColValues
                ' if this column is bound
                If dgvToUse.Columns(c).DataPropertyName <> "" Then
                    ' if some table is mentioned and also
                    ' the column in which we are going to paste is NOT read-only
                    If tblSource Is Nothing OrElse _
                       Not tblSource.Columns(dgvToUse.Columns(c).DataPropertyName).ReadOnly Then
                        ' if extracted value is empty string
                        If sColValue = "" Then
                            ' then paste the DBNULL.value
                            rowEdit(dgvToUse.Columns(c).DataPropertyName) = DBNull.Value
                        Else ' else it means some value is mentioned
                            ' then paste that value
                            rowEdit(dgvToUse.Columns(c).DataPropertyName) = sColValue
                        End If
                    End If
                End If
                ' increase the column count
                c += 1
                ' if reached at last column then stop setting values in columns
                If c >= dgvToUse.Columns.Count Then Exit For
            Next ' next column

            ' ok row edit is complete so end it
            bsDataGridView.EndEdit()
        Next 'next line
    End Sub


    Private Sub Paste()
        Try
            If Not Me.dgvTable.IsCurrentCellInEditMode Then
                Dim bsTable As New System.Windows.Forms.BindingSource
                bsTable.DataSource = InternalTable
                Call PasteInBoundDataGridView(dgvTable, bsTable, InternalTable)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Paste")
        End Try
    End Sub

    ' dgp rev 1/10/07 validate that data Protocol
    Sub Validate_InternalTable()

        ' final file contains "$SMNO in first column, however internally
        ' the column is labeled "Tube" for the user.

        Dim idx As Integer
        ' Assure that first column contains the $SMNO or "Tube" 
        If (Not InternalTable.Columns(0).ColumnName = "Tube") Then
            If (Not InternalTable.Columns(0).ColumnName = "$SMNO") Then
                If (Not InternalTable.Columns.Contains("$SMNO")) Then
                    Add_Sample_InternalTable()
                End If
                InternalTable.Columns(InternalTable.Columns.IndexOf("$SMNO")).SetOrdinal(0)
            End If
            InternalTable.Columns(0).ColumnName = "Tube"
        End If

        ' Assure that column heading begins with "#"
        For idx = 1 To InternalTable.Columns.Count - 1
            If (InternalTable.Columns(idx).ColumnName.Substring(0, 1) <> "#") Then
                InternalTable.Columns(idx).ColumnName = "#" + InternalTable.Columns(idx).ColumnName
            End If
        Next

    End Sub
    ' dgp rev 7/23/07 Create width and height ratios
    Private Sub Set_Ratios()

        '        Dim offset As Integer = dgvTable.Location.Y - Me.Location.Y

        '       y_ratio = dgvTable.Height / (Me.Height - offset)
        '      x_ratio = dgvTable.Width / Me.Width
        '     ratio_flg = True

    End Sub

    ' dgp rev 7/23/07 Copy the Selected Row
    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click

        Dim cell As DataGridViewCell
        If (objClipBoard IsNot Nothing) Then
            For Each cell In objClipBoard.Cells
                cell.Style.BackColor = DefaultColor
            Next
        End If
        If (Not dgvTable.CurrentCell.Selected) Then Exit Sub
        objClipBoard = New MyClipBoard(dgvTable.SelectedCells)
        For Each cell In dgvTable.SelectedCells
            cell.Style.BackColor = Color.Beige
        Next

    End Sub

    Private Sub holder()

        Dim rowpos = 0
        Dim colpos = 0
        CopyBuffer = New DataTable("Buffer")
        Dim idx

        For idx = 0 To dgvTable.SelectedCells.Count - 1
            If (Not colpos = dgvTable.SelectedCells.Item(idx).ColumnIndex) Then
                colpos = dgvTable.SelectedCells.Item(idx).ColumnIndex
                CopyBuffer.Columns.Add()
            End If

            If (Not rowpos = dgvTable.SelectedCells.Item(idx).RowIndex) Then
                rowpos = dgvTable.SelectedCells.Item(idx).RowIndex
                CopyBuffer.Rows.Add()
            End If
        Next

        If CopyBuffer.Rows.Count = 1 Then
            CopyRow.Rows(0).ItemArray = InternalTable.Rows(dgvTable.CurrentCell.RowIndex).ItemArray
        Else
            Dim rowidx
            Dim colidx
            For idx = 0 To dgvTable.SelectedCells.Count - 1
                rowidx = dgvTable.SelectedCells.Item(idx).RowIndex
                colidx = dgvTable.SelectedCells.Item(idx).ColumnIndex
                '                    CopyBuffer.table.Columns.Item(colidx).Rows.Item(rowidx) = dbgTable.SelectedCells.Item(idx).Value
            Next

        End If

    End Sub

    ' dgp rev 8/2/07 Add Rows to Protocol
    Private Sub Copy_Rows(ByVal pos As Integer, ByVal cnt As Integer)

        ' starting pos and copy cnt

        Dim rowidx As Integer = InternalTable.Rows.Count
        Dim nr As DataRow
        For rowidx = 0 To cnt - 1
            nr = InternalTable.NewRow()
            Dim idx
            For idx = 0 To InternalTable.Columns.Count - 1
                nr.Item(idx) = InternalTable.Rows(rowidx).Item(idx)
            Next
            InternalTable.Rows.InsertAt(nr, rowidx)
        Next

    End Sub

    ' dgp rev 8/2/07 Replace row 'tar_pos' with data from 'src_pos' 
    Private Sub Replace_Row(ByVal src_pos As Integer, ByVal tar_pos As Integer)

        If (src_pos > InternalTable.Rows.Count - 1) Then Exit Sub
        If (tar_pos > InternalTable.Rows.Count - 1) Then Exit Sub

        InternalTable.Rows(tar_pos).ItemArray = InternalTable.Rows(src_pos).ItemArray

    End Sub

    ' dgp rev 8/2/07 Add row with data from 'pos' row
    Public Sub Add_Row(ByVal row As DataGridViewRow)

        Dim idx As Integer
        Dim nr As DataRow
        nr = InternalTable.NewRow()
        nr.Item(0) = String.Format("{0:D3}", InternalTable.Rows.Count)
        For idx = 1 To nr.ItemArray.Length - 1
            nr.Item(idx) = row.Cells.Item(idx).Value
        Next
        InternalTable.Rows.Add(nr)
        dgvTable.Refresh()

    End Sub


    ' dgp rev 8/2/07 Add row with data from 'pos' row
    Private Sub Add_Row(ByVal pos As Integer)

        Dim idx
        If (pos > InternalTable.Rows.Count) Then pos = InternalTable.Rows.Count
        Dim nr As DataRow
        nr = InternalTable.NewRow()
        For idx = 0 To InternalTable.Columns.Count - 1
            nr.Item(idx) = InternalTable.Rows(pos).Item(idx)
        Next
        InternalTable.Rows.Add(nr)

    End Sub

    ' dgp rev 11/12/08 prep for another column
    Private Sub Prep_Column()

        txtHeading.SelectionStart = 1
        txtHeading.SelectionLength = txtHeading.Text.Length - 1
        Me.ActiveControl = Me.txtHeading

    End Sub

    ' dgp rev 8/2/07 Add blank rows to Protocol
    Private Sub Add_Rows(ByVal cnt As Integer)

        Dim rowidx As Integer = InternalTable.Rows.Count
        Dim nr As DataRow
        For rowidx = 0 To cnt - 1
            nr = InternalTable.NewRow()
            ' dgp rev 11/12/08 "insertat" unless all rows have been deleted, simple add
            If (InternalTable.Rows.Count = 0) Then
                InternalTable.Rows.Add(nr)
            Else
                InternalTable.Rows.InsertAt(nr, dgvTable.CurrentRow.Index)
                InternalTable.Rows.Item(dgvTable.CurrentRow.Index - 1).ItemArray = InternalTable.Rows.Item(dgvTable.CurrentRow.Index).ItemArray
            End If
        Next

    End Sub

    ' dgp rev 11/10/08 Paste buffer into current row
    Private Sub Paste_Row()

        If (dgvTable.CurrentCell Is Nothing) Then Exit Sub
        Dim objOrig As New MyClipBoard(dgvTable.SelectedCells)

        Dim target_row
        Dim target_col
        Dim max_row = InternalTable.Rows.Count
        Dim max_col = InternalTable.Columns.Count

        Dim Offset_y = objOrig.Upper - objClipBoard.Upper
        Dim Offset_x = objOrig.Left - objClipBoard.Left

        Dim item As DataGridViewCell
        For Each item In objClipBoard.Cells
            target_col = item.ColumnIndex + Offset_x
            target_row = item.RowIndex + Offset_y
            If (target_col < max_col) And (target_row < max_row) Then
                InternalTable.Rows(target_row).Item(target_col) = item.Value
            End If
        Next

        ReNumber()

    End Sub

    ' dgp rev 11/10/08 Paste buffer into current row
    Private Sub Insert_Clipboard()

        If (dgvTable.CurrentCell Is Nothing) Then Exit Sub
        If (objClipBoard Is Nothing) Then Exit Sub

        Dim target_row
        Dim target_col
        Dim max_col = InternalTable.Columns.Count

        Dim Offset_y = InternalTable.Rows.Count - objClipBoard.Upper
        Dim Offset_x = 0
        Dim idx

        For idx = 0 To objClipBoard.RowCnt - 1
            InternalTable.Rows.Add()
        Next
        Dim max_row = InternalTable.Rows.Count

        Dim item As DataGridViewCell
        For Each item In objClipBoard.Cells
            target_col = item.ColumnIndex + Offset_x
            target_row = item.RowIndex + Offset_y
            If (target_col < max_col) And (target_row < max_row) Then
                InternalTable.Rows(target_row).Item(target_col) = item.Value
            End If
        Next

        ReNumber()

    End Sub
    ' dgp rev 7/23/07
    Private Sub cmdPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPaste.Click

        '        Paste()
        Paste_Row()


    End Sub

    ' dgp rev 7/23/07 header clicked
    Private Sub dbgTable_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        CurCol = e.ColumnIndex

    End Sub

    ' dgp rev 4/20/09 HeaderInfo as array 
    Public HeaderInfo As ArrayList

    ' dgp rev 8/3/07 Double Click Header to rename column 
    Private Sub dbgTable_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        Dim col As Integer = e.ColumnIndex

        Dim idx
        HeaderInfo = New ArrayList
        For idx = 1 To InternalTable.Columns.Count - 1
            HeaderInfo.Add(dgvTable.Columns(idx).HeaderText)
        Next

        Dim objHeader As New frmHeader
        objHeader.ShowDialog()

        Dim val As String

        For idx = 1 To InternalTable.Columns.Count - 1
            val = HeaderInfo.Item(idx - 1)
            If val.Substring(0, 1) <> "#" Then val = "#" + val
            dgvTable.Columns(idx).HeaderText = val
        Next

    End Sub

    ' dgp rev 11/10/08 Reflect the current state of the table
    Private Sub Reflect_State()

        If (dgvTable IsNot Nothing) Then
            If (dgvTable.CurrentCell IsNot Nothing) Then
                cmdCopy.Enabled = (dgvTable.CurrentCell.Selected)
            Else
                cmdCopy.Enabled = False
            End If
            cmdRowDelete.Enabled = dgvTable.Rows.Count > 1
        End If
        cmdPaste.Enabled = cmdCopy.Enabled

        If (txtHeading.Text.StartsWith("#")) Then
            cmdColAdd.Enabled = (txtHeading.Text.Length > 1)
        Else
            cmdColAdd.Enabled = (txtHeading.Text.Length > 0)
        End If

    End Sub
    ' dgp rev 7/23/07 Selection change checks for row selection
    Private Sub dbgTable_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        lblRow.Text = dgvTable.CurrentCellAddress.Y + 1
        lblCol.Text = dgvTable.CurrentCellAddress.X + 1

        ' Reflect_State()

    End Sub
    ' dgp rev 4/13/09 
    Private mColMargin As Integer
    Private mRowMargin As Integer


    ' dgp rev 4/15/09 Resizing the form
    Private Sub Resize_Form()

        ' dgp rev 4/13/09 Close Form
        Dim width As Integer = Me.Width - mColMargin
        Dim height As Integer = Me.Height - mRowMargin

        dgvTable.Width = width
        dgvTable.Height = height

        dgvTable.AutoResizeColumns()
        dgvTable.AutoResizeRows()

        dgvTable.Refresh()

    End Sub

    'dgp rev 7/23/07 resize Protocol area
    Private Sub frmTable_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

        Resize_Form()

    End Sub



    'dgp rev 7/23/07 delete selected rows
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRowDelete.Click

        Try
            dgvTable.Rows.RemoveAt(dgvTable.CurrentCell.RowIndex)
            ReNumber()
        Catch ex As Exception

        End Try

        Reflect_State()

    End Sub

    ' dgp rev 7/23/07 Remove the current column
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColRemove.Click

        Dim target As Integer = dgvTable.CurrentCell.ColumnIndex
        If (target > 0 And target < InternalTable.Columns.Count) Then
            InternalTable.Columns.RemoveAt(target)
            CopyRow.Columns.RemoveAt(target)
        End If

        Me.Refresh()

        Reflect_State()

    End Sub

    Private Sub UnhandledEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.ParentChanged

    End Sub

    ' dgp rev 11/5/08 Add a new column
    Private Sub Add_Column()

        Dim title As String = txtHeading.Text
        If (title.Substring(0, 1) <> "#") Then title = "#" + title
        If (title.Length > 1) Then
            If (InternalTable.Columns.Contains(title)) Then
                MsgBox("Duplicate Heading", MsgBoxStyle.Information)
            Else
                InternalTable.Columns.Add(title)
                dgvTable.Columns.Item(dgvTable.Columns.Count - 1).SortMode = DataGridViewColumnSortMode.NotSortable
                CopyRow.Columns.Add()
            End If
        Else
            MsgBox("Invalid Name" + title, MsgBoxStyle.Information)
            txtHeading.SelectAll()
        End If

    End Sub

    ' dgp rev 7/23/07 Add a column to Protocol
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColAdd.Click

        Add_Column()

        Resize_Form()

        Reflect_State()

    End Sub

    ' dgp rev 7/25/07 Done with editing, apply changes
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        TableInstance.filename = txtTableName.Text

        ' All done, accept changes, update Protocol parameters and include $SMNO
        InternalTable.Columns(0).ColumnName = "$SMNO"
        InternalTable.AcceptChanges()

        TableInstance.myTable = InternalTable

        TableInstance.ParCnt = TableInstance.myTable.Columns.Count
        TableInstance.Tubes = TableInstance.myTable.Rows.Count

        TableInstance.Save_Table()

        Me.Close()

    End Sub

    ' dgp rev 8/24/07 Append a new row
    Private Sub cmdAppend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRowInsert.Click

        Add_Rows(1)
        ReNumber()

        Reflect_State()

    End Sub

    ' dgp rev 11/5/08 Finalize
    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

    ' dgp rev 11/12/08 
    Private Sub dbgTable_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        OldRow = e.RowIndex

    End Sub

    ' dgp rev 11/12/08 
    Private Sub dbgTable_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        NewRow = e.RowIndex
        If (NewRow <> OldRow) Then
            If (NewRow = dgvTable.RowCount) Then Exit Sub
        End If

    End Sub

    ' dgp rev 11/12/08 
    Private Sub dbgTable_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)

        e.Row.Cells.Item(0).Value = String.Format("{0:D3}", CInt(e.Row.Index + 1))
        Dim idx
        For idx = 1 To e.Row.Cells.Count - 1
            e.Row.Cells.Item(idx).Value = dgvTable.Rows.Item(e.Row.Index - 1).Cells(idx).Value
        Next

    End Sub

    ' dgp rev 11/12/08 
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Me.Close()

    End Sub

    Private Sub cmdInsertRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertRows.Click

        Insert_Clipboard()

    End Sub

End Class
