Imports FCS_Classes
Imports System.Xml

Public Class frmDerivedData

    Private mDataPath As String = "F:\FlowRoot\Users\plugged\Data\"

    Private Sub ReflectRuns()

        mDataPath = System.IO.Path.Combine(FlowStructure.User_Root, "Data")

        lstRuns.Items.Clear()
        If System.IO.Directory.Exists(mDataPath) Then
            lstRuns.Items.Add("Select Derived Run")
            Dim item
            For Each item In System.IO.Directory.GetDirectories(mDataPath)
                lstRuns.Items.Add(System.IO.Path.GetFileName(item))
            Next
        Else
            lstRuns.Items.Add("No Derived Data")
        End If
        lstRuns.SelectedIndex = 0
        lstRuns.Refresh()

    End Sub

    Private Sub frmDerivedData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ReflectRuns()

    End Sub

    Private mDataInfo
    Private mBranchDS As DataSet

    ' dgp rev 2/15/2011 
    Private Sub CreateGrid(ByVal name)

        mDataInfo = System.IO.Path.Combine(mDataPath, name)
        mDataInfo = System.IO.Path.Combine(mDataInfo, "DataInfo.xml")

        If System.IO.File.Exists(mDataInfo) Then

            Dim Doc = New XmlDocument
            Try
                mBranchDS = New DataSet()
                mBranchDS.ReadXml(mDataInfo)
                Try
                    With (dg_branches) ' the datagridview
                        .DataSource = mBranchDS
                        .DataMember = "Clusters"
                        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                        .AutoSize = True
                        .EditMode = DataGridViewEditMode.EditOnEnter
                    End With
                Catch ex As Exception
                    MsgBox("Branch XML File Could Not Be Loaded: " & ex.Message)
                End Try
                '                    Doc.Load(mDataInfo)
            Catch ex As Exception

                MsgBox("Load Error " + mDataInfo)
                Return

            End Try

        End If

    End Sub

    Private Sub populateTreeControl( _
      ByVal document As System.Xml.XmlNode, _
      ByVal nodes As  _
      System.Windows.Forms.TreeNodeCollection)

        Dim node As System.Xml.XmlNode
        For Each node In document.ChildNodes
            ' If the element has a value, display it; 
            ' otherwise display the first attribute 
            ' (if there is one) or the element name 
            ' (if there isn't)
            Dim [text] As String
            If node.Value <> Nothing Then
                [text] = node.Value
            Else
                If Not node.Attributes Is Nothing And _
                   node.Attributes.Count > 0 Then
                    [text] = node.Attributes(0).Value
                Else
                    [text] = node.Name
                End If
            End If

            Dim new_child As New TreeNode([text])
            nodes.Add(new_child)
            populateTreeControl(node, new_child.Nodes)
        Next node
    End Sub


    Private Sub CreateTree(ByVal name)

        mDataInfo = System.IO.Path.Combine(mDataPath, name)
        mDataInfo = System.IO.Path.Combine(mDataInfo, "DataInfo.xml")

        If System.IO.File.Exists(mDataInfo) Then

            Dim Doc = New XmlDocument
            Try
                Dim document As New System.Xml.XmlDataDocument()
                document.Load(mDataInfo)
                populateTreeControl(document.DocumentElement, _
                   TreeView1.Nodes)
            Catch ex As Exception

                MsgBox("Load Error " + mDataInfo)
                Return

            End Try

        End If

    End Sub

    Private Sub lstRuns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRuns.SelectedIndexChanged

        If lstRuns.SelectedIndex > 0 Then

            '           CreateGrid(lstRuns.SelectedItem)
            CreateTree(lstRuns.SelectedItem)

        End If

    End Sub

    Private Sub TreeView1_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand

        Dim kid
        For Each kid In e.Node.Nodes
            If (kid.Text = "Annotations") Then
                TextBox1.Text = ""
                If (kid.firstnode IsNot Nothing) Then
                    TextBox1.Text = kid.firstnode.text()
                End If
            End If
        Next

    End Sub

    Private Sub TreeView1_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        Dim kid
        For Each kid In e.Node.Nodes
            If (kid.Text = "Annotations") Then
                TextBox1.Text = ""
                If (kid.firstnode IsNot Nothing) Then
                    TextBox1.Text = kid.firstnode.text()
                End If
            End If
        Next



    End Sub
End Class