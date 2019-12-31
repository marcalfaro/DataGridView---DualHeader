Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Step1: Add a DataGrdView control to your form.
        '       (Plus points if you anchor all sides to the form :D 


        'Step2: Prepare your source datatable and your new group headers
        Dim dt As DataTable = Nothing                           'This holds your data. You can build this manually or by SQL query.
        Dim groupHeaders As List(Of TopHeaderInfo) = Nothing    'This holds your new group headers
        Prepare_Datatable_For_the_Demo(dt, groupHeaders)


        'Step 3: Build your DGV with Dual Headers
        BuildDualHeader(DataGridView1, dt, groupHeaders)

    End Sub
End Class
