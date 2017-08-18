
Imports System.Data.SqlClient

Partial Class MasterGuest
    Inherits System.Web.UI.MasterPage
    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                GetOldData()

                Dim dt As New Data.DataTable
                Dim obj As New MasterGClass
                dt = obj.GetAllCategories

                FillMobileMenu(dt)
                FillWebMenu(dt)
            Catch ex As Exception
                Response.Write("Master " & ex.Message)
            End Try
        End If
    End Sub


    Sub GetOldData()
        Try

            If Request.Cookies("IDMCart") Is Nothing Then
            Else
                Dim obj As New MasterGClass
                Dim TotalPrice As Decimal = 0

                Dim IDMCookie As HttpCookie = Request.Cookies("IDMCart")
                Dim dt As New Data.DataTable
                dt = obj.GetGuestTempCart(IDMCookie.Values("CartId"))

                'Dim gvCart As New GridView
                'gvCart = CType(Me.Master.FindControl("gvCart"), GridView)
                gvCart.DataSource = dt
                gvCart.DataBind()

                For i As Integer = 0 To gvCart.Rows.Count - 1
                    CType(gvCart.Rows(i).Cells(0).FindControl("hlnkImage"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("img1"), Image).ImageUrl = dt.Rows(i).Item("ImagePath").ToString

                    CType(gvCart.Rows(i).Cells(0).FindControl("hdnIdfr"), HiddenField).Value = dt.Rows(i).Item("ProductIdfr").ToString

                    CType(gvCart.Rows(i).Cells(0).FindControl("hlnkName"), HyperLink).NavigateUrl = "ProductDetails.aspx?p=" & dt.Rows(i).Item("ProductIdfr").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblName"), Label).Text = dt.Rows(i).Item("ProductName").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblMRP"), Label).Text = dt.Rows(i).Item("MRP").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblSalePrice"), Label).Text = dt.Rows(i).Item("SalePrice").ToString
                    CType(gvCart.Rows(i).Cells(0).FindControl("lblQty"), Label).Text = dt.Rows(i).Item("Quantity").ToString
                    TotalPrice = TotalPrice + (CDec(dt.Rows(i).Item("SalePrice").ToString) * Val(dt.Rows(i).Item("Quantity").ToString))
                Next

                lblTotalQty.Text = dt.Rows.Count
                lblTotalAmt.Text = TotalPrice
            End If
        Catch ex As Exception
            Response.Write("Inside Old data " & ex.Message)
        End Try

    End Sub

    Sub FillMobileMenu(dt As Data.DataTable)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul style = 'display:none;' class='submenu'>")
        str.Append("<li>")
        str.Append("<ul Class='topnav'>")


        Dim drCat1() As System.Data.DataRow = dt.Select("CategoryIdfr1=0 and CategoryIdfr2=0 and CategoryIdfr3=0")
        For Each dr1 As Data.DataRow In drCat1
            If dr1("CategoryName").ToString = "Events" Then
                str.Append("<li Class='level0 nav-6 level-top first parent'><a class='level-top' href='Events.aspx'><span>" & dr1("CategoryName").ToString & "</span></a>")
            Else
                str.Append("<li Class='level0 nav-6 level-top first parent'><a class='level-top' href='ProductsList.aspx?Cat=" & dr1("CategoryIdfr") & "'><span>" & dr1("CategoryName").ToString & "</span></a>")
            End If


            Dim drCat2() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=0 and CategoryIdfr3=0")
            If drCat2.Length > 0 Then
                str.Append("<ul Class='level0'>")
                For Each dr2 As Data.DataRow In drCat2
                    str.Append("<li Class='level1 nav-6-1 first'><a href='ProductsList.aspx'><span>" & dr2("CategoryName") & "</span></a>")
                    Dim drCat3() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=" & dr2("CategoryIdfr") & " and CategoryIdfr3=0")
                    If drCat3.Length > 0 Then
                        str.Append("<ul Class='level1' style='display: none;'>")
                        For Each dr3 As Data.DataRow In drCat3
                            str.Append("<li Class='level2 nav-6-1-1 first'><a href='ProductsList.aspx'><span>" & dr3("CategoryName") & "</span></a>")
                            Dim drCat4() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=" & dr2("CategoryIdfr") & " and CategoryIdfr3=" & dr3("CategoryIdfr"))
                            If drCat4.Length > 0 Then
                                str.Append("<ul Class='level1' style='display: none;'>")
                                For Each dr4 As Data.DataRow In drCat4
                                    str.Append("<li Class='level2 nav-6-1-1 first'><a href='ProductsList.aspx'><span>" & dr4("CategoryName") & "</span></a></li>")
                                Next
                                str.Append("</ul>")
                            End If
                            str.Append("</li>")
                        Next
                        str.Append("</ul>")
                    End If
                    str.Append("</li>")
                Next
                str.Append("</ul>")
            End If
            str.Append("</li>")
        Next
        str.Append("</ul>")
        str.Append("</li>")
        str.Append("</ul>")
        divmobilemenu.InnerHtml = str.ToString
    End Sub

    Sub FillWebMenu(dt As Data.DataTable)
        Dim str As New System.Text.StringBuilder
        str.Append("<ul id='nav' class='hidden-xs'>")
        'single menu
        str.Append("<li class='level0 nav-8 level-top'><a href='Default.aspx' class='level-top'><span>Home</span></a></li>")
        Dim drCat1() As System.Data.DataRow = dt.Select("CategoryIdfr1=0 and CategoryIdfr2=0 and CategoryIdfr3=0")
        For Each dr1 As Data.DataRow In drCat1
            If dr1("CategoryName") = "Events" Then
                str.Append("<li Class='level0 parent drop-menu'><a href='Events.aspx'><span>" & dr1("CategoryName") & "</span></a>")
            Else
                str.Append("<li Class='level0 parent drop-menu'><a href='ProductsList.aspx?Cat=" & dr1("CategoryIdfr") & "'><span>" & dr1("CategoryName") & "</span></a>")
            End If

            'STart main category (disposables)
            Dim drCat2() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=0 and CategoryIdfr3=0")
            If drCat2.Length > 0 Then
                str.Append("<ul Class='level1'>")
                For Each dr2 As Data.DataRow In drCat2
                    str.Append("<li Class='level1 first parent'><a href='ProductsList.aspx?Cat=" & dr2("CategoryIdfr") & "'><span>" & dr2("CategoryName") & "</span></a>")
                    Dim drCat3() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=" & dr2("CategoryIdfr") & " and CategoryIdfr3=0")
                    If drCat3.Length > 0 Then
                        str.Append("<ul Class='level1'>")
                        For Each dr3 As Data.DataRow In drCat3
                            str.Append("<li Class='level1 first'><a href='ProductsList.aspx?Cat=" & dr3("CategoryIdfr") & "'><span>" & dr3("CategoryName") & "</span></a>")
                            Dim drCat4() As System.Data.DataRow = dt.Select("CategoryIdfr1=" & dr1("CategoryIdfr") & " and CategoryIdfr2=" & dr2("CategoryIdfr") & " and CategoryIdfr3=" & dr3("CategoryIdfr"))
                            If drCat4.Length > 0 Then
                                str.Append("<ul Class='level2 right-sub'>")
                                For Each dr4 As Data.DataRow In drCat4
                                    str.Append("<li Class='level2 nav-2-1-1 first'><a href='ProductsList.aspx?Cat=" & dr4("CategoryIdfr") & "'><span>" & dr4("CategoryName") & "</span></a></li>")
                                Next
                                str.Append("</ul>")
                            End If
                            str.Append("</li>")
                        Next
                        str.Append("</ul>")
                    End If


                    str.Append("</li>")
                Next
                str.Append("</ul>")
            End If
            str.Append("</li>") 'end main category (disposables)
        Next
        divmainmenu.InnerHtml = str.ToString
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        If txtSearch.Text.Trim <> "" Then
            Response.Redirect("ProductSearch.aspx?Cat=" & txtSearch.Text.Trim, False)
        End If
    End Sub
