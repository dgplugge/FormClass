' Name:      
' Author:   Donald G Plugge
' Date:     10/26/2010
' Purpose:  
Imports DGVPrinter
Imports System.Threading
Imports HelperClasses

Public Class frmDGVForm


    Private mColMargin
    Private mRowMargin

    Private mCloseRight
    Private mCloseBottom
    Private mPrintRight
    Private mPrintBottom

    Public FormDataTable As System.Data.DataTable
    Public FormUser As String

    Public FormUpload As FCS_Classes.FCSUpload

    Private mDGVPrinter As DGVPrinterHelper.DGVPrinter

    Private mTitle As String
    Public Property Title As String
        Get
            Return mTitle
        End Get
        Set(ByVal value As String)
            mTitle = value
        End Set
    End Property

    ' dgp rev 20/26/2010
    Private Sub frmDGVForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvProtocol.DataSource = FormDataTable

        mCloseRight = Width - cmdClose.Location.X
        mCloseBottom = Height - cmdClose.Location.Y
        mPrintRight = Width - cmdPrintOp.Location.X
        mPrintBottom = Height - cmdPrintOp.Location.Y

        mColMargin = (Width - dgvProtocol.Width)
        mRowMargin = (Height - dgvProtocol.Height) + mColMargin
        mDGVPrinter = New DGVPrinterHelper.DGVPrinter
        mDGVPrinter.PorportionalColumns = True
        mDGVPrinter.Title = Title

        Me.BringToFront()
        Me.Refresh()

    End Sub

    ' dgp rev 20/26/2010 Send protocol to printer
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintOp.Click

        mDGVPrinter.PrintDataGridView(dgvProtocol)

    End Sub


    ' dgp rev 4/15/09 Resizing the form
    Private Sub Resize_Form()

        dgvProtocol.AutoResizeColumns()
        dgvProtocol.AutoResizeRows()

        ' dgp rev 4/13/09 Close Form
        dgvProtocol.Width = Me.Width - mColMargin
        dgvProtocol.Height = Me.Height - mRowMargin

        'cmdClose.Location = New Point(Me.Width - mCloseRight, Me.Height - mCloseBottom)
        'cmdPrint.Location = New Point(Me.Width - mPrintRight, Me.Height - mPrintBottom)

        dgvProtocol.Refresh()

    End Sub

    Private Sub frmDGVForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Resize_Form()

    End Sub

    Private Sub cmdClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private mGridPrinter As HelperClasses.DataGridPrinter
    Private mDataGrid As System.Windows.Forms.DataGrid

    Private Sub ThreadHandler()

        If mGridPrinter.PrintDocument.PrinterSettings.IsValid = True Then
            mGridPrinter.Print()
        End If

    End Sub

    Public Sub columns_autoresize(ByRef sqlGrid As DataGrid)

        Try
            Dim t As Type = sqlGrid.GetType
            Dim m As Reflection.MethodInfo = t.GetMethod("ColAutoResize", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)

            Dim i As Integer = sqlGrid.FirstVisibleColumn
            Dim j As Integer = sqlGrid.VisibleColumnCount
            Do While i < j
                m.Invoke(sqlGrid, New Object() {i})
                i = i + 1
            Loop
        Catch ex As Exception
            Trace.Write("Failed to resize column: " + ex.ToString + vbCrLf)
        End Try
    End Sub

    ' dgp rev 12/11/08 Vantage Printing
    Private Sub Print_Operator()

        If mGridPrinter Is Nothing Then

            mDataGrid = New DataGrid
            mDataGrid.DataSource = FormDataTable
            columns_autoresize(Me.mDataGrid)
            mGridPrinter = New DataGridPrinter(Me.mDataGrid)
        End If

        With mGridPrinter
            FCS_Classes.FCSProtocolPrinter.PrinterConfig()

            .HeaderText = FCS_Classes.FCSProtocolPrinter.mHeaderText
            .HeaderHeightPercent = FCS_Classes.FCSProtocolPrinter.mHeaderHeightPercent
            .FooterHeightPercent = FCS_Classes.FCSProtocolPrinter.mFooterHeightPercent
            .InterSectionSpacingPercent = FCS_Classes.FCSProtocolPrinter.mInterSectionSpacingPercent
            .HeaderPen = FCS_Classes.FCSProtocolPrinter.mFooterPen
            .FooterPen = FCS_Classes.FCSProtocolPrinter.mFooterPen
            .GridPen = FCS_Classes.FCSProtocolPrinter.mGridPen
            .HeaderBrush = FCS_Classes.FCSProtocolPrinter.mHeaderBrush
            .EvenRowBrush = FCS_Classes.FCSProtocolPrinter.mEvenRowBrush
            .OddRowBrush = FCS_Classes.FCSProtocolPrinter.mOddRowBrush
            .FooterBrush = FCS_Classes.FCSProtocolPrinter.mFooterBrush
            .ColumnHeaderBrush = FCS_Classes.FCSProtocolPrinter.mColumnHeaderBrush
            .PagesAcross = FCS_Classes.FCSProtocolPrinter.mPagesAcross
            .PrintDocument.PrinterSettings.PrinterName = "\\nt-eib-10-6b16\EIB Flow Lab 6B16"
            .PrintDocument.DefaultPageSettings.Landscape = True
        End With

        Dim objThread As New Thread(New ThreadStart(AddressOf ThreadHandler))
        objThread.Name = "SendPrintJob"
        objThread.Start()

    End Sub



    ' dgp rev 4/12/2011 Print to operator
    Private Sub cmdPrintOper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintOper.Click

        Print_Operator()

    End Sub

End Class