' Name:     FCS File Class
' Author:   Donald G Plugge
' Date:     07/17/07
' Purpose:  
Imports FCS_Classes
Imports HelperClasses

Public Class frmVMS

    Private Const FORMAT_MESSAGE_FROM_HMODULE = &H800

    '    Dim ftp As FTPClass
    '    Dim f As FTPFileClass

    Dim ff As FCS_FTP
    Dim LogInfoChange As Boolean = True
    Dim ListFlag As Boolean = True

    Public objRun As FCS_Classes.FCSRun

    Dim namelist() As String
    Dim preexisting_fldr As String

    Dim Depot_Target As String
    Dim Depot_Root As String

    Dim Connect_Flag As Boolean = False
    Dim Download_Flag As Boolean = False

    Dim FTP_UserName As String
    Dim FTP_Password As String
    Dim FTP_UserData As String
    Dim FTP_Run As String

    Dim Remote_Run_Path As String
    Dim Remote_Run_List As Collection

    Public Data_Change As Boolean = False

    Const MAXCHARS = 10000
    'Don't go over 50,000 (Hidden vbCrLf's count as 2 characters)

    Private Declare Function GetLastError Lib "kernel32.dll" () As Long
    Private Declare Function GetModuleHandle Lib "kernel32" Alias "GetModuleHandleA" (ByVal lpLibFileName As String) As Long

    Private Declare Function FormatMessage Lib "kernel32" Alias "FormatMessageA" _
    (ByVal dwFlags As Long, ByVal lpSource As Long, ByVal dwMessageId As Long, _
    ByVal dwLanguageId As Long, ByVal lpBuffer As String, ByVal nSize As Long, _
    ByVal Arguments As Long) As Long
    ' dgp rev 5/9/07
    ' dgp rev 2/19/08 rework logic
    Private Function vms_target() As Boolean

        Dim strTarget As String
        Dim strPath As String

        vms_target = True
        strTarget = Trim(txtUser.Text) + "_" + Trim(txtRunInfo.Text)
        strPath = FlowStructure.Data_Root

        Depot_Target = system.io.path.combine(Depot_Root, strTarget)

        ' dgp rev 2/12/08 Replace System.IO.Directory.CreateDirectory with Global Helper Create_Tree
        vms_target = Utility.Create_Tree(Depot_Target)

    End Function

    ' dgp rev 5/9/07
    Private Sub Receive()

        Dim target_path As String
        Dim target_full As String
        Dim Source As String
        Dim file As Object
        Dim noversion() As String
        Dim good_count As Integer
        Dim all_count As Integer

        all_count = 0
        good_count = 0
        ' change pointer

        target_path = Depot_Target

        If (Remote_Run_List.Count > 0) Then

            ff.SetBinaryMode(True)
            For Each file In Remote_Run_List
                all_count = all_count + 1

                Source = file
                noversion = Split(file, ";")
                target_full = target_path & "\" & noversion(0)

                ff.DownloadFile(Source, target_full, True)
                If (System.IO.file.exists(target_full)) Then
                    good_count = good_count + 1
                    txtStatus.Text = Source
                    txtStatus.Refresh()
                Else
                    MsgBox(ff.MessageString, vbAbortRetryIgnore)
                    txtStatus.Text = "Error with " & Source
                    txtStatus.Refresh()
                End If

            Next
        End If

        ' change pointer
        'frmConfig.filList.Refresh
        txtStatus.Text = txtStatus.Text + vbCrLf + CStr(good_count) + " out of " + CStr(all_count) + " successfully downloaded"
        txtStatus.Refresh()
        Download_Flag = True
        cmdConnect.Focus()
        '        cmdConnect.Text = "V&alidate"

        ' open the new folder
        'results = Shell("explorer " & frmConfig.dirList.path, vbNormalFocus)
    End Sub
    ' dgp rev 5/9/07
    Private Function user_run_exists() As Boolean

        Dim wildcard As String
        Dim pos As Long
        Dim item
        Dim fldr_name As String

        wildcard = txtUser.Text.Trim + "_" + txtRunInfo.Text.Trim

        user_run_exists = False ' assume is does not exist
        If (FlowStructure.AnyDataExists) Then
            For Each item In System.IO.Directory.GetDirectories(FlowStructure.Data_Root)
                fldr_name = System.IO.Path.GetFileName(item)
                pos = InStr(1, fldr_name, wildcard, vbTextCompare)
                Debug.Print("Position is " + CStr(pos) + " for " + fldr_name)
                If (pos > 0) Then
                    user_run_exists = True
                    preexisting_fldr = System.IO.Path.Combine(FlowStructure.Data_Root, fldr_name)
                End If
            Next
        End If

    End Function
    ' dgp rev 5/9/07
    Private Function establish() As Boolean

        Dim host As String
        Dim RealPath As String
        Dim RealDir As String
        Dim Message As String = ""

        establish = False
        If (ListFlag) Then
            Remote_Run_Path = "xyzzy_disks:[facstar1.list_data." + txtUser.Text
        Else
            Remote_Run_Path = "xyzzy_disks:[facstar1.cap_data." + txtUser.Text
        End If
        Remote_Run_Path = Remote_Run_Path + "." + txtRunInfo.Text + "]"

        host = "spiffy.nci.nih.gov"

        Dim old_curse As Cursor = Me.Cursor

        ' change the cursor to the one you want
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Windows.Forms.Cursor.Show()

        txtStatus.Text = txtStatus.Text + vbCrLf + "Attempting to connect..."
        txtStatus.Refresh()

        If (ff Is Nothing Or LogInfoChange) Then
            ff = New FCS_FTP(host, Remote_Run_Path, txtUsername.Text, txtPassword.Text, 80)
        End If

        If ff.Login() Then
            LogInfoChange = False
            If (ff.ChangeDirectory(Remote_Run_Path)) Then
                If (ff.ReturnValue = 250) Then
                    RealPath = ff.Reply.Substring(ff.Reply.IndexOf(" is ") + 4)
                    Remote_Run_Path = ff.RemotePath
                    Dim list() As String = ff.GetVMSList("*.*")
                    If (list Is Nothing) Then
                        RealDir = RealPath.Substring(0, RealPath.ToLower.IndexOf("list_data") + 10) + txtUser.Text.ToUpper
                        RealDir = RealDir + "]" + txtRunInfo.Text + ".DIR;1"
                        If (ff.RemoveDirectory(RealDir)) Then
                            Message = "Empty run path has been removed"
                            Message = Message + vbCrLf + "Re-Attempt connection"
                        Else
                            Message = "Empty run path - run removal failed"
                        End If
                    Else
                        establish = True
                        Connect_Flag = establish
                        Message = Message + vbCrLf + "Successful connection to " + host
                        Message = Message + vbCrLf + RealPath
                    End If
                Else
                    Message = "Path failure - check user and run"
                End If
            Else
                Message = "Path failure - check user and run"
            End If
        Else
            Message = "Login failure - check account and password"
        End If

        txtStatus.Text = Message
        txtStatus.Refresh()

        Windows.Forms.Cursor.Hide()
        Windows.Forms.Cursor.Current = old_curse

    End Function
    ' dgp rev 5/9/07
    Private Function files_exist() As Boolean

        files_exist = False ' assume failure

        Dim file_list() As String = ff.GetFileList("*.fcs")

        txtStatus.Text = txtStatus.Text + vbCrLf + ff.MessageString
        txtStatus.Refresh()

        If (file_list Is Nothing) Then Exit Function

        If (file_list.Length = 0) Then Exit Function

        Dim item As String

        Remote_Run_List = New Collection
        For Each item In file_list
            If (item.ToLower.Contains("fcs")) Then Remote_Run_List.Add(item)
        Next

        cmdConnect.Text = "Download " + CStr(file_list.Length - 1) + " files"
        files_exist = True

    End Function
    ' dgp rev 5/9/07
    Private Function prep_download() As Boolean

        Dim answer As Boolean
        prep_download = False
        If (Not user_run_exists()) Then
            If (vms_target()) Then
                prep_download = True
            Else
                MsgBox("No local folder for transfer", vbInformation)
            End If
        Else
            answer = MsgBox("Overwrite", vbYesNo, "Run Exists")
            Debug.Print(preexisting_fldr)
            If (answer) Then
                Utility.DeleteTree(preexisting_fldr)
                If (vms_target()) Then
                    prep_download = True
                Else
                    MsgBox("No local folder for transfer", vbInformation)
                End If
            End If
        End If

    End Function
    ' dgp rev 5/9/07
    Private Sub ftp_error()

        txtStatus.Text = txtStatus.Text + vbCrLf + ff.MessageString
        txtStatus.Refresh()
        ' Clear the message text after reporting error
        ff.MessageString = ""

    End Sub
    ' dgp rev 5/9/07
    Private Sub connectHost()

        If (establish()) Then
            If (Not files_exist()) Then
                ftp_error()
            End If
        Else
            ftp_error()
        End If

        ' change pointer

    End Sub
    ' dgp rev 5/9/07
    Private Sub disconnectHost()

        If (Not ff Is Nothing) Then
            ff.CloseConnection()
            ff = Nothing
        End If
        ' post process VMS files

    End Sub

    Private Sub Init()

        ff = Nothing
        cmdConnect.Text = "Connect to Flow Lab"
        Me.AcceptButton = cmdConnect

        Depot_Root = system.io.path.combine(system.io.Path.GetDirectoryName(FlowStructure.Data_Root), "VMS_Depot")
        Utility.Create_Tree(Depot_Root)
        Utility.Create_Tree(FlowStructure.Data_Root)

        cmdConnect.Enabled = Valid_Info()

        Connect_Flag = False
        Download_Flag = False
        Reflect_Datatype()

    End Sub
    ' dgp rev 5/9/07 
    Private Sub frmVMS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Init()

    End Sub


    ' dgp rev 5/17/07 moves only valid FCS files from source to target
    Private Sub Move_FCS_Data(ByVal source As String, ByVal target As String)

        Dim file
        Dim objFile As FCS_Classes.FCS_File

        Dim target_spec As String

        Dim Source_Path As String
        ' loop thru folder
        For Each file In System.IO.Directory.GetFiles(source)
            ' create an FCS run object
            objFile = New FCS_Classes.FCS_File(file)
            If (objFile.Valid) Then
                Try
                    target_spec = System.IO.Path.Combine(target, System.IO.Path.GetFileName(file))
                    ' once the file is moved, the object is no longer valid
                    Source_Path = file
                    System.IO.File.Move(Source_Path, target_spec)
                    '                    objLog.Log_Info(Source_Path + " to " + target_spec)
                    txtStatus.Text = target_spec
                    txtStatus.Refresh()
                Catch ex As Exception
                    '                    objLog.Log_Info(ex.Message)
                    txtStatus.Text = ex.Message
                    txtStatus.Refresh()
                End Try
            End If
        Next

    End Sub

    Public Function Run_Check(ByVal user As String, ByVal run As String) As Boolean

        Run_Check = False
        ' determine run name
        objRun.Set_User_Run(user, run)
        Dim Run_Name As String = objRun.Unique_Prefix

        If (System.IO.Directory.Exists(System.IO.Path.Combine(FlowStructure.Data_Root, Run_Name))) Then
            txtStatus.Text = txtStatus.Text + vbCrLf + "Run Exists"
            txtStatus.Refresh()
            If (MsgBox("Data Already Exists, Overwrite?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes) Then Exit Function
        End If
        Run_Check = True

    End Function
    ' dgp rev 5/9/07 determine run name and move files to data cache
    ' dgp rev 5/12/07 Move the VMS files from depot to data cache
    Private Function Validate_Data() As Boolean

        Validate_Data = False

        objRun = New FCS_Classes.FCSRun(Depot_Target)
        If (Not Run_Check(FTP_UserData, txtRunInfo.Text)) Then Exit Function

        Dim Run_Name As String = objRun.Unique_Prefix
        Dim Target_Path As String = System.IO.Path.Combine(FlowStructure.Data_Root, Run_Name)

        ' create the run target path
        Utility.Create_Tree(Target_Path)

        txtStatus.Text = txtStatus.Text + vbCrLf + "Local Data " + Target_Path
        txtStatus.Refresh()

        Move_FCS_Data(Depot_Target, Target_Path)

        ' make instance of run object as target
        objRun = New FCS_Classes.FCSRun(Target_Path)
        If (objRun.Valid_Run) Then
            Data_Change = True
            Validate_Data = True
        End If

        txtStatus.Text = txtStatus.Text + vbCrLf + "Validation Complete"
        txtStatus.Refresh()

    End Function

    Private Sub Reset()

        cmdConnect.Text = "Another Run"
        Connect_Flag = False
        Download_Flag = False

    End Sub
    ' dgp rev 5/9/07 Connect command
    ' Use the caption property to determine whether to connect or disconnect
    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click

        txtStatus.Text = ""

        If (Connect_Flag) Then
            Receive()
            If (Validate_Data()) Then
                Reset()
            Else
                MsgBox("Invalid Data", MsgBoxStyle.Information)
            End If
        Else
            If (prep_download()) Then
                connectHost()
            End If
        End If
    End Sub

    ' dgp rev 5/9/07 Run Number formatting
    Private Sub txtRun_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRun.TextChanged

        Dim sTmp As String

        sTmp = txtRun.Text.ToUpper
        sTmp.Replace("R", "")
        Try
            txtRunInfo.Text = (String.Format("R{0:D5}", CInt(sTmp)))
            cmdConnect.Enabled = True
            FTP_Run = txtRun.Text
            cmdConnect.Enabled = Valid_Info()
        Catch ex As Exception
            cmdConnect.Enabled = False
        End Try

    End Sub
    ' dgp rev 5/9/07
    Private Sub txtUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUser.GotFocus

        txtUser.SelectionStart = 0
        txtUser.SelectionLength = txtUser.Text.Length

    End Sub
    ' dgp rev 5/9/07
    Private Function Valid_Info() As Boolean

        Valid_Info = (FTP_UserName <> "" And FTP_Password <> "" And FTP_Run <> "")

    End Function

    ' dgp rev 12/10/08 Reflect Data Type
    Private Sub Reflect_Datatype()

        togList.Checked = ListFlag

    End Sub

    ' dgp rev 5/9/07 Reflect changes onto User Data
    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged

        FTP_UserName = txtUsername.Text
        txtUser.Text = FTP_UserName
        FTP_UserData = FTP_UserName
        cmdConnect.Enabled = Valid_Info()
        LogInfoChange = True

    End Sub
    ' dgp rev 5/9/07
    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

        FTP_Password = txtPassword.Text
        cmdConnect.Enabled = Valid_Info()
        LogInfoChange = True

    End Sub

    ' dgp rev 5/9/07
    Private Sub txtUser_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUser.TextChanged

        FTP_UserData = txtUser.Text
        cmdConnect.Enabled = Valid_Info()

    End Sub

    ' dgp rev 6/26/08 set current date to successful download, then exit
    Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click

        disconnectHost()
        Me.Close()

    End Sub

    ' dgp rev 12/10/08 Toggle the data type between List and CAP
    Private Sub togList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles togList.CheckedChanged

        ListFlag = togList.Checked

    End Sub
End Class