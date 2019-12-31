Option Explicit On
Module DualHeaderDGV

#Region " Dual Headers "

    'We will use this class to design and build our top header
    Public Class TopHeaderInfo
        Public firstHeaderText As String
        Public firstHeaderFont As Font
        Public firstHeadersBGColor As Color
        Public secondHeaderFirstIndex As Integer
        Public secondHeaderLastIndex As Integer
    End Class

    Private TopHeaders As List(Of TopHeaderInfo) = Nothing

    ''' <summary>
    ''' Call this to build another header on top of your default headers
    ''' </summary>
    ''' <param name="dgv">Your DataGridView</param>
    ''' <param name="srcDT">Your source datatable</param>
    ''' <param name="yourTopHeaders">Your new group headers</param>
    Public Sub BuildDualHeader(ByVal dgv As DataGridView, ByVal srcDT As DataTable, ByVal yourTopHeaders As List(Of TopHeaderInfo))
        DoubleBuffer(dgv)
        With dgv
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = .ColumnHeadersHeight * 3 'change this if you want.
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

            TopHeaders = yourTopHeaders

            AddHandler .Paint, AddressOf dgv__Paint
            AddHandler .Scroll, AddressOf dgv__InvalidateHeaders
            AddHandler .ColumnWidthChanged, AddressOf dgv__InvalidateHeaders

            .DataSource = srcDT
        End With
    End Sub

    Private Sub dgv__InvalidateHeaders(ByVal sender As Object, ByVal e As EventArgs)
        Dim dg = CType(sender, DataGridView)
        dg.SuspendLayout()
        Dim rtHeader As Rectangle = dg.DisplayRectangle
        rtHeader.Height = dg.ColumnHeadersHeight / 2
        dg.Invalidate(rtHeader)
        dg.ResumeLayout()
    End Sub

    Private Sub dgv__Paint(ByVal sender As Object, ByVal e As PaintEventArgs)

        Dim dg = CType(sender, DataGridView)

        Dim ttlGrp As Integer = TopHeaders.Count        'we will iterate thru your specific column grouping
        For i As Integer = 0 To (ttlGrp - 1)

            Dim foundIndex As Boolean = False
            Dim headerRec As Rectangle = Nothing

            Dim grp As TopHeaderInfo = TopHeaders(i)
            For index = grp.secondHeaderFirstIndex To grp.secondHeaderLastIndex

                If Not foundIndex Then
                    headerRec = dg.GetCellDisplayRectangle(index, -1, True)     'this is the starting column to paint your new top header
                    If headerRec.Width > 0 Then foundIndex = True
                Else
                    Dim r2 As Rectangle = dg.GetCellDisplayRectangle(index, -1, True)   'this holds the rest of the spanned columns
                    headerRec.Width += r2.Width
                End If

            Next

            If foundIndex AndAlso headerRec.Width > 0 Then

                headerRec.X += 1                            'Optional. Indent a bit to emphasize the left border
                headerRec.Y += 2                            'Optional. Indent a bit to emphasize the top border
                headerRec.Width -= 3                        'Optional. Make the new header's width shorter to emphasize the right border
                headerRec.Height = (headerRec.Height / 3)   'The height of your new painted header

                Using br As New SolidBrush(grp.firstHeadersBGColor)
                    e.Graphics.FillRectangle(br, headerRec)

                    'Below 2 lines are Optional. They add a gray border to your new painted header
                    Dim myPen As Pen = New Pen(Drawing.Color.Gray, 1)
                    e.Graphics.DrawRectangle(myPen, headerRec)
                End Using

                Using br As New SolidBrush(dg.ColumnHeadersDefaultCellStyle.ForeColor)

                    'Dim drawFont As Font = New Font("Arial", 12, FontStyle.Bold)                               'just a doodle
                    'Dim drawFont As Font = dg.ColumnHeadersDefaultCellStyle.Font                               'just a doodle
                    'Dim drawFont As Font = New Font(dg.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold)     'just a doodle

                    Dim sf As New StringFormat()
                    sf.Alignment = StringAlignment.Center
                    sf.LineAlignment = StringAlignment.Center
                    'e.Graphics.DrawString(grp.firstHeaderText, dg.ColumnHeadersDefaultCellStyle.Font, br, headerRec, sf)   'Use this if you want to inherit the default fontStyle
                    e.Graphics.DrawString(grp.firstHeaderText, grp.firstHeaderFont, br, headerRec, sf)
                End Using

            End If

        Next

    End Sub
#End Region

    ''' <summary>
    ''' DoubleBuffering will reduce flickers on our DGV
    ''' </summary>
    ''' <param name="DGV"></param>
    Private Sub DoubleBuffer(ByVal DGV As DataGridView)
        Try
            DGV.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, DGV, New Object() {True})
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub


End Module
