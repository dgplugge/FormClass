' Name:     FCS File Class
' Author:   Donald G Plugge
' Date:     07/17/07
' Purpose:  

Imports System.IO
Imports FCS_Classes
Imports HelperClasses
Imports System.Reflection

Public Class frmProtocol
    Inherits System.Windows.Forms.Form

    Dim InternalTable As DataTable

    Dim InternalDataTable As DataTable
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
    Dim PasteColor As New System.Drawing.Color

    Public FormFCSProtocol As FCSTable
    Public FormUser As String

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
    Friend WithEvents dgvProtocol As System.Windows.Forms.DataGridView
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdAppend As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdPaste = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdAppend = New System.Windows.Forms.Button()
        Me.cmdInsertRows = New System.Windows.Forms.Button()
        Me.lblRow = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtHeading = New System.Windows.Forms.TextBox()
        Me.lblCol = New System.Windows.Forms.Label()
        Me.cmdColRemove = New System.Windows.Forms.Button()
        Me.cmdColAdd = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdRowInsert = New System.Windows.Forms.Button()
        Me.cmdRowDelete = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.ControlPanel = New System.Windows.Forms.Panel()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.dgvProtocol = New System.Windows.Forms.DataGridView()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        CType(Me.dgvProtocol, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdCopy.Location = New System.Drawing.Point(12, 20)
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
        Me.cmdPaste.Text = "Replace"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdAppend)
        Me.GroupBox1.Controls.Add(Me.cmdInsertRows)
        Me.GroupBox1.Controls.Add(Me.cmdPaste)
        Me.GroupBox1.Controls.Add(Me.cmdCopy)
        Me.GroupBox1.Controls.Add(Me.lblRow)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(85, 154)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Row Edit"
        '
        'cmdAppend
        '
        Me.cmdAppend.Location = New System.Drawing.Point(12, 95)
        Me.cmdAppend.Name = "cmdAppend"
        Me.cmdAppend.Size = New System.Drawing.Size(67, 23)
        Me.cmdAppend.TabIndex = 15
        Me.cmdAppend.Text = "Append"
        '
        'cmdInsertRows
        '
        Me.cmdInsertRows.Location = New System.Drawing.Point(12, 70)
        Me.cmdInsertRows.Name = "cmdInsertRows"
        Me.cmdInsertRows.Size = New System.Drawing.Size(67, 23)
        Me.cmdInsertRows.TabIndex = 14
        Me.cmdInsertRows.Text = "Insert"
        '
        'lblRow
        '
        Me.lblRow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRow.Location = New System.Drawing.Point(12, 121)
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(67, 23)
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
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Column Edit"
        '
        'txtHeading
        '
        Me.txtHeading.AcceptsTab = True
        Me.txtHeading.Location = New System.Drawing.Point(6, 74)
        Me.txtHeading.Name = "txtHeading"
        Me.txtHeading.Size = New System.Drawing.Size(67, 20)
        Me.txtHeading.TabIndex = 0
        '
        'lblCol
        '
        Me.lblCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCol.Location = New System.Drawing.Point(6, 99)
        Me.lblCol.Name = "lblCol"
        Me.lblCol.Size = New System.Drawing.Size(67, 23)
        Me.lblCol.TabIndex = 3
        '
        'cmdColRemove
        '
        Me.cmdColRemove.Location = New System.Drawing.Point(6, 16)
        Me.cmdColRemove.Name = "cmdColRemove"
        Me.cmdColRemove.Size = New System.Drawing.Size(67, 23)
        Me.cmdColRemove.TabIndex = 10
        Me.cmdColRemove.TabStop = False
        Me.cmdColRemove.Text = "Remove"
        '
        'cmdColAdd
        '
        Me.cmdColAdd.Location = New System.Drawing.Point(6, 45)
        Me.cmdColAdd.Name = "cmdColAdd"
        Me.cmdColAdd.Size = New System.Drawing.Size(67, 23)
        Me.cmdColAdd.TabIndex = 1
        Me.cmdColAdd.TabStop = False
        Me.cmdColAdd.Text = "Add"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(308, 71)
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
        Me.GroupBox3.TabIndex = 4
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
        Me.cmdCancel.Location = New System.Drawing.Point(308, 108)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(63, 32)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        '
        'ControlPanel
        '
        Me.ControlPanel.Controls.Add(Me.cmdClose)
        Me.ControlPanel.Controls.Add(Me.cmdCancel)
        Me.ControlPanel.Controls.Add(Me.cmdSave)
        Me.ControlPanel.Controls.Add(Me.cmdPrint)
        Me.ControlPanel.Location = New System.Drawing.Point(6, 8)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Size = New System.Drawing.Size(390, 190)
        Me.ControlPanel.TabIndex = 7
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(308, 33)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(63, 32)
        Me.cmdPrint.TabIndex = 8
        Me.cmdPrint.Text = "Print"
        '
        'dgvProtocol
        '
        Me.dgvProtocol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProtocol.Location = New System.Drawing.Point(6, 204)
        Me.dgvProtocol.Name = "dgvProtocol"
        Me.dgvProtocol.Size = New System.Drawing.Size(390, 191)
        Me.dgvProtocol.TabIndex = 2
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(308, 146)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(63, 32)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.Text = "Close"
        '
        'frmProtocol
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 402)
        Me.Controls.Add(Me.dgvProtocol)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtTableName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ControlPanel)
        Me.Name = "frmProtocol"
        Me.Text = "Protocol Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ControlPanel.ResumeLayout(False)
        CType(Me.dgvProtocol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    ' dgp rev 1/6/2011 Form closing
    Private Sub frmProtocol_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If mDirtyFlag Then
            If MsgBox("Save before exiting", vbYesNo) = MsgBoxResult.Yes Then
                SaveProtocol()
            End If
        End If

    End Sub

    ' dgp rev 3/20/06 bind the current Protocol
    Private Sub frmTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UnhandledExceptionManager.AddHandler()

        SelectColor = Color.LightBlue
        PasteColor = Color.LightSalmon
        DefaultColor = dgvProtocol.DefaultCellStyle.BackColor
        dgvProtocol.AllowUserToOrderColumns = True

        dgvProtocol.SelectionMode = DataGridViewSelectionMode.CellSelect
        'dgvTable.AutoSize = True

        txtTableName.Text = FormFCSProtocol.ProtocolName.ToLower.Replace(".xml", "")
        FormFCSProtocol.ProtocolName = txtTableName.Text
        '        Width = 95 * TableInstance.myTable.Columns.Count
        '       dbgTable.Width = Width * 0.9

        '        dbgTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        '       dbgTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

        InternalDataTable = FormFCSProtocol.myTable
        '        TableInstance.myTable.Columns.Count

        Validate_InternalTable()

        CopyRow = New DataTable("Row")
        Dim idx
        For idx = 1 To InternalDataTable.Columns.Count
            CopyRow.Columns.Add()
        Next
        CopyRow.Rows.Add()

        dgvProtocol.DataSource = InternalDataTable
        ' dgp rev 7/23/07 disable sorting
        dgvProtocol.Columns(0).ReadOnly = True
        'Dim nr = InternalTable.NewRow()
        ' dgp rev 11/12/08 "insertat" unless all rows have been deleted, simple add
        'InternalTable.Rows.Add(nr)
        'dgvProtocol.Rows(0).Cells.Item(0).Value = String.Format("{0:D3}", CInt(1))

        For idx = 1 To dgvProtocol.Columns.Count - 1
            dgvProtocol.Columns(idx).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        dgvProtocol.Refresh()
        mColMargin = (Width - dgvProtocol.Width)
        mRowMargin = (Height - dgvProtocol.Height) + mColMargin
        dgvProtocol.AutoResizeColumns()
        Dim tallycol = 70
        Dim col
        For Each col In dgvProtocol.Columns
            tallycol += col.width
        Next
        Dim OrinWidth = Width
        Dim NewWidth = tallycol + mColMargin
        If NewWidth < OrinWidth Then
            Width = OrinWidth
        Else
            Width = NewWidth
        End If
        dgvProtocol.Width = tallycol
        txtHeading.Text = "#newheader"

        Set_Ratios()

        Reflect_State()

        Prep_Column()

        '        AddHandler dbgTable.RowsRemoved, AddressOf dbgTable_RowsRemoved
        '        AddHandler dgvProtocol.SelectionChanged, AddressOf Me.dbgTable_SelectionChanged

    End Sub

    ' dgp rev 7/15/2010 Handle Table Tab event
    Private Sub HandleHeaderTab()

        DebugShowMod()
        Add_Column()
        Resize_Form()
        ' dgp rev 11/12/08 prep for next column header
        Prep_Column()

    End Sub

    ' dgp rev 7/15/2010 Handle Table Tab event
    Private Sub HandleHeaderEnter()

        DebugShowMod()
        Add_Column()
        Resize_Form()
        Prep_Column()

    End Sub

    ' dgp rev 7/15/2010 Handle Table Tab event
    Private Sub HandleTableEnter()

        DebugShowMod()
        Insert_Row()
        Resize_Form()
        ReNumber()

    End Sub

    ' dgp rev 7/15/2010 Handle Table Tab event
    Private Sub HandleTabLastRowCol()

        DebugShowMod()
        ' add a row if tabbing past the last row
        Add_Rows(1)
        Dim pos As Integer
        pos = InternalDataTable.Rows.Count
        InternalDataTable.Rows(pos - 1).ItemArray = InternalDataTable.Rows(pos - 2).ItemArray
        ReNumber()
        dgvProtocol.CurrentCell = dgvProtocol(1, dgvProtocol.CurrentRow.Index)

    End Sub

    ' dgp rev 7/15/2010 Handle Table Tab event
    Private Sub HandleTableTab()

        DebugShowMod()
        ' dgp rev 7/15/2010 What if new table?  Add blank row as first
        If InternalDataTable.Rows.Count = 0 Then
            Add_Rows(1)
            Tube_Order()
            dgvProtocol.CurrentCell = dgvProtocol(1, 0)
        Else
            Dim rowidx As Integer = dgvProtocol.CurrentRow.Index
            If (dgvProtocol.CurrentCell.ColumnIndex = dgvProtocol.ColumnCount - 1) Then
                If (rowidx = InternalDataTable.Rows.Count - 1) Then
                    ' add a row if tabbing past the last row
                    Add_Rows(1)
                    Dim pos As Integer
                    pos = InternalDataTable.Rows.Count
                    InternalDataTable.Rows(pos - 1).ItemArray = InternalDataTable.Rows(pos - 2).ItemArray
                    ReNumber()
                    dgvProtocol.CurrentCell = dgvProtocol(1, dgvProtocol.CurrentRow.Index)
                Else
                    ReNumber()
                    dgvProtocol.CurrentCell = dgvProtocol(1, dgvProtocol.CurrentRow.Index + 1)
                End If
            Else
                dgvProtocol.CurrentCell = dgvProtocol(dgvProtocol.CurrentCell.ColumnIndex + 1, dgvProtocol.CurrentRow.Index)
            End If
        End If

    End Sub

    Private mCurKey As Keys

    ' dgp rev 5/18/2011 Handle the Advance 
    Private Sub HandleGridAdv()

        DebugShowMod()
        If (dgvProtocol Is Nothing) Then Exit Sub
        If (dgvProtocol.CurrentCell Is Nothing) Then Exit Sub
        If (mCurKey = Keys.Tab) Then
            HandleTableTab()
        Else
            HandleTableEnter()
        End If

        Reflect_State()

    End Sub

    ' dgp rev 5/18/2011 Handle the Advance 
    Private Sub HandleHeaderAdv()

        DebugShowMod()
        If (mCurKey = Keys.Tab) Then
            HandleHeaderTab()
        Else
            HandleHeaderEnter()
        End If

        Reflect_State()

    End Sub

    Private mCurControl As mControlType
    Private Enum mControlType
        Grid = 1
        Header = 2
    End Enum



    ' dgp rev 5/23/2011 handles the header modification textbox
    Private Sub HeaderEditKey(ByVal sender As Object, ByVal e As KeyEventArgs)

        DebugShowMod()
        Console.WriteLine(e.KeyCode + e.KeyValue)

        If ((e.KeyCode = Keys.Tab) Or (e.KeyCode = Keys.Enter)) Then
            FixNewHeader()
        End If

    End Sub

    Private sf As StackFrame
    Private mb As MethodBase
    Private mbname As String

    Private Sub DebugShowMod()

        Dim currentstack As New Diagnostics.StackTrace
        Console.WriteLine(currentstack.GetFrame(1).GetMethod.Name)

    End Sub

    ' dgp rev 5/19/2011 Heaader cell is done editing
    Private Sub FinishHeaderEdit(ByVal sender As Object, ByVal e As EventArgs)

        DebugShowMod()

        dgvProtocol.Columns.Item(mHeaderEditCol).HeaderText = sender.text
        dgvProtocol.Columns.Item(mHeaderEditCol).SortMode = DataGridViewColumnSortMode.NotSortable

        RemoveHandler mHeaderTextbox.Leave, AddressOf FinishHeaderEdit
        RemoveHandler mHeaderTextbox.TextChanged, AddressOf NewHeaderText
        mHeaderTextbox.Parent.Controls.Remove(mHeaderTextbox)

    End Sub

    Private mHeaderEditCol As Int16
    Private mHeaderTextbox As TextBox

    Private mOverrideGridEvent As Boolean = False

    ' dgp rev 5/19/2011 Mouse double click in header
    Private Sub dgvProtocol_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProtocol.ColumnHeaderMouseDoubleClick

        DebugShowMod()

        If mOverrideGridEvent Then
            mHeaderTextbox.Parent.Controls.Remove(mHeaderTextbox)
        End If

        mOverrideGridEvent = True


        mHeaderTextbox = New TextBox
        mHeaderEditCol = e.ColumnIndex
        mHeaderTextbox.TabStop = False
        mHeaderTextbox.Multiline = True
        mHeaderTextbox.AcceptsReturn = True
        mHeaderTextbox.AcceptsTab = True
        mHeaderTextbox.Location = dgvProtocol.GetCellDisplayRectangle(e.ColumnIndex, -1, True).Location
        mHeaderTextbox.Size = dgvProtocol.GetCellDisplayRectangle(e.ColumnIndex, -1, True).Size
        mHeaderTextbox.Text = dgvProtocol.Columns.Item(e.ColumnIndex).Name
        sender.controls.add(mHeaderTextbox)
        mHeaderTextbox.Focus()
        mHeaderTextbox.Refresh()

        '        AddHandler mHeaderTextbox.Leave, AddressOf FinishHeaderEdit
        '   AddHandler mHeaderTextbox.KeyDown, AddressOf HeaderEditKey
        AddHandler mHeaderTextbox.TextChanged, AddressOf NewHeaderText

        '       AddHandler mHeaderTextbox.LostFocus, AddressOf FinishHeaderEdit

    End Sub

    Private Sub dgvProtocol_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvProtocol.KeyDown

        DebugShowMod()
        If mOverrideGridEvent Then Exit Sub

        If (Not ((e.KeyCode = Keys.Tab) Or (e.KeyCode = Keys.Enter))) Then Exit Sub

        If (e.KeyCode = Keys.Enter) Then

            e.SuppressKeyPress = True

            mCurKey = e.KeyCode

            HandleTableEnter()

        End If

        If dgvProtocol.CurrentCell.RowIndex < dgvProtocol.Rows.Count - 2 Then Exit Sub

        If dgvProtocol.CurrentCell.ColumnIndex < dgvProtocol.ColumnCount - 1 Then Exit Sub

        e.SuppressKeyPress = True

        mCurKey = e.KeyCode

        HandleTabLastRowCol()

    End Sub

    ' dgp rev 8/3/07 Catch keydown events and check for tab on last column
    Private Sub GridKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        DebugShowMod()
        If mOverrideGridEvent Then Exit Sub

        If (Not ((e.KeyCode = Keys.Tab) Or (e.KeyCode = Keys.Enter))) Then Exit Sub

        If dgvProtocol.CurrentCell.RowIndex < dgvProtocol.Rows.Count - 1 Then Exit Sub

        If dgvProtocol.CurrentCell.ColumnIndex < dgvProtocol.ColumnCount - 1 Then Exit Sub

        e.SuppressKeyPress = True

        mCurKey = e.KeyCode

        mCurControl = ActiveControl.Name.Contains("dgvProtocol") + ActiveControl.Name.Contains("txtHeading") * 2

        Select Case mCurControl
            Case mControlType.Grid
                HandleGridAdv()
            Case mControlType.Header
                HandleHeaderAdv()
        End Select

    End Sub



    ' dgp rev 8/3/07 Catch keydown events and check for tab on last column
    '    Private Sub frmTable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Private Sub frmTable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        DebugShowMod()
        If (Not ((e.KeyCode = Keys.Tab) Or (e.KeyCode = Keys.Enter))) Then Exit Sub

        e.SuppressKeyPress = True

        mCurKey = e.KeyCode

        mCurControl = ActiveControl.Name.Contains("dgvProtocol") + ActiveControl.Name.Contains("txtHeading") * 2

        Select Case mCurControl
            Case mControlType.Grid
                HandleGridAdv()
            Case mControlType.Header
                HandleHeaderAdv()
        End Select

    End Sub

    ' dgp rev 1/10/07 reorder the sample numbers
    Sub Tube_Order()

        DebugShowMod()
        Dim idx As Integer
        Dim s_idx As Integer
        s_idx = InternalDataTable.Columns.IndexOf("Tube")

        For idx = 0 To InternalDataTable.Rows.Count - 1
            InternalDataTable.Rows.Item(idx).Item(s_idx) = CStr(Format(idx + 1, "000"))
            dgvProtocol.Rows(idx).HeaderCell.Value = CStr(Format(idx + 1, "000"))
        Next
        dgvProtocol.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

    End Sub

    ' dgp rev 1/10/07 reorder the sample numbers
    Sub SMNO_Reorder()

        DebugShowMod()
        Dim idx As Integer
        Dim s_idx As Integer
        s_idx = InternalDataTable.Columns.IndexOf("$SMNO")
        For idx = 0 To InternalDataTable.Rows.Count - 1
            InternalDataTable.Rows.Item(idx).Item(s_idx) = CStr(Format(idx + 1, "000"))
        Next

    End Sub

    ' dgp rev 1/11/07 sort the DataTable with Sample first
    Sub Add_Sample_InternalTable()

        DebugShowMod()
        If (Not InternalDataTable.Columns.Contains("$SMNO")) Then

            Dim dc As DataColumn
            dc = New DataColumn("$SMNO")
            InternalDataTable.Columns.Add(dc)
            ' No sorting with Sample Column
            '            dbgTable.Columns.Item(dbgTable.Columns.Count - 1).SortMode = DataGridViewColumnSortMode.NotSortable
            '            dc = New DataColumn()
            '           CopyRow.Columns.Add(dc)

            SMNO_Reorder()

        End If

    End Sub

    ' dgp rev 11/30/07 Insert a new row at the curent row location
    Private Sub Insert_Row()

        DebugShowMod()
        Dim rowidx As Integer = dgvProtocol.CurrentRow.Index
        ' dgp rev 11/19/08 check row limits
        If (rowidx > InternalDataTable.Rows.Count - 1) Then rowidx = InternalDataTable.Rows.Count - 1

        ' add a row if tabbing past the last row
        Dim nr As DataRow
        nr = InternalDataTable.NewRow()
        Dim idx
        For idx = 0 To InternalDataTable.Columns.Count - 1
            nr.Item(idx) = InternalDataTable.Rows(rowidx).Item(idx)
        Next
        InternalDataTable.Rows.InsertAt(nr, rowidx)
        dgvProtocol.CurrentCell = dgvProtocol(1, rowidx + 1)

    End Sub

    ' dgp rev 8/3/07 Renumber the Protocol
    Private Sub ReNumber()

        DebugShowMod()
        Dim idx
        For idx = 0 To InternalDataTable.Rows.Count - 1
            If (Not InternalDataTable.Rows(idx).RowState = DataRowState.Deleted) Then
                InternalDataTable.Rows(idx).Item(0) = String.Format("{0:D3}", idx + 1)
            End If
        Next

    End Sub
    ' 12/12/08 original source -- http://arsalantamiz.blogspot.com
    Public Sub PasteInBoundDataGridView(ByVal dgvToUse As DataGridView, ByVal bsDataGridView As BindingSource, ByVal tblSource As DataTable)
        DebugShowMod()
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

    ' dgp rev 8/6/2010 Paste
    Private Sub Paste()
        DebugShowMod()
        Try
            If Not Me.dgvProtocol.IsCurrentCellInEditMode Then
                Dim bsTable As New System.Windows.Forms.BindingSource
                bsTable.DataSource = InternalDataTable
                Call PasteInBoundDataGridView(dgvProtocol, bsTable, InternalDataTable)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Paste")
        End Try
    End Sub

    ' dgp rev 1/10/07 validate that data Protocol
    Sub Validate_InternalTable()

        DebugShowMod()
        ' final file contains "$SMNO in first column, however internally
        ' the column is labeled "Tube" for the user.

        Dim idx As Integer
        ' Assure that first column contains the $SMNO or "Tube" 
        If (Not InternalDataTable.Columns(0).ColumnName = "Tube") Then
            If (Not InternalDataTable.Columns(0).ColumnName = "$SMNO") Then
                If (Not InternalDataTable.Columns.Contains("$SMNO")) Then
                    Add_Sample_InternalTable()
                End If
                InternalDataTable.Columns(InternalDataTable.Columns.IndexOf("$SMNO")).SetOrdinal(0)
            End If
            InternalDataTable.Columns(0).ColumnName = "Tube"
        End If

        ' Assure that column heading begins with "#"
        For idx = 1 To InternalDataTable.Columns.Count - 1
            If (InternalDataTable.Columns(idx).ColumnName.Substring(0, 1) <> "#") Then
                InternalDataTable.Columns(idx).ColumnName = "#" + InternalDataTable.Columns(idx).ColumnName
            End If
        Next

    End Sub
    ' dgp rev 7/23/07 Create width and height ratios
    Private Sub Set_Ratios()

        DebugShowMod()
        '        Dim offset As Integer = dgvTable.Location.Y - Me.Location.Y

        '       y_ratio = dgvTable.Height / (Me.Height - offset)
        '      x_ratio = dgvTable.Width / Me.Width
        '     ratio_flg = True

    End Sub

    ' dgp rev 7/23/07 Copy the Selected Row
    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click

        DebugShowMod()
        Dim cell As DataGridViewCell
        If (objClipBoard IsNot Nothing) Then
            For Each cell In objClipBoard.Cells
                cell.Style.BackColor = DefaultColor
            Next
        End If
        If (Not dgvProtocol.CurrentCell.Selected) Then Exit Sub
        objClipBoard = New MyClipBoard(dgvProtocol.SelectedCells)
        For Each cell In dgvProtocol.SelectedCells
            cell.Style.BackColor = SelectColor
        Next

    End Sub

    Private Sub holder()

        DebugShowMod()
        Dim rowpos = 0
        Dim colpos = 0
        CopyBuffer = New DataTable("Buffer")
        Dim idx

        For idx = 0 To dgvProtocol.SelectedCells.Count - 1
            If (Not colpos = dgvProtocol.SelectedCells.Item(idx).ColumnIndex) Then
                colpos = dgvProtocol.SelectedCells.Item(idx).ColumnIndex
                CopyBuffer.Columns.Add()
            End If

            If (Not rowpos = dgvProtocol.SelectedCells.Item(idx).RowIndex) Then
                rowpos = dgvProtocol.SelectedCells.Item(idx).RowIndex
                CopyBuffer.Rows.Add()
            End If
        Next

        If CopyBuffer.Rows.Count = 1 Then
            CopyRow.Rows(0).ItemArray = InternalDataTable.Rows(dgvProtocol.CurrentCell.RowIndex).ItemArray
        Else
            Dim rowidx
            Dim colidx
            For idx = 0 To dgvProtocol.SelectedCells.Count - 1
                rowidx = dgvProtocol.SelectedCells.Item(idx).RowIndex
                colidx = dgvProtocol.SelectedCells.Item(idx).ColumnIndex
                '                    CopyBuffer.table.Columns.Item(colidx).Rows.Item(rowidx) = dbgTable.SelectedCells.Item(idx).Value
            Next

        End If

    End Sub

    ' dgp rev 8/2/07 Add Rows to Protocol
    Private Sub Copy_Rows(ByVal pos As Integer, ByVal cnt As Integer)

        ' starting pos and copy cnt

        DebugShowMod()
        Dim rowidx As Integer = InternalDataTable.Rows.Count
        Dim nr As DataRow
        For rowidx = 0 To cnt - 1
            nr = InternalDataTable.NewRow()
            Dim idx
            For idx = 0 To InternalDataTable.Columns.Count - 1
                nr.Item(idx) = InternalDataTable.Rows(rowidx).Item(idx)
            Next
            InternalDataTable.Rows.InsertAt(nr, rowidx)
        Next

    End Sub

    ' dgp rev 8/2/07 Replace row 'tar_pos' with data from 'src_pos' 
    Private Sub Replace_Row(ByVal src_pos As Integer, ByVal tar_pos As Integer)

        DebugShowMod()
        If (src_pos > InternalDataTable.Rows.Count - 1) Then Exit Sub
        If (tar_pos > InternalDataTable.Rows.Count - 1) Then Exit Sub

        InternalDataTable.Rows(tar_pos).ItemArray = InternalDataTable.Rows(src_pos).ItemArray

    End Sub

    ' dgp rev 8/2/07 Add row with data from 'pos' row
    Public Sub Add_Row(ByVal row As DataGridViewRow)

        DebugShowMod()
        Dim idx As Integer
        Dim nr As DataRow
        nr = InternalDataTable.NewRow()
        nr.Item(0) = String.Format("{0:D3}", InternalDataTable.Rows.Count)
        For idx = 1 To nr.ItemArray.Length - 1
            nr.Item(idx) = row.Cells.Item(idx).Value
        Next
        InternalDataTable.Rows.Add(nr)
        dgvProtocol.Refresh()

    End Sub


    ' dgp rev 8/2/07 Add row with data from 'pos' row
    Private Sub Add_Row(ByVal pos As Integer)

        DebugShowMod()
        Dim idx
        If (pos > InternalDataTable.Rows.Count) Then pos = InternalDataTable.Rows.Count
        Dim nr As DataRow
        nr = InternalDataTable.NewRow()
        For idx = 0 To InternalDataTable.Columns.Count - 1
            nr.Item(idx) = InternalDataTable.Rows(pos).Item(idx)
        Next
        InternalDataTable.Rows.Add(nr)

    End Sub

    ' dgp rev 11/12/08 prep for another column
    Private Sub Prep_Column()

        DebugShowMod()
        txtHeading.SelectionStart = 1
        txtHeading.SelectionLength = txtHeading.Text.Length - 1
        Me.ActiveControl = Me.txtHeading

    End Sub

    ' dgp rev 8/2/07 Add blank rows to Protocol
    Private Sub Add_Rows(ByVal cnt As Integer)

        DebugShowMod()
        Dim rowidx As Integer = InternalDataTable.Rows.Count
        Dim nr As DataRow
        For rowidx = 0 To cnt - 1
            nr = InternalDataTable.NewRow()
            ' dgp rev 11/12/08 "insertat" unless all rows have been deleted, simple add
            If (InternalDataTable.Rows.Count = 0) Then
                InternalDataTable.Rows.Add(nr)
            Else
                InternalDataTable.Rows.InsertAt(nr, dgvProtocol.CurrentRow.Index)
                InternalDataTable.Rows.Item(dgvProtocol.CurrentRow.Index - 1).ItemArray = InternalDataTable.Rows.Item(dgvProtocol.CurrentRow.Index).ItemArray
            End If
        Next

    End Sub

    ' dgp rev 11/10/08 Paste buffer into current row
    Private Sub Paste_Row()

        DebugShowMod()
        If (dgvProtocol.CurrentCell Is Nothing) Then Exit Sub
        Dim objOrig As New MyClipBoard(dgvProtocol.SelectedCells)

        Dim target_row
        Dim target_col
        Dim max_row = InternalDataTable.Rows.Count
        Dim max_col = InternalDataTable.Columns.Count

        Dim Offset_y = objOrig.Upper - objClipBoard.Upper
        Dim Offset_x = objOrig.Left - objClipBoard.Left

        Dim item As DataGridViewCell
        For Each item In objClipBoard.Cells
            target_col = item.ColumnIndex + Offset_x
            target_row = item.RowIndex + Offset_y
            If (target_col < max_col) And (target_row < max_row) Then
                InternalDataTable.Rows(target_row).Item(target_col) = item.Value
            End If
        Next

        ReNumber()

    End Sub

    Private Sub InsertNewRow()

        DebugShowMod()
        Dim rowidx As Integer = dgvProtocol.CurrentRow.Index
        ' dgp rev 11/19/08 check row limits
        If (rowidx > InternalDataTable.Rows.Count - 1) Then rowidx = InternalDataTable.Rows.Count - 1

        ' add a row if tabbing past the last row
        Dim nr As DataRow
        nr = InternalDataTable.NewRow()
        Dim idx
        For idx = 0 To InternalDataTable.Columns.Count - 1
            nr.Item(idx) = InternalDataTable.Rows(rowidx).Item(idx)
        Next
        InternalDataTable.Rows.InsertAt(nr, rowidx)
        dgvProtocol.CurrentCell = dgvProtocol(1, rowidx + 1)

    End Sub

    Private mFadeList As ArrayList

    Private Sub Fade_Cells()

        DebugShowMod()
        Threading.Thread.Sleep(1000)
        Dim cell
        For Each cell In mFadeList
            cell.style.backcolor = DefaultColor
        Next

    End Sub

    ' dgp rev 11/10/08 Paste buffer into current row
    Private Sub Insert_Clipboard()

        DebugShowMod()
        If (dgvProtocol.CurrentCell Is Nothing) Then Exit Sub
        If (objClipBoard Is Nothing) Then Exit Sub

        Dim target_row
        Dim target_col
        Dim max_col = InternalDataTable.Columns.Count
        Dim Offset_y = InternalDataTable.Rows.Count - objClipBoard.Upper
        Dim Offset_x = 0
        Dim idx
        Dim nr As DataRow

        Dim rowidx As Integer = dgvProtocol.CurrentRow.Index
        Offset_y = rowidx - objClipBoard.Upper
        ' dgp rev 11/19/08 check row limits
        If (rowidx > InternalDataTable.Rows.Count - 1) Then rowidx = InternalDataTable.Rows.Count - 1

        For idx = 0 To objClipBoard.RowCnt - 1
            ' add a row if tabbing past the last row
            nr = InternalDataTable.NewRow()
            InternalDataTable.Rows.InsertAt(nr, rowidx)
        Next
        Dim max_row = InternalDataTable.Rows.Count

        mFadeList = New ArrayList
        Dim item As DataGridViewCell
        For Each item In objClipBoard.Cells
            target_col = item.ColumnIndex
            target_row = item.RowIndex + Offset_y
            If (target_col < max_col) And (target_row < max_row) Then
                InternalDataTable.Rows(target_row).Item(target_col) = item.Value
                dgvProtocol.Item(target_col, target_row).style.backcolor = PasteColor
                mFadeList.Add(dgvProtocol.Item(target_col, target_row))
            End If
        Next
        dgvProtocol.Refresh()

        ReNumber()

        Fade_Cells()

    End Sub
    ' dgp rev 11/10/08 Paste buffer into current row
    Private Sub Append_Clipboard()

        DebugShowMod()
        If (dgvProtocol.CurrentCell Is Nothing) Then Exit Sub
        If (objClipBoard Is Nothing) Then Exit Sub

        Dim target_row
        Dim target_col
        Dim max_col = InternalDataTable.Columns.Count

        Dim Offset_y = InternalDataTable.Rows.Count - objClipBoard.Upper
        Dim Offset_x = 0
        Dim idx

        For idx = 0 To objClipBoard.RowCnt - 1
            InternalDataTable.Rows.Add()
        Next
        Dim max_row = InternalDataTable.Rows.Count

        Dim item As DataGridViewCell
        For Each item In objClipBoard.Cells
            target_col = item.ColumnIndex + Offset_x
            target_row = item.RowIndex + Offset_y
            If (target_col < max_col) And (target_row < max_row) Then
                InternalDataTable.Rows(target_row).Item(target_col) = item.Value
            End If
        Next

        ReNumber()

    End Sub
    ' dgp rev 7/23/07
    Private Sub cmdPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPaste.Click

        '        Paste()
        DebugShowMod()
        Paste_Row()


    End Sub

    ' dgp rev 7/23/07 header clicked
    Private Sub dbgTable_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        DebugShowMod()
        CurCol = e.ColumnIndex

    End Sub

    ' dgp rev 4/20/09 HeaderInfo as array 
    Public HeaderInfo As ArrayList



    ' dgp rev 8/3/07 Double Click Header to rename column 
    Private Sub dbgTable_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        DebugShowMod()
        Dim col As Integer = e.ColumnIndex

        Dim idx
        HeaderInfo = New ArrayList
        For idx = 1 To InternalDataTable.Columns.Count - 1
            HeaderInfo.Add(dgvProtocol.Columns(idx).HeaderText)
        Next

        Dim objHeader As New frmHeader
        objHeader.ShowDialog()

        Dim val As String

        For idx = 1 To InternalDataTable.Columns.Count - 1
            val = HeaderInfo.Item(idx - 1)
            If val.Substring(0, 1) <> "#" Then val = "#" + val
            dgvProtocol.Columns(idx).HeaderText = val
        Next

    End Sub

    ' dgp rev 11/10/08 Reflect the current state of the table
    Private Sub Reflect_State()

        DebugShowMod()
        If (dgvProtocol IsNot Nothing) Then
            If (dgvProtocol.CurrentCell IsNot Nothing) Then
                cmdCopy.Enabled = (dgvProtocol.CurrentCell.Selected)
            Else
                cmdCopy.Enabled = False
            End If
            cmdRowDelete.Enabled = dgvProtocol.Rows.Count > 1
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

        Console.WriteLine()
        DebugShowMod()
        lblRow.Text = dgvProtocol.CurrentCellAddress.Y + 1
        lblCol.Text = dgvProtocol.CurrentCellAddress.X + 1

        ' Reflect_State()

    End Sub
    ' dgp rev 4/13/09 
    Private mColMargin As Integer
    Private mRowMargin As Integer


    ' dgp rev 4/15/09 Resizing the form
    Private Sub Resize_Form()

        DebugShowMod()
        ' dgp rev 4/13/09 Close Form
        Dim width As Integer = Me.Width - mColMargin
        Dim height As Integer = Me.Height - mRowMargin

        dgvProtocol.Width = width
        dgvProtocol.Height = height

        dgvProtocol.AutoResizeColumns()
        dgvProtocol.AutoResizeRows()

        dgvProtocol.Refresh()

    End Sub

    'dgp rev 7/23/07 resize Protocol area
    Private Sub frmTable_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

        DebugShowMod()
        Resize_Form()

    End Sub



    'dgp rev 7/23/07 delete selected rows
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRowDelete.Click

        DebugShowMod()
        Try
            dgvProtocol.Rows.RemoveAt(dgvProtocol.CurrentCell.RowIndex)
            ReNumber()
        Catch ex As Exception

        End Try

        Reflect_State()

    End Sub

    ' dgp rev 7/23/07 Remove the current column
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColRemove.Click

        DebugShowMod()
        If dgvProtocol.Columns.Count < 3 Then Exit Sub
        Dim target As Integer = dgvProtocol.CurrentCell.ColumnIndex
        If (target > 0 And target < InternalDataTable.Columns.Count) Then
            InternalDataTable.Columns.RemoveAt(target)
            CopyRow.Columns.RemoveAt(target)
        End If

        Me.Refresh()

        Reflect_State()

    End Sub

    Private Sub UnhandledEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.ParentChanged

    End Sub

    ' dgp rev 11/5/08 Add a new column
    Private Sub Add_Column()

        DebugShowMod()
        Dim title As String = txtHeading.Text
        If (title.Substring(0, 1) <> "#") Then title = "#" + title
        If (title.Length > 1) Then
            If (InternalDataTable.Columns.Contains(title)) Then
                MsgBox("Duplicate Heading", MsgBoxStyle.Information)
            Else
                InternalDataTable.Columns.Add(title)
                dgvProtocol.Columns.Item(dgvProtocol.Columns.Count - 1).SortMode = DataGridViewColumnSortMode.NotSortable
                CopyRow.Columns.Add()
            End If
        Else
            MsgBox("Invalid Name" + title, MsgBoxStyle.Information)
            txtHeading.SelectAll()
        End If

    End Sub

    ' dgp rev 7/23/07 Add a column to Protocol
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColAdd.Click

        DebugShowMod()
        Add_Column()

        Resize_Form()

        Reflect_State()

    End Sub

    ' dgp rev 8/9/2010 Save protocol
    Private Sub SaveProtocol()

        DebugShowMod()
        ' All done, accept changes, update Protocol parameters and include $SMNO
        InternalDataTable.Columns(0).ColumnName = "$SMNO"
        InternalDataTable.AcceptChanges()

        FormFCSProtocol.myTable = InternalDataTable

        FormFCSProtocol.ParCnt = FormFCSProtocol.myTable.Columns.Count
        FormFCSProtocol.Tubes = FormFCSProtocol.myTable.Rows.Count

        FormFCSProtocol.Save_Table()
        mDirtyFlag = False

    End Sub

    ' dgp rev 7/25/07 Done with editing, apply changes
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        DebugShowMod()
        SaveProtocol()

    End Sub

    ' dgp rev 8/24/07 Append a new row
    Private Sub cmdAppend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRowInsert.Click

        DebugShowMod()
        Add_Rows(1)
        ReNumber()

        Reflect_State()

    End Sub

    ' dgp rev 11/5/08 Finalize
    Protected Overrides Sub Finalize()

        DebugShowMod()
        MyBase.Finalize()

    End Sub

    ' dgp rev 11/12/08 
    Private Sub dbgTable_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        DebugShowMod()
        OldRow = e.RowIndex

    End Sub

    ' dgp rev 11/12/08 
    Private Sub dbgTable_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        DebugShowMod()
        NewRow = e.RowIndex
        If (NewRow <> OldRow) Then
            If (NewRow = dgvProtocol.RowCount) Then Exit Sub
        End If

    End Sub

    ' dgp rev 11/12/08 
    Private Sub dbgTable_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)

        DebugShowMod()
        e.Row.Cells.Item(0).Value = String.Format("{0:D3}", CInt(e.Row.Index + 1))
        Dim idx
        For idx = 1 To e.Row.Cells.Count - 1
            e.Row.Cells.Item(idx).Value = dgvProtocol.Rows.Item(e.Row.Index - 1).Cells(idx).Value
        Next

    End Sub

    ' dgp rev 11/12/08 
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        DebugShowMod()
        Me.Close()

    End Sub

    ' dgp rev 1/6/2011
    Private Sub cmdInsertRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsertRows.Click

        DebugShowMod()
        Insert_Clipboard()

    End Sub

    ' dgp rev 1/6/2011 Dirty Flag to save edits
    Private mDirtyFlag As Boolean = False

    ' dgp rev 1/6/2011 Cell has been edited
    Private Sub dgvTable_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProtocol.CellEndEdit

        DebugShowMod()
        mDirtyFlag = True
        dgvProtocol.AutoResizeColumn(dgvProtocol.CurrentCell.ColumnIndex)
        If (dgvProtocol.CurrentCell.ColumnIndex = dgvProtocol.ColumnCount - 1) Then
            Dim rowidx = dgvProtocol.CurrentRow.Index
            If (rowidx = InternalDataTable.Rows.Count - 1) Then
                ' add a row if tabbing past the last row
                Add_Rows(1)
                Dim pos As Integer
                pos = InternalDataTable.Rows.Count
                InternalDataTable.Rows(pos - 1).ItemArray = InternalDataTable.Rows(pos - 2).ItemArray
                ReNumber()
                dgvProtocol.CurrentCell = dgvProtocol(1, dgvProtocol.CurrentRow.Index)
            Else
                ReNumber()
                dgvProtocol.CurrentCell = dgvProtocol(1, dgvProtocol.CurrentRow.Index + 1)
            End If

        End If

    End Sub

    Private mNewHeader As String

    ' dgp rev 8/22/2011 Fix the Header with New String
    Private Sub FixNewHeader()

        mOverrideGridEvent = False

        If (mNewHeader.Substring(0, 1) <> "#") Then mNewHeader = "#" + mNewHeader
        InternalDataTable.Columns.Item(mHeaderEditCol).ColumnName = mNewHeader
        '        dgvProtocol.Columns.Item(mHeaderEditCol).HeaderText = mNewHeader
        dgvProtocol.Columns.Item(mHeaderEditCol).SortMode = DataGridViewColumnSortMode.NotSortable
        If mHeaderTextbox IsNot Nothing Then
            'RemoveHandler mHeaderTextbox.KeyDown, AddressOf HeaderEditKey
            If mHeaderTextbox.Parent IsNot Nothing Then
                mHeaderTextbox.Parent.Controls.Remove(mHeaderTextbox)
            End If
        End If

    End Sub

    ' dgp rev 7/16/2010 Selection changed
    Private Sub dgvTable_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProtocol.SelectionChanged

        If mOverrideGridEvent Then FixNewHeader()

    End Sub

    ' dgp rev 8/17/2010 Protocol name
    Private Sub txtTableName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTableName.TextChanged

        DebugShowMod()
        If txtTableName.Text = "" Then
            cmdSave.Enabled = False
        Else
            cmdSave.Enabled = True
            If (HelperClasses.HelperApps.IsValidFileName(txtTableName.Text)) Then
                FormFCSProtocol.ProtocolName = txtTableName.Text
            Else
                txtTableName.Text = FormFCSProtocol.ProtocolName
            End If
        End If

    End Sub
    ' dgp rev 1/6/2011 print document
    Private mDGVPrinter As DGVPrinterHelper.DGVPrinter
    ' dgp rev 9/20/2011 use the server spec, not the full spec, in order to find the modification time
    Private Sub PrepNPrint()

        DebugShowMod()
        Dim cd As FileInfo = New FileInfo(FormFCSProtocol.ServerSpec)
        mDGVPrinter = New DGVPrinterHelper.DGVPrinter
        mDGVPrinter.PorportionalColumns = True
        '        Dim Header = "Protocol: " + FormFCSProtocol.ProtocolName + " Created: " + cd.CreationTime
        Dim header = String.Format("{0,-20}  {1,-20}  {2,10}", FormUser, FormFCSProtocol.ProtocolName, cd.LastWriteTime.ToString)

        mDGVPrinter.Title = header
        mDGVPrinter.TitleFont = New Font(System.Drawing.FontFamily.GenericSansSerif, 12, FontStyle.Bold)
        mDGVPrinter.PrintDataGridView(dgvProtocol)

    End Sub

    ' dgp rev 1/6/2011 Print the grid view
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

        DebugShowMod()
        PrepNPrint()

    End Sub

    ' dgp rev 1/7/2011 Append the Clipboard onto the end
    Private Sub cmdAppend_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAppend.Click

        DebugShowMod()
        Append_Clipboard()

    End Sub

    ' dgp rev 5/23/2011 
    Private Sub NewHeaderText(ByVal sender As Object, ByVal e As EventArgs)

        mNewHeader = sender.text

    End Sub

    ' dgp rev 8/23/2011 Close the form
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub
End Class
