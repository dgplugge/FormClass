' Name:     Form Style
' Author:   Donald G Plugge
' Date:     2/1/2012
' Purpose:  Unify Form Style
Public Class FormStyle

    Private Shared mBackColor = Nothing
    Private Shared mButtonColor As Color
    ' dgp rev 2/1/2012
    Public Shared ReadOnly Property BackColor As System.Drawing.Color
        Get
            If mBackColor Is Nothing Then mBackColor = Windows.Forms.Control.DefaultBackColor
            Return mBackColor
        End Get
    End Property

    ' dgp rev 2/1/2012 Sync the current form to match the style of the master form
    Public Shared Sub Sync2Master(ByVal myform As Windows.Forms.Form)

        myform.BackColor = mBackColor
        Dim cntr As Control
        For Each cntr In myform.Controls
            Dim info = cntr.GetType()
            If mColorHash.ContainsKey(info.name) Then
                cntr.BackColor = mColorHash(info.name)
            End If
        Next

    End Sub

    Private Shared mColorHash As New Hashtable

    ' dgp rev 2/1/2012 Retrieve masterform settings
    Public Shared Sub MasterForm(ByVal myform As Windows.Forms.Form)

        mBackColor = myform.BackColor
        mColorHash = New Hashtable
        Dim cntr As Control
        For Each cntr In myform.Controls
            Dim info = cntr.GetType()
            If Not mColorHash.ContainsKey(info.name) Then
                mColorHash.Add(info.name, cntr.BackColor)
            End If
        Next

    End Sub

End Class
