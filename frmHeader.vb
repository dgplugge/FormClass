' Name:     FCS File Class
' Author:   Donald G Plugge
' Date:     07/17/07
' Purpose:  
Imports FCS_Classes

Public Class frmHeader
    Inherits System.Windows.Forms.Form

    Friend HeaderInfo As ArrayList

    Private _txtbox As ArrayList
    Private _txtbox_cnt As Int16 = 0
    Private _group As GroupBox

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
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdCreate = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdCreate
        '
        Me.cmdCreate.Enabled = False
        Me.cmdCreate.Location = New System.Drawing.Point(130, 12)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(72, 48)
        Me.cmdCreate.TabIndex = 1
        Me.cmdCreate.Text = "Update"
        '
        'frmHeader
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.cmdCreate)
        Me.Name = "frmHeader"
        Me.Text = "Headings"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' dgp rev 3/20/06 list the current heading information
    Private Sub frmHeader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmdCreate.Enabled = True
        reflect_headers()

    End Sub

    ' dgp rev 8/3/07 create a textbox for each header title
    Private Sub reflect_headers()

        Dim idx As Int16
        Dim pcnt As Int16 = HeaderInfo.Count
        Dim arr As New ArrayList
        Dim ystart As Int16 = 16
        Dim xstart As Int16 = 10
        Dim ypos As Int16

        If (_group Is Nothing) Then
            _group = New GroupBox
            _group.Width = 100
            _group.Location = New System.Drawing.Point(xstart - 2, ystart - 2)
            Me.Controls.Add(_group)
        End If

        If (_txtbox_cnt < pcnt) Then
            For idx = pcnt - (pcnt - _txtbox_cnt) To pcnt - 1
                ' new textbox
                ypos = ystart + idx * 20
                Dim tmp As New TextBox
                tmp.Location = New System.Drawing.Point(xstart, ypos)
                tmp.Name = "txtParam" + CStr(idx)
                tmp.Size = New System.Drawing.Size(88, 20)
                tmp.TabIndex = idx + 1
                tmp.Text = HeaderInfo.Item(idx)
                _group.Controls.Add(tmp)
            Next
            _txtbox_cnt = _group.Controls.Count
            _group.Height = ypos + 20 + 10
        ElseIf (_txtbox_cnt > pcnt) Then
            Dim name As String
            For idx = _txtbox_cnt To pcnt + 1 Step -1
                ' remove excess
                name = HeaderInfo.Item(idx)
                _group.Controls.Remove(_group.Controls.Item(idx - 1))
            Next
            _txtbox_cnt = _group.Controls.Count
            _group.Height = ystart + pcnt * 20 + 24
        End If
        _group.Refresh()

    End Sub

    ' dgp rev 8/3/07 Update the Protocol heading information
    Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click

        Dim idx
        Dim ctl As Control
        'HeaderInfo = New ArrayList
        Dim chk As New ArrayList
        Dim val As String

        For idx = 0 To _group.Controls.Count - 1
            ctl = _group.Controls.Item(idx)
            If (ctl.Name.ToLower.Contains("txtparam")) Then
                val = _group.Controls.Item(idx).Text
                If val.Substring(0, 1) <> "#" Then val = "#" + val
                If (chk.Contains(val)) Then
                    MsgBox("Duplicate header values", MsgBoxStyle.Information)
                    Exit Sub
                End If
                chk.Add(val)
            End If
        Next

        HeaderInfo = chk
        Me.Close()

    End Sub

End Class
