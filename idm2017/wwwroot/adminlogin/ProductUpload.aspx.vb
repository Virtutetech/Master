Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports OfficeOpenXml

Partial Class ProductUpload
    Inherits System.Web.UI.Page
    Dim obj As New ProductUploadClass
    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        'If Session("UserLevel") Is Nothing Then
        '    Response.Redirect("Default.aspx", True)
        'End If
        'If Session("UserLevel").ToString = "" Then
        '    Response.Redirect("Default.aspx", True)
        'End If
        'If Session("UserLevel") = "SUPERADMIN" Then
        '    Page.MasterPageFile = "MasterSuperAdmin.master"
        'End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ""
        If Not IsPostBack Then
            Try
                ' BindGrid()
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try

        End If
    End Sub
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Try



            If (fileupload1.HasFile) Then        ' CHECK IF ANY FILE HAS BEEN SELECTED.

                If System.IO.Path.GetExtension(fileupload1.FileName).ToUpper <> ".XLSX" Then
                    lblmsg.Text = "Plese select .XLSX files only"
                    Exit Sub
                End If
                If System.IO.Directory.Exists(Server.MapPath("Docs/ExcelData")) = False Then
                    System.IO.Directory.CreateDirectory(Server.MapPath("Docs/ExcelData"))
                End If

                If System.IO.File.Exists(Server.MapPath("Docs/ExcelData/4.xlsx")) Then
                    System.IO.File.Delete(Server.MapPath("Docs/ExcelData/4.xlsx"))
                End If

                'Save the uploaded Excel file.
                Dim fs As System.IO.Stream = fileupload1.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                File.WriteAllBytes(Server.MapPath("Docs/ExcelData/4.xlsx"), bytes)
                Dim filePath As String = Server.MapPath("Docs/ExcelData/4.xlsx")
                'fileupload1.SaveAs(filePath)

                'Open the Excel file in Read Mode using OpenXml.
                Using doc As SpreadsheetDocument = SpreadsheetDocument.Open(filePath, False)
                    'Read the first Sheet from Excel file.
                    Dim sheet As Sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild(Of Sheet)()

                    'Get the Worksheet instance.
                    Dim worksheet As Worksheet = TryCast(doc.WorkbookPart.GetPartById(sheet.Id.Value), WorksheetPart).Worksheet

                    'Fetch all the rows present in the Worksheet.
                    Dim rows As IEnumerable(Of Row) = worksheet.GetFirstChild(Of SheetData)().Descendants(Of Row)()

                    'Create a new DataTable.
                    Dim dt As New DataTable()

                    'Loop through the Worksheet rows.
                    For Each row As Row In rows
                        'Use the first row to add columns to DataTable.
                        If row.RowIndex.Value = 1 Then
                            For Each cell As Cell In row.Descendants(Of Cell)()
                                dt.Columns.Add(GetValue(doc, cell))
                            Next
                        Else
                            'Add rows to DataTable.
                            dt.Rows.Add()
                            Dim i As Integer = 0
                            For Each cell As Cell In row.Descendants(Of Cell)()
                                dt.Rows(dt.Rows.Count - 1)(i) = GetValue(doc, cell)
                                i += 1
                            Next
                        End If
                    Next

                    lblmsg.Text = obj.UploadData(dt)

                    gv.DataSource = dt
                    gv.DataBind()

                End Using
            End If
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub
    Private Function GetValue(doc As SpreadsheetDocument, cell As Cell) As String
        If cell.CellValue Is Nothing Then
            Return "-"
        End If
        Dim value As String = cell.CellValue.InnerText
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
            Dim str As String = doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(Integer.Parse(value)).InnerText
            Return str
        End If
        Return value
    End Function

End Class


