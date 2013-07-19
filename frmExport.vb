Imports System.IO
Imports System.Collections.Specialized
'Imports Microsoft.Office.Core
Imports PowerPointMe = Microsoft.Office.Interop.PowerPoint
Imports FCS_Classes
Imports OfficeLibrary

' dgp rev 7/23/08 Export Form for PowerPoint configuration
Public Class frmExport

    Private Sub Append_Status(ByVal text As String)

        txtStatus.Text = txtStatus.Text + vbCrLf + text

    End Sub

    Private Sub Reflect_Count()

        NumericRows.Value = ExportPVW.ExportRows
        NumericColumns.Value = ExportPVW.Cols

    End Sub

    ' dgp rev 7/17/08 
    Private Sub cmdTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest.Click

        Dim TestStatus As Boolean = True

        ' dgp rev 7/17/08 Test PowerPower Connectivity
        Append_Status("Attempting to find PowerPoint")
        Dim ppApp As Microsoft.Office.Interop.PowerPoint.Application

        Try
            ppApp = CreateObject("Powerpoint.Application")
        Catch ex As Exception
            ppApp = Nothing
            TestStatus = False
            Append_Status("PowerPoint Error")
            Append_Status(ex.Message.ToString)
        End Try

        If (Not ppApp Is Nothing) Then

            If (ppApp.Active) Then
                Append_Status("PowerPoint Active")
            Else
                Append_Status("PowerPoint Startup")
                Try
                    ppApp.Activate()
                Catch ex As Exception
                    TestStatus = False
                    Append_Status("PowerPoint Error")
                    Append_Status(ex.Message.ToString)
                End Try
            End If

            System.Threading.Thread.Sleep(1000)

            Append_Status("Version: " + ppApp.Version.ToString)
            Append_Status("Path: " + ppApp.Path.ToString)
            Append_Status("Name: " + ppApp.Name.ToString)

            Try
                ppApp.Quit()
            Catch ex As Exception
                TestStatus = False
                Append_Status("PowerPoint Error")
                Append_Status(ex.Message.ToString)
            End Try

            If (TestStatus) Then
                Append_Status("PowerPoint is working properly")
            Else
                Append_Status("PowerPoint is not configured properly")
            End If
        End If


    End Sub

    ' dgp rev 7/18/08 Change the row count in PowerPoint
    Private Sub NumericRows_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericRows.ValueChanged


    End Sub

    ' dgp rev 7/18/08 Change the column count in PowerPoint
    Private Sub NumericColumns_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericColumns.ValueChanged


    End Sub

    ' dgp rev 7/18/08 Load the form
    Private Sub frmExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Reflect_Count()

    End Sub

    ' dgp rev 7/18/08 Apply settings
    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click

        ExportPVW.ExportRows = NumericRows.Value
        ExportPVW.Cols = NumericColumns.Value
        Me.Close()

    End Sub

End Class