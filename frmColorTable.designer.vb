<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColorTable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstTables = New System.Windows.Forms.ComboBox()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.tbColorSet = New System.Windows.Forms.TrackBar()
        Me.togDefault = New System.Windows.Forms.CheckBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.txtNewName = New System.Windows.Forms.TextBox()
        Me.cmdTrim = New System.Windows.Forms.Button()
        Me.tbTrim = New System.Windows.Forms.TrackBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTrim = New System.Windows.Forms.TextBox()
        Me.txtColorNumber = New System.Windows.Forms.TextBox()
        Me.cmdSingle = New System.Windows.Forms.Button()
        CType(Me.tbColorSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTrim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstTables
        '
        Me.lstTables.FormattingEnabled = True
        Me.lstTables.Location = New System.Drawing.Point(19, 19)
        Me.lstTables.Name = "lstTables"
        Me.lstTables.Size = New System.Drawing.Size(168, 21)
        Me.lstTables.TabIndex = 0
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(19, 52)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemove.TabIndex = 1
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(112, 52)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'tbColorSet
        '
        Me.tbColorSet.LargeChange = 10
        Me.tbColorSet.Location = New System.Drawing.Point(6, 81)
        Me.tbColorSet.Maximum = 64
        Me.tbColorSet.Name = "tbColorSet"
        Me.tbColorSet.Size = New System.Drawing.Size(104, 42)
        Me.tbColorSet.TabIndex = 3
        Me.tbColorSet.TickFrequency = 16
        '
        'togDefault
        '
        Me.togDefault.AutoSize = True
        Me.togDefault.Location = New System.Drawing.Point(112, 82)
        Me.togDefault.Name = "togDefault"
        Me.togDefault.Size = New System.Drawing.Size(90, 17)
        Me.togDefault.TabIndex = 4
        Me.togDefault.Text = "Make Default"
        Me.togDefault.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(336, 358)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = " Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 144)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(399, 179)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(12, 332)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.ReadOnly = True
        Me.txtPage.Size = New System.Drawing.Size(130, 20)
        Me.txtPage.TabIndex = 10
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(102, 45)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(75, 23)
        Me.cmdNew.TabIndex = 11
        Me.cmdNew.Text = "New"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'txtNewName
        '
        Me.txtNewName.Location = New System.Drawing.Point(6, 19)
        Me.txtNewName.Name = "txtNewName"
        Me.txtNewName.Size = New System.Drawing.Size(171, 20)
        Me.txtNewName.TabIndex = 12
        '
        'cmdTrim
        '
        Me.cmdTrim.Location = New System.Drawing.Point(102, 74)
        Me.cmdTrim.Name = "cmdTrim"
        Me.cmdTrim.Size = New System.Drawing.Size(75, 23)
        Me.cmdTrim.TabIndex = 13
        Me.cmdTrim.Text = "Trim"
        Me.cmdTrim.UseVisualStyleBackColor = True
        '
        'tbTrim
        '
        Me.tbTrim.Location = New System.Drawing.Point(6, 57)
        Me.tbTrim.Name = "tbTrim"
        Me.tbTrim.Size = New System.Drawing.Size(90, 42)
        Me.tbTrim.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbColorSet)
        Me.GroupBox1.Controls.Add(Me.cmdUpdate)
        Me.GroupBox1.Controls.Add(Me.cmdRemove)
        Me.GroupBox1.Controls.Add(Me.lstTables)
        Me.GroupBox1.Controls.Add(Me.togDefault)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(204, 129)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Palettes"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdTrim)
        Me.GroupBox2.Controls.Add(Me.txtTrim)
        Me.GroupBox2.Controls.Add(Me.cmdNew)
        Me.GroupBox2.Controls.Add(Me.tbTrim)
        Me.GroupBox2.Controls.Add(Me.txtNewName)
        Me.GroupBox2.Location = New System.Drawing.Point(222, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 129)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Create Palette"
        '
        'txtTrim
        '
        Me.txtTrim.Location = New System.Drawing.Point(6, 103)
        Me.txtTrim.Name = "txtTrim"
        Me.txtTrim.ReadOnly = True
        Me.txtTrim.Size = New System.Drawing.Size(171, 20)
        Me.txtTrim.TabIndex = 17
        '
        'txtColorNumber
        '
        Me.txtColorNumber.Location = New System.Drawing.Point(148, 332)
        Me.txtColorNumber.Name = "txtColorNumber"
        Me.txtColorNumber.ReadOnly = True
        Me.txtColorNumber.Size = New System.Drawing.Size(170, 20)
        Me.txtColorNumber.TabIndex = 17
        '
        'cmdSingle
        '
        Me.cmdSingle.Location = New System.Drawing.Point(336, 330)
        Me.cmdSingle.Name = "cmdSingle"
        Me.cmdSingle.Size = New System.Drawing.Size(75, 23)
        Me.cmdSingle.TabIndex = 18
        Me.cmdSingle.Text = "Append"
        Me.cmdSingle.UseVisualStyleBackColor = True
        '
        'frmColorTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 387)
        Me.Controls.Add(Me.cmdSingle)
        Me.Controls.Add(Me.txtColorNumber)
        Me.Controls.Add(Me.txtPage)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmColorTable"
        Me.Text = "Custom Colors"
        CType(Me.tbColorSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTrim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstTables As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents tbColorSet As System.Windows.Forms.TrackBar
    Friend WithEvents togDefault As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents txtNewName As System.Windows.Forms.TextBox
    Friend WithEvents cmdTrim As System.Windows.Forms.Button
    Friend WithEvents tbTrim As System.Windows.Forms.TrackBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTrim As System.Windows.Forms.TextBox
    Friend WithEvents txtColorNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdSingle As System.Windows.Forms.Button

End Class