Public Class ProductUploadClass
    Inherits ConnectionClass
    Public Function UploadData(dt As Data.DataTable) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            For i As Integer = 0 To dt.Rows.Count - 1
                Dim CategoryIdfr1 As Integer = 0
                Dim CategoryIdfr2 As Integer = 0
                Dim CategoryIdfr3 As Integer = 0
                Dim CategoryIdfr4 As Integer = 0
                Dim BrandIdfr As Integer = 0

                Dim CategoryName1 As String = dt.Rows(i).Item("MainCategory").ToString.Replace("'", "`")
                Dim CategoryName2 As String = dt.Rows(i).Item("SubCategory1").ToString.Replace("'", "`")
                Dim CategoryName3 As String = dt.Rows(i).Item("SubCategory2").ToString.Replace("'", "`")
                Dim CategoryName4 As String = dt.Rows(i).Item("SubCategory3").ToString.Replace("'", "`")
                Dim ProductName As String = dt.Rows(i).Item("ProductName").ToString.Replace("'", "`")
                Dim ShortDesc As String = dt.Rows(i).Item("ShortDescription").ToString.Replace("'", "`")
                Dim BrandName As String = dt.Rows(i).Item("Brand").ToString.Replace("'", "`")
                Dim MRP As String = dt.Rows(i).Item("MRP").ToString.Replace("'", "`")
                Dim SalePrice As String = dt.Rows(i).Item("SalePrice").ToString.Replace("'", "`")
                Dim ImagePath As String = dt.Rows(i).Item("ImagePath").ToString.Replace("'", "`")
                Dim Keywords As String = dt.Rows(i).Item("Keywords").ToString.Replace("'", "`").ToUpper
                Dim AStatus As String = dt.Rows(i).Item("Status").ToString.Replace("'", "`").ToUpper


                'Check for CategoryIdfr1
                If CategoryName1.ToUpper <> "NONE" Then
                    cmd.CommandText = "Select CategoryIdfr from IMART_Category where CategoryName='" & CategoryName1 & "' and CategoryIdfr1=0 and CategoryIdfr2=0 and CategoryIdfr3=0"
                    If cmd.ExecuteScalar Is Nothing Then
                        cmd.CommandText = "Insert into IMART_Category(CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,AStatus) values ('" & CategoryName1 & "',0,0,0,'ACTIVE'); select Max(CategoryIdfr) from IMART_Category"
                        CategoryIdfr1 = CType(cmd.ExecuteScalar, Integer)
                    Else
                        CategoryIdfr1 = CType(cmd.ExecuteScalar, Integer)
                    End If
                End If
                'Check for CategoryIdfr2
                If CategoryName2.ToUpper <> "NONE" Then
                    cmd.CommandText = "Select CategoryIdfr from IMART_Category where CategoryName='" & CategoryName2 & "' and CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=0 and CategoryIdfr3=0"
                    If cmd.ExecuteScalar Is Nothing Then
                        cmd.CommandText = "Insert into IMART_Category(CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,AStatus) values ('" & CategoryName2 & "'," & CategoryIdfr1 & ",0,0,'ACTIVE'); select Max(CategoryIdfr) from IMART_Category"
                        CategoryIdfr2 = CType(cmd.ExecuteScalar, Integer)
                    Else
                        CategoryIdfr2 = CType(cmd.ExecuteScalar, Integer)
                    End If
                End If

                'Check for CategoryIdfr3
                If CategoryName3.ToUpper <> "NONE" Then
                    cmd.CommandText = "Select CategoryIdfr from IMART_Category where CategoryName='" & CategoryName3 & "' and CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=" & CategoryIdfr2 & " and CategoryIdfr3=0"
                    If cmd.ExecuteScalar Is Nothing Then
                        cmd.CommandText = "Insert into IMART_Category(CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,AStatus) values ('" & CategoryName3 & "'," & CategoryIdfr1 & "," & CategoryIdfr2 & ",0,'ACTIVE'); select Max(CategoryIdfr) from IMART_Category"
                        CategoryIdfr3 = CType(cmd.ExecuteScalar, Integer)
                    Else
                        CategoryIdfr3 = CType(cmd.ExecuteScalar, Integer)
                    End If
                End If

                'Check for CategoryIdfr4
                If CategoryName4.ToUpper <> "NONE" Then
                    cmd.CommandText = "Select CategoryIdfr from IMART_Category where CategoryName='" & CategoryName4 & "' and CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=" & CategoryIdfr2 & " and CategoryIdfr3=" & CategoryIdfr3 & ""
                    If cmd.ExecuteScalar Is Nothing Then
                        cmd.CommandText = "Insert into IMART_Category(CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,AStatus) values ('" & CategoryName4 & "'," & CategoryIdfr1 & "," & CategoryIdfr2 & "," & CategoryIdfr3 & ",'ACTIVE'); select Max(CategoryIdfr) from IMART_Category"
                        CategoryIdfr4 = CType(cmd.ExecuteScalar, Integer)
                    Else
                        CategoryIdfr4 = CType(cmd.ExecuteScalar, Integer)
                    End If
                End If

                'Check for BrandIdfr
                cmd.CommandText = "Select BrandIdfr from IMART_Brands where BrandName='" & BrandName & "'"
                If cmd.ExecuteScalar Is Nothing Then
                    cmd.CommandText = "Insert into IMART_Brands(BrandName,ImagePath,DeleteStatus) values ('" & BrandName & "','-','NO'); select Max(BrandIdfr) from IMART_Brands"
                    BrandIdfr = CType(cmd.ExecuteScalar, Integer)
                Else
                    BrandIdfr = CType(cmd.ExecuteScalar, Integer)
                End If

                'Upload Products
                Dim ProductIdfr As Integer = 0
                cmd.CommandText = "Select ProductIdfr from IMART_Products where ProductName='" & ProductName & "' and CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=" & CategoryIdfr2 & " and CategoryIdfr3=" & CategoryIdfr3 & " and CategoryIdfr4=" & CategoryIdfr4 & ""
                If cmd.ExecuteScalar Is Nothing Then
                    cmd.CommandText = "Insert into IMART_Products(CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductName,ShortDescription,BrandIdfr,MRP,SalePrice,ImagePath,Keywords,AStatus,IsVariant) values (" & CategoryIdfr1 & "," & CategoryIdfr2 & "," & CategoryIdfr3 & "," & CategoryIdfr4 & ",'" & ProductName & "','" & ShortDesc & "'," & BrandIdfr & "," & MRP & "," & SalePrice & ",'" & ImagePath & "','" & Keywords & "','" & AStatus & "','NO');select max(ProductIdfr) from IMART_Products"
                    ProductIdfr = CType(cmd.ExecuteScalar, Integer)
                Else
                    ProductIdfr = CType(cmd.ExecuteScalar, Integer)
                    cmd.CommandText = "Update IMART_Products set CategoryIdfr1=" & CategoryIdfr1 & ",CategoryIdfr2=" & CategoryIdfr2 & ",CategoryIdfr3=" & CategoryIdfr3 & ",ProductName='" & ProductName & "',ShortDescription='" & ShortDesc & "',BrandIdfr=" & BrandIdfr & ",MRP=" & MRP & ",SalePrice=" & SalePrice & ",AStatus='" & AStatus & "',Keywords='" & Keywords & "' where ProductIdfr=" & ProductIdfr & ""
                    cmd.ExecuteNonQuery()
                End If
            Next

            myTrans.Commit()
            Return "OK"
        Catch ex As Exception
            myTrans.Rollback()
            Return ex.Message
        Finally
            Con.Close()
        End Try

    End Function
End Class

