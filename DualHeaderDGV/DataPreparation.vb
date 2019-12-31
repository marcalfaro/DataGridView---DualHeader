Option Explicit On
Module DataPreparation

    'This module is for preparing the datatable only for demo purposes. 

    Public Sub Prepare_Datatable_For_the_Demo(ByRef yourDT As DataTable, ByRef newtopHeader As List(Of TopHeaderInfo))

        'yourDT = This is the datatable that you want to load to your DGV.
        '         This can be a datatable returned by your SQL query, or a manually created datatable. 
        '         For this demo, we will create a manual datatable.

        'newtopHeader = this is the new group headers that we will paint on top of the default DGV headers.

        'For this demo, we will build both the sample datatable and the sample "group headers" together here.

        'Let's begin...


        'Define the datatable's columns (Below are just sample headers).
        Dim hGrp1 As String() = {"ID", "MPN", "Brand", "Product Category", "Description", "Target Price (USD),", "MOQ (Pcs)", "Delivery Terms", "Cost Price", "Points", "Unit Resale Price (EXW)"}
        Dim hGrp2 As String() = {"Total Freight", "Unit Freight", "FORM E Required?", "FORM E Unit Charge (USD),", "Total Custom's Duty (USD),", "Unit Custom's Duty (USD),", "3rd Party Charge (USD),", "VAT Charge", "Total Other Charges"}
        Dim hGrp3 As String() = {"Unit sales to Cust. (USD)"}
        Dim hGrp4 As String() = {"USD", "THB"}
        Dim hGrp5 As String() = {"Unit sales to Cust. (THB)"}
        Dim hGrp6 As String() = {"Total Cost (EXW)", "Total Resale (DAP)", "Total Profit"}
        Dim hGrp7 As String() = {"Unit Value (USD)"}
        Dim hGrp8 As String() = {"Total Freight Charges"}


        'build your datatable, and build the groupheaders at the same time
        yourDT = Nothing
        yourDT = New DataTable

        newtopHeader = Nothing
        newtopHeader = New List(Of TopHeaderInfo)

        With yourDT

            Dim fontToUse As Font = New Font("Arial", 12, FontStyle.Bold)                   'define your new header's font
            Dim firstGroupIndex As Integer = -1
            Dim lastGroupIndex As Integer = -1
            Dim groupHeaderText As String = String.Empty

            With .Columns

                'Add the columns by group, so you can build the groupheaders as simple as possible. Keep track of the first and last indexes

                groupHeaderText = "Group 1"
                firstGroupIndex = 0
                For Each s As String In hGrp1
                    .Add(s)
                Next
                lastGroupIndex = (yourDT.Columns.Count - 1)
                newtopHeader.Add(New TopHeaderInfo With {.firstHeaderText = groupHeaderText, .firstHeaderFont = fontToUse, .firstHeadersBGColor = Color.Yellow, .secondHeaderFirstIndex = firstGroupIndex, .secondHeaderLastIndex = lastGroupIndex})

                groupHeaderText = "Group 2"
                firstGroupIndex = lastGroupIndex + 1
                For Each s As String In hGrp2
                    .Add(s)
                Next
                lastGroupIndex = (yourDT.Columns.Count - 1)
                newtopHeader.Add(New TopHeaderInfo With {.firstHeaderText = groupHeaderText, .firstHeaderFont = fontToUse, .firstHeadersBGColor = Color.Orange, .secondHeaderFirstIndex = firstGroupIndex, .secondHeaderLastIndex = lastGroupIndex})

                groupHeaderText = "Group 3"
                firstGroupIndex = lastGroupIndex + 1
                For Each s As String In hGrp3
                    .Add(s)
                Next
                lastGroupIndex = (yourDT.Columns.Count - 1)
                newtopHeader.Add(New TopHeaderInfo With {.firstHeaderText = groupHeaderText, .firstHeaderFont = fontToUse, .firstHeadersBGColor = Color.Orange, .secondHeaderFirstIndex = firstGroupIndex, .secondHeaderLastIndex = lastGroupIndex})

                groupHeaderText = "Group 4"
                firstGroupIndex = lastGroupIndex + 1
                For Each s As String In hGrp4
                    .Add(s)
                Next
                lastGroupIndex = (yourDT.Columns.Count - 1)
                newtopHeader.Add(New TopHeaderInfo With {.firstHeaderText = groupHeaderText, .firstHeaderFont = fontToUse, .firstHeadersBGColor = Color.Orange, .secondHeaderFirstIndex = firstGroupIndex, .secondHeaderLastIndex = lastGroupIndex})

                groupHeaderText = "Group 5"
                firstGroupIndex = lastGroupIndex + 1
                For Each s As String In hGrp5
                    .Add(s)
                Next
                lastGroupIndex = (yourDT.Columns.Count - 1)
                newtopHeader.Add(New TopHeaderInfo With {.firstHeaderText = groupHeaderText, .firstHeaderFont = fontToUse, .firstHeadersBGColor = Color.Orange, .secondHeaderFirstIndex = firstGroupIndex, .secondHeaderLastIndex = lastGroupIndex})

                groupHeaderText = "Group 6"
                firstGroupIndex = lastGroupIndex + 1
                For Each s As String In hGrp6
                    .Add(s)
                Next
                lastGroupIndex = (yourDT.Columns.Count - 1)
                newtopHeader.Add(New TopHeaderInfo With {.firstHeaderText = groupHeaderText, .firstHeaderFont = fontToUse, .firstHeadersBGColor = Color.Orange, .secondHeaderFirstIndex = firstGroupIndex, .secondHeaderLastIndex = lastGroupIndex})

                groupHeaderText = "Group 7"
                firstGroupIndex = lastGroupIndex + 1
                For Each s As String In hGrp7
                    .Add(s)
                Next
                lastGroupIndex = (yourDT.Columns.Count - 1)
                newtopHeader.Add(New TopHeaderInfo With {.firstHeaderText = groupHeaderText, .firstHeaderFont = fontToUse, .firstHeadersBGColor = Color.Orange, .secondHeaderFirstIndex = firstGroupIndex, .secondHeaderLastIndex = lastGroupIndex})

                groupHeaderText = "Group 8"
                firstGroupIndex = lastGroupIndex + 1
                For Each s As String In hGrp8
                    .Add(s)
                Next
                lastGroupIndex = (yourDT.Columns.Count - 1)
                newtopHeader.Add(New TopHeaderInfo With {.firstHeaderText = groupHeaderText, .firstHeaderFont = fontToUse, .firstHeadersBGColor = Color.Orange, .secondHeaderFirstIndex = firstGroupIndex, .secondHeaderLastIndex = lastGroupIndex})

            End With

        End With

    End Sub

    'My sample datatable is quite wide... LOL

End Module
