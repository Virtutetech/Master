Imports System.Data.SqlClient

Partial Class AddProduct
    Inherits System.Web.UI.Page
    Dim obj As New AddProductClass
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblmsg.Text = ""
        If Not IsPostBack Then
            Try
                FillParentCategories()
                BindGrid()
            Catch ex As Exception
                lblmsg.Text = ex.Message
            End Try
        End If
    End Sub

    Sub FillParentCategories()
        Dim dt As New Data.DataTable
        dt = obj.GetCategories(0, 0)
        ddlCategory1.DataSource = dt
        ddlCategory1.DataTextField = "CategoryName"
        ddlCategory1.DataValueField = "CategoryIdfr"
        ddlCategory1.DataBind()

        ddlCategory1.Items.Add(New ListItem("None", 0))
        ddlCategory1.SelectedIndex = ddlCategory1.Items.Count - 1

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetCategories(ddlCategory1.SelectedValue, 1)
        ddlCategory2.DataSource = dt
        ddlCategory2.DataTextField = "CategoryName"
        ddlCategory2.DataValueField = "CategoryIdfr"
        ddlCategory2.DataBind()

        ddlCategory2.Items.Add(New ListItem("None", 0))
        ddlCategory2.SelectedIndex = ddlCategory2.Items.Count - 1

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetCategories(ddlCategory2.SelectedValue, 2)
        ddlCategory3.DataSource = dt
        ddlCategory3.DataTextField = "CategoryName"
        ddlCategory3.DataValueField = "CategoryIdfr"
        ddlCategory3.DataBind()

        ddlCategory3.Items.Add(New ListItem("None", 0))
        ddlCategory3.SelectedIndex = ddlCategory3.Items.Count - 1

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetCategories(ddlCategory3.SelectedValue, 3)
        ddlCategory4.DataSource = dt
        ddlCategory4.DataTextField = "CategoryName"
        ddlCategory4.DataValueField = "CategoryIdfr"
        ddlCategory4.DataBind()

        ddlCategory4.Items.Add(New ListItem("None", 0))
        ddlCategory4.SelectedIndex = ddlCategory4.Items.Count - 1

        dt.Rows.Clear()
        dt.Columns.Clear()
        dt = obj.GetBrands
        ddlBrand.DataSource = dt
        ddlBrand.DataTextField = "BrandName"
        ddlBrand.DataValueField = "BrandIdfr"
        ddlBrand.DataBind()

        ddlBrand.Items.Add(New ListItem("Select", 0))
        ddlBrand.SelectedIndex = ddlBrand.Items.Count - 1
    End Sub

    Protected Sub ddlCategory1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory1.SelectedIndexChanged
        FillSubCategory(1)
        BindGrid()
    End Sub

    Protected Sub ddlCategory2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory2.SelectedIndexChanged
        FillSubCategory(2)
        BindGrid()
    End Sub

    Protected Sub ddlCategory3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory3.SelectedIndexChanged
        FillSubCategory(3)
        BindGrid()
    End Sub

    Protected Sub ddlCategory4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategory4.SelectedIndexChanged
        BindGrid()
    End Sub

    Sub BindGrid()
        Dim dt As New Data.DataTable
        dt = obj.GetAllProducts(ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue)
        gv.Columns(1).Visible = True
        gv.Columns(8).Visible = True
        gv.Columns(10).Visible = True
        gv.DataSource = dt
        gv.DataBind()
        For i As Integer = 0 To gv.Rows.Count - 1
            Try
                CType(gv.Rows(i).Cells(7).FindControl("img1"), Image).ImageUrl = "http://www.indiandentalmart.com/Docs/" & gv.Rows(i).Cells(1).Text & "/Gallery/" & System.IO.Path.GetFileName(System.IO.Directory.GetFiles(Server.MapPath("../Docs/") & gv.Rows(i).Cells(1).Text & "\Gallery")(0))
            Catch ex As Exception

            End Try
        Next
        gv.Columns(1).Visible = False
        gv.Columns(8).Visible = False
        gv.Columns(10).Visible = False
        If dt.Rows.Count <= 0 Then
            lblmsg.Text = "No records"
        End If
    End Sub

    Sub FillSubCategory(ddl As Integer)
        Dim dt As New Data.DataTable
        If ddl = 1 Then
            dt = obj.GetCategories(ddlCategory1.SelectedValue, ddl)
            ddlCategory2.DataSource = dt
            ddlCategory2.DataTextField = "CategoryName"
            ddlCategory2.DataValueField = "CategoryIdfr"
            ddlCategory2.DataBind()

            ddlCategory2.Items.Add(New ListItem("None", 0))
            ddlCategory2.SelectedIndex = ddlCategory2.Items.Count - 1
        ElseIf ddl = 2 Then
            dt = obj.GetCategories(ddlCategory2.SelectedValue, ddl)
            ddlCategory3.DataSource = dt
            ddlCategory3.DataTextField = "CategoryName"
            ddlCategory3.DataValueField = "CategoryIdfr"
            ddlCategory3.DataBind()

            ddlCategory3.Items.Add(New ListItem("None", 0))
            ddlCategory3.SelectedIndex = ddlCategory3.Items.Count - 1
        Else
            dt = obj.GetCategories(ddlCategory3.SelectedValue, ddl)
            ddlCategory4.DataSource = dt
            ddlCategory4.DataTextField = "CategoryName"
            ddlCategory4.DataValueField = "CategoryIdfr"
            ddlCategory4.DataBind()

            ddlCategory4.Items.Add(New ListItem("None", 0))
            ddlCategory4.SelectedIndex = ddlCategory4.Items.Count - 1
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If btnSubmit.Text = "Save" Then
                lblmsg.Text = obj.CheckExists(txtProduct.Text.Trim.Replace("'", "`"), ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue)
                If lblmsg.Text = "OK" Then
                    lblmsg.Text = obj.Insert(ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue, txtProduct.Text.Trim.Replace("'", "`"), txtShortDesc.Text.Trim.Replace("'", "`"), ddlBrand.SelectedValue, txtMRP.Text.Trim.Replace("'", "`"), txtSalePrice.Text.Trim.Replace("'", "`"), fileupload1.PostedFile.FileName, ddlStatus.SelectedItem.Text, txtKeywords.Text.Trim.Replace("'", "`"))
                    If lblmsg.Text.StartsWith("OK") = True Then

                        Dim ProductIdfr As String = lblmsg.Text.Split(":")(1)
                        If System.IO.Directory.Exists(Server.MapPath("../Docs/") & ProductIdfr) = False Then
                            System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/") & ProductIdfr)
                        End If
                        System.IO.File.WriteAllText(Server.MapPath("../Docs/") & ProductIdfr & "/" & ProductIdfr & ".txt", txtDesc.Text)

                        If System.IO.Directory.Exists(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery") = False Then
                            System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery")
                        End If
                        Dim filename As String = System.IO.Path.GetFileName(fileupload1.FileName)
                        fileupload1.SaveAs(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery/" & filename)

                        lblmsg.Text = "Insertion success"
                        BindGrid()
                        txtProduct.Text = ""
                        txtDesc.Text = ""
                        txtShortDesc.Text = ""
                        txtMRP.Text = ""
                        txtSalePrice.Text = ""
                        txtKeywords.Text = ""
                    End If
                End If

            ElseIf btnSubmit.Text = "Update" Then
                lblmsg.Text = obj.CheckExists(txtProduct.Text.Trim.Replace("'", "`"), ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue, hdnId.Value)
                If lblmsg.Text = "OK" Then
                    Dim filename As String
                    If fileupload1.HasFile Then
                        filename = System.IO.Path.GetFileName(fileupload1.FileName)
                    Else
                        filename = "-"
                    End If
                    lblmsg.Text = obj.Update(hdnId.Value, ddlCategory1.SelectedValue, ddlCategory2.SelectedValue, ddlCategory3.SelectedValue, ddlCategory4.SelectedValue, txtProduct.Text.Trim.Replace("'", "`"), txtShortDesc.Text.Trim.Replace("'", "`"), ddlBrand.SelectedValue, txtMRP.Text.Trim.Replace("'", "`"), txtSalePrice.Text.Trim.Replace("'", "`"), filename, ddlStatus.SelectedItem.Text, txtKeywords.Text.Trim.Replace("'", "`"))
                    If lblmsg.Text = "OK" Then
                        If filename <> "-" Then
                            Dim ProductIdfr As String = hdnId.Value
                            If System.IO.Directory.Exists(Server.MapPath("../Docs/") & ProductIdfr) = False Then
                                System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/") & ProductIdfr)
                            End If
                            System.IO.File.WriteAllText(Server.MapPath("../Docs/") & ProductIdfr & "/" & ProductIdfr & ".txt", txtDesc.Text)

                            If System.IO.Directory.Exists(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery") = False Then
                                System.IO.Directory.CreateDirectory(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery")
                            End If

                            fileupload1.SaveAs(Server.MapPath("../Docs/") & ProductIdfr & "/Gallery/" & filename)
                        End If
                        lblmsg.Text = "Updation success"
                        BindGrid()
                        txtProduct.Text = ""
                        txtDesc.Text = ""
                        txtShortDesc.Text = ""
                        txtMRP.Text = ""
                        txtSalePrice.Text = ""
                        txtKeywords.Text = ""
                        btnSubmit.Text = "Save"
                    End If
                End If

            End If
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try
    End Sub

    Protected Sub lnkEdit_Click(sender As Object, e As EventArgs)
        Try
            btnSubmit.Text = "Update"
            Dim lnk As New LinkButton
            lnk = sender

            Dim tr As TableRow = lnk.Parent.Parent
            hdnId.Value = tr.Cells(1).Text
            txtProduct.Text = tr.Cells(2).Text
            txtShortDesc.Text = tr.Cells(4).Text
            If System.IO.File.Exists(Server.MapPath("Docs/") & hdnId.Value & "/" & hdnId.Value & ".txt") Then
                txtDesc.Text = System.IO.File.ReadAllText(Server.MapPath("Docs/") & hdnId.Value & "/" & hdnId.Value & ".txt")
            End If

            For i As Integer = 0 To ddlBrand.Items.Count - 1
                If ddlBrand.Items(i).Value = tr.Cells(8).Text Then
                    ddlBrand.SelectedIndex = i
                    Exit For
                End If
            Next
            txtMRP.Text = tr.Cells(5).Text
            txtSalePrice.Text = tr.Cells(6).Text
            For i As Integer = 0 To ddlStatus.Items.Count - 1
                If ddlStatus.Items(i).Text = tr.Cells(9).Text Then
                    ddlStatus.SelectedIndex = i
                    Exit For
                End If
            Next
            txtKeywords.Text = tr.Cells(10).Text
        Catch ex As Exception
            lblmsg.Text = ex.Message
        End Try


    End Sub

End Class

#Region "AddProductClass"

Public Class AddProductClass
    Inherits ConnectionClass
    Public Function GetCategories(CategoryIdfr As Integer, level As Integer) As Data.DataTable
        Dim da As Data.SqlClient.SqlDataAdapter
        If level = 0 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName from IMART_Category where CategoryIdfr1=0", Con)
        ElseIf level = 1 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,(Select CategoryName from IMART_Category b where b.CategoryIdfr=a.CategoryIdfr1)+'/'+CategoryName CategoryName from IMART_Category a where CategoryIdfr1=" & CategoryIdfr & " and CategoryIdfr1>0 and CategoryIdfr2=0 and CategoryIdfr3=0", Con)
        ElseIf level = 2 Then
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName from IMART_Category where CategoryIdfr1>0 and CategoryIdfr2>0 and CategoryIdfr2=" & CategoryIdfr & " and CategoryIdfr3=0", Con)
        Else
            da = New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName from IMART_Category where CategoryIdfr1>0 and CategoryIdfr2>0 and CategoryIdfr3>0 and CategoryIdfr3=" & CategoryIdfr & "", Con)
        End If
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetAllProducts(CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, CategoryIdfr4 As Integer) As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select ProductIdfr,ProductName,ShortDescription,BrandIdfr,MRP,SalePrice,ImagePath,(Select BrandName from IMART_Brands where BrandIdfr=IMART_Products.BrandIdfr) BrandName,AStatus,Keywords from IMART_Products where CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=" & CategoryIdfr2 & " and CategoryIdfr3=" & CategoryIdfr3 & " and CategoryIdfr4=" & CategoryIdfr4 & "", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetBrands() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select BrandIdfr,BrandName from IMART_Brands order by BrandName", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function CheckExists(ByVal ProductName As String, CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, CategoryIdfr4 As Integer, Optional ByVal Idfr As Integer = 0) As String
        cmd.CommandText = "Select ProductName from IMART_Products where ProductName='" & ProductName & "' and CategoryIdfr1=" & CategoryIdfr1 & " and CategoryIdfr2=" & CategoryIdfr2 & " and CategoryIdfr3=" & CategoryIdfr3 & " and CategoryIdfr4=" & CategoryIdfr4 & " And ProductIdfr <> " & Idfr & ""
        Try
            Con.Open()
            If cmd.ExecuteScalar Is Nothing Then
                Return "OK"
            Else
                Return "Product already exists"
            End If
        Catch Sql As SqlException
            Return Sql.Message
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function Insert(CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, CategoryIdfr4 As Integer, ProductName As String, ShortDesc As String, BrandIdfr As Integer, MRP As Decimal, SalePrice As Decimal, ImagePath As String, AStatus As String, Keywords As String) As String
        Try
            Con.Open()

            cmd.CommandText = "Insert into IMART_Products(CategoryIdfr1,CategoryIdfr2,CategoryIdfr3,CategoryIdfr4,ProductName,ShortDescription,BrandIdfr,MRP,SalePrice,ImagePath,AStatus,isVariant,Keywords) values (" & CategoryIdfr1 & "," & CategoryIdfr2 & "," & CategoryIdfr3 & "," & CategoryIdfr4 & ",'" & ProductName & "','" & ShortDesc & "'," & BrandIdfr & "," & MRP & "," & SalePrice & ",'" & ImagePath & "','" & AStatus & "','NO','" & Keywords & "');select max(ProductIdfr) from IMART_Products"
            Dim Idfr As Integer = CType(cmd.ExecuteScalar, Integer)

            Dim NewImagepath As String = "http://www.IndianDentalMart.com/Docs/" & Idfr & "/Gallery/" & System.IO.Path.GetFileName(ImagePath)
            cmd.CommandText = "Update IMART_Products set ImagePath='" & NewImagepath & "' where ProductIdfr=" & Idfr & ""
            cmd.ExecuteNonQuery()

            Return "OK:" & Idfr
        Catch ex As SqlException
            Return ex.Message
        Catch ex As Exception
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

    Public Function Delete(ByVal MainCategoryIdfr As Integer) As Boolean
        cmd.CommandText = "Delete from IMART_MainCategory where MainCategoryIdfr=" & MainCategoryIdfr & ""
        Try
            Con.Open()
            ' cmd.ExecuteNonQuery()
            Return True
        Catch Sql As SqlException
            Return False
        Catch ex As Exception
            Return False
        Finally
            Con.Close()
        End Try
    End Function
    Public Function Update(ProductIdfr As Integer, CategoryIdfr1 As Integer, CategoryIdfr2 As Integer, CategoryIdfr3 As Integer, CategoryIdfr4 As Integer, ProductName As String, ShortDesc As String, BrandIdfr As Integer, MRP As Decimal, SalePrice As Decimal, filename As String, AStatus As String, Keywords As String) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            Dim NewImagepath As String = ""
            If filename <> "-" Then
                NewImagepath = "http://www.IndianDentalMart.com/Docs/" & ProductIdfr & "/Gallery/" & filename
                cmd.CommandText = "Update IMART_Products set ImagePath='" & NewImagepath & "' where ProductIdfr=" & ProductIdfr & ""
                cmd.ExecuteNonQuery()
            End If

            cmd.CommandText = "Update IMART_Products set CategoryIdfr1=" & CategoryIdfr1 & ",CategoryIdfr2=" & CategoryIdfr2 & ",CategoryIdfr3=" & CategoryIdfr3 & ",ProductName='" & ProductName & "',ShortDescription='" & ShortDesc & "',BrandIdfr=" & BrandIdfr & ",MRP=" & MRP & ",SalePrice=" & SalePrice & ",AStatus='" & AStatus & "',Keywords='" & Keywords & "' where ProductIdfr=" & ProductIdfr & ""
            cmd.ExecuteNonQuery()

            myTrans.Commit()
            Return "OK"
        Catch ex As SqlException
            myTrans.Rollback()
            Return ex.Message
        Catch ex As Exception
            myTrans.Rollback()
            Return ex.Message
        Finally
            Con.Close()
        End Try
    End Function

End Class

#End Region