End Class

#Region "MasterGClass"

Public Class MasterGClass
    Inherits ConnectionClass
    Public Function GetAllCategories() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select CategoryIdfr,CategoryName,CategoryIdfr1,CategoryIdfr2,CategoryIdfr3 from IMART_Category where AStatus='ACTIVE' order by CategoryIdfr1,CategoryIdfr2,CategoryIdfr3", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetLatestProducts() As Data.DataTable
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 6 ProductIdfr,ProductName,MRP,SalePrice from IMART_Products where AStatus='ACTIVE' order by ProductIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function GetCategoryProducts(CategoryIdfr As Integer) As Data.DataTable
        ' Dim da As New Data.SqlClient.SqlDataAdapter("Select top 8 ProductIdfr,ProductName,MRP,SalePrice from IMART_Products where CategoryIdfr1=" & CategoryIdfr & " order by ProductIdfr desc", Con)
        Dim da As New Data.SqlClient.SqlDataAdapter("Select top 8 ProductIdfr,ProductName,MRP,SalePrice from IMART_Products where AStatus='ACTIVE' order by ProductIdfr desc", Con)
        Dim dt As New Data.DataTable
        da.Fill(dt)
        Return dt
    End Function

    Public Function Insert(ByVal CategoryName As String, ParentCategoryIdfr As Integer) As String
        Try
            Con.Open()
            cmd.CommandText = "Insert into IMART_Category(CategoryName,ParentCategoryIdfr) values ('" & CategoryName & "'," & ParentCategoryIdfr & ")"
            cmd.ExecuteNonQuery()

            Return "OK"
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
        Catch SQL As SqlException
            Return False
        Catch ex As Exception
            Return False
        Finally
            Con.Close()
        End Try
    End Function
    Public Function Update(CategoryIdfr As Integer, ByVal CategoryName As String, ParentCategoryIdfr As Integer) As String
        Dim myTrans As Data.SqlClient.SqlTransaction = Nothing
        Try
            Dim cmd As New Data.SqlClient.SqlCommand
            cmd.Connection = Con

            Con.Open()
            myTrans = Con.BeginTransaction
            cmd.Transaction = myTrans

            cmd.CommandText = "Update IMART_Category set ParentCategoryIdfr=" & ParentCategoryIdfr & ",CategoryName='" & CategoryName & "' where CategoryIdfr =" & CategoryIdfr & ""
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




